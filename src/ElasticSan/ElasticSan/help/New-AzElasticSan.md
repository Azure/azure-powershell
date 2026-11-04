---
external help file:
Module Name: Az.ElasticSan
online version: https://learn.microsoft.com/powershell/module/az.elasticsan/new-azelasticsan
schema: 2.0.0
---

# New-AzElasticSan

## SYNOPSIS
Create ElasticSan.

## SYNTAX

### CreateExpanded (Default)
```
New-AzElasticSan -Name <String> -ResourceGroupName <String> -Location <String> -SkuName <String>
 [-SubscriptionId <String>] [-AutoScalePolicyEnforcement <String>] [-AvailabilityZone <String[]>]
 [-BaseSizeTiB <Int64>] [-CapacityUnitScaleUpLimitTiB <Int64>] [-ExtendedCapacitySizeTiB <Int64>]
 [-IncreaseCapacityUnitByTiB <Int64>] [-PublicNetworkAccess <String>] [-SkuTier <String>] [-Tag <Hashtable>]
 [-TotalIops <Int64>] [-TotalMBps <Int64>] [-TotalSizeTiB <Int64>] [-UnusedSizeTiB <Int64>]
 [-Version <String>] [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### CreateViaIdentityExpanded
```
New-AzElasticSan -InputObject <IElasticSanIdentity> -Location <String> -SkuName <String>
 [-AutoScalePolicyEnforcement <String>] [-AvailabilityZone <String[]>] [-BaseSizeTiB <Int64>]
 [-CapacityUnitScaleUpLimitTiB <Int64>] [-ExtendedCapacitySizeTiB <Int64>]
 [-IncreaseCapacityUnitByTiB <Int64>] [-PublicNetworkAccess <String>] [-SkuTier <String>] [-Tag <Hashtable>]
 [-TotalIops <Int64>] [-TotalMBps <Int64>] [-TotalSizeTiB <Int64>] [-UnusedSizeTiB <Int64>]
 [-Version <String>] [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-Confirm] [-WhatIf] [<CommonParameters>]
```

## DESCRIPTION
Create ElasticSan.
For V2, omitted autoscale settings default to Enabled, an increase of 1 TiB and an unused-capacity threshold of 1 TiB. If CapacityUnitScaleUpLimitTiB is omitted, the command calls Get-AzElasticSanSkuList for the target subscription and Location, selects SkuName, and uses the smaller of five times TotalSizeTiB and elasticSanMaxTotalCapacityTiB. The command fails before creating the SAN if this lookup fails or does not provide an unambiguous positive capacity limit. Explicit autoscale values are preserved, except Disabled is rejected for V2. V1 behavior is unchanged.

## EXAMPLES

### Example 1: Create an Elastic SAN
```powershell
New-AzElasticSan -ResourceGroupName myresourcegroup -Name myelasticsan -BaseSizeTib 1 -ExtendedCapacitySizeTib 6 -Location eastus -SkuName 'Premium_LRS' -AvailabilityZone 1 -Tag @{tag1="value1";tag2="value2"} -AutoScalePolicyEnforcement Enabled -CapacityUnitScaleUpLimitTiB 30 -IncreaseCapacityUnitByTiB 2 -UnusedSizeTiB 6
```

```output
AutoScalePolicyEnforcement   : Enabled
AvailabilityZone             : {1}
BaseSizeTiB                  : 1
CapacityUnitScaleUpLimitTiB  : 30
ExtendedCapacitySizeTiB      : 6
Id                           : /subscriptions/00000000-0000-0000-0000-000000000000/resourceGroups/myresourcegroup/providers/Microsoft.ElasticSan/elasticSans/myelasticsan
IncreaseCapacityUnitByTiB    : 2 
Location                     : eastus2euap
Name                         : myelasticsan
PrivateEndpointConnection    :
ProvisioningState            : Succeeded
PublicNetworkAccess          :
ResourceGroupName            : myresourcegroup
SkuName                      : Premium_LRS
SkuTier                      :
SystemDataCreatedAt          : 10/29/2025 3:07:36 AM
SystemDataCreatedBy          : example@microsoft.com
SystemDataCreatedByType      : User
SystemDataLastModifiedAt     : 10/29/2025 3:07:36 AM
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
UnusedSizeTiB                : 6 
VolumeGroupCount             : 0
```

This command creates an Elastic SAN.

### Example 2: Create an Elastic SAN with default base size and extended capacity size
```powershell
New-AzElasticSan -ResourceGroupName myresourcegroup -Name myelasticsan -Location eastus -SkuName 'Premium_LRS' -Tag @{tag1="value1";tag2="value2"}
```

```output
AutoScalePolicyEnforcement   :
AvailabilityZone             : {1}
BaseSizeTiB                  : 20
CapacityUnitScaleUpLimitTiB  :
ExtendedCapacitySizeTiB      : 0
Id                           : /subscriptions/00000000-0000-0000-0000-000000000000/resourceGroups/myresourcegroup/providers/Microsoft.ElasticSan/elasticSans/myelasticsan
IncreaseCapacityUnitByTiB    :
Location                     : eastus2euap
Name                         : myelasticsan
PrivateEndpointConnection    :
ProvisioningState            : Succeeded
PublicNetworkAccess          :
ResourceGroupName            : myresourcegroup
SkuName                      : Premium_LRS
SkuTier                      :
SystemDataCreatedAt          : 10/29/2025 6:00:04 AM
SystemDataCreatedBy          : example@microsoft.com
SystemDataCreatedByType      : User
SystemDataLastModifiedAt     : 10/29/2025 6:00:04 AM
SystemDataLastModifiedBy     : example@microsoft.com
SystemDataLastModifiedByType : User
Tag                          : {
                               }
TotalIops                    : 100000
TotalMBps                    : 4000
TotalSizeTiB                 : 20
TotalVolumeSizeGiB           : 0
Type                         : Microsoft.ElasticSan/ElasticSans
UnusedSizeTiB                :
VolumeGroupCount             : 0
```

This command creates an Elastic SAN.

### Example 3: Create a V2 Elastic SAN
```powershell
New-AzElasticSan -ResourceGroupName myresourcegroup -Name myelasticsanv2 -Location eastus -SkuName 'ElasticSAN_LRS' -Version V2 -TotalSizeTiB 20 -TotalIops 100000 -TotalMBps 4000
```

This command creates a V2 Elastic SAN with independently specified total capacity, IOPS and throughput.
V1 base and extended capacity defaults are not added to the V2 request.

## PARAMETERS

### -AsJob
Run the command as a job

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -AutoScalePolicyEnforcement
Enable or Disable scale up setting on Elastic San Appliance.
Defaults to Enabled for V2. Disabled is not supported when Version is V2.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -AvailabilityZone
Logical zone for Elastic San resource; example: ["1"].

```yaml
Type: System.String[]
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -BaseSizeTiB
Base size of the Elastic San appliance in TiB.
Defaults to 20 for V1.

```yaml
Type: System.Int64
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -CapacityUnitScaleUpLimitTiB
Maximum scale up size on Elastic San appliance in TiB.
For V2, defaults to the smaller of five times TotalSizeTiB and the regional maximum total capacity for SkuName.
When omitted for V2, Get-AzElasticSanSkuList is called for the target subscription and Location.

```yaml
Type: System.Int64
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

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

### -ExtendedCapacitySizeTiB
Extended size of the Elastic San appliance in TiB.
Defaults to 0 for V1.

```yaml
Type: System.Int64
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -IncreaseCapacityUnitByTiB
Unit to increase Capacity Unit on Elastic San appliance in TiB.
Defaults to 1 for V2.

```yaml
Type: System.Int64
Parameter Sets: (All)
Aliases:

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
Parameter Sets: CreateViaIdentityExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -Location
The geo-location where the resource lives

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Name
The name of the ElasticSan.

```yaml
Type: System.String
Parameter Sets: CreateExpanded
Aliases: ElasticSanName

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -NoWait
Run the command asynchronously

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -PublicNetworkAccess
Allow or disallow public network access to ElasticSan.
Value is optional but if passed in, must be 'Enabled' or 'Disabled'.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: False
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
Parameter Sets: CreateExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -SkuName
The sku name.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -SkuTier
The sku tier.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -SubscriptionId
The ID of the target subscription.

```yaml
Type: System.String
Parameter Sets: CreateExpanded
Aliases:

Required: False
Position: Named
Default value: (Get-AzContext).Subscription.Id
Accept pipeline input: False
Accept wildcard characters: False
```

### -Tag
Resource tags.

```yaml
Type: System.Collections.Hashtable
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -TotalIops
Total provisioned IOPS of the Elastic San appliance.
Required for V2; read-only for V1.

```yaml
Type: System.Int64
Parameter Sets: (All)
Aliases: TotalIop

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -TotalMBps
Total provisioned throughput of the Elastic San appliance in MBps.
Required for V2; read-only for V1.

```yaml
Type: System.Int64
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -TotalSizeTiB
Total size of the Elastic San appliance in TiB.
Required for V2; read-only for V1.

```yaml
Type: System.Int64
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -UnusedSizeTiB
Unused size on Elastic San appliance in TiB.
Defaults to 1 for V2.

```yaml
Type: System.Int64
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Version
Elastic San appliance version.
Defaults to V1 if not specified.
V2 requires TotalSizeTiB, TotalIops and TotalMBps; V1 capacity defaults are not added for V2.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Confirm
Prompts you for confirmation before running the cmdlet.

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: (All)
Aliases: cf

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -WhatIf
Shows what would happen if the cmdlet runs.
The cmdlet is not run.

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: (All)
Aliases: wi

Required: False
Position: Named
Default value: None
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
