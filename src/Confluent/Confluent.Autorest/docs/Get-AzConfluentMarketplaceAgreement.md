---
external help file:
Module Name: Az.Confluent
online version: https://learn.microsoft.com/powershell/module/az.confluent/get-azconfluentmarketplaceagreement
schema: 2.0.0
---

# Get-AzConfluentMarketplaceAgreement

## SYNOPSIS
List Confluent marketplace agreements in the subscription.

## SYNTAX

```
Get-AzConfluentMarketplaceAgreement [-SubscriptionId <String[]>] [-DefaultProfile <PSObject>]
 [<CommonParameters>]
```

## DESCRIPTION
List Confluent marketplace agreements in the subscription.

## EXAMPLES

### Example 1: List all confluent marketplace agreement under a subscription
```powershell
Get-AzConfluentMarketplaceAgreement
```

```output
Name        Type
----        ----
marketplace Microsoft.Confluent/agreements
confluent   Microsoft.Confluent/offertypes
```

This command lists all confluent marketplace agreement under a subscription.

## PARAMETERS

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

### -SubscriptionId
Microsoft Azure subscription id

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

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see [about_CommonParameters](http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.Confluent.Models.Api20200301.IConfluentAgreementResource

## NOTES

## RELATED LINKS

