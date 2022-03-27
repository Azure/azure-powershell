### Example 1: Create a new MySql server database
```powershell
New-AzMySqlFlexibleServerDatabase -Name databasetest -ResourceGroupName PowershellMySqlTest -ServerName mysql-test -Charset latin1 -Collation latin1_swedish_ci
```

```output
Name            Charset     Collation              
----            -------- ------------------
databasetest    latin1   latin1_swedish_ci  
```
Create a database with default settings.
