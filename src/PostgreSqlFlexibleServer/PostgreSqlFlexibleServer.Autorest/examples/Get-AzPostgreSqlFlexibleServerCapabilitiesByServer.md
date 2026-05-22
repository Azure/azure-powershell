### Example 1: Get flexible server capabilities in a flexible server
```powershell
Get-AzPostgreSqlFlexibleServerCapabilitiesByServer -SubscriptionId aaaa0a0a-bb1b-cc2c-dd3d-eeeeee4e4e4e -ResourceGroup example-resource-group -ServerName example-server-name
```

```output
Name                        ZoneRedundantHaSupported  ZoneRedundantHaAndGeoBackupSupported  StorageAutoGrowthSupported  OnlineResizeSupported   GeoBackupSupported
----                        ------------------------  ------------------------------------  --------------------------  ---------------------   ------------------
FlexibleServerCapabilities  Enabled                   Enabled                               Enabled                     Enabled                 Enabled
```

Gets capabilities in an Azure Database for PostgreSQL flexible server with name, resource group, and subscription explicitly passed as an arguments. If subscription is not passed explicitly, it's taken from default context.
