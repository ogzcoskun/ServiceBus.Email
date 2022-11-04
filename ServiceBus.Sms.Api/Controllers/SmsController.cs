using Microsoft.AspNetCore.Mvc;
using ServiceBus.Sms.Api.Models;
using ServiceBus.Sms.Api.Services;
using System;
using System.Threading.Tasks;

namespace ServiceBus.Sms.Api.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class SmsController : ControllerBase
    {
        private readonly ISmsService _smsService;

        public SmsController(ISmsService smsService)
        {
            _smsService = smsService;
        }


        [HttpPost]
        public async Task<IActionResult> SendSms(SmsModel sms)
        {
            try
            {

                var response = await _smsService.SendSms(sms);

                return Ok(response);

            }catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
