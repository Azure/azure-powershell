### Example 1: List all server configurations
```powershell
Get-AzPostgreSqlFlexibleServerConfiguration -ResourceGroupName "myResourceGroup" -ServerName "myPostgreSqlServer"
```

```output
Name                    Value    DefaultValue Source
----                    -----    ------------ ------
max_connections         100      100          system-default
shared_preload_libraries         None         system-default
log_statement           none     none         system-default
work_mem                4096     4096         system-default
```

Lists all PostgreSQL server configuration parameters and their current values.

### Example 2: Get a specific server configuration parameter
```powershell
Get-AzPostgreSqlFlexibleServerConfiguration -ResourceGroupName "myResourceGroup" -ServerName "myPostgreSqlServer" -ConfigurationName "max_connections"
```

```output
Name           : max_connections
Value          : 100
DefaultValue   : 100
DataType       : Integer
AllowedValues  : 5-5000
Source         : system-default
Description    : Sets the maximum number of concurrent connections.
```

Retrieves detailed information about a specific PostgreSQL server configuration parameter.

