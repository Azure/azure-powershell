### Example 1: Update MySql configuration by name
```powershell
PS C:\> Update-AzMySqlConfiguration -Name net_retry_count -ResourceGroupName PowershellMySqlTest -ServerName mysql-test -Value 15

Name            Type
----            ----
net_retry_count Microsoft.DBforMySQL/servers/configurations
```

This cmdlet updates MySql configuration by name.

### Example 2: Update MySql configuration by identity.
```powershell
PS C:\> $ID = "/subscriptions/<SubscriptionId>/resourceGroups/PowershellMySqlTest/providers/Microsoft.DBforMySQL/servers/mysql-test/configurations/wait_timeout"
PS C:\> Update-AzMySqlConfiguration -InputObject $ID -Value 150

Name         Type
----         ----
wait_timeout Microsoft.DBforMySQL/servers/configurations
```

These cmdlets update MySql configuration by identity.