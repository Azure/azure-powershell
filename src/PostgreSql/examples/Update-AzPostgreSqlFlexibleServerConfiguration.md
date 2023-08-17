### Example 1: Updatae specified PostgreSql configuration by name
```powershell
Update-AzPostgreSqlFlexibleServerConfiguration -Name work_mem -ResourceGroupName PowershellPostgreSqlTest -ServerName postgresql-test -Value 8192
```

```output
Name     Value AllowedValue Source         DefaultValue
----     ----- ------------ ------         ------------
work_mem 8192  4096-2097151 system-default 4096

```

This cmdlet updates specified PostgreSql configuration by name.

### Example 2: Updatae specified PostgreSql configuration by identity
```powershell
$ID = "/subscriptions/<SubscriptionId>/resourceGroups/PowershellPostgreSqlTest/providers/Microsoft.DBforPostgreSQL/flexibleServers/postgresql-test/configurations/work_mem"
Update-AzPostgreSqlFlexibleServerConfiguration -Name work_mem -ResourceGroupName PowershellPostgreSqlTest -ServerName postgresql-test -Value 8192
```

```output
Name     Value AllowedValue Source         DefaultValue
----     ----- ------------ ------         ------------
work_mem 8192  4096-2097151 system-default 4096
```

This cmdlet updates specified PostgreSql configuration by identity.