### Example 1: Update PostgreSql server by resource group and server name
```powershell
Update-AzPostgreSqlFlexibleServer -ResourceGroupName PowershellPostgreSqlTest -Name postgresql-test -Sku Standard_D4s_v3
```

```output
Name                Location  SkuName         SkuTier        AdministratorLogin StorageSizeGb
----                --------  -------         -------        ------------------ -------------
postgresql-test     East US   Standard_D4s_v3 GeneralPurpose daeunyim           256 GeneralPurpose
```

This cmdlet updates PostgreSql server by resource group and server name.

### Example 2: Update PostgreSql server by identity.
```powershell
Get-AzPostgreSqlFlexibleServer -ResourceGroupName PowershellPostgreSqlTest -ServerName postgresql-test | Update-AzPostgreSqlFlexibleServer -BackupRetentionDay 23 -StorageInMb 262144
```

```output
Name                Location  SkuName         SkuTier        AdministratorLogin StorageSizeGb
----                --------  -------         -------        ------------------ -------------
postgresql-test     East US   Standard_D2s_v3 GeneralPurpose daeunyim           256
```

This cmdlet updates PostgreSql server by identity.
