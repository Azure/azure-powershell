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
	$location = Get-ResourceGroupLocation
	$resourceGroupName = "sisi-RSV"
	$name = 'sisisa'

	try
	{
		# Setup
		#$sa = Create-SA $resourceGroupName $location
		$sa = Get-AzureRmStorageAccount -ResourceGroupName $resourceGroupName -Name $name
		$fileshare = Create-FileShare $sa
		
		$vault = Get-AzureRmRecoveryServicesVault -ResourceGroupName 'sisi-RSV' -Name 'sisi-RSV-29-6'
		Get-AzureRmRecoveryServicesVault -ResourceGroupName 'sisi-RSV' -Name 'sisi-RSV-29-6' | Set-AzureRmRecoveryServicesVaultContext
		
		$item = Enable-Protection $vault $fileShare $sa.StorageAccountName
		#$FSContainer = Get-AzureRmRecoveryServicesBackupContainer -ContainerType “AzureStorage” -FriendlyName $saName
		#$FSItem = Get-AzureRmRecoveryServicesBackupItem -Container $FSContainer[0] -WorkloadType “AzureFiles” -Name $fileshare.Name
		
		# Trigger backup and wait for completion
		$backupJob = Backup-AzureRmRecoveryServicesBackupItem `
			-VaultId $vault.ID `
			-Item $FSItem[0]
	}
	finally
	{
		# Cleanup
	}
}

function Test-AzureFileProtection
{
	$location = "westus"
	$resourceGroupName = "sisi-RSV"

	try
	{
	    $vault = Get-AzureRmRecoveryServicesVault -ResourceGroupName 'sisi-RSV' -Name 'sisi-RSV-29-6'
		
		$policyName = "AFSBackupPolicy";
		$policy = Get-AzureRmRecoveryServicesBackupProtectionPolicy `
			-VaultId $vault.ID `
			-WorkloadType "AzureFiles"
		$enableJob = Enable-AzureRmRecoveryServicesBackupProtection `
			-VaultId $vault.ID `
			-Policy $Policy `
			-Name "igniteshare7" `
			-StorageAccountName "sisisa"

		$container = Get-AzureRmRecoveryServicesBackupContainer `
			-VaultId $vault.ID `
			-ContainerType AzureStorage `
			-Status Registered `
			-FriendlyName "sisisa";

		$item = Get-AzureRmRecoveryServicesBackupItem `
			-VaultId $vault.ID `
			-Container $container[16] `
			-WorkloadType AzureFiles `
			-Name "igniteshare7"

		# Disable protection
		Disable-AzureRmRecoveryServicesBackupProtection `
			-VaultId $vault.ID `
			-Item $item `
			-Force;
	}
	finally
	{
		# Cleanup
	}
}

function Test-AzureFileShareGetRPs
{
	$location = "westus"
	$resourceGroupName = "sisi-RSV"

	try
	{
		# Test 1: Get latest recovery point; should be only one

		$vault = Get-AzureRmRecoveryServicesVault -ResourceGroupName $resourceGroupName -Name "sisi-RSV-29-6"
		$container = Get-AzureRmRecoveryServicesBackupContainer `
			-VaultId $vault.ID `
			-ContainerType AzureStorage `
			-Status Registered `
			-FriendlyName "sisisa";
 		$item = Get-AzureRmRecoveryServicesBackupItem `
			-VaultId $vault.ID `
			-Container $container[16] `
			-WorkloadType AzureFiles `
			-Name "sharetest"
		$recoveryPoint = Get-AzureRmRecoveryServicesBackupRecoveryPoint `
			-VaultId $vault.ID `
			-Item $item;
	
		Assert-NotNull $recoveryPoint[0];
		Assert-True { $recoveryPoint[0].Id -match $item.Id };

		# Test 2: Get Recovery point detail
		$recoveryPointDetail = Get-AzureRmRecoveryServicesBackupRecoveryPoint `
			-VaultId $vault.ID `
			-RecoveryPointId $recoveryPoint[0].RecoveryPointId `
			-Item $item;
	
		Assert-NotNull $recoveryPointDetail;
	}
	finally
	{
		# Cleanup
	}
}