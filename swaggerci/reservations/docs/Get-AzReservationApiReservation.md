---
external help file:
Module Name: Az.ReservationApi
online version: https://docs.microsoft.com/en-us/powershell/module/az.reservationapi/get-azreservationapireservation
schema: 2.0.0
---

# Get-AzReservationApiReservation

## SYNOPSIS
Get specific `Reservation` details.

## SYNTAX

### List1 (Default)
```
Get-AzReservationApiReservation [-Filter <String>] [-Orderby <String>] [-RefreshSummary <String>]
 [-SelectedState <String>] [-Skiptoken <Single>] [-Take <Single>] [-DefaultProfile <PSObject>]
 [<CommonParameters>]
```

### Get
```
Get-AzReservationApiReservation -Id <String> -OrderId <String> [-Expand <String>] [-DefaultProfile <PSObject>]
 [<CommonParameters>]
```

### GetViaIdentity
```
Get-AzReservationApiReservation -InputObject <IReservationApiIdentity> [-Expand <String>]
 [-DefaultProfile <PSObject>] [<CommonParameters>]
```

### List
```
Get-AzReservationApiReservation -OrderId <String> [-DefaultProfile <PSObject>] [<CommonParameters>]
```

## DESCRIPTION
Get specific `Reservation` details.

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
Reservation properties include sku/name, properties/{appliedScopeType, archived, displayName, displayProvisioningState, effectiveDateTime, expiryDate, provisioningState, quantity, renew, reservedResourceType, term, userFriendlyAppliedScopeType, userFriendlyRenewState}

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

### -Id
Id of the Reservation Item

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
Type: Microsoft.Azure.PowerShell.Cmdlets.ReservationApi.Models.IReservationApiIdentity
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

### -RefreshSummary
To indicate whether to refresh the roll up counts of the reservations group by provisioning states

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

### -Skiptoken
The number of reservations to skip from the list before returning results

```yaml
Type: System.Single
Parameter Sets: List1
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Take
To number of reservations to return

```yaml
Type: System.Single
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

### Microsoft.Azure.PowerShell.Cmdlets.ReservationApi.Models.IReservationApiIdentity

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.ReservationApi.Models.Api20220301.IReservationResponse

## NOTES

ALIASES

COMPLEX PARAMETER PROPERTIES

To create the parameters described below, construct a hash table containing the appropriate properties. For information on hash tables, run Get-Help about_Hash_Tables.


INPUTOBJECT <IReservationApiIdentity>: Identity Parameter
  - `[Id <String>]`: Quota Request ID.
  - `[Id1 <String>]`: Resource identity path
  - `[Location <String>]`: Azure region.
  - `[ProviderId <String>]`: Azure resource provider ID.
  - `[ReservationId <String>]`: Id of the Reservation Item
  - `[ReservationOrderId <String>]`: Order Id of the reservation
  - `[ResourceName <String>]`: The resource name for a resource provider, such as SKU name for Microsoft.Compute, Sku or TotalLowPriorityCores for Microsoft.MachineLearningServices
  - `[SubscriptionId <String>]`: Id of the subscription

## RELATED LINKS

