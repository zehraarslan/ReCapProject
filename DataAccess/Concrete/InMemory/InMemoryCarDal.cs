﻿using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.InMemory
{
    public class InMemoryCarDal : ICarDal
    {
        List<Car> _cars;

        public InMemoryCarDal()
        {
            _cars = new List<Car>()
            {
                new Car() {Id=1, BrandId=1, ColorId=1, DailyPrice = 2070108 , ModelYear= new DateTime(2021, 1, 1), Description = "2021 Audi A4 Sedan" },
                new Car() {Id=2, BrandId=1, ColorId=2, DailyPrice = 2272389 , ModelYear= new DateTime(2022, 1, 1), Description = "2022 Audi A5 Coupe" },
                new Car() {Id=3, BrandId=2, ColorId=2, DailyPrice = 2883700 , ModelYear= new DateTime(2020, 1, 1), Description = "BMW 3 serisi Station wagon" },
                new Car() {Id=4, BrandId=3, ColorId=3, DailyPrice = 12068195, ModelYear= new DateTime(2022, 1, 1), Description = "Land Rover Range Rover" },
                new Car() {Id=5, BrandId=4, ColorId=3, DailyPrice = 2112047 , ModelYear= new DateTime(2018, 1, 1), Description = "Volvo C40 - Motor : Elektrik" },
                new Car() {Id=6, BrandId=5, ColorId=1, DailyPrice = 1129969, ModelYear= new DateTime(2015, 1, 1), Description = "Subaru XV" }
            };
        }
        public void Add(Car car)
        {
            _cars.Add(car);
        }

        public void Delete(Car car)
        {
            Car carToDelete;
            carToDelete = _cars.SingleOrDefault(c => c.Id == car.Id);
            _cars.Remove(carToDelete);
        }

        public Car Get(Expression<Func<Car, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public List<Car> GetAll()
        {
            return _cars;
        }

        public List<Car> GetAll(Expression<Func<Car, bool>> filter = null)
        {
            throw new NotImplementedException();
        }

        public Car GetById(int id)
        {
            return _cars.SingleOrDefault(c => c.Id == id);
        }

        public List<CarDetailsDto> GetCarDetails()
        {
            throw new NotImplementedException();
        }

        public void Update(Car car)
        {
            Car carToUpdate;
            carToUpdate = _cars.SingleOrDefault(c => c.Id == car.Id);
            carToUpdate.BrandId = car.BrandId;
            carToUpdate.ColorId = car.ColorId;
            carToUpdate.DailyPrice = car.DailyPrice;
            carToUpdate.ModelYear = car.ModelYear;
            carToUpdate.Description = car.Description;
        }
    }

}
