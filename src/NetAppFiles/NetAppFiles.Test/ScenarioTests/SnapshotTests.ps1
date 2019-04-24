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

    $resourceGroup = "pws-sdk-tests-rg-2"
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
        New-AzResourceGroup -Name $resourceGroup -Location $resourceLocation
		
        # create virtual network
        $virtualNetwork = New-AzVirtualNetwork -ResourceGroupName $resourceGroup -Location $resourceLocation -Name $vnetName -AddressPrefix 10.0.0.0/16
        $delegation = New-AzDelegation -Name "netAppVolumes" -ServiceName "Microsoft.Netapp/volumes"
        Add-AzVirtualNetworkSubnetConfig -Name $subnetName -VirtualNetwork $virtualNetwork -AddressPrefix "10.0.1.0/24" -Delegation $delegation | Set-AzVirtualNetwork

        # create the resource group
        New-AzResourceGroup -Name $resourceGroupName -Location $resourceLocation

        # create account, pool and volume
        $retrievedAcc = New-AzNetAppFilesAccount -ResourceGroupName $resourceGroup -Location $resourceLocation -AccountName $accName

        $retrievedPool = New-AzNetAppFilesPool -ResourceGroupName $resourceGroup -Location $resourceLocation -AccountName $accName -PoolName $poolName -PoolSize $standardPoolSize -ServiceLevel $serviceLevel
		
        $retrievedVolume = New-AzNetAppFilesVolume -ResourceGroupName $resourceGroup -Location $resourceLocation -AccountName $accName -PoolName $poolName -VolumeName $volName -CreationToken $volName -UsageThreshold $usageThreshold -ServiceLevel $serviceLevel -SubnetId $subnetId
        Assert-AreEqual "$accName/$poolName/$volName" $retrievedVolume.Name
        Assert-AreEqual $serviceLevel $retrievedVolume.ServiceLevel

        # create two snapshots and check
        $retrieveSn = New-AzNetAppFilesSnapshot -ResourceGroupName $resourceGroup -Location $resourceLocation -AccountName $accName -PoolName $poolName -VolumeName $volName -SnapshotName $snName1 -FileSystemId $retrievedVolume.FileSystemId
        Assert-AreEqual "$accName/$poolName/$volName/$snName1" $retrieveSn.Name

        $retrieveSn = New-AzNetAppFilesSnapshot -ResourceGroupName $resourceGroup -Location $resourceLocation -AccountName $accName -PoolName $poolName -VolumeName $volName -SnapshotName $snName2 -FileSystemId $retrievedVolume.FileSystemId
        Assert-AreEqual "$accName/$poolName/$volName/$snName2" $retrieveSn.Name

        # get and check snapshots by group (list)
        $retrievedSnapshot = Get-AzNetAppFilesSnapshot -ResourceGroupName $resourceGroup -AccountName $accName -PoolName $poolName -VolumeName $volName
        Assert-AreEqual "$accName/$poolName/$volName/$snName1" $retrievedSnapshot[0].Name
        Assert-AreEqual "$accName/$poolName/$volName/$snName2" $retrievedSnapshot[1].Name
        Assert-AreEqual 2 $retrievedSnapshot.Length

        # get and check a snapshot by name
        $retrievedSnapshot = Get-AzNetAppFilesSnapshot -ResourceGroupName $resourceGroup -AccountName $accName -PoolName $poolName -VolumeName $volName -SnapshotName $snName1
        Assert-AreEqual "$accName/$poolName/$volName/$snName1" $retrievedSnapshot.Name
		
        # get and check the snapshot again using the resource id just obtained
        $retrievedSnapshotById = Get-AzNetAppFilesSnapshot -ResourceId $retrievedSnapshot.Id
        Assert-AreEqual "$accName/$poolName/$volName/$snName1" $retrievedSnapshotById.Name

        # no update/set (patch/put) possible for snapshot

        # delete one snapshot retrieved by id and one by name and check removed
        Remove-AzNetAppFilesSnapshot -ResourceId $retrievedSnapshotById.Id
        Remove-AzNetAppFilesSnapshot -ResourceGroupName $resourceGroup -AccountName $accName -PoolName $poolName -VolumeName $volName -SnapshotName $snName2
        $retrievedSnapshot = Get-AzNetAppFilesSnapshot -ResourceGroupName $resourceGroup -AccountName $accName -PoolName $poolName -VolumeName $volName
        Assert-AreEqual 0 $retrievedSnapshot.Length
    }
    finally
    {
        # Cleanup
        Clean-ResourceGroup $resourceGroup
    }
}

<#
.SYNOPSIS
Test Snapshot Pipeline operations (using command aliases)
#>
function Test-SnapshotPipelines
{
    $currentSub = (Get-AzureRmContext).Subscription	
    $subsid = $currentSub.SubscriptionId

    $resourceGroup = "pws-sdk-tests-rg-1"
    $accName = "pws-sdk-acc-1"
    $poolName = "pws-sdk-pool-1"
    $volName = "pws-sdk-vol-1"
    $snName1 = "pws-sdk-snapshot-1"
    $snName2 = "pws-sdk-snapshot-2"
    $gibibyte = 1024 * 1024 * 1024
    $usageThreshold = 100 * $gibibyte
    $doubleUsage = 2 * $usageThreshold
    $resourceLocation = "eastus"
    $subnetName = "default"
    $poolSize = 4398046511104
    $serviceLevel = "Premium"
    $vnetName = $resourceGroup + "-vnet"

    $subnetId = "/subscriptions/$subsId/resourceGroups/$resourceGroup/providers/Microsoft.Network/virtualNetworks/$vnetName/subnets/$subnetName"

    try
    {
        # create the resource group
        New-AzResourceGroup -Name $resourceGroup -Location $resourceLocation
		
        # create virtual network
        $virtualNetwork = New-AzVirtualNetwork -ResourceGroupName $resourceGroup -Location $resourceLocation -Name $vnetName -AddressPrefix 10.0.0.0/16
        $delegation = New-AzDelegation -Name "netAppVolumes" -ServiceName "Microsoft.Netapp/volumes"
        Add-AzVirtualNetworkSubnetConfig -Name $subnetName -VirtualNetwork $virtualNetwork -AddressPrefix "10.0.1.0/24" -Delegation $delegation | Set-AzVirtualNetwork

        # create an account, pool and volume
        $retrievedAcc = New-AnfAccount -ResourceGroupName $resourceGroup -Location $resourceLocation -AccountName $accName 

        New-AnfPool -ResourceGroupName $resourceGroup -Location $resourceLocation -AccountName $accName -Name $poolName -PoolSize $poolSize -ServiceLevel $serviceLevel

        $retrievedVolume = New-AnfVolume -ResourceGroupName $resourceGroup -Location $resourceLocation -AccountName $accName -PoolName $poolName -VolumeName $volName -CreationToken $volName -UsageThreshold $usageThreshold -ServiceLevel $serviceLevel -SubnetId $subnetId
        
        # create a snapshot from the piped volume input
        $retrieveSn = Get-AnfVolume -ResourceGroupName $resourceGroup -AccountName $accName -PoolName $poolName -VolumeName $volName | New-AnfSnapshot -SnapshotName $snName1
        Assert-AreEqual "$accName/$poolName/$volName/$snName1" $retrieveSn.Name
        
        # temporarily removed - snapshots cannot be deleted due to a change in status code in the RP
        # this will be fixed in the R3.5 version of the swagger
        # delete the snapshot by piping from snapshot get
        #Get-AnfSnapshot -ResourceGroupName $resourceGroup -AccountName $accName -PoolName $poolName -VolumeName $volName -Name $snName1 | Remove-AnfSnapshot

        # and check the snapshot list by piping from volume get
        #$retrievedSnapshot = Get-AnfVolume -ResourceGroupName $resourceGroup -AccountName $accName -PoolName $poolName -Name $volName | Get-AnfSnapshot 
        #Assert-AreEqual 0 $retrievedSnapshot.Length
    }
    finally
    {
        # Cleanup
        Clean-ResourceGroup $resourceGroup
    }
}