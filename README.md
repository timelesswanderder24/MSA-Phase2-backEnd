# MSA-Phase2-backEnd
The difference between the appsettings.json and appsettings.development.json is that one is written for 
development configuration while the other one is used for in memory. 
appsettings.json is used to set the default, non changing values while the appsettings.development.json overrides the keys in appsettings.json.

middleware via DI - Middleware like Swagger takes in the objects created by the developer and adds different
features(eg -adds UI). Middleware simplifies our code by creating libraries and it makes the code 
more readable.

NUnit test is done to check the accuracy of our code agianst range of different attributes. 

When Middleware libraries are used they provide different functions that can be used to validate our produced result against the expected result. Hence making our code easier to test.
