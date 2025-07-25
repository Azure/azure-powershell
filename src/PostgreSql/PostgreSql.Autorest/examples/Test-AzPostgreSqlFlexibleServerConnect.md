### Example 1: Test connection by name
```powershell
$password = ConvertTo-SecureString <YourPassword> -AsPlainText
Test-AzPostgreSqlFlexibleServerConnect -ResourceGroupName PowershellPostgreSqlTest -Name postgresql-test -AdministratorLoginPassword $password
```

```output
The connection testing to postgresql-test.database.azure.com was successful!
```

Test connection by the resource group and the server name

### Example 2: Test connection by identity
```powershell
$password = ConvertTo-SecureString <YourPassword> -AsPlainText
Get-AzPostgreSqlFlexibleServer -ResourceGroupName PowershellPostgreSqlTest -ServerName postgresql-test | Test-AzPostgreSqlFlexibleServerConnect -AdministratorLoginPassword $password
```

```output
The connection testing to postgresql-test.database.azure.com was successful!
```

Test connection by the identity

### Example 3: Test query by name
```powershell
$password = ConvertTo-SecureString <YourPassword> -AsPlainText
Test-AzPostgreSqlFlexibleServerConnect -ResourceGroupName PowershellPostgreSqlTest -Name postgresql-test -AdministratorLoginPassword $password -QueryText "SELECT * FROM test"
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
Get-AzPostgreSqlFlexibleServer -ResourceGroupName PowershellPostgreSqlTest -ServerName postgresql-test | Test-AzPostgreSqlFlexibleServerConnect -QueryText "SELECT * FROM test" -AdministratorLoginPassword $password
```

```output
col
-----
1
2
3
```

Test a query by the identity