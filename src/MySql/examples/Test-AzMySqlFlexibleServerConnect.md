### Example 1: Test connection by name
```powershell
$password = ConvertTo-SecureString <YourPassword> -AsPlainText
Get-AzMySqlFlexibleServerConnect -ResourceGroupName PowershellMySqlTest -Name mysql-test -AdministratorLoginPassword $password
```

```output
The connection testing to mysql-test.database.azure.com was successful!
```

Test connection by the resource group and the server name

### Example 2: Test connection by identity
```powershell
$password = ConvertTo-SecureString <YourPassword> -AsPlainText
Get-AzMySqlFlexibleServer -ResourceGroupName PowershellMySqlTest -ServerName mysql-test | Get-AzMySqlFlexibleServerConnect -AdministratorLoginPassword $password
```

```output
The connection testing to mysql-test.database.azure.com was successful!
```

Test connection by the identity

### Example 3: Test query by name
```powershell
$password = ConvertTo-SecureString <YourPassword> -AsPlainText
Get-AzMySqlFlexibleServerConnect -ResourceGroupName PowershellMySqlTest -Name mysql-test -AdministratorLoginPassword $password -Query "SELECT * FROM test"
```

```output
col
-----
1
2
3
```

Test a query by the resource group and the server name

### Example 4: Test connection by identity
```powershell
Get-AzMySqlFlexibleServer -ResourceGroupName PowershellMySqlTest -ServerName mysql-test | Get-AzMySqlFlexibleServerConnect -Query "SELECT * FROM test" -AdministratorLoginPassword $password
```

```output
col
-----
1
2
3
```

Test a query by the identity

