using Core.Utilities.Results;
using Entities.Concrete;
using Entities.DTOs;
using System.Collections.Generic;

namespace Business.Abstract
{
    public interface ICarService
    {
        IDataResult<List<Car>> GetAll();
        IDataResult<CarDto> GetById(int id);
        IResult Add(Car car);
        IResult Update(Car car);
        IResult Delete(Car car);
        IDataResult<List<CarDto>> GetAllByColorId(int id);
        IDataResult<List<CarDto>> GetAllByBrandId(int id);
        IDataResult<List<CarDto>> GetCarDetails();
    }
}
