---
external help file: Azs.Subscriptions.Admin-help.xml
Module Name: Azs.Subscriptions.Admin
online version: 
schema: 2.0.0
---

# Get-AzsPlanMetricDefinition

## SYNOPSIS
Get the list of plan metric definitions.

## SYNTAX

```
Get-AzsPlanMetricDefinition [-PlanName] <String> [-ResourceGroupName] <String> [<CommonParameters>]
```

## DESCRIPTION
Get the list of plan metric definitions.

## EXAMPLES

### -------------------------- EXAMPLE 1 --------------------------
```
Get-AzsPlanMetricDefinition -ResourceGroupName rg1 -PlanName plan1
```

Get a plan's metric definitions.

## PARAMETERS

### -PlanName
Name of the plan.

```yaml
Type: String
Parameter Sets: (All)
Aliases: 

Required: True
Position: 1
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ResourceGroupName
The resource group the resource is located under.

```yaml
Type: String
Parameter Sets: (All)
Aliases: 

Required: True
Position: 2
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see about_CommonParameters (http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

## OUTPUTS

### Microsoft.AzureStack.Management.Subscriptions.Admin.Models.MetricDefinition

## NOTES

## RELATED LINKS

