using EmailLib.EmailConfig;
using EmailService;
using LoggerService;
using MailKit.Net.Smtp;
using MimeKit;
using System;
using System.Threading.Tasks;

namespace EmailLib
{
    public class EmailSender : ISendEmail
    {
        private readonly EmailConfiguration _emailConfig;
        private readonly ILoggerManager _logerManager;


        public EmailSender(EmailConfiguration emailConfig, ILoggerManager loggerManager)
        {
            _emailConfig = emailConfig;
            _logerManager = loggerManager;
        }

        public async Task SendEmailAsync(Message message)
        {
            MimeMessage emailMessage = CreateEmailMessage(message);
            await SendAsync(emailMessage);
        }


        private MimeMessage CreateEmailMessage(Message message)
        {
            MimeMessage emailMessage = EmailOptions(message);
            EmailBody(message, emailMessage);

            return emailMessage;
        }

        private MimeMessage EmailOptions(Message message)
        {
            var emailMessage = new MimeMessage();
            emailMessage.From.Add(new MailboxAddress(_emailConfig.From));
            emailMessage.To.AddRange(message.To);
            emailMessage.Subject = message.Subject;
            return emailMessage;
        }

        private static void EmailBody(Message message, MimeMessage emailMessage)
        {
            emailMessage.Body = new TextPart(MimeKit.Text.TextFormat.Html)
            {
                Text = string.Format("<h2 style='color:red'>{0}</h2>", message.Content)
            };

            //Todo use factory pattern for different email bodies
        }

        private async Task SendAsync(MimeMessage emailMessage)
        {
            using var client = new SmtpClient();
            try
            {
                await client.ConnectAsync(_emailConfig.SmtpServer, _emailConfig.Port, true);
                client.AuthenticationMechanisms.Remove("XOAUTH2");
                await client.AuthenticateAsync(_emailConfig.UserName, _emailConfig.Password);

                await client.SendAsync(emailMessage);
            }
            catch (Exception e)
            {
                _logerManager.LogError(e.Message);
            }
            finally
            {
                await client.DisconnectAsync(true);
                client.Dispose();
            }
        }
    }
}
