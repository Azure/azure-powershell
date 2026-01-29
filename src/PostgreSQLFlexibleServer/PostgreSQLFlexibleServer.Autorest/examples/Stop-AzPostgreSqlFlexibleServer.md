### Example 1: Stop a running PostgreSQL Flexible Server
```powershell
Stop-AzPostgreSqlFlexibleServer -ResourceGroupName "myResourceGroup" -ServerName "myPostgreSqlServer"
```

Stops the specified PostgreSQL Flexible Server. All active connections will be terminated, and the server will no longer accept new connections.

### Example 2: Stop a server without confirmation prompt
```powershell
Stop-AzPostgreSqlFlexibleServer -ResourceGroupName "development-rg" -ServerName "dev-postgresql-01" -Force
```

Stops the PostgreSQL Flexible Server immediately without prompting for confirmation. Use with caution as this will terminate all active connections.

