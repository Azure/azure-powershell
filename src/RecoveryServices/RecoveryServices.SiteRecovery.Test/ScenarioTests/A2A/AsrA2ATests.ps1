# encoding: utf-8
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

########################## Site Recovery Tests #############################

##Default Value ##

<#
.SYNOPSIS
    NewA2ADiskReplicationConfiguration creation test.
#>

function Test-NewA2ADiskReplicationConfiguration
{
    $recoveryStorageAccountId ="/subscriptions/7c943c1b-5122-4097-90c8-861411bdd574/resourceGroups/a2a-rg/providers/Microsoft.Storage/storageAccounts/a2argdisks412"
    $logStorageAccountId = "/subscriptions/7c943c1b-5122-4097-90c8-861411bdd574/resourceGroups/ltrgp1705152333/providers/Microsoft.Storage/storageAccounts/stagingsa2name1705152333"
    $vhdUri = "https://powershelltestdiag414.blob.core.windows.net/vhds/pslinV2-520180112143232.vhd"

    $v = New-AzRecoveryServicesAsrAzureToAzureDiskReplicationConfig -VhdUri  $vhdUri `
        -RecoveryAzureStorageAccountId $recoveryStorageAccountId `
        -LogStorageAccountId   $logStorageAccountId

     Assert-True { $v.vhdUri -eq $vhdUri }
     Assert-True { $v.recoveryAzureStorageAccountId -eq $recoveryStorageAccountId  }
     Assert-True { $v.logStorageAccountId -eq $logStorageAccountId }
}


<#
.SYNOPSIS
    NewA2ADiskReplicationConfiguration creation test.
#>
function Test-NewA2AManagedDiskReplicationConfiguration
{
    $logStorageAccountId = "fdd"
    $DiskId = "diskId"
    $RecoveryResourceGroupId = "3"
    $RecoveryReplicaDiskAccountType = "Premium_LRS"
    $RecoveryTargetDiskAccountType = "Premium_LRS"

    $v = New-AzRecoveryServicesAsrAzureToAzureDiskReplicationConfig -managed -LogStorageAccountId $logStorageAccountId `
         -DiskId "diskId" -RecoveryResourceGroupId  $RecoveryResourceGroupId -RecoveryReplicaDiskAccountType  $RecoveryReplicaDiskAccountType `
         -RecoveryTargetDiskAccountType $RecoveryTargetDiskAccountType

     Assert-True { $v.LogStorageAccountId -eq $LogStorageAccountId }
     Assert-True { $v.DiskId -eq $DiskId  }
     Assert-True { $v.RecoveryResourceGroupId -eq $RecoveryResourceGroupId }
}

<#
.SYNOPSIS
    NewA2ADiskReplicationConfiguration for CMK vms creation test.
#>
function Test-NewA2AManagedDiskReplicationConfigurationWithCmk
{    param([string] $seed ='104')

        $primaryPolicyName = getPrimaryPolicy
        $recoveryPolicyName = getRecoveryPolicy
        
        $primaryContainerMappingName = getPrimaryContainerMapping
        $recoveryContainerMappingName = getRecoveryContainerMapping
        
        $primaryContainerName = getPrimaryContainer
        $recoveryContainerName = getRecoveryContainer
        $vaultRgLocation = getVaultRgLocation
        $vaultName = getVaultName
        $vaultLocation = getVaultLocation
        $vaultRg = getVaultRg
        $primaryLocation = getPrimaryLocation
        $recoveryLocation = getRecoveryLocation
        $primaryFabricName = getPrimaryFabric
        $recoveryFabricName = getRecoveryFabric
        $RecoveryReplicaDiskAccountType = "Premium_LRS"
        $RecoveryTargetDiskAccountType = "Premium_LRS"
	$policyName = getPrimaryPolicy
	$mappingName = getPrimaryContainerMapping
	$primaryNetMapping = getPrimaryNetworkMapping

	#create recovery side resources
	$recRgName = getRecoveryResourceGroupName
	New-AzResourceGroup -name $recRgName -location $recoveryLocation -force
        [Microsoft.Rest.ClientRuntime.Azure.TestFramework.TestUtilities]::Wait(20 * 1000)
	$RecoveryAzureNetworkId = createRecoveryNetworkId 
	$index =$RecoveryAzureNetworkId.IndexOf("/providers/")
	$recRg =$RecoveryAzureNetworkId.Substring(0,$index)

    #create primary
	$vmName = getAzureVmName
	$v2VmId = createAzureVm
	$logStg = createCacheStorageAccount
	$vm = get-azVm -ResourceGroupName $vmName -Name $vmName
	$vhdid =$vm.StorageProfile.OSDisk.ManagedDisk.Id
	$index =$v2VmId.IndexOf("/providers/")
	$Rg =$v2VmId.Substring(0,$index)
	$PrimaryAzureNetworkId = $Rg + "/providers/Microsoft.Network/virtualNetworks/" + $vmName

    # vault Creation
	New-AzResourceGroup -name $vaultRg -location $vaultRgLocation -force
        [Microsoft.Rest.ClientRuntime.Azure.TestFramework.TestUtilities]::Wait(20 * 1000)
        New-AzRecoveryServicesVault -ResourceGroupName $vaultRg -Name $vaultName -Location $vaultLocation
        [Microsoft.Rest.ClientRuntime.Azure.TestFramework.TestUtilities]::Wait(20 * 1000)
        $Vault = Get-AzRecoveryServicesVault -ResourceGroupName $vaultRg -Name $vaultName
        Set-ASRVaultContext -Vault $Vault

    # fabric Creation    
        $fabJob=  New-AzRecoveryServicesAsrFabric -Azure -Name $primaryFabricName -Location $primaryLocation
        WaitForJobCompletion -JobId $fabJob.Name
        $fab = Get-AzRecoveryServicesAsrFabric -Name $primaryFabricName
        Assert-true { $fab.name -eq $primaryFabricName }
        Assert-AreEqual $fab.FabricSpecificDetails.Location $primaryLocation

        $fabJob=  New-AzRecoveryServicesAsrFabric -Azure -Name $recoveryFabricName -Location $recoveryLocation
        WaitForJobCompletion -JobId $fabJob.Name
        $fab = Get-AzRecoveryServicesAsrFabric -Name $recoveryFabricName
        Assert-true { $fab.name -eq $recoveryFabricName }
        Assert-AreEqual $fab.FabricSpecificDetails.Location $recoveryLocation
        $pf = get-asrFabric -Name $primaryFabricName
        $rf = get-asrFabric -Name $recoveryFabricName
        
    #Container creation
        $job = New-AzRecoveryServicesAsrProtectionContainer -Name $primaryContainerName -Fabric $pf
        WaitForJobCompletion -JobId $Job.Name
        $pc = Get-asrProtectionContainer -name $primaryContainerName -Fabric $pf
        Assert-NotNull($pc)
        $job = New-AzRecoveryServicesAsrProtectionContainer -Name $recoveryContainerName -Fabric $rf
        WaitForJobCompletion -JobId $Job.Name
        $rc = Get-asrProtectionContainer -name $recoveryContainerName -Fabric $rf
        Assert-NotNull($rc)

    #create policy and mapping
	$job = New-AzRecoveryServicesAsrPolicy -Name $policyName  -RecoveryPointRetentionInHours 12  -AzureToAzure 
	WaitForJobCompletion -JobId $job.Name
	$policy = Get-AzRecoveryServicesAsrPolicy  -Name $policyName
	$job = New-AzRecoveryServicesAsrProtectionContainerMapping -Name $mappingName -Policy $policy -PrimaryProtectionContainer $pc -RecoveryProtectionContainer $rc
	WaitForJobCompletion -JobId $job.Name
	$mapping = Get-AzRecoveryServicesAsrProtectionContainerMapping -Name $mappingName -ProtectionContainer $pc 
		
    #network mapping
	$job = New-AzRecoveryServicesAsrNetworkMapping -AzureToAzure -Name $primaryNetMapping -PrimaryFabric $pf -PrimaryAzureNetworkId $PrimaryAzureNetworkId -RecoveryFabric $rf -RecoveryAzureNetworkId $RecoveryAzureNetworkId
        WaitForJobCompletion -JobId $job.Name
        
     #enable Replication
	$RecoveryDiskEncryptionSetId = "/subscriptions/509099b2-9d2c-4636-b43e-bd5cafb6be69/resourceGroups/cmkDELwrg/providers/Microsoft.Compute/diskEncryptionSets/cmkdiskSe1dEL2"

     $v = New-AzRecoveryServicesAsrAzureToAzureDiskReplicationConfig -managed -LogStorageAccountId $logStg `
         -DiskId $vhdid -RecoveryResourceGroupId  $recRg -RecoveryReplicaDiskAccountType  $RecoveryReplicaDiskAccountType `
         -RecoveryTargetDiskAccountType $RecoveryTargetDiskAccountType -RecoveryDiskEncryptionSetId $RecoveryDiskEncryptionSetId
     Assert-True { $v.RecoveryDiskEncryptionSetId -eq $RecoveryDiskEncryptionSetId }
     $enableDRjob = New-AzRecoveryServicesAsrReplicationProtectedItem -AzureToAzure -AzureVmId $v2VmId -Name $vmName  -ProtectionContainerMapping $mapping -RecoveryResourceGroupId  $recRg -AzureToAzureDiskReplicationConfiguration $v
        
}

<#
.SYNOPSIS 
    Test GetAsrFabric new parametersets
#>
function Test-NewAsrFabric {
    $seed = 35;
        $vaultRgLocation = getVaultRgLocation
        $vaultName = getVaultName
        $vaultLocation = getVaultLocation
        $vaultRg = getVaultRg
        $primaryLocation = getPrimaryLocation
        $recoveryLocation = getRecoveryLocation
        $primaryFabricName = getPrimaryFabric
        $recoveryFabricName = getRecoveryFabric
        
        New-AzResourceGroup -name $vaultRg -location $vaultRgLocation -force
        [Microsoft.Rest.ClientRuntime.Azure.TestFramework.TestUtilities]::Wait(20 * 1000)
    # vault Creation
        New-AzRecoveryServicesVault -ResourceGroupName $vaultRg -Name $vaultName -Location $vaultLocation
        [Microsoft.Rest.ClientRuntime.Azure.TestFramework.TestUtilities]::Wait(20 * 1000)
        $Vault = Get-AzRecoveryServicesVault -ResourceGroupName $vaultRg -Name $vaultName
        Set-ASRVaultContext -Vault $Vault
    # fabric Creation    
        ### AzureToAzure New paramset 
        $fabJob=  New-AzRecoveryServicesAsrFabric -Azure -Name $primaryFabricName -Location $primaryLocation
        WaitForJobCompletion -JobId $fabJob.Name
        $fab = Get-AzRecoveryServicesAsrFabric -Name $primaryFabricName
        Assert-true { $fab.name -eq $primaryFabricName }
        Assert-AreEqual $fab.FabricSpecificDetails.Location $primaryLocation
}


function Test-NewContainer{

    $seed = 33;
    $primaryPolicyName = getPrimaryPolicy
        $recoveryPolicyName = getRecoveryPolicy
        
        $primaryContainerMappingName = getPrimaryContainerMapping
        $recoveryContainerMappingName = getRecoveryContainerMapping
        
        $primaryContainerName = getPrimaryContainer
        $recoveryContainerName = getRecoveryContainer
        $vaultRgLocation = getVaultRgLocation
        $vaultName = getVaultName
        $vaultLocation = getVaultLocation
        $vaultRg = getVaultRg
        $primaryLocation = getPrimaryLocation
        $recoveryLocation = getRecoveryLocation
        $primaryFabricName = getPrimaryFabric
        $recoveryFabricName = getRecoveryFabric
        $RecoveryReplicaDiskAccountType = "Premium_LRS"
        $RecoveryTargetDiskAccountType = "Premium_LRS"

        New-AzResourceGroup -name $vaultRg -location $vaultRgLocation -force
        [Microsoft.Rest.ClientRuntime.Azure.TestFramework.TestUtilities]::Wait(20 * 1000)
    # vault Creation
        New-AzRecoveryServicesVault -ResourceGroupName $vaultRg -Name $vaultName -Location $vaultLocation
        [Microsoft.Rest.ClientRuntime.Azure.TestFramework.TestUtilities]::Wait(20 * 1000)
        $Vault = Get-AzRecoveryServicesVault -ResourceGroupName $vaultRg -Name $vaultName
        Set-ASRVaultContext -Vault $Vault
    # fabric Creation    
        ### AzureToAzure New paramset 
        $fabJob=  New-AzRecoveryServicesAsrFabric -Azure -Name $primaryFabricName -Location $primaryLocation
        WaitForJobCompletion -JobId $fabJob.Name
        $fab = Get-AzRecoveryServicesAsrFabric -Name $primaryFabricName
        Assert-true { $fab.name -eq $primaryFabricName }
        Assert-AreEqual $fab.FabricSpecificDetails.Location $primaryLocation

        $fabJob=  New-AzRecoveryServicesAsrFabric -Azure -Name $recoveryFabricName -Location $recoveryLocation
        WaitForJobCompletion -JobId $fabJob.Name
        $fab = Get-AzRecoveryServicesAsrFabric -Name $recoveryFabricName
        Assert-true { $fab.name -eq $recoveryFabricName }
        Assert-AreEqual $fab.FabricSpecificDetails.Location $recoveryLocation
        $pf = get-asrFabric -Name $primaryFabricName
        $rf = get-asrFabric -Name $recoveryFabricName
        
        ### AzureToAzure (Default)
        $job = New-AzRecoveryServicesAsrProtectionContainer -Name $primaryContainerName -Fabric $pf
        WaitForJobCompletion -JobId $Job.Name
        $pc = Get-asrProtectionContainer -name $primaryContainerName -Fabric $pf
        Assert-NotNull($pc)
        Assert-AreEqual $pc.Name $primaryContainerName

}

<#
.SYNOPSIS 
    Test RemoveReplicationProtectedItemDisk new parametersets
#>

function Test-RemoveReplicationProtectedItemDisk{
   param([string] $seed ='102')
        $primaryPolicyName = getPrimaryPolicy
        $recoveryPolicyName = getRecoveryPolicy
        
        $primaryContainerMappingName = getPrimaryContainerMapping
        $recoveryContainerMappingName = getRecoveryContainerMapping
        
        $primaryContainerName = getPrimaryContainer
        $recoveryContainerName = getRecoveryContainer
        $vaultRgLocation = getVaultRgLocation
        $vaultName = getVaultName
        $vaultLocation = getVaultLocation
        $vaultRg = getVaultRg
        $primaryLocation = getPrimaryLocation
        $recoveryLocation = getRecoveryLocation
        $primaryFabricName = getPrimaryFabric
        $recoveryFabricName = getRecoveryFabric
        $RecoveryReplicaDiskAccountType = "Premium_LRS"
        $RecoveryTargetDiskAccountType = "Premium_LRS"
	$policyName = getPrimaryPolicy
	$mappingName = getPrimaryContainerMapping
	$primaryNetMapping = getPrimaryNetworkMapping

	#create recovery side resources
	$recRgName = getRecoveryResourceGroupName
	New-AzResourceGroup -name $recRgName -location $recoveryLocation -force
        [Microsoft.Rest.ClientRuntime.Azure.TestFramework.TestUtilities]::Wait(20 * 1000)
	$RecoveryAzureNetworkId = createRecoveryNetworkId 
	$index =$RecoveryAzureNetworkId.IndexOf("/providers/")
	$recRg =$RecoveryAzureNetworkId.Substring(0,$index)

    #create primary
	$vmName = getAzureVmName
	$v2VmId = createAzureVm
	$logStg = createCacheStorageAccount
	$vm = get-azVm -ResourceGroupName $vmName -Name $vmName
	$vhdid =$vm.StorageProfile.OSDisk.ManagedDisk.Id
	$index =$v2VmId.IndexOf("/providers/")
	$Rg =$v2VmId.Substring(0,$index)
	$PrimaryAzureNetworkId = $Rg + "/providers/Microsoft.Network/virtualNetworks/" + $vmName

    # vault Creation
	New-AzResourceGroup -name $vaultRg -location $vaultRgLocation -force
        [Microsoft.Rest.ClientRuntime.Azure.TestFramework.TestUtilities]::Wait(20 * 1000)
        New-AzRecoveryServicesVault -ResourceGroupName $vaultRg -Name $vaultName -Location $vaultLocation
        [Microsoft.Rest.ClientRuntime.Azure.TestFramework.TestUtilities]::Wait(20 * 1000)
        $Vault = Get-AzRecoveryServicesVault -ResourceGroupName $vaultRg -Name $vaultName
        Set-ASRVaultContext -Vault $Vault

    # fabric Creation    
        $fabJob=  New-AzRecoveryServicesAsrFabric -Azure -Name $primaryFabricName -Location $primaryLocation
        WaitForJobCompletion -JobId $fabJob.Name
        $fab = Get-AzRecoveryServicesAsrFabric -Name $primaryFabricName
        Assert-true { $fab.name -eq $primaryFabricName }
        Assert-AreEqual $fab.FabricSpecificDetails.Location $primaryLocation

        $fabJob=  New-AzRecoveryServicesAsrFabric -Azure -Name $recoveryFabricName -Location $recoveryLocation
        WaitForJobCompletion -JobId $fabJob.Name
        $fab = Get-AzRecoveryServicesAsrFabric -Name $recoveryFabricName
        Assert-true { $fab.name -eq $recoveryFabricName }
        Assert-AreEqual $fab.FabricSpecificDetails.Location $recoveryLocation
        $pf = get-asrFabric -Name $primaryFabricName
        $rf = get-asrFabric -Name $recoveryFabricName
        
    #Container creation
        $job = New-AzRecoveryServicesAsrProtectionContainer -Name $primaryContainerName -Fabric $pf
        WaitForJobCompletion -JobId $Job.Name
        $pc = Get-asrProtectionContainer -name $primaryContainerName -Fabric $pf
        Assert-NotNull($pc)
        $job = New-AzRecoveryServicesAsrProtectionContainer -Name $recoveryContainerName -Fabric $rf
        WaitForJobCompletion -JobId $Job.Name
        $rc = Get-asrProtectionContainer -name $recoveryContainerName -Fabric $rf
        Assert-NotNull($rc)

    #create policy and mapping
	$job = New-AzRecoveryServicesAsrPolicy -Name $policyName  -RecoveryPointRetentionInHours 12  -AzureToAzure 
	WaitForJobCompletion -JobId $job.Name
	$policy = Get-AzRecoveryServicesAsrPolicy  -Name $policyName
	$job = New-AzRecoveryServicesAsrProtectionContainerMapping -Name $mappingName -Policy $policy -PrimaryProtectionContainer $pc -RecoveryProtectionContainer $rc
	WaitForJobCompletion -JobId $job.Name
	$mapping = Get-AzRecoveryServicesAsrProtectionContainerMapping -Name $mappingName -ProtectionContainer $pc 
		
    #network mapping
	$job = New-AzRecoveryServicesAsrNetworkMapping -AzureToAzure -Name $primaryNetMapping -PrimaryFabric $pf -PrimaryAzureNetworkId $PrimaryAzureNetworkId -RecoveryFabric $rf -RecoveryAzureNetworkId $RecoveryAzureNetworkId
        WaitForJobCompletion -JobId $job.Name
        
     #enable Replication
        $v = New-AzRecoveryServicesAsrAzureToAzureDiskReplicationConfig -managed -LogStorageAccountId $logStg `
         -DiskId $vhdid -RecoveryResourceGroupId  $recRg -RecoveryReplicaDiskAccountType  $RecoveryReplicaDiskAccountType `
         -RecoveryTargetDiskAccountType $RecoveryTargetDiskAccountType
    	$enableDRjob = New-AzRecoveryServicesAsrReplicationProtectedItem -AzureToAzure -AzureVmId $v2VmId -Name $vmName  -ProtectionContainerMapping $mapping -RecoveryResourceGroupId  $recRg -AzureToAzureDiskReplicationConfiguration $v
        WaitForJobCompletion -JobId $enableDRjob.Name
	WaitForIRCompletion -affectedObjectId $enableDRjob.TargetObjectId

    #add diskId
	$pe = Get-AzRecoveryServicesAsrReplicationProtectedItem -ProtectionContainer $pc -Name  $vmName
	Assert-NotNull($pe)

    #create disk and attach
        $diskName = getAzureDataDiskName
	$newDiskConfig = New-AzDiskConfig -Location $vm.Location  -CreateOption Empty -DiskSizeGB 20
	$newDisk = New-AzDisk -ResourceGroupName $vm.ResourceGroupName -DiskName $diskName -Disk $newDiskConfig
	$vm = Add-AzVMDataDisk -VM $vm -Name $diskName -CreateOption Attach -ManagedDiskId $newDisk.Id -Lun 6
	Update-azVm -ResourceGroupName $vmName -VM $vm

    #wait for the add-disk health warning to appear	
        Write-Host $("Waiting for Add-Disk health warning...") -ForegroundColor Yellow
	$HealthQueryWaitTimeInSeconds = 10
        do
        {
            $pe = Get-AzRecoveryServicesAsrReplicationProtectedItem -ProtectionContainer $pc -Name  $vmName
			$healthError = $pe.ReplicationHealthErrors | where-object {$_.ErrorCode -eq 153039}

            if($healthError -eq $null)
            {
                Write-Host $("Waiting for Add-Disk health warning...") -ForegroundColor Yellow
                Write-Host $("Waiting for: " + $HealthQueryWaitTimeInSeconds.ToString + " Seconds") -ForegroundColor Yellow
                [Microsoft.Rest.ClientRuntime.Azure.TestFramework.TestUtilities]::Wait($HealthQueryWaitTimeInSeconds * 1000)
            }
        }While($healthError -eq $null)

     #add disks
	$storageAccountName = "cachedisk1"
	$storageAccount = New-AzStorageAccount -ResourceGroupName $vmName -Location $primaryLocation  -Name $storageAccountName -Type 'Standard_LRS'
	$disk2=	New-AzRecoveryServicesAsrAzureToAzureDiskReplicationConfig -DiskId $newDisk.Id -LogStorageAccountId   $storageAccount.Id -ManagedDisk  -RecoveryReplicaDiskAccountType $RecoveryReplicaDiskAccountType -RecoveryResourceGroupId $pe.ProviderSpecificDetails.A2ADiskDetails[0].RecoveryResourceGroupId -RecoveryTargetDiskAccountType $RecoveryTargetDiskAccountType
        $addDRjob = Add-AzRecoveryServicesAsrReplicationProtectedItemDisk -ReplicationProtectedItem $pe -AzureToAzureDiskReplicationConfiguration $disk2
	WaitForJobCompletion -JobId $addDRjob.Name
		
    #get disk to deattach
	Remove-AzStorageAccount -ResourceGroupName $vmName -Name $storageAccountName
	WaitForAddDisksIRCompletion -affectedObjectId $addDRjob.TargetObjectId -JobQueryWaitTimeInSeconds 10 -IsExpectedToPass $false
	[Microsoft.Rest.ClientRuntime.Azure.TestFramework.TestUtilities]::Wait(20 * 1000)
         
	$pe = Get-AzRecoveryServicesAsrReplicationProtectedItem -ProtectionContainer $pc -Name  $vmName
	$removeDisk =$pe.ProviderSpecificDetails.A2ADiskDetails | where-object {$_.AllowedDiskLevelOperations.Count -ne 0}

	Assert-NotNull($removeDisk)
	$vm = get-azVm -ResourceGroupName $vmName -Name $vmName
	$removeDiskObj = $vm.StorageProfile.DataDisks | Where-Object {$_.Name -eq $removeDisk.DiskName}
	$removeDRjob = Remove-AzRecoveryServicesAsrReplicationProtectedItemDisk -ReplicationProtectedItem $pe -DiskId $removeDiskObj.ManagedDisk.Id
	WaitForJobCompletion -JobId $removeDRjob.Name

	$pe = Get-AzRecoveryServicesAsrReplicationProtectedItem -ProtectionContainer $pc -Name  $vmName
	Assert-NotNull($pe)
}