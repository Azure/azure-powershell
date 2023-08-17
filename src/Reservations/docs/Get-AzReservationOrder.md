---
external help file:
Module Name: Az.Reservations
online version: https://learn.microsoft.com/powershell/module/az.reservations/get-azreservationorder
schema: 2.0.0
---

# Get-AzReservationOrder

## SYNOPSIS
Get the details of the `ReservationOrder`.

## SYNTAX

### List (Default)
```
Get-AzReservationOrder [-DefaultProfile <PSObject>] [<CommonParameters>]
```

### Get
```
Get-AzReservationOrder -Id <String> [-Expand <String>] [-DefaultProfile <PSObject>] [<CommonParameters>]
```

### GetViaIdentity
```
Get-AzReservationOrder -InputObject <IReservationsIdentity> [-Expand <String>] [-DefaultProfile <PSObject>]
 [<CommonParameters>]
```

## DESCRIPTION
Get the details of the `ReservationOrder`.

## EXAMPLES

### Example 1: Get the list of reservation orders in the current tenant
```powershell
Get-AzReservationOrder
```

```output
ReservationOrderId                   DisplayName                                          Term State     Quantity Reservations
------------------                   -----------                                          ---- -----     -------- ------------
179de21b-90ec-4fe4-9423-f804b856dfee VM_RI_08-20-2021_15-47                               P3Y  Succeeded 1        {{…
0de8d259-d48v-4db2-8fd9-ae4dd2bd2227 VM_RI_04-19-2021_13-48                               P3Y  Cancelled 4        {{…
02ffwsb1-4369-4m8s-b118-12efbfddd3fc VM_RI_04-19-2021_12-48                               P3Y  Succeeded 1        {{…
06629f91-b216-4d6f-80cd-fa91c8ba61b8 VM_RI_04-19-2021_19-48                               P3Y  Succeeded 1        {{…
```

Get the list of reservation orders in the current tenant.
Some data might be trucated due to the width of powershell view, appending this to the end of the command to show the truncated data: | ft -Wrap

### Example 2: Get the reservation order in the current tenant, given reservation order Id
```powershell
Get-AzReservationOrder -ReservationOrderId 179de21b-90ec-4fe4-9423-f804b856dfee
```

```output
ReservationOrderId                   DisplayName            Term State     Quantity Reservations
------------------                   -----------            ---- -----     -------- ------------
179ef21b-90ec-4fe4-9423-f794b856dfee VM_RI_08-20-2021_15-47 P3Y  Succeeded 1        {{…
```

Get the reservation order in the current tenant, given reservation order Id.
Some data might be trucated due to the width of powershell view, appending this to the end of the command to show the truncated data: | ft -Wrap

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

### -Expand
May be used to expand the planInformation.

```yaml
Type: System.String
Parameter Sets: Get, GetViaIdentity
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Id
Order Id of the reservation

```yaml
Type: System.String
Parameter Sets: Get
Aliases: ReservationOrderId, ReservationId

Required: True
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

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see [about_CommonParameters](http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

### Microsoft.Azure.PowerShell.Cmdlets.Reservations.Models.IReservationsIdentity

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.Reservations.Models.Api20221101.IReservationOrderResponse

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

