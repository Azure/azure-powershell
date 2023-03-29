---
external help file:
Module Name: Az.EdgeOrder
online version: https://learn.microsoft.com/powershell/module/az.edgeorder/get-azedgeorderproductandconfiguration
schema: 2.0.0
---

# Get-AzEdgeOrderProductAndConfiguration

## SYNOPSIS
List configurations for the given product family, product line and product for the given subscription.

## SYNTAX

### ListExpanded (Default)
```
Get-AzEdgeOrderProductAndConfiguration [-SubscriptionId <String[]>] [-SkipToken <String>]
 [-ChildConfigurationFilterChildConfigurationType <ChildConfigurationType[]>]
 [-ChildConfigurationFilterHierarchyInformation <IHierarchyInformation[]>]
 [-ConfigurationFilterFilterableProperty <IFilterableProperty[]>]
 [-CustomerSubscriptionDetailLocationPlacementId <String>] [-CustomerSubscriptionDetailQuotaId <String>]
 [-CustomerSubscriptionDetailRegisteredFeature <ICustomerSubscriptionRegisteredFeatures[]>]
 [-HierarchyInformationConfigurationName <String>] [-HierarchyInformationProductFamilyName <String>]
 [-HierarchyInformationProductLineName <String>] [-HierarchyInformationProductName <String>]
 [-DefaultProfile <PSObject>] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### List
```
Get-AzEdgeOrderProductAndConfiguration -ConfigurationsRequest <IConfigurationsRequest>
 [-SubscriptionId <String[]>] [-SkipToken <String>] [-DefaultProfile <PSObject>] [-Confirm] [-WhatIf]
 [<CommonParameters>]
```

## DESCRIPTION
List configurations for the given product family, product line and product for the given subscription.

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

### -ChildConfigurationFilterChildConfigurationType
Filter to fetch all child configurations belonging to the given list of configuration types.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.EdgeOrder.Support.ChildConfigurationType[]
Parameter Sets: ListExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ChildConfigurationFilterHierarchyInformation
The list of child configuration hierarchy customer wants to filter for the given configuration.
To construct, see NOTES section for CHILDCONFIGURATIONFILTERHIERARCHYINFORMATION properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.EdgeOrder.Models.Api20220501Preview.IHierarchyInformation[]
Parameter Sets: ListExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ConfigurationFilterFilterableProperty
Filters specific to product.
To construct, see NOTES section for CONFIGURATIONFILTERFILTERABLEPROPERTY properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.EdgeOrder.Models.Api20220501Preview.IFilterableProperty[]
Parameter Sets: ListExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ConfigurationsRequest
Configuration request object.
To construct, see NOTES section for CONFIGURATIONSREQUEST properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.EdgeOrder.Models.Api20220501Preview.IConfigurationsRequest
Parameter Sets: List
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -CustomerSubscriptionDetailLocationPlacementId
Location placement Id of a subscription.

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
Quota ID of a subscription.

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
List of registered feature flags for subscription.
To construct, see NOTES section for CUSTOMERSUBSCRIPTIONDETAILREGISTEREDFEATURE properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.EdgeOrder.Models.Api20220501Preview.ICustomerSubscriptionRegisteredFeatures[]
Parameter Sets: ListExpanded
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

### -HierarchyInformationConfigurationName
Represents configuration name that uniquely identifies configuration.

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

### -HierarchyInformationProductFamilyName
Represents product family name that uniquely identifies product family.

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

### -HierarchyInformationProductLineName
Represents product line name that uniquely identifies product line.

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

### -HierarchyInformationProductName
Represents product name that uniquely identifies product.

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

### Microsoft.Azure.PowerShell.Cmdlets.EdgeOrder.Models.Api20220501Preview.IConfigurationsRequest

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.EdgeOrder.Models.Api20220501Preview.IConfiguration

## NOTES

ALIASES

COMPLEX PARAMETER PROPERTIES

To create the parameters described below, construct a hash table containing the appropriate properties. For information on hash tables, run Get-Help about_Hash_Tables.


`CHILDCONFIGURATIONFILTERHIERARCHYINFORMATION <IHierarchyInformation[]>`: The list of child configuration hierarchy customer wants to filter for the given configuration.
  - `[ConfigurationName <String>]`: Represents configuration name that uniquely identifies configuration.
  - `[ProductFamilyName <String>]`: Represents product family name that uniquely identifies product family.
  - `[ProductLineName <String>]`: Represents product line name that uniquely identifies product line.
  - `[ProductName <String>]`: Represents product name that uniquely identifies product.

`CONFIGURATIONFILTERFILTERABLEPROPERTY <IFilterableProperty[]>`: Filters specific to product.
  - `SupportedValue <String[]>`: Values to be filtered.
  - `Type <SupportedFilterTypes>`: Type of product filter.

`CONFIGURATIONSREQUEST <IConfigurationsRequest>`: Configuration request object.
  - `[ChildConfigurationFilterChildConfigurationType <ChildConfigurationType[]>]`: Filter to fetch all child configurations belonging to the given list of configuration types.
  - `[ChildConfigurationFilterHierarchyInformation <IHierarchyInformation[]>]`: The list of child configuration hierarchy customer wants to filter for the given configuration.
    - `[ConfigurationName <String>]`: Represents configuration name that uniquely identifies configuration.
    - `[ProductFamilyName <String>]`: Represents product family name that uniquely identifies product family.
    - `[ProductLineName <String>]`: Represents product line name that uniquely identifies product line.
    - `[ProductName <String>]`: Represents product name that uniquely identifies product.
  - `[ConfigurationFilterFilterableProperty <IFilterableProperty[]>]`: Filters specific to product.
    - `SupportedValue <String[]>`: Values to be filtered.
    - `Type <SupportedFilterTypes>`: Type of product filter.
  - `[CustomerSubscriptionDetailLocationPlacementId <String>]`: Location placement Id of a subscription.
  - `[CustomerSubscriptionDetailQuotaId <String>]`: Quota ID of a subscription.
  - `[CustomerSubscriptionDetailRegisteredFeature <ICustomerSubscriptionRegisteredFeatures[]>]`: List of registered feature flags for subscription.
    - `[Name <String>]`: Name of subscription registered feature.
    - `[State <String>]`: State of subscription registered feature.
  - `[HierarchyInformationConfigurationName <String>]`: Represents configuration name that uniquely identifies configuration.
  - `[HierarchyInformationProductFamilyName <String>]`: Represents product family name that uniquely identifies product family.
  - `[HierarchyInformationProductLineName <String>]`: Represents product line name that uniquely identifies product line.
  - `[HierarchyInformationProductName <String>]`: Represents product name that uniquely identifies product.

`CUSTOMERSUBSCRIPTIONDETAILREGISTEREDFEATURE <ICustomerSubscriptionRegisteredFeatures[]>`: List of registered feature flags for subscription.
  - `[Name <String>]`: Name of subscription registered feature.
  - `[State <String>]`: State of subscription registered feature.

## RELATED LINKS

