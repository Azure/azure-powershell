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

    $resourceGroup = "pws-sdk-tests-rg-2"
    $accName = "pws-sdk-acc-1"
    $poolName = "pws-sdk-pool-1"
    $volName1 = "pws-sdk-vol-1"
    $volName2 = "pws-sdk-vol-2"
    $volName3 = "pws-sdk-vol-3"
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

        # create account
        $retrievedAcc = New-AzNetAppFilesAccount -ResourceGroupName $resourceGroup -Location $resourceLocation -AccountName $accName 
	    
        # create pool
        $retrievedPool = New-AzNetAppFilesPool -ResourceGroupName $resourceGroup -Location $resourceLocation -AccountName $accName -PoolName $poolName -PoolSize $poolSize -ServiceLevel $serviceLevel
        
        # create first volume and check
        $newTagName = "tag1"
        $newTagValue = "tagValue1"
        $retrievedVolume = New-AzNetAppFilesVolume -ResourceGroupName $resourceGroup -Location $resourceLocation -AccountName $accName -PoolName $poolName -VolumeName $volName1 -CreationToken $volName1 -UsageThreshold $usageThreshold -ServiceLevel $serviceLevel -SubnetId $subnetId -Tag @{$newTagName = $newTagValue}
        Assert-AreEqual "$accName/$poolName/$volName1" $retrievedVolume.Name
        Assert-AreEqual $serviceLevel $retrievedVolume.ServiceLevel
        Assert-AreEqual True $retrievedVolume.Tags.ContainsKey($newTagName)
        Assert-AreEqual "tagValue1" $retrievedVolume.Tags[$newTagName].ToString()
		
        # create second volume and check using the confirm flag
        $retrievedVolume = New-AzNetAppFilesVolume -ResourceGroupName $resourceGroup -Location $resourceLocation -AccountName $accName -PoolName $poolName -VolumeName $volName2 -CreationToken $volName2 -UsageThreshold $usageThreshold -ServiceLevel $serviceLevel -SubnetId $subnetId -Confirm:$false
        Assert-AreEqual "$accName/$poolName/$volName2" $retrievedVolume.Name
        Assert-AreEqual $serviceLevel $retrievedVolume.ServiceLevel

        # create and check a third volume  using the WhatIf - it should not be created
        $retrievedVolume = New-AzNetAppFilesVolume -ResourceGroupName $resourceGroup -Location $resourceLocation -AccountName $accName -PoolName $poolName -VolumeName $volName3 -CreationToken $volName2 -UsageThreshold $usageThreshold -ServiceLevel $serviceLevel -SubnetId $subnetId -WhatIf

        # get and check volumes by group (list)
        $retrievedVolume = Get-AzNetAppFilesVolume -ResourceGroupName $resourceGroup -AccountName $accName -PoolName $poolName
        Assert-AreEqual "$accName/$poolName/$volName1" $retrievedVolume[0].Name
        Assert-AreEqual "$accName/$poolName/$volName2" $retrievedVolume[1].Name
        Assert-AreEqual 2 $retrievedVolume.Length

        # get and check a volume by name
        $retrievedVolume = Get-AzNetAppFilesVolume -ResourceGroupName $resourceGroup -AccountName $accName -PoolName $poolName -VolumeName $volName1
        Assert-AreEqual "$accName/$poolName/$volName1" $retrievedVolume.Name
		
        # get and check the volume again using the resource id just obtained
        $retrievedVolumeById = Get-AzNetAppFilesVolume -ResourceId $retrievedVolume.Id
        Assert-AreEqual "$accName/$poolName/$volName1" $retrievedVolumeById.Name

        # update (patch) and check the volume
        $retrievedVolume = Update-AzNetAppFilesVolume -ResourceGroupName $resourceGroup -Location $resourceLocation -AccountName $accName -PoolName $poolName -VolumeName $volName1 -UsageThreshold $doubleUsage
        Assert-AreEqual "Premium" $retrievedVolume.ServiceLevel  # unchanged/not part of the patch
        Assert-AreEqual $doubleUsage $retrievedVolume.usageThreshold
		
        # delete one volume retrieved by id and one by name and check removed
        Remove-AzNetAppFilesVolume -ResourceId $retrievedVolumeById.Id

        # but test the WhatIf first
        Remove-AzNetAppFilesVolume -ResourceGroupName $resourceGroup -AccountName $accName -PoolName $poolName -Name $volName2 -WhatIf
        $retrievedVolume = Get-AzNetAppFilesVolume -ResourceGroupName $resourceGroup -AccountName $accName -PoolName $poolName
        Assert-AreEqual 1 $retrievedVolume.Length

        Remove-AzNetAppFilesVolume -ResourceGroupName $resourceGroup -AccountName $accName -PoolName $poolName -VolumeName $volName2
        $retrievedVolume = Get-AzNetAppFilesVolume -ResourceGroupName $resourceGroup -AccountName $accName -PoolName $poolName
        Assert-AreEqual 0 $retrievedVolume.Length
    }
    finally
    {
        # Cleanup
        Clean-ResourceGroup $resourceGroup
    }
}

<#
.SYNOPSIS
Test Volume Pipeline operations (using command aliases)
#>
function Test-VolumePipelines
{
    $currentSub = (Get-AzureRmContext).Subscription	
    $subsid = $currentSub.SubscriptionId

    $resourceGroup = "pws-sdk-tests-rg-2"
    $accName = "pws-sdk-acc-1"
    $poolName = "pws-sdk-pool-1"
    $volName1 = "pws-sdk-vol-1"
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

        # create account
        $retrievedAcc = New-AnfAccount -ResourceGroupName $resourceGroup -Location $resourceLocation -AccountName $accName 

        # create pool
        New-AnfPool -ResourceGroupName $resourceGroup -Location $resourceLocation -AccountName $accName -Name $poolName -PoolSize $poolSize -ServiceLevel $serviceLevel 

        # create volume by piping from a pool
        $retrievedVolume = Get-AnfPool -ResourceGroupName $resourceGroup -AccountName $accName -Name $poolName | New-AnfVolume -Name $volName1 -CreationToken $volName1 -UsageThreshold $usageThreshold -ServiceLevel $serviceLevel -SubnetId $subnetId
        Assert-AreEqual "$accName/$poolName/$volName1" $retrievedVolume.Name
        
        # modify volume by piping from volume
        $retrievedVolume = Get-AnfVolume -ResourceGroupName $resourceGroup -AccountName $accName -PoolName $poolName -Name $volName1 | Update-AnfVolume -UsageThreshold $doubleUsage
        Assert-AreEqual "Premium" $retrievedVolume.ServiceLevel  # unchanged/not part of the patch
		Assert-AreEqual $doubleUsage $retrievedVolume.usageThreshold

        # delete the volumes by piping from volume get
        Get-AnfVolume -ResourceGroupName $resourceGroup -AccountName $accName -PoolName $poolName -Name $volName1 | Remove-AnfVolume

        # and check the volume list by piping from get
        $retrievedVolume = Get-AnfPool -ResourceGroupName $resourceGroup -AccountName $accName -PoolName $poolName | Get-AnfVolume 
        Assert-AreEqual 0 $retrievedVolume.Length
    }
    finally
    {
        # Cleanup
        Clean-ResourceGroup $resourceGroup
    }
}