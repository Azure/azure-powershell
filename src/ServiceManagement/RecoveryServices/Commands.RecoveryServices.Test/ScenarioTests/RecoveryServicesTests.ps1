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
				}
				else
				{
					Set-AzureSiteRecoveryProtectionEntity -ProtectionEntity $protectionEntity -Protection "Disable" -Force
				}
			}
		}
	}
}