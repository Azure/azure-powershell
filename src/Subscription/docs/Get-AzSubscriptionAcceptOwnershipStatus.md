---
external help file:
Module Name: Az.Subscription
online version: https://learn.microsoft.com/powershell/module/az.subscription/get-azsubscriptionacceptownershipstatus
schema: 2.0.0
---

# Get-AzSubscriptionAcceptOwnershipStatus

## SYNOPSIS
Accept subscription ownership status.

## SYNTAX

### AcceptExpanded (Default)
```
Get-AzSubscriptionAcceptOwnershipStatus [-SubscriptionId <String[]>] [-DefaultProfile <PSObject>]
 [<CommonParameters>]
```

### AcceptViaIdentityExpanded
```
Get-AzSubscriptionAcceptOwnershipStatus -InputObject <ISubscriptionIdentity> [-DefaultProfile <PSObject>]
 [<CommonParameters>]
```

## DESCRIPTION
Accept subscription ownership status.

## EXAMPLES

### Example 1: Accept subscription ownership status.
```powershell
Get-AzSubscriptionAcceptOwnershipStatus  -SubscriptionId XXXXXXXX-XXXX-XXXX-XXXX-XXXXXXXXXXXX
```

```output
AcceptOwnershipState BillingOwner      DisplayName ProvisioningState SubscriptionId                       SubscriptionTenantId
-------------------- ------------      ----------- ----------------- --------------                       --------------------
Completed            xxxxxxxx@xxxx.com create18    Pending           XXXXXXXX-XXXX-XXXX-XXXX-XXXXXXXXXXXX XXXXXXXX-XXXX-XXXX-XXXX-XXXXXXXXXXXX
```

Accept subscription ownership status.

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

### -InputObject
Identity Parameter
To construct, see NOTES section for INPUTOBJECT properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Subscription.Models.ISubscriptionIdentity
Parameter Sets: AcceptViaIdentityExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -SubscriptionId
Subscription Id.

```yaml
Type: System.String[]
Parameter Sets: AcceptExpanded
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

### Microsoft.Azure.PowerShell.Cmdlets.Subscription.Models.ISubscriptionIdentity

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.Subscription.Models.Api20211001.IAcceptOwnershipStatusResponse

## NOTES

ALIASES

COMPLEX PARAMETER PROPERTIES

To create the parameters described below, construct a hash table containing the appropriate properties. For information on hash tables, run Get-Help about_Hash_Tables.


`INPUTOBJECT <ISubscriptionIdentity>`: Identity Parameter
  - `[AliasName <String>]`: AliasName is the name for the subscription creation request. Note that this is not the same as subscription name and this doesn’t have any other lifecycle need beyond the request for subscription creation.
  - `[BillingAccountId <String>]`: Billing Account Id.
  - `[Id <String>]`: Resource identity path
  - `[SubscriptionId <String>]`: Subscription Id.

## RELATED LINKS

