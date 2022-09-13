---
external help file:
Module Name: Az.Subscription
online version: https://docs.microsoft.com/powershell/module/az.subscription/invoke-azsubscriptionacceptsubscriptionownershipstatus
schema: 2.0.0
---

# Invoke-AzSubscriptionAcceptSubscriptionOwnershipStatus

## SYNOPSIS
Accept subscription ownership status.

## SYNTAX

### Accept (Default)
```
Invoke-AzSubscriptionAcceptSubscriptionOwnershipStatus [-SubscriptionId <String>] [-DefaultProfile <PSObject>]
 [<CommonParameters>]
```

### AcceptViaIdentity
```
Invoke-AzSubscriptionAcceptSubscriptionOwnershipStatus -InputObject <ISubscriptionIdentity>
 [-DefaultProfile <PSObject>] [<CommonParameters>]
```

## DESCRIPTION
Accept subscription ownership status.

## EXAMPLES

### Example 1: {{ Add title here }}
```powershell
{{ Add code here }}
```

```output
{{ Add output here }}
```

{{ Add description here }}

### Example 2: {{ Add title here }}
```powershell
{{ Add code here }}
```

```output
{{ Add output here }}
```

{{ Add description here }}

## PARAMETERS

### -DefaultProfile
The credentials, account, tenant, and subscription used for communication with Azure.

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
Parameter Sets: AcceptViaIdentity
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
Type: System.String
Parameter Sets: Accept
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

