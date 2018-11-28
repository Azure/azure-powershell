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

$location = "southeastasia"
$resourceGroupName = "pstestFSRG1bca8f8e"
$vaultName = "PSTestFSRSV1bca8f8e"
$fileShareFriendlyName = "pstestfs1bca8f8e"
$fileShareName = "AzureFileShare;pstestfs1bca8f8e"
$saName = "pstestsa1bca8f8e"
$saRgName = "pstestFSRG1bca8f8e"
$targetSaName = "pstestsa3rty7d7s"
$targetFileShareName = "pstestfs3rty7d7s"
$targetFolder = "pstestfolder3rty7d7s"
$folderPath = "pstestfolder1bca8f8e"
$filePath = "pstestfolder1bca8f8e/pstestfile1bca8f8e.txt"
$skuName="Standard_LRS"
$policyName = "AFSBackupPolicy"
$newPolicyName = "NewAFSBackupPolicy"

# Setup Instructions:
# 1. Create a resource group
# New-AzureRmResourceGroup -Name $resourceGroupName -Location $location

# 2. Create a storage account and a recovery services vault
# New-AzureRmStorageAccount -ResourceGroupName $resourceGroupName -Name $saName -Location $location -SkuName $skuName
# New-AzureRmRecoveryServicesVault -Name $vaultName -ResourceGroupName $resourceGroupName -Location $Location

# 3. Create a file share in the storage account
# $storageAcct = Get-AzureRmStorageAccount -ResourceGroupName $resourceGroupName -Name $saName
# New-AzureStorageShare -Name $fileShareFriendlyName -Context $storageAcct.Context

# 4. Create a backup policy for file shares
# $vault = Get-AzureRmRecoveryServicesVault -ResourceGroupName $resourceGroupName -Name $vaultName
# $schedulePolicy = Get-AzureRmRecoveryServicesBackupSchedulePolicyObject -WorkloadType AzureFiles
# $retentionPolicy = Get-AzureRmRecoveryServicesBackupRetentionPolicyObject -WorkloadType AzureFiles
# $policy = New-AzureRmRecoveryServicesBackupProtectionPolicy -VaultId $vault.ID `
#		-Name $policyName `
#		-WorkloadType AzureFiles `
#		-RetentionPolicy $retentionPolicy `
#		-SchedulePolicy $schedulePolicy

function Test-AzureFSItem
{
	try
	{
		$vault = Get-AzureRmRecoveryServicesVault -ResourceGroupName $resourceGroupName -Name $vaultName
		Enable-Protection $vault $fileShareFriendlyName $saName

		$policy = Get-AzureRmRecoveryServicesBackupProtectionPolicy `
			-VaultId $vault.ID `
			-Name $policyName

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
		Assert-True { $items.Name -contains $fileShareName }

		# VARIATION-2: Get items for container with ProtectionStatus filter
		$items = Get-AzureRmRecoveryServicesBackupItem `
			-VaultId $vault.ID `
			-Container $container `
			-WorkloadType AzureFiles `
			-ProtectionStatus Healthy;
		Assert-True { $items.Name -contains $fileShareName }

		# VARIATION-3: Get items for container with Status filter
		$items = Get-AzureRmRecoveryServicesBackupItem `
			-VaultId $vault.ID `
			-Container $container `
			-WorkloadType AzureFiles `
			-ProtectionState IRPending;
		Assert-True { $items.Name -contains $fileShareName }

		# VARIATION-4: Get items for container with friendly name and ProtectionStatus filters
		$items = Get-AzureRmRecoveryServicesBackupItem `
			-VaultId $vault.ID `
			-Container $container `
			-WorkloadType AzureFiles `
			-Name $fileShareFriendlyName `
			-ProtectionStatus Healthy;
		Assert-True { $items.Name -contains $fileShareName }

		# VARIATION-5: Get items for container with friendly name and Status filters
		$items = Get-AzureRmRecoveryServicesBackupItem `
			-VaultId $vault.ID `
			-Container $container `
			-WorkloadType AzureFiles `
			-Name $fileShareFriendlyName `
			-ProtectionState IRPending;
		Assert-True { $items.Name -contains $fileShareName }

		# VARIATION-6: Get items for container with Status and ProtectionStatus filters
		$items = Get-AzureRmRecoveryServicesBackupItem `
			-VaultId $vault.ID `
			-Container $container `
			-WorkloadType AzureFiles `
			-ProtectionState IRPending `
			-ProtectionStatus Healthy;
		Assert-True { $items.Name -contains $fileShareName }

		# VARIATION-7: Get items for Vault Id and Policy
		$items = Get-AzureRmRecoveryServicesBackupItem `
			-VaultId $vault.ID `
			-Policy $policy;
		Assert-True { $items.Name -contains $fileShareName }

		# VARIATION-8: Get items for container with friendly name, Status and ProtectionStatus filters
		$items = Get-AzureRmRecoveryServicesBackupItem `
			-VaultId $vault.ID `
			-Container $container `
			-WorkloadType AzureFiles `
			-Name $fileShareFriendlyName `
			-ProtectionState IRPending `
			-ProtectionStatus Healthy;
		Assert-True { $items.Name -contains $fileShareName }
	}
	finally
	{
		Cleanup-Vault $vault $items $container
	}
}

function Test-AzureFSBackup
{
	try
	{
		$vault = Get-AzureRmRecoveryServicesVault -ResourceGroupName $resourceGroupName -Name $vaultName
		$item = Enable-Protection $vault $fileShareFriendlyName $saName
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
	}
	finally
	{
		Cleanup-Vault $vault $item $container
	}
}

function Test-AzureFSProtection
{
	try
	{
		$vault = Get-AzureRmRecoveryServicesVault -ResourceGroupName $resourceGroupName -Name $vaultName
		
		$policy = Get-AzureRmRecoveryServicesBackupProtectionPolicy `
			-VaultId $vault.ID `
			-Name $policyName

		$enableJob = Enable-AzureRmRecoveryServicesBackupProtection `
			-VaultId $vault.ID `
			-Policy $Policy `
			-Name $fileShareFriendlyName `
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
		Assert-True { $item.Name -contains $fileShareName }
		Assert-True { $item.LastBackupStatus -eq "IRPending" }
		Assert-True { $item.ProtectionPolicyName -eq $policyName }
		
		# Modify Policy
		$newPolicy = Get-AzureRmRecoveryServicesBackupProtectionPolicy `
		-VaultId $vault.ID `
		-Name $newPolicyName

		$enableJob =  Enable-AzureRmRecoveryServicesBackupProtection `
			-VaultId $vault.ID `
			-Policy $newPolicy `
			-Item $item
		
		$item = Get-AzureRmRecoveryServicesBackupItem `
		-VaultId $vault.ID `
		-Container $container `
		-WorkloadType AzureFiles

		Assert-True { $item.Name -contains $fileShareName }
		Assert-True { $item.LastBackupStatus -eq "IRPending" }
		Assert-True { $item.ProtectionPolicyName -eq $newPolicyName }
	}
	finally
	{
		Cleanup-Vault $vault $item $container
	}
}

function Test-AzureFSGetRPs
{
	try
	{
		# Test 1: Get latest recovery point; should be only one
		$vault = Get-AzureRmRecoveryServicesVault -ResourceGroupName $resourceGroupName -Name $vaultName
		$item = Enable-Protection $vault $fileShareFriendlyName $saName
		$container = Get-AzureRmRecoveryServicesBackupContainer `
			-VaultId $vault.ID `
			-ContainerType AzureStorage `
			-Status Registered `
			-Name $saName
		$backupJob = Backup-Item $vault $item

		$backupStartTime = $backupJob.StartTime.AddMinutes(-1);
		$backupEndTime = $backupJob.EndTime.AddMinutes(1);

		$recoveryPoint = Get-AzureRmRecoveryServicesBackupRecoveryPoint `
			-VaultId $vault.ID `
			-StartDate $backupStartTime `
			-EndDate $backupEndTime `
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
		Cleanup-Vault $vault $item $container
	}
}

function Test-AzureFSFullRestore
{
	try
	{
		$vault = Get-AzureRmRecoveryServicesVault -ResourceGroupName $resourceGroupName -Name $vaultName
		$item = Enable-Protection $vault $fileShareFriendlyName $saName
		$container = Get-AzureRmRecoveryServicesBackupContainer `
			-VaultId $vault.ID `
			-ContainerType AzureStorage `
			-Status Registered `
			-Name $saName
		$backupJob = Backup-Item $vault $item

		$backupStartTime = $backupJob.StartTime.AddMinutes(-1);
		$backupEndTime = $backupJob.EndTime.AddMinutes(1);

		$recoveryPoint = Get-AzureRmRecoveryServicesBackupRecoveryPoint `
			-VaultId $vault.ID `
			-StartDate $backupStartTime `
			-EndDate $backupEndTime `
			-Item $item;

		Assert-ThrowsContains { Restore-AzureRmRecoveryServicesBackupItem `
			-VaultId $vault.ID `
			-VaultLocation $vault.Location `
			-RecoveryPoint $recoveryPoint[0] `
			-StorageAccountName $saName `
			-StorageAccountResourceGroupName $saRgName `
			-ResolveConflict Overwrite `
			-TargetStorageAccountName $targetSaName `
			-TargetFolder $targetFolder } `
			"Provide TargetFileShareName for Alternate Location restore or remove TargetStorageAccountName for Original Location restore"

		Assert-ThrowsContains { Restore-AzureRmRecoveryServicesBackupItem `
			-VaultId $vault.ID `
			-VaultLocation $vault.Location `
			-RecoveryPoint $recoveryPoint[0] `
			-StorageAccountName $saName `
			-StorageAccountResourceGroupName $saRgName `
			-ResolveConflict Overwrite `
			-TargetFileShareName $targetFileShareName `
			-TargetFolder $targetFolder } `
			"Provide TargetStorageAccountName for Alternate Location restore or remove TargetFileShareName for Original Location restore"

		Assert-ThrowsContains { Restore-AzureRmRecoveryServicesBackupItem `
			-VaultId $vault.ID `
		  	-VaultLocation $vault.Location `
		  	-RecoveryPoint $recoveryPoint[0] `
		  	-StorageAccountName $saName `
		  	-StorageAccountResourceGroupName $saRgName `
		  	-ResolveConflict Overwrite `
		  	-SourceFileType File } `
		  	"Provide SourceFilePath for File restore or remove SourceFileType for file share restore"

		Assert-ThrowsContains { Restore-AzureRmRecoveryServicesBackupItem `
			-VaultId $vault.ID `
			-VaultLocation $vault.Location `
			-RecoveryPoint $recoveryPoint[0] `
			-StorageAccountName $saName `
			-StorageAccountResourceGroupName $saRgName `
			-ResolveConflict Overwrite `
			-SourceFilePath $filePath } `
			"Provide SourceFileType for File restore or remove SourceFilePath for file share restore"

		# Item level restore at alternate location
		$restoreJob1 = Restore-AzureRmRecoveryServicesBackupItem `
			-VaultId $vault.ID `
			-VaultLocation $vault.Location `
			-RecoveryPoint $recoveryPoint[0] `
			-StorageAccountName $saName `
			-StorageAccountResourceGroupName $saRgName `
			-ResolveConflict Overwrite `
			-SourceFilePath $folderPath `
			-SourceFileType Directory `
			-TargetStorageAccountName $targetSaName `
			-TargetFileShareName $targetFileShareName `
			-TargetFolder $targetFolder | `
				Wait-AzureRmRecoveryServicesBackupJob -VaultId $vault.ID
		
		Assert-True { $restoreJob1.Status -eq "Completed" }

		# Full share restore at alternate location		
		$restoreJob2 = Restore-AzureRmRecoveryServicesBackupItem `
			-VaultId $vault.ID `
			-VaultLocation $vault.Location `
			-RecoveryPoint $recoveryPoint[0] `
			-StorageAccountName $saName `
			-StorageAccountResourceGroupName $saRgName `
			-ResolveConflict Overwrite `
			-TargetStorageAccountName $targetSaName `
			-TargetFileShareName $targetFileShareName `
			-TargetFolder $targetFolder | `
				Wait-AzureRmRecoveryServicesBackupJob -VaultId $vault.ID
		
		Assert-True { $restoreJob2.Status -eq "Completed" }

		# Item level restore at original location
		$restoreJob3 = Restore-AzureRmRecoveryServicesBackupItem `
			-VaultId $vault.ID `
			-VaultLocation $vault.Location `
			-RecoveryPoint $recoveryPoint[0] `
			-StorageAccountName $saName `
			-StorageAccountResourceGroupName $saRgName `
			-ResolveConflict Overwrite `
			-SourceFilePath $filePath `
			-SourceFileType File | `
				Wait-AzureRmRecoveryServicesBackupJob -VaultId $vault.ID

		Assert-True { $restoreJob3.Status -eq "Completed" }

		# Full share restore at original location
		$restoreJob4 = Restore-AzureRmRecoveryServicesBackupItem `
			-VaultId $vault.ID `
			-VaultLocation $vault.Location `
			-RecoveryPoint $recoveryPoint[0] `
			-StorageAccountName $saName `
			-StorageAccountResourceGroupName $saRgName `
			-ResolveConflict Overwrite | `
				Wait-AzureRmRecoveryServicesBackupJob -VaultId $vault.ID

		Assert-True { $restoreJob4.Status -eq "Completed" }
    
		# Test without storage account dependancy
		# Item level restore at alternate location
		$restoreJob5 = Restore-AzureRmRecoveryServicesBackupItem `
			-VaultId $vault.ID `
			-VaultLocation $vault.Location `
			-RecoveryPoint $recoveryPoint[0] `
			-ResolveConflict Overwrite `
			-SourceFilePath $folderPath `
			-SourceFileType Directory `
			-TargetStorageAccountName $targetSaName `
			-TargetFileShareName $targetFileShareName `
			-TargetFolder $targetFolder | `
				Wait-AzureRmRecoveryServicesBackupJob -VaultId $vault.ID
		
		Assert-True { $restoreJob5.Status -eq "Completed" }
    
		# Test without storage account dependancy
		# Full share restore at alternate location
		$restoreJob6 = Restore-AzureRmRecoveryServicesBackupItem `
			-VaultId $vault.ID `
			-VaultLocation $vault.Location `
			-RecoveryPoint $recoveryPoint[0] `
			-ResolveConflict Overwrite `
			-TargetStorageAccountName $targetSaName `
			-TargetFileShareName $targetFileShareName `
			-TargetFolder $targetFolder | `
				Wait-AzureRmRecoveryServicesBackupJob -VaultId $vault.ID
		
		Assert-True { $restoreJob6.Status -eq "Completed" }

		# Test without storage account dependancy
		# Item level restore at original location
		$restoreJob7 = Restore-AzureRmRecoveryServicesBackupItem `
			-VaultId $vault.ID `
			-VaultLocation $vault.Location `
			-RecoveryPoint $recoveryPoint[0] `
			-ResolveConflict Overwrite `
			-SourceFilePath $filePath `
			-SourceFileType File | `
				Wait-AzureRmRecoveryServicesBackupJob -VaultId $vault.ID

		Assert-True { $restoreJob7.Status -eq "Completed" }

		# Test without storage account dependancy
		# Full share restore at original location
		$restoreJob8 = Restore-AzureRmRecoveryServicesBackupItem `
			-VaultId $vault.ID `
			-VaultLocation $vault.Location `
			-RecoveryPoint $recoveryPoint[0] `
			-ResolveConflict Overwrite | `
				Wait-AzureRmRecoveryServicesBackupJob -VaultId $vault.ID

		Assert-True { $restoreJob8.Status -eq "Completed" }
	}
	finally
	{
		Cleanup-Vault $vault $item $container
	}
}