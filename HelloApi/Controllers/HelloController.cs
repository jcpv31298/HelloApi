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

        [HttpGet("file")]
        public IActionResult GetFile(string path)
        {
            // ❌ VULNERABLE: User input directamente en file path
            var content = System.IO.File.ReadAllText(path);
            return Ok(new { content });
        }
    }
}
