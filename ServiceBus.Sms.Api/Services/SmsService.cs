using ServiceBus.Sms.Api.Models;
using System;
using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Types;

namespace ServiceBus.Sms.Api.Services
{
    public class SmsService : ISmsService
    {
        public async Task<ServiceResponse> SendSms(SmsModel sms)
        {
            try
            {

                TelegramBotClient Bot = new TelegramBotClient("5692117941:AAGFeNSjt30KyBX0OU8xNtU12-GA4GRGpk8");

                //phone 5298457122

                var a = await Bot.SendTextMessageAsync(sms.Phone, sms.Message);

                

                return new ServiceResponse()
                {
                    Success = true,
                    Message = "Sms Successfully Send.."
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
