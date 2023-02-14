### Example 1: Test connection by name
```powershell
<<<<<<< HEAD
$password = ConvertTo-SecureString <YourPassword> -AsPlainText
Test-AzPostgreSqlFlexibleServerConnect -ResourceGroupName PowershellPostgreSqlTest -Name postgresql-test -AdministratorLoginPassword $password
=======
 $password = ConvertTo-SecureString <YourPassword> -AsPlainText
 Get-AzPostgreSqlFlexibleServerConnect -ResourceGroupName PowershellPostgreSqlTest -Name postgresql-test -AdministratorLoginPassword $password
>>>>>>> 97176e9029ae7684a4ab56b6bec6966b134d4f91
```

```output
The connection testing to postgresql-test.database.azure.com was successful!
```

Test connection by the resource group and the server name

### Example 2: Test connection by identity
```powershell
<<<<<<< HEAD
$password = ConvertTo-SecureString <YourPassword> -AsPlainText
Get-AzPostgreSqlFlexibleServer -ResourceGroupName PowershellPostgreSqlTest -ServerName postgresql-test | Test-AzPostgreSqlFlexibleServerConnect -AdministratorLoginPassword $password
=======
 $password = ConvertTo-SecureString <YourPassword> -AsPlainText
 Get-AzPostgreSqlFlexibleServer -ResourceGroupName PowershellPostgreSqlTest -ServerName postgresql-test | Test-AzPostgreSqlFlexibleServerConnect -AdministratorLoginPassword $password
>>>>>>> 97176e9029ae7684a4ab56b6bec6966b134d4f91
```

```output
The connection testing to postgresql-test.database.azure.com was successful!
```

Test connection by the identity

### Example 3: Test query by name
```powershell
<<<<<<< HEAD
$password = ConvertTo-SecureString <YourPassword> -AsPlainText
Test-AzPostgreSqlFlexibleServerConnect -ResourceGroupName PowershellPostgreSqlTest -Name postgresql-test -AdministratorLoginPassword $password -QueryText "SELECT * FROM test"
=======
 $password = ConvertTo-SecureString <YourPassword> -AsPlainText
 Test-AzPostgreSqlFlexibleServerConnect -ResourceGroupName PowershellPostgreSqlTest -Name postgresql-test -AdministratorLoginPassword $password -Query "SELECT * FROM test"
>>>>>>> 97176e9029ae7684a4ab56b6bec6966b134d4f91
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
<<<<<<< HEAD
Get-AzPostgreSqlFlexibleServer -ResourceGroupName PowershellPostgreSqlTest -ServerName postgresql-test | Test-AzPostgreSqlFlexibleServerConnect -QueryText "SELECT * FROM test" -AdministratorLoginPassword $password
=======
 Get-AzPostgreSqlFlexibleServer -ResourceGroupName PowershellPostgreSqlTest -ServerName postgresql-test | Test-AzPostgreSqlFlexibleServerConnect -Query "SELECT * FROM test" -AdministratorLoginPassword $password
>>>>>>> 97176e9029ae7684a4ab56b6bec6966b134d4f91
```

```output
col
-----
1
2
3
```

Test a query by the identity