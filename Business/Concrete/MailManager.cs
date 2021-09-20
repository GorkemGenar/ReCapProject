using Business.Abstract;
using Core.Utilities.Results;
using Core.Utilities.SendMail;
using Entities.DTOs;

namespace Business.Concrete
{
    public class MailManager : IMailService
    {
        private ISendMail _sendMail;
        public MailManager(ISendMail sendMail)
        {
            _sendMail = sendMail;
        }

        public IDataResult<MailRequest> SendMail(MailRequest mailRequest)
        {
            var result = _sendMail.Send(mailRequest.ToEmail, mailRequest.Subject, mailRequest.Body);
            return new SuccessDataResult<MailRequest>(result, "Mail gönderildi.");
        }

        public IDataResult<MailRequest> SendMailForResetPassword(ResetPasswordDto resetPassword)
        {
            string urlForResetPassword = "https://www.urlforreset.com";
            string subjectForResetPassword = "Reset Your Password";

            var result = _sendMail.Send(resetPassword.ToEmail, subjectForResetPassword, urlForResetPassword);
            return new SuccessDataResult<MailRequest>(result, "Sıfırlama maili gönderildi.");
        }

        //public async Task SendEmailAsync(MailRequest mailRequest)
        //{
        //    var email = new MimeMessage();
        //    email.Sender = MailboxAddress.Parse(_mailSettings.Mail);
        //    email.To.Add(MailboxAddress.Parse(mailRequest.ToEmail));
        //    email.Subject = mailRequest.Subject;
        //    var builder = new BodyBuilder();
        //    if (mailRequest.Attachments != null)
        //    {
        //        byte[] fileBytes;
        //        foreach (var file in mailRequest.Attachments)
        //        {
        //            if (file.Length > 0)
        //            {
        //                using (var ms = new MemoryStream())
        //                {
        //                    file.CopyTo(ms);
        //                    fileBytes = ms.ToArray();
        //                }
        //                builder.Attachments.Add(file.FileName, fileBytes, ContentType.Parse(file.ContentType));
        //            }
        //        }
        //    }
        //    builder.HtmlBody = mailRequest.Body;
        //    email.Body = builder.ToMessageBody();
        //    using var smtp = new SmtpClient();
        //    smtp.Connect(_mailSettings.Host, _mailSettings.Port, SecureSocketOptions.StartTls);
        //    smtp.Authenticate(_mailSettings.Mail, _mailSettings.Password);
        //    await smtp.SendAsync(email);
        //    smtp.Disconnect(true);
        //}

        //public async Task SendMailForResetPassword(ResetPasswordDto resetPasswordDto)
        //{
        //    string urlForResetPassword = "https://www.urlforreset.com";
        //    string subjectForResetPassword = "Reset Your Password";

        //    MailRequest mailRequest = new MailRequest();

        //    mailRequest.Subject = subjectForResetPassword;
        //    mailRequest.Body = urlForResetPassword;
        //    mailRequest.ToEmail = resetPasswordDto.ToEmail;

        //    var email = new MimeMessage();
        //    email.Sender = MailboxAddress.Parse(_mailSettings.Mail);
        //    email.To.Add(MailboxAddress.Parse(mailRequest.ToEmail));
        //    email.Subject = mailRequest.Subject;
        //    var builder = new BodyBuilder();
        //    if (mailRequest.Attachments != null)
        //    {
        //        byte[] fileBytes;
        //        foreach (var file in mailRequest.Attachments)
        //        {
        //            if (file.Length > 0)
        //            {
        //                using (var ms = new MemoryStream())
        //                {
        //                    file.CopyTo(ms);
        //                    fileBytes = ms.ToArray();
        //                }
        //                builder.Attachments.Add(file.FileName, fileBytes, ContentType.Parse(file.ContentType));
        //            }
        //        }
        //    }
        //    builder.HtmlBody = mailRequest.Body;
        //    email.Body = builder.ToMessageBody();
        //    using var smtp = new SmtpClient();
        //    smtp.Connect(_mailSettings.Host, _mailSettings.Port, SecureSocketOptions.StartTls);
        //    smtp.Authenticate(_mailSettings.Mail, _mailSettings.Password);
        //    await smtp.SendAsync(email);
        //    smtp.Disconnect(true);
        //}
    }
}
