﻿using Core.Entities.Concrete;
using Core.Utilities.Results;
using Core.Utilities.Security.JWT;
using Entities.Concrete;
using Entities.DTOs;

namespace Business.Abstract
{
    public interface IAuthService
    {
        IDataResult<User> Register(UserForRegisterDto userForRegisterDto, string password);
        IDataResult<UserFromSocial> RegisterByGoogle(UserFromSocial userFromSocial);
        IDataResult<User> Update(UserForUpdateDto userForRegisterDto, string password);
        IDataResult<User> Login(UserForLoginDto userForLoginDto);
        IResult UserExistsByEmail(string email);
        IResult UserExistsById(string id);
        IDataResult<AccessToken> CreateAccessToken(User user);
    }
}
