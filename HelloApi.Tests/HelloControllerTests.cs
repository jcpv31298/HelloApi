using FluentAssertions;
using HelloApi.Controllers;
using HelloApi.DTOs;
using HelloApi.Services;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HelloApi.Tests
{
    public class HelloControllerTests
    {
        [Fact]
        public void GetMessage_Returns200OkWithServiceMessage()
        {
            //Arrange
            var serviceMock = new Mock<IMessageService>(MockBehavior.Strict);
            serviceMock.Setup(s => s.GetMessage()).Returns("test message");

            var controller = new HelloController(serviceMock.Object);

            //Act
            var result = controller.GetMessage();

            //Assert
            var ok = result.Should().BeOfType<OkObjectResult>().Subject;
            ok.Value.Should().BeOfType<HelloMessageResponse>().Which.Message.Should().Be("test message");

            serviceMock.VerifyAll();
        }
    }
}
