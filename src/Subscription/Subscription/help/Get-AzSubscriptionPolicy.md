---
external help file: Az.Subscription-help.xml
Module Name: Az.Subscription
online version: https://learn.microsoft.com/powershell/module/az.subscription/get-azsubscriptionpolicy
schema: 2.0.0
---

# Get-AzSubscriptionPolicy

## SYNOPSIS
Get the subscription tenant policy for the user's tenant.

## SYNTAX

```
Get-AzSubscriptionPolicy [-DefaultProfile <PSObject>] [<CommonParameters>]
```

## DESCRIPTION
Get the subscription tenant policy for the user's tenant.

## EXAMPLES

### Example 1: Get the subscription tenant policy for the user's tenant.
```powershell
Get-AzSubscriptionPolicy
```

```output
Name    PolicyId                             BlockSubscriptionsIntoTenant BlockSubscriptionsLeavingTenant
----    --------                             ---------------------------- -------------------------------
default XXXXXXXX-XXXX-XXXX-XXXX-XXXXXXXXXXXX False                        True
```

Get the subscription tenant policy for the user's tenant.

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

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see [about_CommonParameters](http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.Subscription.Models.Api20211001.IGetTenantPolicyResponse

## NOTES

## RELATED LINKS
