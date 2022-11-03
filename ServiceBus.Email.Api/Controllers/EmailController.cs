using Microsoft.AspNetCore.Mvc;

using ServiceBus.Email.Api.Models;
using ServiceBus.Email.Api.Services;
using System;
using System.Threading.Tasks;

namespace ServiceBus.Email.Api.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class EmailController : Controller
    {
        private readonly IEmailService _mailService;

        public EmailController(IEmailService mailService)
        {
            _mailService = mailService;
        }

        [HttpPost]
        public async Task<IActionResult> SendEmail([FromBody]EmailModel email)
        {
            try
            {

                var response = await _mailService.SendEmail(email);

                return Ok(response);
            }catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

    }
}
