---
external help file:
Module Name: Az.Reservations
online version: https://learn.microsoft.com/powershell/module/az.reservations/get-azreservationorderid
schema: 2.0.0
---

# Get-AzReservationOrderId

## SYNOPSIS
Get applicable `Reservation`s that are applied to this subscription or a resource group under this subscription.

## SYNTAX

### Get (Default)
```
Get-AzReservationOrderId [-SubscriptionId <String[]>] [-DefaultProfile <PSObject>] [<CommonParameters>]
```

### GetViaIdentity
```
Get-AzReservationOrderId -InputObject <IReservationsIdentity> [-DefaultProfile <PSObject>]
 [<CommonParameters>]
```

## DESCRIPTION
Get applicable `Reservation`s that are applied to this subscription or a resource group under this subscription.

## EXAMPLES

### Example 1: Get list of applicable ReservationOrder Ids.
```powershell
Get-AzReservationOrderId -SubscriptionId '10000000-aaaa-bbbb-cccc-100000000005'
```

```output
Id                         : /subscriptions/10000000-aaaa-bbbb-cccc-100000000005/providers/microsoft.capacity/AppliedReservations/default
Name                       : default
ReservationOrderIdNextLink : 
ReservationOrderIdValue    : {/providers/Microsoft.Capacity/reservationorders/7c6192be-7543-40c3-93e1-3d7f0b15203f, 
                             /providers/Microsoft.Capacity/reservationorders/aa6c95fe-f25b-4f2e-864f-3860ef5d5bd0, 
                             /providers/Microsoft.Capacity/reservationorders/d9e3935c-288e-4ef5-81a0-55201c1a6a67, 
                             /providers/Microsoft.Capacity/reservationorders/b60911ea-d990-4795-818a-b7396abdb13b…}
ResourceGroupName          : 
Type                       : Microsoft.Capacity/AppliedReservations
```

Get Ids of applicable ReservationOrders that can be applied to this subscription.

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
Type: Microsoft.Azure.PowerShell.Cmdlets.Reservations.Models.IReservationsIdentity
Parameter Sets: GetViaIdentity
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -SubscriptionId
Id of the subscription

```yaml
Type: System.String[]
Parameter Sets: Get
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

### Microsoft.Azure.PowerShell.Cmdlets.Reservations.Models.IReservationsIdentity

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.Reservations.Models.Api20221101.IAppliedReservations

## NOTES

ALIASES

COMPLEX PARAMETER PROPERTIES

To create the parameters described below, construct a hash table containing the appropriate properties. For information on hash tables, run Get-Help about_Hash_Tables.


`INPUTOBJECT <IReservationsIdentity>`: Identity Parameter
  - `[Id <String>]`: Resource identity path
  - `[ReservationId <String>]`: Id of the reservation item
  - `[ReservationOrderId <String>]`: Order Id of the reservation
  - `[SubscriptionId <String>]`: Id of the subscription

## RELATED LINKS

