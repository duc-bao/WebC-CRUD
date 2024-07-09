# Overview
- This is project learn C# CRUD With on a sample data model using Entity Framework Core, ASP.NET Core Web API, and SQL Server.
# Installation
### Prerequisites
- [.NET 8 SDK](https://dotnet.microsoft.com/download/dotnet/8.0)
- [SQL Server](https://www.microsoft.com/en-us/sql-server/sql-server-downloads)
# Features
- Create, Read, Update, Delete operations ASP.NET Core Web API Entity Framework, Core SQL Server, integration Minimal API with .NET 8.
# Step by Step Create Project
## Step1:
- Create Entity and Connect with DbMySql like the example image below:
- ![image](https://github.com/duc-bao/WebC-CRUD/assets/95183608/bd7f92e5-d8d3-4244-9073-7274740a1092)
![image](https://github.com/duc-bao/WebC-CRUD/assets/95183608/94872cae-ce17-4f72-96e8-d658bbc7b955)
## Step2:
- Create CRUD with entity and add-migration and update-database and have Entity Request and Entity Response
- ![image](https://github.com/duc-bao/WebC-CRUD/assets/95183608/79309807-cfdb-4aab-bdfe-ef0e931e7866)
- Use Asynchronous Programming  to optimize time keyword (async, await and Task<>)
## Step3:
-Create Repository for Controller connect Database. Config Dependency Injection in Program.cs
![image](https://github.com/duc-bao/WebC-CRUD/assets/95183608/5e47e465-54f2-49a3-a045-6b4400be0def)
## Step4:
-Config AutoMapper for Entity to DTO or Reverse use IMapper
![image](https://github.com/duc-bao/WebC-CRUD/assets/95183608/9a682373-6b09-439f-b2c1-6b2ff884bc32)
## Step5:
- Understand the 1-to-many relationship between tables and Config it
- Example below
-Entity
![image](https://github.com/duc-bao/WebC-CRUD/assets/95183608/9992070b-3465-4691-ad02-d6d5a2a716de)
-DTO
![image](https://github.com/duc-bao/WebC-CRUD/assets/95183608/79534e4d-02da-4019-a432-5d7f6776f69c)
## Step6:
- Custom Validation for Client request Server
![image](https://github.com/duc-bao/WebC-CRUD/assets/95183608/50669f21-d52b-4f9c-9f63-61d42c2432b7)
## Step7:




- 
