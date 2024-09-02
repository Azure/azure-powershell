---
Module Name: Az.Reservations
Module Guid: 59d3f19f-af05-4d96-a9a8-ff647983b57f
Download Help Link: https://learn.microsoft.com/powershell/module/az.reservations
Help Version: 1.0.0.0
Locale: en-US
---

# Az.Reservations Module
## Description
Microsoft Azure PowerShell: Reservations cmdlets

## Az.Reservations Cmdlets
### [Get-AzReservation](Get-AzReservation.md)
Get specific `Reservation` details.

### [Get-AzReservationAvailableScope](Get-AzReservationAvailableScope.md)
Check whether the scopes from request is valid for `Reservation`.\n

### [Get-AzReservationCatalog](Get-AzReservationCatalog.md)
Get the regions and skus that are available for RI purchase for the specified Azure subscription.

### [Get-AzReservationHistory](Get-AzReservationHistory.md)
List of all the revisions for the `Reservation`.

### [Get-AzReservationOrder](Get-AzReservationOrder.md)
Get the details of the `ReservationOrder`.

### [Get-AzReservationOrderId](Get-AzReservationOrderId.md)
Get applicable `Reservation`s that are applied to this subscription or a resource group under this subscription.

### [Get-AzReservationQuote](Get-AzReservationQuote.md)
Calculate price for placing a `ReservationOrder`.

### [Invoke-AzReservationArchiveReservation](Invoke-AzReservationArchiveReservation.md)
Archiving a `Reservation` moves it to `Archived` state.

### [Invoke-AzReservationCalculateExchange](Invoke-AzReservationCalculateExchange.md)
Calculates price for exchanging `Reservations` if there are no policy errors.\n

### [Invoke-AzReservationCalculateRefund](Invoke-AzReservationCalculateRefund.md)
Calculate price for returning `Reservations` if there are no policy errors.\n

### [Invoke-AzReservationExchange](Invoke-AzReservationExchange.md)
Returns one or more `Reservations` in exchange for one or more `Reservation` purchases.\n

### [Invoke-AzReservationReturn](Invoke-AzReservationReturn.md)
Return a Reservation.

### [Invoke-AzReservationUnarchiveReservation](Invoke-AzReservationUnarchiveReservation.md)
Restores a `Reservation` to the state it was before archiving.\n

### [Merge-AzReservation](Merge-AzReservation.md)
Merge two reservations into one reservation within the same reservation order.

### [Move-AzReservationDirectory](Move-AzReservationDirectory.md)
Change directory (tenant) of `ReservationOrder` and all `Reservation` under it to specified tenant id

### [New-AzReservation](New-AzReservation.md)
Purchase `ReservationOrder` and create resource under the specified URI.

### [Split-AzReservation](Split-AzReservation.md)
Split a Reservation order.

### [Update-AzReservation](Update-AzReservation.md)
Updates the applied scopes of the `Reservation`.

