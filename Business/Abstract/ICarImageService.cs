using Core.Utilities.Results;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface ICarImageService
    {
        IResult Add(IFormFile file, CarImages carImages);
        IResult Delete(CarImages carImages);
        IResult Update(IFormFile file, CarImages carImages);
        IDataResult<CarImages> Get(int id);
        IDataResult<List<CarImages>> GetAll();
        IDataResult<List<CarImages>> GetImagesByCarId(int id);
    }
}
