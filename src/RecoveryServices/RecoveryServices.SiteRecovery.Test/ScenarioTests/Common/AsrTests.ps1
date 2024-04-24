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
$PrimaryFabricName = "PwsTestCS"
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
        [PSObject] $VM,
        [int] $JobQueryWaitTimeInSeconds = $JobQueryWaitTimeInSeconds
        )
        $isProcessingLeft = $true
        $IRjobs = $null

        do
        {
            $IRjobs = Get-AzRecoveryServicesAsrJob -TargetObjectId $VM.Name | Sort-Object StartTime -Descending | select -First 4 | Where-Object{$_.JobType -eq "PrimaryIrCompletion" -or $_.JobType -eq "SecondaryIrCompletion"}
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
                [Microsoft.Rest.ClientRuntime.Azure.TestFramework.TestUtilities]::Wait($JobQueryWaitTimeInSeconds * 1000)
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
    Import-AzRecoveryServicesAsrVaultSettingsFile -Path $vaultSettingsFilePath

    # Enumerate Vaults
    $vaults = Get-AzRecoveryServicesVault
    Assert-True { $vaults.Count -gt 0 }
    Assert-NotNull($vaults)
    foreach($vault in $vaults)
    {
        Assert-NotNull($vault.Name)
        Assert-NotNull($vault.ID)
    }

    # Enumerate Recovery Services Providers
    $rsps = Get-AzRecoveryServicesAsrFabric | Get-AzRecoveryServicesAsrServicesProvider
    Assert-True { $rsps.Count -gt 0 }
    Assert-NotNull($rsps)
    foreach($rsp in $rsps)
    {
        Assert-NotNull($rsp.Name)
        Assert-NotNull($rsp.ID)
    }

    # Enumerate Protection Containers
    $protectionContainers = Get-AzRecoveryServicesAsrFabric | Get-AzRecoveryServicesAsrProtectionContainer
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
    Import-AzRecoveryServicesAsrVaultSettingsFile -Path $vaultSettingsFilePath

    $Events = get-asrEvent
    Assert-NotNull($Events)

    <# $e = Get-AzRecoveryServicesAsrEvent -Name $Events[0].Name
    Assert-NotNull($e)
    Assert-NotNull($e.Name)
    Assert-NotNull($e.Description)
    Assert-NotNull($e.FabricId)
    Assert-NotNull($e.AffectedObjectFriendlyName) #>

    $e = Get-AzRecoveryServicesAsrEvent -Severity $Events[0].Severity
    Assert-NotNull($e)

    $e = Get-AzRecoveryServicesAsrEvent -EventType VmHealth
    Assert-NotNull($e)

    $e = Get-AzRecoveryServicesAsrEvent -EventType VmHealth -AffectedObjectFriendlyName $e[0].AffectedObjectFriendlyName
    Assert-NotNull($e)

    $e = Get-AzRecoveryServicesAsrEvent -EventType VmHealth -FabricId $e[0].FabricId
    Assert-NotNull($e)

    #$e = Get-AzRecoveryServicesAsrEvent -ResourceId  $e[0].Id
    #Assert-NotNull($e)

    $fabric =  Get-AsrFabric -FriendlyName $PrimaryFabricName
    $e = Get-AzRecoveryServicesAsrEvent -Fabric $fabric
    Assert-NotNull($e)
    
    $e = Get-AzRecoveryServicesAsrEvent -AffectedObjectFriendlyName $Events[0].AffectedObjectFriendlyName
    Assert-NotNull($e)
    
    $startTime = "4/4/2021 10:57:32 AM"
    $e = Get-AzRecoveryServicesAsrEvent -StartTime $startTime
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
    Import-AzRecoveryServicesAsrVaultSettingsFile -Path $vaultSettingsFilePath
    # Enumerate specific Fabric
    $jobs =  Get-AzRecoveryServicesAsrJob
    Assert-NotNull($jobs)
    $job = $jobs[0]
    Assert-NotNull($job.name)
    Assert-NotNull($job.id)

    $job = Get-AzRecoveryServicesAsrJob -name $job.name

    Assert-NotNull($job.name)
    Assert-NotNull($job.id)

    $job = Get-AzRecoveryServicesAsrJob -job $job

    Assert-NotNull($job.name)
    Assert-NotNull($job.id)

    $jobList = Get-AzRecoveryServicesAsrJob -TargetObjectId $job.TargetObjectId

    Assert-NotNull($jobList)

    $startTime = "2021-04-04T05:28:32.1338170Z"
    $endTime = "2021-04-07T05:28:32.1391983Z"

    $jobList = Get-AzRecoveryServicesAsrJob -StartTime $startTime -EndTime $endTime
    Assert-NotNull($jobList)

    $jobList =  Get-AzRecoveryServicesAsrJob -State Succeeded
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
    Import-AzRecoveryServicesAsrVaultSettingsFile -Path $vaultSettingsFilePath
    # Enumerate specific Fabric
    $NotificationSettings = Set-AzRecoveryServicesAsrNotificationSetting -EnableEmailSubscriptionOwner -CustomEmailAddress "abcxxxx@microsft.com"
    Assert-NotNull($NotificationSettings)
    
    $NotificationSettings = Set-AzRecoveryServicesAsrNotificationSetting -DisableEmailToSubscriptionOwner -CustomEmailAddress "abcxxxx@microsft.com"
    Assert-NotNull($NotificationSettings)

    $NotificationSettings = Get-AzRecoveryServicesAsrNotificationSetting
    Assert-NotNull($NotificationSettings)
    Assert-NotNull($NotificationSettings.CustomEmailAddress)
    Assert-AreEqual -expected "abcxxxx@microsft.com" -actual $NotificationSettings.CustomEmailAddress
    Assert-NotNull($NotificationSettings.EmailSubscriptionOwner)
    Assert-NotNull($NotificationSettings.Locale)
    Set-AzRecoveryServicesAsrNotificationSetting -DisableNotification
}

function Test-AzureMonitorAlertsForSiteRecovery
{
	$location = "centraluseuap"
	$resourceGroupName = "vijami-alertrg"
	$vaultName1 = "ASRalerts-pstest-vault1"
	$vaultName2 = "ASRalerts-pstest-vault2"

	try
	{	
		# create a vault without Alert settings
		$vault1 = New-AzRecoveryServicesVault -Name $vaultName1 -ResourceGroupName $resourceGroupName -Location "centraluseuap"
		
		Assert-True { $vault1.Properties.AlertSettings -eq $null }

		# create a vault with Alert settings 
		$vault2 = New-AzRecoveryServicesVault -Name $vaultName2 -ResourceGroupName $resourceGroupName -Location "centraluseuap" `
			-DisableAzureMonitorAlertsForJobFailure $false `
            -DisableAzureMonitorAlertsForAllReplicationIssue $false `
            -DisableAzureMonitorAlertsForAllFailoverIssue $true `
            -DisableEmailNotificationsForSiteRecovery $false `
			-DisableClassicAlerts $true			
		
		Assert-True { $vault2.Properties.AlertSettings -ne $null }
		Assert-True { $vault2.Properties.AlertSettings.AzureMonitorAlertsForAllJobFailure -eq "Enabled" }
		Assert-True { $vault2.Properties.AlertSettings.ClassicAlertsForCriticalOperations -eq "Disabled" }
        Assert-True { $vault2.Properties.AlertSettings.AzureMonitorAlertsForAllReplicationIssues -eq "Enabled" }
		Assert-True { $vault2.Properties.AlertSettings.AzureMonitorAlertsForAllFailoverIssues -eq "Disabled" }
        Assert-True { $vault2.Properties.AlertSettings.EmailNotificationsForSiteRecovery -eq "Enabled" }

		$vault = Update-AzRecoveryServicesVault -ResourceGroupName "vijami-alertrg"  -Name "ASRalerts-pstest-vault1" -DisableAzureMonitorAlertsForAllReplicationIssue $true

		# update alert settings 
		$vault1 = Update-AzRecoveryServicesVault -Name $vaultName1 -ResourceGroupName $resourceGroupName `
			-DisableAzureMonitorAlertsForAllFailoverIssue $false `
			-DisableEmailNotificationsForSiteRecovery $true

		Assert-True { $vault1.Properties.AlertSettings -ne $null }
		Assert-True { $vault1.Properties.AlertSettings.AzureMonitorAlertsForAllFailoverIssues -eq "Enabled" }
		Assert-True { $vault1.Properties.AlertSettings.EmailNotificationsForSiteRecovery -eq "Disabled" }
		
		$vault2 = Update-AzRecoveryServicesVault -Name $vaultName2 -ResourceGroupName $resourceGroupName `
			-DisableAzureMonitorAlertsForAllFailoverIssue $true `
			-DisableEmailNotificationsForSiteRecovery $false

		Assert-True { $vault2.Properties.AlertSettings -ne $null }
		Assert-True { $vault2.Properties.AlertSettings.AzureMonitorAlertsForAllFailoverIssues -eq "Disabled" }
		Assert-True { $vault2.Properties.AlertSettings.EmailNotificationsForSiteRecovery -eq "Enabled" }

	}
	finally
	{
		# Cleanup
		Remove-AzRecoveryServicesVault -Vault $vault1
		Remove-AzRecoveryServicesVault -Vault $vault2
	}
}
