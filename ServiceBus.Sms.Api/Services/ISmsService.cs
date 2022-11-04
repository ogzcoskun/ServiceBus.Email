using ServiceBus.Sms.Api.Models;
using System.Threading.Tasks;

namespace ServiceBus.Sms.Api.Services
{
    public interface ISmsService
    {
        public Task<ServiceResponse> SendSms(SmsModel sms);
    }
}
