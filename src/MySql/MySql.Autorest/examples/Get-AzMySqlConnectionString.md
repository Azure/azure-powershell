### Example 1: Get MySql server connection string by resource group and server name
```powershell
Get-AzMySqlConnectionString -Client ADO.NET -Name mysql-test -ResourceGroupName PowershellMySqlTest
```

```output
Server=mysql-test.mysql.database.azure.com; Port=3306; Database={your_database}; Uid=mysql_test@mysql-test; Pwd={your_password};
```

This cmdlet gets MySql server connection string by resource group and server name.

### Example 2: Get MySql server connection string by identity
```powershell
Get-AzMySqlServer -ResourceGroupName PowershellMySqlTest -ServerName mysql-test | Get-AzMySqlConnectionString -Client PHP
```

```output
$con=mysqli_init(); mysqli_real_connect($con, "mysql-test.mysql.database.azure.com", "mysql_test@mysql-test", {your_password}, {your_database}, 3306);
```

This cmdlet gets MySql server connection string by identity.
