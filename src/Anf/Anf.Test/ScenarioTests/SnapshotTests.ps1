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
Test Snapshot CRUD operations
#>
function Test-SnapshotCrud
{
	$currentSub = (Get-AzureRmContext).Subscription	
	$subsid = $currentSub.SubscriptionId

	$resourceGroup = "pws-sdk-tests-rg-1"
	$accName = "pws-sdk-acc-2"
	$poolName = "pws-sdk-pool-1"
	$volName = "pws-sdk-vol-1"
	$snName1 = "pws-sdk-snapshot-1"
	$snName2 = "pws-sdk-snapshot-2"
	$gibibyte = 1024 * 1024 * 1024
	$usageThreshold = 100 * $gibibyte
	$doubleUsage = 2 * $usageThreshold
    $resourceLocation = "westus2"
	$subnetName = "default"
	$standardPoolSize = 4398046511104
	$serviceLevel = "Premium"
	$vnetName = $resourceGroup + "-vnet"

	$subnetId = "/subscriptions/$subsId/resourceGroups/$resourceGroup/providers/Microsoft.Network/virtualNetworks/$vnetName/subnets/$subnetName"

	try
    {
	    # create the resource group
		New-AzureRmResourceGroup -Name $resourceGroup -Location $resourceLocation
		
		# create virtual network
		$virtualNetwork = New-AzureRmVirtualNetwork -ResourceGroupName $resourceGroup -Location $resourceLocation -Name $vnetName -AddressPrefix 10.0.0.0/16
		$delegation = New-AzureRmDelegation -Name "netAppVolumes" -ServiceName "Microsoft.Netapp/volumes"
		Add-AzureRmVirtualNetworkSubnetConfig -Name $subnetName -VirtualNetwork $virtualNetwork -AddressPrefix "10.0.1.0/24" -Delegation $delegation | Set-AzureRmVirtualNetwork

	    # create the resource group
		New-AzureRmResourceGroup -Name $resourceGroupName -Location $resourceLocation

		# create account, pool and volume
		$retrievedAcc = New-AzureRmAnfAccount -ResourceGroupName $resourceGroup -Location $resourceLocation -AccountName $accName

	    $retrievedPool = New-AzureRmAnfPool -ResourceGroupName $resourceGroup -Location $resourceLocation -AccountName $accName -PoolName $poolName -PoolSize $standardPoolSize -ServiceLevel $serviceLevel
		
	    $retrievedVolume = New-AzureRmAnfVolume -ResourceGroupName $resourceGroup -Location $resourceLocation -AccountName $accName -PoolName $poolName -VolumeName $volName -CreationToken $volName -UsageThreshold $usageThreshold -ServiceLevel $serviceLevel -SubnetId $subnetId
		Assert-AreEqual "$accName/$poolName/$volName" $retrievedVolume.Name
		Assert-AreEqual $serviceLevel $retrievedVolume.ServiceLevel

		# create two snapshots and check
	    $retrieveSn = New-AzureRmAnfSnapshot -ResourceGroupName $resourceGroup -Location $resourceLocation -AccountName $accName -PoolName $poolName -VolumeName $volName -SnapshotName $snName1 -FileSystemId $retrievedVolume.FileSystemId
		Assert-AreEqual "$accName/$poolName/$volName/$snName1" $retrieveSn.Name

	    $retrieveSn = New-AzureRmAnfSnapshot -ResourceGroupName $resourceGroup -Location $resourceLocation -AccountName $accName -PoolName $poolName -VolumeName $volName -SnapshotName $snName2 -FileSystemId $retrievedVolume.FileSystemId
		Assert-AreEqual "$accName/$poolName/$volName/$snName2" $retrieveSn.Name

		# get and check snapshots by group (list)
	    $retrievedSnapshot = Get-AzureRmAnfSnapshot -ResourceGroupName $resourceGroup -AccountName $accName -PoolName $poolName -VolumeName $volName
		Assert-AreEqual "$accName/$poolName/$volName/$snName1" $retrievedSnapshot[0].Name
		Assert-AreEqual "$accName/$poolName/$volName/$snName2" $retrievedSnapshot[1].Name
	    Assert-AreEqual 2 $retrievedSnapshot.Length

		# get and check a snapshot by name
		$retrievedSnapshot = Get-AzureRmAnfSnapshot -ResourceGroupName $resourceGroup -AccountName $accName -PoolName $poolName -VolumeName $volName -SnapshotName $snName1
		Assert-AreEqual "$accName/$poolName/$volName/$snName1" $retrievedSnapshot.Name
		
		# get and check the snapshot again using the resource id just obtained
	    $retrievedSnapshotById = Get-AzureRmAnfSnapshot -ResourceId $retrievedSnapshot.Id
		Assert-AreEqual "$accName/$poolName/$volName/$snName1" $retrievedSnapshotById.Name

		# no update/set (patch/put) possible for snapshot

		# delete one snapshot retrieved by id and one by name and check removed
		# temporary fix. Deletion returns 200 until upcoming swagger change
		Assert-ThrowsContains -script { Remove-AzureRmAnfSnapshot -ResourceId $retrievedSnapshotById.Id } -message "invalid status code 'OK'"
		Assert-ThrowsContains -script { Remove-AzureRmAnfSnapshot -ResourceGroupName $resourceGroup -AccountName $accName -PoolName $poolName -VolumeName $volName -SnapshotName $snName2 } -message "invalid status code 'OK'"
		$retrievedSnapshot = Get-AzureRmAnfSnapshot -ResourceGroupName $resourceGroup -AccountName $accName -PoolName $poolName -VolumeName $volName
		Assert-AreEqual 0 $retrievedSnapshot.Length
	}
	finally
    {
        # Cleanup
        Clean-ResourceGroup $resourceGroup
    }
}
