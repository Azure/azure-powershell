### Example 1: Update MySql server by resource group and server name
```powershell
Update-AzMySqlFlexibleServer -ResourceGroupName PowershellMySqlTest -Name mysql-test -Sku Standard_D4ds_v4
```

```output
Name                 Location  SkuName          SkuTier        AdministratorLogin Version StorageSizeGb
----                 --------  -------          -------        ------------------ ------- -------------
mysql-test   West US 2 Standard_D2ds_v4 GeneralPurpose admin              5.7     32
```

This cmdlet updates MySql server by resource group and server name.

### Example 2: Update MySql server by identity.
```powershell
Get-AzMySqlFlexibleServer -ResourceGroupName PowershellMySqlTest -ServerName mysql-test | Update-AzMySqlFlexibleServer -BackupRetentionDay 23 -StorageInMb 10240
```

```output
Name                 Location  SkuName          SkuTier        AdministratorLogin Version StorageSizeGb
----                 --------  -------          -------        ------------------ ------- -------------
mysql-test   West US 2 Standard_D2ds_v4 GeneralPurpose admin              5.7     32
```

This cmdlet updates MySql server by identity.
