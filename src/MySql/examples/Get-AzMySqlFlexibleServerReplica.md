### Example 1: Get MySql server replica by resource group and server name
```powershell
Get-AzMySqlFlexibleServerReplica -ResourceGroupName PowershellMySqlTest -ServerName mysql-test
```

```output
Name                 Location  SkuName          SkuTier        AdministratorLogin Version StorageSizeGb
----                 --------  -------          -------        ------------------ ------- -------------
mysql-test-replica   West US 2 Standard_D2ds_v4 GeneralPurpose admin              5.7     32
```

This cmdlet gets MySql server replica by resource group and server name.
