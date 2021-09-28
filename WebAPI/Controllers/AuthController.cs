using Business.Abstract;
using Core.Entities.Concrete;
using Entities.Concrete;
using Entities.DTOs;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : Controller
    {
        private IAuthService _authService;

        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }

        [HttpPost("login")]
        public ActionResult Login(UserForLoginDto userForLoginDto)
        {
            var userToLogin = _authService.Login(userForLoginDto);
            if (!userToLogin.Success)
            {
                return BadRequest(userToLogin.Message);
            }

            var result = _authService.CreateAccessToken(userToLogin.Data);
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result.Message);
        }

        [HttpPost("register")]
        public ActionResult Register(UserForRegisterDto userForRegisterDto)
        {
            var userExists = _authService.UserExistsByEmail(userForRegisterDto.Email);
            if (!userExists.Success)
            {
                return BadRequest(userExists.Message);
            }

            var registerResult = _authService.Register(userForRegisterDto, userForRegisterDto.Password);
            var result = _authService.CreateAccessToken(registerResult.Data);
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result.Message);
        }

        [HttpPost("registerbygoogle")]
        public ActionResult RegisterByGoogle(UserFromSocial userFromSocial)
        {
            var userExistsByEmail = _authService.UserExistsByEmail(userFromSocial.Email);

            var userExistsById = _authService.UserExistsById(userFromSocial.Id);

            if (!userExistsByEmail.Success)
            {
                return BadRequest(userExistsByEmail.Message);
            }
            
            if (!userExistsById.Success)
            {
                return BadRequest(userExistsById.Message);
            }

            var registerResult = _authService.RegisterByGoogle(userFromSocial);
            
            if (registerResult.Success)
            {
                return Ok(registerResult);
            }

            return BadRequest(registerResult.Message);
        }

        [HttpPost("update")]
        public ActionResult Update(UserForUpdateDto userForUpdateDto)
        {
            var updateResult = _authService.Update(userForUpdateDto, userForUpdateDto.Password);
            if (updateResult.Success)
            {
                return Ok(updateResult);
            }

            return BadRequest(updateResult.Message);
        }
    }
}
