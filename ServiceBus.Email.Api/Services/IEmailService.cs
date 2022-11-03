using ServiceBus.Email.Api.Models;
using System.Threading.Tasks;

namespace ServiceBus.Email.Api.Services
{
    public interface IEmailService
    {
        Task<ServiceResponse> SendEmail(EmailModel email);
    }
}
