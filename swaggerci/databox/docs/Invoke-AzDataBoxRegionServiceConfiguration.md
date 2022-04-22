---
external help file:
Module Name: Az.DataBox
online version: https://docs.microsoft.com/en-us/powershell/module/az.databox/invoke-azdataboxregionserviceconfiguration
schema: 2.0.0
---

# Invoke-AzDataBoxRegionServiceConfiguration

## SYNOPSIS
This API provides configuration details specific to given region/location at Subscription level.

## SYNTAX

### RegionExpanded (Default)
```
Invoke-AzDataBoxRegionServiceConfiguration -Location <String> [-SubscriptionId <String>]
 [-DatacenterAddressRequestSkuName <SkuName>] [-DatacenterAddressRequestStorageLocation <String>]
 [-ScheduleAvailabilityRequestCountry <String>] [-ScheduleAvailabilityRequestSkuName <SkuName>]
 [-ScheduleAvailabilityRequestStorageLocation <String>] [-TransportAvailabilityRequestSkuName <SkuName>]
 [-DefaultProfile <PSObject>] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### Region
```
Invoke-AzDataBoxRegionServiceConfiguration -Location <String>
 -RegionConfigurationRequest <IRegionConfigurationRequest> [-SubscriptionId <String>]
 [-DefaultProfile <PSObject>] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### Region1
```
Invoke-AzDataBoxRegionServiceConfiguration -Location <String> -ResourceGroupName <String>
 -RegionConfigurationRequest <IRegionConfigurationRequest> [-SubscriptionId <String>]
 [-DefaultProfile <PSObject>] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### RegionExpanded1
```
Invoke-AzDataBoxRegionServiceConfiguration -Location <String> -ResourceGroupName <String>
 [-SubscriptionId <String>] [-DatacenterAddressRequestSkuName <SkuName>]
 [-DatacenterAddressRequestStorageLocation <String>] [-ScheduleAvailabilityRequestCountry <String>]
 [-ScheduleAvailabilityRequestSkuName <SkuName>] [-ScheduleAvailabilityRequestStorageLocation <String>]
 [-TransportAvailabilityRequestSkuName <SkuName>] [-DefaultProfile <PSObject>] [-Confirm] [-WhatIf]
 [<CommonParameters>]
```

### RegionViaIdentity
```
Invoke-AzDataBoxRegionServiceConfiguration -InputObject <IDataBoxIdentity>
 -RegionConfigurationRequest <IRegionConfigurationRequest> [-DefaultProfile <PSObject>] [-Confirm] [-WhatIf]
 [<CommonParameters>]
```

### RegionViaIdentity1
```
Invoke-AzDataBoxRegionServiceConfiguration -InputObject <IDataBoxIdentity>
 -RegionConfigurationRequest <IRegionConfigurationRequest> [-DefaultProfile <PSObject>] [-Confirm] [-WhatIf]
 [<CommonParameters>]
```

### RegionViaIdentityExpanded
```
Invoke-AzDataBoxRegionServiceConfiguration -InputObject <IDataBoxIdentity>
 [-DatacenterAddressRequestSkuName <SkuName>] [-DatacenterAddressRequestStorageLocation <String>]
 [-ScheduleAvailabilityRequestCountry <String>] [-ScheduleAvailabilityRequestSkuName <SkuName>]
 [-ScheduleAvailabilityRequestStorageLocation <String>] [-TransportAvailabilityRequestSkuName <SkuName>]
 [-DefaultProfile <PSObject>] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### RegionViaIdentityExpanded1
```
Invoke-AzDataBoxRegionServiceConfiguration -InputObject <IDataBoxIdentity>
 [-DatacenterAddressRequestSkuName <SkuName>] [-DatacenterAddressRequestStorageLocation <String>]
 [-ScheduleAvailabilityRequestCountry <String>] [-ScheduleAvailabilityRequestSkuName <SkuName>]
 [-ScheduleAvailabilityRequestStorageLocation <String>] [-TransportAvailabilityRequestSkuName <SkuName>]
 [-DefaultProfile <PSObject>] [-Confirm] [-WhatIf] [<CommonParameters>]
```

## DESCRIPTION
This API provides configuration details specific to given region/location at Subscription level.

## EXAMPLES

### Example 1: {{ Add title here }}
```powershell
{{ Add code here }}
```

```output
{{ Add output here }}
```

{{ Add description here }}

### Example 2: {{ Add title here }}
```powershell
{{ Add code here }}
```

```output
{{ Add output here }}
```

{{ Add description here }}

## PARAMETERS

### -DatacenterAddressRequestSkuName
Sku Name for which the data center address requested.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.DataBox.Support.SkuName
Parameter Sets: RegionExpanded, RegionExpanded1, RegionViaIdentityExpanded, RegionViaIdentityExpanded1
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -DatacenterAddressRequestStorageLocation
Storage location.
For locations check: https://management.azure.com/subscriptions/SUBSCRIPTIONID/locationsapi-version=2018-01-01

```yaml
Type: System.String
Parameter Sets: RegionExpanded, RegionExpanded1, RegionViaIdentityExpanded, RegionViaIdentityExpanded1
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

### -InputObject
Identity Parameter
To construct, see NOTES section for INPUTOBJECT properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.DataBox.Models.IDataBoxIdentity
Parameter Sets: RegionViaIdentity, RegionViaIdentity1, RegionViaIdentityExpanded, RegionViaIdentityExpanded1
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -Location
The location of the resource

```yaml
Type: System.String
Parameter Sets: Region, Region1, RegionExpanded, RegionExpanded1
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -RegionConfigurationRequest
Request body to get the configuration for the region.
To construct, see NOTES section for REGIONCONFIGURATIONREQUEST properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.DataBox.Models.Api20211201.IRegionConfigurationRequest
Parameter Sets: Region, Region1, RegionViaIdentity, RegionViaIdentity1
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -ResourceGroupName
The Resource Group Name

```yaml
Type: System.String
Parameter Sets: Region1, RegionExpanded1
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ScheduleAvailabilityRequestCountry
Country in which storage location should be supported.

```yaml
Type: System.String
Parameter Sets: RegionExpanded, RegionExpanded1, RegionViaIdentityExpanded, RegionViaIdentityExpanded1
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ScheduleAvailabilityRequestSkuName
Sku Name for which the order is to be scheduled.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.DataBox.Support.SkuName
Parameter Sets: RegionExpanded, RegionExpanded1, RegionViaIdentityExpanded, RegionViaIdentityExpanded1
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ScheduleAvailabilityRequestStorageLocation
Location for data transfer.
For locations check: https://management.azure.com/subscriptions/SUBSCRIPTIONID/locationsapi-version=2018-01-01

```yaml
Type: System.String
Parameter Sets: RegionExpanded, RegionExpanded1, RegionViaIdentityExpanded, RegionViaIdentityExpanded1
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -SubscriptionId
The Subscription Id

```yaml
Type: System.String
Parameter Sets: Region, Region1, RegionExpanded, RegionExpanded1
Aliases:

Required: False
Position: Named
Default value: (Get-AzContext).Subscription.Id
Accept pipeline input: False
Accept wildcard characters: False
```

### -TransportAvailabilityRequestSkuName
Type of the device.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.DataBox.Support.SkuName
Parameter Sets: RegionExpanded, RegionExpanded1, RegionViaIdentityExpanded, RegionViaIdentityExpanded1
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

### Microsoft.Azure.PowerShell.Cmdlets.DataBox.Models.Api20211201.IRegionConfigurationRequest

### Microsoft.Azure.PowerShell.Cmdlets.DataBox.Models.IDataBoxIdentity

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.DataBox.Models.Api20211201.IRegionConfigurationResponse

## NOTES

ALIASES

COMPLEX PARAMETER PROPERTIES

To create the parameters described below, construct a hash table containing the appropriate properties. For information on hash tables, run Get-Help about_Hash_Tables.


INPUTOBJECT <IDataBoxIdentity>: Identity Parameter
  - `[Id <String>]`: Resource identity path
  - `[JobName <String>]`: The name of the job Resource within the specified resource group. job names must be between 3 and 24 characters in length and use any alphanumeric and underscore only
  - `[Location <String>]`: The location of the resource
  - `[ResourceGroupName <String>]`: The Resource Group Name
  - `[SubscriptionId <String>]`: The Subscription Id

REGIONCONFIGURATIONREQUEST <IRegionConfigurationRequest>: Request body to get the configuration for the region.
  - `[DatacenterAddressRequestSkuName <SkuName?>]`: Sku Name for which the data center address requested.
  - `[DatacenterAddressRequestStorageLocation <String>]`: Storage location. For locations check: https://management.azure.com/subscriptions/SUBSCRIPTIONID/locations?api-version=2018-01-01
  - `[ScheduleAvailabilityRequestCountry <String>]`: Country in which storage location should be supported.
  - `[ScheduleAvailabilityRequestSkuName <SkuName?>]`: Sku Name for which the order is to be scheduled.
  - `[ScheduleAvailabilityRequestStorageLocation <String>]`: Location for data transfer. For locations check: https://management.azure.com/subscriptions/SUBSCRIPTIONID/locations?api-version=2018-01-01
  - `[TransportAvailabilityRequestSkuName <SkuName?>]`: Type of the device.

## RELATED LINKS

