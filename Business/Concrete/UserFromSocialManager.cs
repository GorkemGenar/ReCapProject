using Business.Abstract;
using Core.Entities.Concrete;
using Core.Utilities.Results;
using DataAccess.Abstract;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class UserFromSocialManager : IUserFromSocialService
    {
        IUserFromSocialDal _userFromSocialDal;

        public UserFromSocialManager(IUserFromSocialDal userFromSocialDal)
        {
            _userFromSocialDal = userFromSocialDal;
        }

        public IResult Add(UserFromSocial user)
        {
            _userFromSocialDal.Add(user);
            return new SuccessResult();
        }

        public IResult Delete(UserFromSocial user)
        {
            _userFromSocialDal.Delete(user);
            return new SuccessResult();
        }

        public IDataResult<List<UserFromSocial>> GetAll()
        {
            _userFromSocialDal.GetAll();
            return new SuccessDataResult<List<UserFromSocial>>();
        }

        public IDataResult<UserFromSocial> GetById(string id)
        {
            return new SuccessDataResult<UserFromSocial>(_userFromSocialDal.Get(u => u.Id == id));
        }

        public IDataResult<UserFromSocial> GetByMail(string email)
        {
            return new SuccessDataResult<UserFromSocial>(_userFromSocialDal.Get(u => u.Email == email));
        }

        public IDataResult<List<OperationClaim>> GetClaims(UserFromSocial user)
        {
            return new SuccessDataResult<List<OperationClaim>>(_userFromSocialDal.GetClaims(user));
        }

        public IResult Update(UserFromSocial user)
        {
            throw new NotImplementedException();
        }
    }
}
