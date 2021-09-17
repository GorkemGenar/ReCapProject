using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IMailService
    {
        Task SendEmailAsync(MailRequest mailRequest);
        Task SendMailForResetPassword(ResetPasswordDto resetPasswordDto);
    }
}
