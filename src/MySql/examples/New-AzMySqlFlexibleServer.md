### Example 1: Create a new MySql flexible server
```powershell
PS C:\> $password = 'Pa88word!' | ConvertTo-SecureString -AsPlainText -Force
PS C:\> New-AzMySqlFlexibleServer -Name mysql-test -ResourceGroupName PowershellMySqlTest \
-Location westus2 -AdministratorUserName mysql_test -AdministratorLoginPassword $password -Sku Standard_B1ms -SkuTier Burstable

Name          Location AdministratorLogin Version StorageProfileStorageMb SkuName          SkuTier        
----          -------- ------------------ ------- ----------------------- ---------------- -------------
mysql-test    westus2   mysql_test         5.7     10240                  Standard_B1ms    Burstable
```
### Example 2: Create a new MySql flexible server with default parameters
```powershell
PS C:\> $password = 'Pa88word!' | ConvertTo-SecureString -AsPlainText -Force
PS C:\> New-AzMySqlFlexibleServer -Name mysql-test -ResourceGroupName PowershellMySqlTest -AdministratorUserName mysql_test -AdministratorLoginPassword $password

Name          Location AdministratorLogin Version StorageProfileStorageMb SkuName          SkuTier        
----          -------- ------------------ ------- ----------------------- ---------------- -------------
mysql-test    westus2   mysql_test         5.7     10240                  Standard_B1ms    Burstable
```

When no parameters are given, the default values for SKU, SKU tier, storage size, and location are given. 