### Example 1: Start a stopped PostgreSQL Flexible Server
```powershell
Start-AzPostgreSqlFlexibleServer -ResourceGroupName "myResourceGroup" -ServerName "myPostgreSqlServer"
```

Starts the specified PostgreSQL Flexible Server if it was previously stopped. The server will be available for connections once the operation completes.

### Example 2: Start a server and wait for completion
```powershell
Start-AzPostgreSqlFlexibleServer -ResourceGroupName "development-rg" -ServerName "dev-postgresql-01" -PassThru
```

Starts the PostgreSQL Flexible Server and returns the server object once the operation is completed successfully.

