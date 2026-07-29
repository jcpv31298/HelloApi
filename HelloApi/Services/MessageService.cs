namespace HelloApi.Services
{
    public class MessageService : IMessageService
    {
        private const string ApiKey = "sk-1234567890abcdef";  // ❌ Secret in code
        private const string Password = "SuperSecret123!";

        public string GetMessage() => "Hello World";

        public string GetApiPassword()
        {
            var apiUrl = $"https://api.example.com?key={ApiKey}";
            return "Hola desde .NET 8 API";
        }
    }
}
