using HelloApi.DTOs;
using HelloApi.Services;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

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

        // ❌ VULNERABILITY 1: Path Traversal (High)
        [HttpGet("file")]
        public IActionResult GetFile(string path)
        {
            // User input flows directly to file system access
            var content = System.IO.File.ReadAllText(path);
            return Ok(new { content });
        }

        // ❌ VULNERABILITY 2: Command Injection (Critical)
        [HttpGet("exec")]
        public IActionResult ExecuteCommand(string command)
        {
            // User input flows to command execution
            var processInfo = new ProcessStartInfo
            {
                FileName = "/bin/bash",
                Arguments = $"-c \"{command}\"",
                RedirectStandardOutput = true,
                UseShellExecute = false,
                CreateNoWindow = true
            };

            var process = Process.Start(processInfo);
            process?.WaitForExit();

            return Ok(new { executed = command });
        }

        // ❌ VULNERABILITY 3: Open Redirect (Medium)
        [HttpGet("redirect")]
        public IActionResult RedirectUser(string url)
        {
            // User input controls redirect destination
            return Redirect(url);
        }
    }
}
