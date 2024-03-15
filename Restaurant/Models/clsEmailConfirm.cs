using Microsoft.AspNetCore.Identity.UI.Services;
using System.Net;
using System.Net.Mail;
using System.Security.Policy;

namespace Restaurant.Models
{
    public class clsEmailConfirm : IEmailSender
    {
        public async Task SendEmailAsync(string email, string subject, string htmlMessage)
        {

            var fMail = "YourEmail";
            var fPassword = "Password";


            var theMsg = new MailMessage();
            theMsg.From = new MailAddress(fMail);
            theMsg.Subject = subject;
            theMsg.To.Add(email);
            theMsg.Body = $"<html><body>{htmlMessage}</body></html>";
            theMsg.IsBodyHtml = true;

            var smtpClient = new SmtpClient("smtp-mail.gmail.com")
            {
                EnableSsl = true,
                Credentials = new NetworkCredential(fMail, fPassword),
                Port = 465
            };
            smtpClient.Send(theMsg);
        }
    }
}
