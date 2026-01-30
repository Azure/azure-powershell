### Example 1: Get PostgreSQL Flexible Server capabilities for East US region
```powershell
Get-AzPostgreSqlFlexibleServerCapabilitiesByLocation -LocationName "East US"
```

```output
Name                                 : FlexibleServerCapabilities
FastProvisioningSupported           : Enabled
GeoBackupSupported                  : Enabled
OnlineResizeSupported               : Enabled
StorageAutoGrowthSupported          : Enabled
SupportedFastProvisioningEditions   : {Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.FastProvisioningEditionCapability}
SupportedFeatures                   : {Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.FlexibleServerCapability}
SupportedServerEditions             : {Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.FlexibleServerEditionCapability}
SupportedServerVersions             : {Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.ServerVersionCapability}
ZoneRedundantHaAndGeoBackupSupported: Enabled
ZoneRedundantHaSupported            : Enabled
```

Gets the comprehensive PostgreSQL Flexible Server capabilities available in the East US region, including all supported features, editions, versions, and backup options.

### Example 2: Get PostgreSQL Flexible Server capabilities for a specific subscription and location
```powershell
Get-AzPostgreSqlFlexibleServerCapabilitiesByLocation -LocationName "West Europe" -SubscriptionId "ssssssss-ssss-ssss-ssss-ssssssssssss"
```

```output
Name                                 : FlexibleServerCapabilities
FastProvisioningSupported           : Enabled
GeoBackupSupported                  : Enabled
OnlineResizeSupported               : Enabled
StorageAutoGrowthSupported          : Enabled
SupportedFastProvisioningEditions   : {Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.FastProvisioningEditionCapability}
SupportedFeatures                   : {Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.FlexibleServerCapability}
SupportedServerEditions             : {Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.FlexibleServerEditionCapability}
SupportedServerVersions             : {Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.ServerVersionCapability}
ZoneRedundantHaAndGeoBackupSupported: Enabled
ZoneRedundantHaSupported            : Enabled
```

Gets the comprehensive PostgreSQL Flexible Server capabilities available in the West Europe region for a specific subscription.

