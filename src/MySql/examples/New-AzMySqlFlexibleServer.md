### Example 1: Create a new MySql flexible server
```powershell
PS C:\> $password = 'Pasword01!!2020' | ConvertTo-SecureString -AsPlainText -Force
PS C:\> New-AzMySqlFlexibleServer -Name mysql-test -ResourceGroupName PowershellMySqlTest \
-Location eastus -AdministratorUserName mysqltest -AdministratorLoginPassword $password -Sku Standard_B1ms -SkuTier Burstable -Version 12 -StorageInMb 10240

Name            Location AdministratorLogin Version StorageProfileStorageMb SkuName         SkuTier     
----            -------- ------------------ ------- ----------------------- ------------    -------------        
mysql-test      West US 2   mysqltest    5.7      10240                  Standard_B1ms   Burstable
```


### Example 2: Create a new MySql flexible server with default setting
```powershell
PS C:\> $password = 'Pasword01!!2020' | ConvertTo-SecureString -AsPlainText -Force
PS C:\> New-AzMySqlFlexibleServer -Name mysql-test -ResourceGroupName PowershellMySqlTest \
-AdministratorUserName mysqltest -AdministratorLoginPassword $password

Name            Location AdministratorLogin Version StorageProfileStorageMb SkuName         SkuTier     
----            -------- ------------------ ------- ----------------------- ------------    -------------        
mysql-test      West US 2   mysqltest    5.7      131072                  Standard_B1ms   Burstable
```

Create MySql server with default values. The default values of location is West US 2, Sku is Standard_B1ms, Sku tier is Burstable, and storage size is 10GiB.