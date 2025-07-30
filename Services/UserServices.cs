using CarRentalApp.DAL;
using CarRentalApp.Models;
using System;
using System.Collections.Generic;

namespace CarRentalApp.Services
{
    public class UserService
    {
        private readonly IUserManagment _userRepo;

        private const int MaxFailedAttempts = 4;
        private const int LockoutMinutes = 4;

        public UserService(IUserManagment userRepo)
        {
            _userRepo = userRepo;
        }

        public User Login(string username, string password)
        {
            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
                throw new ArgumentException("Username and password are required.");

            var user = _userRepo.GetByUsername(username);

            if (user == null)
                throw new Exception("Invalid username or password.");

            var lockoutEnd = user.LockoutEnd;
            if (lockoutEnd.HasValue && lockoutEnd.Value > DateTime.UtcNow)
            {
                TimeSpan remaining = lockoutEnd.Value - DateTime.UtcNow;
                throw new Exception($"Account is locked. Try again in {remaining.Minutes} minute(s) and {remaining.Seconds} second(s).");
            }

            var authenticatedUser = _userRepo.Authenticate(username, password);
            if (authenticatedUser == null)
            {
                int failedAttempts = _userRepo.IncrementFailedLoginAttempt(username);

                if (failedAttempts >= MaxFailedAttempts)
                {
                    _userRepo.LockAccount(user.Id, LockoutMinutes);
                    throw new Exception($"Account locked due to {MaxFailedAttempts} failed login attempts. Try again in {LockoutMinutes} minutes.");
                }
                else
                {
                    throw new Exception($"Invalid username or password. Attempt {failedAttempts} of {MaxFailedAttempts}.");
                }
            }

            _userRepo.ResetFailedLoginAttemptsAndLockout(user.Id);

            _userRepo.UpdateLastLogin(authenticatedUser.Id);

            return authenticatedUser;
        }


        public User GetUserById(int id) => _userRepo.GetById(id);

        public IEnumerable<User> GetAllUsers() => _userRepo.GetAll();

        public void AddUser(User user, User newUser)
        {
            if (_userRepo.UsernameExists(newUser.Username))
                throw new Exception("Username already exists.");

            if (string.IsNullOrEmpty(newUser.PasswordHash))
                throw new Exception("Password is required.");

            if (!_userRepo.Add(user, newUser))
                throw new Exception("Failed to create user.");
        }

        public void UpdateUser(User user, User userToBeUpdated)
        {
            if (!_userRepo.Update(user, userToBeUpdated))
                throw new Exception("Failed to update user.");
        }

        public bool DeleteUser(User user, User userToBeDeleted)
        {
            if (!_userRepo.Delete(user, userToBeDeleted))
                throw new Exception("Failed to delete user.");

            return true;
        }

        public bool IsUserLockedOut(string username)
        {
            var user = _userRepo.GetByUsername(username);
            return user?.LockoutEnd.HasValue == true && user.LockoutEnd.Value > DateTime.UtcNow;
        }


        public bool IsUserLockedOut(string username, out TimeSpan remaining)
        {
            remaining = TimeSpan.Zero;
            var remainingLock = _userRepo.GetLockoutRemaining(username);
            if (remainingLock.HasValue)
            {
                remaining = remainingLock.Value;
                return true;
            }
            return false;
        }

    }
}
