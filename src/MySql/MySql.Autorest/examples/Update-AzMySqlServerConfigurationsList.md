### Example 1: Update MySQL configurations list by name
```powershell
Update-AzMySqlServerConfigurationsList -ResourceGroupName PowershellMySqlTest -ServerName mysql-test
```
Update MySQL configurations list by name.

### Example 2: Update MySQL configurations list by identity
```powershell
Get-AzMySqlServer -ResourceGroupName PowershellMySqlTest -ServerName mysql-test | Update-AzMySqlServerConfigurationsList
```

Update MySQL configurations list by ID.

