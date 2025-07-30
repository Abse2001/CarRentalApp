using CarRentalApp.Helpers;
using CarRentalApp.Models;
using CarRentalApp.Services;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace CarRentalApp.DAL
{
    public class UserManagment : DbHelper, IUserManagment
    {
        private readonly ActivityServices _activityServices;

        public UserManagment()
        {
            _activityServices = new ActivityServices();
        }

        public User Authenticate(string username, string password)
        {
            try
            {
   

                OpenConnection();

                string query = @"SELECT Id, Username, PasswordHash, UserRole, Balance, 
                         FirstName, LastName, DateCreated, LastLogin, IsLocked, 
                         NumberOfBookings, FailedLoginAttempts, LockoutEnd
                         FROM Users 
                         WHERE Username = @Username AND DeletedAt IS NULL";

                using var cmd = new SqlCommand(query, connection);
                cmd.Parameters.AddWithValue("@Username", username);

                using var reader = cmd.ExecuteReader();

                if (!reader.Read())
                {
                    MessageBox.Show("No user found.");
                    return null;
                }


                var user = new User
                {
                    Id = reader.GetInt32(0),
                    Username = reader.GetString(1),
                    PasswordHash = reader.GetString(2),
                    UserRole = (User.Role)reader.GetInt32(3),
                    Balance = reader.GetDecimal(4),
                    FirstName = reader.IsDBNull(5) ? null : reader.GetString(5),
                    LastName = reader.IsDBNull(6) ? null : reader.GetString(6),
                    DateCreated = reader.GetDateTime(7),
                    LastLogin = reader.IsDBNull(8) ? null : reader.GetDateTime(8),
                    IsLocked = reader.GetBoolean(9),
                    NumberOfBookings = reader.GetInt32(10),
                    FailedLoginAttempts = reader.GetInt32(11),
                    LockoutEnd = reader.IsDBNull(12) ? (DateTime?)null : reader.GetDateTime(12)
                };

                if (user.LockoutEnd.HasValue && user.LockoutEnd.Value > DateTime.UtcNow)
                {
                    MessageBox.Show("User is locked out.");
                    return null;
                }

                bool verified = PasswordHelper.VerifyPassword(password, user.PasswordHash);
                reader.Close();

                if (!verified)
                {
                    MessageBox.Show("Password incorrect. Incrementing failed attempts...");
                    IncrementFailedLogin(user.Id, user.FailedLoginAttempts + 1);
                    return null;
                }

                ResetFailedLogin(user.Id);
                return user;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Authenticate error: " + ex.Message, "DEBUG");
                throw;
            }
            finally
            {
                CloseConnection();
            }
        }



        public User GetByUsername(string username)
        {
            try
            {
                OpenConnection();
                string query = @"SELECT Id, Username, PasswordHash, UserRole, Balance, 
                                 FirstName, LastName, DateCreated, LastLogin, IsLocked, 
                                 NumberOfBookings, FailedLoginAttempts, LockoutEnd
                                 FROM Users 
                                 WHERE Username = @Username AND DeletedAt IS NULL";

                using var cmd = new SqlCommand(query, connection);
                cmd.Parameters.AddWithValue("@Username", username);

                using var reader = cmd.ExecuteReader();
                if (!reader.Read())
                    return null;

                return new User
                {
                    Id = reader.GetInt32(0),
                    Username = reader.GetString(1),
                    PasswordHash = reader.GetString(2),
                    UserRole = (User.Role)reader.GetInt32(3),
                    Balance = reader.GetDecimal(4),
                    FirstName = reader.IsDBNull(5) ? null : reader.GetString(5),
                    LastName = reader.IsDBNull(6) ? null : reader.GetString(6),
                    DateCreated = reader.GetDateTime(7),
                    LastLogin = reader.IsDBNull(8) ? null : reader.GetDateTime(8),
                    IsLocked = reader.GetBoolean(9),
                    NumberOfBookings = reader.GetInt32(10),
                    FailedLoginAttempts = reader.GetInt32(11),
                    LockoutEnd = reader.IsDBNull(12) ? (DateTime?)null : reader.GetDateTime(12)
                };
            }
            finally
            {
                CloseConnection();
            }
        }

        private void IncrementFailedLogin(int userId, int newFailedCount)
        {
            string lockoutSql = "";
            if (newFailedCount >= 4)
            {
                lockoutSql = ", LockoutEnd = DATEADD(minute, 4, GETUTCDATE())";
            }

            string updateSql = $@"
                UPDATE Users SET FailedLoginAttempts = @FailedLoginAttempts {lockoutSql}
                WHERE Id = @Id";

            using var updateCmd = new SqlCommand(updateSql, connection);
            updateCmd.Parameters.AddWithValue("@FailedLoginAttempts", newFailedCount);
            updateCmd.Parameters.AddWithValue("@Id", userId);
            updateCmd.ExecuteNonQuery();
        }

        public int IncrementFailedLoginAttempt(string username)
        {
            try
            {
                OpenConnection();

                string updateSql = @"
                    UPDATE Users 
                    SET FailedLoginAttempts = FailedLoginAttempts + 1 
                    OUTPUT INSERTED.FailedLoginAttempts
                    WHERE Username = @Username AND DeletedAt IS NULL";

                using var cmd = new SqlCommand(updateSql, connection);
                cmd.Parameters.AddWithValue("@Username", username);

                return (int)cmd.ExecuteScalar();
            }
            finally
            {
                CloseConnection();
            }
        }

        public void ResetFailedLogin(int userId)
        {
            try
            {
                OpenConnection();  

                string updateSql = @"
            UPDATE Users SET FailedLoginAttempts = 0, LockoutEnd = NULL
            WHERE Id = @Id";

                using var updateCmd = new SqlCommand(updateSql, connection);
                updateCmd.Parameters.AddWithValue("@Id", userId);
                updateCmd.ExecuteNonQuery();
            }
            finally
            {
                CloseConnection();  
            }
        }

        public void ResetFailedLoginAttemptsAndLockout(int userId)
        {
            ResetFailedLogin(userId);
        }


        public void LockAccount(int userId, int lockMinutes = 4)
        {
            try
            {
                OpenConnection();
                string query = @"UPDATE Users SET LockoutEnd = DATEADD(MINUTE, @LockMinutes, GETUTCDATE()) WHERE Id = @UserId AND DeletedAt IS NULL";
                using var cmd = new SqlCommand(query, connection);
                cmd.Parameters.AddWithValue("@UserId", userId);
                cmd.Parameters.AddWithValue("@LockMinutes", lockMinutes);
                cmd.ExecuteNonQuery();
            }
            finally
            {
                CloseConnection();
            }
        }

        public bool IsUserLockedOut(string username)
        {
            try
            {
                OpenConnection();

                string query = @"SELECT LockoutEnd FROM Users WHERE Username = @Username AND DeletedAt IS NULL";
                using var cmd = new SqlCommand(query, connection);
                cmd.Parameters.AddWithValue("@Username", username);

                var result = cmd.ExecuteScalar();
                if (result != null && result != DBNull.Value)
                {
                    DateTime lockoutEnd = (DateTime)result;
                    return lockoutEnd > DateTime.UtcNow;
                }
                return false;
            }
            finally
            {
                CloseConnection();
            }
        }

        public bool UpdateBalance(int userId, decimal amount)
        {
            try
            {
                OpenConnection();
                string query = @"UPDATE Users SET 
                          Balance = Balance + @Amount
                          WHERE Id = @Id AND DeletedAt IS NULL";

                using (SqlCommand cmd = new SqlCommand(query, connection))
                {
                    cmd.Parameters.AddWithValue("@Id", userId);
                    cmd.Parameters.AddWithValue("@Amount", amount);
                    return cmd.ExecuteNonQuery() > 0;
                }
            }
            finally
            {
                CloseConnection();
            }
        }

        public bool IncrementBookingCount(int userId)
        {
            try
            {
                OpenConnection();
                string query = @"UPDATE Users SET 
                          NumberOfBookings = NumberOfBookings + 1
                          WHERE Id = @Id AND DeletedAt IS NULL";

                using (SqlCommand cmd = new SqlCommand(query, connection))
                {
                    cmd.Parameters.AddWithValue("@Id", userId);
                    return cmd.ExecuteNonQuery() > 0;
                }
            }
            finally
            {
                CloseConnection();
            }
        }

        public IEnumerable<User> GetAll()
        {
            List<User> users = new List<User>();
            try
            {
                OpenConnection();
                string query = @"SELECT Id, Username, UserRole, FirstName, LastName, 
                        Balance, DateCreated, LastLogin, IsLocked, NumberOfBookings
                        FROM Users WHERE DeletedAt IS NULL";

                using (var cmd = new SqlCommand(query, connection))
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        users.Add(new User
                        {
                            Id = reader.GetInt32(0),
                            Username = reader.GetString(1),
                            UserRole = (User.Role)reader.GetInt32(2),
                            FirstName = reader.IsDBNull(3) ? null : reader.GetString(3),
                            LastName = reader.IsDBNull(4) ? null : reader.GetString(4),
                            Balance = reader.GetDecimal(5),
                            DateCreated = reader.GetDateTime(6),
                            LastLogin = reader.IsDBNull(7) ? null : reader.GetDateTime(7),
                            IsLocked = reader.GetBoolean(8),
                            NumberOfBookings = reader.GetInt32(9)
                        });
                    }
                }
            }
            finally
            {
                CloseConnection();
            }
            return users;
        }

        public User GetById(int id)
        {
            try
            {
                OpenConnection();
                string query = @"SELECT Id, Username, UserRole, Balance, FirstName, LastName, 
                               DateCreated, LastLogin, IsLocked, NumberOfBookings 
                               FROM Users WHERE Id = @Id AND DeletedAt IS NULL";

                using (var cmd = new SqlCommand(query, connection))
                {
                    cmd.Parameters.AddWithValue("@Id", id);
                    using (var reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            return new User
                            {
                                Id = reader.GetInt32(0),
                                Username = reader.GetString(1),
                                UserRole = (User.Role)reader.GetInt32(2),
                                Balance = reader.GetDecimal(3),
                                FirstName = reader.IsDBNull(4) ? null : reader.GetString(4),
                                LastName = reader.IsDBNull(5) ? null : reader.GetString(5),
                                DateCreated = reader.GetDateTime(6),
                                LastLogin = reader.IsDBNull(7) ? null : reader.GetDateTime(7),
                                IsLocked = reader.GetBoolean(8),
                                NumberOfBookings = reader.GetInt32(9)
                            };
                        }
                    }
                }
                return null;
            }
            finally
            {
                CloseConnection();
            }
        }

        public bool Add(User user, User userToBeAdded)
        {
            try
            {
                OpenConnection();
                string query = @"INSERT INTO Users 
                       (Username, PasswordHash, UserRole, FirstName, LastName) 
                       VALUES 
                       (@Username, @PasswordHash, @Role, @FirstName, @LastName);
                       SELECT CAST(scope_identity() AS int)";

                using (var cmd = new SqlCommand(query, connection))
                {
                    cmd.Parameters.AddWithValue("@Username", userToBeAdded.Username);
                    cmd.Parameters.AddWithValue("@PasswordHash", PasswordHelper.HashPassword(userToBeAdded.PasswordHash));
                    cmd.Parameters.AddWithValue("@Role", (int)userToBeAdded.UserRole);
                    cmd.Parameters.AddWithValue("@FirstName", userToBeAdded.FirstName ?? (object)DBNull.Value);
                    cmd.Parameters.AddWithValue("@LastName", userToBeAdded.LastName ?? (object)DBNull.Value);

                    int newUserId = (int)cmd.ExecuteScalar();

                    _activityServices.LogActivity(user.Id, user.Username, $"Added new user: {userToBeAdded.Username}");

                    return newUserId > 0;
                }
            }
            finally
            {
                CloseConnection();
            }
        }

        public bool Update(User user, User userToBeUpdated)
        {
            try
            {
                OpenConnection();
                string query = @"UPDATE Users SET 
                               Username = @Username,
                               FirstName = @FirstName,
                               LastName = @LastName,
                               IsLocked = @IsLocked,
                               Balance = @Balance
                               WHERE Id = @Id";

                using (var cmd = new SqlCommand(query, connection))
                {
                    cmd.Parameters.AddWithValue("@Id", userToBeUpdated.Id);
                    cmd.Parameters.AddWithValue("@Username", userToBeUpdated.Username);
                    cmd.Parameters.AddWithValue("@FirstName", userToBeUpdated.FirstName ?? (object)DBNull.Value);
                    cmd.Parameters.AddWithValue("@LastName", userToBeUpdated.LastName ?? (object)DBNull.Value);
                    cmd.Parameters.AddWithValue("@IsLocked", userToBeUpdated.IsLocked);
                    cmd.Parameters.AddWithValue("@Balance", userToBeUpdated.Balance);

                    int rowsAffected = cmd.ExecuteNonQuery();

                    if (rowsAffected > 0)
                    {
                        _activityServices.LogActivity(user.Id, user.Username, $"Updated user details for: {userToBeUpdated.Username}");
                    }

                    return rowsAffected > 0;
                }
            }
            finally
            {
                CloseConnection();
            }
        }

        public bool Delete(User user, User userToBeDeleted)
        {
            try
            {
                OpenConnection();
                string query = "UPDATE Users SET DeletedAt = GETUTCDATE() WHERE Id = @Id";
                using (var cmd = new SqlCommand(query, connection))
                {
                    cmd.Parameters.AddWithValue("@Id", userToBeDeleted.Id);
                    int rowsAffected = cmd.ExecuteNonQuery();

                    if (rowsAffected > 0)
                    {
                        _activityServices.LogActivity(user.Id, user.Username, $"Deleted user with username: {userToBeDeleted.Username}");
                    }

                    return rowsAffected > 0;
                }
            }
            finally
            {
                CloseConnection();
            }
        }

        public bool UsernameExists(string username)
        {
            try
            {
                OpenConnection();
                string query = "SELECT COUNT(1) FROM Users WHERE Username = @Username AND DeletedAt IS NULL";
                using (var cmd = new SqlCommand(query, connection))
                {
                    cmd.Parameters.AddWithValue("@Username", username);
                    return (int)cmd.ExecuteScalar() > 0;
                }
            }
            finally
            {
                CloseConnection();
            }
        }

        public TimeSpan? GetLockoutRemaining(string username)
        {
            try
            {
                OpenConnection();
                string query = @"SELECT 
            CASE 
                WHEN LockoutEnd > GETUTCDATE() THEN DATEDIFF(SECOND, GETUTCDATE(), LockoutEnd)
                ELSE NULL 
            END AS RemainingSeconds
            FROM Users WHERE Username = @Username AND DeletedAt IS NULL";

                using (var cmd = new SqlCommand(query, connection))
                {
                    cmd.Parameters.AddWithValue("@Username", username);
                    var result = cmd.ExecuteScalar();

                    if (result != null && result != DBNull.Value)
                    {
                        int seconds = Convert.ToInt32(result);
                        return TimeSpan.FromSeconds(seconds);
                    }
                    return null;
                }
            }
            finally
            {
                CloseConnection();
            }
        }



        public void UpdateLastLogin(int userId)
        {
            try
            {
                OpenConnection();
                string query = "UPDATE Users SET LastLogin = GETUTCDATE() WHERE Id = @Id";
                using (var cmd = new SqlCommand(query, connection))
                {
                    cmd.Parameters.AddWithValue("@Id", userId);
                    cmd.ExecuteNonQuery();
                }
            }
            finally
            {
                CloseConnection();
            }
        }


    }
}
