### Example 1: Update MySql server by resource group and server name
```powershell
Update-AzMySqlServer -ResourceGroupName PowershellMySqlTest -ServerName mysql-test -SslEnforcement Disabled
```

```output
Name          Location AdministratorLogin Version StorageProfileStorageMb SkuName   SkuTier        SslEnforcement
----          -------- ------------------ ------- ----------------------- -------   -------        --------------
mysql-test    eastus   mysql_test         5.7     5120                    GP_Gen5_4 GeneralPurpose Disabled
```

This cmdlet updates MySql server by resource group and server name.

### Example 2: Update MySql server by identity.
```powershell
Get-AzMySqlServer -ResourceGroupName PowershellMySqlTest -ServerName mysql-test | Update-AzMySqlServer -BackupRetentionDay 23 -StorageInMb 10240
```

```output
Name          Location AdministratorLogin Version StorageProfileStorageMb SkuName   SkuTier        SslEnforcement
----          -------- ------------------ ------- ----------------------- -------   -------        --------------
mysql-test    eastus   mysql_test         5.7     10240                   GP_Gen5_4 GeneralPurpose Disabled
```

This cmdlet updates MySql server by identity.
