using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.SendMail
{
    public interface ISendMail
    {
        MailRequest Send(string mailTarget, string mailTopic, string mailContent);
    }
}
