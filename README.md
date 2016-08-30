# EntityFramework6394

This is a Sample project created with ASP.NET Core 1.0.0 and EF Core 1.0.0
to show the issue with [the filtering problem] (https://github.com/aspnet/EntityFramework/issues/6394)

# Instructions to reproduce
* Clone this repository 
```
git clone https://github.com/iberodev/EntityFramework6394.git
```
* Create an empty database in MSSQLLocalDB called Db6394 

* Restore all the dependencies
```
cd EntityFramework6394
dotnet restore
``

* Create the MSSQLLocalDB database tables by running the following at the project level
```
dotnet ef database update
```
* Execute the script seedDatabase.sql to add test data

* Run the application.
* Trigger the sample by sending a GET request to:

```
GET localhost: http://localhost:57092/api/test should return a list but it crashes
```
