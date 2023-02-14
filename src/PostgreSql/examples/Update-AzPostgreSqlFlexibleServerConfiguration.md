### Example 1: Updatae specified PostgreSql configuration by name
```powershell
<<<<<<< HEAD
Update-AzPostgreSqlFlexibleServerConfiguration -Name work_mem -ResourceGroupName PowershellPostgreSqlTest -ServerName postgresql-test -Value 8192
=======
 Update-AzPostgreSqlFlexibleServerConfiguration -Name work_mem -ResourceGroupName PowershellPostgreSqlTest -ServerName postgresql-test -Value 8192
>>>>>>> 97176e9029ae7684a4ab56b6bec6966b134d4f91
```

```output
Name     Value AllowedValue Source         DefaultValue
----     ----- ------------ ------         ------------
work_mem 8192  4096-2097151 system-default 4096

```

This cmdlet updates specified PostgreSql configuration by name.

### Example 2: Updatae specified PostgreSql configuration by identity
```powershell
<<<<<<< HEAD
$ID = "/subscriptions/<SubscriptionId>/resourceGroups/PowershellPostgreSqlTest/providers/Microsoft.DBforPostgreSQL/flexibleServers/postgresql-test/configurations/work_mem"
Update-AzPostgreSqlFlexibleServerConfiguration -Name work_mem -ResourceGroupName PowershellPostgreSqlTest -ServerName postgresql-test -Value 8192
=======
 $ID = "/subscriptions/<SubscriptionId>/resourceGroups/PowershellPostgreSqlTest/providers/Microsoft.DBforPostgreSQL/flexibleServers/postgresql-test/configurations/work_mem"
 Get-AzPostgreSqlFlexibleServerConfiguration -Name work_mem -ResourceGroupName PowershellPostgreSqlTest -ServerName postgresql-test -Value 8192
>>>>>>> 97176e9029ae7684a4ab56b6bec6966b134d4f91
```

```output
Name     Value AllowedValue Source         DefaultValue
----     ----- ------------ ------         ------------
work_mem 8192  4096-2097151 system-default 4096
```

This cmdlet updates specified PostgreSql configuration by identity.