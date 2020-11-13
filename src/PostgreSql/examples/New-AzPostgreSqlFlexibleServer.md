### Example 1: Create a new PostgreSql flexible server
```powershell
PS C:\> $password = 'Pa88word!' | ConvertTo-SecureString -AsPlainText -Force
PS C:\> New-AzPostgreSqlFlexibleServer -Name postgresql-test -ResourceGroupName PowershellPostgreSqlTest \
-Location eastus -AdministratorUserName postgresql_test -AdministratorLoginPassword $password -Sku Standard_B1ms -SkuTier Burstable

Name              Location AdministratorLogin Version StorageProfileStorageMb SkuName          SkuTier        
----              -------- ------------------ ------- ----------------------- ---------------- -------------
postgresql-test    westus2   postgresql_test    12     131072                  Standard_B1ms    Burstable
```
### Example 2: Create a new PostgreSql flexible server with default parameters
```powershell
PS C:\> $password = 'Pa88word!' | ConvertTo-SecureString -AsPlainText -Force
PS C:\> New-AzPostgreSqlFlexibleServer -Name postgresql-test -ResourceGroupName PowershellPostgreSqlTest -AdministratorUserName postgresql_test -AdministratorLoginPassword $password

Name              Location AdministratorLogin Version StorageProfileStorageMb SkuName          SkuTier        
----              -------- ------------------ ------- ----------------------- ---------------- -------------
postgresql-test    westus2   postgresql_test    12     131072                  Standard_D2s_v3  GeneralPurpose
```

When no parameters are given, the default values for SKU, SKU tier, storage size, and location are given. 