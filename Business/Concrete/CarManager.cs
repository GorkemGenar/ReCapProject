using Business.Abstract;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Validation;
using Core.Utilities.Results;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Business.Concrete
{
    public class CarManager : ICarService
    {
        ICarDal _carDal;

        public CarManager(ICarDal carDal)
        {
            _carDal = carDal;
        }
        [ValidationAspect(typeof(CarValidator))]
        public IResult Add(Car car)
        {
            _carDal.Add(car);
            return new SuccessResult(Messages.CarAdded);
        }

        public IResult Delete(Car car)
        {
            _carDal.Delete(car);
            return new SuccessResult(Messages.CarDeleted);
        }

        public IDataResult<List<Car>> GetAll()
        {
            if (DateTime.Now.Hour == 06)
            {
                return new ErrorDataResult<List<Car>>(Messages.MaintenanceTime);
            }
            return new SuccessDataResult<List<Car>>(_carDal.GetAll(), Messages.CarListed);
        }

        public IDataResult<Car> GetById(int carId)
        {
            return new SuccessDataResult<Car>(_carDal.Get(c => c.CarId == carId));
        }

        public IDataResult<List<CarDto>> GetCarDetails()
        {
            return new SuccessDataResult<List<CarDto>>(_carDal.GetCarDetails(), Messages.CarListed);
        }

        public IDataResult<List<Car>> GetByBrandId(int brandId)
        {
            return new SuccessDataResult<List<Car>>(_carDal.GetAll(c => c.BrandId == brandId), Messages.CarListed);
        }

        public IDataResult<List<Car>> GetByColorId(int colorId)
        {
            return new SuccessDataResult<List<Car>>(_carDal.GetAll(c => c.ColorId == colorId), Messages.CarListed);
        }
        [ValidationAspect(typeof(CarValidator))]
        public IResult Update(Car car)
        {
            _carDal.Update(car);
            return new SuccessResult(Messages.CarUpdated);
        }

        public IDataResult<List<CarDto>> GetCarDetailsByCarId(int carId)
        {
            return new SuccessDataResult<List<CarDto>>(_carDal.GetCarDetails(c => c.CarId == carId));
        }

        public IDataResult<List<CarDto>> GetCarDetailsByBrandId(int brandId)
        {
            return new SuccessDataResult<List<CarDto>>(_carDal.GetCarDetails(c => c.BrandId == brandId));
        }

        public IDataResult<List<CarDto>> GetCarDetailsByColorId(int colorId)
        {
            return new SuccessDataResult<List<CarDto>>(_carDal.GetCarDetails(c => c.ColorId == colorId));
        }

        public IDataResult<List<CarDto>> GetByBrandAndColorId(int brandId, int colorId)
        {
            return new SuccessDataResult<List<CarDto>>(_carDal.GetCarDetails(c => c.BrandId == brandId && c.ColorId == colorId));
        }
    }
}
