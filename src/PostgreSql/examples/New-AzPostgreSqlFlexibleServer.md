### Example 1: Create a new PostgreSql flexible server
```powershell
PS C:\> $password = 'Pasword01!!2020' | ConvertTo-SecureString -AsPlainText -Force
PS C:\> New-AzPostgreSqlFlexibleServer -Name postgresql-test -ResourceGroupName PowershellPostgreSqlTest \
-Location eastus -AdministratorUserName postgresqltest -AdministratorLoginPassword $password -Sku Standard_B1ms -SkuTier Burstable -Version 12 -StorageInMb 131072

Name            Location AdministratorLogin Version StorageProfileStorageMb SkuName         SkuTier     
----            -------- ------------------ ------- ----------------------- ------------    -------------        
postgresql-test East US   postgresqltest     12      131072                  Standard_D2s_v3 GeneralPurpose
```


### Example 2: Create a new PostgreSql flexible server with default setting
```powershell
PS C:\> $password = 'Pasword01!!2020' | ConvertTo-SecureString -AsPlainText -Force
PS C:\> New-AzPostgreSqlFlexibleServer -Name postgresql-test -ResourceGroupName PowershellPostgreSqlTest \
-AdministratorUserName postgresqltest -AdministratorLoginPassword $password

Name            Location AdministratorLogin Version StorageProfileStorageMb SkuName         SkuTier     
----            -------- ------------------ ------- ----------------------- ------------    -------------        
postgresql-test East US   postgresqltest     12      131072                  Standard_D2s_v3 GeneralPurpose
```

Create Postgres server with default values. The default values of location is East US, Sku is Standard_D2s_v3, Sku tier is general purpose, and storage size is 128GiB.