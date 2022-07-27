---
external help file:
Module Name: Az.EdgeOrder
online version: https://docs.microsoft.com/powershell/module/az.edgeorder/get-azedgeorderconfiguration
schema: 2.0.0
---

# Get-AzEdgeOrderConfiguration

## SYNOPSIS
This method provides the list of configurations for the given product family, product line and product under subscription.

## SYNTAX

```
Get-AzEdgeOrderConfiguration -ConfigurationFilter <IConfigurationFilters[]> [-SubscriptionId <String[]>]
 [-DefaultProfile <PSObject>] [-Confirm] [-WhatIf] [<CommonParameters>]
```

## DESCRIPTION
This method provides the list of configurations for the given product family, product line and product under subscription.

## EXAMPLES

### Example 1: Get configuration details
```powershell
$configuration = Get-AzEdgeOrderConfiguration -SubscriptionId SubscriptionId -ConfigurationFilter @(@{"HierarchyInformation"=$HierarchyInformation; "FilterableProperty"= @($filterableProperty)})
$filterableProperty = New-AzEdgeOrderFilterablePropertyObject -Type "ShipToCountries" -SupportedValue @("US")
$HierarchyInformation=New-AzEdgeOrderHierarchyInformationObject -ProductFamilyName "azurestackedge" -ProductLineName "azurestackedge" -ProductName "azurestackedgegpu" -ConfigurationName "EdgeP_High"
$configuration = Get-AzEdgeOrderConfiguration -SubscriptionId SubscriptionId -ConfigurationFilter @(@{"HierarchyInformation"=$HierarchyInformation; "FilterableProperty"= @($filterableProperty)})
$configuration
```

```output
AvailabilityInformationAvailabilityStage     : Available
AvailabilityInformationDisabledReason        : None
AvailabilityInformationDisabledReasonMessage :
CostInformationBillingInfoUrl                : https://aka.ms/edgeHWcenter-pricinglink-custom
CostInformationBillingMeterDetail            : {RentalFee, ShippingFee}
DescriptionAttribute                         : {}
DescriptionKeyword                           : {GPU}
DescriptionLink                              : {}
DescriptionLongDescription                   :
DescriptionShortDescription                  :
DescriptionType                              : Base
DimensionDepth                               : 2
DimensionHeight                              : 15
DimensionLength                              : 50
DimensionLengthHeightUnit                    : IN
DimensionWeight                              : 50
DimensionWeightUnit                          : LBS
DimensionWidth                               : 5
DisplayName                                  : Azure Stack Edge Pro - 2 GPU
FilterableProperty                           : {Microsoft.Azure.PowerShell.Cmdlets.EdgeOrder.Models.Api20211201.FilterableProperty}
HierarchyInformation                         : Microsoft.Azure.PowerShell.Cmdlets.EdgeOrder.Models.Api20211201.HierarchyInformation
ImageInformation                             : {}
Specification                                : {Usable compute, Usable memory, Usable storage}
```

This command get insights of selected configuration.
Make sure you run registerProvider on Microsoft.EdgeOrder before running this command.

## PARAMETERS

### -ConfigurationFilter
Holds details about product hierarchy information and filterable property.
To construct, see NOTES section for CONFIGURATIONFILTER properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.EdgeOrder.Models.Api20211201.IConfigurationFilters[]
Parameter Sets: (All)
Aliases:

Required: True
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

### -SubscriptionId
The ID of the target subscription.

```yaml
Type: System.String[]
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: (Get-AzContext).Subscription.Id
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

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.EdgeOrder.Models.Api20211201.IConfiguration

## NOTES

ALIASES

COMPLEX PARAMETER PROPERTIES

To create the parameters described below, construct a hash table containing the appropriate properties. For information on hash tables, run Get-Help about_Hash_Tables.


CONFIGURATIONFILTER <IConfigurationFilters[]>: Holds details about product hierarchy information and filterable property.
  - `HierarchyInformation <IHierarchyInformation>`: Product hierarchy information
    - `[ConfigurationName <String>]`: Represents configuration name that uniquely identifies configuration
    - `[ProductFamilyName <String>]`: Represents product family name that uniquely identifies product family
    - `[ProductLineName <String>]`: Represents product line name that uniquely identifies product line
    - `[ProductName <String>]`: Represents product name that uniquely identifies product
  - `[FilterableProperty <IFilterableProperty[]>]`: Filters specific to product
    - `SupportedValue <String[]>`: Values to be filtered.
    - `Type <SupportedFilterTypes>`: Type of product filter.

CUSTOMERSUBSCRIPTIONDETAIL `<ICustomerSubscriptionDetails>`: Customer subscription properties. Clients can display available products to unregistered customers by explicitly passing subscription details
  - `QuotaId <String>`: Quota ID of a subscription
  - `[LocationPlacementId <String>]`: Location placement Id of a subscription
  - `[RegisteredFeature <ICustomerSubscriptionRegisteredFeatures[]>]`: List of registered feature flags for subscription
    - `[Name <String>]`: Name of subscription registered feature
    - `[State <String>]`: State of subscription registered feature

## RELATED LINKS

