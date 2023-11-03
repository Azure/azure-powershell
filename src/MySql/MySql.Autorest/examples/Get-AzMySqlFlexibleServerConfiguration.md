### Example 1: List all configurations in specified MySql server
```powershell
Get-AzMySqlFlexibleServerConfiguration -ResourceGroupName PowershellMySqlTest -ServerName mysql-test
```

```output
Name                                     Value
----                                     -----
archive                                  OFF
audit_log_enabled                        OFF
audit_log_events                         CONNECTION
audit_log_exclude_users                  azure_superuser
...
wait_timeout                             28800
```

This cmdlet lists all configurations in specified MySql server.

### Example 2: Get specified MySql configuration by name
```powershell
Get-AzMySqlFlexibleServerConfiguration -Name wait_timeout -ResourceGroupName PowershellMySqlTest -ServerName mysql-test
```

```output
Name         Value AllowedValue Source         DefaultValue
----         ----- ------------ ------         ------------
wait_timeout 28800 1-31536000   system-default 28800
```

This cmdlet gets specified MySql configuration by name.

### Example 3: List configuration by identity
```powershell
$ID = "/subscriptions/<SubscriptionId>/resourceGroups/PowershellMySqlTest/providers/Microsoft.DBforMySQL/flexibleServers/mysql-test/configurations/wait_timeout"
Get-AzMySqlFlexibleServerConfiguration -Name wait_timeout -ResourceGroupName PowershellMySqlTest -ServerName mysql-test
```

```output
Name         Value AllowedValue Source         DefaultValue
----         ----- ------------ ------         ------------
wait_timeout 28800 1-31536000   system-default 28800
```

This cmdlet gets specified MySql configuration by identity.
