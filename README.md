# ProductsAssignment API
This API is made for my Products assignment app. It will later on connect with [this repo](https://github.com/mekairaw/ProductsAssignmentFrontEnd).
## Stack
- .Net Core 3.0
- C#
## Prerequisites to run the project
- Visual Studio 2019 v16.3 or higher.
- .Net Core 3.0 SDK installed on your PC. 

## How to Run the project.
- Clone this repository to the desired location on your PC.
- cd into the cloned repository.
- Open the ProductsAssignmentAPI.sln file using Visual Studio 2019.
- Execute Build > Clean.
- Execute Build > Build Solution.
- Make sure to run the migrations via the Command Prompt using the command "dotnet ef database update".
- Finally proceed to run the solution.

## Unit and Integration Testing
There are two more projects on this Solution for Unit and Integration testing respectively. 
- To execute them, you must build the solution first.
- Then go to the project, for example "ProductsAssignmentAPI.UnitTesting" and right-click. 
- Then select run tests.
- The same goes for Integration Testing. Both tests should be successful.
