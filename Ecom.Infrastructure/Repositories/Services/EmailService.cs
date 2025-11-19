using Ecom.Core.DTO;
using Ecom.Core.Interfaces;
using Microsoft.Extensions.Configuration;
using MimeKit;

namespace Ecom.Infrastructure.Repositories.Services;

public class EmailService(IConfiguration configuration) : IEmailService
{
    public async Task SendEmail(EmailDto emailDto)
    {
        var message = new MimeMessage();
        message.From.Add(new MailboxAddress("My Ecom", configuration["EmailSettings:From"]));
        message.Subject = emailDto.Subject;
        message.To.Add(new MailboxAddress(emailDto.To, emailDto.To));
        message.Body = new TextPart(MimeKit.Text.TextFormat.Html)
        {
            Text = emailDto.Content
        };
        using (var smtp = new MailKit.Net.Smtp.SmtpClient())
        {
            try
            {
                await smtp.ConnectAsync(configuration["EmailSettings:SMTP"],
                    int.Parse(configuration["EmailSettings:Port"]!), true);
                await smtp.AuthenticateAsync(configuration["EmailSettings:Username"],
                    configuration["EmailSettings:Password"]);
                await smtp.SendAsync(message);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
            finally
            {
                await smtp.DisconnectAsync(true);
                smtp.Dispose();
            }
        }

        // throw new NotImplementedException();
    }
}