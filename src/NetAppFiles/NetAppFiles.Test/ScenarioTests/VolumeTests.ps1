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

    $resourceGroup = Get-ResourceGroupName
    $accName = Get-ResourceName
    $poolName = Get-ResourceName
    $volName1 = Get-ResourceName
    $volName2 = Get-ResourceName
    $volName3 = Get-ResourceName
    $gibibyte = 1024 * 1024 * 1024
    $usageThreshold = 100 * $gibibyte
    $doubleUsage = 2 * $usageThreshold
    $resourceLocation = Get-ProviderLocation "Microsoft.NetApp"
    $subnetName = "default"
    $poolSize = 4398046511104
    $serviceLevel = "Premium"
    $vnetName = $resourceGroup + "-vnet"

    $subnetId = "/subscriptions/$subsId/resourceGroups/$resourceGroup/providers/Microsoft.Network/virtualNetworks/$vnetName/subnets/$subnetName"

    $rule1 = @{
        RuleIndex = 1
        UnixReadOnly = 'false'
        UnixReadWrite = 'true'
        Cifs = 'false'
        Nfsv3 = 'true'
        Nfsv4 = 'false'
        AllowedClients = '0.0.0.0/0'
    }
    $rule2 = @{
        RuleIndex = 2
        UnixReadOnly = 'false'
        UnixReadWrite = 'true'
        Cifs = 'false'
        Nfsv3 = 'true'
        Nfsv4 = 'false'
        AllowedClients = '1.2.3.0/24'
    }


    $exportPolicy = @{
		Rules = (
			$rule1, $rule2
		)
	}

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
        $retrievedVolume = New-AzNetAppFilesVolume -ResourceGroupName $resourceGroup -Location $resourceLocation -AccountName $accName -PoolName $poolName -VolumeName $volName1 -CreationToken $volName1 -UsageThreshold $usageThreshold -ServiceLevel $serviceLevel -SubnetId $subnetId -Tag @{$newTagName = $newTagValue} -ExportPolicy $exportPolicy
        Assert-AreEqual "$accName/$poolName/$volName1" $retrievedVolume.Name
        Assert-AreEqual $serviceLevel $retrievedVolume.ServiceLevel
        Assert-AreEqual True $retrievedVolume.Tags.ContainsKey($newTagName)
        Assert-AreEqual "tagValue1" $retrievedVolume.Tags[$newTagName].ToString()
        Assert-NotNull $retrievedVolume.ExportPolicy
        Assert-AreEqual $retrievedVolume.ExportPolicy.Rules[0].AllowedClients '0.0.0.0/0'
        Assert-AreEqual $retrievedVolume.ExportPolicy.Rules[1].AllowedClients '1.2.3.0/24'

        # create second volume and check using the confirm flag
        $retrievedVolume = New-AzNetAppFilesVolume -ResourceGroupName $resourceGroup -Location $resourceLocation -AccountName $accName -PoolName $poolName -VolumeName $volName2 -CreationToken $volName2 -UsageThreshold $usageThreshold -ServiceLevel $serviceLevel -SubnetId $subnetId -Confirm:$false
        Assert-AreEqual "$accName/$poolName/$volName2" $retrievedVolume.Name
        Assert-AreEqual $serviceLevel $retrievedVolume.ServiceLevel

        # create and check a third volume  using the WhatIf - it should not be created
        $retrievedVolume = New-AzNetAppFilesVolume -ResourceGroupName $resourceGroup -Location $resourceLocation -AccountName $accName -PoolName $poolName -VolumeName $volName3 -CreationToken $volName2 -UsageThreshold $usageThreshold -ServiceLevel $serviceLevel -SubnetId $subnetId -WhatIf

        # get and check volumes by group (list)
        $retrievedVolume = Get-AzNetAppFilesVolume -ResourceGroupName $resourceGroup -AccountName $accName -PoolName $poolName
        # check the names but the order does not appear to be guaranteed (perhaps because the names are randomly generated)
        Assert-True {"$accName/$poolName/$volName1" -eq $retrievedVolume[0].Name -or "$accName/$poolName/$volName2" -eq $retrievedVolume[0].Name}
        Assert-True {"$accName/$poolName/$volName1" -eq $retrievedVolume[1].Name -or "$accName/$poolName/$volName2" -eq $retrievedVolume[1].Name}
        Assert-AreEqual 2 $retrievedVolume.Length

        # get and check a volume by name
        $retrievedVolume = Get-AzNetAppFilesVolume -ResourceGroupName $resourceGroup -AccountName $accName -PoolName $poolName -VolumeName $volName1
        Assert-AreEqual "$accName/$poolName/$volName1" $retrievedVolume.Name
		
        # get and check the volume again using the resource id just obtained
        $retrievedVolumeById = Get-AzNetAppFilesVolume -ResourceId $retrievedVolume.Id
        Assert-AreEqual "$accName/$poolName/$volName1" $retrievedVolumeById.Name
        Assert-AreEqual $retrievedVolume.ExportPolicy.Rules[0].AllowedClients '0.0.0.0/0'
        Assert-AreEqual $retrievedVolume.ExportPolicy.Rules[1].AllowedClients '1.2.3.0/24'

        # update (patch) and check the volume
        $retrievedVolume = Update-AzNetAppFilesVolume -ResourceGroupName $resourceGroup -Location $resourceLocation -AccountName $accName -PoolName $poolName -VolumeName $volName1 -UsageThreshold $doubleUsage
        Assert-AreEqual $doubleUsage $retrievedVolume.usageThreshold
        # unchanged, not part of the patch
        Assert-AreEqual "Premium" $retrievedVolume.ServiceLevel
        Assert-AreEqual $retrievedVolume.ExportPolicy.Rules[0].AllowedClients '0.0.0.0/0'
        Assert-AreEqual $retrievedVolume.ExportPolicy.Rules[1].AllowedClients '1.2.3.0/24'

		$rule3 = @{
			RuleIndex = 3
			UnixReadOnly = 'false'
			UnixReadWrite = 'true'
			Cifs = 'false'
			Nfsv3 = 'true'
			Nfsv4 = 'false'
			AllowedClients = '1.2.3.0/24'
		}

		$exportPolicyUpdate = @{
			Rules = (
				$rule2, $rule3
			)
		}

        # now patch the policy
        $retrievedVolume = Update-AzNetAppFilesVolume -ResourceGroupName $resourceGroup -Location $resourceLocation -AccountName $accName -PoolName $poolName -VolumeName $volName1 -ExportPolicy $exportPolicyUpdate
        Assert-AreEqual $retrievedVolume.ExportPolicy.Rules[0].AllowedClients '1.2.3.0/24'

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

    $resourceGroup = Get-ResourceGroupName
    $accName = Get-ResourceName
    $poolName = Get-ResourceName
    $volName1 = Get-ResourceName
    $volName2 = Get-ResourceName
    $gibibyte = 1024 * 1024 * 1024
    $usageThreshold = 100 * $gibibyte
    $doubleUsage = 2 * $usageThreshold
    $resourceLocation = Get-ProviderLocation "Microsoft.NetApp"
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
        # account name, pool name and service level are all acquired
        $retrievedVolume = Get-AnfPool -ResourceGroupName $resourceGroup -AccountName $accName -Name $poolName | New-AnfVolume -Name $volName1 -CreationToken $volName1 -UsageThreshold $usageThreshold -SubnetId $subnetId -ServiceLevel $serviceLevel
        Assert-AreEqual "$accName/$poolName/$volName1" $retrievedVolume.Name
        Assert-AreEqual "Premium" $retrievedVolume.ServiceLevel
        
        # check now with ServiceLevel specified
        # unfortuantely changing to Standard causes FileSystemAllocation error
        # but this can be captured to demonstrate this does use the field parameter
        try
        {
            $retrievedVolume = Get-AnfPool -ResourceGroupName $resourceGroup -AccountName $accName -Name $poolName | New-AnfVolume -Name $volName2 -CreationToken $volName2 -UsageThreshold $usageThreshold -ServiceLevel "Standard" -SubnetId $subnetId
            Assert-AreEqual "$accName/$poolName/$volName2" $retrievedVolume.Name
            Assert-AreEqual "Standard" $retrievedVolume.ServiceLevel
            Assert-True { $false }
        }
        catch
        {
            Assert-True { $true }
        }

        # modify volume by piping from volume
        $retrievedVolume = Get-AnfVolume -ResourceGroupName $resourceGroup -AccountName $accName -PoolName $poolName -Name $volName1 | Update-AnfVolume -UsageThreshold $doubleUsage
        Assert-AreEqual "Premium" $retrievedVolume.ServiceLevel  # unchanged, not part of the patch
		Assert-AreEqual $doubleUsage $retrievedVolume.usageThreshold

        # get the current number of volumes
        $retrievedVolume = Get-AnfVolume -ResourceGroupName $resourceGroup -AccountName $accName -PoolName $poolName
        $numVolumes = $retrievedVolume.Length

        # delete the volumes by piping from volume get
        Get-AnfVolume -ResourceGroupName $resourceGroup -AccountName $accName -PoolName $poolName -Name $volName1 | Remove-AnfVolume

        # and check the volume list by piping from get
        $retrievedVolume = Get-AnfPool -ResourceGroupName $resourceGroup -AccountName $accName -PoolName $poolName | Get-AnfVolume 
        Assert-AreEqual ($numVolumes-1) $retrievedVolume.Length
    }
    finally
    {
        # Cleanup
        Clean-ResourceGroup $resourceGroup
    }
}