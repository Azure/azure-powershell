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
$subscriptionId ="caadc3f2-e83e-487c-9a14-41f74366467f"
$reservationOrderId = "ffa7538a-2251-489d-82bf-7efcb8b346d7"
$reservationId = "cf909cbc-f1e6-46b7-a3cc-6bf51cdc571f"

<#
.SYNOPSIS
Get reservation catalog
#>
function Test-GetCatalog
{
	# Get VirtualMachines catalog
	$catalog = Get-AzureRmReservationCatalog -SubscriptionId $subscriptionId -ReservedResourceType VirtualMachines -Location westus
	Foreach ($item in $catalog)
	{
		Assert-NotNull $item.ResourceType
		Assert-NotNull $item.Name
		Assert-True { $item.Terms.Count -gt 0 }
		Assert-True { $item.Locations.Count -gt 0 }
	}

	# Get SuseLinux catalog
	$catalog = Get-AzureRmReservationCatalog -SubscriptionId $subscriptionId -ReservedResourceType SuseLinux
	Foreach ($item in $catalog)
	{
		Assert-NotNull $item.ResourceType
		Assert-NotNull $item.Name
		Assert-Null $item.Locations
		Assert-True { $item.Terms.Count -gt 0 }
	}

	# Get SqlDatabases catalog
	$catalog = Get-AzureRmReservationCatalog -SubscriptionId $subscriptionId -ReservedResourceType SqlDatabases -Location southeastasia
	Foreach ($item in $catalog)
	{
		Assert-NotNull $item.ResourceType
		Assert-NotNull $item.Name
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

	$splitResult = Split-AzureRmReservation -ReservationOrderId $reservationOrderId -ReservationId $reservationId -Quantity 1,1
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
	$reservationId1 = "d2e29da5-857d-498c-8d34-496f2a315bb9"
	$reservationId2 = "5c3b763e-a148-49df-9d9c-544a40d9d97b"
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

	$reservationItem = Update-AzureRmReservation -ReservationOrderId $reservationOrderId -ReservationId $reservationId -appliedscopetype Shared -InstanceFlexibility On

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
	$subscription = "/subscriptions/caadc3f2-e83e-487c-9a14-41f74366467f"

	$reservationItem = Update-AzureRmReservation -ReservationOrderId $reservationOrderId -ReservationId $reservationId -appliedscopetype Single -appliedscope $subscription -InstanceFlexibility On

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