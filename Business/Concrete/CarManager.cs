using Business.Abstract;
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
            _carDal.Add(car);
        }

        public void AnyTest(int year)
        {
            _carDal.AnyTest(year);
        }

        public void ClassicLinqTest()
        {
            throw new NotImplementedException();
        }

        public void Delete(Car car)
        {
            _carDal.Delete(car);
        }

        public void FindAllTest(string name)
        {
            _carDal.FindAllTest(name);
        }

        public void FindTest(int year)
        {
            _carDal.FindTest(year);
        }

        public List<Car> GetAll()
        {
            return _carDal.GetAll();
        }

        public void GetById(int carid)
        {
            _carDal.GetById(carid);
        }

        public void JoinTest()
        {
            _carDal.JoinTest();
        }

        public void Update(Car car)
        {
            _carDal.Update(car);
        }
    }
}
