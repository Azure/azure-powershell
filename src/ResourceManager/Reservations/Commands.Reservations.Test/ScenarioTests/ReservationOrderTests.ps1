# ----------------------------------------------------------------------------------
#
# Copyright Microsoft Corporation
# Licensed under the Apache License, Version 2.0 (the "License");
# you may not use this file except in compliance with the License.
# You may obtain a copy of the License at
# http://www.apache.org/licenses/LICENSE-2.0
# Unless required by applicable law or agreed to in writing, software
# distributed under the License is distributed on an "AS IS" BASIS,
# WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
# See the License for the specific language governing permissions and
# limitations under the License.
# ----------------------------------------------------------------------------------

<#
.SYNOPSIS
Get a single reservation
#>
function Test-GetReservationOrder
{
	$reservationOrderId = "55793bc2-e5c2-4a98-9d5c-0a0bce6cf998"
    $reservation = Get-AzureRmReservationOrder -ReservationOrderId $reservationOrderId

	Assert-NotNull $reservation
	Assert-NotNull $reservation.Etag
	Assert-NotNull $reservation.Id
	Assert-NotNull $reservation.Name
	Assert-NotNull $reservation.Type
}

<#
.SYNOPSIS
List reservations
#>
function Test-ListReservationOrders
{
	$type = "Microsoft.Capacity/reservations"

    $reservationList = Get-AzureRmReservationOrder

	Assert-NotNull $reservationList

	Assert-NotNull $reservationList.Etag
	Assert-NotNull $reservationList.Id
	Assert-NotNull $reservationList.Name
	Assert-NotNull $reservationList.Type
}
