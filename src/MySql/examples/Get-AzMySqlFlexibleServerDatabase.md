### Example 1: Get a MySql database by resource name
```powershell
Get-AzMySqlFlexibleServerDatabase -ResourceGroupName PowershellMySqlTest -ServerName mysql-test -Name flexibleserverdb
```

```output
Name             Charset     Collation              
----             -------- ------------------
flexibleserverdb utf8     utf8_general_ci
```

This cmdlet gets MySql server by resource name.

### Example 2: Get MySql databases by identity
```powershell
$ID = "/subscriptions/<SubscriptionId>/resourceGroups/PowershellMySqlTest/providers/Microsoft.DBforMySQL/flexibleServers/mysql-test"
Get-AzMySqlFlexibleServerDatabase -InputObject $ID
```

```output
Name               Charset Collation
----               ------- ---------
information_schema utf8    utf8_general_ci
flexibleserverdb   utf8    utf8_general_ci
mysql              latin1  latin1_swedish_ci
performance_schema utf8    utf8_general_ci
sys                utf8    utf8_general_ci
```

This cmdlet gets a MySql server by identity.

### Example 3: Lists all the MySql databases in the specified server
```powershell
Get-AzMySqlFlexibleServerDatabase -ResourceGroupName PowershellMySqlTest -ServerName mysql-test
```

```output
Name               Charset Collation
----               ------- ---------
information_schema utf8    utf8_general_ci
flexibleserverdb   utf8    utf8_general_ci
mysql              latin1  latin1_swedish_ci
performance_schema utf8    utf8_general_ci
sys                utf8    utf8_general_ci
```

This cmdlet lists all the MySql servers in specified the server.