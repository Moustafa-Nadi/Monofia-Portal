using MailKit.Net.Smtp;
using Menofia_Portal.Core.Interfaces;
using MimeKit;

namespace MonofiaPortal.Infrastructure.Services
{
    public class EmailService : IEmailService
    {
        private const string Gmail = "sendere37@gmail.com"; // fake email to send emails to (admin  الجامعه يعني)
        private const string AppPassword = "ljfx antm xdes llxl"; // will moving to json later

        public async Task SendEmailAsync(string toEmail, string subject, string body)
        {
            var email = new MimeMessage();
            email.From.Add(MailboxAddress.Parse(Gmail));
            email.To.Add(MailboxAddress.Parse(toEmail));
            email.Subject = subject;
            email.Body = new TextPart("plain") { Text = body };

            using var smtp = new SmtpClient();
            await smtp.ConnectAsync("smtp.gmail.com", 587, MailKit.Security.SecureSocketOptions.StartTls);
            await smtp.AuthenticateAsync(Gmail, AppPassword);
            await smtp.SendAsync(email);
            await smtp.DisconnectAsync(true);
        }
    }
}
