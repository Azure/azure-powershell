### Example 1: Remove MySql database by name
```powershell
Remove-AzMySqlFlexibleServerDatabase -Name databasetest -ResourceGroupName PowershellMySqlTest -ServerName mysql-test
```
This cmdlet removes MySql database by name.
### Example 2: Remove MySql database by identity
```powershell
$ID = "/subscriptions/<SubscriptionId>/resourceGroups/PowershellMySqlTest/providers/Microsoft.DBforMySQL/flexibleServers/mysql-test/databases/databasetest"
Remove-AzMySqlFlexibleServerDatabase -InputObject $ID
```
These cmdlets remove MySql database by identity.

