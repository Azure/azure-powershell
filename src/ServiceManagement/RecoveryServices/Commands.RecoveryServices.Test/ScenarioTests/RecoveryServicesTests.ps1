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

########################## Recovery Services Tests #############################

<#
.SYNOPSIS
Recovery Services Enumeration Tests
#>
function Test-RecoveryServicesEnumerationTests
{
	param([string] $vaultSettingsFilePath)

	# Import Azure Site Recovery Vault Settings
	Import-AzureSiteRecoveryVaultSettingsFile $vaultSettingsFilePath

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

		# Enumerate Protection Entities under each configured Protection Containers
		if ($protectionContainer.ConfigurationStatus -eq "Configured")
		{
			$protectionEntities = Get-AzureSiteRecoveryProtectionEntity -ProtectionContainer $protectionContainer
			Assert-NotNull($protectionEntities)
			foreach($protectionEntity in $protectionEntities)
			{
				Assert-NotNull($protectionEntity.Name)
				Assert-NotNull($protectionEntity.ID)
			}
		}
	}
}

<#
.SYNOPSIS
Recovery Services Protection Tests
#>
function Test-RecoveryServicesProtectionTests
{
	param([string] $vaultSettingsFilePath)

	# Import Azure Site Recovery Vault Settings
	Import-AzureSiteRecoveryVaultSettingsFile $vaultSettingsFilePath

	# Enable protection for an un protected Protection Entity and 
	# Disable protection for a protected Protection Entity
	$protectionContainers = Get-AzureSiteRecoveryProtectionContainer
	Assert-True { $protectionContainers.Count -gt 0 }
	Assert-NotNull($protectionContainers)
	foreach($protectionContainer in $protectionContainers)
	{
		Assert-NotNull($protectionContainer.Name)
		Assert-NotNull($protectionContainer.ID)

		# Enumerate Protection Entities under each configured Protection Containers
		if ($protectionContainer.ConfigurationStatus -eq "Configured")
		{
			$protectionEntities = Get-AzureSiteRecoveryProtectionEntity -ProtectionContainer $protectionContainer
			Assert-NotNull($protectionEntities)
			foreach($protectionEntity in $protectionEntities)
			{
				Assert-NotNull($protectionEntity.Name)
				Assert-NotNull($protectionEntity.ID)
				if ($protectionEntity.Protected)
				{
					Set-AzureSiteRecoveryProtectionEntity -ProtectionEntity $protectionEntity -Protection "Enable" -Force
					Update-AzureSiteRecoveryProtectionEntity -ProtectionEntity $protectionEntity
				}
				else
				{
					Set-AzureSiteRecoveryProtectionEntity -ProtectionEntity $protectionEntity -Protection "Disable" -Force
				}
			}
		}
	}
}

<#
.SYNOPSIS
Recovery Services Storage mapping tests and validation
#>
function Test-StorageMapping
{
	param([string] $vaultSettingsFilePath)

	# Import Azure Site Recovery Vault Settings
	Import-AzureSiteRecoveryVaultSettingsFile $vaultSettingsFilePath

	# Enumerate Servers
	$servers = Get-AzureSiteRecoveryServer
	Assert-True { $servers.Count -gt 0 }
	Assert-NotNull($servers)
	foreach($server in $servers)
	{
		Assert-NotNull($server.Name)
		Assert-NotNull($server.ID)
	}

	# Enumerate Storages
	$storages = Get-AzureSiteRecoveryStorage -Server $servers[0]
	Assert-NotNull($storages)
	Assert-True { $storages.Count -gt 0 }
	foreach($storage in $storages)
	{
		Assert-NotNull($storage.Name)
		Assert-NotNull($storage.ID)
	}

	# Enumerate StorageMappings
	$storageMappings = Get-AzureSiteRecoveryStorageMapping -PrimaryServer $servers[0] -RecoveryServer $servers[0]
	Assert-True { $storageMappings.Count -eq 0 }

	# Create StorageMapping
	$job = New-AzureSiteRecoveryStorageMapping -PrimaryStorage $storages[0] -RecoveryStorage $storages[1]
	WaitForJobCompletion -JobId $job.ID

	# Enumerate StorageMappings
	$storageMappings = Get-AzureSiteRecoveryStorageMapping -PrimaryServer $servers[0] -RecoveryServer $servers[0]
	Assert-NotNull($storageMappings)
	Assert-True { $storageMappings.Count -eq 1 }
	Assert-NotNull($storageMappings[0].PrimaryServerId)
	Assert-NotNull($storageMappings[0].PrimaryStorageId)
	Assert-NotNull($storageMappings[0].RecoveryServerId)
	Assert-NotNull($storageMappings[0].RecoveryStorageId)
}

<#
.SYNOPSIS
Recovery Services Storage unmapping tests and validation
#>
function Test-StorageUnMapping
{
	param([string] $vaultSettingsFilePath)

	# Import Azure Site Recovery Vault Settings
	Import-AzureSiteRecoveryVaultSettingsFile $vaultSettingsFilePath

	# Enumerate Servers
	$servers = Get-AzureSiteRecoveryServer
	Assert-True { $servers.Count -gt 0 }
	Assert-NotNull($servers)
	foreach($server in $servers)
	{
		Assert-NotNull($server.Name)
		Assert-NotNull($server.ID)
	}

	# Enumerate StorageMappings
	$storageMappings = Get-AzureSiteRecoveryStorageMapping -PrimaryServer $servers[0] -RecoveryServer $servers[0]
	Assert-NotNull($storageMappings)
	Assert-True { $storageMappings.Count -eq 1 }
	Assert-NotNull($storageMappings[0].PrimaryServerId)
	Assert-NotNull($storageMappings[0].PrimaryStorageId)
	Assert-NotNull($storageMappings[0].RecoveryServerId)
	Assert-NotNull($storageMappings[0].RecoveryStorageId)

	# Remove StorageMapping
	$job = Remove-AzureSiteRecoveryStorageMapping -StorageMapping $storageMappings[0]
	WaitForJobCompletion -JobId $job.ID

	# Enumerate StorageMappings
	$storageMappings = Get-AzureSiteRecoveryStorageMapping -PrimaryServer $servers[0] -RecoveryServer $servers[0]
	Assert-True { $storageMappings.Count -eq 0 }
}

<#
.SYNOPSIS
Recovery Services Network mapping tests and validation
#>
function Test-NetworkMapping
{
	param([string] $vaultSettingsFilePath)

	# Import Azure Site Recovery Vault Settings
	Import-AzureSiteRecoveryVaultSettingsFile $vaultSettingsFilePath

	# Enumerate Servers
	$servers = Get-AzureSiteRecoveryServer
	Assert-True { $servers.Count -gt 0 }
	Assert-NotNull($servers)
	foreach($server in $servers)
	{
		Assert-NotNull($server.Name)
		Assert-NotNull($server.ID)
	}

	# Enumerate Networks
	$networks = Get-AzureSiteRecoveryNetwork -Server $servers[0]
	Assert-NotNull($networks)
	Assert-True { $networks.Count -gt 0 }
	foreach($network in $networks)
	{
		Assert-NotNull($network.Name)
		Assert-NotNull($network.ID)
	}

	# Enumerate NetworkMappings
	$networkMappings = Get-AzureSiteRecoveryNetworkMapping -PrimaryServer $servers[0] -RecoveryServer $servers[0]
	Assert-True { $networkMappings.Count -eq 0 }

	# Create NetworkMapping
	$job = New-AzureSiteRecoveryNetworkMapping -PrimaryNetwork $networks[0] -RecoveryNetwork $networks[1]
	WaitForJobCompletion -JobId $job.ID

	# Enumerate NetworkMappings
	$networkMappings = Get-AzureSiteRecoveryNetworkMapping -PrimaryServer $servers[0] -RecoveryServer $servers[0]
	Assert-NotNull($networkMappings)
	Assert-True { $networkMappings.Count -eq 1 }
	Assert-NotNull($networkMappings[0].PrimaryServerId)
	Assert-NotNull($networkMappings[0].PrimaryNetworkId)
	Assert-NotNull($networkMappings[0].PrimaryNetworkName)
	Assert-NotNull($networkMappings[0].RecoveryServerId)
	Assert-NotNull($networkMappings[0].RecoveryNetworkId)
	Assert-NotNull($networkMappings[0].RecoveryNetworkName)
}

<#
.SYNOPSIS
Recovery Services Network unmapping tests and validation
#>
function Test-NetworkUnMapping
{
	param([string] $vaultSettingsFilePath)

	# Import Azure Site Recovery Vault Settings
	Import-AzureSiteRecoveryVaultSettingsFile $vaultSettingsFilePath

	# Enumerate Servers
	$servers = Get-AzureSiteRecoveryServer
	Assert-True { $servers.Count -gt 0 }
	Assert-NotNull($servers)
	foreach($server in $servers)
	{
		Assert-NotNull($server.Name)
		Assert-NotNull($server.ID)
	}

	# Enumerate NetworkMappings
	$networkMappings = Get-AzureSiteRecoveryNetworkMapping -PrimaryServer $servers[0] -RecoveryServer $servers[0]
	Assert-NotNull($networkMappings)
	Assert-True { $networkMappings.Count -eq 1 }
	Assert-NotNull($networkMappings[0].PrimaryServerId)
	Assert-NotNull($networkMappings[0].PrimaryNetworkId)
	Assert-NotNull($networkMappings[0].PrimaryNetworkName)
	Assert-NotNull($networkMappings[0].RecoveryServerId)
	Assert-NotNull($networkMappings[0].RecoveryNetworkId)
	Assert-NotNull($networkMappings[0].RecoveryNetworkName)

	# Remove StorageMapping
	$job = Remove-AzureSiteRecoveryNetworkMapping -NetworkMapping $networkMappings[0]
	WaitForJobCompletion -JobId $job.ID

	# Enumerate NetworkMappings
	$networkMappings = Get-AzureSiteRecoveryNetworkMapping -PrimaryServer $servers[0] -RecoveryServer $servers[0]
	Assert-True { $networkMappings.Count -eq 0 }
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
    param([string] $JobId, [Int] $NumOfSecondsToWait = 30)
	$endStateDescription = @('Succeeded','Failed','Cancelled','Suspended')

	$timeElapse = 0;
	$interval = 5;
	do
	{
		Start-Sleep $interval
		$timeElapse = $timeElapse + $interval
		$job = Get-AzureSiteRecoveryJob -Id $JobId;
	} while((-not ($endStateDescription -ccontains $job.State)) -and ($timeElapse -lt $NumOfSecondsToWait))

	Assert-True { $endStateDescription -ccontains $job.State } "Job did not reached desired state within $NumOfSecondsToWait seconds."
}
