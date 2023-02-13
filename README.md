# ReadyTechTest
API that controls an imaginary internet-connected coffee machine

# How to use this API
Make a GET request with Postman like this https://localhost:<PORT_NUMBER>/CoffeeMachine/BrewCoffee or you can use the Swagger browser UI to make the request.
You will notice that I used a static variable called "_coffeeBrewCounter". Obviously we would never do something like this in the real world, it is merely used to mimick the returned 503 status behaviour.
I haven't commented the code as it should all be self explanitory for an experienced c# developer.

# Test Coverage
I wrote tests for as many scenarios that I could and I probably could have written a couple more but it is getting late. There is enough coverage there for the api and the coffee machine for now. 

Have fun reviewing the code!
