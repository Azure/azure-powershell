---
external help file:
Module Name: Az.Reservations
online version: https://learn.microsoft.com/powershell/module/az.reservations/get-azreservation
schema: 2.0.0
---

# Get-AzReservation

## SYNOPSIS
Get specific `Reservation` details.

## SYNTAX

### List1 (Default)
```
Get-AzReservation [-Filter <String>] [-Orderby <String>] [-SelectedState <String>] [-First <UInt64>]
 [-Skip <UInt64>] [-DefaultProfile <PSObject>] [<CommonParameters>]
```

### Get
```
Get-AzReservation -Id <String> -OrderId <String> [-Expand <String>] [-DefaultProfile <PSObject>]
 [<CommonParameters>]
```

### GetViaIdentity
```
Get-AzReservation -InputObject <IReservationsIdentity> [-Expand <String>] [-DefaultProfile <PSObject>]
 [<CommonParameters>]
```

### List
```
Get-AzReservation -OrderId <String> [-DefaultProfile <PSObject>] [<CommonParameters>]
```

## DESCRIPTION
Get specific `Reservation` details.

## EXAMPLES

### Example 1: Get the list of reservation orders in the current tenant
```powershell
Get-AzReservation
```

```output
Location   ReservationOrderId/ReservationId                                          Sku                           State     BenefitStartTime ExpiryDate            LastUpdatedDateTime SkuDescription
--------   --------------------------------                                          ---                           -----     ---------------- ----------            ------------------- --------------
centralus  a87c1742-0080-5b4d-b953-8531ad46fdc8/cad6fef7-ae86-4d47-91d0-67c897934bfe Standard_B1s                  Succeeded                  6/1/2024 12:00:00 AM
westeurope c5cf5c26-1920-4895-bf34-098ed1c69b92/6540137e-5a4f-4a14-bd17-3f2ea72b1ff4 premium_ssd_managed_disks_p30 Succeeded                  6/1/2022 12:00:00 AM
centralus  bd82bff8-4d29-9375-8194-ce0709fc1691/f2c3a058-b469-4529-88fa-1bae251c4a47 Standard_B1s                  Cancelled                  6/1/2024 12:00:00 AM
```

Get the list of reservation orders in the current tenant.
By design, some propeties do not have data due to the api response(e.g.
LastUpdatedDateTime and SkuDescription).
In this case please get the single reservation with command in example 2 to get the missing data.

Some data might be trucated due to the width of powershell view, appending this to the end of the command to show the truncated data: | ft -Wrap

### Example 2: Get the reservation details given ReservationOrderId and ReservationId
```powershell
Get-AzReservation -ReservationOrderId a87c1742-0080-5b4d-b953-8531ad46fdc8 -ReservationId cad6fef7-ae86-4d47-91d0-67c897934bfe
```

```output
Location  ReservationOrderId/ReservationId                                          Sku          State     BenefitStartTime    ExpiryDate           LastUpdatedDateTime SkuDescription
--------  --------------------------------                                          ---          -----     ----------------    ----------           ------------------- --------------
centralus a87c1742-0080-5b4d-b953-8531ad46fdc8/cad6fef7-ae86-4d47-91d0-67c897934bfe Standard_B1s Succeeded 6/1/2021 5:01:58 PM 6/1/2024 12:00:00 AM 6/1/2021 5:02:09 PM Reserved VM Instance, Standard_B1s, US Central, 3 Years
```

Get the details of a single reservation.
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
Supported value of this query is renewProperties

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

### -Filter
May be used to filter by reservation properties.
The filter supports 'eq', 'or', and 'and'.
It does not currently support 'ne', 'gt', 'le', 'ge', or 'not'.
Reservation properties include sku/name, properties/{appliedScopeType, archived, displayName, displayProvisioningState, effectiveDateTime, expiryDate, expiryDateTime, provisioningState, quantity, renew, reservedResourceType, term, userFriendlyAppliedScopeType, userFriendlyRenewState}

```yaml
Type: System.String
Parameter Sets: List1
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -First
Gets only the first 'n' objects.

```yaml
Type: System.UInt64
Parameter Sets: List1
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Id
Id of the reservation item

```yaml
Type: System.String
Parameter Sets: Get
Aliases: ReservationId

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

### -Orderby
May be used to sort order by reservation properties.

```yaml
Type: System.String
Parameter Sets: List1
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -OrderId
Order Id of the reservation

```yaml
Type: System.String
Parameter Sets: Get, List
Aliases: ReservationOrderId

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -SelectedState
The selected provisioning state

```yaml
Type: System.String
Parameter Sets: List1
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Skip
Ignores the first 'n' objects and then gets the remaining objects.

```yaml
Type: System.UInt64
Parameter Sets: List1
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

### Microsoft.Azure.PowerShell.Cmdlets.Reservations.Models.IReservationsIdentity

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.Reservations.Models.Api20221101.IReservationResponse

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

