### Example 1: List Target Type resources for given location.
```powershell
Get-AzChaosTargetType -LocationName eastus
```

```output
Name                                      Location ResourceGroupName
----                                      -------- -----------------
Microsoft-Agent                           eastus
Microsoft-AppService                      eastus
Microsoft-KeyVault                        eastus
```

List Target Type resources for given location.

### Example 2: Get a Target Type resources for given location.
```powershell
Get-AzChaosTargetType -LocationName eastus -Name Microsoft-KeyVault
```

```output
Description                  :
DisplayName                  :
Id                           : /subscriptions/{subId}/providers/Microsoft.Chaos/locations/eastus/targetTypes/Microsoft-KeyVault
Location                     : eastus
Name                         : Microsoft-KeyVault
PropertiesSchema             : https://schema-tc.eastus.chaos-prod.azure.com/targetTypes/Microsoft-KeyVault/propertiesSchema.json
ResourceGroupName            :
ResourceType                 : {Microsoft.KeyVault/vaults}
SystemDataCreatedAt          : 2024-03-08 06:57:58 PM
SystemDataCreatedBy          :
SystemDataCreatedByType      : Application
SystemDataLastModifiedAt     : 2024-03-08 06:57:58 PM
SystemDataLastModifiedBy     :
SystemDataLastModifiedByType :
Type                         : Microsoft.Chaos/locations/targetTypes
```

Get a Target Type resources for given location.