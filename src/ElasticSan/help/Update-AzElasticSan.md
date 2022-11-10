---
external help file:
Module Name: Az.ElasticSan
online version: https://docs.microsoft.com/powershell/module/az.elasticsan/update-azelasticsan
schema: 2.0.0
---

# Update-AzElasticSan

## SYNOPSIS
Update a Elastic San.

## SYNTAX

### UpdateExpanded (Default)
```
Update-AzElasticSan -Name <String> -ResourceGroupName <String> [-SubscriptionId <String>]
 [-BaseSizeTiB <Int64>] [-ExtendedCapacitySizeTiB <Int64>] [-Tag <Hashtable>] [-DefaultProfile <PSObject>]
 [-AsJob] [-NoWait] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### Update
```
Update-AzElasticSan -Name <String> -ResourceGroupName <String> -Parameter <IElasticSanUpdate>
 [-SubscriptionId <String>] [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-Confirm] [-WhatIf]
 [<CommonParameters>]
```

### UpdateViaIdentity
```
Update-AzElasticSan -InputObject <IElasticSanIdentity> -Parameter <IElasticSanUpdate>
 [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### UpdateViaIdentityExpanded
```
Update-AzElasticSan -InputObject <IElasticSanIdentity> [-BaseSizeTiB <Int64>]
 [-ExtendedCapacitySizeTiB <Int64>] [-Tag <Hashtable>] [-DefaultProfile <PSObject>] [-AsJob] [-NoWait]
 [-Confirm] [-WhatIf] [<CommonParameters>]
```

## DESCRIPTION
Update a Elastic San.

## EXAMPLES

### Example 1: Update an Elastic SAN
```powershell
$elasticSan = Update-AzElasticSan -ResourceGroupName myresourcegroup -Name myelasticsan -BaseSizeTib 64 -ExtendedCapacitySizeTib 128 -Tag @{"tag3" = "value3"}
```

```output
AvailabilityZone             : 
BaseSizeTiB                  : 64
ExtendedCapacitySizeTiB      : 128
Id                           : /subscriptions/xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx/resourceGroups/myresourcegroup/providers/Microsoft.ElasticSan/elasticSans/myelasticsan
Location                     : eastus
Name                         : myelasticsan
ProvisioningState            : Succeeded
SkuName                      : Premium_LRS
SkuTier                      : 
SystemDataCreatedAt          : 8/16/2022 4:59:54 AM
SystemDataCreatedBy          : yyyyyyyy-yyyy-yyyy-yyyy-yyyyyyyyyyyy
SystemDataCreatedByType      : Application
SystemDataLastModifiedAt     : 8/16/2022 4:59:54 AM
SystemDataLastModifiedBy     : yyyyyyyy-yyyy-yyyy-yyyy-yyyyyyyyyyyy
SystemDataLastModifiedByType : Application
Tag                          : Microsoft.Azure.PowerShell.Cmdlets.ElasticSan.Models.Api20211120Preview.ResourceTags
TotalIops                    : 320000
TotalMBps                    : 5120
TotalSizeTiB                 : 192
TotalVolumeSizeGiB           : 0
Type                         : Microsoft.ElasticSan/ElasticSans
VolumeGroupCount             : 0
```

This command updates the BaseSizeTib, ExtendedCapacitySizeTib, and Tag properties of an Elastic SAN.

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

### -BaseSizeTiB
Base size of the Elastic San appliance in TiB.

```yaml
Type: System.Int64
Parameter Sets: UpdateExpanded, UpdateViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -DefaultProfile
The credentials, account, tenant, and subscription used for communication with Azure.

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

```yaml
Type: System.Int64
Parameter Sets: UpdateExpanded, UpdateViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -InputObject
Identity Parameter
To construct, see NOTES section for INPUTOBJECT properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.ElasticSan.Models.IElasticSanIdentity
Parameter Sets: UpdateViaIdentity, UpdateViaIdentityExpanded
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
Parameter Sets: Update, UpdateExpanded
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

### -Parameter
Response for ElasticSan update request.
To construct, see NOTES section for PARAMETER properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.ElasticSan.Models.Api20211120Preview.IElasticSanUpdate
Parameter Sets: Update, UpdateViaIdentity
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -ResourceGroupName
The name of the resource group.
The name is case insensitive.

```yaml
Type: System.String
Parameter Sets: Update, UpdateExpanded
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
Type: System.String
Parameter Sets: Update, UpdateExpanded
Aliases:

Required: False
Position: Named
Default value: (Get-AzContext).Subscription.Id
Accept pipeline input: False
Accept wildcard characters: False
```

### -Tag
Update tags

```yaml
Type: System.Collections.Hashtable
Parameter Sets: UpdateExpanded, UpdateViaIdentityExpanded
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

### Microsoft.Azure.PowerShell.Cmdlets.ElasticSan.Models.Api20211120Preview.IElasticSanUpdate

### Microsoft.Azure.PowerShell.Cmdlets.ElasticSan.Models.IElasticSanIdentity

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.ElasticSan.Models.Api20211120Preview.IElasticSan

## NOTES

ALIASES

COMPLEX PARAMETER PROPERTIES

To create the parameters described below, construct a hash table containing the appropriate properties. For information on hash tables, run Get-Help about_Hash_Tables.


`INPUTOBJECT <IElasticSanIdentity>`: Identity Parameter
  - `[ElasticSanName <String>]`: The name of the ElasticSan.
  - `[Id <String>]`: Resource identity path
  - `[ResourceGroupName <String>]`: The name of the resource group. The name is case insensitive.
  - `[SubscriptionId <String>]`: The ID of the target subscription.
  - `[VolumeGroupName <String>]`: The name of the VolumeGroup.
  - `[VolumeName <String>]`: The name of the Volume.

`PARAMETER <IElasticSanUpdate>`: Response for ElasticSan update request.
  - `[BaseSizeTiB <Int64?>]`: Base size of the Elastic San appliance in TiB.
  - `[ExtendedCapacitySizeTiB <Int64?>]`: Extended size of the Elastic San appliance in TiB.
  - `[Tag <IElasticSanUpdateTags>]`: Update tags
    - `[(Any) <String>]`: This indicates any property can be added to this object.

## RELATED LINKS

