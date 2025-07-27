using CarRentalApp.DAL;
using CarRentalApp.Models;
using System;
using System.Collections.Generic;

namespace CarRentalApp.Services
{
    public class CarService
    {
        private readonly ICarManagment _carDal;

        public CarService(ICarManagment carDal)
        {
            _carDal = carDal ?? throw new ArgumentNullException(nameof(carDal));
        }

        public bool AddCar(Car car)
        {
            return _carDal.Add(car);
        }

        public bool UpdateCar(Car car)
        {
            if (car == null) throw new ArgumentNullException(nameof(car));
            return _carDal.Update(car);
        }

        public bool DeleteCar(int id)
        {
            return _carDal.Delete(id);
        }

        public IEnumerable<Car> GetAllCars()
        {
            return _carDal.GetAll();
        }

        public Car GetCarById(int id)
        {
            return _carDal.GetById(id);
        }
        public bool RentCar(int carId, int customerId, DateTime dueDate)
        {
            return _carDal.RentNow(carId, customerId, dueDate);
        }

        public bool ReturnCar(int carId)
        {
            return _carDal.ReturnNow(carId);
        }
        public Car GetCarByPlate(string plate)
        {
            // You must also implement GetByPlate in your DAL
            return (_carDal as CarManagment)?.GetByPlate(plate);
        }

        public IEnumerable<CarRental> GetRentalsByCarId(int carId)
        {
            return (_carDal as CarManagment)?.GetRentalsByCarId(carId) ?? new List<CarRental>();
        }

        public Customer GetCustomerById(int customerId)
        {
            return (_carDal as CarManagment)?.GetCustomerById(customerId);
        }

    }
}
