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
Recovery Services Vault CRUD Tests
#>
function Test-RecoveryServicesVaultCRUDTests
{
	# Create vault
	$vaultCreationResponse = New-AzureRmRecoveryServicesVault -Name rsv1 -ResourceGroupName RsvTestRG -Location westus
	Assert-NotNull($vaultCreationResponse.Name)
	Assert-NotNull($vaultCreationResponse.ID)
	Assert-NotNull($vaultCreationResponse.Type)

	# Enumerate Vaults
	$vaults = Get-AzureRmRecoveryServicesVault -Name rsv1 -ResourceGroupName RsvTestRG
	Assert-True { $vaults.Count -gt 0 }
	Assert-NotNull($vaults)
	foreach($vault in $vaults)
	{
		Assert-NotNull($vault.Name)
		Assert-NotNull($vault.ID)
		Assert-NotNull($vault.Type)
	}

	$vaultBackupProperties = Get-AzureRmRecoveryServicesBackupProperties -Vault $vaultCreationResponse
	Assert-NotNull($vaultBackupProperties.BackupStorageRedundancy)

	Set-AzureRmRecoveryServicesBackupProperties -Vault $vaultCreationResponse -BackupStorageRedundancy "LocallyRedundant"

	# Get the created vault
	$vaultToBeProcessed = Get-AzureRmRecoveryServicesVault -ResourceGroupName RsvTestRG -Name rsv1
	Assert-NotNull($vaultToBeProcessed.Name)
	Assert-NotNull($vaultToBeProcessed.ID)
	Assert-NotNull($vaultToBeProcessed.Type)

	# Remove Vault
	Remove-AzureRmRecoveryServicesVault -Vault $vaultToBeProcessed
	$vaults = Get-AzureRmRecoveryServicesVault -ResourceGroupName RsvTestRG -Name rsv1
	Assert-True { $vaults.Count -eq 0 }
}