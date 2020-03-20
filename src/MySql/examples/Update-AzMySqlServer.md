### Example 1: Update MySql server by resource group and server name
```powershell
PS C:\> Update-AzMySqlServer -ResourceGroupName mysql_test -ServerName mysql-test -SslEnforcement Disabled

Name        Location AdministratorLogin Version StorageProfileStorageMb SkuName   SkuSize SkuTier        SslEnforcement
----        -------- ------------------ ------- ----------------------- -------   ------- -------        --------------
mysql-test  eastus   mysql_test         5.7     10240                   GP_Gen5_4         GeneralPurpose Disabled
```

This cmdlet updates MySql server by resource group and server name.

### Example 2: Update MySql server by mysql identity.
```powershell
PS C:\> Get-AzMySqlServer -ResourceGroupName mysql_test -ServerName mysql-test | Update-AzMySqlServer -StorageProfileBackupRetentionDay 23 -StorageProfileStorageMb 10240

Name        Location AdministratorLogin Version StorageProfileStorageMb SkuName   SkuSize SkuTier        SslEnforcement
----        -------- ------------------ ------- ----------------------- -------   ------- -------        --------------
mysql-test  eastus   mysql_test         5.7     10240                   GP_Gen5_4         GeneralPurpose Enabled
```

These cmdlets update MySql server by mysql identity.
