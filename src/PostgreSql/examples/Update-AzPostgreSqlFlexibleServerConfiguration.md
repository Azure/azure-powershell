### Example 1: Update PostgreSql configuration by name
```powershell
PS C:\> Update-AzPostgreSqlFlexibleServer -Name work_mem -ResourceGroupName PowershellPostgreSqlTest -ServerName postgresql-test -Value 15

Name          Value   DefaultValue  Source        AllowedValues DataType
----          ------  ------------  -------       ------------- ---------
work_mem    10240    4096            user-override  4096-2097151   Integer
```

This cmdlet updates PostgreSql configuration by name.

### Example 2: Update PostgreSql configuration by identity.
```powershell
PS C:\> $ID = "/subscriptions/<SubscriptionId>/resourceGroups/PowershellPostgreSqlTest/providers/Microsoft.DBforPostgreSql/flexibleServers/PostgreSql-test/configurations/wait_timeout"
PS C:\> Update-AzPostgreSqlFlexibleServer -InputObject $ID -Value 10240

Name          Value   DefaultValue  Source        AllowedValues DataType
----          ------  ------------  -------       ------------- ---------
work_mem   10240    4096         system-default   4096-2097151   Integer
```

These cmdlets update PostgreSql configuration by identity.

