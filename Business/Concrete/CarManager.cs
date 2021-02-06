﻿using Business.Abstract;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class CarManager : ICarService
    {
        ICarDal _carDal;

        public CarManager(ICarDal carDal)
        {
            _carDal = carDal;
        }

        public void Add(Car car)
        {
            if (car.CarName.Length > 2 && car.DailyPrice > 0)
            {
                _carDal.Add(car);
                Console.WriteLine(car.CarName + " eklendi.");
            }
            else
            {
                Console.WriteLine("Araba ismi minimum 2 karakter ve günlük fiyatı 0'dan büyük olmalıdır");
            }            
        }

        public void Delete(Car car)
        {
            _carDal.Delete(car);
        }

        public List<Car> GetAll()
        {
            return _carDal.GetAll();
        }

        public void Update(Car car)
        {
            _carDal.Update(car);
        }

        public Car GetById(int id)
        {
            throw new NotImplementedException();
        }

        public List<Car> GetAllByColorId(int id)
        {
            throw new NotImplementedException();
        }

        public List<Car> GetAllByBrandId(int id)
        {
            throw new NotImplementedException();
        }
    }
}
