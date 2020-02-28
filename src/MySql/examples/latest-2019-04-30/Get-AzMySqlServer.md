### Example 1: Get MySql server by ResourceGroup and ServerName
```powershell
PS C:\> Get-AzMySqlServer -ResourceGroupName mysql_test -ServerName mysql-test

Name        Location AdministratorLogin Version StorageProfileStorageMb SkuName   SkuSize SkuTier        SslEnforcement
----        -------- ------------------ ------- ----------------------- -------   ------- -------        --------------
mysql-test  eastus   mysql_test         5.7     5120                    GP_Gen5_4         GeneralPurpose Enabled
```

The cmdlet gets MySql server by ResourceGroup and ServerName.

### Example 2: Lists all the MySql servers in specified resource group
```powershell
PS C:\> Get-AzMySqlServer -ResourceGroupName mysql_test

Name        Location AdministratorLogin Version StorageProfileStorageMb SkuName   SkuSize SkuTier        SslEnforcement
----        -------- ------------------ ------- ----------------------- -------   ------- -------        --------------
mysql-test  eastus   mysql_test         5.7     5120                    GP_Gen5_4         GeneralPurpose Enabled
```

The cmdlet lists all the MySql servers in specified resource group.


