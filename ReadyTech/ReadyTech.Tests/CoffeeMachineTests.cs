using ReadyTech.Api.Models;
using System;
using Xunit;

namespace ReadyTech.Tests
{
    public class CoffeeMachineTests
    {
        [Theory]
        [InlineData(1)]
        [InlineData(2)]
        [InlineData(3)]
        [InlineData(4)]
        public void CheckIfMachineHasCoffee_DoesMachineHaveCoffee_ShouldReturnTrue(int value)
        {
            // Arrange
            var coffeeMachine = new CoffeeMachine();

            // Act
            var result = coffeeMachine.CheckIfMachineHasCoffee(value);

            // Assert
            Assert.True(result);            
        }

        [Fact]
        public void CheckIfMachineHasCoffee_DoesMachineNotHaveCoffee_ShouldReturnFalse()
        {
            // Arrange
            var coffeeMachine = new CoffeeMachine();
            var fifthApiCall = 5;

            // Act
            var result = coffeeMachine.CheckIfMachineHasCoffee(fifthApiCall);

            // Assert
            Assert.False(result);
        }

        [Fact]
        public void CheckIfMachineIsBrewingCoffee_CheckIfNotAprilFoolsDay_ShouldReturnTrue()
        {
            // Arrange
            var coffeeMachine = new CoffeeMachine();
            var date = new DateTime(2023, 2, 13);

            // Act
            var result = coffeeMachine.CheckIfMachineIsBrewingCoffee(date);

            // Assert
            Assert.True(result);
        }

        [Fact]
        public void CheckIfMachineIsBrewingCoffee_CheckIfAprilFoolsDay_ShouldReturnFalse()
        {
            // Arrange
            var coffeeMachine = new CoffeeMachine();
            var date = new DateTime(2023, 4, 1);

            // Act
            var result = coffeeMachine.CheckIfMachineIsBrewingCoffee(date);

            // Assert
            Assert.False(result);
        }
    }
}