# SimpleAuth

A simple API for registering and authenticating users.

## Tools Used
For this project, I made use of C# (ASP.NET Core) and MS SQL on my local machine (Entity Framework Core is used as my Object Relational Mapper).

## Setting Up
After downloading the source file into your computer, set the database connection string as a secret in the SimpleAuth project.

![Setting up](https://github.com/Allison-E/SimpleAuth/blob/master/User%20secret.jpg)

```json
{
  "Db": {
    "ConnectionString": <your connection string here>
  }
}
```
