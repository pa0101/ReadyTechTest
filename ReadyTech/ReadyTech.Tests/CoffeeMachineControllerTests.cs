using Microsoft.AspNetCore.Mvc;
using Moq;
using ReadyTech.Api.Controllers;
using ReadyTech.Api.Models;
using System;
using System.Net;
using Xunit;

namespace ReadyTech.Tests
{
    public class CoffeeMachineControllerTests
    {
        [Fact]
        public void BrewCoffee_IsMachineBrewingAndHasCoffee_ShouldReturnOkResponse()
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
            Assert.NotNull(okObjectResult?.Value);
            Assert.Equal((int)HttpStatusCode.OK, okObjectResult?.StatusCode);            
        }

        [Fact]
        public void BrewCoffee_IsMachineBrewingButHasNoCoffee_ShouldReturn503Response()
        {
            // Arrange
            var mockMachine = new Mock<ICoffeeMachine>();

            mockMachine.Setup(x => x.CheckIfMachineIsBrewingCoffee(It.IsAny<DateTime>())).Returns(true);
            mockMachine.Setup(x => x.CheckIfMachineHasCoffee(5)).Returns(true);

            var controller = new CoffeeMachineController(mockMachine.Object);

            // Act
            var result = controller.BrewCoffee();

            // Assert
            Assert.NotNull(result);
            var statusCodeResult = Assert.IsType<ObjectResult>(result);
            Assert.Equal((int)HttpStatusCode.ServiceUnavailable, statusCodeResult.StatusCode);
            Assert.Equal("503 Service Unavailable", statusCodeResult.Value);
        }

        [Fact]
        public void BrewCoffee_IsMachineNotBrewing_ShouldReturn418Response()
        {
            // Arrange
            var mockMachine = new Mock<ICoffeeMachine>();

            mockMachine.Setup(x => x.CheckIfMachineIsBrewingCoffee(It.IsAny<DateTime>())).Returns(false);
            mockMachine.Setup(x => x.CheckIfMachineHasCoffee(5)).Returns(true);

            var controller = new CoffeeMachineController(mockMachine.Object);

            // Act
            var result = controller.BrewCoffee();

            // Assert
            Assert.NotNull(result);
            var statusCodeResult = Assert.IsType<ObjectResult>(result);
            Assert.Equal(418, statusCodeResult.StatusCode);
            Assert.Equal("418 I'm a teapot", statusCodeResult.Value);
        }
    }
}