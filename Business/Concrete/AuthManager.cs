using Business.Abstract;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Validation;
using Core.Entities.Concrete;
using Core.Utilities.Results;
using Core.Utilities.Security.Hashing;
using Core.Utilities.Security.JWT;
using Entities.DTOs;

namespace Business.Concrete
{
    public class AuthManager : IAuthService
    {
        private IUserService _userService;
        private IUserFromSocialService _userFromSocialService; 
        private ITokenHelper _tokenHelper;

        public AuthManager(IUserService userService, IUserFromSocialService userFromSocialService, ITokenHelper tokenHelper)
        {
            _userService = userService;
            _userFromSocialService = userFromSocialService;
            _tokenHelper = tokenHelper;
        }

        //[ValidationAspect(typeof(RegisterValidator))]
        public IDataResult<User> Register(UserForRegisterDto userForRegisterDto, string password)
        {
            byte[] passwordHash, passwordSalt;
            HashingHelper.CreatePasswordHash(password, out passwordHash, out passwordSalt);

            var user = new User
            {
                Email = userForRegisterDto.Email,
                FirstName = userForRegisterDto.FirstName,
                LastName = userForRegisterDto.LastName,
                PasswordHash = passwordHash,
                PasswordSalt = passwordSalt,
                Status = true
            };
            _userService.Add(user);
            return new SuccessDataResult<User>(user, "Kayıt oldu");
        }

        public IDataResult<UserFromSocial> RegisterByGoogle(UserFromSocial userFromSocial)
        {
            var user = new UserFromSocial
            {
                Id = userFromSocial.Id,
                Email = userFromSocial.Email,
                FirstName = userFromSocial.FirstName,
                LastName = userFromSocial.LastName
            };
            _userFromSocialService.Add(user);
            return new SuccessDataResult<UserFromSocial>(user, "Google hesabınız ile üyelik işleminiz gerçekleşti.");
        }

        public IDataResult<User> Update(UserForUpdateDto userForUpdateDto, string password)
        {
            byte[] passwordHash, passwordSalt;
            HashingHelper.CreatePasswordHash(password, out passwordHash, out passwordSalt);
            var user = new User
            {
                Id = userForUpdateDto.Id,
                Email = userForUpdateDto.Email,
                FirstName = userForUpdateDto.FirstName,
                LastName = userForUpdateDto.LastName,
                PasswordHash = passwordHash,
                PasswordSalt = passwordSalt,
                Status = true
            };
            _userService.Update(user);
            return new SuccessDataResult<User>(user, "Kullanıcı bilgileri güncellendi.");
        }

        public IDataResult<User> Login(UserForLoginDto userForLoginDto)
        {
            var userToCheck = _userService.GetByMail(userForLoginDto.Email).Data;
            if (userToCheck == null)
            {
                return new ErrorDataResult<User>("Kullanıcı bulunamadı");
            }

            if (!HashingHelper.VerifyPasswordHash(userForLoginDto.Password, userToCheck.PasswordHash, userToCheck.PasswordSalt))
            {
                return new ErrorDataResult<User>("Parola hatası");
            }

            return new SuccessDataResult<User>(userToCheck, "Başarılı giriş");
        }

        public IDataResult<AccessToken> CreateAccessToken(User user)
        {
            var claims = _userService.GetClaims(user);
            var accessToken = _tokenHelper.CreateToken(user, claims.Data);
            return new SuccessDataResult<AccessToken>(accessToken, "Token oluşturuldu");
        }

        public IResult UserExistsByEmail(string email)
        {
            if (_userService.GetByMail(email).Data != null)
            {
                return new ErrorResult("Bu mail adresine kayıtlı kullanıcı mevcut");
            }
            return new SuccessResult();
        }

        public IResult UserExistsById(string id)
        {
            if (_userFromSocialService.GetById(id).Data != null)
            {
                return new ErrorResult("Bu Id'de sistemde kullanıcı mevcut");
            }
            return new SuccessResult();
        }
    }
}
