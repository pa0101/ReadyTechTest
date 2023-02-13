using Microsoft.AspNetCore.Mvc;
using Moq;
using ReadyTech.Api.Controllers;
using ReadyTech.Api.Models;
using ReadyTech.Api.Models.Interfaces;
using ReadyTech.Api.Services.Interfaces;
using System;
using System.Net;
using System.Threading.Tasks;
using Xunit;

namespace ReadyTech.Tests
{
    public class CoffeeMachineControllerTests
    {
        [Fact]
        public async Task BrewCoffee_IsMachineBrewingAndHasCoffee_ShouldReturnOkResponse()
        {
            // Arrange
            var machineMock = new Mock<ICoffeeMachine>();
            machineMock.Setup(x => x.CheckIfMachineIsBrewingCoffee(It.IsAny<DateTime>())).Returns(true);
            machineMock.Setup(x => x.CheckIfMachineHasCoffee(1)).Returns(true);

            var weatherServiceMock = new Mock<IWeatherService>();
            weatherServiceMock.Setup(x => x.GetTemperatureFromCoordinates(It.IsAny<string>(), It.IsAny<string>())).ReturnsAsync(new Weather());

            var controller = new CoffeeMachineController(machineMock.Object, weatherServiceMock.Object);

            // Act
            var result = await controller.BrewCoffee();

            // Assert
            var okObjectResult = result as OkObjectResult;

            Assert.NotNull(result);
            Assert.NotNull(okObjectResult?.Value);
            Assert.Equal((int)HttpStatusCode.OK, okObjectResult?.StatusCode);            
        }

        [Fact]
        public async Task BrewCoffee_IsMachineBrewingButHasNoCoffee_ShouldReturn503Response()
        {
            // Arrange
            var machineMock = new Mock<ICoffeeMachine>();

            machineMock.Setup(x => x.CheckIfMachineIsBrewingCoffee(It.IsAny<DateTime>())).Returns(true);
            machineMock.Setup(x => x.CheckIfMachineHasCoffee(5)).Returns(true);

            var weatherServiceMock = new Mock<IWeatherService>();
            weatherServiceMock.Setup(x => x.GetTemperatureFromCoordinates(It.IsAny<string>(), It.IsAny<string>())).ReturnsAsync(new Weather());

            var controller = new CoffeeMachineController(machineMock.Object, weatherServiceMock.Object);

            // Act
            var result = await controller.BrewCoffee();

            // Assert
            Assert.NotNull(result);
            var statusCodeResult = Assert.IsType<ObjectResult>(result);
            Assert.Equal((int)HttpStatusCode.ServiceUnavailable, statusCodeResult.StatusCode);
            Assert.Equal("503 Service Unavailable", statusCodeResult.Value);
        }

        [Fact]
        public async Task BrewCoffee_IsMachineNotBrewing_ShouldReturn418Response()
        {
            // Arrange
            var machineMock = new Mock<ICoffeeMachine>();

            machineMock.Setup(x => x.CheckIfMachineIsBrewingCoffee(It.IsAny<DateTime>())).Returns(false);
            machineMock.Setup(x => x.CheckIfMachineHasCoffee(5)).Returns(true);

            var weatherServiceMock = new Mock<IWeatherService>();
            weatherServiceMock.Setup(x => x.GetTemperatureFromCoordinates(It.IsAny<string>(), It.IsAny<string>())).ReturnsAsync(new Weather());

            var controller = new CoffeeMachineController(machineMock.Object, weatherServiceMock.Object);

            // Act
            var result = await controller.BrewCoffee();

            // Assert
            Assert.NotNull(result);
            var statusCodeResult = Assert.IsType<ObjectResult>(result);
            Assert.Equal(418, statusCodeResult.StatusCode);
            Assert.Equal("418 I'm a teapot", statusCodeResult.Value);
        }
    }
}