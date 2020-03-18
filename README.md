
# Simple API ASP.NET

The sample project for call api containing api controllers. To test the project you will issue GET and POST to the api.

## Requirements

.NET Core SDK v2.1.4 or newer A SQL Server database (Localdb or any modern version of SQL Server will work fine)

## How to use

Edit server connection in **appsettings.json**

```json
"ConnectionStrings": {
  "DefaultConnection": "Server=DESKTOP-G4NBSB1;Database=TODOLIST;ConnectRetryCount=0;Trusted_Connection=True;MultipleActiveResultSets=true"
}
```

Call api example

Init database

![example 1](https://raw.githubusercontent.com/thaycacac/todo-api/master/images/1.png)

Get list task

![example 2](https://raw.githubusercontent.com/thaycacac/todo-api/master/images/2.png)

Create new task

![example 3](https://raw.githubusercontent.com/thaycacac/todo-api/master/images/3.png)

Update task

![example 4](https://raw.githubusercontent.com/thaycacac/todo-api/master/images/4.png)

Delete task

![example 5](https://raw.githubusercontent.com/thaycacac/todo-api/master/images/5.png)