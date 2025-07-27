using CarRentalApp.Helpers;
using CarRentalApp.Models;
using CarRentalApp.Services;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace CarRentalApp.DAL
{
    public class CarManagment : DbHelper, ICarManagment
    {
        private readonly ActivityServices _activityService;

        public CarManagment()
        {
            _activityService = new ActivityServices();
        }

        public bool Add(Car car)
        {
            try
            {
                OpenConnection();
                string query = @"
                    INSERT INTO Cars 
                    (PlateNumber, Brand, Model, Year, Color, RentalPricePerDay, Status, ImageName)
                    VALUES 
                    (@PlateNumber, @Brand, @Model, @Year, @Color, @RentalPricePerDay, @Status, @ImageName)";

                using var cmd = new SqlCommand(query, connection);
                cmd.Parameters.AddWithValue("@PlateNumber", car.PlateNumber);
                cmd.Parameters.AddWithValue("@Brand", car.Brand);
                cmd.Parameters.AddWithValue("@Model", car.Model);
                cmd.Parameters.AddWithValue("@Year", car.Year);
                cmd.Parameters.AddWithValue("@Color", car.Color);
                cmd.Parameters.AddWithValue("@RentalPricePerDay", car.RentalPricePerDay);
                cmd.Parameters.AddWithValue("@Status", car.Status);
                cmd.Parameters.AddWithValue("@ImageName", car.ImageName ?? (object)DBNull.Value);

                if (cmd.ExecuteNonQuery() > 0)
                {
                    var user = AppCtx.CurrentUser;
                    if (user != null)
                        _activityService.LogActivity( user.Id, user.Username, $"Added car {car.Model}");
                    return true;
                }
                return false;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Add Car Error: {ex.Message}", "Error");
                return false;
            }
            finally
            {
                CloseConnection();
            }
        }

        public bool Delete(int carId)
        {
            try
            {
                OpenConnection();
                string query = @"UPDATE Cars SET DeletedAt = GETUTCDATE() WHERE Id = @Id";

                using var cmd = new SqlCommand(query, connection);
                cmd.Parameters.AddWithValue("@Id", carId);

                if (cmd.ExecuteNonQuery() > 0)
                {
                    var user = AppCtx.CurrentUser;
                    if (user != null)
                        _activityService.LogActivity(user.Id, user.Username, $"Deleted car ID {carId}");
                    return true;
                }
                return false;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Delete Car Error: {ex.Message}", "Error");
                return false;
            }
            finally
            {
                CloseConnection();
            }
        }

        public IEnumerable<Car> GetAll()
        {
            var cars = new List<Car>();

            try
            {
                OpenConnection();
                string query = @"
                    SELECT TOP (1000) Id, PlateNumber, Brand, Model, Year, Color, RentalPricePerDay, Status, ImageName
                    FROM Cars
                    WHERE DeletedAt IS NULL";

                using var cmd = new SqlCommand(query, connection);
                using var reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    cars.Add(new Car
                    {
                        CarId = reader.GetInt32(0),
                        PlateNumber = reader.GetString(1),
                        Brand = reader.GetString(2),
                        Model = reader.GetString(3),
                        Year = reader.GetInt32(4),
                        Color = reader.GetString(5),
                        RentalPricePerDay = reader.GetDecimal(6),
                        Status = reader.GetString(7),
                        ImageName = reader.IsDBNull(8) ? null : reader.GetString(8)
                    });
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"GetAll Cars Error: {ex.Message}", "Error");
            }
            finally
            {
                CloseConnection();
            }

            return cars;
        }

        public Car GetById(int id)
        {
            try
            {
                OpenConnection();
                string query = @"
                    SELECT Id, PlateNumber, Brand, Model, Year, Color, RentalPricePerDay, Status, ImageName
                    FROM Cars
                    WHERE Id = @Id AND DeletedAt IS NULL";

                using var cmd = new SqlCommand(query, connection);
                cmd.Parameters.AddWithValue("@Id", id);

                using var reader = cmd.ExecuteReader();

                if (reader.Read())
                {
                    return new Car
                    {
                        CarId = reader.GetInt32(0),
                        PlateNumber = reader.GetString(1),
                        Brand = reader.GetString(2),
                        Model = reader.GetString(3),
                        Year = reader.GetInt32(4),
                        Color = reader.GetString(5),
                        RentalPricePerDay = reader.GetDecimal(6),
                        Status = reader.GetString(7),
                        ImageName = reader.IsDBNull(8) ? null : reader.GetString(8)
                    };
                }
                return null;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"GetById Car Error: {ex.Message}", "Error");
                return null;
            }
            finally
            {
                CloseConnection();
            }
        }

        public bool PlateNumberExists(string plateNumber)
        {
            try
            {
                OpenConnection();
                string query = @"SELECT COUNT(1) FROM Cars WHERE PlateNumber = @PlateNumber AND DeletedAt IS NULL";

                using var cmd = new SqlCommand(query, connection);
                cmd.Parameters.AddWithValue("@PlateNumber", plateNumber);

                int count = (int)cmd.ExecuteScalar();
                return count > 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"PlateNumberExists Error: {ex.Message}", "Error");
                return false;
            }
            finally
            {
                CloseConnection();
            }
        }

        public bool Update(Car car)
        {
            try
            {
                OpenConnection();
                string query = @"
                    UPDATE Cars SET
                        PlateNumber = @PlateNumber,
                        Brand = @Brand,
                        Model = @Model,
                        Year = @Year,
                        Color = @Color,
                        RentalPricePerDay = @RentalPricePerDay,
                        Status = @Status,
                        ImageName = @ImageName
                    WHERE Id = @Id AND DeletedAt IS NULL";

                using var cmd = new SqlCommand(query, connection);
                cmd.Parameters.AddWithValue("@Id", car.CarId);
                cmd.Parameters.AddWithValue("@PlateNumber", car.PlateNumber);
                cmd.Parameters.AddWithValue("@Brand", car.Brand);
                cmd.Parameters.AddWithValue("@Model", car.Model);
                cmd.Parameters.AddWithValue("@Year", car.Year);
                cmd.Parameters.AddWithValue("@Color", car.Color);
                cmd.Parameters.AddWithValue("@RentalPricePerDay", car.RentalPricePerDay);
                cmd.Parameters.AddWithValue("@Status", car.Status);
                cmd.Parameters.AddWithValue("@ImageName", car.ImageName ?? (object)DBNull.Value);

                if (cmd.ExecuteNonQuery() > 0)
                {
                    var user = AppCtx.CurrentUser;
                    if (user != null)
                        _activityService.LogActivity(user.Id, user.Username, $"Updated car ID {car.CarId} ({car.PlateNumber})");
                    return true;
                }
                return false;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Update Car Error: {ex.Message}", "Error");
                return false;
            }
            finally
            {
                CloseConnection();
            }
        }

        public bool UpdateCarStatus(int carId, string newStatus)
        {
            try
            {
                OpenConnection();
                string query = @"UPDATE Cars SET Status = @Status WHERE Id = @Id AND DeletedAt IS NULL";

                using var cmd = new SqlCommand(query, connection);
                cmd.Parameters.AddWithValue("@Status", newStatus);
                cmd.Parameters.AddWithValue("@Id", carId);

                if (cmd.ExecuteNonQuery() > 0)
                {
                    var user = AppCtx.CurrentUser;
                    if (user != null)
                        _activityService.LogActivity( user.Id, user.Username, $"Updated status of car ID {carId} to '{newStatus}'");
                    return true;
                }
                return false;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"UpdateCarStatus Error: {ex.Message}", "Error");
                return false;
            }
            finally
            {
                CloseConnection();
            }
        }

        public IEnumerable<Car> GetAvailableCars()
        {
            var availableCars = new List<Car>();

            try
            {
                OpenConnection();
                string query = @"
                    SELECT Id, PlateNumber, Brand, Model, Year, Color, RentalPricePerDay, Status, ImageName
                    FROM Cars
                    WHERE Status = 'Available' AND DeletedAt IS NULL";

                using var cmd = new SqlCommand(query, connection);
                using var reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    availableCars.Add(new Car
                    {
                        CarId = reader.GetInt32(0),
                        PlateNumber = reader.GetString(1),
                        Brand = reader.GetString(2),
                        Model = reader.GetString(3),
                        Year = reader.GetInt32(4),
                        Color = reader.GetString(5),
                        RentalPricePerDay = reader.GetDecimal(6),
                        Status = reader.GetString(7),
                        ImageName = reader.IsDBNull(8) ? null : reader.GetString(8)
                    });
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"GetAvailableCars Error: {ex.Message}", "Error");
            }
            finally
            {
                CloseConnection();
            }

            return availableCars;
        }

        public bool RentNow(int carId, int customerId, DateTime dueDate)
        {
            try
            {
                OpenConnection();

                using var transaction = connection.BeginTransaction();

                // Check car availability
                string checkQuery = @"SELECT Status FROM Cars WHERE Id = @CarId AND DeletedAt IS NULL";
                using (var checkCmd = new SqlCommand(checkQuery, connection, transaction))
                {
                    checkCmd.Parameters.AddWithValue("@CarId", carId);
                    var status = checkCmd.ExecuteScalar()?.ToString();
                    if (status == null || status != "Available")
                    {
                        MessageBox.Show("Car is not available for rent.", "Warning");
                        transaction.Rollback();
                        return false;
                    }
                }

                // Update car status to "Rented"
                string updateStatusQuery = @"UPDATE Cars SET Status = 'Rented' WHERE Id = @CarId AND DeletedAt IS NULL";
                using (var updateCmd = new SqlCommand(updateStatusQuery, connection, transaction))
                {
                    updateCmd.Parameters.AddWithValue("@CarId", carId);
                    if (updateCmd.ExecuteNonQuery() == 0)
                    {
                        transaction.Rollback();
                        return false;
                    }
                }

                // Insert rental record
                string rentalLogQuery = @"
            INSERT INTO CarRentals (CarId, CustomerId, RentedAt, DueDate)
            VALUES (@CarId, @CustomerId, GETUTCDATE(), @DueDate)";
                using (var rentalCmd = new SqlCommand(rentalLogQuery, connection, transaction))
                {
                    rentalCmd.Parameters.AddWithValue("@CarId", carId);
                    rentalCmd.Parameters.AddWithValue("@CustomerId", customerId);
                    rentalCmd.Parameters.AddWithValue("@DueDate", dueDate);
                    rentalCmd.ExecuteNonQuery();
                }

                transaction.Commit();

                // Log activity outside the transaction (safe even if it fails)
                var user = AppCtx.CurrentUser;
                if (user != null)
                {
                    _activityService.LogActivity(user.Id, user.Username, $"Rented car ID {carId} to customer ID {customerId}, due {dueDate:yyyy-MM-dd}");
                }

                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"RentNow Error: {ex.Message}", "Error");
                return false;
            }
            finally
            {
                CloseConnection();
            }
        }


        public bool ReturnNow(int carId)
        {
            try
            {
                OpenConnection();

                // Update latest rental for this car to set ReturnedAt if not already set
                string updateRentalQuery = @"
                    UPDATE CarRentals
                    SET ReturnedAt = GETUTCDATE()
                    WHERE CarId = @CarId AND ReturnedAt IS NULL";
                using (var rentalCmd = new SqlCommand(updateRentalQuery, connection))
                {
                    rentalCmd.Parameters.AddWithValue("@CarId", carId);
                    if (rentalCmd.ExecuteNonQuery() == 0)
                    {
                        MessageBox.Show("No active rental found for this car.", "Warning");
                        return false;
                    }
                }

                // Update car status back to "Available"
                string updateCarQuery = @"UPDATE Cars SET Status = 'Available' WHERE Id = @CarId AND DeletedAt IS NULL";
                using var carCmd = new SqlCommand(updateCarQuery, connection);
                carCmd.Parameters.AddWithValue("@CarId", carId);

                if (carCmd.ExecuteNonQuery() > 0)
                {
                    var user = AppCtx.CurrentUser;
                    if (user != null)
                        _activityService.LogActivity(user.Id, user.Username, $"Returned car ID {carId}");

                    return true;
                }
                return false;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"ReturnNow Error: {ex.Message}", "Error");
                return false;
            }
            finally
            {
                CloseConnection();
            }
        }

        public IEnumerable<CarRental> GetRentalsByCarId(int carId)
        {
            var rentals = new List<CarRental>();
            try
            {
                OpenConnection();

                string query = @"
                    SELECT Id, CarId, CustomerId, RentedAt, DueDate, ReturnedAt
                    FROM CarRentals
                    WHERE CarId = @CarId";

                using var cmd = new SqlCommand(query, connection);
                cmd.Parameters.AddWithValue("@CarId", carId);

                using var reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    rentals.Add(new CarRental
                    {
                        Id = reader.GetInt32(0),
                        CarId = reader.GetInt32(1),
                        CustomerId = reader.GetInt32(2),
                        RentedAt = reader.GetDateTime(3),
                        DueDate = reader.GetDateTime(4),
                        ReturnedAt = reader.IsDBNull(5) ? (DateTime?)null : reader.GetDateTime(5)
                    });
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"GetRentalsByCarId Error: {ex.Message}", "Error");
            }
            finally
            {
                CloseConnection();
            }
            return rentals;
        }

        public Customer GetCustomerById(int customerId)
        {
            try
            {
                OpenConnection();

                string query = @"
                    SELECT CustomerId, FirstName, LastName, Phone, Email, DrivingLicenseNum, Nationality, DateOfBirth
                    FROM Customers
                    WHERE CustomerId = @CustomerId";

                using var cmd = new SqlCommand(query, connection);
                cmd.Parameters.AddWithValue("@CustomerId", customerId);

                using var reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    return new Customer
                    {
                        CustomerId = reader.GetInt32(0),
                        FirstName = reader.GetString(1),
                        LastName = reader.GetString(2),
                        Phone = reader.GetString(3),
                        Email = reader.GetString(4),
                        DrivingLicenseNum = reader.GetString(5),
                        Nationality = reader.GetString(6),
                        DateOfBirth = reader.GetDateTime(7),
                    };
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"GetCustomerById Error: {ex.Message}", "Error");
            }
            finally
            {
                CloseConnection();
            }
            return null;
        }

        public Car GetByPlate(string plateNumber)
        {
            try
            {
                OpenConnection();
                string query = @"
                    SELECT Id, PlateNumber, Brand, Model, Year, Color, RentalPricePerDay, Status, ImageName
                    FROM Cars
                    WHERE PlateNumber = @PlateNumber AND DeletedAt IS NULL";

                using var cmd = new SqlCommand(query, connection);
                cmd.Parameters.AddWithValue("@PlateNumber", plateNumber);

                using var reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    return new Car
                    {
                        CarId = reader.GetInt32(0),
                        PlateNumber = reader.GetString(1),
                        Brand = reader.GetString(2),
                        Model = reader.GetString(3),
                        Year = reader.GetInt32(4),
                        Color = reader.GetString(5),
                        RentalPricePerDay = reader.GetDecimal(6),
                        Status = reader.GetString(7),
                        ImageName = reader.IsDBNull(8) ? null : reader.GetString(8)
                    };
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"GetByPlate Error: {ex.Message}", "Error");
            }
            finally
            {
                CloseConnection();
            }

            return null;
        }
    }
}
