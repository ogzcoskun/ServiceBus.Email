using ServiceBus.Email.Api.Models;
using System;
using System.Threading.Tasks;
using MailKit.Net.Smtp;
using MimeKit;
using MimeKit.Text;
using MailKit.Security;
using Microsoft.Extensions.Configuration;

namespace ServiceBus.Email.Api.Services
{
    public class EmailService : IEmailService
    {
        private readonly EmailConfiguration _emailConfig;
        private readonly IConfiguration _config;

        public EmailService(IConfiguration config)
        {
            _config = config;
        }

        public async Task<ServiceResponse> SendEmail(EmailModel email)
        {
            try
            {

                var emailToSend = new MimeMessage();
                emailToSend.From.Add(MailboxAddress.Parse(_config["EmailConfiguration:From"]));
                emailToSend.To.Add(MailboxAddress.Parse(email.Email));
                emailToSend.Subject = "Order Email Subject";
                emailToSend.Body = new TextPart(TextFormat.Plain) { Text = $"Your order with id: {email.OrderId} is created.." };

                using var smtp = new SmtpClient();
                smtp.Connect("smtp.gmail.com", 465, true);
                smtp.Authenticate("oguz.dev.test@gmail.com", "jvljilnoknqyvuyt");
                smtp.Send(emailToSend);
                smtp.Disconnect(true);

                return new ServiceResponse()
                {
                    Success = true,
                    Message = $"Email sent to {email.Email}.."
                };

            }catch(Exception ex)
            {
                return new ServiceResponse()
                {
                    Success = false,
                    Message = ex.Message
                };
            }
        }
    }
}
