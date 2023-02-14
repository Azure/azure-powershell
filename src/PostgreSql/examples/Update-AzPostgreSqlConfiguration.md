### Example 1: Update PostgreSql configuration by name
```powershell
<<<<<<< HEAD
Update-AzPostgreSqlConfiguration -Name intervalstyle -ResourceGroupName PostgreSqlTestRG -ServerName PostgreSqlTestServer -Value SQL_STANDARD
=======
 Update-AzPostgreSqlConfiguration -Name intervalstyle -ResourceGroupName PostgreSqlTestRG -ServerName PostgreSqlTestServer -Value SQL_STANDARD
>>>>>>> 97176e9029ae7684a4ab56b6bec6966b134d4f91
```

```output
Name          Value
----          -----
intervalstyle SQL_STANDARD
```

This cmdlet updates PostgreSql configuration by name.

### Example 2: Update PostgreSql configuration by identity.
```powershell
<<<<<<< HEAD
$ID = "/subscriptions/<SubscriptionId>/resourceGroups/PostgreSqlTestRG/providers/Microsoft.DBforPostgreSQL/servers/PostgreSqlTestServer/configurations/deadlock_timeout"
Update-AzPostgreSqlConfiguration -InputObject $ID -Value 2000
=======
 $ID = "/subscriptions/<SubscriptionId>/resourceGroups/PostgreSqlTestRG/providers/Microsoft.DBforPostgreSQL/servers/PostgreSqlTestServer/configurations/deadlock_timeout"
 Update-AzPostgreSqlConfiguration -InputObject $ID -Value 2000
>>>>>>> 97176e9029ae7684a4ab56b6bec6966b134d4f91
```

```output
Name             Value
----             -----
deadlock_timeout 2000
```

These cmdlets update PostgreSql configuration by identity.