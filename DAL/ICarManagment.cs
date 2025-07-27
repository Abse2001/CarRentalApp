using CarRentalApp.Models;
using System;
using System.Collections.Generic;

namespace CarRentalApp.DAL
{
    public interface ICarManagment
    {
        Car GetById(int id);
        Car GetByPlate(string plateNumber);
        IEnumerable<Car> GetAll();
        bool Add(Car car);
        bool Update(Car car);
        bool Delete(int carId);
        bool PlateNumberExists(string plateNumber);
        IEnumerable<Car> GetAvailableCars();
        bool UpdateCarStatus(int carId, string newStatus);
        bool RentNow(int carId, int customerId, DateTime dueDate);
        bool ReturnNow(int carId);
        IEnumerable<CarRental> GetRentalsByCarId(int carId);
        Customer GetCustomerById(int customerId);
    }
}
