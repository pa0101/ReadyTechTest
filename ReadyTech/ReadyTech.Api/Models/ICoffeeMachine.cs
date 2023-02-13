namespace ReadyTech.Api.Models
{
    public interface ICoffeeMachine
    {
        Coffee? Coffee { get; set; }

        bool CheckIfMachineHasCoffee(int numberOfCoffeesMade);
        bool CheckIfMachineIsBrewingCoffee(DateTime dateTime);
    }
}