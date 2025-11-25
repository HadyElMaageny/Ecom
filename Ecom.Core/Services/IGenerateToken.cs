using Ecom.Core.Entities;

namespace Ecom.Core.Services;

public interface IGenerateToken
{
    Task<string> GetAndCreateToken(AppUser user);
}