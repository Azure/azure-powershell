### Example 1: List all Azure Extended Zones under a subscription
```powershell
Get-AzEdgeZonesExtendedZone
```

```output
Name                     SystemDataCreatedAt SystemDataCreatedBy SystemDataCreatedByType SystemDataLastModifiedAt SystemDataLastModifiedBy SystemDataLastModifiedByType ResourceGroupName
----                     ------------------- ------------------- ----------------------- ------------------------ ------------------------ ---------------------------- -----------------
losangeles
```

This command list all Azure Extended Zones under a subscription

### Example 2: Get an Azure Extended Zone by name
```powershell
Get-AzEdgeZonesExtendedZone -Name losangeles
```

```output
DisplayName                  : Los Angeles
Geography                    : usa
GeographyGroup               : US
HomeLocation                 : westus
Id                           : /subscriptions/2027ff61-4414-4aa3-bd20-170c46f69b19/providers/Microsoft.EdgeZones/extendedZones/losangeles
Latitude                     : 34.058414
Longitude                    : -118.23537
Name                         : losangeles
ProvisioningState            : Succeeded
RegionCategory               : Other
RegionType                   : Physical
RegionalDisplayName          : (US) Los Angeles
RegistrationState            : NotRegistered
ResourceGroupName            :
SystemDataCreatedAt          :
SystemDataCreatedBy          :
SystemDataCreatedByType      :
SystemDataLastModifiedAt     :
SystemDataLastModifiedBy     :
SystemDataLastModifiedByType :
Type                         : Microsoft.EdgeZones/extendedZones
```

This command gets an Azure Extended Zones by name

