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

function Test-AzureFileItem
{
	$location = "southeastasia"
	$resourceGroupName = "sam-rg-sea-can"
	$vaultName = "sam-rv-sea-can"

	try
	{
		$vault = Get-AzureRmRecoveryServicesVault -ResourceGroupName $resourceGroupName -Name $vaultName
		
	}
	finally
	{
		# Cleanup
	}
}

function Test-AzureFileShareBackup
{
	$location = "westus"
	$resourceGroupName = "sisi-RSV"

	try
	{
		# Setup
		$vault = Get-AzureRmRecoveryServicesVault -ResourceGroupName 'sisi-RSV' -Name 'sisi-RSV-29-6'
		Get-AzureRmRecoveryServicesVault -ResourceGroupName 'sisi-RSV' -Name 'sisi-RSV-29-6' | Set-AzureRmRecoveryServicesVaultContext
		$FSContainer = Get-AzureRmRecoveryServicesBackupContainer -ContainerType “AzureStorage” -FriendlyName "sisisa"
		$FSItem = Get-AzureRmRecoveryServicesBackupItem -Container $FSContainer[14] -WorkloadType “AzureFiles” -Name "test2"
		
		# Trigger backup and wait for completion
		$backupJob = Backup-AzureRmRecoveryServicesBackupItem `
			-VaultId $vault.ID `
			-Item $FSItem[0] | Wait-AzureRmRecoveryServicesBackupJob -VaultId $vault.ID

		Assert-True { $backupJob.Status -eq "Completed" }
	}
	finally
	{
		# Cleanup
	}
}