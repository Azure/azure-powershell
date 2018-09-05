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
$FabricNameToBeCreated = "ReleaseFabric"
$PrimaryFabricName = "IDCLAB-A137.ntdev.corp.microsoft.com"
$RecoveryFabricName = "IDCLAB-A147.ntdev.corp.microsoft.com"
$PolicyName = "E2APolicy1"
$PrimaryProtectionContainerName = "primary"
$RecoveryProtectionContainerName = "recovery"
$ProtectionContainerMappingName = "E2AClP26mapping"
$PrimaryNetworkFriendlyName = "corp"
$RecoveryNetworkFriendlyName = "corp"
$NetworkMappingName = "corp96map"
$VMName = "Vm1"
$RecoveryPlanName = "RPSwag96"
$VmList = "Vm1,Vm3"

$RecoveryAzureStorageAccountId = "/subscriptions/7c943c1b-5122-4097-90c8-861411bdd574/resourceGroups/canaryexproute/providers/Microsoft.Storage/storageAccounts/ev2teststorage" 
$RecoveryResourceGroupId  = "/subscriptions/7c943c1b-5122-4097-90c8-861411bdd574/resourceGroups/canaryexproute" 
$AzureVmNetworkId = "/subscriptions/7c943c1b-5122-4097-90c8-861411bdd574/resourceGroups/canaryexproute/providers/Microsoft.Network/virtualNetworks/e2anetworksea"

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
        [int] $JobQueryWaitTimeInSeconds = $JobQueryWaitTimeInSeconds
        )
        $isJobLeftForProcessing = $true;
        do
        {
            $Job = Get-AzureRmRecoveryServicesAsrJob -Name $JobId
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
		        [Microsoft.Azure.Test.TestUtilities]::Wait($JobQueryWaitTimeInSeconds * 1000)
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
            $IRjobs = Get-AzureRmRecoveryServicesAsrJob -TargetObjectId $VM.Name | Sort-Object StartTime -Descending | select -First 5 | Where-Object{$_.JobType -eq "IrCompletion"}
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
		        [Microsoft.Azure.Test.TestUtilities]::Wait($JobQueryWaitTimeInSeconds * 1000)
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
function Test-SiteRecoveryEnumerationTests
{
	param([string] $vaultSettingsFilePath)

	# Import Azure RecoveryServices Vault Settings File
	Import-AzureRmRecoveryServicesAsrVaultSettingsFile -Path $vaultSettingsFilePath

	# Enumerate Vaults
	$vaults = Get-AzureRmRecoveryServicesVault
	Assert-True { $vaults.Count -gt 0 }
	Assert-NotNull($vaults)
	foreach($vault in $vaults)
	{
		Assert-NotNull($vault.Name)
		Assert-NotNull($vault.ID)
	}

	# Enumerate Recovery Services Providers
	$rsps = Get-AzureRmRecoveryServicesAsrFabric | Get-AzureRmRecoveryServicesAsrServicesProvider
	Assert-True { $rsps.Count -gt 0 }
	Assert-NotNull($rsps)
	foreach($rsp in $rsps)
	{
		Assert-NotNull($rsp.Name)
		Assert-NotNull($rsp.ID)
	}

	# Enumerate Protection Containers
	$protectionContainers = Get-AzureRmRecoveryServicesAsrFabric | Get-AzureRmRecoveryServicesAsrProtectionContainer
	Assert-True { $protectionContainers.Count -gt 0 }
	Assert-NotNull($protectionContainers)
	foreach($protectionContainer in $protectionContainers)
	{
		Assert-NotNull($protectionContainer.Name)
		Assert-NotNull($protectionContainer.ID)
	}
}

<#
.SYNOPSIS
Site Recovery Create Policy Test
#>
function Test-SiteRecoveryCreatePolicy
{
	param([string] $vaultSettingsFilePath)

	# Import Azure RecoveryServices Vault Settings File
	Import-AzureRmRecoveryServicesAsrVaultSettingsFile -Path $vaultSettingsFilePath

	# Create profile
	$Job =  New-AzureRmRecoveryServicesAsrPolicy -Name $PolicyName -ReplicationProvider HyperVReplicaAzure -ReplicationFrequencyInSeconds 30 -RecoveryPoints 1 -ApplicationConsistentSnapshotFrequencyInHours 0 -Encryption Disable -RecoveryAzureStorageAccountId $RecoveryAzureStorageAccountId
	WaitForJobCompletion -JobId $Job.Name -JobQueryWaitTimeInSeconds $JobQueryWaitTimeInSeconds

	# Get a profile created (with name ppAzure)
	$Policy = Get-AzureRmRecoveryServicesAsrPolicy -Name $PolicyName
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
	Import-AzureRmRecoveryServicesAsrVaultSettingsFile -Path $vaultSettingsFilePath

	# Get a policy created in previous test
	$Policy = Get-AzureRmRecoveryServicesAsrPolicy -Name $PolicyName
	Assert-True { $Policy.Count -gt 0 }
	Assert-NotNull($Policy)

	# Delete the profile
	$Job = Remove-AzureRmRecoveryServicesAsrPolicy -Policy $Policy
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
	Import-AzureRmRecoveryServicesAsrVaultSettingsFile -Path $vaultSettingsFilePath

	# Get a policy created in previous test
	$fabric = Get-AzureRmRecoveryServicesAsrFabric -FriendlyName $PrimaryFabricName 
	$job = Remove-ASRFabric -InputObject $fabric
	WaitForJobCompletion -JobId $job.Name

	Get-AzureRmRecoveryServicesAsrFabric|Remove-ASRFabric
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
	Import-AzureRmRecoveryServicesAsrVaultSettingsFile -Path $vaultSettingsFilePath

	# Get the containers and policy
	$Policy = Get-AzureRmRecoveryServicesAsrPolicy -Name $PolicyName;
	$PrimaryProtectionContainer = Get-AzureRmRecoveryServicesAsrFabric -FriendlyName $PrimaryFabricName| Get-AzureRmRecoveryServicesAsrProtectionContainer | where { $_.FriendlyName -eq $PrimaryProtectionContainerName }
	# Associate the profile
	$Job = New-AzureRmRecoveryServicesAsrProtectionContainerMapping -Name $ProtectionContainerMappingName -Policy $Policy -PrimaryProtectionContainer $PrimaryProtectionContainer 
	WaitForJobCompletion -JobId $Job.Name

	# Get protection conatiner mapping
	$ProtectionContainerMapping = Get-AzureRmRecoveryServicesAsrProtectionContainerMapping -Name $ProtectionContainerMappingName -ProtectionContainer $PrimaryProtectionContainer
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
	Import-AzureRmRecoveryServicesAsrVaultSettingsFile -Path $vaultSettingsFilePath

	# Get the primary container
	$PrimaryProtectionContainer = Get-AzureRmRecoveryServicesAsrFabric -FriendlyName $PrimaryFabricName | Get-AzureRmRecoveryServicesAsrProtectionContainer | where { $_.FriendlyName -eq $PrimaryProtectionContainerName }

	# Get protection container mapping
	$ProtectionContainerMapping = Get-AzureRmRecoveryServicesAsrProtectionContainerMapping -Name $ProtectionContainerMappingName -ProtectionContainer $PrimaryProtectionContainer

	foreach($EnableVMName in $VmList.Split(','))
	{
		# Get protectable item
		$VM = Get-AzureRmRecoveryServicesAsrProtectableItem -FriendlyName $EnableVMName -ProtectionContainer $PrimaryProtectionContainer  

		# EnableDR
		$Job = New-AzureRmRecoveryServicesAsrReplicationProtectedItem -ProtectableItem $VM -Name $VM.Name -ProtectionContainerMapping $ProtectionContainerMapping -RecoveryAzureStorageAccountId $RecoveryAzureStorageAccountId -RecoveryResourceGroupId $RecoveryResourceGroupId
		WaitForJobCompletion -JobId $Job.Name
		WaitForIRCompletion -VM $VM 
	}
}

<#
.SYNOPSIS
Site Recovery Network Mapping
#>
function Test-MapNetwork
{
	param([string] $vaultSettingsFilePath)
	Import-AzureRmRecoveryServicesAsrVaultSettingsFile -Path $vaultSettingsFilePath

	# Get the primary container
	$PrimaryFabric = Get-AzureRmRecoveryServicesAsrFabric -FriendlyName $PrimaryFabricName
	
	# Get primary network
	$PrimaryNetwork = Get-AzureRmRecoveryServicesAsrNetwork -Fabric $PrimaryFabric | where { $_.FriendlyName -eq $PrimaryNetworkFriendlyName}
	
	# Create network mapping
    $Job = New-AzureRmRecoveryServicesAsrNetworkMapping -Name $NetworkMappingName -PrimaryNetwork $PrimaryNetwork -RecoveryAzureNetworkId $AzureVmNetworkId
	WaitForJobCompletion -JobId $Job.Name

	# Get network mapping
	$NetworkMapping = Get-AzureRmRecoveryServicesAsrNetworkMapping -Name $NetworkMappingName -Network $PrimaryNetwork

	}

	function Test-RemoveNetworkPairing
	{
		param([string] $vaultSettingsFilePath)
		Import-AzureRmRecoveryServicesAsrVaultSettingsFile -Path $vaultSettingsFilePath

		# Get the primary container
		$PrimaryFabric = Get-AzureRmRecoveryServicesAsrFabric -FriendlyName $PrimaryFabricName
		$RecoveryFabric = Get-AzureRmRecoveryServicesAsrFabric -FriendlyName $RecoveryFabricName

		# Get primary network
		$PrimaryNetwork = Get-AzureRmRecoveryServicesAsrNetwork -Fabric $PrimaryFabric | where { $_.FriendlyName -eq $PrimaryNetworkFriendlyName}
		$RecoveryNetwork = Get-AzureRmRecoveryServicesAsrNetwork -Fabric $RecoveryFabric | where { $_.FriendlyName -eq $RecoveryNetworkFriendlyName}

		# Get network mapping
		$job = Get-AzureRmRecoveryServicesAsrNetworkMapping -Name $NetworkMappingName -Network $PrimaryNetwork |Remove-ASRNetworkMapping
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
	Import-AzureRmRecoveryServicesAsrVaultSettingsFile -Path $vaultSettingsFilePath

	# Get the primary container
	$PrimaryProtectionContainer = Get-AzureRmRecoveryServicesAsrFabric -FriendlyName $PrimaryFabricName | Get-AzureRmRecoveryServicesAsrProtectionContainer | where { $_.FriendlyName -eq $PrimaryProtectionContainerName }

	# Get protectable item
	$VM = Get-AzureRmRecoveryServicesAsrProtectableItem -FriendlyName $VMName -ProtectionContainer $PrimaryProtectionContainer  
	# EnableDR
	$rpi = Get-AzureRmRecoveryServicesAsrReplicationProtectedItem -FriendlyName $VMName -ProtectionContainer $PrimaryProtectionContainer 
	Set-ASRReplicationProtectedItem -RecoveryNetworkId $AzureVmNetworkId -RecoveryNicSubnetName "default" -InputObject $rpi
	#$job = Start-ASRTestFailoverJob -ReplicationProtectedItem $rpi -Direction PrimaryToRecovery

	#WaitForJobCompletion -JobId $Job.Name

	#$job = Start-ASRTestFailoverCleanupJob -ReplicationProtectedItem $rpi
	#WaitForJobCompletion -JobId $Job.Name

	$job = Start-ASRTestFailoverJob -ReplicationProtectedItem $rpi -Direction PrimaryToRecovery -AzureVMNetworkId $AzureVmNetworkId

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
	Import-AzureRmRecoveryServicesAsrVaultSettingsFile -Path $vaultSettingsFilePath

	# Get the primary container
	$PrimaryProtectionContainer = Get-AzureRmRecoveryServicesAsrFabric -FriendlyName $PrimaryFabricName | Get-AzureRmRecoveryServicesAsrProtectionContainer | where { $_.FriendlyName -eq $PrimaryProtectionContainerName }

	$rpi = Get-AzureRmRecoveryServicesAsrReplicationProtectedItem -FriendlyName $VMName -ProtectionContainer $PrimaryProtectionContainer 
 
	$job =  Start-AzureRmRecoveryServicesAsrPlannedFailoverJob -ReplicationProtectedItem $rpi -Direction PrimaryToRecovery

}

<#
.SYNOPSIS
Site Recovery Commit and Reprotect
#>
function Test-Reprotect
{
	param([string] $vaultSettingsFilePath)

	# Import Azure RecoveryServices Vault Settings File
	Import-AzureRmRecoveryServicesAsrVaultSettingsFile -Path $vaultSettingsFilePath

	# Get the primary container
	$PrimaryProtectionContainer = Get-AzureRmRecoveryServicesAsrFabric -FriendlyName $PrimaryFabricName | Get-AzureRmRecoveryServicesAsrProtectionContainer | where { $_.FriendlyName -eq $PrimaryProtectionContainerName }

	$rpi = Get-AzureRmRecoveryServicesAsrReplicationProtectedItem -FriendlyName $VMName -ProtectionContainer $PrimaryProtectionContainer 
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
	Import-AzureRmRecoveryServicesAsrVaultSettingsFile -Path $vaultSettingsFilePath

	# Get the primary container
	$PrimaryProtectionContainer = Get-AzureRmRecoveryServicesAsrFabric -FriendlyName $PrimaryFabricName | Get-AzureRmRecoveryServicesAsrProtectionContainer | where { $_.FriendlyName -eq $PrimaryProtectionContainerName }

	$rpi = Get-AzureRmRecoveryServicesAsrReplicationProtectedItem -FriendlyName $VMName -ProtectionContainer $PrimaryProtectionContainer 

	$job =  Start-AzureRmRecoveryServicesAsrPlannedFailoverJob -ReplicationProtectedItem $rpi -Direction RecoveryToPrimary

	WaitForJobCompletion -JobId $Job.Name

	$rpi = Get-AzureRmRecoveryServicesAsrReplicationProtectedItem -FriendlyName $VMName -ProtectionContainer $PrimaryProtectionContainer 

	$job = Start-ASRCommitFailoverJob -ReplicationProtectedItem $rpi 
	WaitForJobCompletion -JobId $Job.Name

	$rpi = Get-AzureRmRecoveryServicesAsrReplicationProtectedItem -FriendlyName $VMName -ProtectionContainer $PrimaryProtectionContainer 
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
	Import-AzureRmRecoveryServicesAsrVaultSettingsFile -Path $vaultSettingsFilePath

	# Get the primary container
	$PrimaryProtectionContainer = Get-AzureRmRecoveryServicesAsrFabric -FriendlyName $PrimaryFabricName | Get-AzureRmRecoveryServicesAsrProtectionContainer | where { $_.FriendlyName -eq $PrimaryProtectionContainerName }

	$rpi = Get-ASRReplicationProtectedItem -FriendlyName $VMName -ProtectionContainer $PrimaryProtectionContainer 

	$job =  Start-AsrUnPlannedFailoverJob -ReplicationProtectedItem $rpi -Direction PrimaryToRecovery
	WaitForJobCompletion -JobId $Job.Name

	$rpi = Get-AsrReplicationProtectedItem -FriendlyName $VMName -ProtectionContainer $PrimaryProtectionContainer 
	$currentJob = Update-ASRProtectionDirection -ReplicationProtectedItem $rpi -Direction RecoveryToPrimary
    WaitForJobCompletion -JobId $currentJob.Name 
	WaitForIRCompletion -VM $rpi 
	#timeout 120

	$rpi = Get-AzureRmRecoveryServicesAsrReplicationProtectedItem -FriendlyName $VMName -ProtectionContainer $PrimaryProtectionContainer 
	$job =  Start-AzureRmRecoveryServicesAsrUnPlannedFailoverJob -ReplicationProtectedItem $rpi -Direction RecoveryToPrimary
	WaitForJobCompletion -JobId $Job.Name
	$rpi = Get-AzureRmRecoveryServicesAsrReplicationProtectedItem -FriendlyName $VMName -ProtectionContainer $PrimaryProtectionContainer 
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
	Import-AzureRmRecoveryServicesAsrVaultSettingsFile -Path $vaultSettingsFilePath

	# Get the primary container
	$PrimaryProtectionContainer = Get-AzureRmRecoveryServicesAsrFabric -FriendlyName $PrimaryFabricName| Get-AzureRmRecoveryServicesAsrProtectionContainer | where { $_.FriendlyName -eq $PrimaryProtectionContainerName }

	# Get protection conatiner mapping
	$ProtectionContainerMapping = Get-AzureRmRecoveryServicesAsrProtectionContainerMapping -Name $ProtectionContainerMappingName -ProtectionContainer $PrimaryProtectionContainer

	# Remove protection conatiner mapping
	$Job = Remove-AzureRmRecoveryServicesAsrProtectionContainerMapping -ProtectionContainerMapping $ProtectionContainerMapping
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
	Import-AzureRmRecoveryServicesAsrVaultSettingsFile -Path $vaultSettingsFilePath

	# Get the primary container
	$PrimaryProtectionContainer = Get-AzureRmRecoveryServicesAsrFabric -FriendlyName $PrimaryFabricName | Get-AzureRmRecoveryServicesAsrProtectionContainer | where { $_.FriendlyName -eq $PrimaryProtectionContainerName }

	# Get protected item
	$VM = Get-AzureRmRecoveryServicesAsrReplicationProtectedItem -FriendlyName $VMName -ProtectionContainer $PrimaryProtectionContainer  

	# DisableDR
	$Job = Remove-AzureRmRecoveryServicesAsrReplicationProtectedItem -ReplicationProtectedItem $VM

	WaitForJobCompletion -JobId $Job.Name

	Get-ASRReplicationProtectedItem -ProtectionContainer $PrimaryProtectionContainer  | Remove-AzureRmRecoveryServicesAsrReplicationProtectedItem
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
	Import-AzureRmRecoveryServicesAsrVaultSettingsFile -Path $vaultSettingsFilePath

	# Get the fabric and container
	$PrimaryFabric = Get-AzureRmRecoveryServicesAsrFabric -FriendlyName $PrimaryFabricName
	$RecoveryFabric = Get-AzureRmRecoveryServicesAsrFabric -FriendlyName $RecoveryFabricName
	$PrimaryProtectionContainer = Get-AzureRmRecoveryServicesAsrProtectionContainer -FriendlyName $PrimaryProtectionContainerName -Fabric $PrimaryFabric
	$VM = Get-AzureRmRecoveryServicesAsrReplicationProtectedItem -FriendlyName $VMName -ProtectionContainer $PrimaryProtectionContainer

	$Job = New-AzureRmRecoveryServicesAsrRecoveryPlan -Name $RecoveryPlanName -PrimaryFabric $PrimaryFabric -RecoveryFabric $RecoveryFabric -ReplicationProtectedItem $VM
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
	Import-AzureRmRecoveryServicesAsrVaultSettingsFile -Path $vaultSettingsFilePath

	$RP = Get-AzureRmRecoveryServicesAsrRecoveryPlan -Name $RecoveryPlanName
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
	Import-AzureRmRecoveryServicesAsrVaultSettingsFile -Path $vaultSettingsFilePath

	$RP = Get-AsrRecoveryPlan -Name $RecoveryPlanName
	$RP = Edit-ASRRecoveryPlan -RecoveryPlan $RP -AppendGroup

	$VMNameList = $VMList.split(',')
	$PrimaryFabric = Get-AzureRmRecoveryServicesAsrFabric -FriendlyName $PrimaryFabricName
	$PrimaryProtectionContainer = Get-AzureRmRecoveryServicesAsrProtectionContainer -FriendlyName $PrimaryProtectionContainerName -Fabric $PrimaryFabric
	
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
	Import-AzureRmRecoveryServicesAsrVaultSettingsFile -Path $vaultSettingsFilePath

	$RP = Get-AsrRecoveryPlan -Name $RecoveryPlanName
	$RecoveryFabric = Get-AzureRmRecoveryServicesAsrFabric -FriendlyName $RecoveryFabricName

	$RecoveryNetwork = Get-AzureRmRecoveryServicesAsrNetwork -Fabric $RecoveryFabric | where { $_.FriendlyName -eq $RecoveryNetworkFriendlyName}

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
	Import-AzureRmRecoveryServicesAsrVaultSettingsFile -Path $vaultSettingsFilePath

	$RP = Get-AzureRmRecoveryServicesAsrRecoveryPlan -Name $RecoveryPlanName
	$Job = Remove-AzureRmRecoveryServicesAsrRecoveryPlan -RecoveryPlan $RP
	#WaitForJobCompletion -JobId $Job.Name
}

<#
.SYNOPSIS
Site Recovery Fabric Tests New model
#>
function Test-FabricTest
{
	param([string] $vaultSettingsFilePath)

	# Import Azure RecoveryServices Vault Settings File
	Import-AzureRmRecoveryServicesAsrVaultSettingsFile -Path $vaultSettingsFilePath

	# Create Fabric
	$Job = New-AzureRmRecoveryServicesAsrFabric -Name $FabricNameToBeCreated -Type HyperVSite
	#WaitForJobCompletion -JobId $Job.Name -JobQueryWaitTimeInSeconds $JobQueryWaitTimeInSeconds
	Assert-NotNull($Job)
	WaitForJobCompletion -JobId $job.name

	# Enumerate Fabrics
	$fabrics =  Get-AzureRmRecoveryServicesAsrFabric 
	Assert-True { $fabrics.Count -gt 0 }
	Assert-NotNull($fabrics)
	foreach($fabric in $fabrics)
	{
		Assert-NotNull($fabrics.Name)
		Assert-NotNull($fabrics.ID)
	}

	# Enumerate specific Fabric
	$fabric =  Get-AzureRmRecoveryServicesAsrFabric -Name $FabricNameToBeCreated
	Assert-NotNull($fabric)
	Assert-NotNull($fabrics.Name)
	Assert-NotNull($fabrics.ID)

	# Remove specific fabric
	$Job = Remove-AzureRmRecoveryServicesAsrFabric -Fabric $fabric
	WaitForJobCompletion -JobId $job.Name
	Assert-NotNull($Job)
	#WaitForJobCompletion -JobId $Job.Name -JobQueryWaitTimeInSeconds $JobQueryWaitTimeInSeconds
	$fabric =  Get-AzureRmRecoveryServicesAsrFabric | Where-Object {$_.Name -eq $FabricNameToBeCreated }
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
	Import-AzureRmRecoveryServicesAsrVaultSettingsFile -Path $vaultSettingsFilePath

	# Enumerate Fabrics
	$Fabrics =  Get-AzureRmRecoveryServicesAsrFabric 
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
	$rsps = Get-AzureRmRecoveryServicesAsrFabric | Get-AzureRmRecoveryServicesAsrServicesProvider
	Assert-True { $rsps.Count -gt 0 }
	Assert-NotNull($rsps)
	foreach($rsp in $rsps)
	{
		Assert-NotNull($rsp.Name)
	}

	# Create Policy
	$Job = New-AzureRmRecoveryServicesAsrPolicy -Name $PolicyName -ReplicationProvider HyperVReplica2012R2 -ReplicationMethod Online -ReplicationFrequencyInSeconds 30 -RecoveryPoints 1 -ApplicationConsistentSnapshotFrequencyInHours 0 -ReplicationPort 8083 -Authentication Kerberos -ReplicaDeletion Required
	#WaitForJobCompletion -JobId $Job.Name

    $Policy = Get-AzureRmRecoveryServicesAsrPolicy -Name $PolicyName
	Assert-NotNull($Policy)
	Assert-NotNull($Policy.Name)

	# Get conatiners
	$PrimaryProtectionContainer = Get-AzureRmRecoveryServicesAsrFabric | Get-AzureRmRecoveryServicesAsrProtectionContainer | where { $_.FriendlyName -eq $PrimaryProtectionContainerName }
	Assert-NotNull($PrimaryProtectionContainer)
	Assert-NotNull($PrimaryProtectionContainer.Name)
	$RecoveryProtectionContainer = Get-AzureRmRecoveryServicesAsrFabric | Get-AzureRmRecoveryServicesAsrProtectionContainer | where { $_.FriendlyName -eq $RecoveryProtectionContainerName }
	Assert-NotNull($RecoveryProtectionContainer)
	Assert-NotNull($RecoveryProtectionContainer.Name)

	# Create new Conatiner mapping 
	$Job = New-AzureRmRecoveryServicesAsrProtectionContainerMapping -Name $ProtectionContainerMappingName -Policy $Policy -PrimaryProtectionContainer $PrimaryProtectionContainer -RecoveryProtectionContainer $RecoveryProtectionContainer
	#WaitForJobCompletion -JobId $Job.Name

	# Get container mapping
	$ProtectionContainerMapping = Get-AzureRmRecoveryServicesAsrProtectionContainerMapping -Name $ProtectionContainerMappingName -ProtectionContainer $PrimaryProtectionContainer
	Assert-NotNull($ProtectionContainerMapping)
	Assert-NotNull($ProtectionContainerMapping.Name)

	# Get primary network
	$PrimaryNetwork = Get-AzureRmRecoveryServicesAsrNetwork -Fabric $PrimaryFabric | where { $_.FriendlyName -eq $PrimaryNetworkFriendlyName}
	$RecoveryNetwork = Get-AzureRmRecoveryServicesAsrNetwork -Fabric $RecoveryFabric | where { $_.FriendlyName -eq $RecoveryNetworkFriendlyName}

	# Create network mapping
    $Job = New-AzureRmRecoveryServicesAsrNetworkMapping -Name $NetworkMappingName -PrimaryNetwork $PrimaryNetwork -RecoveryNetwork $RecoveryNetwork
	#WaitForJobCompletion -JobId $Job.Name

	# Get network mapping
	$NetworkMapping = Get-AzureRmRecoveryServicesAsrNetworkMapping -Name $NetworkMappingName -Network $PrimaryNetwork

	# Get protectable item
	$protectable = Get-AzureRmRecoveryServicesAsrProtectableItem -ProtectionContainer $PrimaryProtectionContainer -FriendlyName $VMName
	Assert-NotNull($protectable)
	Assert-NotNull($protectable.Name)

	# New replication protected item
	$Job = New-AzureRmRecoveryServicesAsrReplicationProtectedItem -ProtectableItem $protectable -Name $protectable.Name -ProtectionContainerMapping $ProtectionContainerMapping
	#WaitForJobCompletion -JobId $Job.Name
	#WaitForIRCompletion -VM $protectable 
	Assert-NotNull($Job)

	# Get replication protected item
	$protected = Get-AzureRmRecoveryServicesAsrReplicationProtectedItem -ProtectionContainer $PrimaryProtectionContainer -Name $protectable.Name
	Assert-NotNull($protected)
	Assert-NotNull($protected.Name)

	# Remove protected item
	$Job = Remove-AzureRmRecoveryServicesAsrReplicationProtectedItem -ReplicationProtectedItem $protected
	#WaitForJobCompletion -JobId $Job.Name
	$protected = Get-AzureRmRecoveryServicesAsrReplicationProtectedItem -ProtectionContainer $PrimaryProtectionContainer | Where-Object {$_.Name -eq $protectable.Name} 
	Assert-Null($protected)

	# Remove network mapping
	$Job = Remove-AzureRmRecoveryServicesAsrNetworkMapping -NetworkMapping $NetworkMapping
	#WaitForJobCompletion -JobId $Job.Name

	# Remove conatiner mapping
	$Job = Remove-AzureRmRecoveryServicesAsrProtectionContainerMapping -ProtectionContainerMapping $ProtectionContainerMapping
	#WaitForJobCompletion -JobId $Job.Name
	$ProtectionContainerMapping = Get-AzureRmRecoveryServicesAsrProtectionContainerMapping -ProtectionContainer $PrimaryProtectionContainer | Where-Object {$_.Name -eq $ProtectionContainerMappingName}
	Assert-Null($ProtectionContainerMapping)

	# Remove Policy
	$Job = Remove-AzureRmRecoveryServicesAsrPolicy -Policy $Policy
	#WaitForJobCompletion -JobId $Job.Name
	$Policy = Get-AzureRmRecoveryServicesAsrPolicy | Where-Object {$_.Name -eq $PolicyName}
	Assert-Null($Policy)
}
