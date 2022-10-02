# Contacts
<img witdh="40" height="40" src="https://github.com/devicons/devicon/blob/master/icons/csharp/csharp-original.svg" />&nbsp;
<img witdh="40" height="40" src="https://github.com/devicons/devicon/blob/master/icons/dotnetcore/dotnetcore-original.svg" />&nbsp;

Console app for contacts 

## Requirements
- MySQL
- .NET 6.0

## Installation
1. Download last release 
2. Extract the zip file
3. Copy the folder path of the "exe"
4. Add the path to the "Path" environment variable
5. Create a MySQL database and use 'Data/database.sql' to create a table
6. Add "contacts.dll.config" file inside the "exe" folder, inside the file insert:
```xml
<configuration>
   <appSettings>
       <add key="database" value="[db_name]" />
       <add key="password" value="[mysql_password]" />
       <add key="server" value="localhost" />
       <add key="user" value="root" />
   </appSettings>
</configuration>
```

## How to use it

```
contacts help 
```
<i>for more information</i>
