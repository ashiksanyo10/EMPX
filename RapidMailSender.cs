using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net.Mail;
using System.IO;
using System.Net.Mime;
namespace EmployeeProductivityManagement
{
    class RapidMailSender
    {
        public static void Send(string Id,  string Body , string Subject,string filename)
        {
            SmtpClient smtp = new SmtpClient();
            smtp.Port = 587;
            smtp.Host = "smtp.gmail.com";
            smtp.Credentials = new System.Net.NetworkCredential("mailserviceforproject@gmail.com", "Unlock2018");
            smtp.EnableSsl = true;

            MailAddress _from = new MailAddress(Id);
            MailAddress _to = new MailAddress(Id);

            MailMessage mail = new MailMessage(_from, _to);
            mail.Subject = Subject;
            mail.Body = "<font size=15>" + Body + "</font> ";

            FileStream fs1 = new FileStream(filename, FileMode.Open, FileAccess.Read);
            Attachment a1 = new Attachment(fs1, filename, MediaTypeNames.Application.Octet);
            mail.Attachments.Add(a1);

            mail.IsBodyHtml = true;
            try
            {   
                smtp.Send(mail);
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}
