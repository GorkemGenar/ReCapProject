using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataAccess.Concrete.InMemory
{
    public class InMemoryCarDal : ICarDal
    {
        List<Car> _cars;

        public InMemoryCarDal()
        {
            _cars = new List<Car>()
            {
                new Car{CarId=1, BrandId=1, ColorId=1234, DailyPrice=15000, Description="Description_1", ModelYear= 1965},
                new Car{CarId=2, BrandId=2, ColorId=1234, DailyPrice=11200, Description="Description_2", ModelYear= 2000},
                new Car{CarId=3, BrandId=2, ColorId=1234, DailyPrice=44000, Description="Description_3", ModelYear= 2020},
                new Car{CarId=4, BrandId=3, ColorId=1234, DailyPrice=42000, Description="Description_4", ModelYear= 1999},
                new Car{CarId=5, BrandId=1, ColorId=1234, DailyPrice=22000, Description="Description_5", ModelYear= 2005}
            };
        }

        public void Add(Car car)
        {
            _cars.Add(car);
        }

        public void Delete(Car car)
        {
            var carToDelete = _cars.Where(i => i.CarId == car.CarId).SingleOrDefault();
        }

        public List<Car> GetAll()
        {
            return _cars;
        }

        public void GetById(int carid)
        {
            _cars.Where(i => i.CarId == carid).FirstOrDefault();
        }

        public void Update(Car car)
        {
            var carToUpdate = _cars.Where(i => i.CarId == car.CarId).FirstOrDefault();

            carToUpdate.BrandId = car.BrandId;
            carToUpdate.ColorId = car.ColorId;
            carToUpdate.DailyPrice = car.DailyPrice;
            carToUpdate.Description = car.Description;
            carToUpdate.ModelYear = car.ModelYear;
        }
    }
}
