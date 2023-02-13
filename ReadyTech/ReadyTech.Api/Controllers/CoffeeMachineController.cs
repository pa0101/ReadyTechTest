using Microsoft.AspNetCore.Mvc;
using ReadyTech.Api.Models;
using ReadyTech.Api.Utilities;

namespace ReadyTech.Api.Controllers
{
    [ApiController]
    [Route("CoffeeMachine")]
    public class CoffeeMachineController : ControllerBase
    {
        private readonly ILogger<CoffeeMachineController> _logger;
        private static int _coffeeBrewCounter = 0;

        public CoffeeMachineController(ILogger<CoffeeMachineController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        [Route("BrewCoffee")]
        public ActionResult<Coffee> BrewCoffee()
        {
            var utcNow = DateTime.UtcNow;
            ObjectResult result;

            var coffeMachine = new CoffeeMachine();

            if(coffeMachine.CheckIfMachineIsBrewingCoffee(utcNow))
            {
                _coffeeBrewCounter++;

                var coffee = coffeMachine.CheckIfMachineHasCoffee(_coffeeBrewCounter) ?
                coffeMachine.Coffee = new Coffee
                {
                    Message = "Your piping hot coffee is ready",
                    Prepared = DateTimeUtils.FormatDateTimeToISO8601(utcNow)
                } : null;

                result = coffee == null ? StatusCode(503, "503 Service Unavailable") : Ok(JSONUtils.SerializeObjectToJSON(coffee));
            }
            else
            {
                result = StatusCode(418, "418 I'm a teapot");
            }

            return result;
        }
    }
}
