### Example 1: Remove a database by name
```powershell
PS C:\> Remove-AzPostgreSqlFlexibleServerDatabase -ResourceGroupName PowershellPostgreSqlTest -ServerName postgresql -Name testdb

```
Remove a database by name

### Example 2: Remove a database by Id
```powershell
PS C:\> Remove-AzPostgreSqlFlexibleServerDatabase-InputObject /subscriptions/0000000000-0000-0000-0000-000000000000/resourceGroups/PowershellPostgreSqlTest/providers/Microsoft.DBforPostgreSQL/flexibleServers/postgresql-test/databases/flexibleserverdb

```
Remove a database by Id

