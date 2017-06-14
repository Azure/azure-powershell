﻿# ----------------------------------------------------------------------------------
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


<#
.SYNOPSIS
Site Recovery Enumeration Tests
#>
function Test-SiteRecoveryEnumerationTests
{
	param([string] $vaultSettingsFilePath)

	# Import Azure Site Recovery Vault Settings
	Import-AzureRmSiteRecoveryVaultSettingsFile $vaultSettingsFilePath

	# Enumerate Vaults
	$vaults = Get-AzureRmSiteRecoveryVault
	Assert-True { $vaults.Count -gt 0 }
	Assert-NotNull($vaults)
	foreach($vault in $vaults)
	{
		Assert-NotNull($vault.Name)
		Assert-NotNull($vault.ID)
	}

	# Enumerate Servers
	$servers = Get-AzureRmSiteRecoveryServer
	Assert-True { $servers.Count -gt 0 }
	Assert-NotNull($servers)
	foreach($server in $servers)
	{
		Assert-NotNull($server.Name)
		Assert-NotNull($server.ID)
	}

	# Enumerate Protection Containers
	$protectionContainers = Get-AzureRmSiteRecoveryProtectionContainer
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
Site Recovery Create profile Test
#>
function Test-SiteRecoveryCreateProfile
{
	param([string] $vaultSettingsFilePath)

	# Import Azure Site Recovery Vault Settings
	Import-AzureRmSiteRecoveryVaultSettingsFile $vaultSettingsFilePath

	# Create profile
	$job = New-AzureRmSiteRecoveryPolicy -Name ppAzure -ReplicationProvider HyperVReplicaAzure -ReplicationFrequencyInSeconds 30 -RecoveryPoints 1 -ApplicationConsistentSnapshotFrequencyInHours 0 -RecoveryAzureStorageAccountId "/subscriptions/aef7cd8f-a06f-407d-b7f0-cc78cfebaab0/resourceGroups/rgn1/providers/Microsoft.Storage/storageAccounts/e2astoragev2"
	# WaitForJobCompletion -JobId $job.Name
}

<#
.SYNOPSIS
Site Recovery Delete profile Test
#>
function Test-SiteRecoveryDeleteProfile
{
	param([string] $vaultSettingsFilePath)

	# Import Azure Site Recovery Vault Settings
	Import-AzureRmSiteRecoveryVaultSettingsFile $vaultSettingsFilePath

	# Get a profile created in previous test (with name pp)
	$profiles = Get-AzureRmSiteRecoveryPolicy -FriendlyName ppAzure
	Assert-True { $profiles.Count -gt 0 }
	Assert-NotNull($profiles)

	# Delete the profile
	$job = Remove-AzureRmSiteRecoveryPolicy -Policy $profiles[0]
	# WaitForJobCompletion -JobId $job.Name
}

<#
.SYNOPSIS
Site Recovery Associate profile Test
#>
function Test-SiteRecoveryAssociateProfile
{
	param([string] $vaultSettingsFilePath)

	# Import Azure Site Recovery Vault Settings
	Import-AzureRmSiteRecoveryVaultSettingsFile $vaultSettingsFilePath

	# Get the primary cloud, recovery cloud, and protection profile
	$pri = Get-AzureRmSiteRecoveryProtectionContainer -FriendlyName Cloud_0_15b7884b_30016OE62978
	$pp = Get-AzureRmSiteRecoveryPolicy -Name ppAzure;

	# Associate the profile
	# $job = Start-AzureRmSiteRecoveryPolicyAssociationJob -Policy $pp -PrimaryProtectionContainer $pri
	# WaitForJobCompletion -JobId $job.Name
}


<#
.SYNOPSIS
Site Recovery Dissociate profile Test
#>
function Test-SiteRecoveryDissociateProfile
{
	param([string] $vaultSettingsFilePath)

	# Import Azure Site Recovery Vault Settings
	Import-AzureRmSiteRecoveryVaultSettingsFile $vaultSettingsFilePath

	# Get the primary cloud, recovery cloud, and protection profile
	$pri = Get-AzureRmSiteRecoveryProtectionContainer -FriendlyName Cloud_0_15b7884b_30016OE62978
	$pp = Get-AzureRmSiteRecoveryPolicy -Name ppAzure;

	# Dissociate the profile
	$job = Start-AzureRmSiteRecoveryPolicyDissociationJob -Policy $pp -PrimaryProtectionContainer $pri
	# WaitForJobCompletion -JobId $job.Name
}

<#
.SYNOPSIS
Site Recovery Enable protection Test
#>
function Test-SiteRecoveryEnableDR
{
	param([string] $vaultSettingsFilePath)

	# Import Azure Site Recovery Vault Settings
	Import-AzureRmSiteRecoveryVaultSettingsFile $vaultSettingsFilePath

	# Get the primary cloud, recovery cloud, and protection profile
	$pri = Get-AzureRmSiteRecoveryProtectionContainer -FriendlyName Cloud_0_15b7884b_30016OE62978
	$pp = Get-AzureRmSiteRecoveryPolicy -Name ppAzure;

	# EnableDR
	$VM = Get-AzureRMSiteRecoveryProtectionEntity -ProtectionContainer $pri -FriendlyName vm1
	$job = Set-AzureRMSiteRecoveryProtectionEntity -ProtectionEntity $VM -Protection Enable -Force -Policy $pp -RecoveryAzureStorageAccountId "/subscriptions/aef7cd8f-a06f-407d-b7f0-cc78cfebaab0/resourceGroups/rgn1/providers/Microsoft.Storage/storageAccounts/e2astoragev2"
	# WaitForJobCompletion -JobId $job.Name
	# WaitForIRCompletion -VM $VM 
}

<#
.SYNOPSIS
Site Recovery Disable protection Test
#>
function Test-SiteRecoveryDisableDR
{
	param([string] $vaultSettingsFilePath)

	# Import Azure Site Recovery Vault Settings
	Import-AzureRmSiteRecoveryVaultSettingsFile $vaultSettingsFilePath

	# Get the primary cloud, recovery cloud, and protection profile
	$pri = Get-AzureRmSiteRecoveryProtectionContainer -FriendlyName Cloud_0_15b7884b_30016OE62978

	# DisableDR
	$VM = Get-AzureRMSiteRecoveryProtectionEntity -ProtectionContainer $pri -FriendlyName vm1
	$job = Set-AzureRMSiteRecoveryProtectionEntity -ProtectionEntity $VM -Protection Disable -Force
}

<#
.SYNOPSIS
Site Recovery Create Recovery Plan Test
#>
function Test-SiteRecoveryCreateRecoveryPlan
{
	param([string] $vaultSettingsFilePath)

	# Import Azure Site Recovery Vault Settings
	Import-AzureRmSiteRecoveryVaultSettingsFile $vaultSettingsFilePath

	# Get the primary cloud, recovery cloud, and protection profile
	$pri = Get-AzureRmSiteRecoveryProtectionContainer -FriendlyName Cloud_0_15b7884b_30016OE62978	
	$PrimaryServer = Get-AzureRMSiteRecoveryServer -FriendlyName sriramvu-test.ntdev.corp.microsoft.com
	$VM = Get-AzureRMSiteRecoveryProtectionEntity -ProtectionContainer $pri -FriendlyName vm1

	$job = New-AzureRmSiteRecoveryRecoveryPlan -Name rp -PrimaryServer $PrimaryServer -Azure -FailoverDeploymentModel ResourceManager -ProtectionEntityList $VM
	# WaitForJobCompletion -JobId $job.Name
}

<#
.SYNOPSIS
Site Recovery Enumerate Recovery Plan Test
#>
function Test-SiteRecoveryEnumerateRecoveryPlan
{
	param([string] $vaultSettingsFilePath)

	# Import Azure Site Recovery Vault Settings
	Import-AzureRmSiteRecoveryVaultSettingsFile $vaultSettingsFilePath

	$RP = Get-AzureRmSiteRecoveryRecoveryPlan -Name rp
	Assert-NotNull($RP)
	Assert-True { $RP.Count -gt 0 }
}

<#
.SYNOPSIS
Site Recovery Remove Recovery Plan Test
#>
function Test-SiteRecoveryRemoveRecoveryPlan
{
	param([string] $vaultSettingsFilePath)

	# Import Azure Site Recovery Vault Settings
	Import-AzureRmSiteRecoveryVaultSettingsFile $vaultSettingsFilePath

	$RP = Get-AzureRmSiteRecoveryRecoveryPlan -Name rp
	$job = Remove-AzureRmSiteRecoveryRecoveryPlan -RecoveryPlan $RP
}

<#
.SYNOPSIS
Wait for job completion
Usage:
	WaitForJobCompletion -JobId $job.ID
	WaitForJobCompletion -JobId $job.ID -NumOfSecondsToWait 10
#>
<#
function WaitForJobCompletion
{
    param([string] $JobId, [Int] $NumOfSecondsToWait = 120)
	$endStateDescription = @('Succeeded','Failed','Cancelled','Suspended')

	$timeElapse = 0;
	$interval = 5;
	do
	{
		Wait-Seconds $interval
		$timeElapse = $timeElapse + $interval
		$job = Get-AzureRmSiteRecoveryJob -Name $JobId;
	} while((-not ($endStateDescription -ccontains $job.State)) -and ($timeElapse -lt $NumOfSecondsToWait))

	Assert-True { $endStateDescription -ccontains $job.State } "Job did not reached desired state within $NumOfSecondsToWait seconds."
}
#>

function WaitForJobCompletion
{ 
	param(
        [string] $JobId,
        [int] $JobQueryWaitTimeInSeconds = 60,
        [string] $Message = "NA"
        )
        $isJobLeftForProcessing = $true;
        do
        {
            $Job = Get-AzureRMSiteRecoveryJob -Name $JobId
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
		        Start-Sleep -Seconds $JobQueryWaitTimeInSeconds
	        }
        }While($isJobLeftForProcessing)
}

function WaitForIRCompletion
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
            $IRjobs = Get-AzureRMSiteRecoveryJob -TargetObjectId $VM.Name | Sort-Object StartTime -Descending | select -First 5 | Where-Object{$_.JobType -eq "IrCompletion"}
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
		        Start-Sleep -Seconds $JobQueryWaitTimeInSeconds
	        }
        }While($isProcessingLeft)

        Write-Host $("Finalize IR jobs:") -ForegroundColor Green
        $IRjobs
        WaitForJobCompletion -JobId $IRjobs[0].Name -JobQueryWaitTimeInSeconds $JobQueryWaitTimeInSeconds -Message $("Finalize IR in Progress...")
}
<#
.SYNOPSIS
Site Recovery Vault CRUD Tests
#>
function Test-SiteRecoveryVaultCRUDTests
{
	# Create vault
	$vaultCreationResponse = New-AzureRmSiteRecoveryVault -Name v2 -ResourceGroupName rg1 -Location westus
	Assert-NotNull($vaultCreationResponse.Name)
	Assert-NotNull($vaultCreationResponse.ID)
	Assert-NotNull($vaultCreationResponse.Type)

	# Enumerate Vaults
	$vaults = Get-AzureRmSiteRecoveryVault
	Assert-True { $vaults.Count -gt 0 }
	Assert-NotNull($vaults)
	foreach($vault in $vaults)
	{
		Assert-NotNull($vault.Name)
		Assert-NotNull($vault.ID)
		Assert-NotNull($vault.Type)
	}

	# Get the created vault
	$vaultToBeRemoved = Get-AzureRmSiteRecoveryVault -ResourceGroupName rg1 -Name v2
	Assert-NotNull($vaultToBeRemoved.Name)
	Assert-NotNull($vaultToBeRemoved.ID)
	Assert-NotNull($vaultToBeRemoved.Type)

	# Remove Vault
	Remove-AzureRmSiteRecoveryVault -Vault $vaultToBeRemoved
	$vaults = Get-AzureRmSiteRecoveryVault -ResourceGroupName rg1 -Name v2
	Assert-True { $vaults.Count -eq 0 }
}


<#
.SYNOPSIS
Site Recovery Fabric Tests New model
#>
function Test-SiteRecoveryFabricTest
{
	# Enumerate vaults and set Azure Site Recovery Vault Settings
	$vault = Get-AzureRmSiteRecoveryVault -ResourceGroupName ReleaseResourceGroup -Name ReleaseVault
	Assert-NotNull($vault)
	Assert-True { $vault.Count -gt 0 }
	Assert-NotNull($vault.Name)
	Assert-NotNull($vault.ID)
	Set-AzureRmSiteRecoveryVaultSettings -ASRVault $vault

	# Create Fabric
	$job = New-AzureRmSiteRecoveryFabric -Name ReleaseFabric -Type HyperVSite
	Assert-NotNull($job)

	# Enumerate Fabrics
	$fabrics =  Get-AzureRmSiteRecoveryFabric 
	Assert-True { $fabrics.Count -gt 0 }
	Assert-NotNull($fabrics)
	foreach($fabric in $fabrics)
	{
		Assert-NotNull($fabrics.Name)
		Assert-NotNull($fabrics.ID)
	}

	# Enumerate specific Fabric
	$fabric =  Get-AzureRmSiteRecoveryFabric -Name ReleaseFabric
	Assert-NotNull($fabric)
	Assert-NotNull($fabrics.Name)
	Assert-NotNull($fabrics.ID)

	# Remove specific fabric
	$job = Remove-AzureRmSiteRecoveryFabric -Fabric $fabric
	Assert-NotNull($job)
	WaitForJobCompletion -JobId $job.Name
	$fabric =  Get-AzureRmSiteRecoveryFabric | Where-Object {$_.Name -eq "ReleaseFabric"}
	Assert-Null($fabric)
}


<#
.SYNOPSIS
Site Recovery New model End to End
#>
function Test-SiteRecoveryNewModelE2ETest
{
	$JobQueryWaitTimeInSeconds = 30

	# Enumerate vaults and set Azure Site Recovery Vault Settings
	$vault = Get-AzureRmSiteRecoveryVault -ResourceGroupName ReleaseResourceGroup -Name ReleaseVault
	Assert-NotNull($vault)
	Assert-True { $vault.Count -eq 1 }
	Assert-NotNull($vault.Name)
	Assert-NotNull($vault.ID)
	Set-AzureRmSiteRecoveryVaultSettings -ASRVault $vault

	# Enumerate Fabrics
	$fabrics =  Get-AzureRmSiteRecoveryFabric 
	Assert-True { $fabrics.Count -gt 0 }
	Assert-NotNull($fabrics)
	foreach($fabric in $fabrics)
	{
		Assert-NotNull($fabrics.Name)
		Assert-NotNull($fabrics.ID)
	}

	# Enumerate RSPs
	$rsps = Get-AzureRmSiteRecoveryFabric | Get-AzureRmSiteRecoveryServicesProvider
	Assert-True { $rsps.Count -gt 0 }
	Assert-NotNull($rsps)
	foreach($rsp in $rsps)
	{
		Assert-NotNull($rsp.Name)
	}

	$StorageAccountID = "/subscriptions/19b823e2-d1f3-4805-93d7-401c5d8230d5/resourceGroups/releaseresourcegroup/providers/Microsoft.Storage/storageAccounts/releasestorageav" 

	# Create Policy
	$currentJob = New-AzureRmSiteRecoveryPolicy -Name "PP1" -ReplicationProvider HyperVReplicaAzure -ReplicationFrequencyInSeconds 30 -RecoveryPoints 1 -ApplicationConsistentSnapshotFrequencyInHours 0 -Encryption Disable -RecoveryAzureStorageAccountId $StorageAccountID 
    $ProtectionProfile = Get-AzureRMSiteRecoveryPolicy -Name "PP1"
	Assert-NotNull($ProtectionProfile)
	Assert-NotNull($ProtectionProfile.Name)

	# Get conatiners
	$ProtectionContainers = Get-AzureRmSiteRecoveryFabric | Get-AzureRmSiteRecoveryProtectionContainer
	$PrimaryContainer = $ProtectionContainers | where { $_.FriendlyName -eq "hark-123" }
	Assert-NotNull($PrimaryContainer)
	Assert-NotNull($PrimaryContainer.Name)

	# Create new Conatiner mapping 
	$currentJob = New-AzureRmSiteRecoveryProtectionContainerMapping -Name $("hark123" + "PP1") -Policy $ProtectionProfile -PrimaryProtectionContainer $PrimaryContainer

	# Get container mapping
	$ProtectionContainerMapping = Get-AzureRmSiteRecoveryProtectionContainerMapping -Name $("hark123" + "PP1") -ProtectionContainer $PrimaryContainer
	Assert-NotNull($ProtectionContainerMapping)
	Assert-NotNull($ProtectionContainerMapping.Name)

	# Get protectable item
	$protectable = Get-AzureRmSiteRecoveryProtectableItem -ProtectionContainer $PrimaryContainer -FriendlyName "vm3"
	Assert-NotNull($protectable)
	Assert-NotNull($protectable.Name)

	# New replication protected item
	$currentJob = New-AzureRmSiteRecoveryReplicationProtectedItem -ProtectableItem $protectable -Name $protectable.Name -ProtectionContainerMapping $ProtectionContainerMapping -RecoveryAzureStorageAccountId $StorageAccountID
	Assert-NotNull($currentJob)

	# Get replication protected item
	$protected = Get-AzureRmSiteRecoveryReplicationProtectedItem -ProtectionContainer $PrimaryContainer -Name $protectable.Name
	Assert-NotNull($protected)
	Assert-NotNull($protected.Name)

	# Remove protected item
	$currentJob = Remove-AzureRmSiteRecoveryReplicationProtectedItem -ReplicationProtectedItem $protected -Force -Confirm:$false
	$protected = Get-AzureRmSiteRecoveryReplicationProtectedItem -ProtectionContainer $PrimaryContainer | Where-Object {$_.Name -eq $protectable.Name} 
	Assert-Null($protected)

	# Remove conatiner mapping
	$currentJob = Remove-AzureRmSiteRecoveryProtectionContainerMapping -ProtectionContainerMapping $ProtectionContainerMapping
	$ProtectionContainerMapping = Get-AzureRmSiteRecoveryProtectionContainerMapping -ProtectionContainer $PrimaryContainer | Where-Object {$_.Name -eq $("hark123" + "PP1")}
	Assert-Null($ProtectionContainerMapping)

	# Remove Policy
	$currentJob = Remove-AzureRMSiteRecoveryPolicy -Policy $ProtectionProfile
	$ProtectionProfile = Get-AzureRMSiteRecoveryPolicy | Where-Object {$_.Name -eq "PP1"}
	Assert-Null($ProtectionProfile)
}
