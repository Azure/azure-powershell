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
    NewA2ADiskReplicationConfigurationUltraDisk creation test.
#>
function Test-NewA2AManagedDiskReplicationConfigurationForUltraDisk {
     param([string] $seed = '108')

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
    $RecoveryTargetDiskAccountType = "UltraSSD_LRS"
    $policyName = getPrimaryPolicy
    $mappingName = getPrimaryContainerMapping
    $primaryNetMapping = getPrimaryNetworkMapping

    #create recovery side resources
    $recRgName = getRecoveryResourceGroupName
    New-AzResourceGroup -name $recRgName -location $recoveryLocation -force
    [Microsoft.Rest.ClientRuntime.Azure.TestFramework.TestUtilities]::Wait(20 * 1000)
    $RecoveryAzureNetworkId = createRecoveryNetworkId

    #create primary
    $vmName = getAzureVmName
    $v2VmId = createAzureVmInAvailabilityZone
    $vm = get-azVm -ResourceGroupName $vmName -Name $vmName

    # Stop the VM
    Stop-AzVM -Name $vmName -ResourceGroupName $vmName -force
    # Enable Ultra Disk compatibility
    $vm = Get-AzVM -name $vmName -ResourceGroupName $vmName
    Update-AzVM -ResourceGroupName $vmName -VM $vm -UltraSSDEnabled $True
    # Start the VM
    Start-AzVM -Name $vmName -ResourceGroupName $vmName

    #create disk and attach
    $diskName = getAzureDataDiskName
    $primaryZone = getPrimaryZone
    $newDiskConfig = New-AzDiskConfig -SkuName 'UltraSSD_LRS' -Location $vm.Location  -CreateOption Empty -DiskSizeGB 20 -Zone $primaryZone
    $newDisk = New-AzDisk -ResourceGroupName $vm.ResourceGroupName -DiskName $diskName -Disk $newDiskConfig
    $vm = Add-AzVMDataDisk -VM $vm -Name $diskName -CreateOption Attach -ManagedDiskId $newDisk.Id -Lun 1
    Update-azVm -ResourceGroupName $vmName -VM $vm


    $logStg = createCacheStorageAccountForZone($vm.Location, $vm.ReservationGroupName, "Premium_LRS")
    $dataDiskId = $vm.StorageProfile.DataDisks[0].ManagedDisk.Id
    $index = $v2VmId.IndexOf("/providers/")
    $Rg = $v2VmId.Substring(0, $index)
    $PrimaryAzureNetworkId = $Rg + "/providers/Microsoft.Network/virtualNetworks/" + $vmName

    # vault Creation
    New-AzResourceGroup -name $vaultRg -location $vaultRgLocation -force
    [Microsoft.Rest.ClientRuntime.Azure.TestFramework.TestUtilities]::Wait(20 * 1000)
    New-AzRecoveryServicesVault -ResourceGroupName $vaultRg -Name $vaultName -Location $vaultLocation
    [Microsoft.Rest.ClientRuntime.Azure.TestFramework.TestUtilities]::Wait(20 * 1000)
    $Vault = Get-AzRecoveryServicesVault -ResourceGroupName $vaultRg -Name $vaultName
    Set-ASRVaultContext -Vault $Vault

    # fabric Creation
    $fabJob = New-AzRecoveryServicesAsrFabric -Azure -Name $primaryFabricName -Location $primaryLocation
    WaitForJobCompletion -JobId $fabJob.Name
    $fab = Get-AzRecoveryServicesAsrFabric -Name $primaryFabricName
    Assert-true { $fab.name -eq $primaryFabricName }
    Assert-AreEqual $fab.FabricSpecificDetails.Location $primaryLocation

    $fabJob = New-AzRecoveryServicesAsrFabric -Azure -Name $recoveryFabricName -Location $recoveryLocation
    WaitForJobCompletion -JobId $fabJob.Name
    $fab = Get-AzRecoveryServicesAsrFabric -Name $recoveryFabricName
    Assert-true { $fab.name -eq $recoveryFabricName }
    Assert-AreEqual $fab.FabricSpecificDetails.Location $recoveryLocation
    $pf = get-asrFabric -Name $primaryFabricName
    $rf = get-asrFabric -Name $recoveryFabricName

    $RecoveryResourceGroupId = "/subscriptions/7c943c1b-5122-4097-90c8-861411bdd574/resourceGroups/" + $recRgName

    $v = New-AzRecoveryServicesAsrAzureToAzureDiskReplicationConfig -ManagedDisk -LogStorageAccountId $logStg `
        -DiskId $dataDiskId -RecoveryResourceGroupId  $RecoveryResourceGroupId -RecoveryReplicaDiskAccountType  $RecoveryReplicaDiskAccountType `
        -RecoveryTargetDiskAccountType $RecoveryTargetDiskAccountType

    Assert-True { $v.DiskId -eq $dataDiskId }
}

<#
.SYNOPSIS
    NewA2ADiskReplicationConfigurationPv2 creation test.
#>
function Test-NewA2AManagedDiskReplicationConfigurationForPv2 {
     param([string] $seed = '107')

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
    $RecoveryTargetDiskAccountType = "PremiumV2_LRS"
    $policyName = getPrimaryPolicy
    $mappingName = getPrimaryContainerMapping
    $primaryNetMapping = getPrimaryNetworkMapping

    #create recovery side resources
    $recRgName = getRecoveryResourceGroupName
    New-AzResourceGroup -name $recRgName -location $recoveryLocation -force
    [Microsoft.Rest.ClientRuntime.Azure.TestFramework.TestUtilities]::Wait(20 * 1000)
    $RecoveryAzureNetworkId = createRecoveryNetworkId

    #create primary
    $vmName = getAzureVmName
    $v2VmId = createAzureVmInAvailabilityZone
    $vm = get-azVm -ResourceGroupName $vmName -Name $vmName

    #create disk and attach
    $diskName = getAzureDataDiskName
    $primaryZone = getPrimaryZone
    $newDiskConfig = New-AzDiskConfig -SkuName 'PremiumV2_LRS' -Location $vm.Location  -CreateOption Empty -DiskSizeGB 20 -Zone $primaryZone
    $newDisk = New-AzDisk -ResourceGroupName $vm.ResourceGroupName -DiskName $diskName -Disk $newDiskConfig
    $vm = Add-AzVMDataDisk -VM $vm -Name $diskName -CreateOption Attach -ManagedDiskId $newDisk.Id -Lun 1
    Update-azVm -ResourceGroupName $vmName -VM $vm


    $logStg = createCacheStorageAccountForZone($vm.Location, $vm.ReservationGroupName, "Premium_LRS")
    $dataDiskId = $vm.StorageProfile.DataDisks[0].ManagedDisk.Id
    $index = $v2VmId.IndexOf("/providers/")
    $Rg = $v2VmId.Substring(0, $index)
    $PrimaryAzureNetworkId = $Rg + "/providers/Microsoft.Network/virtualNetworks/" + $vmName

    # vault Creation
    New-AzResourceGroup -name $vaultRg -location $vaultRgLocation -force
    [Microsoft.Rest.ClientRuntime.Azure.TestFramework.TestUtilities]::Wait(20 * 1000)
    New-AzRecoveryServicesVault -ResourceGroupName $vaultRg -Name $vaultName -Location $vaultLocation
    [Microsoft.Rest.ClientRuntime.Azure.TestFramework.TestUtilities]::Wait(20 * 1000)
    $Vault = Get-AzRecoveryServicesVault -ResourceGroupName $vaultRg -Name $vaultName
    Set-ASRVaultContext -Vault $Vault

    # fabric Creation
    $fabJob = New-AzRecoveryServicesAsrFabric -Azure -Name $primaryFabricName -Location $primaryLocation
    WaitForJobCompletion -JobId $fabJob.Name
    $fab = Get-AzRecoveryServicesAsrFabric -Name $primaryFabricName
    Assert-true { $fab.name -eq $primaryFabricName }
    Assert-AreEqual $fab.FabricSpecificDetails.Location $primaryLocation

    $fabJob = New-AzRecoveryServicesAsrFabric -Azure -Name $recoveryFabricName -Location $recoveryLocation
    WaitForJobCompletion -JobId $fabJob.Name
    $fab = Get-AzRecoveryServicesAsrFabric -Name $recoveryFabricName
    Assert-true { $fab.name -eq $recoveryFabricName }
    Assert-AreEqual $fab.FabricSpecificDetails.Location $recoveryLocation
    $pf = get-asrFabric -Name $primaryFabricName
    $rf = get-asrFabric -Name $recoveryFabricName

    $RecoveryResourceGroupId = "/subscriptions/7c943c1b-5122-4097-90c8-861411bdd574/resourceGroups/" + $recRgName

    $v = New-AzRecoveryServicesAsrAzureToAzureDiskReplicationConfig -ManagedDisk -LogStorageAccountId $logStg `
        -DiskId $dataDiskId -RecoveryResourceGroupId  $RecoveryResourceGroupId -RecoveryReplicaDiskAccountType  $RecoveryReplicaDiskAccountType `
        -RecoveryTargetDiskAccountType $RecoveryTargetDiskAccountType

    Assert-True { $v.DiskId -eq $dataDiskId }
}

<#
.SYNOPSIS
    Test Cluster Test Failover Job.
#>
function Test-ClusterTestFailoverAndFailoverCleanupJob {
    $primaryContainerName = getClusterPrimaryContainerName
    $primaryFabricName = getClusterPrimaryFabricName
    $recoveryResourceGroupName = getClusterRecoveryResourceGroupName
    $vaultName = getClusterVaultName
    $clusterName = getClusterName
    $Vault = Get-AzRecoveryServicesVault -ResourceGroupName $recoveryResourceGroupName -Name $vaultName
    Set-ASRVaultContext -Vault $Vault
    $primaryFabric = get-asrFabric -Name $primaryFabricName
    $protectionContainer = get-asrProtectionContainer -Name $primaryContainerName -Fabric $primaryFabric
    $protectionCluster = get-ASRReplicationProtectionCluster -ProtectionContainer $protectionContainer -Name $clusterName

    #TFO
    $tfoJob = Start-AzRecoveryServicesAsrClusterTestFailoverJob -ReplicationProtectionCluster $protectionCluster -Direction PrimaryToRecovery -AzureVMNetworkId "/subscriptions/7c943c1b-5122-4097-90c8-861411bdd574/resourceGroups/ClusterRG-Shashank-1903224559-asr/providers/Microsoft.Network/virtualNetworks/adVNET-asr" -LatestProcessedRecoveryPoint

    WaitForJobCompletion -JobId $tfoJob.Name
    #Get recovery vm and verify
    $recvm = get-azVm -ResourceGroupName $recoveryResourceGroupName -Name "sdgql1-test"
    Assert-NotNull($recvm.Id);

    #TFO cleanup
    $tfoCleanupJob = Start-AzRecoveryServicesAsrClusterTestFailoverCleanupJob -ReplicationProtectionCluster $protectionCluster

    WaitForJobCompletion -JobId $tfoCleanupJob.Name
    #Get recovery vm will give exception
    Assert-ThrowsContains { get-azVm -ResourceGroupName $recoveryResourceGroupName -Name "sdgql1-test"} "The Resource 'Microsoft.Compute/virtualMachines/sdgql1-test' under resource group 'ClusterRG-Shashank-1903224559-asr' was not found."

    #Get ClusterRecoveryPoint
    $clusterRecoveryPoints = Get-AzRecoveryServicesAsrClusterRecoveryPoint -ReplicationProtectionCluster $protectionCluster
    #Node Recovery Point
    $nodeRecoveryPoints = @("/Subscriptions/7c943c1b-5122-4097-90c8-861411bdd574/resourceGroups/ClusterRG-Shashank-1903224559-asr/providers/Microsoft.RecoveryServices/vaults/powershell-cluster-vault/replicationFabrics/asr-a2a-default-eastus2/replicationProtectionContainers/8fbcf43b-798e-57f3-9c82-a2c5d9af7541/replicationProtectedItems/20yNCJytW0HBUYGHL4YEigFgyjgmh2u_Bm7QQ-_YqY0/recoveryPoints/c7a79558-a464-4ba9-90e9-13b91860570c")
    
    #TFO
    $tfoJob = Start-AzRecoveryServicesAsrClusterTestFailoverJob -ReplicationProtectionCluster $protectionCluster -Direction PrimaryToRecovery -AzureVMNetworkId "/subscriptions/7c943c1b-5122-4097-90c8-861411bdd574/resourceGroups/ClusterRG-Shashank-1903224559-asr/providers/Microsoft.Network/virtualNetworks/adVNET-asr" -ClusterRecoveryPoint $clusterRecoveryPoints[-1] -ListNodeRecoveryPoint $nodeRecoveryPoints

    WaitForJobCompletion -JobId $tfoJob.Name
    #Get recovery vm and verify
    $recvm = get-azVm -ResourceGroupName $recoveryResourceGroupName -Name "sdgql1-test"
    Assert-NotNull($recvm.Id);
    #TFO cleanup
    $tfoCleanupJob = Start-AzRecoveryServicesAsrClusterTestFailoverCleanupJob -ReplicationProtectionCluster $protectionCluster

    WaitForJobCompletion -JobId $tfoCleanupJob.Name
    #Get recovery vm will give exception
    Assert-ThrowsContains { get-azVm -ResourceGroupName $recoveryResourceGroupName -Name "sdgql1-test"} "The Resource 'Microsoft.Compute/virtualMachines/sdgql1-test' under resource group 'ClusterRG-Shashank-1903224559-asr' was not found."
}

<#
.SYNOPSIS
    Test Cluster Unplanned Failover Job.
#>
function Test-ClusterUnplannedFailoverJob {
    $primaryContainerName = getClusterPrimaryContainerName
    $primaryFabricName = getClusterPrimaryFabricName
    $recoveryResourceGroupName = getClusterRecoveryResourceGroupName
    $vaultName = getClusterVaultName
    $clusterName = getClusterName
    $Vault = Get-AzRecoveryServicesVault -ResourceGroupName $recoveryResourceGroupName -Name $vaultName
    Set-ASRVaultContext -Vault $Vault
    $primaryFabric = get-asrFabric -Name $primaryFabricName
    $protectionContainer = get-asrProtectionContainer -Name $primaryContainerName -Fabric $primaryFabric
    $protectionCluster = get-ASRReplicationProtectionCluster -ProtectionContainer $protectionContainer -Name $clusterName

    $ufoJob = Start-AzRecoveryServicesAsrClusterUnplannedFailoverJob -ReplicationProtectionCluster $protectionCluster  -Direction PrimaryToRecovery -LatestProcessedRecoveryPoint

    WaitForJobCompletion -JobId $ufoJob.Name
    #Get recovery vm and verify
    $recvm = get-azVm -ResourceGroupName $recoveryResourceGroupName -Name "sdgql1"
    Assert-NotNull($recvm.Id);
}

<#
.SYNOPSIS
    Test Cluster Apply Cluster Recovery Point.
#>
function Test-ApplyClusterRecoveryPoint {
    $primaryContainerName = getClusterPrimaryContainerName
    $primaryFabricName = getClusterPrimaryFabricName
    $recoveryResourceGroupName = getClusterRecoveryResourceGroupName
    $vaultName = getClusterVaultName
    $clusterName = getClusterName
    $Vault = Get-AzRecoveryServicesVault -ResourceGroupName $recoveryResourceGroupName -Name $vaultName
    Set-ASRVaultContext -Vault $Vault
    $primaryFabric = get-asrFabric -Name $primaryFabricName
    $protectionContainer = get-asrProtectionContainer -Name $primaryContainerName -Fabric $primaryFabric
    $protectionCluster = get-ASRReplicationProtectionCluster -ProtectionContainer $protectionContainer -Name $clusterName

    $changePitJob = Start-AzRecoveryServicesAsrApplyClusterRecoveryPoint -ReplicationProtectionCluster $protectionCluster -LatestProcessedRecoveryPoint

    WaitForJobCompletion -JobId $changePitJob.Name
    #Get recovery vm and verify
    $recvm = get-azVm -ResourceGroupName $recoveryResourceGroupName -Name "sdgql1"
    Assert-NotNull($recvm.Id);
}

<#
.SYNOPSIS
    Test Cluster Commit Failover Job.
#>
function Test-ClusterCommitFailoverJob {
    $primaryContainerName = getClusterPrimaryContainerName
    $primaryFabricName = getClusterPrimaryFabricName
    $recoveryResourceGroupName = getClusterRecoveryResourceGroupName
    $vaultName = getClusterVaultName
    $clusterName = getClusterName
    $Vault = Get-AzRecoveryServicesVault -ResourceGroupName $recoveryResourceGroupName -Name $vaultName
    Set-ASRVaultContext -Vault $Vault
    $primaryFabric = get-asrFabric -Name $primaryFabricName
    $protectionContainer = get-asrProtectionContainer -Name $primaryContainerName -Fabric $primaryFabric
    $protectionCluster = get-ASRReplicationProtectionCluster -ProtectionContainer $protectionContainer -Name $clusterName

    $CommitFailoverJob = Start-AzRecoveryServicesAsrClusterCommitFailoverJob -ReplicationProtectionCluster $protectionCluster  

    WaitForJobCompletion -JobId $CommitFailoverJob.Name
    #Get recovery vm and verify
    $recvm = get-azVm -ResourceGroupName $recoveryResourceGroupName -Name "sdgql1"
    Assert-NotNull($recvm.Id);
}

<#
.SYNOPSIS
    NewA2ADiskReplicationConfiguration creation test.
#>

function Test-NewA2ADiskReplicationConfiguration {
    param([string] $seed = '106')

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
    $index = $RecoveryAzureNetworkId.IndexOf("/providers/")
    $recRg = $RecoveryAzureNetworkId.Substring(0, $index)

    #create primary
    $vmName = getAzureVmName
    $v2VmId = createAzureVm
    $logStg = createCacheStorageAccount
    $vm = get-azVm -ResourceGroupName $vmName -Name $vmName
    $vhdid = $vm.StorageProfile.OSDisk.ManagedDisk.Id
    $index = $v2VmId.IndexOf("/providers/")
    $Rg = $v2VmId.Substring(0, $index)
    $PrimaryAzureNetworkId = $Rg + "/providers/Microsoft.Network/virtualNetworks/" + $vmName

    # vault Creation
    New-AzResourceGroup -name $vaultRg -location $vaultRgLocation -force
    [Microsoft.Rest.ClientRuntime.Azure.TestFramework.TestUtilities]::Wait(20 * 1000)
    New-AzRecoveryServicesVault -ResourceGroupName $vaultRg -Name $vaultName -Location $vaultLocation
    [Microsoft.Rest.ClientRuntime.Azure.TestFramework.TestUtilities]::Wait(20 * 1000)
    $Vault = Get-AzRecoveryServicesVault -ResourceGroupName $vaultRg -Name $vaultName
    Set-ASRVaultContext -Vault $Vault

    # fabric Creation
    $fabJob = New-AzRecoveryServicesAsrFabric -Azure -Name $primaryFabricName -Location $primaryLocation
    WaitForJobCompletion -JobId $fabJob.Name
    $fab = Get-AzRecoveryServicesAsrFabric -Name $primaryFabricName
    Assert-true { $fab.name -eq $primaryFabricName }
    Assert-AreEqual $fab.FabricSpecificDetails.Location $primaryLocation

    $fabJob = New-AzRecoveryServicesAsrFabric -Azure -Name $recoveryFabricName -Location $recoveryLocation
    WaitForJobCompletion -JobId $fabJob.Name
    $fab = Get-AzRecoveryServicesAsrFabric -Name $recoveryFabricName
    Assert-true { $fab.name -eq $recoveryFabricName }
    Assert-AreEqual $fab.FabricSpecificDetails.Location $recoveryLocation
    $pf = get-asrFabric -Name $primaryFabricName
    $rf = get-asrFabric -Name $recoveryFabricName

    $recoveryStorageAccountId = "/subscriptions/7c943c1b-5122-4097-90c8-861411bdd574/resourceGroups/a2a-rg/providers/Microsoft.Storage/storageAccounts/a2argdisks412"
    $logStorageAccountId = "/subscriptions/7c943c1b-5122-4097-90c8-861411bdd574/resourceGroups/ltrgp1705152333/providers/Microsoft.Storage/storageAccounts/stagingsa2name1705152333"
    $vhdUri = "https://powershelltestdiag414.blob.core.windows.net/vhds/pslinV2-520180112143232.vhd"

    $v = New-AzRecoveryServicesAsrAzureToAzureDiskReplicationConfig -VhdUri  $vhdUri `
        -RecoveryAzureStorageAccountId $recoveryStorageAccountId `
        -LogStorageAccountId   $logStorageAccountId

    Assert-True { $v.vhdUri -eq $vhdUri }
    Assert-True { $v.recoveryAzureStorageAccountId -eq $recoveryStorageAccountId }
    Assert-True { $v.logStorageAccountId -eq $logStorageAccountId }
}


<#
.SYNOPSIS
    NewA2ADiskReplicationConfiguration creation test.
#>
function Test-NewA2AManagedDiskReplicationConfiguration {
     param([string] $seed = '105')

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
    $index = $RecoveryAzureNetworkId.IndexOf("/providers/")
    $recRg = $RecoveryAzureNetworkId.Substring(0, $index)

    #create primary
    $vmName = getAzureVmName
    $v2VmId = createAzureVm
    $logStg = createCacheStorageAccount
    $vm = get-azVm -ResourceGroupName $vmName -Name $vmName
    $vhdid = $vm.StorageProfile.OSDisk.ManagedDisk.Id
    $index = $v2VmId.IndexOf("/providers/")
    $Rg = $v2VmId.Substring(0, $index)
    $PrimaryAzureNetworkId = $Rg + "/providers/Microsoft.Network/virtualNetworks/" + $vmName

    # vault Creation
    New-AzResourceGroup -name $vaultRg -location $vaultRgLocation -force
    [Microsoft.Rest.ClientRuntime.Azure.TestFramework.TestUtilities]::Wait(20 * 1000)
    New-AzRecoveryServicesVault -ResourceGroupName $vaultRg -Name $vaultName -Location $vaultLocation
    [Microsoft.Rest.ClientRuntime.Azure.TestFramework.TestUtilities]::Wait(20 * 1000)
    $Vault = Get-AzRecoveryServicesVault -ResourceGroupName $vaultRg -Name $vaultName
    Set-ASRVaultContext -Vault $Vault

    # fabric Creation
    $fabJob = New-AzRecoveryServicesAsrFabric -Azure -Name $primaryFabricName -Location $primaryLocation
    WaitForJobCompletion -JobId $fabJob.Name
    $fab = Get-AzRecoveryServicesAsrFabric -Name $primaryFabricName
    Assert-true { $fab.name -eq $primaryFabricName }
    Assert-AreEqual $fab.FabricSpecificDetails.Location $primaryLocation

    $fabJob = New-AzRecoveryServicesAsrFabric -Azure -Name $recoveryFabricName -Location $recoveryLocation
    WaitForJobCompletion -JobId $fabJob.Name
    $fab = Get-AzRecoveryServicesAsrFabric -Name $recoveryFabricName
    Assert-true { $fab.name -eq $recoveryFabricName }
    Assert-AreEqual $fab.FabricSpecificDetails.Location $recoveryLocation
    $pf = get-asrFabric -Name $primaryFabricName
    $rf = get-asrFabric -Name $recoveryFabricName

    $logStorageAccountId = "fdd"
    $DiskId = "diskId"
    $RecoveryResourceGroupId = "3"
    $RecoveryReplicaDiskAccountType = "Premium_LRS"
    $RecoveryTargetDiskAccountType = "Premium_LRS"

    $v = New-AzRecoveryServicesAsrAzureToAzureDiskReplicationConfig -ManagedDisk -LogStorageAccountId $logStorageAccountId `
        -DiskId "diskId" -RecoveryResourceGroupId  $RecoveryResourceGroupId -RecoveryReplicaDiskAccountType  $RecoveryReplicaDiskAccountType `
        -RecoveryTargetDiskAccountType $RecoveryTargetDiskAccountType

    Assert-True { $v.LogStorageAccountId -eq $LogStorageAccountId }
    Assert-True { $v.DiskId -eq $DiskId }
    Assert-True { $v.RecoveryResourceGroupId -eq $RecoveryResourceGroupId }
}

<#
.SYNOPSIS
    NewA2ADiskReplicationConfiguration for CMK vms creation test.
#>
function Test-NewA2AManagedDiskReplicationConfigurationWithCmk {
    param([string] $seed = '104')

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
    $index = $RecoveryAzureNetworkId.IndexOf("/providers/")
    $recRg = $RecoveryAzureNetworkId.Substring(0, $index)

    #create primary
    $vmName = getAzureVmName
    $v2VmId = createAzureVm
    $logStg = createCacheStorageAccount
    $vm = get-azVm -ResourceGroupName $vmName -Name $vmName
    $vhdid = $vm.StorageProfile.OSDisk.ManagedDisk.Id
    $index = $v2VmId.IndexOf("/providers/")
    $Rg = $v2VmId.Substring(0, $index)
    $PrimaryAzureNetworkId = $Rg + "/providers/Microsoft.Network/virtualNetworks/" + $vmName

    # vault Creation
    New-AzResourceGroup -name $vaultRg -location $vaultRgLocation -force
    [Microsoft.Rest.ClientRuntime.Azure.TestFramework.TestUtilities]::Wait(20 * 1000)
    New-AzRecoveryServicesVault -ResourceGroupName $vaultRg -Name $vaultName -Location $vaultLocation
    [Microsoft.Rest.ClientRuntime.Azure.TestFramework.TestUtilities]::Wait(20 * 1000)
    $Vault = Get-AzRecoveryServicesVault -ResourceGroupName $vaultRg -Name $vaultName
    Set-ASRVaultContext -Vault $Vault

    # fabric Creation    
    $fabJob = New-AzRecoveryServicesAsrFabric -Azure -Name $primaryFabricName -Location $primaryLocation
    WaitForJobCompletion -JobId $fabJob.Name
    $fab = Get-AzRecoveryServicesAsrFabric -Name $primaryFabricName
    Assert-true { $fab.name -eq $primaryFabricName }
    Assert-AreEqual $fab.FabricSpecificDetails.Location $primaryLocation

    $fabJob = New-AzRecoveryServicesAsrFabric -Azure -Name $recoveryFabricName -Location $recoveryLocation
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

    $v = New-AzRecoveryServicesAsrAzureToAzureDiskReplicationConfig -ManagedDisk -LogStorageAccountId $logStg `
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
    $fabJob = New-AzRecoveryServicesAsrFabric -Azure -Name $primaryFabricName -Location $primaryLocation
    WaitForJobCompletion -JobId $fabJob.Name
    $fab = Get-AzRecoveryServicesAsrFabric -Name $primaryFabricName
    Assert-true { $fab.name -eq $primaryFabricName }
    Assert-AreEqual $fab.FabricSpecificDetails.Location $primaryLocation
}


function Test-NewContainer {

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
    $fabJob = New-AzRecoveryServicesAsrFabric -Azure -Name $primaryFabricName -Location $primaryLocation
    WaitForJobCompletion -JobId $fabJob.Name
    $fab = Get-AzRecoveryServicesAsrFabric -Name $primaryFabricName
    Assert-true { $fab.name -eq $primaryFabricName }
    Assert-AreEqual $fab.FabricSpecificDetails.Location $primaryLocation

    $fabJob = New-AzRecoveryServicesAsrFabric -Azure -Name $recoveryFabricName -Location $recoveryLocation
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

function Test-RemoveReplicationProtectedItemDisk {
    param([string] $seed = '1022')
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
    $index = $RecoveryAzureNetworkId.IndexOf("/providers/")
    $recRg = $RecoveryAzureNetworkId.Substring(0, $index)

    #create primary
    $vmName = getAzureVmName
    $v2VmId = createAzureVm
    $logStg = createCacheStorageAccount
    $vm = get-azVm -ResourceGroupName $vmName -Name $vmName
    $vhdid = $vm.StorageProfile.OSDisk.ManagedDisk.Id
    $index = $v2VmId.IndexOf("/providers/")
    $Rg = $v2VmId.Substring(0, $index)
    $PrimaryAzureNetworkId = $Rg + "/providers/Microsoft.Network/virtualNetworks/" + $vmName

    # vault Creation
    New-AzResourceGroup -name $vaultRg -location $vaultRgLocation -force
    [Microsoft.Rest.ClientRuntime.Azure.TestFramework.TestUtilities]::Wait(20 * 1000)
    New-AzRecoveryServicesVault -ResourceGroupName $vaultRg -Name $vaultName -Location $vaultLocation
    [Microsoft.Rest.ClientRuntime.Azure.TestFramework.TestUtilities]::Wait(20 * 1000)
    $Vault = Get-AzRecoveryServicesVault -ResourceGroupName $vaultRg -Name $vaultName
    Set-ASRVaultContext -Vault $Vault

    # fabric Creation    
    $fabJob = New-AzRecoveryServicesAsrFabric -Azure -Name $primaryFabricName -Location $primaryLocation
    WaitForJobCompletion -JobId $fabJob.Name
    $fab = Get-AzRecoveryServicesAsrFabric -Name $primaryFabricName
    Assert-true { $fab.name -eq $primaryFabricName }
    Assert-AreEqual $fab.FabricSpecificDetails.Location $primaryLocation

    $fabJob = New-AzRecoveryServicesAsrFabric -Azure -Name $recoveryFabricName -Location $recoveryLocation
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
    $v = New-AzRecoveryServicesAsrAzureToAzureDiskReplicationConfig -ManagedDisk -LogStorageAccountId $logStg `
        -DiskId $vhdid -RecoveryResourceGroupId  $recRg -RecoveryReplicaDiskAccountType  $RecoveryReplicaDiskAccountType `
        -RecoveryTargetDiskAccountType $RecoveryTargetDiskAccountType
    $enableDRjob = New-AzRecoveryServicesAsrReplicationProtectedItem -AzureToAzure -AzureVmId $v2VmId -Name $vmName  -ProtectionContainerMapping $mapping -RecoveryResourceGroupId  $recRg -AzureToAzureDiskReplicationConfiguration $v
    [Microsoft.Rest.ClientRuntime.Azure.TestFramework.TestUtilities]::Wait(20 * 1000)
    [Microsoft.Rest.ClientRuntime.Azure.TestFramework.TestUtilities]::Wait(20 * 1000)
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
    do {
        $pe = Get-AzRecoveryServicesAsrReplicationProtectedItem -ProtectionContainer $pc -Name  $vmName
        $healthError = $pe.ReplicationHealthErrors | Where-Object { $_.ErrorCode -eq 153039 }

        if ($healthError -eq $null) {
            Write-Host $("Waiting for Add-Disk health warning...") -ForegroundColor Yellow
            Write-Host $("Waiting for: " + $HealthQueryWaitTimeInSeconds.ToString + " Seconds") -ForegroundColor Yellow
            [Microsoft.Rest.ClientRuntime.Azure.TestFramework.TestUtilities]::Wait($HealthQueryWaitTimeInSeconds * 1000)
        }
    }While ($healthError -eq $null)

    #add disks
    $storageAccountName = "cachedisk1"
    $storageAccount = New-AzStorageAccount -ResourceGroupName $vmName -Location $primaryLocation  -Name $storageAccountName -Type 'Standard_LRS'
    $disk2 =	New-AzRecoveryServicesAsrAzureToAzureDiskReplicationConfig -DiskId $newDisk.Id -LogStorageAccountId   $storageAccount.Id -ManagedDisk  -RecoveryReplicaDiskAccountType $RecoveryReplicaDiskAccountType -RecoveryResourceGroupId $pe.ProviderSpecificDetails.A2ADiskDetails[0].RecoveryResourceGroupId -RecoveryTargetDiskAccountType $RecoveryTargetDiskAccountType
    $addDRjob = Add-AzRecoveryServicesAsrReplicationProtectedItemDisk -ReplicationProtectedItem $pe -AzureToAzureDiskReplicationConfiguration $disk2
    WaitForJobCompletion -JobId $addDRjob.Name

    #get disk to deattach
    Remove-AzStorageAccount -ResourceGroupName $vmName -Name $storageAccountName
    WaitForAddDisksIRCompletion -affectedObjectId $addDRjob.TargetObjectId -JobQueryWaitTimeInSeconds 10 -IsExpectedToPass $false
    [Microsoft.Rest.ClientRuntime.Azure.TestFramework.TestUtilities]::Wait(20 * 1000)

    $pe = Get-AzRecoveryServicesAsrReplicationProtectedItem -ProtectionContainer $pc -Name  $vmName
    $removeDisk = $pe.ProviderSpecificDetails.A2ADiskDetails | Where-Object { $_.AllowedDiskLevelOperations.Count -ne 0 }

    Assert-NotNull($removeDisk)
    $vm = get-azVm -ResourceGroupName $vmName -Name $vmName
    $removeDiskObj = $vm.StorageProfile.DataDisks | Where-Object { $_.Name -eq $removeDisk.DiskName }
    $removeDRjob = Remove-AzRecoveryServicesAsrReplicationProtectedItemDisk -ReplicationProtectedItem $pe -DiskId $removeDiskObj.ManagedDisk.Id
    WaitForJobCompletion -JobId $removeDRjob.Name

    $pe = Get-AzRecoveryServicesAsrReplicationProtectedItem -ProtectionContainer $pc -Name  $vmName
    Assert-NotNull($pe)
}

<#
.SYNOPSIS 
    Test ReplicateProximityPlacementGroupVm new parametersets
#>

function Test-ReplicateProximityPlacementGroupVm {
    param([string] $seed = '9100')
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
    $recMappingName = getRecoveryContainerMapping
    $primaryNetMapping = getPrimaryNetworkMapping
    $recoveryNetMapping = getRecoveryNetworkMapping

    #create recovery side resources
    $recRgName = getRecoveryResourceGroupName
    New-AzResourceGroup -name $recRgName -location $recoveryLocation -force
    [Microsoft.Rest.ClientRuntime.Azure.TestFramework.TestUtilities]::Wait(20 * 1000)
    $RecoveryAzureNetworkId = createRecoveryNetworkId 
    $index = $RecoveryAzureNetworkId.IndexOf("/providers/")
    $recRg = $RecoveryAzureNetworkId.Substring(0, $index)
    #create proximity placement group
    $recPpg = New-AzProximityPlacementGroup -ResourceGroupName $recRgName -Name "PPG1-asr" -Location $recoveryLocation
    $recPpg1 = New-AzProximityPlacementGroup -ResourceGroupName $recRgName -Name "PPG2-asr" -Location $recoveryLocation

    #create primary
    $vmName = getAzureVmName
    New-AzResourceGroup -name $vmName -location $primaryLocation -force
    [Microsoft.Rest.ClientRuntime.Azure.TestFramework.TestUtilities]::Wait(20 * 1000)
    $logStg = createCacheStorageAccount
    $recLogStg = createRecoveryCacheStorageAccount

    $v2VmId = createAzureVmInProximityPlacementgroup
    $vm = get-azVm -ResourceGroupName $vmName -Name $vmName
    $vhdid = $vm.StorageProfile.OSDisk.ManagedDisk.Id
    $index = $vm.Id.IndexOf("/providers/")
    $Rg = $vm.Id.Substring(0, $index)
    $PrimaryAzureNetworkId = $Rg + "/providers/Microsoft.Network/virtualNetworks/" + $vmName

    # vault Creation
    New-AzResourceGroup -name $vaultRg -location $vaultRgLocation -force
    [Microsoft.Rest.ClientRuntime.Azure.TestFramework.TestUtilities]::Wait(20 * 1000)
    New-AzRecoveryServicesVault -ResourceGroupName $vaultRg -Name $vaultName -Location $vaultLocation
    [Microsoft.Rest.ClientRuntime.Azure.TestFramework.TestUtilities]::Wait(20 * 1000)
    $Vault = Get-AzRecoveryServicesVault -ResourceGroupName $vaultRg -Name $vaultName
    Set-ASRVaultContext -Vault $Vault

    # fabric Creation    
    $fabJob = New-AzRecoveryServicesAsrFabric -Azure -Name $primaryFabricName -Location $primaryLocation
    WaitForJobCompletion -JobId $fabJob.Name
    $fab = Get-AzRecoveryServicesAsrFabric -Name $primaryFabricName
    Assert-true { $fab.name -eq $primaryFabricName }
    Assert-AreEqual $fab.FabricSpecificDetails.Location $primaryLocation

    $fabJob = New-AzRecoveryServicesAsrFabric -Azure -Name $recoveryFabricName -Location $recoveryLocation
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

    #Reverse Container mapping
    $job = New-AzRecoveryServicesAsrProtectionContainerMapping -Name $recMappingName -Policy $policy -PrimaryProtectionContainer $rc -RecoveryProtectionContainer $pc
    WaitForJobCompletion -JobId $job.Name
    $revMapping = Get-AzRecoveryServicesAsrProtectionContainerMapping -Name $recMappingName -ProtectionContainer $rc  

    #Reverse network mapping
    $job = New-AzRecoveryServicesAsrNetworkMapping -AzureToAzure -Name $recoveryNetMapping -PrimaryFabric $rf -PrimaryAzureNetworkId $RecoveryAzureNetworkId -RecoveryFabric $pf -RecoveryAzureNetworkId $PrimaryAzureNetworkId
    WaitForJobCompletion -JobId $job.Name

    #enable Replication
    $v = New-AzRecoveryServicesAsrAzureToAzureDiskReplicationConfig -ManagedDisk -LogStorageAccountId $logStg `
        -DiskId $vhdid -RecoveryResourceGroupId  $recRg -RecoveryReplicaDiskAccountType  $RecoveryReplicaDiskAccountType `
        -RecoveryTargetDiskAccountType $RecoveryTargetDiskAccountType
    $enableDRjob = New-AzRecoveryServicesAsrReplicationProtectedItem -AzureToAzure -AzureVmId $vm.Id -Name $vmName  -ProtectionContainerMapping $mapping -RecoveryResourceGroupId  $recRg -AzureToAzureDiskReplicationConfiguration $v -RecoveryProximityPlacementGroupId $recPpg.Id
    WaitForJobCompletion -JobId $enableDRjob.Name
    WaitForIRCompletion -affectedObjectId $enableDRjob.TargetObjectId

    #Validate PPG Set in replicated vm properties
    $pe = Get-AzRecoveryServicesAsrReplicationProtectedItem -ProtectionContainer $pc -Name  $vmName
    Assert-NotNull($pe.providerSpecificDetails.RecoveryProximityPlacementGroupId)

    #Update Vmproperties
    $updateDRjob = Set-AzRecoveryServicesAsrReplicationProtectedItem -InputObject $pe -RecoveryProximityPlacementGroupId $recPpg1.Id
    WaitForJobCompletion -JobId $updateDRjob.Name
    $pe = Get-AzRecoveryServicesAsrReplicationProtectedItem -ProtectionContainer $pc -Name  $vmName
    Assert-NotNull($pe.providerSpecificDetails.RecoveryProximityPlacementGroupId)

    #Failover
    $failoverjob = Start-AzRecoveryServicesAsrUnPlannedFailoverJob -ReplicationProtectedItem $pe -Direction PrimaryToRecovery -PerformSourceSideAction
    WaitForJobCompletion -JobId $failoverjob.Name
    #Get recovery vm and verify
    $recvm = get-azVm -ResourceGroupName $recRgName -Name $vmName
    Assert-NotNull($recvm.ProximityPlacementGroup.Id);

    #Switch replication
    $vm = get-azVm -ResourceGroupName $vmName -Name $vmName
    $vhdid = $recvm.StorageProfile.OSDisk.ManagedDisk.Id
    $v = New-AzRecoveryServicesAsrAzureToAzureDiskReplicationConfig -ManagedDisk -LogStorageAccountId $recLogStg `
        -DiskId $vhdid -RecoveryResourceGroupId  $Rg -RecoveryReplicaDiskAccountType  $RecoveryReplicaDiskAccountType `
        -RecoveryTargetDiskAccountType $RecoveryTargetDiskAccountType
    [Microsoft.Rest.ClientRuntime.Azure.TestFramework.TestUtilities]::Wait(600 * 1000)
    $Switchjob = Update-AzureRmRecoveryServicesAsrProtectionDirection -AzureToAzure  -ProtectionContainerMapping $revMapping[0]  -RecoveryResourceGroupId $Rg  -ReplicationProtectedItem $pe -RecoveryProximityPlacementGroupId $vm.ProximityPlacementGroup.Id -AzureToAzureDiskReplicationConfiguration $v
    WaitForJobCompletion -JobId $Switchjob.Name

    $pe = Get-AzRecoveryServicesAsrReplicationProtectedItem -ProtectionContainer $rc -Name  $vmName
    Assert-NotNull($pe.providerSpecificDetails.RecoveryProximityPlacementGroupId)
}

<#
.SYNOPSIS 
    Test VMNicConfig new parametersets
#>

function Test-VMNicConfig {
    param([string] $seed = '330')
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
    $recMappingName = getRecoveryContainerMapping
    $primaryNetMapping = getPrimaryNetworkMapping
    $recoveryNetMapping = getRecoveryNetworkMapping

    #create recovery side resources
    $recRgName = getRecoveryResourceGroupName
    New-AzResourceGroup -name $recRgName -location $recoveryLocation -force
    [Microsoft.Rest.ClientRuntime.Azure.TestFramework.TestUtilities]::Wait(20 * 1000)
    $RecoveryAzureNetworkId = createRecoveryNetworkId 
    $index = $RecoveryAzureNetworkId.IndexOf("/providers/")
    $recRg = $RecoveryAzureNetworkId.Substring(0, $index)

    #create primary
    $vmName = getAzureVmName
    New-AzResourceGroup -name $vmName -location $primaryLocation -force
    [Microsoft.Rest.ClientRuntime.Azure.TestFramework.TestUtilities]::Wait(20 * 1000)
    $logStg = createCacheStorageAccount
    $recLogStg = createRecoveryCacheStorageAccount

    $v2VmId = createAzureVm
    $vm = get-azVm -ResourceGroupName $vmName -Name $vmName
    $vhdid = $vm.StorageProfile.OSDisk.ManagedDisk.Id
    $index = $vm.Id.IndexOf("/providers/")
    $Rg = $vm.Id.Substring(0, $index)
    $PrimaryAzureNetworkId = $Rg + "/providers/Microsoft.Network/virtualNetworks/" + $vmName

    # vault Creation
    New-AzResourceGroup -name $vaultRg -location $vaultRgLocation -force
    [Microsoft.Rest.ClientRuntime.Azure.TestFramework.TestUtilities]::Wait(20 * 1000)
    New-AzRecoveryServicesVault -ResourceGroupName $vaultRg -Name $vaultName -Location $vaultLocation
    [Microsoft.Rest.ClientRuntime.Azure.TestFramework.TestUtilities]::Wait(20 * 1000)
    $Vault = Get-AzRecoveryServicesVault -ResourceGroupName $vaultRg -Name $vaultName
    Set-ASRVaultContext -Vault $Vault

    # fabric Creation    
    $fabJob = New-AzRecoveryServicesAsrFabric -Azure -Name $primaryFabricName -Location $primaryLocation
    WaitForJobCompletion -JobId $fabJob.Name
    $fab = Get-AzRecoveryServicesAsrFabric -Name $primaryFabricName
    Assert-true { $fab.name -eq $primaryFabricName }
    Assert-AreEqual $fab.FabricSpecificDetails.Location $primaryLocation

    $fabJob = New-AzRecoveryServicesAsrFabric -Azure -Name $recoveryFabricName -Location $recoveryLocation
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

    #Reverse Container mapping
    $job = New-AzRecoveryServicesAsrProtectionContainerMapping -Name $recMappingName -Policy $policy -PrimaryProtectionContainer $rc -RecoveryProtectionContainer $pc
    WaitForJobCompletion -JobId $job.Name
    $revMapping = Get-AzRecoveryServicesAsrProtectionContainerMapping -Name $recMappingName -ProtectionContainer $rc  

    #Reverse network mapping
    $job = New-AzRecoveryServicesAsrNetworkMapping -AzureToAzure -Name $recoveryNetMapping -PrimaryFabric $rf -PrimaryAzureNetworkId $RecoveryAzureNetworkId -RecoveryFabric $pf -RecoveryAzureNetworkId $PrimaryAzureNetworkId
    WaitForJobCompletion -JobId $job.Name

    #enable Replication
    $v = New-AzRecoveryServicesAsrAzureToAzureDiskReplicationConfig -ManagedDisk -LogStorageAccountId $logStg `
        -DiskId $vhdid -RecoveryResourceGroupId  $recRg -RecoveryReplicaDiskAccountType  $RecoveryReplicaDiskAccountType `
        -RecoveryTargetDiskAccountType $RecoveryTargetDiskAccountType
    $enableDRjob = New-AzRecoveryServicesAsrReplicationProtectedItem -AzureToAzure -AzureVmId $vm.Id -Name $vmName  -ProtectionContainerMapping $mapping -RecoveryResourceGroupId  $recRg -AzureToAzureDiskReplicationConfiguration $v
    WaitForJobCompletion -JobId $enableDRjob.Name
    WaitForIRCompletion -affectedObjectId $enableDRjob.TargetObjectId

    #Validate PE
    $pe = Get-AzRecoveryServicesAsrReplicationProtectedItem -ProtectionContainer $pc -Name  $vmName
    Assert-NotNull($pe)

    #Update VM Nic properties
    $pe = Get-AzRecoveryServicesAsrReplicationProtectedItem -ProtectionContainer $pc -Name  $vmName
    $nicId = $pe.NicDetailsList[0].NicId
    $ipConfigName = $pe.NicDetailsList[0].IpConfigs[0].Name
    $recSubnetName = $pe.NicDetailsList[0].IpConfigs[0].RecoverySubnetName
    $recNicName = getRecoveryNicName

    $ipConfig = New-AzRecoveryServicesAsrVMNicIPConfig -IpConfigName $ipConfigName -RecoverySubnetName $recSubnetName -RecoveryStaticIPAddress ""
    $ipConfigs = @($ipConfig)
    $nicConfig = New-AzRecoveryServicesAsrVMNicConfig -NicId $nicId -ReplicationProtectedItem $pe -RecoveryVMNetworkId $RecoveryAzureNetworkId -RecoveryNicName $recNicName -RecoveryNicResourceGroupName $recRgName -ReuseExistingNic -IPConfig $ipConfigs

    $updateDRjob = Set-AzRecoveryServicesAsrReplicationProtectedItem -InputObject $pe -ASRVMNicConfiguration $nicConfig
    WaitForJobCompletion -JobId $updateDRjob.Name
    $pe = Get-AzRecoveryServicesAsrReplicationProtectedItem -ProtectionContainer $pc -Name  $vmName
    Assert-NotNull($pe.NicDetailsList[0].RecoveryNicName)
    Assert-NotNull($pe.NicDetailsList[0].RecoveryNicResourceGroupName)
    Assert-NotNull($pe.NicDetailsList[0].ReuseExistingNic)
        
    #Failover
    $failoverjob = Start-AzRecoveryServicesAsrUnPlannedFailoverJob -ReplicationProtectedItem $pe -Direction PrimaryToRecovery -PerformSourceSideAction
    WaitForJobCompletion -JobId $failoverjob.Name
}

<#
.SYNOPSIS 
    Test EdgeZoneToAzureRecoveryPlanReplication new parametersets
#>

function Test-EdgeZoneToAzureRecoveryPlanReplication {
    param([string] $seed = '348')
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
    $primaryLocation = getLocationForEZScenario
    $recoveryLocation = getLocationForEZScenario
    $primaryExtendedLocation = getPrimaryExtendedLocation
    $recoveryExtendedLocation = getRecoveryExtendedLocation
    $primaryFabricName = getPrimaryFabric
    $RecoveryReplicaDiskAccountType = "Premium_LRS"
    $RecoveryTargetDiskAccountType = "Premium_LRS"
    $policyName = getPrimaryPolicy
    $mappingName = getPrimaryContainerMapping
    $RecoveryPlanName = getRecoveryPlanName

    #create recovery side resources
    $recRgName = getRecoveryResourceGroupName
    New-AzResourceGroup -name $recRgName -location $recoveryLocation -force
    [Microsoft.Rest.ClientRuntime.Azure.TestFramework.TestUtilities]::Wait(20 * 1000)
    # Create recovery network in Azure
    $RecoveryAzureNetworkId = createRecoveryNetworkId -Location $primaryLocation
    $index = $RecoveryAzureNetworkId.IndexOf("/providers/")
    $recRg = $RecoveryAzureNetworkId.Substring(0, $index)

    #create primary
    $vmName = getAzureVmName
    New-AzResourceGroup -name $vmName -location $primaryLocation -force
    [Microsoft.Rest.ClientRuntime.Azure.TestFramework.TestUtilities]::Wait(20 * 1000)
    $logStg = createCacheStorageAccount -Location $primaryLocation

    $v2VmId = createAzureVmInEdgeZone -PrimaryLocation $primaryLocation -PrimaryExtendedLocation $primaryExtendedLocation
    $vm = get-azVm -ResourceGroupName $vmName -Name $vmName
    $vhdid = $vm.StorageProfile.OSDisk.ManagedDisk.Id
    $index = $vm.Id.IndexOf("/providers/")
    $Rg = $vm.Id.Substring(0, $index)
    $PrimaryAzureNetworkId = $Rg + "/providers/Microsoft.Network/virtualNetworks/" + $vmName

    # vault Creation
    New-AzResourceGroup -name $vaultRg -location $vaultRgLocation -force
    [Microsoft.Rest.ClientRuntime.Azure.TestFramework.TestUtilities]::Wait(20 * 1000)
    New-AzRecoveryServicesVault -ResourceGroupName $vaultRg -Name $vaultName -Location $vaultLocation
    [Microsoft.Rest.ClientRuntime.Azure.TestFramework.TestUtilities]::Wait(20 * 1000)
    $Vault = Get-AzRecoveryServicesVault -ResourceGroupName $vaultRg -Name $vaultName
    Set-ASRVaultContext -Vault $Vault

    # fabric Creation    
    $fabJob = New-AzRecoveryServicesAsrFabric -Azure -Name $primaryFabricName -Location $primaryLocation
    WaitForJobCompletion -JobId $fabJob.Name
    $fab = Get-AzRecoveryServicesAsrFabric -Name $primaryFabricName
    Assert-true { $fab.name -eq $primaryFabricName }
    Assert-AreEqual $fab.FabricSpecificDetails.Location $primaryLocation

    $pf = get-asrFabric -Name $primaryFabricName
        
    #Container creation
    $job = New-AzRecoveryServicesAsrProtectionContainer -Name $primaryContainerName -Fabric $pf
    WaitForJobCompletion -JobId $Job.Name
    $pc = Get-asrProtectionContainer -name $primaryContainerName -Fabric $pf
    Assert-NotNull($pc)
    $job = New-AzRecoveryServicesAsrProtectionContainer -Name $recoveryContainerName -Fabric $pf
    WaitForJobCompletion -JobId $Job.Name
    $rc = Get-asrProtectionContainer -name $recoveryContainerName -Fabric $pf
    Assert-NotNull($rc)

    #create policy and mapping
    $job = New-AzRecoveryServicesAsrPolicy -Name $policyName  -RecoveryPointRetentionInHours 12 -AzureToAzure 
    WaitForJobCompletion -JobId $job.Name
    $policy = Get-AzRecoveryServicesAsrPolicy  -Name $policyName
    $job = New-AzRecoveryServicesAsrProtectionContainerMapping -Name $mappingName -Policy $policy -PrimaryProtectionContainer $pc -RecoveryProtectionContainer $rc
    WaitForJobCompletion -JobId $job.Name
    $mapping = Get-AzRecoveryServicesAsrProtectionContainerMapping -Name $mappingName -ProtectionContainer $pc 

    #enable Replication
    $v = New-AzRecoveryServicesAsrAzureToAzureDiskReplicationConfig -ManagedDisk -LogStorageAccountId $logStg `
        -DiskId $vhdid -RecoveryResourceGroupId  $recRg -RecoveryReplicaDiskAccountType  $RecoveryReplicaDiskAccountType `
        -RecoveryTargetDiskAccountType $RecoveryTargetDiskAccountType
    $enableDRjob = New-AzRecoveryServicesAsrReplicationProtectedItem -AzureToAzure -AzureVmId $vm.Id -Name $vmName  -ProtectionContainerMapping $mapping -RecoveryResourceGroupId  $recRg -AzureToAzureDiskReplicationConfiguration $v -RecoveryAzureNetworkId $RecoveryAzureNetworkId -RecoveryAzureSubnetName "frontendSubnet"
    WaitForJobCompletion -JobId $enableDRjob.Name
    WaitForIRCompletion -affectedObjectId $enableDRjob.TargetObjectId

    $pe = Get-AzRecoveryServicesAsrReplicationProtectedItem -ProtectionContainer $pc -Name  $vmName
    Assert-NotNull($pe)

    #Create Recovery Plan
    $createRecoveryJob = New-AzRecoveryServicesAsrRecoveryPlan -EdgeZoneToAzure -Name $RecoveryPlanName -PrimaryFabric $pf -ReplicationProtectedItem $pe -PrimaryEdgeZone $primaryExtendedLocation
    WaitForJobCompletion -JobId $createRecoveryJob.Name

    #Get Recovery Plan
    $RecoveryPlan = Get-AzRecoveryServicesAsrRecoveryPlan -Name $RecoveryPlanName 
    Assert-NotNull($RecoveryPlan)

    #Failover
    $failoverjob = Start-AzRecoveryServicesAsrUnPlannedFailoverJob -RecoveryPlan $RecoveryPlan -Direction PrimaryToRecovery -PerformSourceSideAction
    WaitForJobCompletion -JobId $failoverjob.Name
    #Get recovery vm and verify
    $recvm = get-azVm -ResourceGroupName $recRgName -Name $vmName
    Assert-Null($recvm.Zones);
    Assert-Null($recvm.ExtendedLocation);

    $pe = Get-AzRecoveryServicesAsrReplicationProtectedItem -ProtectionContainer $pc -Name $vmName
    Assert-NotNull($pe)

    #Get Recovery Plan
    $RecoveryPlan = Get-AzRecoveryServicesAsrRecoveryPlan -Name $RecoveryPlanName 
    Assert-NotNull($RecoveryPlan)
}

<#
.SYNOPSIS 
    Test EdgeZoneToEdgeZoneRecoveryPlanReplication new parametersets
#>

function Test-EdgeZoneToEdgeZoneRecoveryPlanReplication {
    param([string] $seed = '349')
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
    $primaryLocation = getLocationForEZScenario
    $recoveryLocation = getLocationForEZScenario
    $primaryExtendedLocation = getPrimaryExtendedLocation
    $recoveryExtendedLocation = getRecoveryExtendedLocation
    $primaryFabricName = getPrimaryFabric
    $RecoveryReplicaDiskAccountType = "Premium_LRS"
    $RecoveryTargetDiskAccountType = "Premium_LRS"
    $policyName = getPrimaryPolicy
    $mappingName = getPrimaryContainerMapping
    $RecoveryPlanName = getRecoveryPlanName

    #create recovery side resources
    $recRgName = getRecoveryResourceGroupName
    New-AzResourceGroup -name $recRgName -location $recoveryLocation -force
    [Microsoft.Rest.ClientRuntime.Azure.TestFramework.TestUtilities]::Wait(20 * 1000)
    # Create recovery network in Azure
    $RecoveryAzureNetworkId = createRecoveryNetworkIdForEdgeZone -Location $primaryLocation -EdgeZone $recoveryExtendedLocation
    $index = $RecoveryAzureNetworkId.IndexOf("/providers/")
    $recRg = $RecoveryAzureNetworkId.Substring(0, $index)

    #create primary
    $vmName = getAzureVmName
    New-AzResourceGroup -name $vmName -location $primaryLocation -force
    [Microsoft.Rest.ClientRuntime.Azure.TestFramework.TestUtilities]::Wait(20 * 1000)
    $logStg = createCacheStorageAccount -Location $primaryLocation

    $v2VmId = createAzureVmInEdgeZone -PrimaryLocation $primaryLocation -PrimaryExtendedLocation $primaryExtendedLocation
    $vm = get-azVm -ResourceGroupName $vmName -Name $vmName
    $vhdid = $vm.StorageProfile.OSDisk.ManagedDisk.Id
    $index = $vm.Id.IndexOf("/providers/")
    $Rg = $vm.Id.Substring(0, $index)
    $PrimaryAzureNetworkId = $Rg + "/providers/Microsoft.Network/virtualNetworks/" + $vmName

    # vault Creation
    New-AzResourceGroup -name $vaultRg -location $vaultRgLocation -force
    [Microsoft.Rest.ClientRuntime.Azure.TestFramework.TestUtilities]::Wait(20 * 1000)
    New-AzRecoveryServicesVault -ResourceGroupName $vaultRg -Name $vaultName -Location $vaultLocation
    [Microsoft.Rest.ClientRuntime.Azure.TestFramework.TestUtilities]::Wait(20 * 1000)
    $Vault = Get-AzRecoveryServicesVault -ResourceGroupName $vaultRg -Name $vaultName
    Set-ASRVaultContext -Vault $Vault

    # fabric Creation    
    $fabJob = New-AzRecoveryServicesAsrFabric -Azure -Name $primaryFabricName -Location $primaryLocation
    WaitForJobCompletion -JobId $fabJob.Name
    $fab = Get-AzRecoveryServicesAsrFabric -Name $primaryFabricName
    Assert-true { $fab.name -eq $primaryFabricName }
    Assert-AreEqual $fab.FabricSpecificDetails.Location $primaryLocation

    $pf = get-asrFabric -Name $primaryFabricName
        
    #Container creation
    $job = New-AzRecoveryServicesAsrProtectionContainer -Name $primaryContainerName -Fabric $pf
    WaitForJobCompletion -JobId $Job.Name
    $pc = Get-asrProtectionContainer -name $primaryContainerName -Fabric $pf
    Assert-NotNull($pc)
    $job = New-AzRecoveryServicesAsrProtectionContainer -Name $recoveryContainerName -Fabric $pf
    WaitForJobCompletion -JobId $Job.Name
    $rc = Get-asrProtectionContainer -name $recoveryContainerName -Fabric $pf
    Assert-NotNull($rc)

    #create policy and mapping
    $job = New-AzRecoveryServicesAsrPolicy -Name $policyName  -RecoveryPointRetentionInHours 12 -AzureToAzure 
    WaitForJobCompletion -JobId $job.Name
    $policy = Get-AzRecoveryServicesAsrPolicy  -Name $policyName
    $job = New-AzRecoveryServicesAsrProtectionContainerMapping -Name $mappingName -Policy $policy -PrimaryProtectionContainer $pc -RecoveryProtectionContainer $rc
    WaitForJobCompletion -JobId $job.Name
    $mapping = Get-AzRecoveryServicesAsrProtectionContainerMapping -Name $mappingName -ProtectionContainer $pc 

    #enable Replication
    $v = New-AzRecoveryServicesAsrAzureToAzureDiskReplicationConfig -ManagedDisk -LogStorageAccountId $logStg `
        -DiskId $vhdid -RecoveryResourceGroupId  $recRg -RecoveryReplicaDiskAccountType  $RecoveryReplicaDiskAccountType `
        -RecoveryTargetDiskAccountType $RecoveryTargetDiskAccountType
    $enableDRjob = New-AzRecoveryServicesAsrReplicationProtectedItem -AzureToAzure -AzureVmId $vm.Id -Name $vmName  -ProtectionContainerMapping $mapping -RecoveryResourceGroupId  $recRg -AzureToAzureDiskReplicationConfiguration $v -RecoveryAzureNetworkId $RecoveryAzureNetworkId -RecoveryAzureSubnetName "frontendSubnet" -RecoveryExtendedLocation $recoveryExtendedLocation
    WaitForJobCompletion -JobId $enableDRjob.Name
    WaitForIRCompletion -affectedObjectId $enableDRjob.TargetObjectId

    $pe = Get-AzRecoveryServicesAsrReplicationProtectedItem -ProtectionContainer $pc -Name  $vmName
    Assert-NotNull($pe)

    #Failover
    $failoverjob = Start-AzRecoveryServicesAsrUnPlannedFailoverJob -ReplicationProtectedItem $pe -Direction PrimaryToRecovery -PerformSourceSideAction
    WaitForJobCompletion -JobId $failoverjob.Name

    $CommitFailoverJob = Start-AzRecoveryServicesAsrCommitFailoverJob -ReplicationProtectedItem $pe
    (Get-AzRecoveryServicesAsrJob -Job $CommitFailoverJob).Tasks
    WaitForJobCompletion -JobId $CommitFailoverJob.Name

    #Get recovery vm and verify
    $recvm = get-azVm -ResourceGroupName $recRgName -Name $vmName
    Assert-Null($recvm.Zones);
    Assert-NotNull($recvm.ExtendedLocation);

    $pe = Get-AzRecoveryServicesAsrReplicationProtectedItem -ProtectionContainer $pc -Name $vmName
    Assert-NotNull($pe)
}

<#
.SYNOPSIS 
    Test EdgeZoneToAvailabilityZoneRecoveryPlanReplication new parametersets
#>

function Test-EdgeZoneToAvailabilityZoneRecoveryPlanReplication {
    param([string] $seed = '350')
    $primaryPolicyName = getPrimaryPolicy
    $recoveryPolicyName = getRecoveryPolicy
        
    $primaryContainerMappingName = getPrimaryContainerMapping
    $recoveryContainerMappingName = getRecoveryContainerMapping
        
    $primaryContainerName = getPrimaryContainer
    $recoveryContainerName = getRecoveryContainer
    $vaultRgLocation = getLocationForEZAzScenario
    $vaultName = getVaultName
    $vaultLocation = getLocationForEZAzScenario
    $vaultRg = getVaultRg
    $primaryLocation = getLocationForEZAzScenario
    $recoveryLocation = getLocationForEZAzScenario
    $primaryExtendedLocation = getPrimaryExtendedLocationForAz
    $primaryFabricName = getPrimaryFabric
    $RecoveryReplicaDiskAccountType = "Premium_LRS"
    $RecoveryTargetDiskAccountType = "Premium_LRS"
    $policyName = getPrimaryPolicy
    $mappingName = getPrimaryContainerMapping
    $RecoveryPlanName = getRecoveryPlanName
    $priZone = getPrimaryZone
    $recZone = getRecoveryZone

    #create recovery side resources
    $recRgName = getRecoveryResourceGroupName
    New-AzResourceGroup -name $recRgName -location $recoveryLocation -force
    [Microsoft.Rest.ClientRuntime.Azure.TestFramework.TestUtilities]::Wait(20 * 1000)
    # Create recovery network in Azure
    $RecoveryAzureNetworkId = createRecoveryNetworkIdForZone -Location $recoveryLocation
    $index = $RecoveryAzureNetworkId.IndexOf("/providers/")
    $recRg = $RecoveryAzureNetworkId.Substring(0, $index)

    #create primary
    $vmName = getAzureVmName
    New-AzResourceGroup -name $vmName -location $primaryLocation -force
    [Microsoft.Rest.ClientRuntime.Azure.TestFramework.TestUtilities]::Wait(20 * 1000)
    $logStg = createCacheStorageAccount -Location $primaryLocation

    $v2VmId = createAzureVmInEdgeZone -PrimaryLocation $primaryLocation -PrimaryExtendedLocation $primaryExtendedLocation
    $vm = get-azVm -ResourceGroupName $vmName -Name $vmName
    $vhdid = $vm.StorageProfile.OSDisk.ManagedDisk.Id
    $index = $vm.Id.IndexOf("/providers/")
    $Rg = $vm.Id.Substring(0, $index)
    $PrimaryAzureNetworkId = $Rg + "/providers/Microsoft.Network/virtualNetworks/" + $vmName

    # vault Creation
    New-AzResourceGroup -name $vaultRg -location $vaultRgLocation -force
    [Microsoft.Rest.ClientRuntime.Azure.TestFramework.TestUtilities]::Wait(20 * 1000)
    New-AzRecoveryServicesVault -ResourceGroupName $vaultRg -Name $vaultName -Location $vaultLocation
    [Microsoft.Rest.ClientRuntime.Azure.TestFramework.TestUtilities]::Wait(20 * 1000)
    $Vault = Get-AzRecoveryServicesVault -ResourceGroupName $vaultRg -Name $vaultName
    Set-ASRVaultContext -Vault $Vault

    # fabric Creation    
    $fabJob = New-AzRecoveryServicesAsrFabric -Azure -Name $primaryFabricName -Location $primaryLocation
    WaitForJobCompletion -JobId $fabJob.Name
    $fab = Get-AzRecoveryServicesAsrFabric -Name $primaryFabricName
    Assert-true { $fab.name -eq $primaryFabricName }
    Assert-AreEqual $fab.FabricSpecificDetails.Location $primaryLocation

    $pf = get-asrFabric -Name $primaryFabricName
        
    #Container creation
    $job = New-AzRecoveryServicesAsrProtectionContainer -Name $primaryContainerName -Fabric $pf
    WaitForJobCompletion -JobId $Job.Name
    $pc = Get-asrProtectionContainer -name $primaryContainerName -Fabric $pf
    Assert-NotNull($pc)
    $job = New-AzRecoveryServicesAsrProtectionContainer -Name $recoveryContainerName -Fabric $pf
    WaitForJobCompletion -JobId $Job.Name
    $rc = Get-asrProtectionContainer -name $recoveryContainerName -Fabric $pf
    Assert-NotNull($rc)

    #create policy and mapping
    $job = New-AzRecoveryServicesAsrPolicy -Name $policyName  -RecoveryPointRetentionInHours 12 -AzureToAzure 
    WaitForJobCompletion -JobId $job.Name
    $policy = Get-AzRecoveryServicesAsrPolicy  -Name $policyName
    $job = New-AzRecoveryServicesAsrProtectionContainerMapping -Name $mappingName -Policy $policy -PrimaryProtectionContainer $pc -RecoveryProtectionContainer $rc
    WaitForJobCompletion -JobId $job.Name
    $mapping = Get-AzRecoveryServicesAsrProtectionContainerMapping -Name $mappingName -ProtectionContainer $pc 

    #enable Replication
    $v = New-AzRecoveryServicesAsrAzureToAzureDiskReplicationConfig -ManagedDisk -LogStorageAccountId $logStg `
        -DiskId $vhdid -RecoveryResourceGroupId  $recRg -RecoveryReplicaDiskAccountType  $RecoveryReplicaDiskAccountType `
        -RecoveryTargetDiskAccountType $RecoveryTargetDiskAccountType
    $enableDRjob = New-AzRecoveryServicesAsrReplicationProtectedItem -AzureToAzure -AzureVmId $vm.Id -Name $vmName  -ProtectionContainerMapping $mapping -RecoveryResourceGroupId  $recRg -AzureToAzureDiskReplicationConfiguration $v -RecoveryAzureNetworkId $RecoveryAzureNetworkId -RecoveryAzureSubnetName "frontendSubnet" -RecoveryAvailabilityZone $recZone
    WaitForJobCompletion -JobId $enableDRjob.Name
    WaitForIRCompletion -affectedObjectId $enableDRjob.TargetObjectId

    $pe = Get-AzRecoveryServicesAsrReplicationProtectedItem -ProtectionContainer $pc -Name  $vmName
    Assert-NotNull($pe)

    #Failover
    $failoverjob = Start-AzRecoveryServicesAsrUnPlannedFailoverJob -ReplicationProtectedItem $pe -Direction PrimaryToRecovery -PerformSourceSideAction
    WaitForJobCompletion -JobId $failoverjob.Name

    $CommitFailoverJob = Start-AzRecoveryServicesAsrCommitFailoverJob -ReplicationProtectedItem $pe
    (Get-AzRecoveryServicesAsrJob -Job $CommitFailoverJob).Tasks
    WaitForJobCompletion -JobId $CommitFailoverJob.Name

    #Get recovery vm and verify
    $recvm = get-azVm -ResourceGroupName $recRgName -Name $vmName
    Assert-NotNull($recvm.Zones);
    Assert-Null($recvm.ExtendedLocation);

    $pe = Get-AzRecoveryServicesAsrReplicationProtectedItem -ProtectionContainer $pc -Name $vmName
    Assert-NotNull($pe)
}


<#
.SYNOPSIS 
    Test ZoneToZoneRecoveryPlanReplication new parametersets
#>

function Test-ZoneToZoneRecoveryPlanReplication {
    param([string] $seed = '347')
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
    $primaryLocation = getPrimaryZoneLocation
    $recoveryLocation = getPrimaryZoneLocation
    $primaryFabricName = getPrimaryFabric
    $RecoveryReplicaDiskAccountType = "Premium_LRS"
    $RecoveryTargetDiskAccountType = "Premium_LRS"
    $policyName = getPrimaryPolicy
    $mappingName = getPrimaryContainerMapping
    $recZone = getRecoveryZone
    $priZone = getPrimaryZone
    $RecoveryPlanName = getRecoveryPlanName

    #create recovery side resources
    $recRgName = getRecoveryResourceGroupName
    New-AzResourceGroup -name $recRgName -location $recoveryLocation -force
    [Microsoft.Rest.ClientRuntime.Azure.TestFramework.TestUtilities]::Wait(20 * 1000)
    $RecoveryAzureNetworkId = createRecoveryNetworkIdForZone 
    $index = $RecoveryAzureNetworkId.IndexOf("/providers/")
    $recRg = $RecoveryAzureNetworkId.Substring(0, $index)

    #create primary
    $vmName = getAzureVmName
    New-AzResourceGroup -name $vmName -location $primaryLocation -force
    [Microsoft.Rest.ClientRuntime.Azure.TestFramework.TestUtilities]::Wait(20 * 1000)
    $logStg = createCacheStorageAccountForZone

    $v2VmId = createAzureVmInAvailabilityZone
    $vm = get-azVm -ResourceGroupName $vmName -Name $vmName
    $vhdid = $vm.StorageProfile.OSDisk.ManagedDisk.Id
    $index = $vm.Id.IndexOf("/providers/")
    $Rg = $vm.Id.Substring(0, $index)
    $PrimaryAzureNetworkId = $Rg + "/providers/Microsoft.Network/virtualNetworks/" + $vmName

    # vault Creation
    New-AzResourceGroup -name $vaultRg -location $vaultRgLocation -force
    [Microsoft.Rest.ClientRuntime.Azure.TestFramework.TestUtilities]::Wait(20 * 1000)
    New-AzRecoveryServicesVault -ResourceGroupName $vaultRg -Name $vaultName -Location $vaultLocation
    [Microsoft.Rest.ClientRuntime.Azure.TestFramework.TestUtilities]::Wait(20 * 1000)
    $Vault = Get-AzRecoveryServicesVault -ResourceGroupName $vaultRg -Name $vaultName
    Set-ASRVaultContext -Vault $Vault

    # fabric Creation    
    $fabJob = New-AzRecoveryServicesAsrFabric -Azure -Name $primaryFabricName -Location $primaryLocation
    WaitForJobCompletion -JobId $fabJob.Name
    $fab = Get-AzRecoveryServicesAsrFabric -Name $primaryFabricName
    Assert-true { $fab.name -eq $primaryFabricName }
    Assert-AreEqual $fab.FabricSpecificDetails.Location $primaryLocation

    $pf = get-asrFabric -Name $primaryFabricName
        
    #Container creation
    $job = New-AzRecoveryServicesAsrProtectionContainer -Name $primaryContainerName -Fabric $pf
    WaitForJobCompletion -JobId $Job.Name
    $pc = Get-asrProtectionContainer -name $primaryContainerName -Fabric $pf
    Assert-NotNull($pc)
    $job = New-AzRecoveryServicesAsrProtectionContainer -Name $recoveryContainerName -Fabric $pf
    WaitForJobCompletion -JobId $Job.Name
    $rc = Get-asrProtectionContainer -name $recoveryContainerName -Fabric $pf
    Assert-NotNull($rc)

    #create policy and mapping
    $job = New-AzRecoveryServicesAsrPolicy -Name $policyName  -RecoveryPointRetentionInHours 12  -AzureToAzure 
    WaitForJobCompletion -JobId $job.Name
    $policy = Get-AzRecoveryServicesAsrPolicy  -Name $policyName
    $job = New-AzRecoveryServicesAsrProtectionContainerMapping -Name $mappingName -Policy $policy -PrimaryProtectionContainer $pc -RecoveryProtectionContainer $rc
    WaitForJobCompletion -JobId $job.Name
    $mapping = Get-AzRecoveryServicesAsrProtectionContainerMapping -Name $mappingName -ProtectionContainer $pc 

    #enable Replication
    $v = New-AzRecoveryServicesAsrAzureToAzureDiskReplicationConfig -ManagedDisk -LogStorageAccountId $logStg `
        -DiskId $vhdid -RecoveryResourceGroupId  $recRg -RecoveryReplicaDiskAccountType  $RecoveryReplicaDiskAccountType `
        -RecoveryTargetDiskAccountType $RecoveryTargetDiskAccountType
    $enableDRjob = New-AzRecoveryServicesAsrReplicationProtectedItem -AzureToAzure -AzureVmId $vm.Id -Name $vmName  -ProtectionContainerMapping $mapping -RecoveryResourceGroupId  $recRg -AzureToAzureDiskReplicationConfiguration $v -RecoveryAvailabilityZone $recZone -RecoveryAzureNetworkId $RecoveryAzureNetworkId -RecoveryAzureSubnetName "frontendSubnet"
    Assert-NotNull($enableDRjob)
    WaitForJobCompletion -JobId $enableDRjob.Name
    WaitForIRCompletion -affectedObjectId $enableDRjob.TargetObjectId

    $pe = Get-AzRecoveryServicesAsrReplicationProtectedItem -ProtectionContainer $pc -Name  $vmName
    Assert-NotNull($pe)

    #Create Recovery Plan
    $createRecoveryJob = New-AzRecoveryServicesAsrRecoveryPlan -AzureZoneToZone -Name $RecoveryPlanName -PrimaryFabric $pf -ReplicationProtectedItem $pe -RecoveryZone $recZone -PrimaryZone $priZone
    WaitForJobCompletion -JobId $createRecoveryJob.Name

    #Get Recovery Plan
    $RecoveryPlan = Get-AzRecoveryServicesAsrRecoveryPlan -Name $RecoveryPlanName 
    Assert-NotNull($RecoveryPlan)

    #Failover
    $failoverjob = Start-AzRecoveryServicesAsrUnPlannedFailoverJob -RecoveryPlan $RecoveryPlan -Direction PrimaryToRecovery -PerformSourceSideAction
    WaitForJobCompletion -JobId $failoverjob.Name
    #Get recovery vm and verify
    $recvm = get-azVm -ResourceGroupName $recRgName -Name $vmName
    Assert-NotNull($recvm.Zones);

    $pe = Get-AzRecoveryServicesAsrReplicationProtectedItem -ProtectionContainer $pc -Name  $vmName
    Assert-NotNull($pe)

    #Get Recovery Plan
    $RecoveryPlan = Get-AzRecoveryServicesAsrRecoveryPlan -Name $RecoveryPlanName 
    Assert-NotNull($RecoveryPlan)
}

<#
.SYNOPSIS 
    Test RecoveryPlanReplication new parametersets
#>

function Test-RecoveryPlanReplication {
    param([string] $seed = '918')
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
    $recMappingName = getRecoveryContainerMapping
    $primaryNetMapping = getPrimaryNetworkMapping
    $recoveryNetMapping = getRecoveryNetworkMapping
    $RecoveryPlanName = getRecoveryPlanName

    #create recovery side resources
    $recRgName = getRecoveryResourceGroupName
    New-AzResourceGroup -name $recRgName -location $recoveryLocation -force
    [Microsoft.Rest.ClientRuntime.Azure.TestFramework.TestUtilities]::Wait(20 * 1000)
    $RecoveryAzureNetworkId = createRecoveryNetworkId 
    $index = $RecoveryAzureNetworkId.IndexOf("/providers/")
    $recRg = $RecoveryAzureNetworkId.Substring(0, $index)
    #create proximity placement group
    $recPpg = New-AzProximityPlacementGroup -ResourceGroupName $recRgName -Name "PPG1-asr" -Location $recoveryLocation
    $recPpg1 = New-AzProximityPlacementGroup -ResourceGroupName $recRgName -Name "PPG2-asr" -Location $recoveryLocation

    #create primary
    $vmName = getAzureVmName
    New-AzResourceGroup -name $vmName -location $primaryLocation -force
    [Microsoft.Rest.ClientRuntime.Azure.TestFramework.TestUtilities]::Wait(20 * 1000)
    $logStg = createCacheStorageAccount -Location $primaryLocation
    $recLogStg = createRecoveryCacheStorageAccount

    $v2VmId = createAzureVmInProximityPlacementgroup
    $vm = get-azVm -ResourceGroupName $vmName -Name $vmName
    $vhdid = $vm.StorageProfile.OSDisk.ManagedDisk.Id
    $index = $vm.Id.IndexOf("/providers/")
    $Rg = $vm.Id.Substring(0, $index)
    $PrimaryAzureNetworkId = $Rg + "/providers/Microsoft.Network/virtualNetworks/" + $vmName

    # vault Creation
    New-AzResourceGroup -name $vaultRg -location $vaultRgLocation -force
    [Microsoft.Rest.ClientRuntime.Azure.TestFramework.TestUtilities]::Wait(20 * 1000)
    New-AzRecoveryServicesVault -ResourceGroupName $vaultRg -Name $vaultName -Location $vaultLocation
    [Microsoft.Rest.ClientRuntime.Azure.TestFramework.TestUtilities]::Wait(20 * 1000)
    $Vault = Get-AzRecoveryServicesVault -ResourceGroupName $vaultRg -Name $vaultName
    Set-ASRVaultContext -Vault $Vault

    # fabric Creation    
    $fabJob = New-AzRecoveryServicesAsrFabric -Azure -Name $primaryFabricName -Location $primaryLocation
    WaitForJobCompletion -JobId $fabJob.Name
    $fab = Get-AzRecoveryServicesAsrFabric -Name $primaryFabricName
    Assert-true { $fab.name -eq $primaryFabricName }
    Assert-AreEqual $fab.FabricSpecificDetails.Location $primaryLocation

    $fabJob = New-AzRecoveryServicesAsrFabric -Azure -Name $recoveryFabricName -Location $recoveryLocation
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
    $v = New-AzRecoveryServicesAsrAzureToAzureDiskReplicationConfig -ManagedDisk -LogStorageAccountId $logStg `
        -DiskId $vhdid -RecoveryResourceGroupId  $recRg -RecoveryReplicaDiskAccountType  $RecoveryReplicaDiskAccountType `
        -RecoveryTargetDiskAccountType $RecoveryTargetDiskAccountType
    $enableDRjob = New-AzRecoveryServicesAsrReplicationProtectedItem -AzureToAzure -AzureVmId $vm.Id -Name $vmName  -ProtectionContainerMapping $mapping -RecoveryResourceGroupId  $recRg -AzureToAzureDiskReplicationConfiguration $v -RecoveryProximityPlacementGroupId $recPpg.Id
    WaitForJobCompletion -JobId $enableDRjob.Name
    WaitForIRCompletion -affectedObjectId $enableDRjob.TargetObjectId

    #Validate PPG Set in replicated vm properties
    $pe = Get-AzRecoveryServicesAsrReplicationProtectedItem -ProtectionContainer $pc -Name  $vmName
    Assert-NotNull($pe.providerSpecificDetails.RecoveryProximityPlacementGroupId)

    #Create Recovery Plan
    $createRecoveryJob = New-AzRecoveryServicesAsrRecoveryPlan -Name $RecoveryPlanName -PrimaryFabric $pf -RecoveryFabric $rf  -ReplicationProtectedItem $pe
    WaitForJobCompletion -JobId $createRecoveryJob.Name

    #Get Recovery Plan
    $RecoveryPlan = Get-AzRecoveryServicesAsrRecoveryPlan -Name $RecoveryPlanName 
    Assert-NotNull($RecoveryPlan)

    #Failover
    $failoverjob = Start-AzRecoveryServicesAsrUnPlannedFailoverJob -RecoveryPlan $RecoveryPlan -Direction PrimaryToRecovery -PerformSourceSideAction
    WaitForJobCompletion -JobId $failoverjob.Name
}

<#
.SYNOPSIS
    Test A2AReplicationProtectionCluster new parametersets
#>
function Test-A2AReplicationProtectionCluster{
    $Vault = Get-AzRecoveryServicesVault -Name "vijamipowershelltest" -ResourceGroupName "vijami-alertrg"
    Set-ASRVaultContext -Vault $Vault
    $fabricName = "asr-a2a-default-eastus2"
    $fabric = Get-AzRecoveryServicesAsrFabric -Name $fabricName
    $pc = Get-AzRecoveryServicesAsrProtectionContainer -Fabric $fabric
    $forwardpcm = Get-AzRecoveryServicesAsrProtectionContainerMapping -ProtectionContainer $pc -Name "eastus2-westus-24-hour-retention-policy"
    $clusterName = "PowershellTestLatest"
    $clusterjob = New-AzRecoveryServicesAsrReplicationProtectionCluster -AzureToAzure -Name $clusterName -ProtectionContainerMapping $forwardpcm

    WaitForJobCompletion -JobId $clusterjob.Name
    $cluster = Get-AzRecoveryServicesAsrReplicationProtectionCluster -Name $clusterName -ProtectionContainer $pc

    $vmId1 = "/subscriptions/7c943c1b-5122-4097-90c8-861411bdd574/resourceGroups/ClusterRG-Vijami-1103092752/providers/Microsoft.Compute/virtualMachines/sdgql0"
    $rgId = "/subscriptions/7c943c1b-5122-4097-90c8-861411bdd574/resourceGroups/ClusterRG-Vijami-1103092752-asr"
    $avset = "/subscriptions/7c943c1b-5122-4097-90c8-861411bdd574/resourceGroups/ClusterRG-Vijami-1103092752-asr/providers/Microsoft.Compute/availabilitySets/SDGQL-AS-asr"
    $ppg = "/subscriptions/7c943c1b-5122-4097-90c8-861411bdd574/resourceGroups/ClusterRG-Vijami-1103092752-asr/providers/Microsoft.Compute/proximityPlacementGroups/sdgql-ppg-asr"
    $networkId = "/subscriptions/7c943c1b-5122-4097-90c8-861411bdd574/resourceGroups/ClusterRG-Vijami-1103092752-asr/providers/Microsoft.Network/virtualNetworks/adVNET-asr"
    $storageId = "/subscriptions/7c943c1b-5122-4097-90c8-861411bdd574/resourceGroups/vijami-alertrg/providers/Microsoft.Storage/storageAccounts/er9stavijamipoweasrcache"
    $rpiName1 = "sdgql0"
    $EnableJob1 = New-AzRecoveryServicesAsrReplicationProtectedItem -AzureToAzure -Name $rpiName1 -ReplicationProtectionCluster $cluster `
    -AzureVmId $vmId1 -ProtectionContainerMapping $forwardpcm -RecoveryResourceGroupId $rgId -RecoveryAvailabilitySetId $avset `
    -RecoveryProximityPlacementGroupId $ppg -RecoveryAzureNetworkId $networkId -LogStorageAccountId $storageId

    $vmId2 = "/subscriptions/7c943c1b-5122-4097-90c8-861411bdd574/resourceGroups/ClusterRG-Vijami-1103092752/providers/Microsoft.Compute/virtualMachines/sdgql1"
    $rpiName2 = "sdgql1"
    
    $RecoveryReplicaDiskAccountType = "Premium_LRS"
    $RecoveryTargetDiskAccountType = "Premium_LRS"
    $vhdId1 = "/subscriptions/7c943c1b-5122-4097-90c8-861411bdd574/resourceGroups/ClusterRG-Vijami-1103092752/providers/Microsoft.Compute/disks/sdgql1-osdisk"
    $vhdId2 = "/subscriptions/7c943c1b-5122-4097-90c8-861411bdd574/resourceGroups/ClusterRG-Vijami-1103092752/providers/Microsoft.Compute/disks/sdgql-datadisk0"
    $disk1 = New-AzRecoveryServicesAsrAzureToAzureDiskReplicationConfig -ManagedDisk -LogStorageAccountId $storageId `
        -DiskId $vhdId1 -RecoveryResourceGroupId  $rgId -RecoveryReplicaDiskAccountType  $RecoveryReplicaDiskAccountType `
        -RecoveryTargetDiskAccountType $RecoveryTargetDiskAccountType
    $disk2 = New-AzRecoveryServicesAsrAzureToAzureDiskReplicationConfig -ManagedDisk -LogStorageAccountId $storageId `
        -DiskId $vhdId2 -RecoveryResourceGroupId  $rgId -RecoveryReplicaDiskAccountType  $RecoveryReplicaDiskAccountType `
        -RecoveryTargetDiskAccountType $RecoveryTargetDiskAccountType
    $disks = @()
    $disks += $disk1
    $disks += $disk2
    $EnableJob2 = New-AzRecoveryServicesAsrReplicationProtectedItem -AzureToAzure -Name $rpiName2 `
    -AzureToAzureDiskReplicationConfiguration $disks -ReplicationProtectionCluster $cluster -AzureVmId $vmId2 `
    -ProtectionContainerMapping $forwardpcm -RecoveryResourceGroupId $rgId -RecoveryAvailabilitySetId $avset `
    -RecoveryProximityPlacementGroupId $ppg -RecoveryAzureNetworkId $networkId

    [Microsoft.Rest.ClientRuntime.Azure.TestFramework.TestUtilities]::Wait(20 * 1000)
    WaitForJobCompletion -JobId $EnableJob1.Name
    WaitForJobCompletion -JobId $EnableJob2.Name

    [Microsoft.Rest.ClientRuntime.Azure.TestFramework.TestUtilities]::Wait(20 * 1000)
    WaitForIRCompletion -affectedObjectId $EnableJob1.TargetObjectId
    WaitForIRCompletion -affectedObjectId $EnableJob2.TargetObjectId

    $clusterToDisableName = "PowershellTestLatest"
    $clusterToDisable = Get-AzRecoveryServicesAsrReplicationProtectionCluster -Name $clusterToDisableName -ProtectionContainer $pc
    $DisableJob = Remove-AzRecoveryServicesAsrReplicationProtectionCluster -ReplicationProtectionCluster $clusterToDisable
    WaitForJobCompletion -JobId $DisableJob.Name
}

<#
.SYNOPSIS
    Test A2AResyncReplicationProtectionCluster parametersets
#>
function Test-A2AResyncReplicationProtectionCluster{
    $Vault = Get-AzRecoveryServicesVault -Name "vijamitest" -ResourceGroupName "vijami-alertrg"
    Set-ASRVaultContext -Vault $Vault
    $fabricName = "asr-a2a-default-eastus2"
    $fabric = Get-AzRecoveryServicesAsrFabric -Name $fabricName
    $pc = Get-AzRecoveryServicesAsrProtectionContainer -Fabric $fabric
    $forwardpcm = Get-AzRecoveryServicesAsrProtectionContainerMapping -ProtectionContainer $pc -Name "eastus2-westus-24-hour-retention-policy"
    $clusterName = "pscluster"
    $cluster = Get-AzRecoveryServicesAsrReplicationProtectionCluster -Name $clusterName -ProtectionContainer $pc

    $ResyncJob = Start-AzRecoveryServicesAsrClusterResynchronizeReplicationJob -ReplicationProtectionCluster $cluster

    [Microsoft.Rest.ClientRuntime.Azure.TestFramework.TestUtilities]::Wait(20 * 1000)
    WaitForJobCompletion -JobId $ResyncJob.Name
}

<#
.SYNOPSIS
    Test A2AReprotectClusterWithoutProtectedItemDetails parametersets
#>
function Test-A2AReprotectClusterWithoutProtectedItemDetails{
    $Vault = Get-AzRecoveryServicesVault -Name "vijami1903" -ResourceGroupName "vijami-alertrg"
    Set-ASRVaultContext -Vault $Vault
    $fabricName = "asr-a2a-default-eastus2"
    $fabric = Get-AzRecoveryServicesAsrFabric -Name $fabricName
    $pc = Get-AzRecoveryServicesAsrProtectionContainer -Fabric $fabric
    $forwardpcm = Get-AzRecoveryServicesAsrProtectionContainerMapping -ProtectionContainer $pc -Name "eastus2-westus-24-hour-retention-policy"
    $clusterName = "cluster924"
    $cluster = Get-AzRecoveryServicesAsrReplicationProtectionCluster -Name $clusterName -ProtectionContainer $pc

    $storage = "/subscriptions/7c943c1b-5122-4097-90c8-861411bdd574/resourceGroups/vijami-alertrg/providers/Microsoft.Storage/storageAccounts/yerp1nvijamitestasrcache"
    $ppg = "/subscriptions/7c943c1b-5122-4097-90c8-861411bdd574/resourceGroups/ClusterRG-Vijami-1003165924/providers/Microsoft.Compute/proximityPlacementGroups/sdgql-ppg"
    $avset = "/subscriptions/7c943c1b-5122-4097-90c8-861411bdd574/resourceGroups/ClusterRG-Vijami-1003165924/providers/Microsoft.Compute/availabilitySets/SDGQL-AS"
    $rgId = "/subscriptions/7c943c1b-5122-4097-90c8-861411bdd574/resourceGroups/ClusterRG-Vijami-1003165924"

    # Without protected item details
    $recoveryFabricName = "asr-a2a-default-westus"
    $recoveryFabric = Get-AzRecoveryServicesAsrFabric -Name $recoveryFabricName
    $recoverypc = Get-AzRecoveryServicesAsrProtectionContainer -Fabric $recoveryFabric
    $recoverypcm = Get-AzRecoveryServicesAsrProtectionContainerMapping -ProtectionContainer $recoverypc -Name "westus-eastus2-24-hour-retention-policy"
    $ReprotectJob = Update-AzRecoveryServicesAsrClusterProtectionDirection -AzureToAzure -ReplicationProtectionCluster $cluster `
    -RecoveryProximityPlacementGroupId $ppg -RecoveryAvailabilitySetId $avset `
    -RecoveryResourceGroupId $rgId -LogStorageAccountId $storage -ProtectionContainerMapping $recoverypcm

    [Microsoft.Rest.ClientRuntime.Azure.TestFramework.TestUtilities]::Wait(20 * 1000)
    WaitForJobCompletion -JobId $ReprotectJob.Name
}

<#
.SYNOPSIS
    Test-A2AReprotectClusterWithProtectedItemDetails parametersets
#>
function Test-A2AReprotectClusterWithProtectedItemDetails{
    $Vault = Get-AzRecoveryServicesVault -Name "vijami2003" -ResourceGroupName "vijami-alertrg"
    Set-ASRVaultContext -Vault $Vault
    $fabricName = "asr-a2a-default-eastus2"
    $fabric = Get-AzRecoveryServicesAsrFabric -Name $fabricName
    $pc = Get-AzRecoveryServicesAsrProtectionContainer -Fabric $fabric
    $forwardpcm = Get-AzRecoveryServicesAsrProtectionContainerMapping -ProtectionContainer $pc -Name "eastus2-westus-24-hour-retention-policy"
    $clusterName = "sharedcluster"
    $cluster = Get-AzRecoveryServicesAsrReplicationProtectionCluster -Name $clusterName -ProtectionContainer $pc

    $storage = "/subscriptions/7c943c1b-5122-4097-90c8-861411bdd574/resourceGroups/vijami-alertrg/providers/Microsoft.Storage/storageAccounts/yerp1nvijamitestasrcache"
    $ppg = "/subscriptions/7c943c1b-5122-4097-90c8-861411bdd574/resourceGroups/ClusterRG-Shashank-1903211114/providers/Microsoft.Compute/proximityPlacementGroups/sdgql-ppg"
    $avset = "/subscriptions/7c943c1b-5122-4097-90c8-861411bdd574/resourceGroups/ClusterRG-Shashank-1903211114/providers/Microsoft.Compute/availabilitySets/SDGQL-AS"
    $rgId = "/subscriptions/7c943c1b-5122-4097-90c8-861411bdd574/resourceGroups/ClusterRG-Shashank-1903211114"

    # With protected item details
    $recoveryFabricName = "asr-a2a-default-westus"
    $recoveryFabric = Get-AzRecoveryServicesAsrFabric -Name $recoveryFabricName
    $recoverypc = Get-AzRecoveryServicesAsrProtectionContainer -Fabric $recoveryFabric
    $recoverypcm = Get-AzRecoveryServicesAsrProtectionContainerMapping -ProtectionContainer $recoverypc -Name "westus-eastus2-24-hour-retention-policy"
    
    $rpiName1 = "LgmdzaWuGZLO_cJHE7U-jgIqKAtIiUS2EfqlpOxaio0"
    $rpi1 = New-AzRecoveryServicesAsrAzureToAzureReplicationProtectedItemConfig `
    -ReplicationProtectedItemName $rpiName1 -RecoveryResourceGroupId $rgId `
    -RecoveryAvailabilitySetId $avset -RecoveryProximityPlacementGroupId $ppg 

    $RecoveryReplicaDiskAccountType = "Premium_LRS"
    $RecoveryTargetDiskAccountType = "Premium_LRS"
    $vhdId1 = "/subscriptions/7c943c1b-5122-4097-90c8-861411bdd574/resourceGroups/ClusterRG-Shashank-1903211114-asr/providers/Microsoft.Compute/disks/sdgql1-osdisk"
    $vhdId2 = "/subscriptions/7c943c1b-5122-4097-90c8-861411bdd574/resourceGroups/ClusterRG-Shashank-1903211114-asr/providers/Microsoft.Compute/disks/sdgql-datadisk0"
    $disk1 = New-AzRecoveryServicesAsrAzureToAzureDiskReplicationConfig -ManagedDisk -LogStorageAccountId $storage `
        -DiskId $vhdId1 -RecoveryResourceGroupId  $rgId -RecoveryReplicaDiskAccountType $RecoveryReplicaDiskAccountType `
        -RecoveryTargetDiskAccountType $RecoveryTargetDiskAccountType
    $disk2 = New-AzRecoveryServicesAsrAzureToAzureDiskReplicationConfig -ManagedDisk -LogStorageAccountId $storage `
        -DiskId $vhdId2 -RecoveryResourceGroupId  $rgId -RecoveryReplicaDiskAccountType $RecoveryReplicaDiskAccountType `
        -RecoveryTargetDiskAccountType $RecoveryTargetDiskAccountType

    $disks = @()
    $disks += $disk1
    $disks += $disk2

    $rpiName2 = "2InGmCRe9AA7MIHDYK6iGDh9QDAML0cclNQt0rSzc5o"
    $rpi2 = New-AzRecoveryServicesAsrAzureToAzureReplicationProtectedItemConfig -ManagedDisk `
    -ReplicationProtectedItemName $rpiName2 -RecoveryResourceGroupId $rgId `
    -AzureToAzureDiskReplicationConfiguration $disks -RecoveryAvailabilitySetId $avset `
    -RecoveryProximityPlacementGroupId $ppg 

     $rpis = @()
     $rpis += $rpi1
     $rpis += $rpi2

    $ReprotectJob = Update-AzRecoveryServicesAsrClusterProtectionDirection -AzureToAzure -ReplicationProtectionCluster $cluster `
    -AzureToAzureReplicationProtectedItemConfig $rpis -LogStorageAccountId $storage -ProtectionContainerMapping $recoverypcm `
    -RecoveryResourceGroupId $rgId

    [Microsoft.Rest.ClientRuntime.Azure.TestFramework.TestUtilities]::Wait(20 * 1000)
    WaitForJobCompletion -JobId $ReprotectJob.Name
}

<#
.SYNOPSIS
    Test VMSS replication new parametersets
#>

function Test-VMSSReplication {
    param([string] $seed = '1228')
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
    $recMappingName = getRecoveryContainerMapping
    $primaryNetMapping = getPrimaryNetworkMapping
    $recoveryNetMapping = getRecoveryNetworkMapping

    #create recovery side resources
    $recRgName = getRecoveryResourceGroupName
    New-AzResourceGroup -name $recRgName -location $recoveryLocation -force
    [Microsoft.Rest.ClientRuntime.Azure.TestFramework.TestUtilities]::Wait(20 * 1000)
    $RecoveryAzureNetworkId = createRecoveryNetworkId
    $index = $RecoveryAzureNetworkId.IndexOf("/providers/")
    $recRg = $RecoveryAzureNetworkId.Substring(0, $index)
    #create virtual Machine scale set
    $stnd = "Standard"
    $vmssConfig = New-AzVmssConfig -Location $recoveryLocation -PlatformFaultDomainCount 1 -SinglePlacementGroup 0 -SecurityType $stnd
    $recVmss = new-azvmss -resourcegroupname $recRgName -vmscalesetname 'vmss-asr' -virtualmachinescaleset $vmssConfig
    $recVmss1 = new-azvmss -resourcegroupname $recRgName -vmscalesetname 'vmss1-asr' -virtualmachinescaleset $vmssConfig

    #create primary
    $vmName = getAzureVmName
    New-AzResourceGroup -name $vmName -location $primaryLocation -force
    [Microsoft.Rest.ClientRuntime.Azure.TestFramework.TestUtilities]::Wait(20 * 1000)
    $logStg = createCacheStorageAccount
    $recLogStg = createRecoveryCacheStorageAccount

    $v2VmId = createAzureVm
    $vm = get-azVm -ResourceGroupName $vmName -Name $vmName
    $vhdid = $vm.StorageProfile.OSDisk.ManagedDisk.Id
    $index = $vm.Id.IndexOf("/providers/")
    $Rg = $vm.Id.Substring(0, $index)
    $PrimaryAzureNetworkId = $Rg + "/providers/Microsoft.Network/virtualNetworks/" + $vmName

    # vault Creation
    New-AzResourceGroup -name $vaultRg -location $vaultRgLocation -force
    [Microsoft.Rest.ClientRuntime.Azure.TestFramework.TestUtilities]::Wait(20 * 1000)
    New-AzRecoveryServicesVault -ResourceGroupName $vaultRg -Name $vaultName -Location $vaultLocation
    [Microsoft.Rest.ClientRuntime.Azure.TestFramework.TestUtilities]::Wait(20 * 1000)
    $Vault = Get-AzRecoveryServicesVault -ResourceGroupName $vaultRg -Name $vaultName
    Set-ASRVaultContext -Vault $Vault

    # fabric Creation
    $fabJob = New-AzRecoveryServicesAsrFabric -Azure -Name $primaryFabricName -Location $primaryLocation
    WaitForJobCompletion -JobId $fabJob.Name
    $fab = Get-AzRecoveryServicesAsrFabric -Name $primaryFabricName
    Assert-true { $fab.name -eq $primaryFabricName }
    Assert-AreEqual $fab.FabricSpecificDetails.Location $primaryLocation

    $fabJob = New-AzRecoveryServicesAsrFabric -Azure -Name $recoveryFabricName -Location $recoveryLocation
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

    #Reverse Conatiner mapping
    $job = New-AzRecoveryServicesAsrProtectionContainerMapping -Name $recMappingName -Policy $policy -PrimaryProtectionContainer $rc -RecoveryProtectionContainer $pc
    WaitForJobCompletion -JobId $job.Name
    $revMapping = Get-AzRecoveryServicesAsrProtectionContainerMapping -Name $recMappingName -ProtectionContainer $rc

    #Reverse network mapping
    $job = New-AzRecoveryServicesAsrNetworkMapping -AzureToAzure -Name $recoveryNetMapping -PrimaryFabric $rf -PrimaryAzureNetworkId $RecoveryAzureNetworkId -RecoveryFabric $pf -RecoveryAzureNetworkId $PrimaryAzureNetworkId
    WaitForJobCompletion -JobId $job.Name

    #enable Replication
    $v = New-AzRecoveryServicesAsrAzureToAzureDiskReplicationConfig -ManagedDisk -LogStorageAccountId $logStg `
        -DiskId $vhdid -RecoveryResourceGroupId  $recRg -RecoveryReplicaDiskAccountType  $RecoveryReplicaDiskAccountType `
        -RecoveryTargetDiskAccountType $RecoveryTargetDiskAccountType
    $enableDRjob = New-AzRecoveryServicesAsrReplicationProtectedItem -AzureToAzure -AzureVmId $vm.Id -Name $vmName  -ProtectionContainerMapping $mapping -RecoveryResourceGroupId  $recRg -AzureToAzureDiskReplicationConfiguration $v -RecoveryVirtualMachineScaleSetId $recVmss.Id
    [Microsoft.Rest.ClientRuntime.Azure.TestFramework.TestUtilities]::Wait(20 * 1000)
    [Microsoft.Rest.ClientRuntime.Azure.TestFramework.TestUtilities]::Wait(20 * 1000)
    WaitForJobCompletion -JobId $enableDRjob.Name
    WaitForIRCompletion -affectedObjectId $enableDRjob.TargetObjectId

    #Validate vmss Set in replicated vm properties
    $pe = Get-AzRecoveryServicesAsrReplicationProtectedItem -ProtectionContainer $pc -Name  $vmName
    Assert-NotNull($pe.providerSpecificDetails.RecoveryVirtualMachineScaleSetId)

    #Update Vmpropertie
    $updateDRjob = Set-AzRecoveryServicesAsrReplicationProtectedItem -InputObject $pe -RecoveryVirtualMachineScaleSetId $recVmss1.Id
    WaitForJobCompletion -JobId $updateDRjob.Name
    $pe = Get-AzRecoveryServicesAsrReplicationProtectedItem -ProtectionContainer $pc -Name  $vmName
    Assert-NotNull($pe.providerSpecificDetails.RecoveryVirtualMachineScaleSetId)

    #Failover
    $failoverjob = Start-AzRecoveryServicesAsrUnPlannedFailoverJob -ReplicationProtectedItem $pe -Direction PrimaryToRecovery -PerformSourceSideAction
    WaitForJobCompletion -JobId $failoverjob.Name
    #Get recovery vm and verify
    $recvm = get-azVm -ResourceGroupName $recRgName -Name $vmName
    Assert-NotNull($recvm.virtualmachinescaleset.Id);
}


<#
.SYNOPSIS
    Test CRG replication new parametersets
#>

function Test-CRGReplication {
    param([string] $seed = '2048')
    $primaryPolicyName = getPrimaryPolicy
    $recoveryPolicyName = getRecoveryPolicy

    $primaryContainerMappingName = getPrimaryContainerMapping
    $recoveryContainerMappingName = getRecoveryContainerMapping

    $primaryContainerName = getPrimaryContainer
    $recoveryContainerName = getRecoveryContainer
    $vaultRgLocation = getVaultRgLocation
    $vaultName = getVaultName
    $vaultLocation = "eastus2euap"
    $vaultRg = getVaultRg
    $primaryLocation = getPrimaryLocation
    $recoveryLocation = "eastus2euap"
    $primaryFabricName = getPrimaryFabric
    $recoveryFabricName = getRecoveryFabric
    $RecoveryReplicaDiskAccountType = "Premium_LRS"
    $RecoveryTargetDiskAccountType = "Premium_LRS"
    $policyName = getPrimaryPolicy
    $mappingName = getPrimaryContainerMapping
    $recMappingName = getRecoveryContainerMapping
    $primaryNetMapping = getPrimaryNetworkMapping
    $recoveryNetMapping = getRecoveryNetworkMapping
    $recoveryCRGName1 = "crg-a2a-pwsh-1-" + $seed;
    $recoveryCRGName2 = "crg-a2a-pwsh-2-" + $seed;
    $primaryCRGName = "crg-a2a-pwsh-p-" + $seed;

    # Create recovery side resources
    $recRgName = getRecoveryResourceGroupName
    New-AzResourceGroup -name $recRgName -location $recoveryLocation -force
    [Microsoft.Rest.ClientRuntime.Azure.TestFramework.TestUtilities]::Wait(20 * 1000)
    $RecoveryAzureNetworkId = createRecoveryNetworkId
    $index = $RecoveryAzureNetworkId.IndexOf("/providers/")
    $recRg = $RecoveryAzureNetworkId.Substring(0, $index)
    
    # Create CRG
    New-AzCapacityReservationGroup -ResourceGroupName $recRgName -Location $recoveryLocation -Name $recoveryCRGName1
    New-AzCapacityReservationGroup -ResourceGroupName $recRgName -Location $recoveryLocation -Name $recoveryCRGName2
    [Microsoft.Rest.ClientRuntime.Azure.TestFramework.TestUtilities]::Wait(20 * 1000)
    New-AzCapacityReservation -ResourceGroupName $recRgName -Location $recoveryLocation -ReservationGroupName $recoveryCRGName1 -Name "cr-a2a-pwsh" -Sku "Standard_D2s_v3" -CapacityToReserve 1
    New-AzCapacityReservation -ResourceGroupName $recRgName -Location $recoveryLocation -ReservationGroupName $recoveryCRGName2 -Name "cr-a2a-pwsh" -Sku "Standard_D2s_v3" -CapacityToReserve 1
    [Microsoft.Rest.ClientRuntime.Azure.TestFramework.TestUtilities]::Wait(20 * 1000)
    $recCRG1 = Get-AzCapacityReservationGroup -ResourceGroupName $recRgName -Name $recoveryCRGName1 -InstanceView
    $recCRG2 = Get-AzCapacityReservationGroup -ResourceGroupName $recRgName -Name $recoveryCRGName2 -InstanceView

    # Create primary side resources
    $vmName = getAzureVmName
    New-AzResourceGroup -name $vmName -location $primaryLocation -force
    [Microsoft.Rest.ClientRuntime.Azure.TestFramework.TestUtilities]::Wait(20 * 1000)
    $logStg = createCacheStorageAccount
    $recLogStg = createRecoveryCacheStorageAccount

    $v2VmId = createAzureVmForCRG
    $vm = get-azVm -ResourceGroupName $vmName -Name $vmName
    $vhdid = $vm.StorageProfile.OSDisk.ManagedDisk.Id
    $index = $vm.Id.IndexOf("/providers/")
    $Rg = $vm.Id.Substring(0, $index)
    $PrimaryAzureNetworkId = $Rg + "/providers/Microsoft.Network/virtualNetworks/" + $vmName

    # Vault creation
    New-AzResourceGroup -name $vaultRg -location $vaultRgLocation -force
    [Microsoft.Rest.ClientRuntime.Azure.TestFramework.TestUtilities]::Wait(20 * 1000)
    New-AzRecoveryServicesVault -ResourceGroupName $vaultRg -Name $vaultName -Location $vaultLocation
    [Microsoft.Rest.ClientRuntime.Azure.TestFramework.TestUtilities]::Wait(20 * 1000)
    $Vault = Get-AzRecoveryServicesVault -ResourceGroupName $vaultRg -Name $vaultName
    Set-ASRVaultContext -Vault $Vault

    # Fabric creation
    $fabJob = New-AzRecoveryServicesAsrFabric -Azure -Name $primaryFabricName -Location $primaryLocation
    WaitForJobCompletion -JobId $fabJob.Name
    $fab = Get-AzRecoveryServicesAsrFabric -Name $primaryFabricName
    Assert-true { $fab.name -eq $primaryFabricName }
    Assert-AreEqual $fab.FabricSpecificDetails.Location $primaryLocation

    $fabJob = New-AzRecoveryServicesAsrFabric -Azure -Name $recoveryFabricName -Location $recoveryLocation
    WaitForJobCompletion -JobId $fabJob.Name
    $fab = Get-AzRecoveryServicesAsrFabric -Name $recoveryFabricName
    Assert-true { $fab.name -eq $recoveryFabricName }
    Assert-AreEqual $fab.FabricSpecificDetails.Location $recoveryLocation
    $pf = get-asrFabric -Name $primaryFabricName
    $rf = get-asrFabric -Name $recoveryFabricName

    # Container creation
    $job = New-AzRecoveryServicesAsrProtectionContainer -Name $primaryContainerName -Fabric $pf
    WaitForJobCompletion -JobId $Job.Name
    $pc = Get-asrProtectionContainer -name $primaryContainerName -Fabric $pf
    Assert-NotNull($pc)
    $job = New-AzRecoveryServicesAsrProtectionContainer -Name $recoveryContainerName -Fabric $rf
    WaitForJobCompletion -JobId $Job.Name
    $rc = Get-asrProtectionContainer -name $recoveryContainerName -Fabric $rf
    Assert-NotNull($rc)

    # Create policy and mapping
    $job = New-AzRecoveryServicesAsrPolicy -Name $policyName  -RecoveryPointRetentionInHours 12  -AzureToAzure
    WaitForJobCompletion -JobId $job.Name
    $policy = Get-AzRecoveryServicesAsrPolicy  -Name $policyName
    $job = New-AzRecoveryServicesAsrProtectionContainerMapping -Name $mappingName -Policy $policy -PrimaryProtectionContainer $pc -RecoveryProtectionContainer $rc
    WaitForJobCompletion -JobId $job.Name
    $mapping = Get-AzRecoveryServicesAsrProtectionContainerMapping -Name $mappingName -ProtectionContainer $pc

    # Network mapping
    $job = New-AzRecoveryServicesAsrNetworkMapping -AzureToAzure -Name $primaryNetMapping -PrimaryFabric $pf -PrimaryAzureNetworkId $PrimaryAzureNetworkId -RecoveryFabric $rf -RecoveryAzureNetworkId $RecoveryAzureNetworkId
    WaitForJobCompletion -JobId $job.Name

    # Reverse container mapping
    $job = New-AzRecoveryServicesAsrProtectionContainerMapping -Name $recMappingName -Policy $policy -PrimaryProtectionContainer $rc -RecoveryProtectionContainer $pc
    WaitForJobCompletion -JobId $job.Name
    $revMapping = Get-AzRecoveryServicesAsrProtectionContainerMapping -Name $recMappingName -ProtectionContainer $rc

    # Reverse network mapping
    $job = New-AzRecoveryServicesAsrNetworkMapping -AzureToAzure -Name $recoveryNetMapping -PrimaryFabric $rf -PrimaryAzureNetworkId $RecoveryAzureNetworkId -RecoveryFabric $pf -RecoveryAzureNetworkId $PrimaryAzureNetworkId
    WaitForJobCompletion -JobId $job.Name

    # Enable replication
    $v = New-AzRecoveryServicesAsrAzureToAzureDiskReplicationConfig -ManagedDisk -LogStorageAccountId $logStg `
        -DiskId $vhdid -RecoveryResourceGroupId  $recRg -RecoveryReplicaDiskAccountType  $RecoveryReplicaDiskAccountType `
        -RecoveryTargetDiskAccountType $RecoveryTargetDiskAccountType
    $enableDRjob = New-AzRecoveryServicesAsrReplicationProtectedItem -AzureToAzure -AzureVmId $vm.Id -Name $vmName  -ProtectionContainerMapping $mapping -RecoveryResourceGroupId  $recRg -AzureToAzureDiskReplicationConfiguration $v -RecoveryCapacityReservationGroupId $recCRG1.Id
    [Microsoft.Rest.ClientRuntime.Azure.TestFramework.TestUtilities]::Wait(20 * 1000)
    [Microsoft.Rest.ClientRuntime.Azure.TestFramework.TestUtilities]::Wait(20 * 1000)
    WaitForJobCompletion -JobId $enableDRjob.Name
    WaitForIRCompletion -affectedObjectId $enableDRjob.TargetObjectId

    # Validate CRG in replicated vm properties
    $pe = Get-AzRecoveryServicesAsrReplicationProtectedItem -ProtectionContainer $pc -Name  $vmName
    Assert-NotNull($pe.providerSpecificDetails.RecoveryCapacityReservationGroupId)

    # Update Vm properties
    $updateDRjob = Set-AzRecoveryServicesAsrReplicationProtectedItem -InputObject $pe -RecoveryCapacityReservationGroupId $recCRG2.Id
    WaitForJobCompletion -JobId $updateDRjob.Name
    $pe = Get-AzRecoveryServicesAsrReplicationProtectedItem -ProtectionContainer $pc -Name  $vmName
    Assert-NotNull($pe.providerSpecificDetails.RecoveryCapacityReservationGroupId)

    # Failover
    $failoverjob = Start-AzRecoveryServicesAsrUnPlannedFailoverJob -ReplicationProtectedItem $pe -Direction PrimaryToRecovery -PerformSourceSideAction
    WaitForJobCompletion -JobId $failoverjob.Name
}

<#
.SYNOPSIS
    Test-A2ASingleVMReprotect parametersets
#>
function Test-A2ASingleVMReprotect{
$vault = Get-AzRecoveryServicesVault -Name "vijamireprotecttest" -ResourceGroupName "vijami-alertrg"

Set-AzRecoveryServicesAsrVaultContext -Vault $vault

$primaryfabric = Get-AzRecoveryServicesAsrFabric -Name asr-a2a-default-uksouth

$PrimaryProtContainer = Get-AzRecoveryServicesAsrProtectionContainer -Fabric $primaryfabric

$recoveryfabric = Get-AzRecoveryServicesAsrFabric -Name asr-a2a-default-ukwest

$RecoveryContainer = Get-AzRecoveryServicesAsrProtectionContainer -Fabric $recoveryfabric

$RecoveryMapping = Get-AzRecoveryServicesAsrProtectionContainerMapping -ProtectionContainer $RecoveryContainer -Name  ukwest-uksouth-24-hour-retention-policy

$ReplicationProtectedItem = Get-AzRecoveryServicesAsrReplicationProtectedItem -FriendlyName "reprotectvm" -ProtectionContainer $PrimaryProtContainer

$CacheStorageAccount = "/subscriptions/7c943c1b-5122-4097-90c8-861411bdd574/resourceGroups/gl-rec-rg-prod-z2zgql-ukw/providers/Microsoft.Storage/storageAccounts/bootdiag0411052737"

$rgId = "/subscriptions/7c943c1b-5122-4097-90c8-861411bdd574/resourceGroups/vijami-alertrg"

$ReprotectJob = Update-AzRecoveryServicesAsrProtectionDirection -AzureToAzure -ReplicationProtectedItem $ReplicationProtectedItem -ProtectionContainerMapping $RecoveryMapping -LogStorageAccountId $CacheStorageAccount -RecoveryResourceGroupID $rgId

[Microsoft.Rest.ClientRuntime.Azure.TestFramework.TestUtilities]::Wait(20 * 1000)
WaitForJobCompletion -JobId $ReprotectJob.Name
}