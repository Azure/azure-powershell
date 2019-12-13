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
$subscriptionId ="d3ae48e5-dbb2-4618-afd4-fb1b8559cb80"
$reservationOrderId = "b9fbc5c6-fa93-4c1d-b7dc-81a786af5813"
$reservationId = "d42d1cd5-9ea9-4a93-b3ca-c50a2ab0c0b9"

<#
.SYNOPSIS
Get reservation catalog
#>
function Test-GetCatalog
{
	# Get VirtualMachines catalog
	$catalog = Get-AzReservationCatalog -SubscriptionId $subscriptionId -ReservedResourceType VirtualMachines -Location westus
	Foreach ($item in $catalog)
	{
		Assert-NotNull $item.ResourceType
		Assert-NotNull $item.Name
		Assert-True { $item.Terms.Count -gt 0 }
		Assert-True { $item.Locations.Count -gt 0 }
	}

	# Get SuseLinux catalog
	$catalog = Get-AzReservationCatalog -SubscriptionId $subscriptionId -ReservedResourceType SuseLinux
	Foreach ($item in $catalog)
	{
		Assert-NotNull $item.ResourceType
		Assert-NotNull $item.Name
		Assert-Null $item.Locations
		Assert-True { $item.Terms.Count -gt 0 }
	}

	# Get SqlDatabases catalog
	$catalog = Get-AzReservationCatalog -SubscriptionId $subscriptionId -ReservedResourceType SqlDatabases -Location southeastasia
	Foreach ($item in $catalog)
	{
		Assert-NotNull $item.ResourceType
		Assert-NotNull $item.Name
		Assert-True { $item.Terms.Count -gt 0 }
		Assert-True { $item.Locations.Count -gt 0 }
	}

    # Get CosmosDb catalog
	$catalog = Get-AzReservationCatalog -SubscriptionId $subscriptionId -ReservedResourceType CosmosDb
	Foreach ($item in $catalog)
	{
		Assert-NotNull $item.ResourceType
		Assert-NotNull $item.Name
		Assert-True { $item.Terms.Count -gt 0 }
		Assert-Null $item.Locations
	}
}

<#
.SYNOPSIS
Calculate price
#>
function Test-CalculatePrice
{
    $reservedResourceType = "VirtualMachines"
    $location = "westus"
    $term = "P1Y"
    $quantity = 1
    $billingPlan = "Upfront"
    $applyScopeType = "Shared"
    $renew = $false
    $sku = "standard_b1ls"
    $disPlayName = "test"

    $calculateP = Get-AzReservationQuote -ReservedResourceType $reservedResourceType -Location $location -BillingScopeId $subscriptionId -Term $term -Quantity $quantity -BillingPlan $billingPlan  -AppliedScopeType $applyScopeType -Sku $sku -DisplayName $disPlayName
    Assert-NotNull $calculateP
    Assert-NotNull $calculateP.ReservationOrderId
}

<#
.SYNOPSIS
Purchase
#>
function Test-Purchase
{
    $roId = "53f2a7dd-04ba-4354-afa8-68301b2d3d28"
    $reservedResourceType = "VirtualMachines"
    $location = "westus"
    $term = "P1Y"
    $quantity = 1
    $billingPlan = "Upfront"
    $applyScopeType = "Shared"
    $renew = $false
    $sku = "standard_b1ls"
    $disPlayName = "test"

    $purcahseResult = New-AzReservation -ReservationOrderId $roId -ReservedResourceType $reservedResourceType -Location $location -BillingScopeId $subscriptionId -Term $term -Quantity $quantity -BillingPlan $billingPlan  -AppliedScopeType $applyScopeType -Sku $sku -DisplayName $disPlayName
    Assert-NotNull $purcahseResult
}

<#
.SYNOPSIS
Get applied reservation list
#>
function Test-GetReservationOrderId
{
	$appliedReservations = Get-AzReservationOrderId -SubscriptionId $subscriptionId

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
	$reservationOrderIdSplit = "0c0e972c-a418-497c-8fc9-96b5d43fcb1d"
	$reservationIdSplit = "5d941ba9-22d0-46f5-8194-ca00001bb180"
	$type = "Microsoft.Capacity/reservationOrders/reservations"

	$splitResult = Split-AzReservation -ReservationOrderId $reservationOrderIdSplit -ReservationId $reservationIdSplit -Quantity 1,2
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
	$reservationId1 = "5ae9e6f9-6193-4d0b-9c49-d59d5b19fe53"
	$reservationId2 = "4a60de37-8be3-4c67-ba15-1c7722f6a008"
	$reservationOrderIdMerge = "0c0e972c-a418-497c-8fc9-96b5d43fcb1d"
	$type = "Microsoft.Capacity/reservationOrders/reservations"
	$mergeResult = Merge-AzReservation -ReservationOrderId $reservationOrderIdMerge -ReservationId $reservationId1,$reservationId2
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

	$reservationItem = Get-AzReservation -ReservationOrderId $reservationOrderId -ReservationId $reservationId

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
$ReservationOrderIdTestScope = "11e0f3cb-d8d2-42d4-8b24-b460cab90b67"
$ReservationIdTestScope = "153f4fea-dde4-4656-949a-50e3191840c9"

function Test-UpdateReservationToShared
{
	$type = "Microsoft.Capacity/reservationOrders/reservations"

	$reservationItem = Update-AzReservation -ReservationOrderId $ReservationOrderIdTestScope -ReservationId $ReservationIdTestScope -appliedscopetype Shared -InstanceFlexibility On

	Assert-NotNull $reservationItem
	Assert-NotNull $reservationItem.Etag

	$name = $ReservationOrderIdTestScope + '/' + $ReservationIdTestScope
	$id = "/providers/microsoft.capacity/reservationOrders/" + $ReservationOrderIdTestScope + "/reservations/" + $ReservationIdTestScope

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
	$subscription = "/subscriptions/d3ae48e5-dbb2-4618-afd4-fb1b8559cb80"

	$reservationItem = Update-AzReservation -ReservationOrderId $ReservationOrderIdTestScope -ReservationId $ReservationIdTestScope -appliedscopetype Single -appliedscope $subscription -InstanceFlexibility On

	Assert-NotNull $reservationItem
	Assert-NotNull $reservationItem.Etag

	$name = $ReservationOrderIdTestScope + '/' + $ReservationIdTestScope
	$id = "/providers/microsoft.capacity/reservationOrders/" + $ReservationOrderIdTestScope + "/reservations/" + $ReservationIdTestScope

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

	$reservations = Get-AzReservation -ReservationOrderId $reservationOrderId

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

	$reservationItemList = Get-AzReservationHistory -ReservationOrderId $reservationOrderId -ReservationId $reservationId

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