using Business.Abstract;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
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

        public List<CarDto> GetCarDetails()
        {
            using (ReCapProjectContext context = new ReCapProjectContext())
            {
                var result = from c in context.Cars
                             join b in context.Brands on c.BrandId equals b.BrandId
                             join clr in context.Colors on c.ColorId equals clr.ColorId
                             select new CarDto
                             {
                                CarName = c.CarName,
                                BrandName = b.BrandName,
                                ColorName = clr.ColorName,
                                DailyPrice = c.DailyPrice
                             };
                             

                return result.ToList();
            }
        }
    }
}
