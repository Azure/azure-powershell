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
function Test-SubvolumeCrud
{
	$currentSub = (Get-AzureRmContext).Subscription
	$subsid = $currentSub.SubscriptionId
    $resourceGroup = Get-ResourceGroupName
    $accName = Get-ResourceName
    $poolName = Get-ResourceName    
    $volName1 = Get-ResourceName
    $subvolName1 = Get-ResourceName
    $subvolName2 = Get-ResourceName
    $gibibyte = 1024 * 1024 * 1024
    $usageThreshold = 100 * $gibibyte
    $doubleUsage = 2 * $usageThreshold
    $resourceLocation = "eastus"

    $subnetName = "default"
    $poolSize = 4398046511104
    $serviceLevel = "Premium"
    $vnetName = $resourceGroup + "-vnet"

    $subnetId = "/subscriptions/$subsId/resourceGroups/$resourceGroup/providers/Microsoft.Network/virtualNetworks/$vnetName/subnets/$subnetName"
    
    # create the list of protocol types
    $protocolTypes = New-Object string[] 1
    $protocolTypes[0] = "NFSv3"
    $path = "/subvolumePath"
    $updatePath = "/subvolumePath1"
    $parentPath = "/parentPath"
    $subvolumeSize = 5
    try
    {
        # create the resource group
        New-AzResourceGroup -Name $resourceGroup -Location $resourceLocation -Tags @{Owner = 'b-aubald'}
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
        $retrievedVolume = New-AzNetAppFilesVolume -ResourceGroupName $resourceGroup -Location $resourceLocation -AccountName $accName -PoolName $poolName -VolumeName $volName1 -CreationToken $volName1 -UsageThreshold $usageThreshold -ServiceLevel $serviceLevel -SubnetId $subnetId -Tag @{$newTagName = $newTagValue} -ProtocolType $protocolTypes -EnableSubvolume
        Assert-AreEqual "$accName/$poolName/$volName1" $retrievedVolume.Name
        Assert-AreEqual $serviceLevel $retrievedVolume.ServiceLevel
        Assert-AreEqual True $retrievedVolume.Tags.ContainsKey($newTagName)
        Assert-AreEqual "tagValue1" $retrievedVolume.Tags[$newTagName].ToString()
        Assert-AreEqual '0.0.0.0/0' $retrievedVolume.ExportPolicy.Rules[0].AllowedClients
        Assert-AreEqual $retrievedVolume.ProtocolTypes[0] 'NFSv3'

        # create first subvolume and check
        $retrievedSubvolume = New-AzNetAppFilesSubvolume -ResourceGroupName $resourceGroup -Location $resourceLocation -AccountName $accName -PoolName $poolName -VolumeName $volName1 -SubvolumeName $subvolName1  -Size $subvolumeSize -Path $path                
        Assert-AreEqual $path $retrievedSubvolume.Path
        
        # get first subvolume and check
        $getSubvolume = Get-AzNetAppFilesSubvolume -ResourceGroupName $resourceGroup -AccountName $accName -PoolName $poolName -VolumeName $volName1 -SubvolumeName $subvolName1         
        Assert-AreEqual $path $getSubvolume.Path

        # get first subvolume metadata and check
        $getSubvolumeMetadata = Get-AzNetAppFilesSubvolumeMetadata -ResourceGroupName $resourceGroup -AccountName $accName -PoolName $poolName -VolumeName $volName1 -SubvolumeName $subvolName1         
        Assert-AreEqual $path $getSubvolumeMetadata.Path        
        Assert-NotNull $getSubvolumeMetadata.Permissions
        Assert-NotNull $getSubvolumeMetadata.CreationTimeStamp
                
        # Update subvolume and check
        $updatedSubvolume = Update-AzNetAppFilesSubvolume -ResourceGroupName $resourceGroup -AccountName $accName -PoolName $poolName -VolumeName $volName1 -SubvolumeName $subvolName1 -Size 3 -Path $updatePath
        Assert-AreEqual $updatePath $updatedSubvolume.Path
        
        # create second subvolume and check
        $retrievedSubvolume2 = New-AzNetAppFilesSubvolume -ResourceGroupName $resourceGroup -Location $resourceLocation -AccountName $accName -PoolName $poolName -VolumeName $volName1 -SubvolumeName $subvolName2  -Size 5 -Path $path
        Assert-AreEqual $path $retrievedSubvolume2.Path
        
        # get list and check
        $getSubvolumes = Get-AzNetAppFilesSubvolume -ResourceGroupName $resourceGroup -AccountName $accName -PoolName $poolName -VolumeName $volName1
        Assert-AreEqual 2 $getSubvolumes.Length

        #Delete subvolume 1
        $updatedSubvolume = Remove-AzNetAppFilesSubvolume -ResourceGroupName $resourceGroup -AccountName $accName -PoolName $poolName -VolumeName $volName1 -SubvolumeName $subvolName1

        # get list and check again
        $getSubvolumes = Get-AzNetAppFilesSubvolume -ResourceGroupName $resourceGroup -AccountName $accName -PoolName $poolName -VolumeName $volName1
        Assert-AreEqual 1 $getSubvolumes.Length
    }
    finally
    {
        # Cleanup
        Clean-ResourceGroup $resourceGroup
    }
}