---
external help file: Az.CloudHealth-help.xml
Module Name: Az.CloudHealth
online version: https://learn.microsoft.com/powershell/module/Az.CloudHealth/new-azmonitorhealthmodeldiscoveryrulepropertiesobject
schema: 2.0.0
---

# New-AzMonitorHealthModelDiscoveryRulePropertiesObject

## SYNOPSIS
Create an in-memory object for DiscoveryRuleProperties.

## SYNTAX

```
New-AzMonitorHealthModelDiscoveryRulePropertiesObject -AddRecommendedSignal <String>
 -AuthenticationSetting <String> -DiscoverRelationship <String> -Specification <IDiscoveryRuleSpecification>
 [-AddResourceHealthSignal <String>] [-DisplayName <String>] [<CommonParameters>]
```

## DESCRIPTION
Create an in-memory object for DiscoveryRuleProperties.

## EXAMPLES

### Example 1: Build discovery rule properties
```powershell
# Build a discovery rule property object for use with New- or Update-AzMonitorHealthModelDiscoveryRule
$specification = New-AzMonitorHealthModelResourceGraphQuerySpecificationObject -ResourceGraphQuery "resources | where type =~ 'microsoft.compute/virtualmachines' | project id"
New-AzMonitorHealthModelDiscoveryRulePropertiesObject -AuthenticationSetting default-auth -AddRecommendedSignal Enabled -AddResourceHealthSignal Enabled -DiscoverRelationship Enabled -DisplayName 'Discover virtual machines' -Specification $specification
```

Creates the property object to pass to New-AzMonitorHealthModelDiscoveryRule.

## PARAMETERS

### -AddRecommendedSignal
Whether to add all recommended signals to the discovered entities.

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

### -AddResourceHealthSignal
Whether to automatically add a signal for the Azure resource's availability state from Azure Resource Health to the discovered entities.
Defaults to Enabled: discovery rules updated via this API version without setting this field will begin emitting a Resource Health availability signal.
Pass Disabled to preserve pre-2026-05-01-preview behavior.

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

### -AuthenticationSetting
Reference to the name of the authentication setting which is used for querying Azure Resource Graph.
The same authentication setting will also be assigned to any discovered entities.

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

### -DiscoverRelationship
Whether to create relationships between the discovered entities based on a set of built-in rules.
These relationships cannot be manually deleted.

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

### -DisplayName
Display name.

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

### -Specification
Specification of the discovery rule defining how entities are discovered.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.CloudHealth.Models.IDiscoveryRuleSpecification
Parameter Sets: (All)
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see [about_CommonParameters](http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.CloudHealth.Models.DiscoveryRuleProperties

## NOTES

## RELATED LINKS

