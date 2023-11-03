---
external help file:
Module Name: Az.Subscription
online version: https://learn.microsoft.com/powershell/module/az.subscription/update-azsubscriptionpolicy
schema: 2.0.0
---

# Update-AzSubscriptionPolicy

## SYNOPSIS
Create or Update Subscription tenant policy for user's tenant.

## SYNTAX

```
Update-AzSubscriptionPolicy [-BlockSubscriptionsIntoTenant] [-BlockSubscriptionsLeavingTenant]
 [-ExemptedPrincipal <String[]>] [-DefaultProfile <PSObject>] [-Confirm] [-WhatIf] [<CommonParameters>]
```

## DESCRIPTION
Create or Update Subscription tenant policy for user's tenant.

## EXAMPLES

### Example 1: Create or Update Subscription tenant policy for user's tenant.
```powershell
Update-AzSubscriptionPolicy -BlockSubscriptionsIntoTenant:$true -BlockSubscriptionsLeavingTenant:$false -ExemptedPrincipal XXXXXXXX-XXXX-XXXX-XXXX-XXXXXXXXXXXX
```

```output
Name    PolicyId                             BlockSubscriptionsIntoTenant BlockSubscriptionsLeavingTenant
----    --------                             ---------------------------- -------------------------------
default XXXXXXXX-XXXX-XXXX-XXXX-XXXXXXXXXXXX True                         False
```

Create or Update Subscription tenant policy for user's tenant.

## PARAMETERS

### -BlockSubscriptionsIntoTenant
Blocks the entering of subscriptions into user's tenant.

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -BlockSubscriptionsLeavingTenant
Blocks the leaving of subscriptions from user's tenant.

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: (All)
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

### -ExemptedPrincipal
List of user objectIds that are exempted from the set subscription tenant policies for the user's tenant.

```yaml
Type: System.String[]
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
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

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.Subscription.Models.Api20211001.IGetTenantPolicyResponse

## NOTES

ALIASES

## RELATED LINKS

