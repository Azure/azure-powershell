### Example 1: Scale up a PostgreSQL Flexible Server
```powershell
Update-AzPostgreSqlFlexibleServer -ResourceGroupName "myResourceGroup" -ServerName "myPostgreSqlServer" -SkuName "Standard_D4s_v3" -StorageSizeGb 256
```

```output
Name               : myPostgreSqlServer
ResourceGroupName  : myResourceGroup
Location           : East US
SkuName            : Standard_D4s_v3
SkuTier            : GeneralPurpose
StorageSizeGb      : 256
Version            : 13
State              : Ready
```

Scales up the PostgreSQL Flexible Server to a larger SKU and increases storage size.

### Example 2: Update backup retention settings
```powershell
Update-AzPostgreSqlFlexibleServer -ResourceGroupName "production-rg" -ServerName "prod-postgresql-01" -BackupRetentionDay 30 -GeoRedundantBackup "Enabled"
```

```output
Name               : prod-postgresql-01
ResourceGroupName  : production-rg
Location           : West Europe
BackupRetentionDay : 30
GeoRedundantBackup : Enabled
State              : Ready
```

Updates the backup retention period to 30 days and enables geo-redundant backup for the server.

