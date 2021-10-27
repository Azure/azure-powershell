### Example 1: Get a MySql database by resource name
```powershell
PS C:\> Get-AzMySqlFlexibleServerDatabase -ResourceGroupName PowershellMySqlTest -ServerName mysql-test -Name flexibleserverdb

Name             Charset     Collation              
----             -------- ------------------
flexibleserverdb utf8     utf8_general_ci
```

This cmdlet gets MySql server by resource name.

### Example 2: Get MySql databases by identity
```powershell
PS C:\> $ID = "/subscriptions/<SubscriptionId>/resourceGroups/PowershellMySqlTest/providers/Microsoft.DBforMySQL/flexibleServers/mysql-test"
PS C:\> Get-AzMySqlFlexibleServerDatabase -InputObject $ID

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
PS C:\> Get-AzMySqlFlexibleServerDatabase -ResourceGroupName PowershellMySqlTest -ServerName mysql-test

Name               Charset Collation
----               ------- ---------
information_schema utf8    utf8_general_ci
flexibleserverdb   utf8    utf8_general_ci
mysql              latin1  latin1_swedish_ci
performance_schema utf8    utf8_general_ci
sys                utf8    utf8_general_ci
```

This cmdlet lists all the MySql servers in specified the server.