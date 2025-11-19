using Ecom.Core.DTO;
using Ecom.Core.Interfaces;

namespace Ecom.Infrastructure.Repositories.Services;

public class EmailService : IEmailService
{
    public Task SendEmail(EmailDto emailDto)
    {
        // var message = new MimeMessage();
        // message.From.Add(new MailboxAddress("My Ecom", _configuration["EmailSettings:"]));
        // message.Subject = emailDto.Subject;
        // message.To.Add(new MailboxAddress());
        throw new NotImplementedException();
    }
}