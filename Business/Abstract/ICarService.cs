using Core.Utilities.Results;
using Entities.Concrete;
using Entities.DTOs;
using System.Collections.Generic;

namespace Business.Abstract
{
    public interface ICarService
    {
        IDataResult<List<Car>> GetAll();
        IDataResult<List<Car>> GetByBrandId(int brandId);
        IDataResult<List<Car>> GetByColorId(int colorId);
        IDataResult<List<CarDto>> GetByBrandAndColorId(int brandId, int colorId);
        IDataResult<Car> GetById(int carId);
        IResult Add(Car car);
        IResult Delete(Car car);
        IResult Update(Car car);
        IDataResult<List<CarDto>> GetCarDetails();
        IDataResult<List<CarDto>> GetCarDetailsByCarId(int carId);
        IDataResult<List<CarDto>> GetCarDetailsByBrandId(int brandId);
        IDataResult<List<CarDto>> GetCarDetailsByColorId(int colorId);
    }
}
