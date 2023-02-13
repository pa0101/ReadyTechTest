using ReadyTech.Api.Models.Interfaces;
using ReadyTech.Api.Utilities;

namespace ReadyTech.Api.Models
{
    public class CoffeeMachine : ICoffeeMachine
    {
        public Coffee? Coffee { get; set; }

        public bool CheckIfMachineHasCoffee(int numberOfCoffeesMade) =>
            numberOfCoffeesMade % 5 == 0 ? false : true;

        public bool CheckIfMachineIsBrewingCoffee(DateTime dateTime)
        {
            var firstDayOfApril = 1;
            var april = 4;

            var localDate = DateTimeUtils.GetLocalDateTimeFromUTC(dateTime);

            return (localDate.Day == firstDayOfApril && localDate.Month == april) ? false : true;
        }
    }
}
