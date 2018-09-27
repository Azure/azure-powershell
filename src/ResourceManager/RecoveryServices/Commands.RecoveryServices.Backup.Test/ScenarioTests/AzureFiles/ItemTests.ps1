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

#Setup Instructions:
#1. Create a resource group
#2. Create a storage account and a recovery services vault
#3. Create a file share in the storage account
#4. Fill the below global variables accordingly

$location = "westus"
$resourceGroupName = "sisi-RSV"
$vaultName = "sisi-RSV-29-6"
$fileShareName = "pstestfileshare"
$fileShareFullName = "AzureFileShare;pstestfileshare"
$saName = "pstestsaa"

function Test-AzureFileItem
{
	$vault = Get-AzureRmRecoveryServicesVault -ResourceGroupName $resourceGroupName -Name $vaultName
	Enable-Protection $vault $fileShareName $saName

	$policy = Get-AzureRmRecoveryServicesBackupProtectionPolicy `
		-VaultId $vault.ID `
		-Name "AFSBackupPolicy"

	$container = Get-AzureRmRecoveryServicesBackupContainer `
		-VaultId $vault.ID `
		-ContainerType AzureStorage `
		-Status Registered `
		-Name $saName
		
	# VARIATION-1: Get all items for container
	$items = Get-AzureRmRecoveryServicesBackupItem `
		-VaultId $vault.ID `
		-Container $container `
		-WorkloadType AzureFiles;
	Assert-True { $items.Name -contains $fileShareFullName }

	# VARIATION-2: Get items for container with ProtectionStatus filter
	$items = Get-AzureRmRecoveryServicesBackupItem `
		-VaultId $vault.ID `
		-Container $container `
		-WorkloadType AzureFiles `
		-ProtectionStatus Healthy;
	Assert-True { $items.Name -contains $fileShareFullName }

	# VARIATION-3: Get items for container with Status filter
	$items = Get-AzureRmRecoveryServicesBackupItem `
		-VaultId $vault.ID `
		-Container $container `
		-WorkloadType AzureFiles `
		-ProtectionState IRPending;
	Assert-True { $items.Name -contains $fileShareFullName }

	# VARIATION-4: Get items for container with friendly name and ProtectionStatus filters
	$items = Get-AzureRmRecoveryServicesBackupItem `
		-VaultId $vault.ID `
		-Container $container `
		-WorkloadType AzureFiles `
		-Name $fileShareName `
		-ProtectionStatus Healthy;
	Assert-True { $items.Name -contains $fileShareFullName }

	# VARIATION-5: Get items for container with friendly name and Status filters
	$items = Get-AzureRmRecoveryServicesBackupItem `
		-VaultId $vault.ID `
		-Container $container `
		-WorkloadType AzureFiles `
		-Name $fileShareName `
		-ProtectionState IRPending;
	Assert-True { $items.Name -contains $fileShareFullName }

	# VARIATION-6: Get items for container with Status and ProtectionStatus filters
	$items = Get-AzureRmRecoveryServicesBackupItem `
		-VaultId $vault.ID `
		-Container $container `
		-WorkloadType AzureFiles `
		-ProtectionState IRPending `
		-ProtectionStatus Healthy;
	Assert-True { $items.Name -contains $fileShareFullName }

	# VARIATION-7: Get items for Vault Id and Policy
	$items = Get-AzureRmRecoveryServicesBackupItem `
		-VaultId $vault.ID `
		-Policy $policy;
	Assert-True { $items.Name -contains $fileShareFullName }

	# VARIATION-8: Get items for container with friendly name, Status and ProtectionStatus filters
	$items = Get-AzureRmRecoveryServicesBackupItem `
		-VaultId $vault.ID `
		-Container $container `
		-WorkloadType AzureFiles `
		-Name $fileShareName `
		-ProtectionState IRPending `
		-ProtectionStatus Healthy;
	Assert-True { $items.Name -contains $fileShareFullName }

	# Disable protection
	Disable-AzureRmRecoveryServicesBackupProtection `
		-VaultId $vault.ID `
		-Item $items `
		-RemoveRecoveryPoints `
		-Force;
	Unregister-AzureRmRecoveryServicesBackupContainer `
	-VaultId $vault.ID `
	-Container $container
}

function Test-AzureFileShareBackup
{
	$vault = Get-AzureRmRecoveryServicesVault -ResourceGroupName $resourceGroupName -Name $vaultName
	$item = Enable-Protection $vault $fileShareName $saName
	$container = Get-AzureRmRecoveryServicesBackupContainer `
		-VaultId $vault.ID `
		-ContainerType AzureStorage `
		-Status Registered `
		-Name $saName

	# Trigger backup and wait for completion
	$backupJob = Backup-AzureRmRecoveryServicesBackupItem `
		-VaultId $vault.ID `
		-Item $item | Wait-AzureRmRecoveryServicesBackupJob -VaultId $vault.ID

	Assert-True { $backupJob.Status -eq "Completed" }

	# Disable protection
	Disable-AzureRmRecoveryServicesBackupProtection `
		-VaultId $vault.ID `
		-Item $item `
		-RemoveRecoveryPoints `
		-Force;
	Unregister-AzureRmRecoveryServicesBackupContainer `
	-VaultId $vault.ID `
	-Container $container
}

function Test-AzureFileProtection
{
	$vault = Get-AzureRmRecoveryServicesVault -ResourceGroupName $resourceGroupName -Name $vaultName
		
	$policyName = "AFSBackupPolicy";
	$policy = Get-AzureRmRecoveryServicesBackupProtectionPolicy `
		-VaultId $vault.ID `
		-WorkloadType AzureFiles

	$enableJob = Enable-AzureRmRecoveryServicesBackupProtection `
		-VaultId $vault.ID `
		-Policy $Policy `
		-Name $fileShareName `
		-StorageAccountName $saName

	$container = Get-AzureRmRecoveryServicesBackupContainer `
		-VaultId $vault.ID `
		-ContainerType AzureStorage `
		-Status Registered `
		-FriendlyName $saName

	$item = Get-AzureRmRecoveryServicesBackupItem `
		-VaultId $vault.ID `
		-Container $container `
		-WorkloadType AzureFiles

	# Disable protection
	Disable-AzureRmRecoveryServicesBackupProtection `
		-VaultId $vault.ID `
		-Item $item `
		-RemoveRecoveryPoints `
		-Force;
	Unregister-AzureRmRecoveryServicesBackupContainer `
	-VaultId $vault.ID `
	-Container $container
}

function Test-AzureFileShareGetRPs
{
	# Test 1: Get latest recovery point; should be only one
	$vault = Get-AzureRmRecoveryServicesVault -ResourceGroupName $resourceGroupName -Name $vaultName
	$item = Enable-Protection $vault $fileShareName $saName
	$container = Get-AzureRmRecoveryServicesBackupContainer `
		-VaultId $vault.ID `
		-ContainerType AzureStorage `
		-Status Registered `
		-Name $saName
	$backupJob = Backup-Item $vault $item

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

	# Disable protection
	Disable-AzureRmRecoveryServicesBackupProtection `
		-VaultId $vault.ID `
		-Item $item `
		-RemoveRecoveryPoints `
		-Force;
	Unregister-AzureRmRecoveryServicesBackupContainer `
	-VaultId $vault.ID `
	-Container $container
}