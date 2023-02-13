using Microsoft.AspNetCore.Mvc;
using ReadyTech.Api.Models;
using ReadyTech.Api.Models.Interfaces;
using ReadyTech.Api.Services.Interfaces;
using ReadyTech.Api.Utilities;

namespace ReadyTech.Api.Controllers
{
    [ApiController]
    [Route("CoffeeMachine")]
    public class CoffeeMachineController : ControllerBase
    {
        private readonly ICoffeeMachine _coffeeMachine;
        private readonly IWeatherService _weatherService;
        private static int _coffeeBrewCounter = 0;

        public CoffeeMachineController(ICoffeeMachine coffeeMachine, IWeatherService weatherService)
        {
            _coffeeMachine = coffeeMachine;
            _weatherService = weatherService;
        }

        [HttpGet]
        [Route("BrewCoffee")]
        public async Task<IActionResult> BrewCoffee()
        {
            var utcNow = DateTime.UtcNow;

            if (_coffeeMachine.CheckIfMachineIsBrewingCoffee(utcNow))
            {
                _coffeeBrewCounter++;

                if (_coffeeMachine.CheckIfMachineHasCoffee(_coffeeBrewCounter))
                {
                    var weather = await _weatherService.GetTemperatureFromCoordinates("-37.78", "175.27"); // <-- Coordinates of Hamilton, New Zealand
                    _coffeeMachine.Coffee = new Coffee
                    {
                        Message = weather.TemperatureCelcius > 30.0 ? "Your refreshing iced coffee is ready" : "Your piping hot coffee is ready",
                        Prepared = DateTimeUtils.FormatDateTimeToISO8601(utcNow)
                    };

                    return Ok(JSONUtils.SerializeObjectToJSON(_coffeeMachine.Coffee));
                }
                else
                {
                    return StatusCode(503, "503 Service Unavailable");
                }
            }
            else
            {
                return StatusCode(418, "418 I'm a teapot");
            }
        }
    }
}
