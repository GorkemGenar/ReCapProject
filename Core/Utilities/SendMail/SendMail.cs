using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.SendMail
{
    public class SendMail : ISendMail
    {

        public SendMail()
        {
        }

        public MailRequest Send(string mailTarget, string mailTopic, string mailContent)
        {
            var result = new MailRequest();
            result.ToEmail = mailTarget;
            result.Subject = mailTopic;
            result.Body = mailContent;

            try
            {
                System.Net.NetworkCredential cred = new System.Net.NetworkCredential("gorkemgenarakkaya@gmail.com", "Sanane12");
                // mail göndermek için oturum açtık

                System.Net.Mail.MailMessage mail = new System.Net.Mail.MailMessage(); // yeni mail oluşturduk
                mail.From = new System.Net.Mail.MailAddress("gorkemgenarakkaya@gmail.com", "Rent A Car"); // maili gönderecek hesabı belirttik
                mail.To.Add(mailTarget); // mail gönderilecek adresi belirledik
                mail.Subject = mailTopic; // mailin konusu
                mail.Body = mailContent; // mailin içeriği
                System.Net.Mail.SmtpClient smtp = new System.Net.Mail.SmtpClient("smtp.gmail.com", 587); // smtp servere bağlandık
                smtp.UseDefaultCredentials = false; // varsayılan girişi kullanmadık
                smtp.EnableSsl = true; // ssl kullanımına izin verdik
                smtp.Credentials = cred; // server üzerindeki oturumumuzu yukarıda belirttiğimiz NetworkCredential üzerinden sağladık.
                smtp.Send(mail); // mailimizi gönderdik.

                return result;
            }
            catch (Exception)
            {
                return result;
            }
        }
    }
}
