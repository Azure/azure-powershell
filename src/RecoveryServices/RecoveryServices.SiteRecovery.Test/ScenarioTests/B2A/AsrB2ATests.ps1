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
$ResourceGroupName = "E2ERg"
$VaultName = "E2ETest"
$PrimaryFabricName = "primaryFriendlyName"

$RecoveryFabricName = "IDCLAB-A147.ntdev.corp.microsoft.com"
$PolicyName = "B2APolicyTest1"
$PrimaryProtectionContainerName = "primaryFriendlyName"
$RecoveryProtectionContainerName = "recovery"
$ProtectionContainerMappingName = "B2AClP26mapping"
$PrimaryNetworkFriendlyName = "corp"
$RecoveryNetworkFriendlyName = "corp"
$NetworkMappingName = "corp96map"
$VMName = "hyperV1"
$RecoveryPlanName = "RPSwag96"
$VmList = "hyperV1,hyperV2"
$RecoveryAzureStorageAccountId = "/subscriptions/7c943c1b-5122-4097-90c8-861411bdd574/resourceGroups/canaryexproute/providers/Microsoft.Storage/storageAccounts/ev2teststorage" 
$RecoveryResourceGroupId  = "/subscriptions/7c943c1b-5122-4097-90c8-861411bdd574/resourceGroups/canaryexproute" 
$AzureVmNetworkId = "/subscriptions/7c943c1b-5122-4097-90c8-861411bdd574/resourceGroups/canaryexproute/providers/Microsoft.Network/virtualNetworks/e2anetworksea"

$AzureNetworkID = $AzureVmNetworkId
$subnet = "default"
$storageAccountId = $RecoveryAzureStorageAccountId
$PrimaryCloudName = $PrimaryFabricName
$ProtectionProfileName = $PolicyName

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
        [int] $JobQueryWaitTimeInSeconds = 0,
        [string] $Message = "NA"
        )
        $isJobLeftForProcessing = $true;
        do
        {
            $Job = Get-AzRecoveryServicesAsrJob -Name $JobId
            Write-Host $("Job Status:") -ForegroundColor Green
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
                if($Message -ne "NA")
                {
                    Write-Host $Message -ForegroundColor Yellow
                }
                else
                {
                    Write-Host $($($Job.JobType) + " in Progress...") -ForegroundColor Yellow
                }
		        Write-Host $("Waiting for: " + $JobQueryWaitTimeInSeconds.ToString() + " Seconds") -ForegroundColor Yellow
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
        [PSObject] $VM,
        [int] $JobQueryWaitTimeInSeconds = 60
        )
        $isProcessingLeft = $true
        $IRjobs = $null

        Write-Host $("IR in Progress...") -ForegroundColor Yellow
        do
        {
            $IRjobs = Get-AzRecoveryServicesAsrJob -TargetObjectId $VM.Name | Sort-Object StartTime -Descending | select -First 5 | Where-Object{$_.JobType -eq "IrCompletion"}
            if($IRjobs -eq $null -or $IRjobs.Count -ne 1)
            {
                $isProcessingLeft = $true
            }
            else
            {
                $isProcessingLeft = $false
            }

            if($isProcessingLeft)
            {
                Write-Host $("IR in Progress...") -ForegroundColor Yellow
                Write-Host $("Waiting for: " + $JobQueryWaitTimeInSeconds.ToString() + " Seconds") -ForegroundColor Yellow
                [Microsoft.Rest.ClientRuntime.Azure.TestFramework.TestUtilities]::Wait($JobQueryWaitTimeInSeconds * 1000)
            }
        }While($isProcessingLeft)

        Write-Host $("Finalize IR jobs:") -ForegroundColor Green
        $IRjobs
        WaitForJobCompletion -JobId $IRjobs[0].Name -JobQueryWaitTimeInSeconds $JobQueryWaitTimeInSeconds -Message $("Finalize IR in Progress...")
}

<#
.SYNOPSIS
Site Recovery Enumeration Tests
#>
function Test-CreateFabric
{
    param([string] $vaultSettingsFilePath)

    # Import Azure RecoveryServices Vault Settings File
    Import-AzRecoveryServicesAsrVaultSettingsFile -Path $vaultSettingsFilePath

    $currentJob = New-AzRecoveryServicesAsrFabric -Name $PrimaryCloudName
	$currentJob
	WaitForJobCompletion -JobId $currentJob.Name
}

<#
.SYNOPSIS
Site Recovery Create Policy Test
#>
function Test-CreatePolicy
{
    param([string] $vaultSettingsFilePath)

    # Import Azure RecoveryServices Vault Settings File
    Import-AzRecoveryServicesAsrVaultSettingsFile -Path $vaultSettingsFilePath
    $currentJob = New-AzRecoveryServicesAsrPolicy -Name $ProtectionProfileName -ReplicationProvider HyperVReplicaAzure -ReplicationFrequencyInSeconds 30 -RecoveryPoints 1 -ApplicationConsistentSnapshotFrequencyInHours 0 -RecoveryAzureStorageAccountId $StorageAccountID
    WaitForJobCompletion -JobId $currentJob.Name
    $ProtectionProfile = Get-AzRecoveryServicesAsrPolicy -Name $ProtectionProfileName
    $ProtectionProfile
    
    $Policy = Get-AzRecoveryServicesAsrPolicy -Name $PolicyName
    Assert-True { $Policy.Count -gt 0 }
    Assert-NotNull($Policy)
}

<#
.SYNOPSIS
Site Recovery remove Policy Test
#>
function Test-SiteRecoveryRemovePolicy
{
    param([string] $vaultSettingsFilePath)

    # Import Azure RecoveryServices Vault Settings File
    Import-AzRecoveryServicesAsrVaultSettingsFile -Path $vaultSettingsFilePath

    # Get a policy created in previous test
    $Policy = Get-AzRecoveryServicesAsrPolicy -Name $PolicyName
    Assert-True { $Policy.Count -gt 0 }
    Assert-NotNull($Policy)

    # Delete the profile
    $Job = Remove-AzRecoveryServicesAsrPolicy -Policy $Policy
    #WaitForJobCompletion -JobId $Job.Name
}

<#
.SYNOPSIS
Site Recovery remove Policy Test
#>
function Test-RemoveFabric
{
    param([string] $vaultSettingsFilePath)

    # Import Azure RecoveryServices Vault Settings File
    Import-AzRecoveryServicesAsrVaultSettingsFile -Path $vaultSettingsFilePath

    # Get a policy created in previous test
    $fabric = Get-AzRecoveryServicesAsrFabric -FriendlyName $PrimaryFabricName 
    $job = Remove-ASRFabric -InputObject $fabric
    WaitForJobCompletion -JobId $job.Name

    Get-AzRecoveryServicesAsrFabric|Remove-ASRFabric
    #WaitForJobCompletion -JobId $Job.Name
}
<#
.SYNOPSIS
Site Recovery new protection container mapping test
#>
function Test-CreatePCMap
{
    param([string] $vaultSettingsFilePath)

    # Import Azure RecoveryServices Vault Settings File
    Import-AzRecoveryServicesAsrVaultSettingsFile -Path $vaultSettingsFilePath
    $Policy = Get-AzRecoveryServicesAsrPolicy -Name $PolicyName
    $PrimaryProtectionContainer = Get-AzRecoveryServicesAsrFabric -FriendlyName $PrimaryFabricName| Get-AzRecoveryServicesAsrProtectionContainer | where { $_.FriendlyName -eq $PrimaryProtectionContainerName }
    
	$currentJob = New-AzRecoveryServicesAsrProtectionContainerMapping -Name $ProtectionContainerMappingName -Policy $Policy -PrimaryProtectionContainer  $PrimaryProtectionContainer
    $currentJob
    WaitForJobCompletion -JobId $currentJob.Name 
   
    # Get protection conatiner mapping
    $ProtectionContainerMapping = Get-AzRecoveryServicesAsrProtectionContainerMapping -Name $ProtectionContainerMappingName -ProtectionContainer $PrimaryProtectionContainer
    Assert-NotNull($ProtectionContainerMapping)
}

<#
.SYNOPSIS
Site Recovery Enable protection Test
#>
function Test-SiteRecoveryEnableDR
{
    param([string] $vaultSettingsFilePath)

    # Import Azure RecoveryServices Vault Settings File
    Import-AzRecoveryServicesAsrVaultSettingsFile -Path $vaultSettingsFilePath

    $Policy = Get-AzRecoveryServicesAsrPolicy -Name $PolicyName
    $PrimaryProtectionContainer = Get-AzRecoveryServicesAsrFabric -FriendlyName $PrimaryFabricName| Get-AzRecoveryServicesAsrProtectionContainer | where { $_.FriendlyName -eq $PrimaryProtectionContainerName }
    $ProtectionContainerMapping = Get-AzRecoveryServicesAsrProtectionContainerMapping -Name $ProtectionContainerMappingName -ProtectionContainer $PrimaryProtectionContainer

    foreach($EnableVMName in $VmList.Split(','))
    {
        # Get protectable item
        $VM = Get-AzRecoveryServicesAsrProtectableItem -FriendlyName $EnableVMName -ProtectionContainer $PrimaryProtectionContainer  
        # EnableDR
        $Job = New-AzRecoveryServicesAsrReplicationProtectedItem -ProtectableItem $VM -Name $VM.Name -ProtectionContainerMapping $ProtectionContainerMapping -RecoveryAzureStorageAccountId $StorageAccountID -OSDiskName $($EnableVMName+"disk") -OS Windows -RecoveryResourceGroupId $RecoveryResourceGroupId
    }
}

<#
.SYNOPSIS
Site Recovery Update RPI
#>
function Test-UpdateRPI
{
    param([string] $vaultSettingsFilePath)

    # Import Azure RecoveryServices Vault Settings File
    Import-AzRecoveryServicesAsrVaultSettingsFile -Path $vaultSettingsFilePath

    $Policy = Get-AzRecoveryServicesAsrPolicy -Name $PolicyName
    $PrimaryProtectionContainer = Get-AzRecoveryServicesAsrFabric -FriendlyName $PrimaryFabricName| Get-AzRecoveryServicesAsrProtectionContainer | where { $_.FriendlyName -eq $PrimaryProtectionContainerName }
    
    foreach($EnableVMName in $VmList.Split(','))
    {
        # Get protectable item
        $v = Get-AzRecoveryServicesAsrReplicationProtectedItem -ProtectionContainer $PrimaryProtectionContainer -FriendlyName $EnableVMName
        $currentJob = Set-AzRecoveryServicesAsrReplicationProtectedItem -ReplicationProtectedItem $v -PrimaryNic $v.NicDetailsList[0].NicId -RecoveryNetworkId $AzureNetworkID -RecoveryNicSubnetName $subnet
    }
}

<#
.SYNOPSIS
Site Recovery Network Mapping
#>
function Test-MapNetwork
{
    param([string] $vaultSettingsFilePath)
    Import-AzRecoveryServicesAsrVaultSettingsFile -Path $vaultSettingsFilePath

    # Get the primary container
    $PrimaryFabric = Get-AzRecoveryServicesAsrFabric -FriendlyName $PrimaryFabricName
    $RecoveryFabric = Get-AzRecoveryServicesAsrFabric -FriendlyName $RecoveryFabricName

    # Get primary network
    $PrimaryNetwork = Get-AzRecoveryServicesAsrNetwork -Fabric $PrimaryFabric | where { $_.FriendlyName -eq $PrimaryNetworkFriendlyName}
    $RecoveryNetwork = Get-AzRecoveryServicesAsrNetwork -Fabric $RecoveryFabric | where { $_.FriendlyName -eq $RecoveryNetworkFriendlyName}

    # Create network mapping
    $Job = New-AzRecoveryServicesAsrNetworkMapping -Name $NetworkMappingName -PrimaryNetwork $PrimaryNetwork -RecoveryNetwork $RecoveryNetwork
    WaitForJobCompletion -JobId $Job.Name

    # Get network mapping
    $NetworkMapping = Get-AzRecoveryServicesAsrNetworkMapping -Name $NetworkMappingName -Network $PrimaryNetwork

    }

    function Test-RemoveNetworkPairing
    {
        param([string] $vaultSettingsFilePath)
        Import-AzRecoveryServicesAsrVaultSettingsFile -Path $vaultSettingsFilePath

        # Get the primary container
        $PrimaryFabric = Get-AzRecoveryServicesAsrFabric -FriendlyName $PrimaryFabricName
        $RecoveryFabric = Get-AzRecoveryServicesAsrFabric -FriendlyName $RecoveryFabricName

        # Get primary network
        $PrimaryNetwork = Get-AzRecoveryServicesAsrNetwork -Fabric $PrimaryFabric | where { $_.FriendlyName -eq $PrimaryNetworkFriendlyName}
        $RecoveryNetwork = Get-AzRecoveryServicesAsrNetwork -Fabric $RecoveryFabric | where { $_.FriendlyName -eq $RecoveryNetworkFriendlyName}

        # Get network mapping
        $job = Get-AzRecoveryServicesAsrNetworkMapping -Name $NetworkMappingName -Network $PrimaryNetwork |Remove-ASRNetworkMapping
        WaitForJobCompletion -JobId $Job.Name
    }
<#
.SYNOPSIS
Site Recovery Test Failover
#>
function Test-TFO
{
    param([string] $vaultSettingsFilePath)

    # Import Azure RecoveryServices Vault Settings File
    Import-AzRecoveryServicesAsrVaultSettingsFile -Path $vaultSettingsFilePath

    # Get the primary container
    $PrimaryProtectionContainer = Get-AzRecoveryServicesAsrFabric -FriendlyName $PrimaryFabricName | Get-AzRecoveryServicesAsrProtectionContainer | where { $_.FriendlyName -eq $PrimaryProtectionContainerName }
    
    $rpi = Get-AzRecoveryServicesAsrReplicationProtectedItem -FriendlyName $VMName -ProtectionContainer $PrimaryProtectionContainer 

	$job = Start-ASRTestFailoverJob -ReplicationProtectedItem $rpi -Direction PrimaryToRecovery -AzureVMNetworkId $AzureNetworkID
    WaitForJobCompletion -JobId $Job.Name

    $job = Start-ASRTestFailoverCleanupJob -ReplicationProtectedItem $rpi
    WaitForJobCompletion -JobId $Job.Name
}

<#
.SYNOPSIS
Site Recovery Planned Failover
#>
function Test-PlannedFailover
{
    param([string] $vaultSettingsFilePath)

    # Import Azure RecoveryServices Vault Settings File
    Import-AzRecoveryServicesAsrVaultSettingsFile -Path $vaultSettingsFilePath

    # Get the primary container
    $PrimaryProtectionContainer = Get-AzRecoveryServicesAsrFabric -FriendlyName $PrimaryFabricName | Get-AzRecoveryServicesAsrProtectionContainer | where { $_.FriendlyName -eq $PrimaryProtectionContainerName }

    $rpi = Get-AzRecoveryServicesAsrReplicationProtectedItem -FriendlyName $VMName -ProtectionContainer $PrimaryProtectionContainer 
 
    $job = Start-AzRecoveryServicesAsrPlannedFailoverJob -ReplicationProtectedItem $rpi -Direction PrimaryToRecovery

    WaitForJobCompletion -JobId $Job.Name
}

<#
.SYNOPSIS
Site Recovery Commit and Reprotect
#>
function Test-Reprotect
{
    param([string] $vaultSettingsFilePath)

    # Import Azure RecoveryServices Vault Settings File
    Import-AzRecoveryServicesAsrVaultSettingsFile -Path $vaultSettingsFilePath

    # Get the primary container
    $PrimaryProtectionContainer = Get-AzRecoveryServicesAsrFabric -FriendlyName $PrimaryFabricName | Get-AzRecoveryServicesAsrProtectionContainer | where { $_.FriendlyName -eq $PrimaryProtectionContainerName }

    $rpi = Get-AzRecoveryServicesAsrReplicationProtectedItem -FriendlyName $VMName -ProtectionContainer $PrimaryProtectionContainer 
    $currentJob = Update-ASRProtectionDirection -ReplicationProtectedItem $rpi -Direction RecoveryToPrimary
    WaitForJobCompletion -JobId $currentJob.Name 
}

<#
.SYNOPSIS
Site Recovery Commit and Reprotect
#>
function Test-FailbackReprotect
{
    param([string] $vaultSettingsFilePath)

    # Import Azure RecoveryServices Vault Settings File
    Import-AzRecoveryServicesAsrVaultSettingsFile -Path $vaultSettingsFilePath

    # Get the primary container
    $PrimaryProtectionContainer = Get-AzRecoveryServicesAsrFabric -FriendlyName $PrimaryFabricName | Get-AzRecoveryServicesAsrProtectionContainer | where { $_.FriendlyName -eq $PrimaryProtectionContainerName }

    $rpi = Get-AzRecoveryServicesAsrReplicationProtectedItem -FriendlyName $VMName -ProtectionContainer $PrimaryProtectionContainer 

    $job =  Start-AzRecoveryServicesAsrPlannedFailoverJob -ReplicationProtectedItem $rpi -Direction RecoveryToPrimary

    WaitForJobCompletion -JobId $Job.Name

    $rpi = Get-AzRecoveryServicesAsrReplicationProtectedItem -FriendlyName $VMName -ProtectionContainer $PrimaryProtectionContainer 

    $job = Start-ASRCommitFailoverJob -ReplicationProtectedItem $rpi 
    WaitForJobCompletion -JobId $Job.Name

    $rpi = Get-AzRecoveryServicesAsrReplicationProtectedItem -FriendlyName $VMName -ProtectionContainer $PrimaryProtectionContainer 
    $currentJob = Update-ASRProtectionDirection -ReplicationProtectedItem $rpi -Direction PrimaryToRecovery

    WaitForJobCompletion -JobId $currentJob.Name 
}

<#
.SYNOPSIS
Site Recovery Commit and Reprotect
#>
function Test-UFOandFailback
{
    param([string] $vaultSettingsFilePath)

    # Import Azure RecoveryServices Vault Settings File
    Import-AzRecoveryServicesAsrVaultSettingsFile -Path $vaultSettingsFilePath

    # Get the primary container
    $PrimaryProtectionContainer = Get-AzRecoveryServicesAsrFabric -FriendlyName $PrimaryFabricName | Get-AzRecoveryServicesAsrProtectionContainer | where { $_.FriendlyName -eq $PrimaryProtectionContainerName }

    $rpi = Get-ASRReplicationProtectedItem -FriendlyName $VMName -ProtectionContainer $PrimaryProtectionContainer 

    $job =  Start-AsrUnPlannedFailoverJob -ReplicationProtectedItem $rpi -Direction PrimaryToRecovery
    WaitForJobCompletion -JobId $Job.Name

    $rpi = Get-AsrReplicationProtectedItem -FriendlyName $VMName -ProtectionContainer $PrimaryProtectionContainer 
    $currentJob = Update-ASRProtectionDirection -ReplicationProtectedItem $rpi -Direction RecoveryToPrimary
    WaitForJobCompletion -JobId $currentJob.Name 
    WaitForIRCompletion -VM $rpi 
    #timeout 120

    $rpi = Get-AzRecoveryServicesAsrReplicationProtectedItem -FriendlyName $VMName -ProtectionContainer $PrimaryProtectionContainer 
    $job =  Start-AzRecoveryServicesAsrUnPlannedFailoverJob -ReplicationProtectedItem $rpi -Direction RecoveryToPrimary
    WaitForJobCompletion -JobId $Job.Name
    $rpi = Get-AzRecoveryServicesAsrReplicationProtectedItem -FriendlyName $VMName -ProtectionContainer $PrimaryProtectionContainer 
    $currentJob = Update-ASRProtectionDirection -ReplicationProtectedItem $rpi -Direction PrimaryToRecovery
    WaitForJobCompletion -JobId $currentJob.Name  
}

<#
.SYNOPSIS
Site Recovery remove protection container mapping test
#>
function Test-RemovePCMap
{
    param([string] $vaultSettingsFilePath)

    # Import Azure RecoveryServices Vault Settings File
    Import-AzRecoveryServicesAsrVaultSettingsFile -Path $vaultSettingsFilePath

    # Get the primary container
    $PrimaryProtectionContainer = Get-AzRecoveryServicesAsrFabric -FriendlyName $PrimaryFabricName| Get-AzRecoveryServicesAsrProtectionContainer | where { $_.FriendlyName -eq $PrimaryProtectionContainerName }

    # Get protection conatiner mapping
    $ProtectionContainerMapping = Get-AzRecoveryServicesAsrProtectionContainerMapping -Name $ProtectionContainerMappingName -ProtectionContainer $PrimaryProtectionContainer

    # Remove protection conatiner mapping
    $Job = Remove-AzRecoveryServicesAsrProtectionContainerMapping -ProtectionContainerMapping $ProtectionContainerMapping
    #WaitForJobCompletion -JobId $Job.Name
}




<#
.SYNOPSIS
Site Recovery Disable protection Test
#>
function Test-SiteRecoveryDisableDR
{
    param([string] $vaultSettingsFilePath)

    # Import Azure RecoveryServices Vault Settings File
    Import-AzRecoveryServicesAsrVaultSettingsFile -Path $vaultSettingsFilePath

    # Get the primary container
    $PrimaryProtectionContainer = Get-AzRecoveryServicesAsrFabric -FriendlyName $PrimaryFabricName | Get-AzRecoveryServicesAsrProtectionContainer | where { $_.FriendlyName -eq $PrimaryProtectionContainerName }

    # Get protected item
    $VM = Get-AzRecoveryServicesAsrReplicationProtectedItem -FriendlyName $VMName -ProtectionContainer $PrimaryProtectionContainer  

    # DisableDR
    $Job = Remove-AzRecoveryServicesAsrReplicationProtectedItem -ReplicationProtectedItem $VM

    WaitForJobCompletion -JobId $Job.Name

    Get-ASRReplicationProtectedItem -ProtectionContainer $PrimaryProtectionContainer  | Remove-AzRecoveryServicesAsrReplicationProtectedItem
    #WaitForJobCompletion -JobId $Job.Name
}

<#
.SYNOPSIS
Site Recovery Create Recovery Plan Test
#>
function Test-SiteRecoveryCreateRecoveryPlan
{
    param([string] $vaultSettingsFilePath)

    # Import Azure RecoveryServices Vault Settings File
    Import-AzRecoveryServicesAsrVaultSettingsFile -Path $vaultSettingsFilePath

    # Get the fabric and container
    $PrimaryFabric = Get-AzRecoveryServicesAsrFabric -FriendlyName $PrimaryFabricName
    $RecoveryFabric = Get-AzRecoveryServicesAsrFabric -FriendlyName $RecoveryFabricName
    $PrimaryProtectionContainer = Get-AzRecoveryServicesAsrProtectionContainer -FriendlyName $PrimaryProtectionContainerName -Fabric $PrimaryFabric
    $VM = Get-AzRecoveryServicesAsrReplicationProtectedItem -FriendlyName $VMName -ProtectionContainer $PrimaryProtectionContainer

    $Job = New-AzRecoveryServicesAsrRecoveryPlan -Name $RecoveryPlanName -PrimaryFabric $PrimaryFabric -RecoveryFabric $RecoveryFabric -ReplicationProtectedItem $VM
    #WaitForJobCompletion -JobId $Job.Name
}

<#
.SYNOPSIS
Site Recovery Enumerate Recovery Plan Test
#>
function Test-SiteRecoveryEnumerateRecoveryPlan
{
    param([string] $vaultSettingsFilePath)

    # Import Azure RecoveryServices Vault Settings File
    Import-AzRecoveryServicesAsrVaultSettingsFile -Path $vaultSettingsFilePath

    $RP = Get-AzRecoveryServicesAsrRecoveryPlan -Name $RecoveryPlanName
    Assert-NotNull($RP)
    Assert-True { $RP.Count -gt 0 }
}

<#
.SYNOPSIS
Site Recovery Remove Recovery Plan Test
#>
function Test-EditRecoveryPlan
{
    param([string] $vaultSettingsFilePath)

    # Import Azure RecoveryServices Vault Settings File
    Import-AzRecoveryServicesAsrVaultSettingsFile -Path $vaultSettingsFilePath

    $RP = Get-AsrRecoveryPlan -Name $RecoveryPlanName
    $RP = Edit-ASRRecoveryPlan -RecoveryPlan $RP -AppendGroup

    $VMNameList = $VMList.split(',')
    $PrimaryFabric = Get-AzRecoveryServicesAsrFabric -FriendlyName $PrimaryFabricName
    $PrimaryProtectionContainer = Get-AzRecoveryServicesAsrProtectionContainer -FriendlyName $PrimaryProtectionContainerName -Fabric $PrimaryFabric
    
    $VMList = Get-ASRReplicationProtectedItem -ProtectionContainer $PrimaryProtectionContainer
    $VM = $VMList | where { $_.FriendlyName -eq $VMNameList[1] }
    #-or  $_.FriendlyName -eq $VMNameList[2]}

    $RP = Edit-ASRRecoveryPlan -RecoveryPlan $RP -Group $RP.Groups[3] -AddProtectedItems $VM
    $RP.Groups

    Write-Host $("Triggered Update RP") -ForegroundColor Green
    $currentJob = Update-ASRRecoveryPlan -RecoveryPlan $RP
    WaitForJobCompletion -JobId $currentJob.Name
    #WaitForJobCompletion -JobId $Job.Name
}

<#
.SYNOPSIS
Site Recovery Remove Recovery Plan Test
#>
function Test-RecoveryPlanJob
{
    param([string] $vaultSettingsFilePath)

    # Import Azure RecoveryServices Vault Settings File
    Import-AzRecoveryServicesAsrVaultSettingsFile -Path $vaultSettingsFilePath

    $RP = Get-AsrRecoveryPlan -Name $RecoveryPlanName
    $RecoveryFabric = Get-AzRecoveryServicesAsrFabric -FriendlyName $RecoveryFabricName

    $RecoveryNetwork = Get-AzRecoveryServicesAsrNetwork -Fabric $RecoveryFabric | where { $_.FriendlyName -eq $RecoveryNetworkFriendlyName}

    $currentJob = Start-ASRTestFailoverJob -RecoveryPlan $RP -Direction PrimaryToRecovery -VMNetwork $RecoveryNetwork
    WaitForJobCompletion -JobId $currentJob.Name
    $currentJob = Start-ASRTestFailoverCleanupJob -RecoveryPlan $RP
    WaitForJobCompletion -JobId $currentJob.Name

    $currentJob = Start-ASRTestFailoverJob -RecoveryPlan $RP -Direction PrimaryToRecovery
    WaitForJobCompletion -JobId $currentJob.Name
    $currentJob = Start-ASRTestFailoverCleanupJob -RecoveryPlan $RP
    WaitForJobCompletion -JobId $currentJob.Name

    $currentJob = Start-ASRPlannedFailoverJob -RecoveryPlan $RP -Direction PrimaryToRecovery
    WaitForJobCompletion -JobId $currentJob.Name 

    $currentJob = Start-AsrCommitFailoverJob -RecoveryPlan $RP
    $currentJob
    WaitForJobCompletion -JobId $currentJob.Name

    $currentJob = Update-AsrProtectionDirection -RecoveryPlan $RP -Direction RecoveryToPrimary 
    $currentJob
    WaitForJobCompletion -JobId $currentJob.Name
    
    #timeout 1200

    $currentJob = Start-AsrUnPlannedFailoverJob -RecoveryPlan $RP -Direction RecoveryToPrimary
    $currentJob
    WaitForJobCompletion -JobId $currentJob.Name

    $currentJob = Start-AsrCommitFailoverJob -RecoveryPlan $RP
    $currentJob
    WaitForJobCompletion -JobId $currentJob.Name 
    #WaitForJobCompletion -JobId $Job.Name
}
<#
.SYNOPSIS
Site Recovery Remove Recovery Plan Test
#>
function Test-SiteRecoveryRemoveRecoveryPlan
{
    param([string] $vaultSettingsFilePath)

    # Import Azure RecoveryServices Vault Settings File
    Import-AzRecoveryServicesAsrVaultSettingsFile -Path $vaultSettingsFilePath

    $RP = Get-AzRecoveryServicesAsrRecoveryPlan -Name $RecoveryPlanName
    $Job = Remove-AzRecoveryServicesAsrRecoveryPlan -RecoveryPlan $RP
    #WaitForJobCompletion -JobId $Job.Name
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

    # Create Fabric
    $Job = New-AzRecoveryServicesAsrFabric -Name $FabricNameToBeCreated -Type HyperVSite
    #WaitForJobCompletion -JobId $Job.Name -JobQueryWaitTimeInSeconds $JobQueryWaitTimeInSeconds
    Assert-NotNull($Job)
    WaitForJobCompletion -JobId $job.name

    # Enumerate Fabrics
    $fabrics =  Get-AzRecoveryServicesAsrFabric 
    Assert-True { $fabrics.Count -gt 0 }
    Assert-NotNull($fabrics)
    foreach($fabric in $fabrics)
    {
        Assert-NotNull($fabrics.Name)
        Assert-NotNull($fabrics.ID)
    }

    # Enumerate specific Fabric
    $fabric =  Get-AzRecoveryServicesAsrFabric -Name $FabricNameToBeCreated
    Assert-NotNull($fabric)
    Assert-NotNull($fabrics.Name)
    Assert-NotNull($fabrics.ID)

    # Remove specific fabric
    $Job = Remove-AzRecoveryServicesAsrFabric -Fabric $fabric
    Assert-NotNull($Job)
    #WaitForJobCompletion -JobId $Job.Name -JobQueryWaitTimeInSeconds $JobQueryWaitTimeInSeconds
    $fabric =  Get-AzRecoveryServicesAsrFabric | Where-Object {$_.Name -eq $FabricNameToBeCreated }
    Assert-Null($fabric)
}


<#
.SYNOPSIS
Site Recovery New model End to End
#>
function Test-SiteRecoveryNewModelE2ETest
{
    param([string] $vaultSettingsFilePath)

    # Import Azure RecoveryServices Vault Settings File
    Import-AzRecoveryServicesAsrVaultSettingsFile -Path $vaultSettingsFilePath

    # Enumerate Fabrics
    $Fabrics =  Get-AzRecoveryServicesAsrFabric 
    Assert-True { $fabrics.Count -gt 0 }
    Assert-NotNull($fabrics)
    foreach($fabric in $fabrics)
    {
        Assert-NotNull($fabrics.Name)
        Assert-NotNull($fabrics.ID)
    }
    $PrimaryFabric = $Fabrics | Where-Object { $_.FriendlyName -eq $PrimaryFabricName}
    $RecoveryFabric = $Fabrics | Where-Object { $_.FriendlyName -eq $RecoveryFabricName}

    # Enumerate RSPs
    $rsps = Get-AzRecoveryServicesAsrFabric | Get-AzRecoveryServicesAsrServicesProvider
    Assert-True { $rsps.Count -gt 0 }
    Assert-NotNull($rsps)
    foreach($rsp in $rsps)
    {
        Assert-NotNull($rsp.Name)
    }

    # Create Policy
    $Job = New-AzRecoveryServicesAsrPolicy -Name $PolicyName -ReplicationProvider HyperVReplica2012R2 -ReplicationMethod Online -ReplicationFrequencyInSeconds 30 -RecoveryPoints 1 -ApplicationConsistentSnapshotFrequencyInHours 0 -ReplicationPort 8083 -Authentication Kerberos -ReplicaDeletion Required
    #WaitForJobCompletion -JobId $Job.Name

    $Policy = Get-AzRecoveryServicesAsrPolicy -Name $PolicyName
    Assert-NotNull($Policy)
    Assert-NotNull($Policy.Name)

    # Get conatiners
    $PrimaryProtectionContainer = Get-AzRecoveryServicesAsrFabric | Get-AzRecoveryServicesAsrProtectionContainer | where { $_.FriendlyName -eq $PrimaryProtectionContainerName }
    Assert-NotNull($PrimaryProtectionContainer)
    Assert-NotNull($PrimaryProtectionContainer.Name)
    $RecoveryProtectionContainer = Get-AzRecoveryServicesAsrFabric | Get-AzRecoveryServicesAsrProtectionContainer | where { $_.FriendlyName -eq $RecoveryProtectionContainerName }
    Assert-NotNull($RecoveryProtectionContainer)
    Assert-NotNull($RecoveryProtectionContainer.Name)

    # Create new Conatiner mapping 
    $Job = New-AzRecoveryServicesAsrProtectionContainerMapping -Name $ProtectionContainerMappingName -Policy $Policy -PrimaryProtectionContainer $PrimaryProtectionContainer -RecoveryProtectionContainer $RecoveryProtectionContainer
    #WaitForJobCompletion -JobId $Job.Name

    # Get container mapping
    $ProtectionContainerMapping = Get-AzRecoveryServicesAsrProtectionContainerMapping -Name $ProtectionContainerMappingName -ProtectionContainer $PrimaryProtectionContainer
    Assert-NotNull($ProtectionContainerMapping)
    Assert-NotNull($ProtectionContainerMapping.Name)

    # Get primary network
    $PrimaryNetwork = Get-AzRecoveryServicesAsrNetwork -Fabric $PrimaryFabric | where { $_.FriendlyName -eq $PrimaryNetworkFriendlyName}
    $RecoveryNetwork = Get-AzRecoveryServicesAsrNetwork -Fabric $RecoveryFabric | where { $_.FriendlyName -eq $RecoveryNetworkFriendlyName}

    # Create network mapping
    $Job = New-AzRecoveryServicesAsrNetworkMapping -Name $NetworkMappingName -PrimaryNetwork $PrimaryNetwork -RecoveryNetwork $RecoveryNetwork
    #WaitForJobCompletion -JobId $Job.Name

    # Get network mapping
    $NetworkMapping = Get-AzRecoveryServicesAsrNetworkMapping -Name $NetworkMappingName -Network $PrimaryNetwork

    # Get protectable item
    $protectable = Get-AzRecoveryServicesAsrProtectableItem -ProtectionContainer $PrimaryProtectionContainer -FriendlyName $VMName
    Assert-NotNull($protectable)
    Assert-NotNull($protectable.Name)

    # New replication protected item
    $Job = New-AzRecoveryServicesAsrReplicationProtectedItem -ProtectableItem $protectable -Name $protectable.Name -ProtectionContainerMapping $ProtectionContainerMapping
    #WaitForJobCompletion -JobId $Job.Name
    #WaitForIRCompletion -VM $protectable 
    Assert-NotNull($Job)

    # Get replication protected item
    $protected = Get-AzRecoveryServicesAsrReplicationProtectedItem -ProtectionContainer $PrimaryProtectionContainer -Name $protectable.Name
    Assert-NotNull($protected)
    Assert-NotNull($protected.Name)

    # Remove protected item
    $Job = Remove-AzRecoveryServicesAsrReplicationProtectedItem -ReplicationProtectedItem $protected
    #WaitForJobCompletion -JobId $Job.Name
    $protected = Get-AzRecoveryServicesAsrReplicationProtectedItem -ProtectionContainer $PrimaryProtectionContainer | Where-Object {$_.Name -eq $protectable.Name} 
    Assert-Null($protected)

    # Remove network mapping
    $Job = Remove-AzRecoveryServicesAsrNetworkMapping -NetworkMapping $NetworkMapping
    #WaitForJobCompletion -JobId $Job.Name

    # Remove conatiner mapping
    $Job = Remove-AzRecoveryServicesAsrProtectionContainerMapping -ProtectionContainerMapping $ProtectionContainerMapping
    #WaitForJobCompletion -JobId $Job.Name
    $ProtectionContainerMapping = Get-AzRecoveryServicesAsrProtectionContainerMapping -ProtectionContainer $PrimaryProtectionContainer | Where-Object {$_.Name -eq $ProtectionContainerMappingName}
    Assert-Null($ProtectionContainerMapping)

    # Remove Policy
    $Job = Remove-AzRecoveryServicesAsrPolicy -Policy $Policy
    #WaitForJobCompletion -JobId $Job.Name
    $Policy = Get-AzRecoveryServicesAsrPolicy | Where-Object {$_.Name -eq $PolicyName}
    Assert-Null($Policy)
}

<#
.SYNOPSIS
Site Recovery Update RPI with DiskIdToDiskEncryptionSetMap
#>
function Test-UpdateRPIWithDiskEncryptionSetMap
{
    param([string] $vaultSettingsFilePath)

    # Import Azure RecoveryServices Vault Settings File
    Import-AzRecoveryServicesAsrVaultSettingsFile -Path $vaultSettingsFilePath
    $PrimaryFabricName = "HyperVSite"    
    $fabric =  Get-AsrFabric -FriendlyName $PrimaryFabricName
    $pc =  Get-ASRProtectionContainer -Fabric $fabric
    $policyName ="b2apolicy"
    $policy = Get-AzRecoveryServicesAsrPolicy -Name $policyName
    $VMFriendlyName ="b2a-vm1"
    $rpi = Get-AsrReplicationProtectedItem -ProtectionContainer $pc -FriendlyName $VMFriendlyName
    $diskId="/subscriptions/7c943c1b-5122-4097-90c8-861411bdd574/resourceGroups/cmkrgccy/providers/Microsoft.Compute/diskEncryptionSets/cmkdesccy"
    $diskEncryptionSetMap = New-Object "System.Collections.Generic.Dictionary``2[System.String,System.String]"
    $diskEncryptionSetMap.Add($rpi.ProviderSpecificDetails.AzureVMDiskDetails[0].DiskId, $diskId)
    Set-AsrReplicationProtectedItem -InputObject $rpi -DiskIdToDiskEncryptionSetMap $diskEncryptionSetMap
    $rpi = Get-AsrReplicationProtectedItem -ProtectionContainer $pc -FriendlyName $VMFriendlyName
    Assert-NotNull($rpi.ProviderSpecificDetails.AzureVMDiskDetails[0].DiskEncryptionSetId)
}

<#
.SYNOPSIS
Site Recovery Create RPI with ProximityPlacementGroup
#>
function Test-CreateRPIWithProximityPlacementGroup
{
    param([string] $vaultSettingsFilePath)

    # Import Azure RecoveryServices Vault Settings File
    Import-AzRecoveryServicesAsrVaultSettingsFile -Path $vaultSettingsFilePath
    $PrimaryFabricName = "H2ASite"
    $fabric =  Get-AsrFabric -FriendlyName $PrimaryFabricName
    $pc =  Get-ASRProtectionContainer -Fabric $fabric
    $pcm = Get-ASRProtectionContainerMapping -ProtectionContainer $pc
    $policyName ="b2apolicy"
    $policy = Get-AzRecoveryServicesAsrPolicy -Name $policyName
    $VMFriendlyName ="A020-VJ-Dum1"
    $VM= Get-AsrProtectableItem -ProtectionContainer $pc -FriendlyName $VMFriendlyName
    $ResourceGroupId ="/subscriptions/b364ed8d-4279-4bf8-8fd1-56f8fa0ae05c/resourceGroups/h2arg"
    $LogStorageAccountId = "/subscriptions/b364ed8d-4279-4bf8-8fd1-56f8fa0ae05c/resourceGroups/h2arg/providers/Microsoft.Storage/storageAccounts/hrasa"
    $ppg = "/subscriptions/b364ed8d-4279-4bf8-8fd1-56f8fa0ae05c/resourceGroups/h2arg/providers/Microsoft.Compute/proximityPlacementGroups/ppgh2a"
    $EnableDRjob = New-AsrReplicationProtectedItem -ProtectableItem $VM -Name $VM.Name -ProtectionContainerMapping $pcm -RecoveryAzureStorageAccountId $LogStorageAccountId -OSDiskName $($VMFriendlyName+"disk") -OS Windows -RecoveryResourceGroupId $ResourceGroupId -RecoveryProximityPlacementGroupId $ppg
}

<#
.SYNOPSIS
Site Recovery Update RPI with ProximityPlacementGroup
#>
function Test-UpdateRPIWithProximityPlacementGroup
{
    param([string] $vaultSettingsFilePath)

    # Import Azure RecoveryServices Vault Settings File
    Import-AzRecoveryServicesAsrVaultSettingsFile -Path $vaultSettingsFilePath
    $PrimaryFabricName = "H2ASite"
    $fabric =  Get-AsrFabric -FriendlyName $PrimaryFabricName
    $pc =  Get-ASRProtectionContainer -Fabric $fabric
    $policyName ="b2apolicy"
    $policy = Get-AzRecoveryServicesAsrPolicy -Name $policyName
    $VMFriendlyName ="A020-VJ-Dum1"
    $rpi = Get-AsrReplicationProtectedItem -ProtectionContainer $pc -FriendlyName $VMFriendlyName
    $ppgSet="/subscriptions/b364ed8d-4279-4bf8-8fd1-56f8fa0ae05c/resourceGroups/h2arg/providers/Microsoft.Compute/proximityPlacementGroups/ppgh2aset"
    Set-AsrReplicationProtectedItem -InputObject $rpi -RecoveryProximityPlacementGroupId $ppgSet
    $rpi = Get-AsrReplicationProtectedItem -ProtectionContainer $pc -FriendlyName $VMFriendlyName
    Assert-NotNull($rpi.ProviderSpecificDetails.RecoveryProximityPlacementGroupId)
}

<#
.SYNOPSIS
Site Recovery Create RPI with AvailabilityZone
#>
function Test-CreateRPIWithAvailabilityZone
{
    param([string] $vaultSettingsFilePath)

    Import-AzRecoveryServicesAsrVaultSettingsFile -Path $vaultSettingsFilePath
    $PrimaryFabricName = "H2ASite"
    $fabric =  Get-AsrFabric -FriendlyName $PrimaryFabricName
    $pc =  Get-ASRProtectionContainer -Fabric $fabric
    $pcm = Get-ASRProtectionContainerMapping -ProtectionContainer $pc
    $policyName ="b2apolicy"
    $policy = Get-AzRecoveryServicesAsrPolicy -Name $policyName
    $VMFriendlyName ="A020-VJ-Dum2"
    $VM= Get-AsrProtectableItem -ProtectionContainer $pc -FriendlyName $VMFriendlyName
    $ResourceGroupId ="/subscriptions/b364ed8d-4279-4bf8-8fd1-56f8fa0ae05c/resourceGroups/h2arg"
    $LogStorageAccountId = "/subscriptions/b364ed8d-4279-4bf8-8fd1-56f8fa0ae05c/resourceGroups/h2arg/providers/Microsoft.Storage/storageAccounts/hrasa"
    $avZone = "1"
    $EnableDRjob = New-AsrReplicationProtectedItem -ProtectableItem $VM -Name $VM.Name -ProtectionContainerMapping $pcm -RecoveryAzureStorageAccountId $LogStorageAccountId -OSDiskName $($VMFriendlyName+"disk") -OS Windows -RecoveryResourceGroupId $ResourceGroupId -RecoveryAvailabilityZone $avZone
}

<#
.SYNOPSIS
Site Recovery Update RPI with AvailabilityZone
#>
function Test-UpdateRPIWithAvailabilityZone
{
    param([string] $vaultSettingsFilePath)

    # Import Azure RecoveryServices Vault Settings File
    Import-AzRecoveryServicesAsrVaultSettingsFile -Path $vaultSettingsFilePath
    $PrimaryFabricName = "H2ASite"
    $fabric =  Get-AsrFabric -FriendlyName $PrimaryFabricName
    $pc =  Get-ASRProtectionContainer -Fabric $fabric
    $policyName ="b2apolicy"
    $policy = Get-AzRecoveryServicesAsrPolicy -Name $policyName
    $VMFriendlyName ="A020-VJ-Dum2"
    $rpi = Get-AsrReplicationProtectedItem -ProtectionContainer $pc -FriendlyName $VMFriendlyName
    $avZoneSet="2"
    Set-AsrReplicationProtectedItem -InputObject $rpi -RecoveryAvailabilityZone $avZoneSet
    $rpi = Get-AsrReplicationProtectedItem -ProtectionContainer $pc -FriendlyName $VMFriendlyName
    Assert-NotNull($rpi.ProviderSpecificDetails.RecoveryAvailabilityZone)
}

function Test-CreateRPIWithManagedDisk
{
    param([string] $vaultSettingsFilePath)

    # Import Azure RecoveryServices Vault Settings File
    Import-AzRecoveryServicesAsrVaultSettingsFile -Path $vaultSettingsFilePath
    $PrimaryFabricName = "H2ASite"
    $fabric =  Get-AsrFabric -FriendlyName $PrimaryFabricName
    $pc =  Get-ASRProtectionContainer -Fabric $fabric
    $pcm = Get-ASRProtectionContainerMapping -ProtectionContainer $pc
    $policyName ="b2apolicy"
    $policy = Get-AzRecoveryServicesAsrPolicy -Name $policyName
    $VMFriendlyName ="NestedDum1"
    $VM= Get-AsrProtectableItem -ProtectionContainer $pc -FriendlyName $VMFriendlyName
    $ResourceGroupId ="/subscriptions/b364ed8d-4279-4bf8-8fd1-56f8fa0ae05c/resourceGroups/h2arg"
    $LogStorageAccountId = "/subscriptions/b364ed8d-4279-4bf8-8fd1-56f8fa0ae05c/resourceGroups/h2arg/providers/Microsoft.Storage/storageAccounts/hrasa"
    $ppg = "/subscriptions/b364ed8d-4279-4bf8-8fd1-56f8fa0ae05c/resourceGroups/h2arg/providers/Microsoft.Compute/proximityPlacementGroups/ppgh2a"
    $EnableDRjob = New-AsrReplicationProtectedItem -ProtectableItem $VM -Name $VM.Name -ProtectionContainerMapping $pcm -RecoveryAzureStorageAccountId $LogStorageAccountId -OSDiskName $($VMFriendlyName+"disk") -OS Windows -RecoveryResourceGroupId $ResourceGroupId -RecoveryProximityPlacementGroupId $ppg -UseManagedDisk true
}