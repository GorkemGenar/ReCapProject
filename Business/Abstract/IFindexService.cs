using Core.Utilities.Results;
using Entities.Concrete;
using System.Collections.Generic;

namespace Business.Abstract
{
    public interface IFindexService
    {
        IDataResult<List<Findex>> GetAll();
        IDataResult<Findex> GetById(int id);
        IResult Add(Findex findex);
        IResult Update(Findex findex);
        IResult Delete(Findex findex);
        IDataResult<List<Findex>> GetByUserId(int userId);
    }
}
