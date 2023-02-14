### Example 1: Update PostgreSql server by resource group and server name
```powershell
<<<<<<< HEAD
Update-AzPostgreSqlFlexibleServer -ResourceGroupName PowershellPostgreSqlTest -Name postgresql-test -Sku Standard_D4s_v3
=======
 Update-AzPostgreSqlFlexibleServer -ResourceGroupName PowershellPostgreSqlTest -Name postgresql-test -Sku Standard_D4s_v3
>>>>>>> 97176e9029ae7684a4ab56b6bec6966b134d4f91
```

```output
Name                Location  SkuName         SkuTier        AdministratorLogin StorageSizeGb
----                --------  -------         -------        ------------------ -------------
postgresql-test     East US   Standard_D4s_v3 GeneralPurpose daeunyim           256 GeneralPurpose
```

This cmdlet updates PostgreSql server by resource group and server name.

### Example 2: Update PostgreSql server by identity.
```powershell
<<<<<<< HEAD
Get-AzPostgreSqlFlexibleServer -ResourceGroupName PowershellPostgreSqlTest -ServerName postgresql-test | Update-AzPostgreSqlFlexibleServer -BackupRetentionDay 23 -StorageInMb 262144
=======
 Get-AzPostgreSqlFlexibleServer -ResourceGroupName PowershellPostgreSqlTest -ServerName postgresql-test | Update-AzPostgreSqlFlexibleServer -BackupRetentionDay 23 -StorageMb 262144
>>>>>>> 97176e9029ae7684a4ab56b6bec6966b134d4f91
```

```output
Name                Location  SkuName         SkuTier        AdministratorLogin StorageSizeGb
----                --------  -------         -------        ------------------ -------------
postgresql-test     East US   Standard_D2s_v3 GeneralPurpose daeunyim           256
```

This cmdlet updates PostgreSql server by identity.
