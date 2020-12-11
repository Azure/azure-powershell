### Example 1: Get connection string by name
```powershell
PS C:\> Get-AzPostgreSqlFlexibleServerConnectionString -Client ADO.NET -ResourceGroupName PowershellPostgreSqlTest -Name postgresql-test

Server=postgresql-test.postgres.database.azure.com;Database={your_database};Port=5432;User Id=adminuser;Password={your_password};
```

This cmdlet shows connection string of a client by server name. 
