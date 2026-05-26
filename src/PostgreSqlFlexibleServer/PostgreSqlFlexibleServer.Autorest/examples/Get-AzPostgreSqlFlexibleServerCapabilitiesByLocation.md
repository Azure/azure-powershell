### Example 1: Get flexible server capabilities in a location
```powershell
Get-AzPostgreSqlFlexibleServerCapabilitiesByLocation -SubscriptionId aaaa0a0a-bb1b-cc2c-dd3d-eeeeee4e4e4e -LocationName example-location
```

```output
Name                        ZoneRedundantHaSupported  ZoneRedundantHaAndGeoBackupSupported  StorageAutoGrowthSupported  OnlineResizeSupported   GeoBackupSupported
----                        ------------------------  ------------------------------------  --------------------------  ---------------------   ------------------
FlexibleServerCapabilities  Enabled                   Enabled                               Enabled                     Enabled                 Enabled
```

Gets capabilities in a location for a subscription explicitly passed as arguments. If subscription is not passed explicitly, it's taken from default context.
