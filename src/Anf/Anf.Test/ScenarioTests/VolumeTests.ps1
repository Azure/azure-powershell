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
Test Volume CRUD operations
#>
function Test-VolumeCrud
{
	$currentSub = (Get-AzureRmContext).Subscription	
	$subsid = $currentSub.SubscriptionId

	$resourceGroup = "pws-sdk-tests-rg-1"
	$accName = "pws-sdk-acc-2"
	$poolName = "pws-sdk-pool-1"
	$volName1 = "pws-sdk-vol-1"
	$volName2 = "pws-sdk-vol-2"
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

		# create account
		$retrievedAcc = New-AzureRmAnfAccount -ResourceGroupName $resourceGroup -Location $resourceLocation -AccountName $accName 
	    
		# create pool
	    $retrievedPool = New-AzureRmAnfPool -ResourceGroupName $resourceGroup -Location $resourceLocation -AccountName $accName -PoolName $poolName -PoolSize $standardPoolSize -ServiceLevel $serviceLevel

		# create first volume and check
	    $retrievedVolume = New-AzureRmAnfVolume -ResourceGroupName $resourceGroup -Location $resourceLocation -AccountName $accName -PoolName $poolName -VolumeName $volName1 -CreationToken $volName1 -UsageThreshold $usageThreshold -ServiceLevel $serviceLevel -SubnetId $subnetId
		Assert-AreEqual "$accName/$poolName/$volName1" $retrievedVolume.Name
		Assert-AreEqual $serviceLevel $retrievedVolume.ServiceLevel

		# create second volume and check
	    $retrievedVolume = New-AzureRmAnfVolume -ResourceGroupName $resourceGroup -Location $resourceLocation -AccountName $accName -PoolName $poolName -VolumeName $volName2 -CreationToken $volName2 -UsageThreshold $usageThreshold -ServiceLevel $serviceLevel -SubnetId $subnetId
		Assert-AreEqual "$accName/$poolName/$volName2" $retrievedVolume.Name
		Assert-AreEqual $serviceLevel $retrievedVolume.ServiceLevel
		
		# get and check volumes by group (list)
	    $retrievedVolume = Get-AzureRmAnfVolume -ResourceGroupName $resourceGroup -AccountName $accName -PoolName $poolName
		Assert-AreEqual "$accName/$poolName/$volName1" $retrievedVolume[0].Name
		Assert-AreEqual "$accName/$poolName/$volName2" $retrievedVolume[1].Name
	    Assert-AreEqual 2 $retrievedVolume.Length

		# get and check a volume by name
		$retrievedVolume = Get-AzureRmAnfVolume -ResourceGroupName $resourceGroup -AccountName $accName -PoolName $poolName -VolumeName $volName1
		Assert-AreEqual "$accName/$poolName/$volName1" $retrievedVolume.Name
		
		# get and check the volume again using the resource id just obtained
	    $retrievedVolumeById = Get-AzureRmAnfVolume -ResourceId $retrievedVolume.Id
		Assert-AreEqual "$accName/$poolName/$volName1" $retrievedVolumeById.Name

		# update (patch) and check the volume
	    $retrievedVolume = Update-AzureRmAnfVolume -ResourceGroupName $resourceGroup -Location $resourceLocation -AccountName $accName -PoolName $poolName -VolumeName $volName1 -UsageThreshold $doubleUsage
        Assert-AreEqual "Premium" $retrievedVolume.ServiceLevel  # unchanged/not part of the patch
        Assert-AreEqual $doubleUsage $retrievedVolume.usageThreshold

		# set (put) and check the volume
	    $retrievedVolume = Set-AzureRmAnfVolume -ResourceGroupName $resourceGroup -Location $resourceLocation -AccountName $accName -PoolName $poolName -VolumeName $volName1 -CreationToken $volName1 -UsageThreshold $usageThreshold -ServiceLevel "Standard" -SubnetId $subnetId
		Assert-AreEqual "$accName/$poolName/$volName1" $retrievedVolume.Name
        Assert-AreEqual "Standard"  $retrievedVolume.ServiceLevel
        Assert-AreEqual $UsageThreshold $retrievedVolume.usageThreshold
		
		# delete one volume retrieved by id and one by name and check removed
		Remove-AzureRmAnfVolume -ResourceId $retrievedVolumeById.Id
		Remove-AzureRmAnfVolume -ResourceGroupName $resourceGroup -AccountName $accName -PoolName $poolName -VolumeName $volName2
		$retrievedVolume = Get-AzureRmAnfVolume -ResourceGroupName $resourceGroup -AccountName $accName -PoolName $poolName
		Assert-AreEqual 0 $retrievedVolume.Length
    }
	finally
    {
        # Cleanup
        Clean-ResourceGroup $resourceGroup
    }
}
