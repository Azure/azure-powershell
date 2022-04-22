---
Module Name: Az.ReservationApi
Module Guid: 49413f34-f87e-44fd-ba06-d0c9e92cc16c
Download Help Link: https://docs.microsoft.com/en-us/powershell/module/az.reservationapi
Help Version: 1.0.0.0
Locale: en-US
---

# Az.ReservationApi Module
## Description
Microsoft Azure PowerShell: ReservationApi cmdlets

## Az.ReservationApi Cmdlets
### [Get-AzReservationApiAppliedReservationList](Get-AzReservationApiAppliedReservationList.md)
Get applicable `Reservation`s that are applied to this subscription or a resource group under this subscription.

### [Get-AzReservationApiCatalog](Get-AzReservationApiCatalog.md)
Get the regions and skus that are available for RI purchase for the specified Azure subscription.

### [Get-AzReservationApiQuota](Get-AzReservationApiQuota.md)
Get the current quota (service limit) and usage of a resource.
You can use the response from the GET operation to submit quota update request.

### [Get-AzReservationApiQuotaRequestStatus](Get-AzReservationApiQuotaRequestStatus.md)
For the specified Azure region (location), get the details and status of the quota request by the quota request ID for the resources of the resource provider.
The PUT request for the quota (service limit) returns a response with the requestId parameter.

### [Get-AzReservationApiReservation](Get-AzReservationApiReservation.md)
Get specific `Reservation` details.

### [Get-AzReservationApiReservationOrder](Get-AzReservationApiReservationOrder.md)
Get the details of the `ReservationOrder`.

### [Get-AzReservationApiReservationRevision](Get-AzReservationApiReservationRevision.md)
List of all the revisions for the `Reservation`.

### [Invoke-AzReservationApiAvailableReservationScope](Invoke-AzReservationApiAvailableReservationScope.md)
Get Available Scopes for `Reservation`.\n

### [Invoke-AzReservationApiCalculateExchange](Invoke-AzReservationApiCalculateExchange.md)
Calculates price for exchanging `Reservations` if there are no policy errors.\n

### [Invoke-AzReservationApiCalculateReservationOrder](Invoke-AzReservationApiCalculateReservationOrder.md)
Calculate price for placing a `ReservationOrder`.

### [Invoke-AzReservationApiExchange](Invoke-AzReservationApiExchange.md)
Returns one or more `Reservations` in exchange for one or more `Reservation` purchases.\n

### [Invoke-AzReservationApiPurchaseReservationOrder](Invoke-AzReservationApiPurchaseReservationOrder.md)
Purchase `ReservationOrder` and create resource under the specified URI.

### [Merge-AzReservationApiReservation](Merge-AzReservationApiReservation.md)
Merge the specified `Reservation`s into a new `Reservation`.
The two `Reservation`s being merged must have same properties.

### [New-AzReservationApiQuota](New-AzReservationApiQuota.md)
Create or update the quota (service limits) of a resource to the requested value.\n Steps:\n\r  1.
Make the Get request to get the quota information for specific resource.\n\r  2.
To increase the quota, update the limit field in the response from Get request to new value.\n\r  3.
Submit the JSON to the quota request API to update the quota.\r\n  The Create quota request may be constructed as follows.
The PUT operation can be used to update the quota.

### [Rename-AzReservationApiReservationOrderDirectory](Rename-AzReservationApiReservationOrderDirectory.md)
Change directory (tenant) of `ReservationOrder` and all `Reservation` under it to specified tenant id

### [Split-AzReservationApiReservation](Split-AzReservationApiReservation.md)
Split a `Reservation` into two `Reservation`s with specified quantity distribution.

### [Update-AzReservationApiQuota](Update-AzReservationApiQuota.md)
Update the quota (service limits) of this resource to the requested value.\n\r  • To get the quota information for specific resource, send a GET request.\n\r  • To increase the quota, update the limit field from the GET response to a new value.\n\r  • To update the quota value, submit the JSON response to the quota request API to update the quota.\r\n  • To update the quota.
use the PATCH operation.

### [Update-AzReservationApiReservation](Update-AzReservationApiReservation.md)
Updates the applied scopes of the `Reservation`.

