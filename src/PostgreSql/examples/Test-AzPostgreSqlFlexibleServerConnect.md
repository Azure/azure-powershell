### Example 1: Test connection by name
```powershell
PS C:\> $password = ConvertTo-SecureString <YourPassword> -AsPlainText
PS C:\> Get-AzPostgreSqlFlexibleServerConnect -ResourceGroupName PowershellPostgreSqlTest -Name postgresql-test -AdministratorLoginPassword $password

The connection testing to postgresql-test.database.azure.com was successful!
```

Test connection by the resource group and the server name

### Example 2: Test connection by identity
```powershell
PS C:\> $password = ConvertTo-SecureString <YourPassword> -AsPlainText
PS C:\> Get-AzPostgreSqlFlexibleServer -ResourceGroupName PowershellPostgreSqlTest -ServerName postgresql-test | Test-AzPostgreSqlFlexibleServerConnect -AdministratorLoginPassword $password

The connection testing to postgresql-test.database.azure.com was successful!
```

Test connection by the identity

### Example 3: Test query by name
```powershell
PS C:\> $password = ConvertTo-SecureString <YourPassword> -AsPlainText
PS C:\> Test-AzPostgreSqlFlexibleServerConnect -ResourceGroupName PowershellPostgreSqlTest -Name postgresql-test -AdministratorLoginPassword $password -Query "SELECT * FROM test"

col
-----
1
2
3
```

Test a query by the resource group and the server name

### Example 4: Test connection by identity
```powershell
PS C:\> Get-AzPostgreSqlFlexibleServer -ResourceGroupName PowershellPostgreSqlTest -ServerName postgresql-test | Test-AzPostgreSqlFlexibleServerConnect -Query "SELECT * FROM test" -AdministratorLoginPassword $password

col
-----
1
2
3
```

Test a query by the identity