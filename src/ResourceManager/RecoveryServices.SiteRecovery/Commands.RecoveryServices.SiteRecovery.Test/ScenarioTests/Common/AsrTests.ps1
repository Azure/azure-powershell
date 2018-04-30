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
$vCenterIpOrHostName = "10.150.209.216"
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
        [int] $JobQueryWaitTimeInSeconds = $JobQueryWaitTimeInSeconds
        )
        $isProcessingLeft = $true
        $IRjobs = $null

        do
        {
            $IRjobs = Get-AzureRmRecoveryServicesAsrJob -TargetObjectId $VM.Name | Sort-Object StartTime -Descending | select -First 4 | Where-Object{$_.JobType -eq "PrimaryIrCompletion" -or $_.JobType -eq "SecondaryIrCompletion"}
            if($IRjobs -eq $null -or $IRjobs.Count -lt 2)
            {
                $isProcessingLeft = $true
            }
            else
            {
                $isProcessingLeft = $false
            }

            if($isProcessingLeft)
            {
                [Microsoft.Azure.Test.TestUtilities]::Wait($JobQueryWaitTimeInSeconds * 1000)
            }
        }While($isProcessingLeft)

        $IRjobs
        WaitForJobCompletion -JobId $IRjobs[0].Name -JobQueryWaitTimeInSeconds $JobQueryWaitTimeInSeconds
        WaitForJobCompletion -JobId $IRjobs[1].Name -JobQueryWaitTimeInSeconds $JobQueryWaitTimeInSeconds
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
Site Recovery Get Events.
#>
function Test-AsrEvent
{
    param([string] $vaultSettingsFilePath)

    # Import Azure RecoveryServices Vault Settings File
    Import-AzureRmRecoveryServicesAsrVaultSettingsFile -Path $vaultSettingsFilePath

    $Events = get-asrEvent
    Assert-NotNull($Events)

    $e = Get-AzureRmRecoveryServicesAsrEvent -Name $Events[0].Name
    Assert-NotNull($e)
    Assert-NotNull($e.Name)
    Assert-NotNull($e.Description)
    Assert-NotNull($e.FabricId)
    Assert-NotNull($e.AffectedObjectFriendlyName)

    $e = Get-AzureRmRecoveryServicesAsrEvent -Severity $Events[0].Severity
    Assert-NotNull($e)

    $e = Get-AzureRmRecoveryServicesAsrEvent -EventType VmHealth
    Assert-NotNull($e)

    $e = Get-AzureRmRecoveryServicesAsrEvent -EventType VmHealth -AffectedObjectFriendlyName $e[0].AffectedObjectFriendlyName
    Assert-NotNull($e)

    $e = Get-AzureRmRecoveryServicesAsrEvent -EventType VmHealth -FabricId $e[0].FabricId
    Assert-NotNull($e)

     $e = Get-AzureRmRecoveryServicesAsrEvent -ResourceId  $e[0].Id
    Assert-NotNull($e)

    $fabric =  Get-AsrFabric -FriendlyName $PrimaryFabricName
    $e = Get-AzureRmRecoveryServicesAsrEvent -Fabric $fabric
    Assert-NotNull($e)
    
    $e = Get-AzureRmRecoveryServicesAsrEvent -AffectedObjectFriendlyName $Events[0].AffectedObjectFriendlyName
    Assert-NotNull($e)
    
    $e = Get-AzureRmRecoveryServicesAsrEvent -StartTime "8/18/2017 2:05:00 AM"
    Assert-NotNull($e)

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
    $NotificationSettings = Set-AzureRmRecoveryServicesAsrNotificationSetting -EnableEmailSubscriptionOwner -CustomEmailAddress "abcxxxx@microsft.com"
    Assert-NotNull($NotificationSettings)
    
    $NotificationSettings = Set-AzureRmRecoveryServicesAsrNotificationSetting -DisableEmailToSubscriptionOwner -CustomEmailAddress "abcxxxx@microsft.com"
    Assert-NotNull($NotificationSettings)

    $NotificationSettings = Get-AzureRmRecoveryServicesAsrNotificationSetting
    Assert-NotNull($NotificationSettings)
    Assert-NotNull($NotificationSettings.CustomEmailAddress)
    Assert-AreEqual -expected "abcxxxx@microsft.com" -actual $NotificationSettings.CustomEmailAddress
    Assert-NotNull($NotificationSettings.EmailSubscriptionOwner)
    Assert-NotNull($NotificationSettings.Locale)
    Set-AzureRmRecoveryServicesAsrNotificationSetting -DisableNotification
}
