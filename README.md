# ReadyTechTest
API that controls an imaginary internet-connected coffee machine

# How to use this API
Make a GET request with Postman like this https://localhost:<PORT_NUMBER>/CoffeeMachine/BrewCoffee or you can use the Swagger browser UI to make the request.
You will notice that I used a static variable called "_coffeeBrewCounter". Obviously we would never do something like this in the real world, it is merely used to mimick the returned 503 status behaviour.
For requirement 1 in the Extra Credit task, I have assumed that in a real production app you would use some kind of location service api to get the coordinates/city of where the coffee machine exists for the weather api.
I have used hard coded coordinates of your city of Hamilton, NZ to get the current temperature as you'll see in the CoffeeMachineController.
I haven't commented the code as it should all be self explanitory for an experienced c# developer.

# Test Coverage
I wrote tests for as many scenarios that I could and I probably could have written a couple more but it is getting late. There is enough coverage there for the api and the coffee machine for now. 

Have fun reviewing the code!
