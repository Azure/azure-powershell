### Example 1: Update MySql configuration by name
```powershell
Update-AzMySqlConfiguration -Name net_retry_count -ResourceGroupName PowershellMySqlTest -ServerName mysql-test -Value 15
```

```output
Name            Value
----            -----
net_retry_count 15
```

This cmdlet updates MySql configuration by name.

### Example 2: Update MySql configuration by identity.
```powershell
$ID = "/subscriptions/<SubscriptionId>/resourceGroups/PowershellMySqlTest/providers/Microsoft.DBforMySQL/servers/mysql-test/configurations/wait_timeout"
Update-AzMySqlConfiguration -InputObject $ID -Value 150
```

```output
Name         Value
----         -----
wait_timeout 150
```

These cmdlets update MySql configuration by identity.