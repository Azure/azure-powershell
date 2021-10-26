### Example 1: Update MySql configuration by name
```powershell
PS C:\> Update-AzMySqlFlexibleServerConfiguration -Name net_retry_count -ResourceGroupName PowershellMySqlTest -ServerName mysql-test -Value 15

Name            Value AllowedValue  Source         DefaultValue
----            ----- ------------  ------         ------------
net_retry_count 15    1-4294967295  user-override  10
```

This cmdlet updates MySql configuration by name.

### Example 2: Update MySql configuration by identity.
```powershell
PS C:\> $ID = "/subscriptions/<SubscriptionId>/resourceGroups/PowershellMySqlTest/providers/Microsoft.DBForMySql/flexibleServers/mysql-test/configurations/wait_timeout"
PS C:\> Update-AzMySqlFlexibleServerConfiguration -InputObject $ID -Value 150

Name         Value AllowedValue Source         DefaultValue
----         ----- ------------ ------         ------------
wait_timeout 150   1-31536000   user-override  28800
```

These cmdlets update MySql configuration by identity.

