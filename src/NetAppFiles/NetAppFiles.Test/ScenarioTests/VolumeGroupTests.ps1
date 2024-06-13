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
function Test-VolumeGroupCrud
{	
    $currentSub = (Get-AzureRmContext).Subscription
    $subsid = $currentSub.SubscriptionId
    	
    $resourceGroup = Get-ResourceGroupName
    $accName = Get-ResourceName
    $poolName = Get-ResourceName    
    $volGroupName1 = Get-ResourceName
    $volGroupName1 = Get-ResourceName
    $subvolName2 = Get-ResourceName
    $gibibyte = 1024 * 1024 * 1024
    $tebibytes = 1024 * 1024 * 1024 * 1024;
    $usageThreshold = 100 * $gibibyte
    $doubleUsage = 2 * $usageThreshold
    
    $subnetName = "default"
    $volBytes = 12816182411264
    #$poolSize = $volBytes*$gibibyte
    $poolSize = 20*$tebibytes
    $serviceLevel = "Premium"
    $GroupDescription = "Powershell test VolumeGroup"
    $ApplicationType = "SAP-HANA"
    $ApplicationIdentifier = "SH1"
    $SystemRole = "PRIMARY"
    $nodeMemory = 100
    
    
    #For now we need those prerequisite resources specifically as they are manually pinned to an supporting cluster in the datacenter, untill this becomes dynamic where we can pin in code here we use this.
    #see for more detail https://learn.microsoft.com/en-us/azure/azure-netapp-files/application-volume-group-considerations#best-practices-about-proximity-placement-groups
    $fixedResourceGroup = "sdk-net-test-qa2"
    $resourceLocation = "northeurope"
    $vnetName = "vnetnortheurope-anf"
    $subnetId = "/subscriptions/$subsId/resourceGroups/$fixedResourceGroup/providers/Microsoft.Network/virtualNetworks/$vnetName/subnets/$subnetName"
    $proximityPlacementGroup = "/subscriptions/$subsId/resourceGroups/$fixedResourceGroup/providers/Microsoft.Compute/proximityPlacementGroups/sdk_test_northeurope_ppg"
    
    # create the list of protocol types
    $protocolTypes = New-Object string[] 1
    $protocolTypes[0] = "NFSv4.1"

    try
    {
        # create the resource group
        #New-AzResourceGroup -Name $resourceGroup -Location $resourceLocation -Tags @{Owner = 'b-aubald'}
        
        # create account
        $retrievedAcc = New-AzNetAppFilesAccount -ResourceGroupName $fixedResourceGroup -Location $resourceLocation -AccountName $accName 
        $len = $retrievedAcc.ActiveDirectories.Length
	    Write-Log "Got account with $len ad"
        # create pool
        $retrievedPool = New-AzNetAppFilesPool -ResourceGroupName $fixedResourceGroup -Location $resourceLocation -AccountName $accName -PoolName $poolName -PoolSize $poolSize -ServiceLevel $serviceLevel -QosType Manual
        Write-Debug "Pool created"
        Assert-AreEqual "$accName/$poolName" $retrievedPool.Name
        # create volumeGroup and check
        $newTagName = "tag1"
        $newTagValue = "tagValue1"
        Write-Log "Call new volumegroup"
        $retrievedVolumeGroup = New-AzNetAppFilesVolumeGroup -ResourceGroupName $fixedResourceGroup -Location $resourceLocation -AccountName $accName -PoolName $poolName -Name $volGroupName1 -Tag @{$newTagName = $newTagValue}  -GroupDescription $GroupDescription -ApplicationIdentifier $ApplicationIdentifier -ProximityPlacementGroup $proximityPlacementGroup -Vnet $vnetName -SystemRole $SystemRole -NodeMemory $nodeMemory 
        $lenVols = $retrievedVolumeGroup.Volumes.Count
        Write-Log "Got volume grup with $lenVols volumes"
        Assert-AreEqual "$accName/$volGroupName1" $retrievedVolumeGroup.Name
        Assert-AreEqual $GroupDescription $retrievedVolumeGroup.GroupMetaData.GroupDescription
        #Assert-AreEqual True $retrievedVolumeGroup.Tags.ContainsKey($newTagName)
        #Assert-AreEqual "tagValue1" $retrievedVolumeGroup.Tags[$newTagName].ToString()
        #Assert-AreEqual 1 $retrievedAcc.ActiveDirectories.Length
        #Assert-AreEqual 5 $retrievedVolumeGroup.Volumes.Length
        Assert-AreEqual 5 $retrievedVolumeGroup.Volumes.Count
        #Naming convention 
        #<SID>-data-mnt00001
        #$expectedDataVolumeName = "$accName/$poolName/$ApplicationIdentifier-data-mnt00001" 
        #$expectedLogVolumeName = "$accName/$poolName/$ApplicationIdentifier-log-mnt00001" 
        #Assert-AreEqual $expectedDataVolumeName $retrievedVolumeGroup.Volumes[0].Name
        #Assert-AreEqual $expectedLogVolumeName $retrievedVolumeGroup.Volumes[1].Name
        Write-Log "Cleanup volumes $retrievedVolumeGroup.Volumes.Length in volumegroup"
        # Cleanup the volumes
        foreach($volume in $retrievedVolumeGroup.Volumes)
        {
            #Remove-AzNetAppFilesVolume -ResourceGroupName $resourceGroup -AccountName $accName -PoolName $poolName -Name $volume.Name
            Remove-AzNetAppFilesVolume -ResourceId $volume.Id
        }

        #Assert-AreEqual '0.0.0.0/0' $retrievedVolumeGroup.ExportPolicy.Rules[0].AllowedClients
        #Assert-AreEqual $retrievedVolume.ProtocolTypes[0] 'NFSv3'                   
    }
    finally
    {
        try
        {
            if($retrievedVolumeGroup)
            {
                Remove-AzNetAppFilesVolumeGroup -ResourceGroupName $fixedResourceGroup -AccountName $accName -Name $volGroupName1        
            }
            Remove-AzNetAppFilesPool -ResourceGroupName $fixedResourceGroup -AccountName $accName -PoolName $poolName        
            Remove-AzNetAppFilesAccount -ResourceGroupName $fixedResourceGroup -AccountName $accName 
        }
        catch
        {}
        # Cleanup
        Clean-ResourceGroup $resourceGroup
    }
}