using Core.Entities.Concrete;
using Core.Utilities.Results;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface IUserFromSocialService
    {
        IDataResult<List<UserFromSocial>> GetAll();
        IDataResult<UserFromSocial> GetById(string id);
        IResult Add(UserFromSocial user);
        IResult Update(UserFromSocial user);
        IResult Delete(UserFromSocial user);
        IDataResult<List<OperationClaim>> GetClaims(UserFromSocial user);
        IDataResult<UserFromSocial> GetByMail(string email);
    }
}
