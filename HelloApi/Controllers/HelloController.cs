using HelloApi.DTOs;
using HelloApi.Services;
using Microsoft.AspNetCore.Mvc;

namespace HelloApi.Controllers
{
    [ApiController]
    [Route("api/hello")]
    public class HelloController : ControllerBase
    {
        private readonly IMessageService _messageService;

        public HelloController(IMessageService messageService)
        {
            _messageService = messageService;
        }


        [HttpGet]
        public IActionResult GetMessage() => Ok(new HelloMessageResponse(_messageService.GetMessage()));
    }
}
