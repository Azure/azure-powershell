### Example 1: Get MySql server replica by resource group and server name
```powershell
Get-AzMySqlReplica -ResourceGroupName PowershellMySqlTest -ServerName mysql-test
```

```output
Name               Location AdministratorLogin Version StorageProfileStorageMb SkuName   SkuTier        SslEnforcement
----               -------- ------------------ ------- ----------------------- -------   -------        --------------
mysql-test-replica eastus   mysql_test         5.7     10240                   GP_Gen5_4 GeneralPurpose Disabled
```

This cmdlet gets MySql server replica by resource group and server name.
