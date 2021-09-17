using Business.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MailController : ControllerBase
    {
        private readonly IMailService _mailService;

        public MailController(IMailService mailService)
        {
            _mailService = mailService;
        }

        [HttpPost("send")]
        public async Task<IActionResult> Send([FromForm] MailRequest request)
        {
            try
            {
                await _mailService.SendEmailAsync(request);
                return Ok();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpPost("resetthepassword")]
        public async Task<IActionResult> SendMailForResetPassword(ResetPasswordDto resetPasswordDto)
        {
            try
            {
                await _mailService.SendMailForResetPassword(resetPasswordDto);
                return Ok();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
