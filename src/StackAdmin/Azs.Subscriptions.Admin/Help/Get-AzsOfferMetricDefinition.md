---
external help file: Azs.Subscriptions.Admin-help.xml
Module Name: Azs.Subscriptions.Admin
online version: 
schema: 2.0.0
---

# Get-AzsOfferMetricDefinition

## SYNOPSIS
Get the offer metric definitions.

## SYNTAX

```
Get-AzsOfferMetricDefinition [-OfferName] <String> [-ResourceGroupName] <String> [<CommonParameters>]
```

## DESCRIPTION
Get the offer metric definitions.

## EXAMPLES

### -------------------------- EXAMPLE 1 --------------------------
```
Get-AzsOfferMetricDefinition -ResourceGroupName rg1 -OfferName offername1
```

Get the offer metric definitions.

## PARAMETERS

### -OfferName
Name of an offer.

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

