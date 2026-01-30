### Example 1: Update a server configuration parameter
```powershell
Update-AzPostgreSqlFlexibleServerConfiguration -ResourceGroupName "myResourceGroup" -ServerName "myPostgreSqlServer" -ConfigurationName "max_connections" -Value "200"
```

```output
Name           : max_connections
Value          : 200
DefaultValue   : 100
DataType       : Integer
AllowedValues  : 5-5000
Source         : user-override
Description    : Sets the maximum number of concurrent connections.
```

Updates the max_connections parameter to allow 200 concurrent connections.

### Example 2: Update a configuration parameter that requires server restart
```powershell
Update-AzPostgreSqlFlexibleServerConfiguration -ResourceGroupName "production-rg" -ServerName "prod-postgresql-01" -ConfigurationName "shared_preload_libraries" -Value "pg_stat_statements"
```

```output
Name           : shared_preload_libraries
Value          : pg_stat_statements
DefaultValue   : 
DataType       : String
Source         : user-override
Description    : Lists shared libraries to be preloaded at server startup.
```

Updates the shared_preload_libraries parameter to enable pg_stat_statements extension. This change requires a server restart to take effect.

