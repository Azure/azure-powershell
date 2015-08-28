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
	Import-AzureSiteRecoveryVaultSettingsFile $vaultSettingsFilePath

	# Enumerate Vaults
	$vaults = Get-AzureSiteRecoveryVault
	Assert-True { $vaults.Count -gt 0 }
	Assert-NotNull($vaults)
	foreach($vault in $vaults)
	{
		Assert-NotNull($vault.Name)
		Assert-NotNull($vault.ID)
	}

	# Enumerate Servers
	$servers = Get-AzureSiteRecoveryServer
	Assert-True { $servers.Count -gt 0 }
	Assert-NotNull($servers)
	foreach($server in $servers)
	{
		Assert-NotNull($server.Name)
		Assert-NotNull($server.ID)
	}

	# Enumerate Protection Containers
	$protectionContainers = Get-AzureSiteRecoveryProtectionContainer
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
	Import-AzureSiteRecoveryVaultSettingsFile $vaultSettingsFilePath

	# Create profile
	$job = New-AzureSiteRecoveryProtectionProfile -Name pp -ReplicationProvider HyperVReplica -ReplicationMethod Online -ReplicationFrequencyInSeconds 30 -RecoveryPoints 1 -ApplicationConsistentSnapshotFrequencyInHours 0 -ReplicationPort 8083 -Authentication Kerberos
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
	Import-AzureSiteRecoveryVaultSettingsFile $vaultSettingsFilePath

	# Get a profile created in previous test (with name pp)
	$profiles = Get-AzureSiteRecoveryProtectionProfile -Name pp
	Assert-True { $profiles.Count -gt 0 }
	Assert-NotNull($profiles)

	# Delete the profile
	$job = Remove-AzureSiteRecoveryProtectionProfile -ProtectionProfile $profiles[0]
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
	Import-AzureSiteRecoveryVaultSettingsFile $vaultSettingsFilePath

	# Get the primary cloud, recovery cloud, and protection profile
	$pri = Get-AzureSiteRecoveryProtectionContainer -FriendlyName pri
	$rec = Get-AzureSiteRecoveryProtectionContainer -FriendlyName rec
	$pp = Get-AzureSiteRecoveryProtectionProfile -Name pp;

	# Associate the profile
	$job = Start-AzureSiteRecoveryProtectionProfileAssociationJob -ProtectionProfile $pp -PrimaryProtectionContainer $pri -RecoveryProtectionContainer $rec
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
	Import-AzureSiteRecoveryVaultSettingsFile $vaultSettingsFilePath

	# Get the primary cloud, recovery cloud, and protection profile
	$pri = Get-AzureSiteRecoveryProtectionContainer -FriendlyName pri
	$rec = Get-AzureSiteRecoveryProtectionContainer -FriendlyName rec
	$pp = Get-AzureSiteRecoveryProtectionProfile -Name pp;

	# Dissociate the profile
	$job = Start-AzureSiteRecoveryProtectionProfileDissociationJob -ProtectionProfile $pp -PrimaryProtectionContainer $pri -RecoveryProtectionContainer $rec
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
		$job = Get-AzureSiteRecoveryJob -Name $JobId;
	} while((-not ($endStateDescription -ccontains $job.State)) -and ($timeElapse -lt $NumOfSecondsToWait))

	Assert-True { $endStateDescription -ccontains $job.State } "Job did not reached desired state within $NumOfSecondsToWait seconds."
}