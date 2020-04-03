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

$JobQueryWaitTimeInSeconds = 0
$PrimaryFabricName = "vijamiMig-lat29ddreplicationfabric"
$policyName = "VmwareCbtTestPolicy"
$PrimaryProtectionContainerMapping = "pcmmapping"
$pcName = "vijamiMig-lat29ddreplicationcontainer"
$AzureVmNetworkId = "/subscriptions/7c943c1b-5122-4097-90c8-861411bdd574/resourceGroups/vijami-rg/providers/Microsoft.Network/virtualNetworks/aznetworkcus"
$miName = "vi-win-test"

<#
.SYNOPSIS
Wait for job completion
Usage:
    WaitForJobCompletion -JobId $Job.ID
    WaitForJobCompletion -JobId $Job.ID -NumOfSecondsToWait 10
#>
function WaitForJobCompletion
{ 
    param(
        [string] $JobId,
        [int] $JobQueryWaitTimeInSeconds =$JobQueryWaitTimeInSeconds
        )
        $isJobLeftForProcessing = $true;
        do
        {
            $Job = Get-AzRecoveryServicesAsrJob -Name $JobId
            $Job

            if($Job.State -eq "InProgress" -or $Job.State -eq "NotStarted")
            {
                $isJobLeftForProcessing = $true
            }
            else
            {
                $isJobLeftForProcessing = $false
            }

            if($isJobLeftForProcessing)
            {
                [Microsoft.Rest.ClientRuntime.Azure.TestFramework.TestUtilities]::Wait($JobQueryWaitTimeInSeconds * 1000)
            }
        }While($isJobLeftForProcessing)
}

<#
.SYNOPSIS
Wait for IR job completion
Usage:
    WaitForJobCompletion -VM $VM
    WaitForJobCompletion -VM $VM -NumOfSecondsToWait 10
#>
Function WaitForIRCompletion
{ 
    param(
        [PSObject] $TargetObjectId,
        [int] $JobQueryWaitTimeInSeconds = $JobQueryWaitTimeInSeconds
        )
        $isProcessingLeft = $true
        $IRjobs = $null

        do
        {
            $IRjobs = Get-AzRecoveryServicesAsrJob -TargetObjectId $TargetObjectId | Sort-Object StartTime -Descending | select -First 1 | Where-Object{$_.JobType -eq "IrCompletion"}
            if($IRjobs -eq $null -or $IRjobs.Count -lt 1)
            {
                $isProcessingLeft = $true
            }
            else
            {
                $isProcessingLeft = $false
            }

            if($isProcessingLeft)
            {
                [Microsoft.Rest.ClientRuntime.Azure.TestFramework.TestUtilities]::Wait($JobQueryWaitTimeInSeconds * 1000)
            }
        }While($isProcessingLeft)

        $IRjobs
        WaitForJobCompletion -JobId $IRjobs[0].Name -JobQueryWaitTimeInSeconds $JobQueryWaitTimeInSeconds
}

<#
.SYNOPSIS
Site Recovery Fabric Tests New model
#>
function Test-SiteRecoveryFabricTest
{
    param([string] $vaultSettingsFilePath)

    # Import Azure RecoveryServices Vault Settings File
    Import-AzRecoveryServicesAsrVaultSettingsFile -Path $vaultSettingsFilePath
    # Enumerate specific Fabric
    $fabricList =  Get-AsrFabric
    Assert-NotNull($fabricList)

    $fabric =  Get-AsrFabric -FriendlyName $PrimaryFabricName
    Assert-NotNull($fabric)
    Assert-NotNull($fabric.FriendlyName)
    Assert-NotNull($fabric.name)
    Assert-NotNull($fabric.ID)
    Assert-NotNull($fabric.Type)
    Assert-NotNull($fabric.FabricType)
    Assert-NotNull($fabric.FabricSpecificDetails)

    $fabricDetails = $fabric.FabricSpecificDetails

    Assert-NotNull($fabricDetails.MigrationSolutionId)
    Assert-NotNull($fabricDetails.ServiceEndpoint)
    Assert-NotNull($fabricDetails.ServiceResourceId)
    Assert-NotNull($fabricDetails.VmwareSiteId)
}

<#
.SYNOPSIS
Site Recovery Protection Container - get.
#>
function Test-PC
{
    param([string] $vaultSettingsFilePath)

    # Import Azure RecoveryServices Vault Settings File
    Import-AzRecoveryServicesAsrVaultSettingsFile -Path $vaultSettingsFilePath
    $fabric =  Get-AsrFabric -FriendlyName $PrimaryFabricName
    # Create profile

    $ProtectionContainerList =  Get-ASRProtectionContainer -Fabric $fabric
    Assert-NotNull($ProtectionContainerList)
    $ProtectionContainer = $ProtectionContainerList[0]
    Assert-NotNull($ProtectionContainer)
    Assert-NotNull($ProtectionContainer.id)
    Assert-AreEQUAL -actual $ProtectionContainer.FabricType -expected "VMwareV2"

    $ProtectionContainer =  Get-ASRProtectionContainer -FriendlyName $pcName -Fabric $fabric
    Assert-NotNull($ProtectionContainer)
    Assert-NotNull($ProtectionContainer.id)
    Assert-AreEQUAL -actual $ProtectionContainer.FabricType -expected "VMwareV2"

    $ProtectionContainer =  Get-ASRProtectionContainer -Name $ProtectionContainer.Name -Fabric $fabric
    Assert-NotNull($ProtectionContainer)
    Assert-NotNull($ProtectionContainer.id)
    Assert-AreEQUAL -actual $ProtectionContainer.FabricType -expected "VMwareV2"
}

<#
.SYNOPSIS
Site Recovery Create Policy Test -new get remove
#>
function Test-SiteRecoveryPolicy
{
    param([string] $vaultSettingsFilePath)

    # Import Azure RecoveryServices Vault Settings File
    Import-AzRecoveryServicesAsrVaultSettingsFile -Path $vaultSettingsFilePath

    $Job = New-AzRecoveryServicesAsrPolicy -Name $policyName -VMwareCbt -RecoveryPointRetentionInHours 1 -ApplicationConsistentSnapshotFrequencyInHours 1 -CrashConsistentFrequencyInMinutes 15
    WaitForJobCompletion -JobId $Job.Name
    # Get a profile created (with name ppAzure)
    $Policy1 = Get-AzRecoveryServicesAsrPolicy -Name $PolicyName
    Assert-True { $Policy1.Count -gt 0 }
    Assert-NotNull($Policy1)

    # Remove the Job created
    $RemoveJob = Remove-ASRPolicy -InputObject $Policy1
}

<#
.SYNOPSIS
Site Recovery Protection Container Mapping  - new get remove
#>
function Test-PCM 
{
    param([string] $vaultSettingsFilePath)

    Import-AzRecoveryServicesAsrVaultSettingsFile -Path $vaultSettingsFilePath
    $fabric =  Get-AsrFabric -FriendlyName $PrimaryFabricName

    Import-AzRecoveryServicesAsrVaultSettingsFile -Path $vaultSettingsFilePath

    $pc =  Get-ASRProtectionContainer -FriendlyName $pcName -Fabric $fabric

    $Job = New-AzRecoveryServicesAsrPolicy -Name $policyName -VMwareCbt -RecoveryPointRetentionInHours 1 -ApplicationConsistentSnapshotFrequencyInHours 1 -CrashConsistentFrequencyInMinutes 15
    waitForJobCompletion -JobId $Job.name

    $Policy = Get-AzRecoveryServicesAsrPolicy -Name $PolicyName

    $KeyVaultId = "/subscriptions/7c943c1b-5122-4097-90c8-861411bdd574/resourceGroups/vijami-rg/providers/Microsoft.KeyVault/vaults/migratekv1214124206"
    $KeyVaultUri = "https://migratekv1214124206.vault.azure.net"
    $StorageAccountId = "/subscriptions/7c943c1b-5122-4097-90c8-861411bdd574/resourceGroups/vijami-rg/providers/Microsoft.Storage/storageAccounts/migrategwsa1214124206"
    $StorageAccountSasSecretName = "migrategwsa1214124206-gwySas"
    $ServiceBusConnectionStringSecretName = "ServiceBusConnectionString"
    $PrimaryProtectionContainerMapping = "pcmmapping"
    $TargetLocation = "centralus"
    # Create Mapping
    $pcmjob =  New-AzRecoveryServicesAsrProtectionContainerMapping -Name $PrimaryProtectionContainerMapping -policy $Policy -PrimaryProtectionContainer $pc -KeyVaultId $KeyVaultId -KeyVaultUri $KeyVaultUri -StorageAccountId $StorageAccountId -StorageAccountSasSecretName $StorageAccountSasSecretName -ServiceBusConnectionStringSecretName $ServiceBusConnectionStringSecretName -TargetLocation $TargetLocation
    WaitForJobCompletion -JobId $pcmjob.Name

    $pcm = Get-ASRProtectionContainerMapping -Name $PrimaryProtectionContainerMapping -ProtectionContainer $pc
    Assert-NotNull($pcm)

    $Removepcm = Remove-AzRecoveryServicesAsrProtectionContainerMapping  -InputObject $pcm
    WaitForJobCompletion -JobId $Removepcm.Name
}

<#
.SYNOPSIS
Site Recovery Replication Create ReplicationMigrationItem
#>
function V2ACreateRMI
{
    param([string] $vaultSettingsFilePath)

    # Import Azure RecoveryServices Vault Settings File
    Import-AzRecoveryServicesAsrVaultSettingsFile -Path $vaultSettingsFilePath

    $fabric =  Get-AsrFabric -FriendlyName $PrimaryFabricName
    $pc =  Get-ASRProtectionContainer -FriendlyName $pcName -Fabric $fabric
    $Job1 = New-AzRecoveryServicesAsrPolicy -Name $policyName -VMwareCbt -RecoveryPointRetentionInHours 1 -ApplicationConsistentSnapshotFrequencyInHours 1 -CrashConsistentFrequencyInMinutes 15

    WaitForJobCompletion -JobId $Job1.Name

    $Policy = Get-AzRecoveryServicesAsrPolicy -Name $PolicyName

    # Create Mapping
    $KeyVaultId = "/subscriptions/7c943c1b-5122-4097-90c8-861411bdd574/resourceGroups/vijami-rg/providers/Microsoft.KeyVault/vaults/migratekv1214124206"
    $KeyVaultUri = "https://migratekv1214124206.vault.azure.net"
    $StorageAccountId = "/subscriptions/7c943c1b-5122-4097-90c8-861411bdd574/resourceGroups/vijami-rg/providers/Microsoft.Storage/storageAccounts/migrategwsa1214124206"
    $StorageAccountSasSecretName = "migrategwsa1214124206-gwySas"
    $ServiceBusConnectionStringSecretName = "ServiceBusConnectionString"
    $PrimaryProtectionContainerMapping = "pcmmapping"
    $TargetLocation = "centralus"
    # Create Mapping
    $pcmjob =  New-AzRecoveryServicesAsrProtectionContainerMapping -Name $PrimaryProtectionContainerMapping -policy $Policy -PrimaryProtectionContainer $pc -KeyVaultId $KeyVaultId -KeyVaultUri $KeyVaultUri -StorageAccountId $StorageAccountId -StorageAccountSasSecretName $StorageAccountSasSecretName -ServiceBusConnectionStringSecretName $ServiceBusConnectionStringSecretName -TargetLocation $TargetLocation
    WaitForJobCompletion -JobId $pcmjob.Name

    $pcm = Get-ASRProtectionContainerMapping -Name $PrimaryProtectionContainerMapping -ProtectionContainer $pc

    $DiskInput = New-Object -TypeName Microsoft.Azure.Commands.RecoveryServices.SiteRecovery.ASRVMwareCbtDiskInput

    $DiskInput.DiskId="6000C29d-2131-1432-da5f-9360853f5703"
    $DiskInput.LogStorageAccountId="/subscriptions/7c943c1b-5122-4097-90c8-861411bdd574/resourceGroups/vijami-rg/providers/Microsoft.Storage/storageAccounts/migratelsa1214124206"
    $DiskInput.LogStorageAccountSasSecretName="migratelsa1214124206-cacheSas"
    $DiskInput.IsOSDisk="true"
    $VMwareMachineId = "/subscriptions/7c943c1b-5122-4097-90c8-861411bdd574/resourceGroups/vijami-rg/providers/Microsoft.OffAzure/VMwareSites/vijamiMig-lat29ddsite/machines/bcdr-vcenter-fareast-corp-micro-cfcc5a24-a40e-56b9-a6af-e206c9ca4f93_500fa9a4-f6b4-9af4-7116-bceaf52564f6"
    $DataMoverRunAsAccountId = "/subscriptions/7c943c1b-5122-4097-90c8-861411bdd574/resourceGroups/vijami-rg/providers/Microsoft.OffAzure/VMwareSites/vijamiMig-lat29ddsite/runasaccounts/cfcc5a24-a40e-56b9-a6af-e206c9ca4f93"
    $SnapshotRunAsAccountId = "/subscriptions/7c943c1b-5122-4097-90c8-861411bdd574/resourceGroups/vijami-rg/providers/Microsoft.OffAzure/VMwareSites/vijamiMig-lat29ddsite/runasaccounts/cfcc5a24-a40e-56b9-a6af-e206c9ca4f93"
    $TargetNetworkId = "/subscriptions/7c943c1b-5122-4097-90c8-861411bdd574/resourceGroups/vijami-rg/providers/Microsoft.Network/virtualNetworks/aznetworkcus"
    $TargetResourceGroupId = "/subscriptions/7c943c1b-5122-4097-90c8-861411bdd574/resourceGroups/vijami-rg"
    $TargetBootDiagnosticsStorageAccountId="/subscriptions/7c943c1b-5122-4097-90c8-861411bdd574/resourceGroups/vijami-rg/providers/Microsoft.Storage/storageAccounts/migratelsa1214124206"
    $CreateMigrateItemjob = New-AzRecoveryServicesAsrReplicationMigrationItem -Name "vi-win-test" -ProtectionContainerMapping $pcm -VMwareMachineId $VMwareMachineId -DataMoverRunAsAccountId $DataMoverRunAsAccountId -SnapshotRunAsAccountId $SnapshotRunAsAccountId -TargetResourceGroupId $TargetResourceGroupId -TargetNetworkId $TargetNetworkId -TargetBootDiagnosticsStorageAccountId $TargetBootDiagnosticsStorageAccountId -PerformAutoResync -DisksToInclude $DiskInput
    WaitForJobCompletion -JobId $CreateMigrateItemjob.Name

    $migrationItem = Get-AzRecoveryServicesAsrReplicationMigrationItem -Name "vi-win-test" -ProtectionContainer $pc

    #$RemoveMigrationItem = Remove-AzRecoveryServicesAsrReplicationMigrationItem -InputObject $migrationItem 
    #WaitForJobCompletion -JobId $RemoveMigrationItem.Name
    }

<#
.SYNOPSIS
Site Recovery Test migrate Job.
#>

function VmwareCbtTestMigrateJob
{
    param([string] $vaultSettingsFilePath)

    # Import Azure RecoveryServices Vault Settings File
    Import-AzRecoveryServicesAsrVaultSettingsFile -Path $vaultSettingsFilePath

    $fabric =  Get-AsrFabric -FriendlyName $PrimaryFabricName
    $pc =  Get-ASRProtectionContainer -FriendlyName $pcName -Fabric $fabric

    $migrationItem = Get-AzRecoveryServicesAsrReplicationMigrationItem -Name $miName -ProtectionContainer $pc

    do
    {
        $rPoints = Get-ASRMigrationRecoveryPoint -ReplicationMigrationItem $migrationItem
        if($rpoints -and  $rpoints.count  -eq 0) {
			#timeout 60
		}
		else
		{
			break
		}
    }while ($rpoints.count -lt 0)

    $testMigrateJob = Start-AzRecoveryServicesAsrTestMigrateJob -ReplicationMigrationItem $migrationItem -AzureVMNetworkId  $AzureVMNetworkId -MigrationRecoveryPoint $rpoints[0]

    WaitForJobCompletion -JobId $testMigrateJob.Name

    $cleanupJob = Start-AzRecoveryServicesAsrTestMigrateCleanupJob -ReplicationMigrationItem $migrationItem -Comment "testing done"
    WaitForJobCompletion -JobId $cleanupJob.Name
    }

    <#
    .SYNOPSIS
     Site Recovery migrate Job.
    #>
    function VmwareCbtMigrateJob
    {
        param([string] $vaultSettingsFilePath)

        # Import Azure RecoveryServices Vault Settings File
        Import-AzRecoveryServicesAsrVaultSettingsFile -Path $vaultSettingsFilePath

        $fabric =  Get-AsrFabric -FriendlyName $PrimaryFabricName
        $pc =  Get-ASRProtectionContainer -FriendlyName $pcName -Fabric $fabric

        $migrationItem = Get-AzRecoveryServicesAsrReplicationMigrationItem -Name $miName -ProtectionContainer $pc

        $migrateJob = Start-AzRecoveryServicesAsrMigrateJob -ReplicationMigrationItem $migrationItem -PerformShutdown
        WaitForJobCompletion -JobId $migrateJob.Name
    }
