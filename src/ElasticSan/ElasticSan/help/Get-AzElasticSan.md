---
external help file: Az.ElasticSan-help.xml
Module Name: Az.ElasticSan
online version: https://learn.microsoft.com/powershell/module/az.elasticsan/get-azelasticsan
schema: 2.0.0
---

# Get-AzElasticSan

## SYNOPSIS
Get either a list of Elastic SANs from a subscription or a resource group, or get a single Elastic SAN.

## SYNTAX

### List (Default)
```
Get-AzElasticSan [-SubscriptionId <String[]>] [-DefaultProfile <PSObject>]
 [<CommonParameters>]
```

### Get
```
Get-AzElasticSan -Name <String> -ResourceGroupName <String> [-SubscriptionId <String[]>]
 [-DefaultProfile <PSObject>] [<CommonParameters>]
```

### List1
```
Get-AzElasticSan -ResourceGroupName <String> [-SubscriptionId <String[]>] [-DefaultProfile <PSObject>]
 [<CommonParameters>]
```

### GetViaIdentity
```
Get-AzElasticSan -InputObject <IElasticSanIdentity> [-DefaultProfile <PSObject>]
 [<CommonParameters>]
```

## DESCRIPTION
Get either a list of Elastic SANs from a subscription or a resource group, or get a single Elastic SAN.

## EXAMPLES

### Example 1: Get all Elastic SANs in a subscription
```powershell
Get-AzElasticSan
```

```output
AutoScalePolicyEnforcement   :
AvailabilityZone             :
BaseSizeTiB                  : 1
CapacityUnitScaleUpLimitTiB  :
ExtendedCapacitySizeTiB      : 6
Id                           : /subscriptions/00000000-0000-0000-0000-000000000000/resourceGroups/myresourcegroup/providers/Microsoft.ElasticSan/elasticSans/myelasticsan1
IncreaseCapacityUnitByTiB    :
Location                     : eastus
Name                         : myelasticsan1
PrivateEndpointConnection    :
ProvisioningState            : Succeeded
PublicNetworkAccess          :
ResourceGroupName            : myresourcegroup
SkuName                      : Premium_LRS
SkuTier                      :
SystemDataCreatedAt          : 9/29/2024 2:34:21 AM
SystemDataCreatedBy          : example@microsoft.com
SystemDataCreatedByType      : User
SystemDataLastModifiedAt     : 9/29/2024 2:34:21 AM
SystemDataLastModifiedBy     : example@microsoft.com
SystemDataLastModifiedByType : User
Tag                          : {
                                 "tag1": "value1",
                                 "tag2": "value2"
                               }
TotalIops                    : 5000
TotalMBps                    : 200
TotalSizeTiB                 : 7
TotalVolumeSizeGiB           : 120
Type                         : Microsoft.ElasticSan/ElasticSans
UnusedSizeTiB                :
VolumeGroupCount             : 4
AutoScalePolicyEnforcement   :
AvailabilityZone             :
BaseSizeTiB                  : 1
CapacityUnitScaleUpLimitTiB  :
ExtendedCapacitySizeTiB      : 6
Id                           : /subscriptions/00000000-0000-0000-0000-000000000000/resourceGroups/myresourcegroup/providers/Microsoft.ElasticSan/elasticSans/myelasticsan2
IncreaseCapacityUnitByTiB    :
Location                     : eastus
Name                         : myelasticsan2
PrivateEndpointConnection    :
ProvisioningState            : Succeeded
PublicNetworkAccess          :
ResourceGroupName            : myresourcegroup
SkuName                      : Premium_LRS
SkuTier                      :
SystemDataCreatedAt          : 9/29/2024 2:34:48 AM
SystemDataCreatedBy          : example@microsoft.com
SystemDataCreatedByType      : User
SystemDataLastModifiedAt     : 9/29/2024 2:34:48 AM
SystemDataLastModifiedBy     : example@microsoft.com
SystemDataLastModifiedByType : User
Tag                          : {
                                 "tag1": "value1",
                                 "tag2": "value2"
                               }
TotalIops                    : 5000
TotalMBps                    : 200
TotalSizeTiB                 : 7
TotalVolumeSizeGiB           : 0
Type                         : Microsoft.ElasticSan/ElasticSans
UnusedSizeTiB                :
VolumeGroupCount             : 0
```

This command gets all the Elastic SANs in a subscription.

### Example 2: Get all Elastic Sans in a resource group
```powershell
Get-AzElasticSan -ResourceGroupName myresourcegroup
```

```output
AutoScalePolicyEnforcement   :
AvailabilityZone             :
BaseSizeTiB                  : 1
CapacityUnitScaleUpLimitTiB  :
ExtendedCapacitySizeTiB      : 6
Id                           : /subscriptions/00000000-0000-0000-0000-000000000000/resourceGroups/myresourcegroup/providers/Microsoft.ElasticSan/elasticSans/myelasticsan1
IncreaseCapacityUnitByTiB    :
Location                     : eastus
Name                         : myelasticsan1
PrivateEndpointConnection    :
ProvisioningState            : Succeeded
PublicNetworkAccess          :
ResourceGroupName            : myresourcegroup
SkuName                      : Premium_LRS
SkuTier                      :
SystemDataCreatedAt          : 9/29/2024 2:34:21 AM
SystemDataCreatedBy          : example@microsoft.com
SystemDataCreatedByType      : User
SystemDataLastModifiedAt     : 9/29/2024 2:34:21 AM
SystemDataLastModifiedBy     : example@microsoft.com
SystemDataLastModifiedByType : User
Tag                          : {
                                 "tag1": "value1",
                                 "tag2": "value2"
                               }
TotalIops                    : 5000
TotalMBps                    : 200
TotalSizeTiB                 : 7
TotalVolumeSizeGiB           : 120
Type                         : Microsoft.ElasticSan/ElasticSans
UnusedSizeTiB                :
VolumeGroupCount             : 4
AutoScalePolicyEnforcement   :
AvailabilityZone             :
BaseSizeTiB                  : 1
CapacityUnitScaleUpLimitTiB  :
ExtendedCapacitySizeTiB      : 6
Id                           : /subscriptions/00000000-0000-0000-0000-000000000000/resourceGroups/myresourcegroup/providers/Microsoft.ElasticSan/elasticSans/myelasticsan2
IncreaseCapacityUnitByTiB    :
Location                     : eastus
Name                         : myelasticsan2
PrivateEndpointConnection    :
ProvisioningState            : Succeeded
PublicNetworkAccess          :
ResourceGroupName            : myresourcegroup
SkuName                      : Premium_LRS
SkuTier                      :
SystemDataCreatedAt          : 9/29/2024 2:34:48 AM
SystemDataCreatedBy          : example@microsoft.com
SystemDataCreatedByType      : User
SystemDataLastModifiedAt     : 9/29/2024 2:34:48 AM
SystemDataLastModifiedBy     : example@microsoft.com
SystemDataLastModifiedByType : User
Tag                          : {
                                 "tag1": "value1",
                                 "tag2": "value2"
                               }
TotalIops                    : 5000
TotalMBps                    : 200
TotalSizeTiB                 : 7
TotalVolumeSizeGiB           : 0
Type                         : Microsoft.ElasticSan/ElasticSans
UnusedSizeTiB                :
VolumeGroupCount             : 0
```

This command gets all Elastic SANs in a resource group.

### Example 3: Get a specific Elastic SAN
```powershell
Get-AzElasticSan -ResourceGroupName myresourcegroup -Name myelasticsan
```

```output
AutoScalePolicyEnforcement   :
AvailabilityZone             :
BaseSizeTiB                  : 1
CapacityUnitScaleUpLimitTiB  :
ExtendedCapacitySizeTiB      : 6
Id                           : /subscriptions/00000000-0000-0000-0000-000000000000/resourceGroups/myresourcegroup/providers/Microsoft.ElasticSan/elasticSans/myelasticsan
IncreaseCapacityUnitByTiB    :
Location                     : eastus2
Name                         : myelasticsan
PrivateEndpointConnection    :
ProvisioningState            : Succeeded
PublicNetworkAccess          :
ResourceGroupName            : myresourcegroup
SkuName                      : Premium_LRS
SkuTier                      :
SystemDataCreatedAt          : 9/29/2024 2:34:21 AM
SystemDataCreatedBy          : example@microsoft.com
SystemDataCreatedByType      : User
SystemDataLastModifiedAt     : 9/29/2024 2:34:21 AM
SystemDataLastModifiedBy     : example@microsoft.com
SystemDataLastModifiedByType : User
Tag                          : {
                                 "tag1": "value1",
                                 "tag2": "value2"
                               }
TotalIops                    : 5000
TotalMBps                    : 200
TotalSizeTiB                 : 7
TotalVolumeSizeGiB           : 120
Type                         : Microsoft.ElasticSan/ElasticSans
UnusedSizeTiB                :
VolumeGroupCount             : 4
```

This command gets a specific Elastic SAN.

## PARAMETERS

### -DefaultProfile
The DefaultProfile parameter is not functional.
Use the SubscriptionId parameter when available if executing the cmdlet against a different subscription.

```yaml
Type: System.Management.Automation.PSObject
Parameter Sets: (All)
Aliases: AzureRMContext, AzureCredential

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -InputObject
Identity Parameter

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.ElasticSan.Models.IElasticSanIdentity
Parameter Sets: GetViaIdentity
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -Name
The name of the ElasticSan.

```yaml
Type: System.String
Parameter Sets: Get
Aliases: ElasticSanName

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ResourceGroupName
The name of the resource group.
The name is case insensitive.

```yaml
Type: System.String
Parameter Sets: Get, List1
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -SubscriptionId
The ID of the target subscription.

```yaml
Type: System.String[]
Parameter Sets: List, Get, List1
Aliases:

Required: False
Position: Named
Default value: (Get-AzContext).Subscription.Id
Accept pipeline input: False
Accept wildcard characters: False
```

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see [about_CommonParameters](http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

### Microsoft.Azure.PowerShell.Cmdlets.ElasticSan.Models.IElasticSanIdentity

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.ElasticSan.Models.IElasticSan

## NOTES

## RELATED LINKS
