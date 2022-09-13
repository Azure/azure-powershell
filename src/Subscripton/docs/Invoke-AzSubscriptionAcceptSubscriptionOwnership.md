---
external help file:
Module Name: Az.Subscription
online version: https://docs.microsoft.com/powershell/module/az.subscription/invoke-azsubscriptionacceptsubscriptionownership
schema: 2.0.0
---

# Invoke-AzSubscriptionAcceptSubscriptionOwnership

## SYNOPSIS
Accept subscription ownership.

## SYNTAX

### AcceptExpanded (Default)
```
Invoke-AzSubscriptionAcceptSubscriptionOwnership [-SubscriptionId <String>] [-DisplayName <String>]
 [-ManagementGroupId <String>] [-Tag <Hashtable>] [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-Confirm]
 [-WhatIf] [<CommonParameters>]
```

### Accept
```
Invoke-AzSubscriptionAcceptSubscriptionOwnership -Body <IAcceptOwnershipRequest> [-SubscriptionId <String>]
 [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### AcceptViaIdentity
```
Invoke-AzSubscriptionAcceptSubscriptionOwnership -InputObject <ISubscriptionIdentity>
 -Body <IAcceptOwnershipRequest> [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-Confirm] [-WhatIf]
 [<CommonParameters>]
```

### AcceptViaIdentityExpanded
```
Invoke-AzSubscriptionAcceptSubscriptionOwnership -InputObject <ISubscriptionIdentity> [-DisplayName <String>]
 [-ManagementGroupId <String>] [-Tag <Hashtable>] [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-Confirm]
 [-WhatIf] [<CommonParameters>]
```

## DESCRIPTION
Accept subscription ownership.

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

### -AsJob
Run the command as a job

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

### -Body
The parameters required to accept subscription ownership.
To construct, see NOTES section for BODY properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Subscription.Models.Api20211001.IAcceptOwnershipRequest
Parameter Sets: Accept, AcceptViaIdentity
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

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

### -DisplayName
The friendly name of the subscription.

```yaml
Type: System.String
Parameter Sets: AcceptExpanded, AcceptViaIdentityExpanded
Aliases:

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
Parameter Sets: AcceptViaIdentity, AcceptViaIdentityExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -ManagementGroupId
Management group Id for the subscription.

```yaml
Type: System.String
Parameter Sets: AcceptExpanded, AcceptViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -NoWait
Run the command asynchronously

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

### -SubscriptionId
Subscription Id.

```yaml
Type: System.String
Parameter Sets: Accept, AcceptExpanded
Aliases:

Required: False
Position: Named
Default value: (Get-AzContext).Subscription.Id
Accept pipeline input: False
Accept wildcard characters: False
```

### -Tag
Tags for the subscription

```yaml
Type: System.Collections.Hashtable
Parameter Sets: AcceptExpanded, AcceptViaIdentityExpanded
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

### Microsoft.Azure.PowerShell.Cmdlets.Subscription.Models.Api20211001.IAcceptOwnershipRequest

### Microsoft.Azure.PowerShell.Cmdlets.Subscription.Models.ISubscriptionIdentity

## OUTPUTS

### System.Boolean

## NOTES

ALIASES

COMPLEX PARAMETER PROPERTIES

To create the parameters described below, construct a hash table containing the appropriate properties. For information on hash tables, run Get-Help about_Hash_Tables.


`BODY <IAcceptOwnershipRequest>`: The parameters required to accept subscription ownership.
  - `[DisplayName <String>]`: The friendly name of the subscription.
  - `[ManagementGroupId <String>]`: Management group Id for the subscription.
  - `[Tag <IAcceptOwnershipRequestPropertiesTags>]`: Tags for the subscription
    - `[(Any) <String>]`: This indicates any property can be added to this object.

`INPUTOBJECT <ISubscriptionIdentity>`: Identity Parameter
  - `[AliasName <String>]`: AliasName is the name for the subscription creation request. Note that this is not the same as subscription name and this doesn’t have any other lifecycle need beyond the request for subscription creation.
  - `[BillingAccountId <String>]`: Billing Account Id.
  - `[Id <String>]`: Resource identity path
  - `[SubscriptionId <String>]`: Subscription Id.

## RELATED LINKS

