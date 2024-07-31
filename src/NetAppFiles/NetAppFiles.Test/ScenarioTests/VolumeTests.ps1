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
    $poolName2 = Get-ResourceName
    $volName1 = Get-ResourceName
    $volName2 = Get-ResourceName
    $volName3 = Get-ResourceName
    $volName4 = Get-ResourceName
    $gibibyte = 1024 * 1024 * 1024
    $usageThreshold = 100 * $gibibyte
    $doubleUsage = 2 * $usageThreshold
    #$resourceLocation = Get-ProviderLocation "Microsoft.NetApp" "eastus" -UseCanonical
    #$resourceLocation = "eastus2euap"
    $resourceLocation = "westus2"

    $subnetName = "default"
    $poolSize = 4398046511104
    $serviceLevel = "Premium"
    $vnetName = $resourceGroup + "-vnet"

    $subnetId = "/subscriptions/$subsId/resourceGroups/$resourceGroup/providers/Microsoft.Network/virtualNetworks/$vnetName/subnets/$subnetName"

    $rule1 = @{
        RuleIndex = 1
        UnixReadOnly = $false
        UnixReadWrite = $true
        Cifs = $false
        Nfsv3 = $true
        Nfsv41 = $false
        AllowedClients = '0.0.0.0/0'
    }
    $rule2 = @{
        RuleIndex = 2
        UnixReadOnly = $false
        UnixReadWrite = $true
        Cifs = $false
        Nfsv3 = $true
        Nfsv41 = $false
        AllowedClients = '1.2.3.0/24'
    }
    $rule3 = @{
        RuleIndex = 2
        UnixReadOnly = $false
        UnixReadWrite = $true
        Cifs = $false
        Nfsv3 = $true
        Nfsv41 = $false
        AllowedClients = '2.3.4.0/24'
    }
    $rule5 = @{
        RuleIndex = 1
        UnixReadOnly = $false
        UnixReadWrite = $true
        Cifs = $false
        Nfsv3 = $false
        Nfsv41 = $true
        AllowedClients = '1.2.3.0/24'
    }
    $exportPolicy = @{
		Rules = (
			$rule1
		)
	}

    $exportPolicyv4 = @{
		Rules = (
			$rule5
		)
	}

    $exportPolicyMod = @{
		Rules = (
			$rule3
		)
	}

    # create the list of protocol types
    $protocolTypes = New-Object string[] 1
    $protocolTypes[0] = "NFSv3"

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
        $retrievedVolume = New-AzNetAppFilesVolume -ResourceGroupName $resourceGroup -Location $resourceLocation -AccountName $accName -PoolName $poolName -VolumeName $volName1 -CreationToken $volName1 -UsageThreshold $usageThreshold -ServiceLevel $serviceLevel -SubnetId $subnetId -Tag @{$newTagName = $newTagValue} -ExportPolicy $exportPolicy -ProtocolType $protocolTypes
        Assert-AreEqual "$accName/$poolName/$volName1" $retrievedVolume.Name
        Assert-AreEqual $serviceLevel $retrievedVolume.ServiceLevel
        Assert-AreEqual True $retrievedVolume.Tags.ContainsKey($newTagName)
        Assert-AreEqual "tagValue1" $retrievedVolume.Tags[$newTagName].ToString()
        Assert-NotNull $retrievedVolume.ExportPolicy
        Assert-AreEqual '0.0.0.0/0' $retrievedVolume.ExportPolicy.Rules[0].AllowedClients

        Assert-AreEqual $retrievedVolume.ProtocolTypes[0] 'NFSv3'
        Assert-NotNull $retrievedVolume.MountTargets

        # use the NFSv4.1
        $protocolTypesv4 = New-Object string[] 1
        $protocolTypesv4[0] = "NFSv4.1"

        # create second volume and check using the confirm flag
        $retrievedVolume = New-AzNetAppFilesVolume -ResourceGroupName $resourceGroup -Location $resourceLocation -AccountName $accName -PoolName $poolName -VolumeName $volName2 -CreationToken $volName2 -UsageThreshold $usageThreshold -ServiceLevel $serviceLevel -SubnetId $subnetId -ExportPolicy $exportPolicyv4 -ProtocolType $protocolTypesv4 -Confirm:$false
        Assert-AreEqual "$accName/$poolName/$volName2" $retrievedVolume.Name
        Assert-AreEqual $serviceLevel $retrievedVolume.ServiceLevel
        Assert-AreEqual $retrievedVolume.ProtocolTypes[0] 'NFSv4.1'

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
        Assert-AreEqual '0.0.0.0/0' $retrievedVolume.ExportPolicy.Rules[0].AllowedClients
        #Assert-AreEqual $retrievedVolume.ExportPolicy.Rules[1].AllowedClients '1.2.3.0/24'

        # update (patch) and check the volume
        $retrievedVolume = Update-AzNetAppFilesVolume -ResourceGroupName $resourceGroup -Location $resourceLocation -AccountName $accName -PoolName $poolName -VolumeName $volName1 -UsageThreshold $doubleUsage
        Assert-AreEqual $doubleUsage $retrievedVolume.usageThreshold
        # unchanged, not part of the patch
        Assert-AreEqual "Premium" $retrievedVolume.ServiceLevel
        Assert-AreEqual '0.0.0.0/0' $retrievedVolume.ExportPolicy.Rules[0].AllowedClients
        #Assert-AreEqual $retrievedVolume.ExportPolicy.Rules[1].AllowedClients '1.2.3.0/24'

        $rule4 = @{
            RuleIndex = 3
            UnixReadOnly = $false
            UnixReadWrite = $true
            Cifs = $false
            Nfsv3 = $true
            Nfsv41 = $false
            AllowedClients = '1.2.3.0/24'
        }

        $exportPolicyUpdate = @{
            Rules = (
                $rule1, $rule4
            )
        }

        # now patch the policy
        $retrievedVolume = Update-AzNetAppFilesVolume -ResourceGroupName $resourceGroup -Location $resourceLocation -AccountName $accName -PoolName $poolName -VolumeName $volName1 -ExportPolicy $exportPolicyUpdate
        Assert-AreEqual '0.0.0.0/0' $retrievedVolume.ExportPolicy.Rules[0].AllowedClients
        Assert-AreEqual '1.2.3.0/24' $retrievedVolume.ExportPolicy.Rules[1].AllowedClients

        # delete one volume retrieved by id and one by name and check removed
        Remove-AzNetAppFilesVolume -ResourceId $retrievedVolumeById.Id

        # but test the WhatIf first
        Remove-AzNetAppFilesVolume -ResourceGroupName $resourceGroup -AccountName $accName -PoolName $poolName -Name $volName2 -WhatIf
        $retrievedVolume = Get-AzNetAppFilesVolume -ResourceGroupName $resourceGroup -AccountName $accName -PoolName $poolName
        Assert-AreEqual 1 $retrievedVolume.Length

        Remove-AzNetAppFilesVolume -ResourceGroupName $resourceGroup -AccountName $accName -PoolName $poolName -VolumeName $volName2
        $retrievedVolume = Get-AzNetAppFilesVolume -ResourceGroupName $resourceGroup -AccountName $accName -PoolName $poolName
        Assert-AreEqual 0 $retrievedVolume.Length

        # test export policy update with non-default volume (and "Standard" Pool)
        # create pool
        $retrievedPool = New-AzNetAppFilesPool -ResourceGroupName $resourceGroup -Location $resourceLocation -AccountName $accName -PoolName $poolName2 -PoolSize $poolSize -ServiceLevel "Standard"

        # create the volume and check
        $newTagName = "tag1"
        $newTagValue = "tagValue1"
        $retrievedVolume = New-AzNetAppFilesVolume -ResourceGroupName $resourceGroup -Location $resourceLocation -AccountName $accName -PoolName $poolName2 -VolumeName $volName4 -CreationToken $volName4 -UsageThreshold $doubleUsage -ServiceLevel "Standard" -SubnetId $subnetId -Tag @{$newTagName = $newTagValue} -ExportPolicy $exportPolicy
        Assert-AreEqual "$accName/$poolName2/$volName4" $retrievedVolume.Name
        Assert-AreEqual "Standard" $retrievedVolume.ServiceLevel
        Assert-AreEqual True $retrievedVolume.Tags.ContainsKey($newTagName)
        Assert-AreEqual "tagValue1" $retrievedVolume.Tags[$newTagName].ToString()
        Assert-NotNull $retrievedVolume.ExportPolicy
        Assert-AreEqual '0.0.0.0/0' $retrievedVolume.ExportPolicy.Rules[0].AllowedClients
        #Assert-AreEqual '1.2.3.0/24' $retrievedVolume.ExportPolicy.Rules[1].AllowedClients
        # default protocol type for new volume
        Assert-AreEqual $retrievedVolume.ProtocolTypes[0] 'NFSv3'

        # update (patch) export policy and check no change to rest of volume
        $retrievedVolume = Update-AzNetAppFilesVolume -ResourceGroupName $resourceGroup -Location $resourceLocation -AccountName $accName -PoolName $poolName2 -VolumeName $volName4 -ExportPolicy $exportPolicyMod

        $retrievedVolume = Get-AzNetAppFilesVolume -ResourceGroupName $resourceGroup -AccountName $accName -PoolName $poolName2 -VolumeName $volName4
        #Due to service side bug that is to be fixed this is disabled temporaraly
        #Assert-AreEqual '2.3.4.0/24' $retrievedVolume.ExportPolicy.Rules[0].AllowedClients
        # unchanged, not part of the patch
        Assert-AreEqual "Standard" $retrievedVolume.ServiceLevel
        Assert-AreEqual $doubleUsage $retrievedVolume.usageThreshold
        Assert-AreEqual True $retrievedVolume.Tags.ContainsKey($newTagName)
        Assert-AreEqual "tagValue1" $retrievedVolume.Tags[$newTagName].ToString()
    }
    finally
    {
        # Cleanup
        Clean-ResourceGroup $resourceGroup
    }
}


<#
.SYNOPSIS
Test VolumeReplication operations (using command aliases)
#>
<# ---Note This test will be added to the next (2019-11-01) version ---#>
function Test-VolumeReplication
{
    $currentSub = (Get-AzureRmContext).Subscription
    $subsid = $currentSub.SubscriptionId

    $srcResourceGroup = Get-ResourceGroupName
    $srcResourceGroup = $srcResourceGroup
    $destResourceGroup = Get-ResourceGroupName
    $destResourceGroup = $destResourceGroup
    $srcAccName = Get-ResourceName
    $destAccName = Get-ResourceName
    $srcPoolName = Get-ResourceName
    $destPoolName = Get-ResourceName
    $srcVolName = Get-ResourceName
    $destVolName = Get-ResourceName
    $gibibyte = 1024 * 1024 * 1024
    $usageThreshold = 100 * $gibibyte
    $doubleUsage = 2 * $usageThreshold
    $srcResourceGroupLocation = "eastus2"
    $destResourceGroupLocation = "westus2"

    #$srcResourceGroupLocation = "eastus2euap"
    #$destResourceGroupLocation = "southcentralus"
    $srcResourceLocation = "eastus2"
    $destResourceLocation = "westus2"
    #for when using stage regions (southcentralusstage then vnet is created in southcentralus)
    $destVnetLocation = "westus2"

    #$srcResourceLocation = "eastus2euap"
    #$destResourceLocation = "southcentralusstage"
    #$destVnetLocation = "southcentralus"

    $subnetName = "default"
    $poolSize = 4398046511104
    $serviceLevel = "Premium"
    $srcVnetName = $srcResourceGroup + "-vnet"
    $destVnetName = $destResourceGroup + "-vnet"

    $srcSubnetId = "/subscriptions/$subsId/resourceGroups/$srcResourceGroup/providers/Microsoft.Network/virtualNetworks/$srcVnetName/subnets/$subnetName"
    $destSubnetId = "/subscriptions/$subsId/resourceGroups/$destResourceGroup/providers/Microsoft.Network/virtualNetworks/$destVnetName/subnets/$subnetName"

    function WaitForSucceeded #($sourceOnly)
    {
        do
        {
            $sourceVolume = Get-AzNetAppFilesVolume -ResourceGroupName $srcResourceGroup -AccountName $srcAccName -PoolName $srcPoolName -VolumeName $srcVolName
            $dpVolume = Get-AzNetAppFilesVolume -ResourceGroupName $destResourceGroup -AccountName $destAccName -PoolName $destPoolName -VolumeName $destVolName

           Start-TestSleep -Seconds 1
        }
        while (($sourceVolume.ProvisioningState -ne "Succeeded") -or ($dpVolume.ProvisioningState -ne "Succeeded"));
    }

    function WaitForRepliationStatus($targetState)
    {
        $i = 0
        do
        {
            try
            {
                $replicationStatus = Get-AnfReplicationStatus -ResourceGroupName $destResourceGroup -AccountName $destAccName -PoolName $destPoolName -VolumeName $destVolName
            }
            catch [Microsoft.Rest.Azure.CloudException]
            {
                $ErrorMessage = $_.Exception.Message
                if ($ErrorMessage -notlike "*Cannot get replication status, the volume replication is*")
                {
                    throw
                }
            }
            Start-TestSleep -Seconds 20
            $i++
        }
        until ($replicationStatus.MirrorState -eq $targetState -or $i -eq 40);

        $replicationStatus = Get-AnfReplicationStatus -ResourceGroupName $destResourceGroup -AccountName $destAccName -PoolName $destPoolName -VolumeName $destVolName
        Assert-AreEqual $targetState $replicationStatus.MirrorState

        #while ($replicationStatus.MirrorState -ne $targetState)
    }

    try
    {
        # normal setup :

        # create the resource groups for source and destination
        $groupTagName = "owner"
        $groupTagValue = "b-aubald"
        New-AzResourceGroup -Name $srcResourceGroup -Location $srcResourceGroupLocation -Tags @{$groupTagName = $groupTagValue}
        New-AzResourceGroup -Name $destResourceGroup -Location $destResourceGroupLocation -Tags @{$groupTagName = $groupTagValue}

        # create virtual network source
        $virtualNetwork = New-AzVirtualNetwork -ResourceGroupName $srcResourceGroup -Location $srcResourceLocation -Name $srcVnetName -AddressPrefix 10.0.0.0/16
        $delegation = New-AzDelegation -Name "netAppVolumes" -ServiceName "Microsoft.Netapp/volumes"
        Add-AzVirtualNetworkSubnetConfig -Name $subnetName -VirtualNetwork $virtualNetwork -AddressPrefix "10.0.2.0/24" -Delegation $delegation | Set-AzVirtualNetwork

        # create virtual network destination
        $virtualNetwork = New-AzVirtualNetwork -ResourceGroupName $destResourceGroup -Location $destVnetLocation -Name $destVnetName -AddressPrefix 10.0.0.0/16
        $delegation = New-AzDelegation -Name "netAppVolumes" -ServiceName "Microsoft.Netapp/volumes"
        Add-AzVirtualNetworkSubnetConfig -Name $subnetName -VirtualNetwork $virtualNetwork -AddressPrefix "10.0.3.0/24" -Delegation $delegation | Set-AzVirtualNetwork

        # create accounts for source and destination
        $srcRetrievedAcc = New-AzNetAppFilesAccount -ResourceGroupName $srcResourceGroup -Location $srcResourceLocation -AccountName $srcAccName
	    $destRetrievedAcc = New-AzNetAppFilesAccount -ResourceGroupName $destResourceGroup -Location $destResourceLocation -AccountName $destAccName

        # create pools for source and destination
        $srcRetrievedPool = New-AzNetAppFilesPool -ResourceGroupName $srcResourceGroup -Location $srcResourceLocation -AccountName $srcAccName -PoolName $srcPoolName -PoolSize $poolSize -ServiceLevel $serviceLevel
        $destRetrievedPool = New-AzNetAppFilesPool -ResourceGroupName $destResourceGroup -Location $destResourceLocation -AccountName $destAccName -PoolName $destPoolName -PoolSize $poolSize -ServiceLevel $serviceLevel

        # create source volume
        $sourceVolume = New-AzNetAppFilesVolume -ResourceGroupName $srcResourceGroup -Location $srcResourceLocation -AccountName $srcAccName -PoolName $srcPoolName -VolumeName $srcVolName -CreationToken $srcVolName -UsageThreshold $usageThreshold -ServiceLevel $serviceLevel -SubnetId $srcSubnetId
        #Assert-AreEqual "$srcAccName/$srcPoolName/$srcVolName" $sourceVolume.Name

        $sourceVolume = Get-AzNetAppFilesVolume -ResourceGroupName $srcResourceGroup -AccountName $srcAccName -PoolName $srcPoolName -VolumeName $srcVolName

        # create data protection volume

        $replication = @{
            EndpointType = "dst"
            RemoteVolumeResourceId = $sourceVolume.Id
            ReplicationSchedule = "_10minutely"
        }

        $destinationVolume = New-AzNetAppFilesVolume -ResourceGroupName $destResourceGroup -Location $destResourceLocation -AccountName $destAccName -PoolName $destPoolName -VolumeName $destVolName -CreationToken $destVolName -UsageThreshold $usageThreshold -ServiceLevel $serviceLevel -SubnetId $destSubnetId -ReplicationObject $replication -VolumeType "DataProtection"

        $destinationVolume = Get-AzNetAppFilesVolume  -ResourceGroupName $destResourceGroup -AccountName $destAccName -PoolName $destPoolName -VolumeName $destVolName
        #Assert-AreEqual "$destAccName/$destPoolName/$destVolName" $destinationVolume.Name
        #Assert-NotNull $destinationVolume.DataProtection
        WaitForSucceeded
        Start-TestSleep -Seconds 30

        # authorize the replication
        Approve-AnfReplication -ResourceGroupName $srcResourceGroup -AccountName $srcAccName -PoolName $srcPoolName -VolumeName $srcVolName -DataProtectionVolumeId $destinationVolume.Id

        WaitForSucceeded
        WaitForRepliationStatus "Mirrored"

        # list Replications
        $listedReplicaitons = Get-AzNetAppFilesVolumeReplication -ResourceGroupName $srcResourceGroup -AccountName $srcAccName -PoolName $srcPoolName -VolumeName $srcVolName
        Assert-NotNull $listedReplicaitons

        # suspend the replication
        Suspend-AnfReplication -ResourceGroupName $destResourceGroup -AccountName $destAccName -PoolName $destPoolName -VolumeName $destVolName

        WaitForRepliationStatus "Broken"
        Start-TestSleep -Seconds 30
        WaitForSucceeded

        # resync the replication
        Resume-AnfReplication -ResourceGroupName $destResourceGroup -AccountName $destAccName -PoolName $destPoolName -VolumeName $destVolName

        WaitForRepliationStatus "Mirrored"
        Start-TestSleep -Seconds 30

        # break the replication again
        Suspend-AnfReplication -ResourceGroupName $destResourceGroup -AccountName $destAccName -PoolName $destPoolName -VolumeName $destVolName -ForceBreak

        WaitForRepliationStatus "Broken"
        Start-TestSleep -Seconds 30

        # delete the data protection object
        #  - initiate delete replication on destination, this then releases on source, both resulting in object deletion
        Remove-AnfReplication -ResourceGroupName $destResourceGroup -AccountName $destAccName -PoolName $destPoolName -VolumeName $destVolName
    }
    finally
    {
        # Cleanup
        Clean-ResourceGroup $srcResourceGroup
        Clean-ResourceGroup $destResourceGroup
    }
}

<#
.SYNOPSIS
Test Volume Set-AzNetAppFilesVolumePool operation
#>
function Test-SetVolumePool
{
    $currentSub = (Get-AzureRmContext).Subscription
    $subsid = $currentSub.SubscriptionId

    $resourceGroup = Get-ResourceGroupName
    $accName = Get-ResourceName
    $poolName = Get-ResourceName
    $poolName2 = Get-ResourceName
    $volName1 = Get-ResourceName
    $gibibyte = 1024 * 1024 * 1024
    $usageThreshold = 100 * $gibibyte
    #$resourceLocation = Get-ProviderLocation "Microsoft.NetApp" "eastus" -UseCanonical
    $resourceLocation = "westus2"
    $subnetName = "default"
    $poolSize = 4398046511104
    $serviceLevel = "Premium"
    $serviceLevelStandard = "Premium"
    $vnetName = $resourceGroup + "-vnet"

    $subnetId = "/subscriptions/$subsId/resourceGroups/$resourceGroup/providers/Microsoft.Network/virtualNetworks/$vnetName/subnets/$subnetName"

    $rule1 = @{
        RuleIndex = 1
        UnixReadOnly = $false
        UnixReadWrite = $true
        Cifs = $false
        Nfsv3 = $true
        Nfsv41 = $false
        AllowedClients = '0.0.0.0/0'
    }


    $exportPolicy = @{
		Rules = (
			$rule1
		)
	}

    # create the list of protocol types
    $protocolTypes = New-Object string[] 1
    $protocolTypes[0] = "NFSv3"

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

        # create pools
        $retrievedPool = New-AzNetAppFilesPool -ResourceGroupName $resourceGroup -Location $resourceLocation -AccountName $accName -PoolName $poolName -PoolSize $poolSize -ServiceLevel $serviceLevel
        $retrievedPool2 = New-AzNetAppFilesPool -ResourceGroupName $resourceGroup -Location $resourceLocation -AccountName $accName -PoolName $poolName2 -PoolSize $poolSize -ServiceLevel $serviceLevelStandard

        # create  volume and check
        $newTagName = "tag1"
        $newTagValue = "tagValue1"
        $retrievedVolume = New-AzNetAppFilesVolume -ResourceGroupName $resourceGroup -Location $resourceLocation -AccountName $accName -PoolName $poolName -VolumeName $volName1 -CreationToken $volName1 -UsageThreshold $usageThreshold -ServiceLevel $serviceLevel -SubnetId $subnetId -Tag @{$newTagName = $newTagValue} -ExportPolicy $exportPolicy -ProtocolType $protocolTypes
        Assert-AreEqual "$accName/$poolName/$volName1" $retrievedVolume.Name
        Assert-AreEqual $serviceLevel $retrievedVolume.ServiceLevel
        Assert-AreEqual True $retrievedVolume.Tags.ContainsKey($newTagName)
        Assert-AreEqual "tagValue1" $retrievedVolume.Tags[$newTagName].ToString()
        Assert-NotNull $retrievedVolume.ExportPolicy
        Assert-AreEqual '0.0.0.0/0' $retrievedVolume.ExportPolicy.Rules[0].AllowedClients

        Assert-AreEqual $retrievedVolume.ProtocolTypes[0] 'NFSv3'
        Assert-NotNull $retrievedVolume.MountTargets

        # get and check the volume by name
        $retrievedVolume = Get-AzNetAppFilesVolume -ResourceGroupName $resourceGroup -AccountName $accName -PoolName $poolName -VolumeName $volName1
        Assert-AreEqual "$accName/$poolName/$volName1" $retrievedVolume.Name

        # PoolChange and check the volume
        $poolChangeResult = Set-AzNetAppFilesVolumePool -ResourceGroupName $resourceGroup -AccountName $accName -PoolName $poolName -VolumeName $volName1 -NewPoolResourceId $retrievedPool2.Id

        # check GET no change to rest of volume
        $retrievedVolume = Get-AzNetAppFilesVolume -ResourceGroupName $resourceGroup -AccountName $accName -PoolName $poolName2 -VolumeName $volName1
        Assert-AreEqual "$accName/$poolName2/$volName1" $retrievedVolume.Name
        Assert-AreEqual $serviceLevelStandard $retrievedVolume.ServiceLevel

        # unchanged, not part of the patch
        Assert-AreEqual $serviceLevelStandard $retrievedVolume.ServiceLevel
        Assert-AreEqual $usageThreshold $retrievedVolume.usageThreshold
        #Known Bug tags are missing,  https://jira.ngage.netapp.com/browse/NFSAAS-11136  wait for deployment before uncommenting
        #Assert-AreEqual True $retrievedVolume.Tags.ContainsKey($newTagName)
        #Assert-AreEqual "tagValue1" $retrievedVolume.Tags[$newTagName].ToString()
    }
    finally
    {
        # Cleanup
        Clean-ResourceGroup $resourceGroup
    }
}

<#
.SYNOPSIS
Test Volume Unlock-AzNetAppFilesVolumeFileLock operation
#>
function Test-UnlockVolumeFileLock
{
    $currentSub = (Get-AzureRmContext).Subscription
    $subsid = $currentSub.SubscriptionId

    $resourceGroup = Get-ResourceGroupName
    $accName = Get-ResourceName
    $poolName = Get-ResourceName
    $volName1 = Get-ResourceName
    $gibibyte = 1024 * 1024 * 1024
    $usageThreshold = 100 * $gibibyte
    #$resourceLocation = Get-ProviderLocation "Microsoft.NetApp" "eastus" -UseCanonical
    $resourceLocation = "westus2"
    $subnetName = "default"
    $poolSize = 4398046511104
    $serviceLevel = "Premium"
    $vnetName = $resourceGroup + "-vnet"

    $subnetId = "/subscriptions/$subsId/resourceGroups/$resourceGroup/providers/Microsoft.Network/virtualNetworks/$vnetName/subnets/$subnetName"

    $rule1 = @{
        RuleIndex = 1
        UnixReadOnly = $false
        UnixReadWrite = $true
        Cifs = $false
        Nfsv3 = $true
        Nfsv41 = $false
        AllowedClients = '0.0.0.0/0'
    }

    $exportPolicy = @{
		Rules = (
			$rule1
		)
	}

    # create the list of protocol types
    $protocolTypes = New-Object string[] 1
    $protocolTypes[0] = "NFSv3"

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

        # create pools
        $retrievedPool = New-AzNetAppFilesPool -ResourceGroupName $resourceGroup -Location $resourceLocation -AccountName $accName -PoolName $poolName -PoolSize $poolSize -ServiceLevel $serviceLevel

        # create  volume and check
        $newTagName = "tag1"
        $newTagValue = "tagValue1"
        $retrievedVolume = New-AzNetAppFilesVolume -ResourceGroupName $resourceGroup -Location $resourceLocation -AccountName $accName -PoolName $poolName -VolumeName $volName1 -CreationToken $volName1 -UsageThreshold $usageThreshold -ServiceLevel $serviceLevel -SubnetId $subnetId -Tag @{$newTagName = $newTagValue} -ExportPolicy $exportPolicy -ProtocolType $protocolTypes
        Assert-AreEqual "$accName/$poolName/$volName1" $retrievedVolume.Name
        Assert-AreEqual $serviceLevel $retrievedVolume.ServiceLevel
        Assert-AreEqual True $retrievedVolume.Tags.ContainsKey($newTagName)
        Assert-AreEqual "tagValue1" $retrievedVolume.Tags[$newTagName].ToString()
        Assert-NotNull $retrievedVolume.ExportPolicy
        Assert-AreEqual '0.0.0.0/0' $retrievedVolume.ExportPolicy.Rules[0].AllowedClients

        Assert-AreEqual $retrievedVolume.ProtocolTypes[0] 'NFSv3'
        Assert-NotNull $retrievedVolume.MountTargets

        # get and check the volume by name
        $retrievedVolume = Get-AzNetAppFilesVolume -ResourceGroupName $resourceGroup -AccountName $accName -PoolName $poolName -VolumeName $volName1
        Assert-AreEqual "$accName/$poolName/$volName1" $retrievedVolume.Name

        # BreakFileLocks and check the volume
        $poolChangeResult = Unlock-AzNetAppFilesVolumeFileLock -ResourceGroupName $resourceGroup -AccountName $accName -PoolName $poolName -VolumeName $volName1

        # check GET no change to rest of volume
        $retrievedVolume = Get-AzNetAppFilesVolume -ResourceGroupName $resourceGroup -AccountName $accName -PoolName $poolName -VolumeName $volName1
        Assert-AreEqual "$accName/$poolName/$volName1" $retrievedVolume.Name
        Assert-AreEqual $serviceLevel $retrievedVolume.ServiceLevel

    }
    finally
    {
        # Cleanup
        Clean-ResourceGroup $resourceGroup
    }
}

<#
.SYNOPSIS
Test Volume Get-AzNetAppFilesVolumeGroupIdListForLDAPUser operation on non LDAP volume
#>
function Test-GetGroupIdListForLDAPUser
{
    $currentSub = (Get-AzureRmContext).Subscription
    $subsid = $currentSub.SubscriptionId

    $resourceGroup = Get-ResourceGroupName
    $accName = Get-ResourceName
    $poolName = Get-ResourceName
    $volName1 = Get-ResourceName
    $gibibyte = 1024 * 1024 * 1024
    $usageThreshold = 100 * $gibibyte
    #$resourceLocation = Get-ProviderLocation "Microsoft.NetApp" "eastus" -UseCanonical
    $resourceLocation = "westus2"
    $subnetName = "default"
    $poolSize = 4398046511104
    $serviceLevel = "Premium"
    $vnetName = $resourceGroup + "-vnet"
    $userName = "testuser"

    $subnetId = "/subscriptions/$subsId/resourceGroups/$resourceGroup/providers/Microsoft.Network/virtualNetworks/$vnetName/subnets/$subnetName"

    $rule1 = @{
        RuleIndex = 1
        UnixReadOnly = $false
        UnixReadWrite = $true
        Cifs = $false
        Nfsv3 = $true
        Nfsv41 = $false
        AllowedClients = '0.0.0.0/0'
    }

    $exportPolicy = @{
		Rules = (
			$rule1
		)
	}

    # create the list of protocol types
    $protocolTypes = New-Object string[] 1
    $protocolTypes[0] = "NFSv3"

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

        # create pools
        $retrievedPool = New-AzNetAppFilesPool -ResourceGroupName $resourceGroup -Location $resourceLocation -AccountName $accName -PoolName $poolName -PoolSize $poolSize -ServiceLevel $serviceLevel

        # create  volume and check
        $newTagName = "tag1"
        $newTagValue = "tagValue1"
        $retrievedVolume = New-AzNetAppFilesVolume -ResourceGroupName $resourceGroup -Location $resourceLocation -AccountName $accName -PoolName $poolName -VolumeName $volName1 -CreationToken $volName1 -UsageThreshold $usageThreshold -ServiceLevel $serviceLevel -SubnetId $subnetId -Tag @{$newTagName = $newTagValue} -ExportPolicy $exportPolicy -ProtocolType $protocolTypes
        Assert-AreEqual "$accName/$poolName/$volName1" $retrievedVolume.Name
        Assert-AreEqual $serviceLevel $retrievedVolume.ServiceLevel
        Assert-AreEqual True $retrievedVolume.Tags.ContainsKey($newTagName)
        Assert-AreEqual "tagValue1" $retrievedVolume.Tags[$newTagName].ToString()
        Assert-NotNull $retrievedVolume.ExportPolicy
        Assert-AreEqual '0.0.0.0/0' $retrievedVolume.ExportPolicy.Rules[0].AllowedClients

        Assert-AreEqual $retrievedVolume.ProtocolTypes[0] 'NFSv3'

        # get and check the volume by name
        $retrievedVolume = Get-AzNetAppFilesVolume -ResourceGroupName $resourceGroup -AccountName $accName -PoolName $poolName -VolumeName $volName1
        Assert-AreEqual "$accName/$poolName/$volName1" $retrievedVolume.Name

        # Get GroupIdListForLDAPUser
        Assert-ThrowsContains{ Get-AzNetAppFilesVolumeGroupIdListForLDAPUser -ResourceGroupName $resourceGroup -AccountName $accName -PoolName $poolName -VolumeName $volName1 -Username $userName} 'Group Id list can be fetched for LDAP enabled volumes only. Please check that the volume is LDAP enabled'
    }
    finally
    {
        # Cleanup
        Clean-ResourceGroup $resourceGroup
    }
}

<#
.SYNOPSIS
Test Volume Update-AzNetAppFilesVolume to set snapshotPolicy
#>
function TestUpdate-SnapshotPolicyId
{
    $currentSub = (Get-AzureRmContext).Subscription
    $subsid = $currentSub.SubscriptionId

    $resourceGroup = Get-ResourceGroupName
    $accName = Get-ResourceName
    $poolName = Get-ResourceName
    $volName1 = Get-ResourceName
    $snapshotPolicyName1 = Get-ResourceName
    $gibibyte = 1024 * 1024 * 1024
    $usageThreshold = 100 * $gibibyte
    #$resourceLocation = Get-ProviderLocation "Microsoft.NetApp" "eastus" -UseCanonical
    $resourceLocation = "westus2"
    $subnetName = "default"
    $poolSize = 4398046511104
    $serviceLevel = "Premium"
    $serviceLevelStandard = "Premium"
    $vnetName = $resourceGroup + "-vnet"


    $subnetId = "/subscriptions/$subsId/resourceGroups/$resourceGroup/providers/Microsoft.Network/virtualNetworks/$vnetName/subnets/$subnetName"

    $rule1 = @{
        RuleIndex = 1
        UnixReadOnly = $false
        UnixReadWrite = $true
        Cifs = $false
        Nfsv3 = $true
        Nfsv41 = $false
        AllowedClients = '0.0.0.0/0'
    }


    $exportPolicy = @{
		Rules = (
			$rule1
		)
	}

    $hourlySchedule = @{        
        Minute = 2
        SnapshotsToKeep = 6
    }
    $dailySchedule = @{
        Hour = 1
        Minute = 2
        SnapshotsToKeep = 6
    }
    $weeklySchedule = @{
        Minute = 2    
        Hour = 1		        
        Day = "Sunday,Monday"
        SnapshotsToKeep = 6
    }
    $monthlySchedule = @{
        Minute = 2    
        Hour = 1        
        DaysOfMonth = "2,11,21"
        SnapshotsToKeep = 6
    }

    # create the list of protocol types
    $protocolTypes = New-Object string[] 1
    $protocolTypes[0] = "NFSv3"

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

        # create  volume and check
        $newTagName = "tag1"
        $newTagValue = "tagValue1"
        $retrievedVolume = New-AzNetAppFilesVolume -ResourceGroupName $resourceGroup -Location $resourceLocation -AccountName $accName -PoolName $poolName -VolumeName $volName1 -CreationToken $volName1 -UsageThreshold $usageThreshold -ServiceLevel $serviceLevel -SubnetId $subnetId -Tag @{$newTagName = $newTagValue} -ExportPolicy $exportPolicy -ProtocolType $protocolTypes
        Assert-AreEqual "$accName/$poolName/$volName1" $retrievedVolume.Name
        Assert-AreEqual $serviceLevel $retrievedVolume.ServiceLevel
        Assert-AreEqual True $retrievedVolume.Tags.ContainsKey($newTagName)
        Assert-AreEqual "tagValue1" $retrievedVolume.Tags[$newTagName].ToString()
        Assert-NotNull $retrievedVolume.ExportPolicy
        Assert-AreEqual '0.0.0.0/0' $retrievedVolume.ExportPolicy.Rules[0].AllowedClients

        Assert-AreEqual $retrievedVolume.ProtocolTypes[0] 'NFSv3'
        Assert-NotNull $retrievedVolume.MountTargets

        # get and check the volume by name
        $retrievedVolume = Get-AzNetAppFilesVolume -ResourceGroupName $resourceGroup -AccountName $accName -PoolName $poolName -VolumeName $volName1
        Assert-AreEqual "$accName/$poolName/$volName1" $retrievedVolume.Name

        # create and check SnapshotPolicy        
        $retrievedSnapshotPolicy = New-AzNetAppFilesSnapshotPolicy -ResourceGroupName $resourceGroup -Location $resourceLocation -AccountName $accName -Name $snapshotPolicyName1 -Enabled -HourlySchedule $hourlySchedule -DailySchedule $dailySchedule -WeeklySchedule $weeklySchedule -MonthlySchedule $monthlySchedule
        Assert-AreEqual "$accName/$snapshotPolicyName1" $retrievedSnapshotPolicy.Name        
        Assert-NotNull $retrievedSnapshotPolicy.Id


        # get and check a SnapshotPolicy by name and check again
        $getRetrievedSnapshotPolicy = Get-AzNetAppFilesSnapshotPolicy -ResourceGroupName $resourceGroup -AccountName $accName -Name $snapshotPolicyName1
        Assert-AreEqual "$accName/$snapshotPolicyName1" $retrievedSnapshotPolicy.Name

        # Assign snapshotpolicy to volume
        $updateRetrievedVolume = Update-AzNetAppFilesVolume -ResourceGroupName $resourceGroup -Location $resourceLocation -AccountName $accName -PoolName $poolName -VolumeName $volName1 -SnapshotPolicyId $retrievedSnapshotPolicy.Id
        
        # check GET
        $getRetrievedVolume = Get-AzNetAppFilesVolume -ResourceGroupName $resourceGroup -AccountName $accName -PoolName $poolName -VolumeName $volName1
        Assert-AreEqual "$accName/$poolName/$volName1" $getRetrievedVolume.Name
        Assert-AreEqual $serviceLevelStandard $getRetrievedVolume.ServiceLevel
        Assert-AreEqual $retrievedSnapshotPolicy.Id $getRetrievedVolume.DataProtection.Snapshot.SnapshotPolicyId
        
        #List volumes assigned to snapshotPolicy
        $getVolumeList = Get-AzNetAppFilesSnapshotPolicyVolumeList -ResourceGroupName $resourceGroup -AccountName $accName -Name $snapshotPolicyName1
        Assert-AreEqual 1 $getVolumeList.Length
        Assert-True {"$accName/$poolName/$volName1" -eq $getVolumeList[0].Name}
        
        # Remove snapshotpolicy to volume
        $updateRetrievedVolume = Update-AzNetAppFilesVolume -ResourceGroupName $resourceGroup -Location $resourceLocation -AccountName $accName -PoolName $poolName -VolumeName $volName1 -SnapshotPolicyId ""
        Assert-AreEqual "" $updateRetrievedVolume.DataProtection.Snapshot.SnapshotPolicyId

        # check GET
        $getRetrievedVolume = Get-AzNetAppFilesVolume -ResourceGroupName $resourceGroup -AccountName $accName -PoolName $poolName -VolumeName $volName1
        Assert-AreEqual "$accName/$poolName/$volName1" $getRetrievedVolume.Name
        Assert-AreEqual $serviceLevelStandard $getRetrievedVolume.ServiceLevel
        Assert-AreEqual "" $getRetrievedVolume.DataProtection.Snapshot.SnapshotPolicyId


    }
    finally
    {
        # Cleanup
        Clean-ResourceGroup $resourceGroup
    }
}

<#
.SYNOPSIS
Test Volume Update-AzNetAppFilesVolume to set ProtocolType
#>
function TestUpdate-ProtocolType
{
    $currentSub = (Get-AzureRmContext).Subscription
    $subsid = $currentSub.SubscriptionId

    $resourceGroup = Get-ResourceGroupName
    $accName = Get-ResourceName
    $poolName = Get-ResourceName
    $volName1 = Get-ResourceName
    $snapshotPolicyName1 = Get-ResourceName
    $gibibyte = 1024 * 1024 * 1024
    $usageThreshold = 100 * $gibibyte
    #$resourceLocation = Get-ProviderLocation "Microsoft.NetApp" "eastus" -UseCanonical
    $resourceLocation = "westus2"
    $subnetName = "default"
    $poolSize = 4398046511104
    $serviceLevel = "Premium"
    $serviceLevelStandard = "Premium"
    $vnetName = $resourceGroup + "-vnet"


    $subnetId = "/subscriptions/$subsId/resourceGroups/$resourceGroup/providers/Microsoft.Network/virtualNetworks/$vnetName/subnets/$subnetName"

    $rule1 = @{
        RuleIndex = 1
        UnixReadOnly = $false
        UnixReadWrite = $true
        Cifs = $false
        Nfsv3 = $true
        Nfsv41 = $false
        AllowedClients = '0.0.0.0/0'
    }


    $exportPolicy = @{
		Rules = (
			$rule1
		)
	}

    $hourlySchedule = @{        
        Minute = 2
        SnapshotsToKeep = 6
    }
    $dailySchedule = @{
        Hour = 1
        Minute = 2
        SnapshotsToKeep = 6
    }
    $weeklySchedule = @{
        Minute = 2    
        Hour = 1		        
        Day = "Sunday,Monday"
        SnapshotsToKeep = 6
    }
    $monthlySchedule = @{
        Minute = 2    
        Hour = 1        
        DaysOfMonth = "2,11,21"
        SnapshotsToKeep = 6
    }

    # create the list of protocol types
    $protocolTypes = New-Object string[] 1
    $protocolTypes[0] = "NFSv3"
    $protocolTypesNfs41 = New-Object string[] 1
    $protocolTypesNfs41[0] = "NFSv4.1"
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

        # create  volume and check
        $newTagName = "tag1"
        $newTagValue = "tagValue1"
        $retrievedVolume = New-AzNetAppFilesVolume -ResourceGroupName $resourceGroup -Location $resourceLocation -AccountName $accName -PoolName $poolName -VolumeName $volName1 -CreationToken $volName1 -UsageThreshold $usageThreshold -ServiceLevel $serviceLevel -SubnetId $subnetId -Tag @{$newTagName = $newTagValue} -ExportPolicy $exportPolicy -ProtocolType $protocolTypes
        Assert-AreEqual "$accName/$poolName/$volName1" $retrievedVolume.Name
        Assert-AreEqual $serviceLevel $retrievedVolume.ServiceLevel
        Assert-AreEqual True $retrievedVolume.Tags.ContainsKey($newTagName)
        Assert-AreEqual "tagValue1" $retrievedVolume.Tags[$newTagName].ToString()
        Assert-NotNull $retrievedVolume.ExportPolicy
        Assert-AreEqual '0.0.0.0/0' $retrievedVolume.ExportPolicy.Rules[0].AllowedClients

        Assert-AreEqual $retrievedVolume.ProtocolTypes[0] 'NFSv3'
        Assert-NotNull $retrievedVolume.MountTargets

        # get and check the volume by name
        $retrievedVolume = Get-AzNetAppFilesVolume -ResourceGroupName $resourceGroup -AccountName $accName -PoolName $poolName -VolumeName $volName1
        Assert-AreEqual "$accName/$poolName/$volName1" $retrievedVolume.Name

        # Change ProtocolType of the Volume
        $updateRetrievedVolume = Update-AzNetAppFilesVolume -ResourceGroupName $resourceGroup -Location $resourceLocation -AccountName $accName -PoolName $poolName -VolumeName $volName1 -ProtocolType $protocolTypesNfs41
        
        # check GET
        $getRetrievedVolume = Get-AzNetAppFilesVolume -ResourceGroupName $resourceGroup -AccountName $accName -PoolName $poolName -VolumeName $volName1
        Assert-AreEqual "$accName/$poolName/$volName1" $getRetrievedVolume.Name
        Assert-AreEqual 'NFSv4.1' $getRetrievedVolume.ProtocolTypes[0] 
        

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
    #$resourceLocation = Get-ProviderLocation "Microsoft.NetApp" "eastus" -UseCanonical
    #$resourceLocation = Get-ProviderLocation "Microsoft.NetApp" "westcentralus" -UseCanonical
    $resourceLocation = "westus2"
    $subnetName = "default"
    $poolSize = 4398046511104
    $serviceLevel = "Premium"
    $vnetName = $resourceGroup + "-vnet"

    $subnetId = "/subscriptions/$subsId/resourceGroups/$resourceGroup/providers/Microsoft.Network/virtualNetworks/$vnetName/subnets/$subnetName"

    try
    {
        # create the resource group
        New-AzResourceGroup -Name $resourceGroup -Location $resourceLocation -Tags @{Owner = 'b-aubald'}

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

<#
.SYNOPSIS
Test Volume CRUD operations
#>
function Test-ResetCifsOnNfsVolume
{
    $currentSub = (Get-AzureRmContext).Subscription
    $subsid = $currentSub.SubscriptionId

    $resourceGroup = Get-ResourceGroupName
    $accName = Get-ResourceName
    $poolName = Get-ResourceName
    $volName1 = Get-ResourceName
    $gibibyte = 1024 * 1024 * 1024
    $usageThreshold = 100 * $gibibyte
    $doubleUsage = 2 * $usageThreshold
    #$resourceLocation = Get-ProviderLocation "Microsoft.NetApp" "eastus" -UseCanonical
    #$resourceLocation = "eastus2euap"
    $resourceLocation = "westus2"

    $subnetName = "default"
    $poolSize = 4398046511104
    $serviceLevel = "Premium"
    $vnetName = $resourceGroup + "-vnet"

    $subnetId = "/subscriptions/$subsId/resourceGroups/$resourceGroup/providers/Microsoft.Network/virtualNetworks/$vnetName/subnets/$subnetName"

    $rule1 = @{
        RuleIndex = 1
        UnixReadOnly = $false
        UnixReadWrite = $true
        Cifs = $false
        Nfsv3 = $true
        Nfsv41 = $false
        AllowedClients = '0.0.0.0/0'
    }
    $rule2 = @{
        RuleIndex = 2
        UnixReadOnly = $false
        UnixReadWrite = $true
        Cifs = $false
        Nfsv3 = $true
        Nfsv41 = $false
        AllowedClients = '1.2.3.0/24'
    }
    $rule3 = @{
        RuleIndex = 2
        UnixReadOnly = $false
        UnixReadWrite = $true
        Cifs = $false
        Nfsv3 = $true
        Nfsv41 = $false
        AllowedClients = '2.3.4.0/24'
    }
    $rule5 = @{
        RuleIndex = 1
        UnixReadOnly = $false
        UnixReadWrite = $true
        Cifs = $false
        Nfsv3 = $false
        Nfsv41 = $true
        AllowedClients = '1.2.3.0/24'
    }
    $exportPolicy = @{
		Rules = (
			$rule1
		)
	}

    $exportPolicyv4 = @{
		Rules = (
			$rule5
		)
	}

    $exportPolicyMod = @{
		Rules = (
			$rule3
		)
	}

    # create the list of protocol types
    $protocolTypes = New-Object string[] 1
    $protocolTypes[0] = "NFSv3"

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
        $retrievedVolume = New-AzNetAppFilesVolume -ResourceGroupName $resourceGroup -Location $resourceLocation -AccountName $accName -PoolName $poolName -VolumeName $volName1 -CreationToken $volName1 -UsageThreshold $usageThreshold -ServiceLevel $serviceLevel -SubnetId $subnetId -Tag @{$newTagName = $newTagValue} -ExportPolicy $exportPolicy -ProtocolType $protocolTypes
        Assert-AreEqual "$accName/$poolName/$volName1" $retrievedVolume.Name
        Assert-AreEqual $serviceLevel $retrievedVolume.ServiceLevel
        Assert-AreEqual True $retrievedVolume.Tags.ContainsKey($newTagName)
        Assert-AreEqual "tagValue1" $retrievedVolume.Tags[$newTagName].ToString()
        Assert-NotNull $retrievedVolume.ExportPolicy
        Assert-AreEqual '0.0.0.0/0' $retrievedVolume.ExportPolicy.Rules[0].AllowedClients

        Assert-AreEqual $retrievedVolume.ProtocolTypes[0] 'NFSv3'
        Assert-NotNull $retrievedVolume.MountTargets

        # get and check a volume by name
        $retrievedVolume = Get-AzNetAppFilesVolume -ResourceGroupName $resourceGroup -AccountName $accName -PoolName $poolName -VolumeName $volName1
        Assert-AreEqual "$accName/$poolName/$volName1" $retrievedVolume.Name

        #Assert-ThrowsContains{ Reset-AzNetAppFilesVolumeCifsPassword -ResourceGroupName $resourceGroup -AccountName $accName -PoolName $poolName -VolumeName $volName1} 'Cannot reset account for volume with NFS protocol, only volumes with CIFS protocol can be reset'
        Assert-ThrowsContains{ Reset-AzNetAppFilesVolumeCifsPassword -ResourceGroupName $resourceGroup -AccountName $accName -PoolName $poolName -VolumeName $volName1} 'Resetting CIFS password on account for volume is not permitted'

        Remove-AzNetAppFilesVolume -ResourceGroupName $resourceGroup -AccountName $accName -PoolName $poolName -VolumeName $volName1
        $retrievedVolume = Get-AzNetAppFilesVolume -ResourceGroupName $resourceGroup -AccountName $accName -PoolName $poolName
        Assert-AreEqual 0 $retrievedVolume.Length
    }
    finally
    {
        # Cleanup
        Clean-ResourceGroup $resourceGroup
    }
}
