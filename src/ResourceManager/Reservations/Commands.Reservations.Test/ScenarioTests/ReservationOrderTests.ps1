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
    # Currently there is no Create Reservation api exposed to powershell.
    # Please create reservation through portal and use id to run tests
    # Once reservation is created you will have reservationOrderId to run this test
	$type = "Microsoft.Capacity/reservationOrders"
	$reservationOrderId = "55793bc2-e5c2-4a98-9d5c-0a0bce6cf998"
    $reservation = Get-AzureRmReservationOrder -ReservationOrderId $reservationOrderId

	Assert-NotNull $reservation
	Assert-True { $reservation.Etag -gt 0 }
	$expectedId = "/providers/microsoft.capacity/reservationOrders/" + $reservationOrderId
	Assert-AreEqual $expectedId $reservation.Id
	Assert-AreEqual $reservationOrderId $reservation.Name
	Assert-AreEqual $type $reservation.Type
}

<#
.SYNOPSIS
List reservations
#>
function Test-ListReservationOrders
{
	$type = "Microsoft.Capacity/reservationOrders"

    $reservationList = Get-AzureRmReservationOrder

	Assert-NotNull $reservationList
	Foreach ($reservation in $reservationList)
	{
		Assert-NotNull $reservation
		Assert-True { $reservation.Etag -gt 0 }
		Assert-NotNull $reservation.Name
		$expectedId = "/providers/microsoft.capacity/reservationOrders/" + $reservation.Name
		Assert-AreEqual $expectedId $reservation.Id
		Assert-AreEqual $type $reservation.Type
	}

}
