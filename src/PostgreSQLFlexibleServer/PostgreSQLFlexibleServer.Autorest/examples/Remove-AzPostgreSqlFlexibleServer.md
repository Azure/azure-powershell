### Example 1: Remove a PostgreSQL Flexible Server
```powershell
Remove-AzPostgreSqlFlexibleServer -ResourceGroupName "myResourceGroup" -ServerName "myPostgreSqlServer"
```

Removes the specified PostgreSQL Flexible Server. This operation is irreversible and will delete all databases on the server.

### Example 2: Remove a PostgreSQL Flexible Server without confirmation prompt
```powershell
Remove-AzPostgreSqlFlexibleServer -ResourceGroupName "development-rg" -ServerName "dev-postgresql-temp" -Force
```

Removes the PostgreSQL Flexible Server without prompting for confirmation. Use with caution in production environments.

