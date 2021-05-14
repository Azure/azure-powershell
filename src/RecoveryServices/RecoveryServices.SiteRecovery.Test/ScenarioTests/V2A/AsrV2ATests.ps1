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
$suffix="v2a"
$JobQueryWaitTimeInSeconds = 0
$PrimaryFabricName = "PwsTestCS"
$PrimaryNetworkFriendlyName = "corp"
$RecoveryNetworkFriendlyName = "corp"
$NetworkMappingName = "corp96map"
$RecoveryPlanName = "TestRP" + $suffix
$policyName1 = "Policy" + $suffix
$policyName2 = "Ploicy"+ $suffix+"-failback"
$PrimaryProtectionContainerMapping = "pcmmapping" + $suffix
$reverseMapping = "reverseMap" + $suffix
$pcName = "PwsTestCS"
$masterTargetName = "V2A-PS-200"

$RecoveryAzureStorageAccountId = "/subscriptions/b8aef8e1-37df-4f17-a537-f10e183c8eca/resourceGroups/PwsTestRG/providers/Microsoft.Storage/storageAccounts/pwsteststor" 
$RecoveryResourceGroupId  = "/subscriptions/b8aef8e1-37df-4f17-a537-f10e183c8eca/resourceGroups/PwsTestRG" 
$DiskEncrySet = "/subscriptions/b8aef8e1-37df-4f17-a537-f10e183c8eca/resourceGroups/PwsTestRG/providers/Microsoft.Compute/diskEncryptionSets/diskEncrySet"
$Ppg = "/subscriptions/b8aef8e1-37df-4f17-a537-f10e183c8eca/resourceGroups/PwsTestRG/providers/Microsoft.Compute/proximityPlacementGroups/PwsTestPpg"
$Avset="/subscriptions/b8aef8e1-37df-4f17-a537-f10e183c8eca/resourceGroups/PwsTestRG/providers/Microsoft.Compute/availabilitySets/PwsTestAvSet"

$AzureVmNetworkId = "/subscriptions/b8aef8e1-37df-4f17-a537-f10e183c8eca/resourceGroups/PwsTestRG/providers/Microsoft.Network/virtualNetworks/PwsTestNw"
$rpiNameNew = "V2A-W2K16-201-new"
$vCenterIpOrHostName = "10.150.4.17"
$vCenterName = "vcenter67"
$Subnet = "subnet1"
$staticIp = "30.30.0.45"

$vmAccount = "windowsuser"
$piName = "V2A-W2K16-201"
$rpiName = "V2A-W2K16-201"

$piAvZone = "V2A-W2K19-202"
$rpiAvZone = "V2A-W2K19-202"

$phyVm = "PhysicalVm1"
$phyVmIp = "10.10.10.10"


$VmNameList = "v2avm1,win-4002,win-4003"

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
Site Recovery vCenter - - new set get delete.
#>
function Test-vCenter 
{
    param([string] $vaultSettingsFilePath)

    Import-AzRecoveryServicesAsrVaultSettingsFile -Path $vaultSettingsFilePath
    $fabric =  Get-AsrFabric -FriendlyName $PrimaryFabricName
    $job = New-ASRvCenter -Fabric $fabric -Name $vCenterName -IpOrHostName $vCenterIporHostName -Port 443 -Account $fabric.FabricSpecificDetails.RunAsAccounts[0]
    WaitForJobCompletion -JobId $job.name

    $fabric =  Get-AsrFabric -FriendlyName $PrimaryFabricName

    $vCenterList = Get-ASRvCenter -Fabric $fabric 
    Assert-NotNull($vCenterList[0])

    $vCenter = Get-ASRvCenter -Fabric $fabric -Name $vCenterName
    Assert-NotNull($vCenter)

    $updateJob = Update-AzRecoveryServicesAsrvCenter -InputObject $vCenter -Port 444
    WaitForJobCompletion -JobId $updatejob.name

    $job = Remove-ASRvCenter -InputObject $vCenter
    WaitForJobCompletion -JobId $job.name
}

<#
.SYNOPSIS
Site Recovery Add vCenter.
#>
function Test-AddvCenter
{
    param([string] $vaultSettingsFilePath)

    Import-AzRecoveryServicesAsrVaultSettingsFile -Path $vaultSettingsFilePath
    $fabric =  Get-AsrFabric -FriendlyName $PrimaryFabricName
    $job = New-ASRvCenter -Fabric $fabric -Name $vCenterName -IpOrHostName $vCenterIporHostName -Port 443 -Account $fabric.FabricSpecificDetails.RunAsAccounts[0]
    WaitForJobCompletion -JobId $job.name

    $fabric =  Get-AsrFabric -FriendlyName $PrimaryFabricName

    $vCenterList = Get-ASRvCenter -Fabric $fabric 
    Assert-NotNull($vCenterList[0])

    $vCenter = Get-ASRvCenter -Fabric $fabric -Name $vCenterName
    Assert-NotNull($vCenter)
}

<#
.SYNOPSIS
Site Recovery vCenter - - new set get delete.
#>
function Test-RemovevCenter 
{
    param([string] $vaultSettingsFilePath)

    Import-AzRecoveryServicesAsrVaultSettingsFile -Path $vaultSettingsFilePath
    $fabric =  Get-AsrFabric -FriendlyName $PrimaryFabricName

    $vCenter = Get-ASRvCenter -Fabric $fabric -Name $vCenterName
    Assert-NotNull($vCenter)

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
    Import-AzRecoveryServicesAsrVaultSettingsFile -Path $vaultSettingsFilePath
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

    # New-AzRecoveryServicesAsrFabric Not used in V2A
    # Remove-AzRecoveryServicesAsrFabric Not Used in V2A
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
    Import-AzRecoveryServicesAsrVaultSettingsFile -Path $vaultSettingsFilePath

    $Job = New-AzRecoveryServicesAsrPolicy -Name $policyName1 -VmwareToAzure -RecoveryPointRetentionInHours 40  -RPOWarningThresholdInMinutes 5 -ApplicationConsistentSnapshotFrequencyInHours 15
    WaitForJobCompletion -JobId $Job.Name
    # Get a profile created (with name ppAzure)
    $Policy1 = Get-AzRecoveryServicesAsrPolicy -Name $PolicyName1
    Assert-True { $Policy1.Count -gt 0 }
    Assert-NotNull($Policy1)

    # Create profile
    $Job = New-AzRecoveryServicesAsrPolicy -Name $policyName2 -AzureToVmware -RecoveryPointRetentionInHours 40  -RPOWarningThresholdInMinutes 5 -ApplicationConsistentSnapshotFrequencyInHours 15
    WaitForJobCompletion -JobId $Job.Name

    # Get a profile created (with name ppAzure)
    $Policy2 = Get-AzRecoveryServicesAsrPolicy -Name $PolicyName2
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
    Import-AzRecoveryServicesAsrVaultSettingsFile -Path $vaultSettingsFilePath
    $fabric =  Get-AsrFabric -FriendlyName $PrimaryFabricName
     $pc =  Get-ASRProtectionContainer -FriendlyName $pcName -Fabric $fabric
    $job = New-AzRecoveryServicesAsrProtectableItem -IPAddress $phyVmIp -FriendlyName $phyVm -OSType Windows -ProtectionContainer $pc
    waitForJobCompletion -JobId $job.name
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
    
    $Job1 = New-AzRecoveryServicesAsrPolicy -Name $policyName1 -VmwaretoAzure -RecoveryPointRetentionInHours 24 -RPOWarningThresholdInMinutes 15 -ApplicationConsistentSnapshotFrequencyInHours 1
    $Job2 = New-AzRecoveryServicesAsrPolicy -Name $policyName2 -AzureToVmware -RecoveryPointRetentionInHours 24 -RPOWarningThresholdInMinutes 15 -ApplicationConsistentSnapshotFrequencyInHours 1
    waitForJobCompletion -JobId $job1.name
    waitForJobCompletion -JobId $job2.name

    $Policy1 = Get-AzRecoveryServicesAsrPolicy -Name $PolicyName1
    $Policy2 = Get-AzRecoveryServicesAsrPolicy -Name $PolicyName2

    # Create Mapping
    $pcmjob =  New-AzRecoveryServicesAsrProtectionContainerMapping -Name $PrimaryProtectionContainerMapping -policy $Policy1 -PrimaryProtectionContainer $pc
    WaitForJobCompletion -JobId $pcmjob.Name 

    $pcm = Get-ASRProtectionContainerMapping -Name $PrimaryProtectionContainerMapping -ProtectionContainer $pc
    Assert-NotNull($pcm)

    $Removepcm = Remove-AzRecoveryServicesAsrProtectionContainerMapping  -InputObject $pcm 
    WaitForJobCompletion -JobId $Removepcm.Name

    # Remove the Job created
    $RemoveJob = Remove-ASRPolicy -InputObject $Policy1
    $RemoveJob = Remove-ASRPolicy -InputObject $Policy2
}

<#
.SYNOPSIS
Site Recovery Protection Container Mapping  - new get remove
#>
function V2ACreatePolicyAndAssociate
{
    param([string] $vaultSettingsFilePath)

    Import-AzRecoveryServicesAsrVaultSettingsFile -Path $vaultSettingsFilePath
    $fabric =  Get-AsrFabric -FriendlyName $PrimaryFabricName
    
    Import-AzRecoveryServicesAsrVaultSettingsFile -Path $vaultSettingsFilePath

    $pc =  Get-ASRProtectionContainer -FriendlyName $pcName -Fabric $fabric
    
    $Job1 = New-AzRecoveryServicesAsrPolicy -Name $policyName1 -VmwaretoAzure -RecoveryPointRetentionInHours 24 -RPOWarningThresholdInMinutes 15 -ApplicationConsistentSnapshotFrequencyInHours 1
    $Job2 = New-AzRecoveryServicesAsrPolicy -Name $policyName2 -AzureToVmware -RecoveryPointRetentionInHours 24 -RPOWarningThresholdInMinutes 15 -ApplicationConsistentSnapshotFrequencyInHours 1
    waitForJobCompletion -JobId $job1.name
    waitForJobCompletion -JobId $job2.name

    $Policy1 = Get-AzRecoveryServicesAsrPolicy -Name $PolicyName1
    $Policy2 = Get-AzRecoveryServicesAsrPolicy -Name $PolicyName2

    # Create Mapping
    $pcmjob =  New-AzRecoveryServicesAsrProtectionContainerMapping -Name $PrimaryProtectionContainerMapping -policy $Policy1 -PrimaryProtectionContainer $pc
    WaitForJobCompletion -JobId $pcmjob.Name 

    $pcm = Get-ASRProtectionContainerMapping -Name $PrimaryProtectionContainerMapping -ProtectionContainer $pc
    Assert-NotNull($pcm)

    $pcmjob =  New-AzRecoveryServicesAsrProtectionContainerMapping -Name $reverseMapping -policy $Policy2 -PrimaryProtectionContainer $pc -RecoveryProtectionContainer $pc
    WaitForJobCompletion -JobId $pcmjob.Name

    $reversepcm = Get-ASRProtectionContainerMapping -Name $reverseMapping -ProtectionContainer $pc
    Assert-NotNull($reversepcm)
}

<#
.SYNOPSIS
Site Recovery Replication Create ReplicatedProtectedItem
#>
function V2ACreateRPI 
{
    param([string] $vaultSettingsFilePath)

    # Import Azure RecoveryServices Vault Settings File
    Import-AzRecoveryServicesAsrVaultSettingsFile -Path $vaultSettingsFilePath

    $fabric =  Get-AsrFabric -FriendlyName $PrimaryFabricName
    $pc =  Get-ASRProtectionContainer -FriendlyName $pcName -Fabric $fabric
    #$Job1 = New-AzRecoveryServicesAsrPolicy -VmwareToAzure -Name $policyName1  -RecoveryPointRetentionInHours 24  -RPOWarningThresholdInMinutes 15 -ApplicationConsistentSnapshotFrequencyInHours 1 -MultiVmSyncStatus "Enable"
    #$Job2 = New-AzRecoveryServicesAsrPolicy -AzureToVmware -Name $policyName2  -RecoveryPointRetentionInHours 24  -RPOWarningThresholdInMinutes 15 -ApplicationConsistentSnapshotFrequencyInHours 1 -MultiVmSyncStatus "Enable"
    #WaitForJobCompletion -JobId $Job1.Name
    #WaitForJobCompletion -JobId $Job2.Name
    $Policy1 = Get-AzRecoveryServicesAsrPolicy -Name $PolicyName1
    $Policy2 = Get-AzRecoveryServicesAsrPolicy -Name $PolicyName2

    # Create Mapping
    #$pcmjob =  New-AzRecoveryServicesAsrProtectionContainerMapping -Name $PrimaryProtectionContainerMapping -policy $Policy1 -PrimaryProtectionContainer $pc
    #WaitForJobCompletion -JobId $pcmjob.Name

    $pcm = Get-ASRProtectionContainerMapping -Name $PrimaryProtectionContainerMapping -ProtectionContainer $pc
    $pi = Get-ASRProtectableItem -ProtectionContainer $pc -FriendlyName $piName

    $Account = $fabric.FabricSpecificDetails.RunAsAccounts[1]
    $ProcessServer = $fabric.fabricSpecificDetails.ProcessServers[0]

    $EnableDRjob = New-AzRecoveryServicesAsrReplicationProtectedItem -VMwareToAzure -ProtectableItem $pi -Name "V2A-W2K16-201-new" -ProtectionContainerMapping $pcm -ProcessServer $ProcessServer -Account $Account -RecoveryResourceGroupId $RecoveryResourceGroupId -logStorageAccountId $RecoveryAzureStorageAccountId -RecoveryAzureNetworkId $AzureVmNetworkId -RecoveryAzureSubnetName $Subnet
    WaitForJobCompletion -JobId $EnableDRjob.Name
}


<#
.SYNOPSIS
Site Recovery Recovery Plan Test -create edit delete
#>
function Test-RPJobReverse
{
    param([string] $vaultSettingsFilePath)

    # Import Azure RecoveryServices Vault Settings File
    Import-AzRecoveryServicesAsrVaultSettingsFile -Path $vaultSettingsFilePath
    $fabric =  Get-AsrFabric -FriendlyName $PrimaryFabricName
    $pc =  Get-ASRProtectionContainer -FriendlyName $pcName -Fabric $fabric
    $rpi = get-AzRecoveryServicesAsrReplicationProtectedItem -ProtectionContainer $pc -Name $rpiName
    
    $pcm = Get-ASRProtectionContainerMapping -Name $reverseMapping -ProtectionContainer $pc
    $job = Update-AzRecoveryServicesAsrProtectionDirection -AzureToVMware`
    -Account $fabric.FabricSpecificDetails.RunAsAccounts[0] -DataStore $fabric.FabricSpecificDetails.MasterTargetServers[0].DataStores[3] `
    -Direction RecoveryToPrimary -MasterTarget $fabric.FabricSpecificDetails.MasterTargetServers[0] `
    -ProcessServer $fabric.FabricSpecificDetails.ProcessServers[0] -ProtectionContainerMapping $pcm `
    -ReplicationProtectedItem $RPI -RetentionVolume $fabric.FabricSpecificDetails.MasterTargetServers[0].RetentionVolumes[0] 
    WaitForJobCompletion -JobId $Job.Name
    
    $RP = Get-AzRecoveryServicesAsrRecoveryPlan -Name $RecoveryPlanName 

    #$job  = Start-AzRecoveryServicesAsrTestFailoverJob -RecoveryPlan $RP -Direction RecoveryToPrimary -AzureVMNetworkId $rpi[0].SelectedRecoveryAzureNetworkId
    #WaitForJobCompletion -JobId $Job.Name
    #$cleanupJob = Start-AzRecoveryServicesAsrTestFailoverCleanupJob -RecoveryPlan $RP -Comment "testing done"
    #WaitForJobCompletion -JobId $cleanupJob.Name
    
    $foJob = Start-AzRecoveryServicesAsrUnPlannedFailoverJob -RecoveryPlan $RP -Direction RecoveryToPrimary
    WaitForJobCompletion -JobId $foJob.Name
    $commitJob = Start-AzRecoveryServicesAsrCommitFailoverJob -RecoveryPlan $RP 
    WaitForJobCompletion -JobId $commitJob.Name
}

<#
.SYNOPSIS
Site Recovery resync replication.
#>
function V2ATestResync 
{
    param([string] $vaultSettingsFilePath)
    Import-AzRecoveryServicesAsrVaultSettingsFile -Path $vaultSettingsFilePath

    $fabric =  Get-AsrFabric -FriendlyName $PrimaryFabricName
    $pc =  Get-ASRProtectionContainer -FriendlyName $pcName -Fabric $fabric
    $rpi = get-AzRecoveryServicesAsrReplicationProtectedItem -ProtectionContainer $pc -Name "V2A-W2K16-201-new"
    $job = Start-AzRecoveryServicesAsrResynchronizeReplicationJob -ReplicationProtectedItem $rpi
    WaitForJobCompletion -JobId $Job.Name
}

<#
.SYNOPSIS
Site Recovery update mobility service.
#>
function V2AUpdateMobilityService
{
    param([string] $vaultSettingsFilePath)
    Import-AzRecoveryServicesAsrVaultSettingsFile -Path $vaultSettingsFilePath
    $fabric =  Get-AsrFabric -FriendlyName $PrimaryFabricName
    $pc =  Get-ASRProtectionContainer -FriendlyName $pcName -Fabric $fabric
    $rpi = get-AzRecoveryServicesAsrReplicationProtectedItem -ProtectionContainer $pc -Name $rpiAvZone
    $account = $fabric.FabricSpecificDetails.RunAsAccounts | where {$_.AccountName -eq $vmAccount}
    $job = Update-AzRecoveryServicesAsrMobilityService -ReplicationProtectedItem $rpi -Account $account
    WaitForJobCompletion -JobId $Job.Name
}

<#
.SYNOPSIS
Site Recovery update ASR service provider.
#>
function V2AUpdateServiceProvider 
{
    param([string] $vaultSettingsFilePath)
    Import-AzRecoveryServicesAsrVaultSettingsFile -Path $vaultSettingsFilePath
    $fabric =  Get-AsrFabric -FriendlyName $PrimaryFabricName
    $splist = Get-ASRServicesProvider -Fabric $fabric 
    $job = Update-ASRServicesProvider -InputObject $splist[0]
    WaitForJobCompletion -JobId $Job.Name
}

<#
.SYNOPSIS
Site Recovery update ASR service provider.
#>
function V2ASwitchProcessServer 
{
    param([string] $vaultSettingsFilePath)
    Import-AzRecoveryServicesAsrVaultSettingsFile -Path $vaultSettingsFilePath
    $fabric =  Get-AsrFabric -FriendlyName $PrimaryFabricName
    $pc =  Get-ASRProtectionContainer -FriendlyName $pcName -Fabric $fabric
    $RPIList = Get-AzRecoveryServicesAsrReplicationProtectedItem   -ProtectionContainer $pc
    $job = Start-AzRecoveryServicesAsrSwitchProcessServerJob -Fabric $fabric -SourceProcessServer $fabric.FabricSpecificDetails.ProcessServers[0] -TargetProcessServer $fabric.FabricSpecificDetails.ProcessServers[1] -ReplicatedItem $RPIList
    WaitForJobCompletion -JobId $Job.Name
    $job = Start-AzRecoveryServicesAsrSwitchProcessServerJob -Fabric $fabric -SourceProcessServer $fabric.FabricSpecificDetails.ProcessServers[1] -TargetProcessServer $fabric.FabricSpecificDetails.ProcessServers[0]
    WaitForJobCompletion -JobId $Job.Name
}

<#
.SYNOPSIS
Site Recovery Failover Job.
#>

function V2ATestFailoverJob 
{
    param([string] $vaultSettingsFilePath)

    # Import Azure RecoveryServices Vault Settings File
    Import-AzRecoveryServicesAsrVaultSettingsFile -Path $vaultSettingsFilePath

    $fabric =  Get-AsrFabric -FriendlyName $PrimaryFabricName
    $pc =  Get-ASRProtectionContainer -FriendlyName $pcName -Fabric $fabric
    
    $rpi = get-AzRecoveryServicesAsrReplicationProtectedItem -ProtectionContainer $pc -Name "V2A-W2K16-201-new"
    ## do network mapping
    do
    {
        $rPoints = Get-ASRRecoveryPoint -ReplicationProtectedItem $rpi
        if($rpoints -and  $rpoints.count  -eq 0) {		
			#timeout 60
		}		
		else
		{
			break
		}
    }while ($rpoints.count -lt 0)

    $tfoJob = Start-AzRecoveryServicesAsrTestFailoverJob -ReplicationProtectedItem $rpi -Direction PrimaryToRecovery -AzureVMNetworkId  $AzureVMNetworkId -RecoveryPoint $rpoints[0]

    WaitForJobCompletion -JobId $tfoJob.Name

    $cleanupJob = Start-AzRecoveryServicesAsrTestFailoverCleanupJob -ReplicationProtectedItem $rpi -Comment "testing done"
    WaitForJobCompletion -JobId $cleanupJob.Name
    }

    function V2AFailoverJob 
    {
        param([string] $vaultSettingsFilePath)

        # Import Azure RecoveryServices Vault Settings File
        Import-AzRecoveryServicesAsrVaultSettingsFile -Path $vaultSettingsFilePath

        $fabric =  Get-AsrFabric -FriendlyName $PrimaryFabricName
        $pc =  Get-ASRProtectionContainer -FriendlyName $pcName -Fabric $fabric
        $rpi = get-AzRecoveryServicesAsrReplicationProtectedItem -ProtectionContainer $pc -FriendlyName $rpiName
    
        $foJob = Start-AzRecoveryServicesAsrUnPlannedFailoverJob -ReplicationProtectedItem $rpi -Direction PrimaryToRecovery
        WaitForJobCompletion -JobId $foJob.Name
        $commitJob = Start-AzRecoveryServicesAsrCommitFailoverJob -ReplicationProtectedItem $rpi 
        WaitForJobCompletion -JobId $commitJob.Name
    }

<#
.SYNOPSIS
Site Recovery Replication ReplicatedProtectedItem change direction and failback
#>
function V2ATestReprotectAzureToVmware
{
    param([string] $vaultSettingsFilePath)
    Import-AzRecoveryServicesAsrVaultSettingsFile -Path $vaultSettingsFilePath
    $fabric =  Get-AsrFabric -FriendlyName $PrimaryFabricName
    $pc =  Get-ASRProtectionContainer -FriendlyName $pcName -Fabric $fabric
    $rpi = get-AzRecoveryServicesAsrReplicationProtectedItem -ProtectionContainer $pc -FriendlyName $rpiName
    
    #$Policy2 = Get-AzRecoveryServicesAsrPolicy -Name $PolicyName2
    #$pcmjob =  New-AzRecoveryServicesAsrProtectionContainerMapping -Name $reverseMapping -policy $Policy2 -PrimaryProtectionContainer $pc -RecoveryProtectionContainer $pc
    #WaitForJobCompletion -JobId $pcmjob.Name

    $pcm = Get-ASRProtectionContainerMapping -Name $reverseMapping -ProtectionContainer $pc

    $processServer = $fabric.FabricSpecificDetails.ProcessServers | where {$_.FriendlyName -eq $PrimaryFabricName}
    $masterTarget = $fabric.FabricSpecificDetails.MasterTargetServers | where {$_.Name -eq $masterTargetName}
    $account = $fabric.FabricSpecificDetails.RunAsAccounts | where {$_.AccountName -eq $vmAccount}

    $job = Update-AzRecoveryServicesAsrProtectionDirection `
                -AzureToVmware `
                -Account $account `
                -DataStore $masterTarget.DataStores[0]  `
                -Direction RecoveryToPrimary -MasterTarget $masterTarget `
                -ProcessServer $processServer `
                -ProtectionContainerMapping $pcm `
                -ReplicationProtectedItem $RPI `
                -RetentionVolume $masterTarget.RetentionVolumes[0]
    
    }

function V2ATestFailback
{
    param([string] $vaultSettingsFilePath)
        Import-AzRecoveryServicesAsrVaultSettingsFile -Path $vaultSettingsFilePath
        $fabric = Get-AsrFabric -FriendlyName $PrimaryFabricName
        $pc =  Get-ASRProtectionContainer -FriendlyName $pcName -Fabric $fabric
    
        $rpi = get-AzRecoveryServicesAsrReplicationProtectedItem -ProtectionContainer $pc -FriendlyName $rpiName
        $job = Start-AzRecoveryServicesAsrUnPlannedFailoverJob -ReplicationProtectedItem $rpi -Direction PrimaryToRecovery
        WaitForJobCompletion -JobId $Job.Name

        $job = Start-AzRecoveryServicesAsrCommitFailoverJob -ReplicationProtectedItem $rpi 
        WaitForJobCompletion -JobId $Job.Name
}

function V2ATestReprotectVMwareToAzure
{
    param([string] $vaultSettingsFilePath)
        Import-AzRecoveryServicesAsrVaultSettingsFile -Path $vaultSettingsFilePath
        $fabric =  Get-AsrFabric -FriendlyName $PrimaryFabricName
        $pc =  Get-ASRProtectionContainer -FriendlyName $pcName -Fabric $fabric
    
        $rpi = get-AzRecoveryServicesAsrReplicationProtectedItem -ProtectionContainer $pc -FriendlyName $rpiName
        $pcm = Get-ASRProtectionContainerMapping -Name $PrimaryProtectionContainerMapping -ProtectionContainer $pc

        $processServer = $fabric.FabricSpecificDetails.ProcessServers | where {$_.FriendlyName -eq $masterTargetName}
        $account = $fabric.FabricSpecificDetails.RunAsAccounts | where {$_.AccountName -eq $vmAccount}

        $job = Update-AzRecoveryServicesAsrProtectionDirection `
                    -VMwareToAzure `
                    -Account $account `
                    -Direction RecoveryToPrimary `
                    -ProcessServer $processServer `
                    -ProtectionContainerMapping $pcm `
                    -ReplicationProtectedItem $rpi

        WaitForJobCompletion -JobId $Job.Name
}

function v2aUpdatePolicy
{
    param([string] $vaultSettingsFilePath)
        Import-AzRecoveryServicesAsrVaultSettingsFile -Path $vaultSettingsFilePath
        $po = get-asrpolicy -Name $policyName1
        $job = Update-AzRecoveryServicesAsrPolicy  -VMwareToAzure -ApplicationConsistentSnapshotFrequencyInHours 5 -InputObject $po -MultiVmSyncStatus "Enable"
        WaitForJobCompletion -JobId $job.Name

        $job = Update-AzRecoveryServicesAsrPolicy  -VMwareToAzure -ApplicationConsistentSnapshotFrequencyInHours 2 -InputObject $po
        WaitForJobCompletion -JobId $job.Name
}

function Test-SetRPI
{
    param([string] $vaultSettingsFilePath)
        Import-AzRecoveryServicesAsrVaultSettingsFile -Path $vaultSettingsFilePath
        $fabric =  Get-AsrFabric -FriendlyName $PrimaryFabricName
        $pc =  Get-ASRProtectionContainer -FriendlyName $pcName -Fabric $fabric
        $rpi = get-AzRecoveryServicesAsrReplicationProtectedItem -ProtectionContainer $pc -Name "V2A-W2K16-201-new"
        Set-AzRecoveryServicesAsrReplicationProtectedItem -InputObject $rpi -UpdateNic $rpi.nicDetailsList[0].nicId -PrimaryNic $rpi.nicDetailsList[0].nicId -RecoveryNetworkId `
                        $AzureVmNetworkId -RecoveryNicStaticIPAddress $staticIp -RecoveryNicSubnetName $Subnet -UseManagedDisk "True"
    
}

function V2ACreateRPIWithDES
{
    param([string] $vaultSettingsFilePath)
        Import-AzRecoveryServicesAsrVaultSettingsFile -Path $vaultSettingsFilePath
        $fabric =  Get-AsrFabric -FriendlyName $PrimaryFabricName
        $pc =  Get-ASRProtectionContainer -FriendlyName $pcName -Fabric $fabric

        $pcm = Get-AzRecoveryServicesAsrProtectionContainerMapping -ProtectionContainer $pc -Name $PrimaryProtectionContainerMapping
        $pi = Get-ASRProtectableItem -ProtectionContainer $pc -FriendlyName $piName
        
        $processServer = $fabric.FabricSpecificDetails.ProcessServers | where {$_.FriendlyName -eq $masterTargetName}
        $account = $fabric.FabricSpecificDetails.RunAsAccounts | where {$_.AccountName -eq $vmAccount}
        $EnableDRjob = New-AzRecoveryServicesAsrReplicationProtectedItem -VMwareToAzure -ProtectableItem $pi -Name $rpiName -ProtectionContainerMapping $pcm -ProcessServer $processServer `
                        -Account $account -RecoveryResourceGroupId $RecoveryResourceGroupId -DiskEncryptionSetId $DiskEncrySet -logStorageAccountId $RecoveryAzureStorageAccountId `
                        -RecoveryAzureNetworkId $AzureVmNetworkId -RecoveryAzureSubnetName $Subnet
}

function V2ACreateRPIWithDESEnabledDiskInput
{
    param([string] $vaultSettingsFilePath)
        Import-AzRecoveryServicesAsrVaultSettingsFile -Path $vaultSettingsFilePath
        $fabric =  Get-AsrFabric -FriendlyName $PrimaryFabricName
        $pc =  Get-ASRProtectionContainer -FriendlyName $pcName -Fabric $fabric

        $pcm = Get-AzRecoveryServicesAsrProtectionContainerMapping -ProtectionContainer $pc -Name $PrimaryProtectionContainerMapping
        $pi = Get-ASRProtectableItem -ProtectionContainer $pc -FriendlyName $piAvZone
        
        $processServer = $fabric.FabricSpecificDetails.ProcessServers | where {$_.FriendlyName -eq $masterTargetName}
        $account = $fabric.FabricSpecificDetails.RunAsAccounts | where {$_.AccountName -eq $vmAccount}

        $disk = $pi.Disks | where {$_.Name -match "Drive0"}
        $diskInput = New-AzRecoveryServicesAsrInMageAzureV2DiskInput -DiskId $disk.Id -LogStorageAccountId $RecoveryAzureStorageAccountId -DiskType "Standard_LRS" -DiskEncryptionSetId $DiskEncrySet
        $EnableDRjob = New-AzRecoveryServicesAsrReplicationProtectedItem -VMwareToAzure -ProtectableItem $pi -Name $rpiAvZone -ProtectionContainerMapping $pcm -InMageAzureV2DiskInput $diskInput `
                        -ProcessServer $processServer -Account $account -RecoveryResourceGroupId $RecoveryResourceGroupId -logStorageAccountId $RecoveryAzureStorageAccountId `
                        -RecoveryAzureNetworkId $AzureVmNetworkId -RecoveryAzureSubnetName $Subnet
}

function V2ACreateRPIWithPPG
{
    param([string] $vaultSettingsFilePath)
        Import-AzRecoveryServicesAsrVaultSettingsFile -Path $vaultSettingsFilePath
        $fabric =  Get-AsrFabric -FriendlyName $PrimaryFabricName
        $pc =  Get-ASRProtectionContainer -FriendlyName $pcName -Fabric $fabric

        $pcm = Get-AzRecoveryServicesAsrProtectionContainerMapping -ProtectionContainer $pc -Name $PrimaryProtectionContainerMapping
        $pi = Get-ASRProtectableItem -ProtectionContainer $pc -FriendlyName $piName
        
        $processServer = $fabric.FabricSpecificDetails.ProcessServers | where {$_.FriendlyName -eq $masterTargetName}
        $account = $fabric.FabricSpecificDetails.RunAsAccounts | where {$_.AccountName -eq $vmAccount}

        $EnableDRjob = New-AzRecoveryServicesAsrReplicationProtectedItem -VMwareToAzure -ProtectableItem $pi -Name $rpiName -ProtectionContainerMapping $pcm -ProcessServer $processServer `
                        -Account $account -RecoveryResourceGroupId $RecoveryResourceGroupId -logStorageAccountId $RecoveryAzureStorageAccountId -RecoveryProximityPlacementGroupId $Ppg `
                        -RecoveryAzureNetworkId $AzureVmNetworkId -RecoveryAzureSubnetName $Subnet
}

function V2AUpdateRPIWithPPG
{
    param([string] $vaultSettingsFilePath)
        Import-AzRecoveryServicesAsrVaultSettingsFile -Path $vaultSettingsFilePath
        $fabric =  Get-AsrFabric -FriendlyName $PrimaryFabricName
        $pc =  Get-ASRProtectionContainer -FriendlyName $pcName -Fabric $fabric
        $rpi = Get-ASRReplicationProtectedItem -ProtectionContainer $pc -FriendlyName $rpiAvZone

        $UpdateVmjob = Set-AzRecoveryServicesAsrReplicationProtectedItem -InputObject $rpi -Name $rpiAvZone -RecoveryProximityPlacementGroupId $Ppg
        
        $rpi = Get-AsrReplicationProtectedItem -ProtectionContainer $pc -FriendlyName $piName
        Assert-NotNull($rpi.ProviderSpecificDetails.RecoveryProximityPlacementGroupId)
}

function V2ACreateRPIWithAvZone
{
    param([string] $vaultSettingsFilePath)
        Import-AzRecoveryServicesAsrVaultSettingsFile -Path $vaultSettingsFilePath
        #$PrimaryFabricName = "WIN-B6L6OJO1E6Q"
        #$pcName = "WIN-B6L6OJO1E6Q"
        $fabric =  Get-AsrFabric -FriendlyName $PrimaryFabricName
        $pc =  Get-ASRProtectionContainer -FriendlyName $pcName -Fabric $fabric
        #$PolicyName1 = "test-policy"
        $Policy1 = Get-AzRecoveryServicesAsrPolicy -Name $PolicyName1
        $pcm = Get-AzRecoveryServicesAsrProtectionContainerMapping -ProtectionContainer $pc -Name $PrimaryProtectionContainerMapping
        $pi = Get-ASRProtectableItem -ProtectionContainer $pc -FriendlyName $piAvZone
        $Account = $fabric.FabricSpecificDetails.RunAsAccounts[1]
        $ProcessServer = $fabric.FabricSpecificDetails.ProcessServers[0]
        $avZone = "1"
        $EnableDRjob = New-AzRecoveryServicesAsrReplicationProtectedItem -VMwareToAzure -ProtectableItem $pi -Name $rpiAvZone -ProtectionContainerMapping $pcm -ProcessServer $ProcessServer -Account $Account -RecoveryResourceGroupId $RecoveryResourceGroupId -logStorageAccountId $RecoveryAzureStorageAccountId -RecoveryAvailabilityZone $avZone -RecoveryAzureNetworkId $AzureVmNetworkId -RecoveryAzureSubnetName $Subnet
        WaitForJobCompletion -JobId $EnableDRjob.Name
}

function V2AUpdateRPIWithAvZone
{
    param([string] $vaultSettingsFilePath)
        Import-AzRecoveryServicesAsrVaultSettingsFile -Path $vaultSettingsFilePath
        $fabric =  Get-AsrFabric -FriendlyName $PrimaryFabricName
        $pc =  Get-ASRProtectionContainer -FriendlyName $pcName -Fabric $fabric
        $rpi = Get-ASRReplicationProtectedItem -ProtectionContainer $pc -FriendlyName $rpiAvZone
        $avZone = "2"
        $UpdateVmjob = Set-AzRecoveryServicesAsrReplicationProtectedItem -InputObject $rpi -Name $rpiAvZone -RecoveryAvailabilityZone $avZone
        $rpi = Get-AsrReplicationProtectedItem -ProtectionContainer $pc -FriendlyName $rpiAvZone
        Assert-NotNull($rpi.ProviderSpecificDetails.RecoveryAvailabilityZone)
}

function V2ACreateRPIWithAdditionalProperties
{
    param([string] $vaultSettingsFilePath)
        Import-AzRecoveryServicesAsrVaultSettingsFile -Path $vaultSettingsFilePath
        $fabric =  Get-AsrFabric -FriendlyName $PrimaryFabricName
        $pc =  Get-ASRProtectionContainer -FriendlyName $pcName -Fabric $fabric
        $Policy1 = Get-AzRecoveryServicesAsrPolicy -Name $PolicyName1
        $pcm = Get-AzRecoveryServicesAsrProtectionContainerMapping -ProtectionContainer $pc -Name $PrimaryProtectionContainerMapping
        $pi = Get-ASRProtectableItem -ProtectionContainer $pc -FriendlyName $piAvZone

        $processServer = $fabric.FabricSpecificDetails.ProcessServers | where {$_.FriendlyName -eq $masterTargetName}
		$account = $fabric.FabricSpecificDetails.RunAsAccounts | where {$_.AccountName -eq $vmAccount}

        $size="Standard_F2s_v2"
        $sqlLicenseType = "AHUB"
        $vmTag = New-Object "System.Collections.Generic.Dictionary``2[System.String,System.String]"
        $vmTag.Add("VmTag1","powershellVm")
        $diskTag = New-Object "System.Collections.Generic.Dictionary``2[System.String,System.String]"
        $diskTag.Add("DiskTag1","powershellDisk")
        $nicTag = New-Object "System.Collections.Generic.Dictionary``2[System.String,System.String]"
        $nicTag.Add("NicTag1","powershellNic")
        $EnableDRjob = New-AzRecoveryServicesAsrReplicationProtectedItem -VMwareToAzure -ProtectableItem $pi -Name $rpiAvZone -ProtectionContainerMapping $pcm `
                        -ProcessServer $ProcessServer -Account $Account -RecoveryResourceGroupId $RecoveryResourceGroupId -logStorageAccountId $RecoveryAzureStorageAccountId `
                        -RecoveryAzureNetworkId $AzureVmNetworkId -RecoveryAzureSubnetName $Subnet -RecoveryProximityPlacementGroupId $Ppg -RecoveryAvailabilitySetId $Avset `
                        -Size $size -SqlServerLicenseType $sqlLicenseType -RecoveryVmTag $vmTag -RecoveryNicTag $nicTag -DiskTag $diskTag
}

function V2AUpdateRPIWithAdditionalProperties
{
    param([string] $vaultSettingsFilePath)
        Import-AzRecoveryServicesAsrVaultSettingsFile -Path $vaultSettingsFilePath
        $fabric =  Get-AsrFabric -FriendlyName $PrimaryFabricName
        $pc =  Get-ASRProtectionContainer -FriendlyName $pcName -Fabric $fabric
        $Policy1 = Get-AzRecoveryServicesAsrPolicy -Name $PolicyName1
        $pcm = Get-AzRecoveryServicesAsrProtectionContainerMapping -ProtectionContainer $pc -Name $PrimaryProtectionContainerMapping
        $rpi = Get-ASRReplicationProtectedItem -ProtectionContainer $pc -FriendlyName $rpiAvZone

        $sqlLicenseType = "PAYG"
        $vmTag = New-Object "System.Collections.Generic.Dictionary``2[System.String,System.String]"
        $vmTag.Add("VmTag2","powershellVm2")
        $diskTag = New-Object "System.Collections.Generic.Dictionary``2[System.String,System.String]"
        $diskTag.Add("DiskTag2","powershellDisk2")
        $nicTag = New-Object "System.Collections.Generic.Dictionary``2[System.String,System.String]"
        $nicTag.Add("NicTag2","powershellNic2")

        $currentJob = Set-AsrReplicationProtectedItem -InputObject $rpi -Name $rpiAvZone -SqlServerLicenseType $sqlLicenseType -RecoveryVmTag $vmTag -RecoveryNicTag $nicTag -DiskTag $diskTag
        WaitForJobCompletion -JobId $currentJob.Name

        $rpi = Get-AsrReplicationProtectedItem -ProtectionContainer $pc -FriendlyName $rpiAvZone
        Assert-NotNull($rpi.ProviderSpecificDetails.RecoveryVmTag)
        Assert-NotNull($rpi.ProviderSpecificDetails.DiskTag)
        Assert-NotNull($rpi.ProviderSpecificDetails.RecoveryNicTag)
}