---
external help file:
Module Name: Az.Reservations
online version: https://docs.microsoft.com/powershell/module/az.reservations/move-azreservationdirectory
schema: 2.0.0
---

# Move-AzReservationDirectory

## SYNOPSIS
Change directory (tenant) of `ReservationOrder` and all `Reservation` under it to specified tenant id

## SYNTAX

### ChangeExpanded (Default)
```
Move-AzReservationDirectory -ReservationOrderId <String> [-DestinationTenantId <String>]
 [-DefaultProfile <PSObject>] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### Change
```
Move-AzReservationDirectory -ReservationOrderId <String> -Body <IChangeDirectoryRequest>
 [-DefaultProfile <PSObject>] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### ChangeViaIdentity
```
Move-AzReservationDirectory -InputObject <IReservationsIdentity> -Body <IChangeDirectoryRequest>
 [-DefaultProfile <PSObject>] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### ChangeViaIdentityExpanded
```
Move-AzReservationDirectory -InputObject <IReservationsIdentity> [-DestinationTenantId <String>]
 [-DefaultProfile <PSObject>] [-Confirm] [-WhatIf] [<CommonParameters>]
```

## DESCRIPTION
Change directory (tenant) of `ReservationOrder` and all `Reservation` under it to specified tenant id

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

### -Body
.
To construct, see NOTES section for BODY properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Reservations.Models.Api20220301.IChangeDirectoryRequest
Parameter Sets: Change, ChangeViaIdentity
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

### -DestinationTenantId
Tenant id GUID that reservation order is to be transferred to

```yaml
Type: System.String
Parameter Sets: ChangeExpanded, ChangeViaIdentityExpanded
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
Type: Microsoft.Azure.PowerShell.Cmdlets.Reservations.Models.IReservationsIdentity
Parameter Sets: ChangeViaIdentity, ChangeViaIdentityExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -ReservationOrderId
Order Id of the reservation

```yaml
Type: System.String
Parameter Sets: Change, ChangeExpanded
Aliases:

Required: True
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

### Microsoft.Azure.PowerShell.Cmdlets.Reservations.Models.Api20220301.IChangeDirectoryRequest

### Microsoft.Azure.PowerShell.Cmdlets.Reservations.Models.IReservationsIdentity

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.Reservations.Models.Api20220301.IChangeDirectoryResponse

## NOTES

ALIASES

COMPLEX PARAMETER PROPERTIES

To create the parameters described below, construct a hash table containing the appropriate properties. For information on hash tables, run Get-Help about_Hash_Tables.


BODY <IChangeDirectoryRequest>: .
  - `[DestinationTenantId <String>]`: Tenant id GUID that reservation order is to be transferred to

INPUTOBJECT <IReservationsIdentity>: Identity Parameter
  - `[Id <String>]`: Resource identity path
  - `[ReservationId <String>]`: Id of the Reservation Item
  - `[ReservationOrderId <String>]`: Order Id of the reservation
  - `[SubscriptionId <String>]`: Id of the subscription

## RELATED LINKS

