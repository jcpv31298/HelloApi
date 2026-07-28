using FluentAssertions;
using HelloApi.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HelloApi.Tests
{
    public class MessageServiceTests
    {
        [Fact]
        public void GetMessage_ReturnExpectedValue()
        {
            //Arrange
            var service = new MessageService();

            //Act
            var result = service.GetMessage();

            //Assert
            result.Should().Be("Hello World");
        }
    }
}
