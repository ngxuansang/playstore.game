using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace PlayStore.Project.DataAccess.Email
{
    public class Email
    {
        public static string Address = "playstore.lanina@gmail.com";
        public static string Password = "Sang678!@#$";

        public static void Send(string toAddress, string subject, string body)
        {
            MailMessage mailObject = new MailMessage(Email.Address, toAddress);
            mailObject.IsBodyHtml = true;
            mailObject.Subject = subject;
            mailObject.Body = body;
            using (SmtpClient smtp = new SmtpClient())
            {
                var credential = new NetworkCredential
                {
                    UserName = Email.Address,  // replace with valid value
                    Password = Email.Password  // replace with valid value
                };
                smtp.Credentials = credential;
                smtp.Port = 587;
                smtp.Host = "smtp.gmail.com";
                smtp.EnableSsl = true;
                smtp.Send(mailObject);
            };
        }
    }
}