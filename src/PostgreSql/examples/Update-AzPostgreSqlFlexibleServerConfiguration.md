### Example 1: Updatae specified PostgreSql configuration by name
```powershell
PS C:\> Update-AzPostgreSqlFlexibleServerConfiguration -Name work_mem -ResourceGroupName PowershellPostgreSqlTest -ServerName postgresql-test -Value 8192

Name     Value AllowedValue Source         DefaultValue
----     ----- ------------ ------         ------------
work_mem 8192  4096-2097151 system-default 4096

```

This cmdlet updates specified PostgreSql configuration by name.

### Example 1: Updatae specified PostgreSql configuration by identity
```powershell
PS C:\> $ID = "/subscriptions/<SubscriptionId>/resourceGroups/PowershellPostgreSqlTest/providers/Microsoft.DBforPostgreSQL/flexibleServers/postgresql-test/configurations/work_mem"
PS C:\> Get-AzPostgreSqlFlexibleServerConfiguration -Name work_mem -ResourceGroupName PowershellPostgreSqlTest -ServerName postgresql-test -Value 8192

Name     Value AllowedValue Source         DefaultValue
----     ----- ------------ ------         ------------
work_mem 8192  4096-2097151 system-default 4096
```

This cmdlet updates specified PostgreSql configuration by identity.