using Microsoft.AspNetCore.Mvc;
using ReadyTech.Api.Models;
using ReadyTech.Api.Utilities;

namespace ReadyTech.Api.Controllers
{
    [ApiController]
    [Route("CoffeeMachine")]
    public class CoffeeMachineController : ControllerBase
    {
        private readonly ICoffeeMachine _coffeeMachine;
        private static int _coffeeBrewCounter = 0;

        public CoffeeMachineController(ICoffeeMachine coffeeMachine)
        {
            _coffeeMachine = coffeeMachine;
        }

        [HttpGet]
        [Route("BrewCoffee")]
        public IActionResult BrewCoffee()
        {
            var utcNow = DateTime.UtcNow;

            if (_coffeeMachine.CheckIfMachineIsBrewingCoffee(utcNow))
            {
                _coffeeBrewCounter++;

                var coffee = _coffeeMachine.CheckIfMachineHasCoffee(_coffeeBrewCounter) ?
                _coffeeMachine.Coffee = new Coffee
                {
                    Message = "Your piping hot coffee is ready",
                    Prepared = DateTimeUtils.FormatDateTimeToISO8601(utcNow)
                } : null;

                return coffee == null ? StatusCode(503, "503 Service Unavailable") : Ok(JSONUtils.SerializeObjectToJSON(coffee));
            }
            else
            {
                return StatusCode(418, "418 I'm a teapot");
            }
        }
    }
}
