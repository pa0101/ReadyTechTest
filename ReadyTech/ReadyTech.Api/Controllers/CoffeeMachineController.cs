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
        private static int CoffeeBrewCounter = 0;

        public CoffeeMachineController(ILogger<CoffeeMachineController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        [Route("BrewCoffee")]
        public ActionResult<Coffee> BrewCoffee()
        {
            CoffeeBrewCounter++;

            var coffee = new Coffee 
            { 
                Message = "Your piping hot coffee is ready", 
                Prepared = DateTimeUtils.FormatDateTimeToISO8601(DateTime.UtcNow) 
            };

            return coffee == null ? NotFound() : Ok(JSONUtils.SerializeObjectToJSON(coffee));
        }
    }
}