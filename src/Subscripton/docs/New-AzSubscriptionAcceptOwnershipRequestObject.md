---
external help file:
Module Name: Az.Subscription
online version: https://docs.microsoft.com/powershell/module/az.Subscription/new-AzSubscriptionAcceptOwnershipRequestObject
schema: 2.0.0
---

# New-AzSubscriptionAcceptOwnershipRequestObject

## SYNOPSIS
Create an in-memory object for AcceptOwnershipRequest.

## SYNTAX

```
New-AzSubscriptionAcceptOwnershipRequestObject [-DisplayName <String>] [-ManagementGroupId <String>]
 [-Tag <IAcceptOwnershipRequestPropertiesTags>] [<CommonParameters>]
```

## DESCRIPTION
Create an in-memory object for AcceptOwnershipRequest.

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

### -DisplayName
The friendly name of the subscription.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ManagementGroupId
Management group Id for the subscription.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Tag
Tags for the subscription.
To construct, see NOTES section for TAG properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Subscription.Models.Api20211001.IAcceptOwnershipRequestPropertiesTags
Parameter Sets: (All)
Aliases:

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

### Microsoft.Azure.PowerShell.Cmdlets.Subscription.Models.Api20211001.AcceptOwnershipRequest

## NOTES

ALIASES

COMPLEX PARAMETER PROPERTIES

To create the parameters described below, construct a hash table containing the appropriate properties. For information on hash tables, run Get-Help about_Hash_Tables.


`TAG <IAcceptOwnershipRequestPropertiesTags>`: Tags for the subscription.
  - `[(Any) <String>]`: This indicates any property can be added to this object.

## RELATED LINKS

