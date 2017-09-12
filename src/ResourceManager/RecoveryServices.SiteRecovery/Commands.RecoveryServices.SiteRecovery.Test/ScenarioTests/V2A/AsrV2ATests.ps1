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

$suffix="v2avm1"
$JobQueryWaitTimeInSeconds = 0
$PrimaryFabricName = "V2A-W2K12-400"
$PrimaryNetworkFriendlyName = "corp"
$RecoveryNetworkFriendlyName = "corp"
$NetworkMappingName = "corp96map"
$RecoveryPlanName = "RPSwag96" + $suffix
$policyName1 = "V2aTest" + $suffix
$policyName2 = "V2aTest"+ $suffix+"-failback"
$PrimaryProtectionContainerMapping = "pcmmapping" + $suffix
$reverseMapping = "reverseMap" + $suffix
$pcName = "V2A-W2K12-400"

$rpiName = "V2ATest-rpi-" + $suffix
$RecoveryAzureStorageAccountId = "/subscriptions/7c943c1b-5122-4097-90c8-861411bdd574/resourceGroups/canaryexproute/providers/Microsoft.Storage/storageAccounts/ev2teststorage" 
$RecoveryResourceGroupId  = "/subscriptions/7c943c1b-5122-4097-90c8-861411bdd574/resourceGroups/canaryexproute" 
$AzureVmNetworkId = "/subscriptions/7c943c1b-5122-4097-90c8-861411bdd574/resourceGroups/ERNetwork/providers/Microsoft.Network/virtualNetworks/ASRCanaryTestSub3-CORP-SEA-VNET-1"
$rpiNameNew = "V2ATest-CentOS6U7-400-new"
$vCenterIporHostName = "10.150.209.216"
$vCenterName = "BCDR"
$Subnet = "Subnet-1"

$piName = "v2avm1"
$vmIp = "10.150.208.125"

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
		        Start-Sleep -Seconds $JobQueryWaitTimeInSeconds
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
            $IRjobs = Get-AzureRmRecoveryServicesAsrJob -TargetObjectId $TargetObjectId | Sort-Object StartTime -Descending | select -First 1 | Where-Object{$_.JobType -eq "IrCompletion"}
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
		        Start-Sleep -Seconds $JobQueryWaitTimeInSeconds
	        }
        }While($isProcessingLeft)

        $IRjobs
        WaitForJobCompletion -JobId $IRjobs[0].Name -JobQueryWaitTimeInSeconds $JobQueryWaitTimeInSeconds
}

<#
.SYNOPSIS
Site Recovery Get Events.
#>
function Test-AsrEvent
{
	param([string] $vaultSettingsFilePath)

	# Import Azure RecoveryServices Vault Settings File
	Import-AzureRmRecoveryServicesAsrVaultSettingsFile -Path $vaultSettingsFilePath

	$Events = get-asrEvent
	Assert-NotNull($Events)

	$e = Get-AzureRmRecoveryServicesAsrEvent -EventName $Events[0].Name
	Assert-NotNull($e)
	Assert-NotNull($e.Name)
	Assert-NotNull($e.Description)
	Assert-NotNull($e.FabricId)
	Assert-NotNull($e.AffectedObjectFriendlyName)

	$e = Get-AzureRmRecoveryServicesAsrEvent -Severity $Events[0].Severity
	Assert-NotNull($e)

	$fabric =  Get-AsrFabric -FriendlyName $PrimaryFabricName
	$e = Get-AzureRmRecoveryServicesAsrEvent -Fabric $fabric
	Assert-NotNull($e)
	
	$e = Get-AzureRmRecoveryServicesAsrEvent -AffectedObjectFriendlyName $Events[0].AffectedObjectFriendlyName
	Assert-NotNull($e)
	
	$e = Get-AzureRmRecoveryServicesAsrEvent -EventType VmHealth
	Assert-NotNull($e)

	$e = Get-AzureRmRecoveryServicesAsrEvent -StartTime "8/18/2017 2:05:00 AM"
	Assert-NotNull($e)

	$e = Get-AzureRmRecoveryServicesAsrEvent -EventType VmHealth -AffectedObjectFriendlyName $Events[0].AffectedObjectFriendlyName
	Assert-NotNull($e)
}

<#
.SYNOPSIS
Site Recovery vCenter - - new set get delete.
#>
function Test-vCenter 
{
	param([string] $vaultSettingsFilePath)

	Import-AzureRmRecoveryServicesAsrVaultSettingsFile -Path $vaultSettingsFilePath
	$fabric =  Get-AsrFabric -FriendlyName $PrimaryFabricName
	$job = New-ASRvCenter -Fabric $fabric -Name $vCenterName -IporHostName $vCenterIporHostName -Port 443 -Account $fabric.FabricSpecificDetails.RunAsAccounts[0]
	WaitForJobCompletion -JobId $job.name

	$fabric =  Get-AsrFabric -FriendlyName $PrimaryFabricName

	$vCenterList = Get-ASRvCenter -Fabric $fabric 
	Assert-NotNull($vCenterList[0])

	$vCenter = Get-ASRvCenter -Fabric $fabric -Name $vCenterName
	Assert-NotNull($vCenter)

	$updateJob = Update-AzureRmRecoveryServicesAsrvCenter -InputObject $vCenter -Port 444
	WaitForJobCompletion -JobId $updatejob.name

	$job = Remove-ASRvCenter -InputObject $vCenter
	WaitForJobCompletion -JobId $job.name
}

<#
.SYNOPSIS
Site Recovery Fabric Tests New model
#>
function Test-SiteRecoveryFabricTest
{
	param([string] $vaultSettingsFilePath)

	# Import Azure RecoveryServices Vault Settings File
	Import-AzureRmRecoveryServicesAsrVaultSettingsFile -Path $vaultSettingsFilePath
	# Enumerate specific Fabric
	$fabricList =  Get-AsrFabric
	Assert-NotNull($fabricList)

	$fabric =  Get-AsrFabric -FriendlyName $PrimaryFabricName
	Assert-NotNull($fabric)
	Assert-NotNull($fabric.FriendlyName)
	Assert-NotNull($fabric.name)
	Assert-NotNull($fabric.ID)
	Assert-NotNull($fabric.FabricSpecificDetails)

	$fabricDetails = $fabric.FabricSpecificDetails

	Assert-NotNull($fabricDetails.HostName)
	Assert-NotNull($fabricDetails.IpAddress)
	Assert-NotNull($fabricDetails.AgentVersion)
	Assert-NotNull($fabricDetails.ProtectedServers)
	Assert-NotNull($fabricDetails.LastHeartbeat)
	Assert-NotNull($fabricDetails.ProcessServers)
	Assert-NotNull($fabricDetails.MasterTargetServers)
	Assert-NotNull($fabricDetails.RunAsAccounts)
	Assert-NotNull($fabricDetails.IpAddress)

	$ProcessServer = $fabricDetails.ProcessServers

	Assert-NotNull($ProcessServer.FriendlyName)
	Assert-NotNull($ProcessServer.Id)
	Assert-NotNull($ProcessServer.IpAddress)

	# New-AzureRmRecoveryServicesAsrFabric Not used in V2A
	# Remove-AzureRmRecoveryServicesAsrFabric Not Used in V2A
}

<#
.SYNOPSIS
Site Recovery Fabric Tests Job
#>

function Test-Job
{
	param([string] $vaultSettingsFilePath)

	# Import Azure RecoveryServices Vault Settings File
	Import-AzureRmRecoveryServicesAsrVaultSettingsFile -Path $vaultSettingsFilePath
	# Enumerate specific Fabric
	$jobs =  Get-AzureRmRecoveryServicesAsrJob
	Assert-NotNull($jobs)
	$job = $jobs[0]
	Assert-NotNull($job.name)
	Assert-NotNull($job.id)

	$job = Get-AzureRmRecoveryServicesAsrJob -name $job.name

	Assert-NotNull($job.name)
	Assert-NotNull($job.id)

	$job = Get-AzureRmRecoveryServicesAsrJob -job $job

	Assert-NotNull($job.name)
	Assert-NotNull($job.id)

	$jobList = Get-AzureRmRecoveryServicesAsrJob -TargetObjectId $job.TargetObjectId

	Assert-NotNull($jobList)

	$jobList = Get-AzureRmRecoveryServicesAsrJob -EndTime "8/10/2017 7:50:50 PM" -StartTime "8/4/2017 2:58:52 PM"
	Assert-NotNull($jobList)

	$jobList =  Get-AzureRmRecoveryServicesAsrJob -State Succeeded
	Assert-NotNull($jobList)
}

<#
.SYNOPSIS
Site Recovery NotificationSettings testing Set and Get
#>
function Test-NotificationSettings
{
	param([string] $vaultSettingsFilePath)

	# Import Azure RecoveryServices Vault Settings File
	Import-AzureRmRecoveryServicesAsrVaultSettingsFile -Path $vaultSettingsFilePath
	# Enumerate specific Fabric
	$NotificationSettings = Set-AzureRmRecoveryServicesAsrNotificationSetting -EmailSubscriptionOwner -CustomEmailAddress "abcxxxx@microsft.com"
	Assert-NotNull($NotificationSettings)
	
	$NotificationSettings = Get-AzureRmRecoveryServicesAsrNotificationSetting
	Assert-NotNull($NotificationSettings)
	Assert-NotNull($NotificationSettings.CustomEmailAddress)
	Assert-AreEqual -expected "abcxxxx@microsft.com" -actual $NotificationSettings.CustomEmailAddress
	Assert-NotNull($NotificationSettings.EmailSubscriptionOwner)
	Assert-NotNull($NotificationSettings.Locale)

}

<#
.SYNOPSIS
Site Recovery Protection Container - get.
#>
function Test-PC
{
	param([string] $vaultSettingsFilePath)

	# Import Azure RecoveryServices Vault Settings File
	Import-AzureRmRecoveryServicesAsrVaultSettingsFile -Path $vaultSettingsFilePath
	$fabric =  Get-AsrFabric -FriendlyName $PrimaryFabricName
	# Create profile

	$ProtectionContainerList =  Get-ASRProtectionContainer -Fabric $fabric
	Assert-NotNull($ProtectionContainerList)
	$ProtectionContainer = $ProtectionContainerList[0]
	Assert-NotNull($ProtectionContainer)
	Assert-NotNull($ProtectionContainer.id)
	Assert-AreEQUAL -actual $ProtectionContainer.FabricType -expected "VMware"

	$ProtectionContainer =  Get-ASRProtectionContainer -FriendlyName $pcName -Fabric $fabric
	Assert-NotNull($ProtectionContainer)
	Assert-NotNull($ProtectionContainer.id)
	Assert-AreEQUAL -actual $ProtectionContainer.FabricType -expected "VMware"

	$ProtectionContainer =  Get-ASRProtectionContainer -Name $ProtectionContainer.Name -Fabric $fabric
		Assert-NotNull($ProtectionContainer)
	Assert-NotNull($ProtectionContainer.id)
	Assert-AreEQUAL -actual $ProtectionContainer.FabricType -expected "VMware"
}

<#
.SYNOPSIS
Site Recovery Create Policy Test -new get remove
#>
function Test-SiteRecoveryPolicy
{
	param([string] $vaultSettingsFilePath)

	# Import Azure RecoveryServices Vault Settings File
	Import-AzureRmRecoveryServicesAsrVaultSettingsFile -Path $vaultSettingsFilePath

	$Job = New-AzureRmRecoveryServicesAsrPolicy -Name $policyName1 -ReplicationProvider InMageAzureV2 -RecoveryPointRetentionInHours 40  -RPOWarningThresholdInMinutes 5 -ApplicationConsistentSnapshotFrequencyInMinutes 15
	WaitForJobCompletion -JobId $Job.Name
	# Get a profile created (with name ppAzure)
	$Policy1 = Get-AzureRmRecoveryServicesAsrPolicy -Name $PolicyName1
	Assert-True { $Policy1.Count -gt 0 }
	Assert-NotNull($Policy1)

	# Create profile
	$Job = New-AzureRmRecoveryServicesAsrPolicy -Name $policyName2 -ReplicationProvider InMage -RecoveryPointRetentionInHours 40  -RPOWarningThresholdInMinutes 5 -ApplicationConsistentSnapshotFrequencyInMinutes 15
	WaitForJobCompletion -JobId $Job.Name

	# Get a profile created (with name ppAzure)
	$Policy2 = Get-AzureRmRecoveryServicesAsrPolicy -Name $PolicyName2
	Assert-True { $Policy2.Count -gt 0 }
	Assert-NotNull($Policy2)
	# Remove the Job created
	$RemoveJob = Remove-ASRPolicy -InputObject $Policy1
	$RemoveJob = Remove-ASRPolicy -InputObject $Policy2
}

<#
.SYNOPSIS
Site Recovery Protection Container - get.
#>
function Test-V2AAddPI
{
	param([string] $vaultSettingsFilePath)

	# Import Azure RecoveryServices Vault Settings File
	Import-AzureRmRecoveryServicesAsrVaultSettingsFile -Path $vaultSettingsFilePath
	$fabric =  Get-AsrFabric -FriendlyName $PrimaryFabricName
	 $pc =  Get-ASRProtectionContainer -FriendlyName $pcName -Fabric $fabric
	$job = New-AzureRmRecoveryServicesAsrProtectableItem -IPAddress $vmIp -name $piName -OSType Windows -ProtectionContainer $pc
	waitForJobCompletion -JobId $job.name
}

<#
.SYNOPSIS
Site Recovery Protection Container Mapping  - new get remove
#>
function Test-PCM 
{
	param([string] $vaultSettingsFilePath)

	Import-AzureRmRecoveryServicesAsrVaultSettingsFile -Path $vaultSettingsFilePath
	$fabric =  Get-AsrFabric -FriendlyName $PrimaryFabricName
	
	Import-AzureRmRecoveryServicesAsrVaultSettingsFile -Path $vaultSettingsFilePath

	$pc =  Get-ASRProtectionContainer -FriendlyName $pcName -Fabric $fabric
	
	$Job1 = New-AzureRmRecoveryServicesAsrPolicy -Name $policyName1 -ReplicationProvider InMageAzureV2 -RecoveryPointRetentionInHours 40  -RPOWarningThresholdInMinutes 5 -ApplicationConsistentSnapshotFrequencyInMinutes 15
	$Job2 = New-AzureRmRecoveryServicesAsrPolicy -Name $policyName2 -ReplicationProvider InMage -RecoveryPointRetentionInHours 40  -RPOWarningThresholdInMinutes 5 -ApplicationConsistentSnapshotFrequencyInMinutes 15
	waitForJobCompletion -JobId $job1.name
	waitForJobCompletion -JobId $job2.name

	$Policy1 = Get-AzureRmRecoveryServicesAsrPolicy -Name $PolicyName1
	$Policy2 = Get-AzureRmRecoveryServicesAsrPolicy -Name $PolicyName2

	# Create Mapping
	$pcmjob =  New-AzureRmRecoveryServicesAsrProtectionContainerMapping -Name $PrimaryProtectionContainerMapping -policy $Policy1 -PrimaryProtectionContainer $pc
	WaitForJobCompletion -JobId $pcmjob.Name 

	$pcm = Get-ASRProtectionContainerMapping -Name $PrimaryProtectionContainerMapping -ProtectionContainer $pc
	Assert-NotNull($pcm)

	$Removepcm = Remove-AzureRmRecoveryServicesAsrProtectionContainerMapping  -InputObject $pcm 
	WaitForJobCompletion -JobId $Removepcm.Name
}

<#
.SYNOPSIS
Site Recovery Replication Create ReplicatedProtectedItem
#>
function V2ACreateRPI 
{
	param([string] $vaultSettingsFilePath)

	# Import Azure RecoveryServices Vault Settings File
	Import-AzureRmRecoveryServicesAsrVaultSettingsFile -Path $vaultSettingsFilePath

	$fabric =  Get-AsrFabric -FriendlyName $PrimaryFabricName
	$pc =  Get-ASRProtectionContainer -FriendlyName $pcName -Fabric $fabric
	$Job1 = New-AzureRmRecoveryServicesAsrPolicy -Name $policyName1 -ReplicationProvider InMageAzureV2 -RecoveryPointRetentionInHours 40  -RPOWarningThresholdInMinutes 5 -ApplicationConsistentSnapshotFrequencyInMinutes 15
	$Job2 = New-AzureRmRecoveryServicesAsrPolicy -Name $policyName2 -ReplicationProvider InMage -RecoveryPointRetentionInHours 40  -RPOWarningThresholdInMinutes 5 -ApplicationConsistentSnapshotFrequencyInMinutes 15
	WaitForJobCompletion -JobId $Job1.Name
	WaitForJobCompletion -JobId $Job2.Name
	$Policy1 = Get-AzureRmRecoveryServicesAsrPolicy -Name $PolicyName1
	$Policy2 = Get-AzureRmRecoveryServicesAsrPolicy -Name $PolicyName2

	# Create Mapping
	$pcmjob =  New-AzureRmRecoveryServicesAsrProtectionContainerMapping -Name $PrimaryProtectionContainerMapping -policy $Policy1 -PrimaryProtectionContainer $pc
	WaitForJobCompletion -JobId $pcmjob.Name

	$pcm = Get-ASRProtectionContainerMapping -Name $PrimaryProtectionContainerMapping -ProtectionContainer $pc
	$pi = Get-ASRProtectableItem -ProtectionContainer $pc -FriendlyName $piName
	$EnableDRjob = New-AzureRmRecoveryServicesAsrReplicationProtectedItem -ProtectableItem $pi -Name $rpiName -ProtectionContainerMapping $pcm -RecoveryAzureStorageAccountId $RecoveryAzureStorageAccountId -RecoveryResourceGroupId  $RecoveryResourceGroupId -ProcessServer $fabric.fabricSpecificDetails.ProcessServers[0] -Account $fabric.fabricSpecificDetails.RunAsAccounts[0] -RecoveryAzureNetworkId $AzureVmNetworkId -RecoveryAzureSubnetId $Subnet
	}


<#
.SYNOPSIS
Site Recovery Recovery Plan Test -create edit delete
#>
function Test-RPJobReverse
{
	param([string] $vaultSettingsFilePath)

	# Import Azure RecoveryServices Vault Settings File
	Import-AzureRmRecoveryServicesAsrVaultSettingsFile -Path $vaultSettingsFilePath
	$fabric =  Get-AsrFabric -FriendlyName $PrimaryFabricName
	$pc =  Get-ASRProtectionContainer -FriendlyName $pcName -Fabric $fabric
	$rpi = get-AzureRmRecoveryServicesAsrReplicationProtectedItem -ProtectionContainer $pc -Name $rpiName
	$Policy2 = Get-AzureRmRecoveryServicesAsrPolicy -Name $PolicyName2
	$pcmjob =  New-AzureRmRecoveryServicesAsrProtectionContainerMapping -Name $reverseMapping -policy $Policy2 -PrimaryProtectionContainer $pc -RecoveryProtectionContainer $pc
	WaitForJobCompletion -JobId $pcmjob.Name
	
	$pcm = Get-ASRProtectionContainerMapping -Name $reverseMapping -ProtectionContainer $pc
	$job = Update-AzureRmRecoveryServicesAsrProtectionDirection -Account $fabric.FabricSpecificDetails.RunAsAccounts[0] -DataStore $fabric.FabricSpecificDetails.MasterTargetServers[0].DataStores[3]  -Direction RecoveryToPrimary -MasterTarget $fabric.FabricSpecificDetails.MasterTargetServers[0] -ProcessServer $fabric.FabricSpecificDetails.ProcessServers[0] -ProtectionContainerMapping $pcm -ReplicationProtectedItem $RPI -RetentionVolume $fabric.FabricSpecificDetails.MasterTargetServers[0].RetentionVolumes[0] 
	WaitForJobCompletion -JobId $Job.Name
	
	$RP = Get-AzureRmRecoveryServicesAsrRecoveryPlan -Name $RecoveryPlanName 

	#$job  = Start-AzureRmRecoveryServicesAsrTestFailoverJob -RecoveryPlan $RP -Direction RecoveryToPrimary -AzureVMNetworkId $rpi[0].SelectedRecoveryAzureNetworkId
	#WaitForJobCompletion -JobId $Job.Name
	#$cleanupJob = Start-AzureRmRecoveryServicesAsrTestFailoverCleanupJob -RecoveryPlan $RP -Comments "testing done"
	#WaitForJobCompletion -JobId $cleanupJob.Name
	
	$foJob = Start-AzureRmRecoveryServicesAsrUnPlannedFailoverJob -RecoveryPlan $RP -Direction RecoveryToPrimary
	WaitForJobCompletion -JobId $foJob.Name
	$commitJob = Start-AzureRmRecoveryServicesAsrCommitFailoverJob -RecoveryPlan $RP 
	WaitForJobCompletion -JobId $commitJob.Name
}

<#
.SYNOPSIS
Site Recovery resync replication.
#>
function V2ATestResync 
{
	param([string] $vaultSettingsFilePath)
	Import-AzureRmRecoveryServicesAsrVaultSettingsFile -Path $vaultSettingsFilePath

	$fabric =  Get-AsrFabric -FriendlyName $PrimaryFabricName
	$pc =  Get-ASRProtectionContainer -FriendlyName $pcName -Fabric $fabric
	$rpi = get-AzureRmRecoveryServicesAsrReplicationProtectedItem -ProtectionContainer $pc -Name $rpiName
	$job = Start-AzureRmRecoveryServicesAsrResynchronizeReplication -ReplicationProtectedItem $rpi
	WaitForJobCompletion -JobId $Job.Name
}

