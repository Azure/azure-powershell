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

# Inputs
$vaultRg = "vmwaresrcrg"
$vaultName = "v2aRcm-pwsh-test"
$primaryFabricName = "v2aRcm-pwsh-testreplicationfabric"
$primaryContainerName = "v2aRcm-pwsh-test0afareplicationcontainer"
$policyName = "v2aRcm-pwsh-testpolicy"
$failbackPolicyName = "appconsistency-policy-failback"
$primaryContainerMappingName = "v2aRcm-pwsh-testmapping"
$recoveryContainerMappingName = "appconsistency-failback-containerpairing"

$vmName = "V2ARCM-Pwsh-Vm"
$recoveryVmName = "V2ARCM-Pwsh-Vm"
$updateRecoveryVmName = "v2aRcm-ps-vm"
$recoveryPlanName = "v2arcm-pwsh-rp"
$credentialsName = "windows-creds"
$recoveryAzureNetworkId = "/subscriptions/7c943c1b-5122-4097-90c8-861411bdd574/resourceGroups/vmwaretargetrg/providers/Microsoft.Network/virtualNetworks/v2arcm-vnet"
$testNetworkId = "/subscriptions/7c943c1b-5122-4097-90c8-861411bdd574/resourceGroups/vmwaretargetrg/providers/Microsoft.Network/virtualNetworks/v2arcm-vnet"
$recoveryAzureSubnetName = "default"
$testSubnetName = "default"
$recoveryResourceGroupId = "/subscriptions/7c943c1b-5122-4097-90c8-861411bdd574/resourceGroups/vmwaretargetrg"
$logStorageAccountId = "/subscriptions/7c943c1b-5122-4097-90c8-861411bdd574/resourceGroups/vmwaretargetrg/providers/Microsoft.Storage/storageAccounts/v2arcmpwshsa"
$recoveryBootDiagnosticsStorageAccountId = "/subscriptions/7c943c1b-5122-4097-90c8-861411bdd574/resourceGroups/vmwaretargetrg/providers/Microsoft.Storage/storageAccounts/v2arcmpwshsa"
$dataStoreName = "datastore1 (1)"

<#
.SYNOPSIS 
    Site Recovery V2A RCM Fabric Tests.
#>
function Test-V2ARCMFabric {
    
    # Set vault context.
    $Vault = Get-AzRecoveryServicesVault -ResourceGroupName $vaultRg -Name $vaultName
    Set-ASRVaultContext -Vault $Vault
    
    # Get fabric.
    $fabric = Get-AzRecoveryServicesAsrFabric -Name $primaryFabricName
    Assert-NotNull($fabric)
    Assert-NotNull($fabric.FriendlyName)
    Assert-NotNull($fabric.name)
    Assert-NotNull($fabric.ID)
    Assert-NotNull($fabric.FabricSpecificDetails)
    Assert-true { $fabric.name -eq $primaryFabricName }

    $fabricDetails = $fabric.FabricSpecificDetails

    Assert-NotNull($fabricDetails.VmwareSiteId)
    Assert-NotNull($fabricDetails.PhysicalSiteId)
    Assert-NotNull($fabricDetails.ServiceEndpoint)
    Assert-NotNull($fabricDetails.ServiceResourceId)
    Assert-NotNull($fabricDetails.ServiceContainerId)
    Assert-NotNull($fabricDetails.DataPlaneUri)
    Assert-NotNull($fabricDetails.ControlPlaneUri)
}

<#
.SYNOPSIS 
    Site Recovery V2A RCM Container Tests.
#>
function Test-V2ARCMContainer {
    
    # Set vault context.
    $Vault = Get-AzRecoveryServicesVault -ResourceGroupName $vaultRg -Name $vaultName
    Set-ASRVaultContext -Vault $Vault
    
    # Get fabric.
    $Fabric = Get-AzRecoveryServicesAsrFabric -Name $primaryFabricName
    Assert-NotNull($Fabric)
    Assert-true { $Fabric.name -eq $primaryFabricName }

    # Get container.
    $ContainerList = Get-ASRProtectionContainer -Fabric $Fabric
    Assert-NotNull($ContainerList)
    $Container = $ContainerList[0]
    Assert-NotNull($Container)
    Assert-NotNull($Container.id)
    Assert-AreEQUAL -actual $Container.FabricType -expected "InMageRcm"

    $Container = Get-AzRecoveryServicesAsrProtectionContainer -Name $primaryContainerName -Fabric $Fabric
    Assert-NotNull($Container)
    Assert-NotNull($Container.id)
    Assert-NotNull($Container.name)
    Assert-true { $Container.name -eq $primaryContainerName }
    Assert-AreEQUAL -actual $Container.FabricType -expected "InMageRcm"
}

<#
.SYNOPSIS
	Site Recovery V2A RCM Policy Tests.
#>
function Test-V2ARCMPolicy {

    # Set vault context.
    $Vault = Get-AzRecoveryServicesVault -ResourceGroupName $vaultRg -Name $vaultName
    Set-ASRVaultContext -Vault $Vault

    # Create policy.
    $Job = New-AzRecoveryServicesAsrPolicy -ReplicateVMwareToAzure -Name $policyName -RecoveryPointRetentionInHours 40 `
        -ApplicationConsistentSnapshotFrequencyInHours 15 -MultiVmSyncStatus Disable
    WaitForJobCompletion -JobId $Job.Name
     
    # Get policy details.
    $Policy = Get-AzRecoveryServicesAsrPolicy -Name $policyName
    Assert-NotNull($Policy)
    Assert-True { $Policy.Count -gt 0 }

    $FailbackPolicy = Get-AzRecoveryServicesAsrPolicy -Name $failbackPolicyName
    Assert-NotNull($FailbackPolicy)
    Assert-True { $FailbackPolicy.Count -gt 0 }

    # Update policy.
    $Job = Update-AzRecoveryServicesAsrPolicy -ReplicateVMwareToAzure -InputObject $Policy -ApplicationConsistentSnapshotFrequencyInHours 5
    WaitForJobCompletion -JobId $Job.Name
     
    # Get policy details.
    $Policy = Get-AzRecoveryServicesAsrPolicy -Name $policyName
    Assert-NotNull($Policy)
    Assert-True { $Policy.Count -gt 0 }
}

<#
.SYNOPSIS
	Site Recovery V2A RCM Container Mapping Test.
#>
function Test-V2ARCMContainerMapping {
	
    # Set vault context.
    $Vault = Get-AzRecoveryServicesVault -ResourceGroupName $vaultRg -Name $vaultName
    Set-ASRVaultContext -Vault $Vault
    
    # Get fabric.
    $Fabric = Get-AzRecoveryServicesAsrFabric -Name $primaryFabricName
    Assert-NotNull($Fabric)
    Assert-true { $Fabric.name -eq $primaryFabricName }

    # Get container.
    $Container = Get-AzRecoveryServicesAsrProtectionContainer -Name $primaryContainerName -Fabric $Fabric
    Assert-NotNull($Container)
    Assert-true { $Container.name -eq $primaryContainerName }

    # Get policy.
    $Policy = Get-AzRecoveryServicesAsrPolicy -Name $policyName
    Assert-NotNull($Policy)
    Assert-True { $Policy.Count -gt 0 }

    $FailbackPolicy = Get-AzRecoveryServicesAsrPolicy -Name $failbackPolicyName
    Assert-NotNull($FailbackPolicy)
    Assert-True { $FailbackPolicy.Count -gt 0 }

    # Create mapping.
    $Job = New-AzRecoveryServicesAsrProtectionContainerMapping -Name $primaryContainerMappingName -policy $Policy `
        -PrimaryProtectionContainer $Container
    WaitForJobCompletion -JobId $Job.Name

    # Get mapping.
    $Mapping = Get-AzRecoveryServicesAsrProtectionContainerMapping -ProtectionContainer $Container `
        -Name $primaryContainerMappingName    
    Assert-NotNull($Mapping)
}

<#
.SYNOPSIS
	Site Recovery V2A RCM Enable Replication Test.
#>
function Test-V2ARCMEnableDR {

    # Set vault context.
    $Vault = Get-AzRecoveryServicesVault -ResourceGroupName $vaultRg -Name $vaultName
    Set-ASRVaultContext -Vault $Vault
    
    # Get fabric.
    $Fabric = Get-AzRecoveryServicesAsrFabric -Name $primaryFabricName
    Assert-NotNull($Fabric)
    Assert-true { $Fabric.name -eq $primaryFabricName }

    # Get container.
    $Container = Get-AzRecoveryServicesAsrProtectionContainer -Name $primaryContainerName -Fabric $Fabric
    Assert-NotNull($Container)
    Assert-true { $Container.name -eq $primaryContainerName }
	
    # Get policy.
    $Policy = Get-AzRecoveryServicesAsrPolicy -Name $policyName
    Assert-NotNull($Policy)
    Assert-True { $Policy.Count -gt 0 }

    # Get mapping.
    $Mapping = Get-AzRecoveryServicesAsrProtectionContainerMapping -ProtectionContainer $Container `
        -Name $primaryContainerMappingName    
    Assert-NotNull($Mapping)

    # Refresh DRA.
    $dras = Get-ASRServicesProvider -Fabric $fabric 
    $Job = Update-ASRServicesProvider -InputObject $dras[0]
    WaitForJobCompletion -JobId $Job.Name

    # Get updated fabric details.
    $Fabric = Get-AzRecoveryServicesAsrFabric -Name $primaryFabricName
    Assert-NotNull($Fabric)
    Assert-NotNull($Fabric.FabricSpecificDetails.ProcessServers)
    Assert-NotNull($Fabric.FabricSpecificDetails.ProcessServers[0].ID)

    # Get protectable item.
    $ProtectableItem = Get-ASRProtectableItem -ProtectionContainer $Container `
        -SiteId $Fabric.FabricSpecificDetails.VmwareSiteId -FriendlyName $vmName

    # Enable replication.
    $Job = New-AzRecoveryServicesAsrReplicationProtectedItem -ReplicateVMwareToAzure -ProtectableItem $ProtectableItem `
        -Name $vmName -RecoveryVmName $recoveryVmName -TestNetworkId $testNetworkId `
        -TestSubnetName $testSubnetName	-ProtectionContainerMapping $Mapping -CredentialsToAccessVm $credentialsName `
        -LogStorageAccountId $LogStorageAccountId -ApplianceName $Fabric.FabricSpecificDetails.ProcessServers[0].Name -Fabric $Fabric `
        -RecoveryAzureNetworkId $recoveryAzureNetworkId -RecoveryAzureSubnetName $recoveryAzureSubnetName `
        -RecoveryResourceGroupId $recoveryResourceGroupId -RecoveryBootDiagStorageAccountId $recoveryBootDiagnosticsStorageAccountId `
        -DiskType Standard_LRS
}

<#
.SYNOPSIS
	Site Recovery V2A RCM Update Protection Test.
#>
function Test-V2ARCMUpdateProtection {

    # Set vault context.
    $Vault = Get-AzRecoveryServicesVault -ResourceGroupName $vaultRg -Name $vaultName
    Set-ASRVaultContext -Vault $Vault
    
    # Get fabric.
    $Fabric = Get-AzRecoveryServicesAsrFabric -Name $primaryFabricName
    Assert-NotNull($Fabric)
    Assert-true { $Fabric.name -eq $primaryFabricName }

    # Get container.
    $Container = Get-AzRecoveryServicesAsrProtectionContainer -Name $primaryContainerName -Fabric $Fabric
    Assert-NotNull($Container)
    Assert-true { $Container.name -eq $primaryContainerName }

    # Get protected item.
    $RPI = Get-AzRecoveryServicesAsrReplicationProtectedItem -ProtectionContainer $Container -FriendlyName $vmName
    Assert-NotNull($RPI)
    Assert-NotNull($RPI.providerSpecificDetails)
		
    # Update protected item .
    $job = Set-AzRecoveryServicesAsrReplicationProtectedItem -InputObject $RPI -Name $updateRecoveryVmName -Size Standard_D1
    WaitForJobCompletion -JobId $Job.Name

    # Get protected item.
    $RPI = Get-AzRecoveryServicesAsrReplicationProtectedItem -ProtectionContainer $Container -FriendlyName $vmName
    Assert-NotNull($RPI)
    Assert-true { $RPI.providerSpecificDetails.TargetVmName -eq $updateRecoveryVmName }
}

<#
.SYNOPSIS
	Site Recovery V2A RCM TFO Test.
#>
function Test-V2ARCMTestFailover {

    # Set vault context.
    $Vault = Get-AzRecoveryServicesVault -ResourceGroupName $vaultRg -Name $vaultName
    Set-ASRVaultContext -Vault $Vault
    
    # Get fabric.
    $Fabric = Get-AzRecoveryServicesAsrFabric -Name $primaryFabricName
    Assert-NotNull($Fabric)
    Assert-true { $Fabric.name -eq $primaryFabricName }

    # Get container.
    $Container = Get-AzRecoveryServicesAsrProtectionContainer -Name $primaryContainerName -Fabric $Fabric
    Assert-NotNull($Container)
    Assert-true { $Container.name -eq $primaryContainerName }

    # Get protected item.
    $RPI = Get-AzRecoveryServicesAsrReplicationProtectedItem -ProtectionContainer $Container -FriendlyName $vmName
    Assert-NotNull($RPI)
    Assert-NotNull($RPI.providerSpecificDetails)
		
    # Test failover.
    $Job = Start-ASRTestFailoverJob -ReplicationProtectedItem $RPI -Direction PrimaryToRecovery -AzureVMNetworkId $testNetworkID
    WaitForJobCompletion -JobId $Job.Name

    # Test failover clean-up.
    $Job = Start-ASRTestFailoverCleanupJob -ReplicationProtectedItem $RPI
    WaitForJobCompletion -JobId $Job.Name
}

<#
.SYNOPSIS
	Site Recovery V2A RCM Failover Test.
#>
function Test-V2ARCMFailover {

    # Set vault context.
    $Vault = Get-AzRecoveryServicesVault -ResourceGroupName $vaultRg -Name $vaultName
    Set-ASRVaultContext -Vault $Vault
    
    # Get fabric.
    $Fabric = Get-AzRecoveryServicesAsrFabric -Name $primaryFabricName
    Assert-NotNull($Fabric)
    Assert-true { $Fabric.name -eq $primaryFabricName }

    # Get container.
    $Container = Get-AzRecoveryServicesAsrProtectionContainer -Name $primaryContainerName -Fabric $Fabric
    Assert-NotNull($Container)
    Assert-true { $Container.name -eq $primaryContainerName }
	
    # Get protected item.
    $RPI = Get-AzRecoveryServicesAsrReplicationProtectedItem -ProtectionContainer $Container -FriendlyName $vmName
    Assert-NotNull($RPI)
    Assert-NotNull($RPI.providerSpecificDetails)
		
    # Failover.
    $Job = Start-AzRecoveryServicesAsrUnPlannedFailoverJob -ReplicationProtectedItem $RPI -Direction PrimaryToRecovery
    WaitForJobCompletion -JobId $Job.Name
}

<#
.SYNOPSIS
	Site Recovery V2A RCM Commit Test.
#>
function Test-V2ARCMCommit {

    # Set vault context.
    $Vault = Get-AzRecoveryServicesVault -ResourceGroupName $vaultRg -Name $vaultName
    Set-ASRVaultContext -Vault $Vault
    
    # Get fabric.
    $Fabric = Get-AzRecoveryServicesAsrFabric -Name $primaryFabricName
    Assert-NotNull($Fabric)
    Assert-true { $Fabric.name -eq $primaryFabricName }

    # Get container.
    $Container = Get-AzRecoveryServicesAsrProtectionContainer -Name $primaryContainerName -Fabric $Fabric
    Assert-NotNull($Container)
    Assert-true { $Container.name -eq $primaryContainerName }
	
    # Get protected item.
    $RPI = Get-AzRecoveryServicesAsrReplicationProtectedItem -ProtectionContainer $Container -FriendlyName $vmName
    Assert-NotNull($RPI)
    Assert-NotNull($RPI.providerSpecificDetails)
		
    # Commit.
    $Job = Start-AzRecoveryServicesAsrCommitFailoverJob -ReplicationProtectedItem $RPI 
    WaitForJobCompletion -JobId $Job.Name
}

<#
.SYNOPSIS
	Site Recovery V2A RCM Reprotect Test.
#>
function Test-V2ARCMReprotect {

    # Set vault context.
    $Vault = Get-AzRecoveryServicesVault -ResourceGroupName $vaultRg -Name $vaultName
    Set-ASRVaultContext -Vault $Vault
    
    # Get fabric.
    $Fabric = Get-AzRecoveryServicesAsrFabric -Name $primaryFabricName
    Assert-NotNull($Fabric)
    Assert-true { $Fabric.name -eq $primaryFabricName }
    Assert-NotNull($Fabric.FabricSpecificDetails.ProcessServers)
    Assert-NotNull($Fabric.FabricSpecificDetails.ProcessServers[0].ID)
    Assert-NotNull($Fabric.FabricSpecificDetails.ReprotectAgents[0].ID)

    # Get container.
    $Container = Get-AzRecoveryServicesAsrProtectionContainer -Name $primaryContainerName -Fabric $Fabric
    Assert-NotNull($Container)
    Assert-true { $Container.name -eq $primaryContainerName }
	
    # Get mapping.
    $FailbackMapping = Get-AzRecoveryServicesAsrProtectionContainerMapping -ProtectionContainer $Container `
        -Name $recoveryContainerMappingName    
    Assert-NotNull($FailbackMapping)

    # Get protected item.
    $RPI = Get-AzRecoveryServicesAsrReplicationProtectedItem -ProtectionContainer $Container -FriendlyName $vmName
    Assert-NotNull($RPI)
    Assert-NotNull($RPI.providerSpecificDetails)

    # Reprotect.
    $Job = Update-AzRecoveryServicesAsrProtectionDirection -ReplicateAzureToVMware -ProtectionContainerMapping $FailbackMapping `
        -ReplicationProtectedItem $RPI -Direction RecoveryToPrimary `
        -ApplianceName $Fabric.FabricSpecificDetails.ProcessServers[0].Name -Fabric $Fabric `
        -LogStorageAccountId $logStorageAccountId -DatastoreName $dataStoreName         
}

<#
.SYNOPSIS
	Site Recovery V2A RCM Failback Test.
#>
function Test-V2ARCMFailback {

    # Set vault context.
    $Vault = Get-AzRecoveryServicesVault -ResourceGroupName $vaultRg -Name $vaultName
    Set-ASRVaultContext -Vault $Vault
    
    # Get fabric.
    $Fabric = Get-AzRecoveryServicesAsrFabric -Name $primaryFabricName
    Assert-NotNull($Fabric)
    Assert-true { $Fabric.name -eq $primaryFabricName }

    # Get container.
    $Container = Get-AzRecoveryServicesAsrProtectionContainer -Name $primaryContainerName -Fabric $Fabric
    Assert-NotNull($Container)
    Assert-true { $Container.name -eq $primaryContainerName }
	
    # Get protected item.
    $RPI = Get-AzRecoveryServicesAsrReplicationProtectedItem -ProtectionContainer $Container -FriendlyName $recoveryVmName
    Assert-NotNull($RPI)
    Assert-NotNull($RPI.providerSpecificDetails)
		
    # Failback.
    $Job = Start-AzRecoveryServicesAsrPlannedFailoverJob -ReplicationProtectedItem $RPI -Direction RecoveryToPrimary `
        -RecoveryTag RecoveryTagApplicationConsistent
    WaitForJobCompletion -JobId $Job.Name
}

<#
.SYNOPSIS
	Site Recovery V2A RCM Cancel Failover Test.
#>
function Test-V2ARCMCancelFailover {

    # Set vault context.
    $Vault = Get-AzRecoveryServicesVault -ResourceGroupName $vaultRg -Name $vaultName
    Set-ASRVaultContext -Vault $Vault
    
    # Get fabric.
    $Fabric = Get-AzRecoveryServicesAsrFabric -Name $primaryFabricName
    Assert-NotNull($Fabric)
    Assert-true { $Fabric.name -eq $primaryFabricName }

    # Get container.
    $Container = Get-AzRecoveryServicesAsrProtectionContainer -Name $primaryContainerName -Fabric $Fabric
    Assert-NotNull($Container)
    Assert-true { $Container.name -eq $primaryContainerName }
	
    # Get protected item.
    $RPI = Get-AzRecoveryServicesAsrReplicationProtectedItem -ProtectionContainer $Container -FriendlyName $recoveryVmName
    Assert-NotNull($RPI)
    Assert-NotNull($RPI.providerSpecificDetails)
		
    # Cancel failover.
    $Job = Start-ASRCancelFailover -ReplicationProtectedItem $RPI 
    WaitForJobCompletion -JobId $Job.Name
}

<#
.SYNOPSIS 
    Site Recovery V2A RCM Recovery Plan Test
#>
function Test-V2ARCMRecoveryPlan {

    # Set vault context
    $Vault = Get-AzRecoveryServicesVault -ResourceGroupName $vaultRg -Name $vaultName
    Set-ASRVaultContext -Vault $Vault
    
    # Get fabric
    $Fabric = Get-AzRecoveryServicesAsrFabric -Name $primaryFabricName
    Assert-NotNull($Fabric)
    Assert-true { $Fabric.name -eq $primaryFabricName }

    # Get container
    $Container = Get-AzRecoveryServicesAsrProtectionContainer -Name $primaryContainerName -Fabric $Fabric
    Assert-NotNull($Container)
    Assert-true { $Container.name -eq $primaryContainerName }

    # Get protected item
    $RPI = Get-AzRecoveryServicesAsrReplicationProtectedItem -ProtectionContainer $Container -Name $vmName
    Assert-NotNull($RPI)
    Assert-NotNull($RPI.providerSpecificDetails)
		
    # Create Recovery Plan
    $Job = New-AzRecoveryServicesAsrRecoveryPlan -Azure -Name $recoveryPlanName -PrimaryFabric $Fabric `
        -ReplicationProtectedItem $RPI -FailoverDeploymentModel ResourceManager 
    WaitForJobCompletion -JobId $Job.Name

    # Get Recovery Plan
    $RecoveryPlan = Get-AzRecoveryServicesAsrRecoveryPlan -Name $recoveryPlanName 
    Assert-NotNull($RecoveryPlan)

    # Remove Recovery Plan
    $Job = Remove-AzRecoveryServicesAsrRecoveryPlan -InputObject $RecoveryPlan
    WaitForJobCompletion -JobId $Job.Name
}

<#
.SYNOPSIS
    Wait for job completion.

    Usage:
        WaitForJobCompletion -JobId $Job.ID
        WaitForJobCompletion -JobId $Job.ID -NumOfSecondsToWait 10
#>
function WaitForJobCompletion { 
    param(
        [string] $JobId,
        [int] $JobQueryWaitTimeInSeconds = $JobQueryWaitTimeInSeconds
    )
    $isJobLeftForProcessing = $true;
    do {
        $Job = Get-AzRecoveryServicesAsrJob -Name $JobId
        $Job

        if ($Job.State -eq "InProgress" -or $Job.State -eq "NotStarted") {
            $isJobLeftForProcessing = $true
        }
        else {
            $isJobLeftForProcessing = $false
        }

        if ($isJobLeftForProcessing) {
            [Microsoft.Rest.ClientRuntime.Azure.TestFramework.TestUtilities]::Wait($JobQueryWaitTimeInSeconds * 1000)
        }
    } While ($isJobLeftForProcessing)
}
