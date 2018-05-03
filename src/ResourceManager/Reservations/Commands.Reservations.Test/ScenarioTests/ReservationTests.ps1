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

# Currently there is no Create Reservation api exposed to powershell.
# Please create reservation through portal and use id to run tests
# Once reservation is created you will have reservationOrderId (which is container for reservation),
# reservationId, subscriptionId to run this test
$subscriptionId ="98df3792-7962-4f18-8be2-d5576f122de3"
$reservationOrderId = "55793bc2-e5c2-4a98-9d5c-0a0bce6cf998"
$reservationId = "55ef9160-825e-4ca3-969e-c919de3c57ec"

<#
.SYNOPSIS
Get reservation catalog
#>
function Test-GetCatalog
{
	$catalog = Get-AzureRmReservationCatalog -SubscriptionId $subscriptionId
	Foreach ($item in $catalog)
	{
		Assert-NotNull $item.ResourceType
		Assert-NotNull $item.Name
		Assert-NotNull $item.Tier
		Assert-NotNull $item.Size
		Assert-True { $item.Terms.Count -gt 0 }
		Assert-True { $item.Locations.Count -gt 0 }
	}
}

<#
.SYNOPSIS
Get applied reservation list
#>
function Test-GetReservationOrderId
{
	$appliedReservations = Get-AzureRmReservationOrderId -SubscriptionId $subscriptionId

	$name = "default"
	$type = "Microsoft.Capacity/AppliedReservations"
	$id = "/subscriptions/" + $subscriptionId + "/providers/microsoft.capacity/AppliedReservations/default"

	Assert-AreEqual $id $appliedReservations.Id
	Assert-AreEqual $name $appliedReservations.Name
	Assert-AreEqual $type $appliedReservations.Type
}

<#
.SYNOPSIS
Split reservation
#>
function Test-SplitReservation
{
	$type = "Microsoft.Capacity/reservationOrders/reservations"

	$splitResult = Split-AzureRmReservation -ReservationOrderId $reservationOrderId -ReservationId $reservationId -Quantity 2,3
	Foreach ($splitItem in $splitResult)
	{
		Assert-NotNull $splitItem
		Assert-True { $splitItem.Etag -gt 0}
		Assert-NotNull $splitItem.Id
		Assert-NotNull $splitItem.Name
		Assert-NotNull $splitItem.Sku
		Assert-AreEqual $splitItem.Type $type	 
	}
}

<#
.SYNOPSIS
Merge reservations
#>
function Test-MergeReservation
{
	$reservationId1 = "85c72953-db91-4d92-8535-e02f6bddb2cb"
	$reservationId2 = "d2f9dac4-5bfb-4013-a93a-fdc1a7a353f7"
	$type = "Microsoft.Capacity/reservationOrders/reservations"
	$mergeResult = Merge-AzureRmReservation -ReservationOrderId $reservationOrderId -ReservationId $reservationId1,$reservationId2
	Foreach ($mergeItem in $mergeResult)
	{
		Assert-NotNull $mergeItem
		Assert-True { $mergeItem.Etag -gt 0}
		Assert-NotNull $mergeItem.Id
		Assert-NotNull $mergeItem.Name
		Assert-NotNull $mergeItem.Sku
		Assert-AreEqual $mergeItem.Type $type	 
	}
}
	
<#
.SYNOPSIS
Get reservation
#>
function Test-GetReservation
{
	$name = $reservationOrderId + '/' + $reservationId
	$type = "Microsoft.Capacity/reservationOrders/reservations"
	$id = "/providers/microsoft.capacity/reservationOrders/" + $reservationOrderId + "/reservations/" + $reservationId

	$reservationItem = Get-AzureRmReservation -ReservationOrderId $reservationOrderId -ReservationId $reservationId

	Assert-NotNull $reservationItem
	Assert-NotNull $reservationItem.Etag
	Assert-AreEqual $reservationItem.Id $id
	Assert-AreEqual $reservationItem.Name $name
	Assert-NotNull $reservationItem.Sku
	Assert-AreEqual $reservationItem.Type $type	 

	
}

<#
.SYNOPSIS
Update reservation
#>
function Test-UpdateReservationToShared
{
	$type = "Microsoft.Capacity/reservationOrders/reservations"

	$reservationItem = Update-AzureRmReservation -ReservationOrderId $reservationOrderId -ReservationId $reservationId -appliedscopetype Shared

	Assert-NotNull $reservationItem
	Assert-NotNull $reservationItem.Etag

	$name = $reservationOrderId + '/' + $reservationId
	$id = "/providers/microsoft.capacity/reservationOrders/" + $reservationOrderId + "/reservations/" + $reservationId

	Assert-AreEqual $reservationItem.Id $id
	Assert-AreEqual $reservationItem.Name $name
	Assert-NotNull $reservationItem.Sku
	Assert-AreEqual $reservationItem.Type $type	 
}
	
<#
.SYNOPSIS
Update reservation
#>
function Test-UpdateReservationToSingle
{
	$type = "Microsoft.Capacity/reservationOrders/reservations"
	$subscription = "/subscriptions/98df3792-7962-4f18-8be2-d5576f122de3"

	$reservationItem = Update-AzureRmReservation -ReservationOrderId $reservationOrderId -ReservationId $reservationId -appliedscopetype Single -appliedscope $subscription

	Assert-NotNull $reservationItem
	Assert-NotNull $reservationItem.Etag

	$name = $reservationOrderId + '/' + $reservationId
	$id = "/providers/microsoft.capacity/reservationOrders/" + $reservationOrderId + "/reservations/" + $reservationId

	Assert-AreEqual $reservationItem.Id $id
	Assert-AreEqual $reservationItem.Name $name
	Assert-NotNull $reservationItem.Sku
	Assert-AreEqual $reservationItem.Type $type	
}

<#
.SYNOPSIS
List reservations
#>
function Test-ListReservations
{
	$name = $reservationOrderId + '/' + $reservationId
	$type = "Microsoft.Capacity/reservationOrders/reservations"
	$id = "/providers/microsoft.capacity/reservationOrders/" + $reservationOrderId + "/reservations/" + $reservationId

	$reservations = Get-AzureRmReservation -ReservationOrderId $reservationOrderId

	Foreach($reservation in $reservations)
	{
		Assert-NotNull $reservation
		Assert-NotNull $reservation.Etag
		Assert-NotNull $reservation.Id
		Assert-NotNull $reservation.Name
		Assert-NotNull $reservation.Sku
		Assert-AreEqual $reservation.Type $type
	}
}

<#
.SYNOPSIS
List reservation revision history
#>
function Test-ListReservationHistory
{
	$type = "Microsoft.Capacity/reservationOrders/reservations/revisions"

	$reservationItemList = Get-AzureRmReservationHistory -ReservationOrderId $reservationOrderId -ReservationId $reservationId

	Assert-NotNull $reservationItemList
	Assert-True {$reservationItemList.Count -ge 1}

	$reservationItem = $reservationItemList[0]
	Assert-NotNull $reservationItem.Etag

	$name = $reservationOrderId + '/' + $reservationId + '/' + $reservationItem.Etag
	$id = "/providers/microsoft.capacity/reservationOrders/" + $reservationOrderId + "/reservations/" + $reservationId + "/revisions/" + $reservationItem.Etag

	Assert-AreEqual $reservationItem.Id $id
	Assert-AreEqual $reservationItem.Name $name
	Assert-NotNull $reservationItem.Sku
	Assert-AreEqual $reservationItem.Type $type
}