### Example 1: Update PostgreSql configuration by name
```powershell
Update-AzPostgreSqlConfiguration -Name intervalstyle -ResourceGroupName PostgreSqlTestRG -ServerName PostgreSqlTestServer -Value SQL_STANDARD
```

```output
Name          Value
----          -----
intervalstyle SQL_STANDARD
```

This cmdlet updates PostgreSql configuration by name.

### Example 2: Update PostgreSql configuration by identity.
```powershell
$ID = "/subscriptions/<SubscriptionId>/resourceGroups/PostgreSqlTestRG/providers/Microsoft.DBforPostgreSQL/servers/PostgreSqlTestServer/configurations/deadlock_timeout"
Update-AzPostgreSqlConfiguration -InputObject $ID -Value 2000
```

```output
Name             Value
----             -----
deadlock_timeout 2000
```

These cmdlets update PostgreSql configuration by identity.