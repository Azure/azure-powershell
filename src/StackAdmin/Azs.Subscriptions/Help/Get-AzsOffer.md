---
external help file: Azs.Subscriptions-help.xml
Module Name: Azs.Subscriptions
online version: 
schema: 2.0.0
---

# Get-AzsOffer

## SYNOPSIS
Get the list of public offers.

## SYNTAX

```
Get-AzsOffer [[-Skip] <Int32>] [[-Top] <Int32>] [<CommonParameters>]
```

## DESCRIPTION
Get the list of public offers.

## EXAMPLES

### -------------------------- EXAMPLE 1 --------------------------
```
Get-AzsOffer | fl
```

DisplayName : offer1
Description : Basic service offering
Name        : offer1
Id          : /delegatedProviders/default/offers/offer1
...

Get the list of public offers.

## PARAMETERS

### -Skip
Skip the first N items as specified by the parameter value.

```yaml
Type: Int32
Parameter Sets: (All)
Aliases: 

Required: False
Position: 1
Default value: -1
Accept pipeline input: False
Accept wildcard characters: False
```

### -Top
Return the top N items as specified by the parameter value.
Applies after the -Skip parameter.

```yaml
Type: Int32
Parameter Sets: (All)
Aliases: 

Required: False
Position: 2
Default value: -1
Accept pipeline input: False
Accept wildcard characters: False
```

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see about_CommonParameters (http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

## OUTPUTS

### Microsoft.AzureStack.Management.Subscriptions.Models.Offer

## NOTES

## RELATED LINKS

