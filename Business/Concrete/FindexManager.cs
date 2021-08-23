using Business.Abstract;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Validation;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using System.Collections.Generic;

namespace Business.Concrete
{
    public class FindexManager : IFindexService
    {
        IFindexDal _findexDal;

        public FindexManager(IFindexDal findexDal)
        {
            _findexDal = findexDal;
        }

        [ValidationAspect(typeof(FindexValidator))]
        public IResult Add(Findex findex)
        {
            _findexDal.Add(findex);
            return new SuccessResult(Messages.FindexRateAdded);
        }

        public IResult Delete(Findex findex)
        {
            _findexDal.Delete(findex);
            return new SuccessResult();
        }

        public IDataResult<List<Findex>> GetAll()
        {
            return new SuccessDataResult<List<Findex>>(_findexDal.GetAll());
        }

        public IDataResult<Findex> GetById(int id)
        {
            return new SuccessDataResult<Findex>(_findexDal.Get(f => f.FindexId == id));
        }

        public IDataResult<List<Findex>> GetByUserId(int userId)
        {
            return new SuccessDataResult<List<Findex>>(_findexDal.GetAll(f => f.UserId == userId));
        }

        public IResult Update(Findex findex)
        {
            _findexDal.Update(findex);
            return new SuccessResult(Messages.FindexRateUpdated);
        }
    }
}
