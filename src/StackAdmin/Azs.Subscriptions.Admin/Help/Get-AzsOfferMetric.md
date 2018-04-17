---
external help file: Azs.Subscriptions.Admin-help.xml
Module Name: Azs.Subscriptions.Admin
online version: 
schema: 2.0.0
---

# Get-AzsOfferMetric

## SYNOPSIS
Get the offer metrics.

## SYNTAX

```
Get-AzsOfferMetric [-OfferName] <String> [-ResourceGroupName] <String> [<CommonParameters>]
```

## DESCRIPTION
Get the offer metrics.

## EXAMPLES

### -------------------------- EXAMPLE 1 --------------------------
```
Get-AzsOfferMetric -ResourceGroupName rg1 -Offer offername1 | fl *
```

Value    : {Microsoft.AzureStack.Management.Subscriptions.Admin.Models.Metric, Microsoft.AzureStack.Management.Subscriptions.Admin.Models.Metric}
NextLink :

Get the offer metrics.

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
{{Fill ResourceGroupName Description}}

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

### Microsoft.AzureStack.Management.Subscriptions.Admin.Models.Metric

## NOTES

## RELATED LINKS

