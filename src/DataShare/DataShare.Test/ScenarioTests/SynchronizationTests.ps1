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
Testing start synchronization

#>
function Test-SynchronizationStart
{
    $resourceGroup = getAssetName
    $AccountName = getAssetName
    $ShareName = getAssetName
	$Mode = "FullSync"
	$ResourceId = "/subscriptions/c39dce18-cead-4065-8fb1-3af7683a5038/resourceGroups/sdktestingadsrg4712/providers/Microsoft.DataShare/accounts/sdktestingshareaccount9776/shareSubscriptions/sdktestingshare1"
	$endAndStartTime = "06/26/2019 01:15:47"

	$syncStatus = "Succeeded"

	$sync = Start-AzDataShareSubscriptionSynchronization -ResourceGroupName $resourceGroup -AccountName $AccountName -ShareSubscriptionName $ShareName -SynchronizationMode $Mode
	Assert-NotNull $sync
	Assert-AreEqual $sync.startTime $endAndStartTime
	Assert-AreEqual $sync.endTime $endAndStartTime
	Assert-AreEqual $sync.status $syncStatus

	$sync = Start-AzDataShareSubscriptionSynchronization -ResourceId $ResourceId -SynchronizationMode $Mode
	Assert-NotNull $sync
	Assert-AreEqual $sync.startTime $endAndStartTime
	Assert-AreEqual $sync.endTime $endAndStartTime
}


function Test-SynchronizationCancel
{
	$resourceGroup = getAssetName
    $AccountName = getAssetName
    $ShareName = getAssetName
	$SynchronizationId = "20a43c32-81d2-4a03-a878-9c2c389e7ea8"

	$sync = Stop-AzDataShareSubscriptionSynchronization -ResourceGroupName $resourceGroup -AccountName $AccountName -ShareSubscriptionName $ShareName -SynchronizationId $SynchronizationId

	Assert-NotNull $sync
	Assert-AreEqual $sync.status "Succeeded"
	
	$ResourceId = "/subscriptions/c39dce18-cead-4065-8fb1-3af7683a5038/resourceGroups/sdktestingadsrg4712/providers/Microsoft.DataShare/accounts/sdktestingshareaccount9776/shareSubscriptions/sdktestingshare1"
	
	$sync = Stop-AzDataShareSubscriptionSynchronization -ResourceId $ResourceId -SynchronizationId $SynchronizationId
	Assert-NotNull $sync
	Assert-AreEqual $sync.status "Succeeded"	
}

function Test-ListShareSubscriptionSynchronizationCrud
{
	$resourceGroup = getAssetName
    $AccountName = getAssetName
    $ShareSubscripitonName = getAssetName

	$listSync = Get-AzDataShareSubscriptionSynchronization -ResourceGroupName $resourceGroup -AccountName $AccountName -ShareSubscriptionName $ShareSubscripitonName

	Assert-NotNull $listSync
	Assert-AreEqual $listSync[0].status "Succeeded"
	Assert-AreEqual $listSync[1].status "InProgress"
	Assert-AreEqual $listSync[2].status "Failed"
}

function Test-ListShareSubscriptionSynchronizationDetailsCrud
{
	$resourceGroup = getAssetName
    $AccountName = getAssetName
    $ShareSubscripitonName = getAssetName
	$SynchronizationId = "02a17faa-4498-45ee-a884-162180af9251"

	$listSyncDetails = Get-AzDataShareSubscriptionSynchronizationDetail -ResourceGroupName $resourceGroup -AccountName $AccountName -ShareSubscriptionName $ShareSubscripitonName -SynchronizationId $SynchronizationId

	Assert-NotNull $listSyncDetails
	Assert-AreEqual $listSyncDetails[0].status "Succeeded"
	Assert-AreEqual $listSyncDetails[1].status "InProgress"
	Assert-AreEqual $listSyncDetails[2].status "Failed"
}

function Test-ListShareSynchronizationCrud
{
	$resourceGroup = getAssetName
    $AccountName = getAssetName
    $ShareName = getAssetName

	$listSync = Get-AzDataShareSynchronization -ResourceGroupName $resourceGroup -AccountName $AccountName -ShareName $ShareName

	Assert-NotNull $listSync
	Assert-AreEqual $listSync[0].status "Succeeded"
	Assert-AreEqual $listSync[1].status "InProgress"
	Assert-AreEqual $listSync[2].status "Failed"
}

function Test-ListShareSynchronizationDetailsCrud
{
	$resourceGroup = getAssetName
    $AccountName = getAssetName
    $ShareName = getAssetName
	$SynchronizationId = "02a17faa-4498-45ee-a884-162180af9251"

	$listSyncDetails = Get-AzDataShareSynchronizationDetail -ResourceGroupName $resourceGroup -AccountName $AccountName -ShareName $ShareName -SynchronizationId $SynchronizationId

	Assert-NotNull $listSyncDetails
	Assert-AreEqual $listSyncDetails[0].status "Succeeded"
	Assert-AreEqual $listSyncDetails[1].status "InProgress"
	Assert-AreEqual $listSyncDetails[2].status "Failed"
}