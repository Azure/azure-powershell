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
	$job = New-AzureRmSiteRecoveryPolicy -Name ppAzure -ReplicationProvider HyperVReplicaAzure -ReplicationFrequencyInSeconds 30 -RecoveryPoints 1 -ApplicationConsistentSnapshotFrequencyInHours 0 -RecoveryAzureStorageAccountId "/subscriptions/aef7cd8f-a06f-407d-b7f0-cc78cfebaab0/resourceGroups/Default-Storage-WestUS/providers/Microsoft.ClassicStorage/storageAccounts/b2astorageversion1"

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
	$pri = Get-AzureRmSiteRecoveryProtectionContainer -FriendlyName B2asite1
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
	$pri = Get-AzureRmSiteRecoveryProtectionContainer -FriendlyName B2asite1
	$pp = Get-AzureRmSiteRecoveryPolicy -Name ppAzure;

	# Dissociate the profile
	$job = Start-AzureRmSiteRecoveryPolicyDissociationJob -Policy $pp -PrimaryProtectionContainer $pri
	# WaitForJobCompletion -JobId $job.Name
}

<#
.SYNOPSIS
Wait for job completion
Usage:
	WaitForJobCompletion -JobId $job.ID
	WaitForJobCompletion -JobId $job.ID -NumOfSecondsToWait 10
#>
function WaitForJobCompletion
{
    param([string] $JobId, [Int] $NumOfSecondsToWait = 120)
	$endStateDescription = @('Succeeded','Failed','Cancelled','Suspended')

	$timeElapse = 0;
	$interval = 5;
	do
	{
		Start-Sleep $interval
		$timeElapse = $timeElapse + $interval
		$job = Get-AzureRmSiteRecoveryJob -Name $JobId;
	} while((-not ($endStateDescription -ccontains $job.State)) -and ($timeElapse -lt $NumOfSecondsToWait))

	Assert-True { $endStateDescription -ccontains $job.State } "Job did not reached desired state within $NumOfSecondsToWait seconds."
}

<#
.SYNOPSIS
Site Recovery Vault CRUD Tests
#>
function Test-SiteRecoveryVaultCRUDTests
{
	# Create vault
	$vaultCreationResponse = New-AzureRmSiteRecoveryVault -Name rsv1 -ResourceGroupName S91-1 -Location westus
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
	$vaultToBeRemoved = Get-AzureRmSiteRecoveryVault -ResourceGroupName S91-1 -Name rsv1
	Assert-NotNull($vaultToBeRemoved.Name)
	Assert-NotNull($vaultToBeRemoved.ID)
	Assert-NotNull($vaultToBeRemoved.Type)

	# Remove Vault
	Remove-AzureRmSiteRecoveryVault -Vault $vaultToBeRemoved
	$vaults = Get-AzureRmSiteRecoveryVault -ResourceGroupName S91-1 -Name rsv1
	Assert-True { $vaults.Count -eq 0 }
}