using Ecom.Core.DTO;

namespace Ecom.Core.Interfaces;

public interface IEmailService
{
    Task SendEmail(EmailDto emailDto);
}