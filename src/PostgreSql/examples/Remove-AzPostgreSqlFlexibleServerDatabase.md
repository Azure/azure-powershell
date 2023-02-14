### Example 1: Remove a database by name
```powershell
Remove-AzPostgreSqlFlexibleServerDatabase -ResourceGroupName PowershellPostgreSqlTest -ServerName postgresql -Name testdb
<<<<<<< HEAD
=======

>>>>>>> 97176e9029ae7684a4ab56b6bec6966b134d4f91
```
Remove a database by name

### Example 2: Remove a database by Id
```powershell
<<<<<<< HEAD
Remove-AzPostgreSqlFlexibleServerDatabase-InputObject /subscriptions/0000000000-0000-0000-0000-000000000000/resourceGroups/PowershellPostgreSqlTest/providers/Microsoft.DBforPostgreSQL/flexibleServers/postgresql-test/databases/flexibleserverdb
=======
 Remove-AzPostgreSqlFlexibleServerDatabase -InputObject /subscriptions/0000000000-0000-0000-0000-000000000000/resourceGroups/PowershellPostgreSqlTest/providers/Microsoft.DBforPostgreSQL/flexibleServers/postgresql-test/databases/flexibleserverdb

>>>>>>> 97176e9029ae7684a4ab56b6bec6966b134d4f91
```
Remove a database by Id

