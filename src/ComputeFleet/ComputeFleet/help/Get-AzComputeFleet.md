---
external help file: Az.ComputeFleet-help.xml
Module Name: Az.ComputeFleet
online version: https://learn.microsoft.com/powershell/module/az.computefleet/get-azcomputefleetmarketplaceagreement
schema: 2.0.0
---

# Get-AzComputeFleetMarketplaceAgreement

## SYNOPSIS
List ComputeFleet marketplace agreements in the subscription.

## SYNTAX

```
Get-AzComputeFleetMarketplaceAgreement [-SubscriptionId <String[]>] [-DefaultProfile <PSObject>]
 [<CommonParameters>]
```

## DESCRIPTION
List ComputeFleet marketplace agreements in the subscription.

## EXAMPLES

### Example 1: List all computefleet marketplace agreement under a subscription
```powershell
Get-AzComputeFleetMarketplaceAgreement
```

```output
Name        Type
----        ----
marketplace Microsoft.ComputeFleet/agreements
computefleet   Microsoft.ComputeFleet/offertypes
```

This command lists all computefleet marketplace agreement under a subscription.

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

### Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Module.Api20241101.IComputeFleetAgreementResource

## NOTES

## RELATED LINKS
