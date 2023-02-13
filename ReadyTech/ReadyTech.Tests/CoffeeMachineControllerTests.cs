using AutoFixture;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Moq;
using ReadyTech.Api.Controllers;
using ReadyTech.Api.Models;
using ReadyTech.Api.Utilities;
using System;
using System.Net;
using Xunit;

namespace ReadyTech.Tests
{
    public class CoffeeMachineControllerTests
    {
        [Fact]
        public void BrewCoffee_IsMachineBrewingAndActuallyHasCoffee_ShouldReturnOkResponse()
        {
            // Arrange
            var mockMachine = new Mock<ICoffeeMachine>();

            mockMachine.Setup(x => x.CheckIfMachineIsBrewingCoffee(It.IsAny<DateTime>())).Returns(true);
            mockMachine.Setup(x => x.CheckIfMachineHasCoffee(1)).Returns(true);

            var controller = new CoffeeMachineController(mockMachine.Object);

            // Act
            var result = controller.BrewCoffee();

            // Assert
            var okObjectResult = result as OkObjectResult;

            Assert.NotNull(result);
            Assert.Equal((int)HttpStatusCode.OK, okObjectResult?.StatusCode);            
        }
    }
}