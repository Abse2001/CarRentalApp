using CarRentalApp.Models;
using System;
using System.Collections.Generic;

namespace CarRentalApp.DAL
{
    public interface IUserManagment
    {
        User Authenticate(string username, string password);
        User GetById(int id);
        User GetByUsername(string username);  
        IEnumerable<User> GetAll();
        bool Add(User user, User userToBeAdded);
        bool Update(User user, User userToBeUpdated);
        bool Delete(User user, User userToBeDeleted);
        bool UsernameExists(string username);
        void UpdateLastLogin(int userId);
        bool UpdateBalance(int userId, decimal amount);
        bool IncrementBookingCount(int userId);
        bool IsUserLockedOut(string username);

        void LockAccount(int userId, int lockMinutes = 4);
        void ResetFailedLoginAttemptsAndLockout(int userId);
        int IncrementFailedLoginAttempt(string username);
        TimeSpan? GetLockoutRemaining(string username);

    }

}
