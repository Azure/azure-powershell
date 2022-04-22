---
external help file:
Module Name: Az.EdgeOrder
online version: https://docs.microsoft.com/en-us/powershell/module/az.edgeorder/get-azedgeorderconfiguration
schema: 2.0.0
---

# Get-AzEdgeOrderConfiguration

## SYNOPSIS
This method provides the list of configurations for the given product family, product line and product under subscription.

## SYNTAX

### List (Default)
```
Get-AzEdgeOrderConfiguration -ConfigurationsRequest <IConfigurationsRequest> [-SubscriptionId <String[]>]
 [-SkipToken <String>] [-DefaultProfile <PSObject>] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### ListExpanded
```
Get-AzEdgeOrderConfiguration -ConfigurationFilter <IConfigurationFilters[]> [-SubscriptionId <String[]>]
 [-SkipToken <String>] [-CustomerSubscriptionDetailLocationPlacementId <String>]
 [-CustomerSubscriptionDetailQuotaId <String>]
 [-CustomerSubscriptionDetailRegisteredFeature <ICustomerSubscriptionRegisteredFeatures[]>]
 [-DefaultProfile <PSObject>] [-Confirm] [-WhatIf] [<CommonParameters>]
```

## DESCRIPTION
This method provides the list of configurations for the given product family, product line and product under subscription.

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

### -ConfigurationFilter
Holds details about product hierarchy information and filterable property.
To construct, see NOTES section for CONFIGURATIONFILTER properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.EdgeOrder.Models.Api20211201.IConfigurationFilters[]
Parameter Sets: ListExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ConfigurationsRequest
Configuration request object.
To construct, see NOTES section for CONFIGURATIONSREQUEST properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.EdgeOrder.Models.Api20211201.IConfigurationsRequest
Parameter Sets: List
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -CustomerSubscriptionDetailLocationPlacementId
Location placement Id of a subscription

```yaml
Type: System.String
Parameter Sets: ListExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -CustomerSubscriptionDetailQuotaId
Quota ID of a subscription

```yaml
Type: System.String
Parameter Sets: ListExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -CustomerSubscriptionDetailRegisteredFeature
List of registered feature flags for subscription
To construct, see NOTES section for CUSTOMERSUBSCRIPTIONDETAILREGISTEREDFEATURE properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.EdgeOrder.Models.Api20211201.ICustomerSubscriptionRegisteredFeatures[]
Parameter Sets: ListExpanded
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

### -SkipToken
$skipToken is supported on list of configurations, which provides the next page in the list of configurations.

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

### Microsoft.Azure.PowerShell.Cmdlets.EdgeOrder.Models.Api20211201.IConfigurationsRequest

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.EdgeOrder.Models.Api20211201.IConfiguration

## NOTES

ALIASES

COMPLEX PARAMETER PROPERTIES

To create the parameters described below, construct a hash table containing the appropriate properties. For information on hash tables, run Get-Help about_Hash_Tables.


CONFIGURATIONFILTER <IConfigurationFilters[]>: Holds details about product hierarchy information and filterable property.
  - `[FilterableProperty <IFilterableProperty[]>]`: Filters specific to product
    - `SupportedValue <String[]>`: Values to be filtered.
    - `Type <SupportedFilterTypes>`: Type of product filter.
  - `[HierarchyInformationConfigurationName <String>]`: Represents configuration name that uniquely identifies configuration
  - `[HierarchyInformationProductFamilyName <String>]`: Represents product family name that uniquely identifies product family
  - `[HierarchyInformationProductLineName <String>]`: Represents product line name that uniquely identifies product line
  - `[HierarchyInformationProductName <String>]`: Represents product name that uniquely identifies product

CONFIGURATIONSREQUEST <IConfigurationsRequest>: Configuration request object.
  - `ConfigurationFilter <IConfigurationFilters[]>`: Holds details about product hierarchy information and filterable property.
    - `[FilterableProperty <IFilterableProperty[]>]`: Filters specific to product
      - `SupportedValue <String[]>`: Values to be filtered.
      - `Type <SupportedFilterTypes>`: Type of product filter.
    - `[HierarchyInformationConfigurationName <String>]`: Represents configuration name that uniquely identifies configuration
    - `[HierarchyInformationProductFamilyName <String>]`: Represents product family name that uniquely identifies product family
    - `[HierarchyInformationProductLineName <String>]`: Represents product line name that uniquely identifies product line
    - `[HierarchyInformationProductName <String>]`: Represents product name that uniquely identifies product
  - `[CustomerSubscriptionDetailLocationPlacementId <String>]`: Location placement Id of a subscription
  - `[CustomerSubscriptionDetailQuotaId <String>]`: Quota ID of a subscription
  - `[CustomerSubscriptionDetailRegisteredFeature <ICustomerSubscriptionRegisteredFeatures[]>]`: List of registered feature flags for subscription
    - `[Name <String>]`: Name of subscription registered feature
    - `[State <String>]`: State of subscription registered feature

CUSTOMERSUBSCRIPTIONDETAILREGISTEREDFEATURE <ICustomerSubscriptionRegisteredFeatures[]>: List of registered feature flags for subscription
  - `[Name <String>]`: Name of subscription registered feature
  - `[State <String>]`: State of subscription registered feature

## RELATED LINKS

