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

$location = "eastasia" #"southeastasia"
$resourceGroupName = "afs-pstest-rg" #"pstestrg8895"
$vaultName = "afs-pstest-vault" # "pstestrsv8895"
$fileShareFriendlyName = "fs1"
$skuName="Standard_LRS"
$saName = "afspstestsa" # "pstestsa8895"
$saRgName = "afs-pstest-rg" # "pstestrg8895"
$fileShareName = "azurefileshare;d10" # "AzureFileShare;fs1"
$targetSaName = "afspstesttargetsa" #"pstesttargetsa8896"
$targetFileShareName = "fs1"
$targetFolder = "pstestfolder3rty7d7s"
$folderPath = "pstestfolder1bca8f8e"
$filePath = "pstestfolder1bca8f8e/pstestfile1bca8f8e.txt"
$file1 = "file1.txt"
$file2 = "file2.txt"
$policyName = "afspolicy1"
$newPolicyName = "NewAFSBackupPolicy"

# Setup Instructions:
# 1. Create a resource group
# New-AzResourceGroup -Name $resourceGroupName -Location $location

# 2. Create a storage account and a recovery services vault
# New-AzStorageAccount -ResourceGroupName $resourceGroupName -Name $saName -Location $location -SkuName $skuName
# New-AzRecoveryServicesVault -Name $vaultName -ResourceGroupName $resourceGroupName -Location $Location

# 3. Create a file share in the storage account
# $storageAcct = Get-AzStorageAccount -ResourceGroupName $resourceGroupName -Name $saName
# New-AzureStorageShare -Name $fileShareFriendlyName -Context $storageAcct.Context

# 4. Create a backup policy for file shares
# $vault = Get-AzRecoveryServicesVault -ResourceGroupName $resourceGroupName -Name $vaultName
# $schedulePolicy = Get-AzRecoveryServicesBackupSchedulePolicyObject -WorkloadType AzureFiles
# $retentionPolicy = Get-AzRecoveryServicesBackupRetentionPolicyObject -WorkloadType AzureFiles
# $policy = New-AzRecoveryServicesBackupProtectionPolicy -VaultId $vault.ID `
#		-Name $policyName `
#		-WorkloadType AzureFiles `
#		-RetentionPolicy $retentionPolicy `
#		-SchedulePolicy $schedulePolicy

function Test-AzureFSRestoreToAnotherRegion
{
	# testing AFS restore to different region and resource group than the source
	$targetFileShareName = "drfs"
	$targetSaName = "afsrestorediffregion2"

	try
	{
		$vault = Get-AzRecoveryServicesVault -ResourceGroupName $resourceGroupName -Name $vaultName
		Enable-Protection $vault $fileShareFriendlyName $saName

		$items = Get-AzRecoveryServicesBackupItem -VaultId $vault.ID -BackupManagementType AzureStorage -WorkloadType AzureFiles

		$backupJob = Backup-Item $vault $items[0]

		$backupStartTime = $backupJob.StartTime.AddMinutes(-1);
		$backupEndTime = $backupJob.EndTime.AddMinutes(1);

		$rp = Get-AzRecoveryServicesBackupRecoveryPoint `
			-VaultId $vault.ID `
			-StartDate $backupStartTime `
			-EndDate $backupEndTime `
			-Item $items[0];
			
		$restoreJob = Restore-AzRecoveryServicesBackupItem -RecoveryPoint $rp[0] -ResolveConflict Overwrite -VaultId $vault.ID -VaultLocation $vault.Location -TargetStorageAccountName $targetSaName -TargetFileShareName $targetFileShareName | Wait-AzRecoveryServicesBackupJob -VaultId $vault.ID

		Assert-True { $restoreJob.Status -eq "Completed" }
	}
	finally
	{
		Cleanup-Vault $vault $items $container
	}
}

function Test-AzureFSItem
{
	try
	{
		$vault = Get-AzRecoveryServicesVault -ResourceGroupName $resourceGroupName -Name $vaultName
		Enable-Protection $vault $fileShareFriendlyName $saName

		$policy = Get-AzRecoveryServicesBackupProtectionPolicy `
			-VaultId $vault.ID `
			-Name $policyName

		$container = Get-AzRecoveryServicesBackupContainer `
			-VaultId $vault.ID `
			-ContainerType AzureStorage `
			-FriendlyName $saName
		
		# VARIATION-1: Get all items for container
		$items = Get-AzRecoveryServicesBackupItem `
			-VaultId $vault.ID `
			-Container $container `
			-WorkloadType AzureFiles;
		Assert-True { $items.FriendlyName -contains $fileShareFriendlyName }

		# VARIATION-2: Get items for container with ProtectionStatus filter
		$items = Get-AzRecoveryServicesBackupItem `
			-VaultId $vault.ID `
			-Container $container `
			-WorkloadType AzureFiles `
			-ProtectionStatus Healthy;
		Assert-True { $items.FriendlyName -contains $fileShareFriendlyName }

		# VARIATION-3: Get items for container with Status filter
		$items = Get-AzRecoveryServicesBackupItem `
			-VaultId $vault.ID `
			-Container $container `
			-WorkloadType AzureFiles `
			-ProtectionState IRPending;
		Assert-True { $items.FriendlyName -contains $fileShareFriendlyName }

		# VARIATION-4: Get items for container with friendly name and ProtectionStatus filters
		$items = Get-AzRecoveryServicesBackupItem `
			-VaultId $vault.ID `
			-Container $container `
			-WorkloadType AzureFiles `
			-Name $fileShareFriendlyName `
			-ProtectionStatus Healthy;
		Assert-True { $items.FriendlyName -contains $fileShareFriendlyName }

		# VARIATION-5: Get items for container with friendly name and Status filters
		$items = Get-AzRecoveryServicesBackupItem `
			-VaultId $vault.ID `
			-Container $container `
			-WorkloadType AzureFiles `
			-Name $fileShareFriendlyName `
			-ProtectionState IRPending;
		Assert-True { $items.FriendlyName -contains $fileShareFriendlyName }

		# VARIATION-6: Get items for container with Status and ProtectionStatus filters
		$items = Get-AzRecoveryServicesBackupItem `
			-VaultId $vault.ID `
			-Container $container `
			-WorkloadType AzureFiles `
			-ProtectionState IRPending `
			-ProtectionStatus Healthy;
		Assert-True { $items.FriendlyName -contains $fileShareFriendlyName }

		# VARIATION-7: Get items for Vault Id and Policy
		$items = Get-AzRecoveryServicesBackupItem `
			-VaultId $vault.ID `
			-Policy $policy;
		Assert-True { $items.FriendlyName -contains $fileShareFriendlyName }

		# VARIATION-8: Get items for container with friendly name, Status and ProtectionStatus filters
		$items = Get-AzRecoveryServicesBackupItem `
			-VaultId $vault.ID `
			-Container $container `
			-WorkloadType AzureFiles `
			-Name $fileShareFriendlyName `
			-ProtectionState IRPending `
			-ProtectionStatus Healthy;
		Assert-True { $items.FriendlyName -contains $fileShareFriendlyName }
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
		$vault = Get-AzRecoveryServicesVault -ResourceGroupName $resourceGroupName -Name $vaultName
		$item = Enable-Protection $vault $fileShareFriendlyName $saName
		$container = Get-AzRecoveryServicesBackupContainer `
			-VaultId $vault.ID `
			-ContainerType AzureStorage `
			-FriendlyName $saName

		# Trigger backup and wait for completion
		$backupJob = Backup-AzRecoveryServicesBackupItem `
			-VaultId $vault.ID `
			-Item $item | Wait-AzRecoveryServicesBackupJob -VaultId $vault.ID

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
		$resourceGroupName = "iannea-rg"
		$vaultName = "iannea-rsv"
		$policyName = "afspolicy3"
		$newPolicyName = "afspolicy4"
		$fileShareFriendlyName = "afs0"
		$saName = "iannafstest1"
		$targetSaName = "iannafstest2"
		$targetFileShareName = "afs0"

		$vault = Get-AzRecoveryServicesVault -ResourceGroupName $resourceGroupName -Name $vaultName
		
		$policy = Get-AzRecoveryServicesBackupProtectionPolicy `
			-VaultId $vault.ID `
			-Name $policyName

		$enableJob = Enable-AzRecoveryServicesBackupProtection `
			-VaultId $vault.ID `
			-Policy $Policy `
			-Name $fileShareFriendlyName `
			-StorageAccountName $saName

		$container = Get-AzRecoveryServicesBackupContainer `
			-VaultId $vault.ID `
			-ContainerType AzureStorage `
			-FriendlyName $saName

		$item = Get-AzRecoveryServicesBackupItem `
			-VaultId $vault.ID `
			-Container $container `
			-WorkloadType AzureFiles
		Assert-True { $item.FriendlyName -contains $fileShareFriendlyName }
		Assert-True { $item.LastBackupStatus -eq "IRPending" }
		Assert-True { $item.ProtectionPolicyName -eq $policyName }
		
		# Modify Policy
		$newPolicy = Get-AzRecoveryServicesBackupProtectionPolicy `
		-VaultId $vault.ID `
		-Name $newPolicyName

		$enableJob =  Enable-AzRecoveryServicesBackupProtection `
			-VaultId $vault.ID `
			-Policy $newPolicy `
			-Item $item
		
		$item = Get-AzRecoveryServicesBackupItem `
		-VaultId $vault.ID `
		-Container $container `
		-WorkloadType AzureFiles

		Assert-True { $item.FriendlyName -contains $fileShareFriendlyName }
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
		$vault = Get-AzRecoveryServicesVault -ResourceGroupName $resourceGroupName -Name $vaultName
		$item = Enable-Protection $vault $fileShareFriendlyName $saName
		$container = Get-AzRecoveryServicesBackupContainer `
			-VaultId $vault.ID `
			-ContainerType AzureStorage `
			-FriendlyName $saName
		$backupJob = Backup-Item $vault $item

		$backupStartTime = $backupJob.StartTime.AddMinutes(-1);
		$backupEndTime = $backupJob.EndTime.AddMinutes(1);

		$recoveryPoint = Get-AzRecoveryServicesBackupRecoveryPoint `
			-VaultId $vault.ID `
			-StartDate $backupStartTime `
			-EndDate $backupEndTime `
			-Item $item;
	
		Assert-NotNull $recoveryPoint[0];
		Assert-True { $recoveryPoint[0].Id -match $item.Id };

		# Test 2: Get Recovery point detail
		$recoveryPointDetail = Get-AzRecoveryServicesBackupRecoveryPoint `
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
		$vault = Get-AzRecoveryServicesVault -ResourceGroupName $resourceGroupName -Name $vaultName
		$item = Enable-Protection $vault $fileShareFriendlyName $saName
		$container = Get-AzRecoveryServicesBackupContainer `
			-VaultId $vault.ID `
			-ContainerType AzureStorage `
			-FriendlyName $saName
		$backupJob = Backup-Item $vault $item

		$backupStartTime = $backupJob.StartTime.AddMinutes(-1);
		$backupEndTime = $backupJob.EndTime.AddMinutes(1);

		$recoveryPoint = Get-AzRecoveryServicesBackupRecoveryPoint `
			-VaultId $vault.ID `
			-StartDate $backupStartTime `
			-EndDate $backupEndTime `
			-Item $item;

		Assert-ThrowsContains { Restore-AzRecoveryServicesBackupItem `
			-VaultId $vault.ID `
			-VaultLocation $vault.Location `
			-RecoveryPoint $recoveryPoint[0] `
			-ResolveConflict Overwrite `
			-TargetStorageAccountName $targetSaName `
			-TargetFolder $targetFolder } `
			"Provide TargetFileShareName for Alternate Location restore or remove TargetStorageAccountName for Original Location restore"

		Assert-ThrowsContains { Restore-AzRecoveryServicesBackupItem `
			-VaultId $vault.ID `
			-VaultLocation $vault.Location `
			-RecoveryPoint $recoveryPoint[0] `
			-ResolveConflict Overwrite `
			-TargetFileShareName $targetFileShareName `
			-TargetFolder $targetFolder } `
			"Provide TargetStorageAccountName for Alternate Location restore or remove TargetFileShareName for Original Location restore"

		Assert-ThrowsContains { Restore-AzRecoveryServicesBackupItem `
			-VaultId $vault.ID `
		  	-VaultLocation $vault.Location `
		  	-RecoveryPoint $recoveryPoint[0] `
		  	-ResolveConflict Overwrite `
		  	-SourceFileType File } `
		  	"Provide SourceFilePath for File restore or remove SourceFileType for file share restore"

		Assert-ThrowsContains { Restore-AzRecoveryServicesBackupItem `
			-VaultId $vault.ID `
			-VaultLocation $vault.Location `
			-RecoveryPoint $recoveryPoint[0] `
			-ResolveConflict Overwrite `
			-SourceFilePath $filePath } `
			"Provide SourceFileType for File restore or remove SourceFilePath for file share restore"
			
		# Multiple Files Restore
		$files = ($file1, $file2)
		$restoreJob = Restore-AzRecoveryServicesBackupItem `
			-VaultId $vault.ID `
			-VaultLocation $vault.Location `
			-RecoveryPoint $recoveryPoint[0] `
			-MultipleSourceFilePath $files `
			-SourceFileType File `
			-ResolveConflict Overwrite | `
				Wait-AzRecoveryServicesBackupJob -VaultId $vault.ID

		Assert-True { $restoreJob.Status -eq "Completed" }
    
		# Test without storage account dependancy
		# Item level restore at alternate location
		$restoreJob1 = Restore-AzRecoveryServicesBackupItem `
			-VaultId $vault.ID `
			-VaultLocation $vault.Location `
			-RecoveryPoint $recoveryPoint[0] `
			-ResolveConflict Overwrite `
			-SourceFilePath $folderPath `
			-SourceFileType Directory `
			-TargetStorageAccountName $targetSaName `
			-TargetFileShareName $targetFileShareName `
			-TargetFolder $targetFolder | `
				Wait-AzRecoveryServicesBackupJob -VaultId $vault.ID
		
		Assert-True { $restoreJob1.Status -eq "Completed" }
    
		# Test without storage account dependancy
		# Full share restore at alternate location
		$restoreJob2 = Restore-AzRecoveryServicesBackupItem `
			-VaultId $vault.ID `
			-VaultLocation $vault.Location `
			-RecoveryPoint $recoveryPoint[0] `
			-ResolveConflict Overwrite `
			-TargetStorageAccountName $targetSaName `
			-TargetFileShareName $targetFileShareName `
			-TargetFolder $targetFolder | `
				Wait-AzRecoveryServicesBackupJob -VaultId $vault.ID
		
		Assert-True { $restoreJob2.Status -eq "Completed" }

		# Test without storage account dependancy
		# Item level restore at original location
		$restoreJob3 = Restore-AzRecoveryServicesBackupItem `
			-VaultId $vault.ID `
			-VaultLocation $vault.Location `
			-RecoveryPoint $recoveryPoint[0] `
			-ResolveConflict Overwrite `
			-SourceFilePath $filePath `
			-SourceFileType File | `
				Wait-AzRecoveryServicesBackupJob -VaultId $vault.ID

		Assert-True { $restoreJob3.Status -eq "Completed" }

		# Test without storage account dependancy
		# Full share restore at original location
		$restoreJob4 = Restore-AzRecoveryServicesBackupItem `
			-VaultId $vault.ID `
			-VaultLocation $vault.Location `
			-RecoveryPoint $recoveryPoint[0] `
			-ResolveConflict Overwrite | `
				Wait-AzRecoveryServicesBackupJob -VaultId $vault.ID

		Assert-True { $restoreJob4.Status -eq "Completed" }
	}
	finally
	{
		Cleanup-Vault $vault $item $container
	}
}

function Test-AzureFSVaultRestore
{
	try
	{
		$resourceGroupName = "iannea-rg"
		$vaultName = "iannea-rsv"
		$policyName = "afspolicy1"
		$newPolicyName = "afsvaultpolicy1"
		$fileShareFriendlyName = "afs0"
		$saName = "iannafstest"
		$targetSaName = "iannafstest1"
		$targetFileShareName = "afs0"

		# Get Vault
		$vault = Get-AzRecoveryServicesVault -ResourceGroupName $resourceGroupName -Name $vaultName

		# Get default schedule policy object
		$schedulePolicy = Get-AzRecoveryServicesBackupSchedulePolicyObject -WorkloadType AzureFiles
		Assert-NotNull $schedulePolicy

		# Create retention policy with VaultStandard backup tier 
		$vaultRetentionPolicy = Get-AzRecoveryServicesBackupRetentionPolicyObject `
			-WorkloadType AzureFiles `
			-BackupTier VaultStandard 

		# Create retention policy with Snapshot backup tier 
		$snapshotRetentionPolicy = Get-AzRecoveryServicesBackupRetentionPolicyObject `
			-WorkloadType AzureFiles `
			-BackupTier Snapshot

		# Create policy 
		$snapshotPolicy = New-AzRecoveryServicesBackupProtectionPolicy `
			-VaultId $vault.ID `
			-Name $policyName `
			-WorkloadType AzureFiles `
			-RetentionPolicy $snapshotRetentionPolicy `
			-SchedulePolicy $schedulePolicy
		
		$vaultPolicy = New-AzRecoveryServicesBackupProtectionPolicy `
			-VaultId $vault.ID `
			-Name $newPolicyName `
			-WorkloadType AzureFiles `
			-RetentionPolicy $vaultRetentionPolicy `
			-SchedulePolicy $schedulePolicy
		
		# Enable protection with VaultStandard policy
		Enable-AzRecoveryServicesBackupProtection `
									-VaultId $vault.ID `
									-Policy $vaultPolicy `
									-Name $fileShareFriendlyName `
									-storageAccountName $saName | Out-Null

		# Modify protection with Snapshot policy
		$container = Get-AzRecoveryServicesBackupContainer `
			-VaultId $vault.ID `
			-ContainerType AzureStorage `
			-FriendlyName $saName

		$item = Get-AzRecoveryServicesBackupItem `
					-VaultId $vault.ID `
					-Container $container `
					-WorkloadType AzureFiles

		Assert-ThrowsContains { Enable-AzRecoveryServicesBackupProtection `
									-VaultId $vault.ID `
									-Policy $snapshotPolicy `
									-Item $item
		} "Switching the backup tier from vaulted backup to snapshot is not possible. Please create a new policy for snapshot-only backups."

		$item = Get-AzRecoveryServicesBackupItem -VaultId $vault.ID -BackupManagementType AzureStorage -WorkloadType AzureFiles
		
		# Adhoc Backup
		$backupJob = Backup-Item $vault $item

		$backupStartTime = $backupJob.StartTime.AddMinutes(-1);
		$backupEndTime = $backupJob.EndTime.AddMinutes(1);

		# Perform restore with VaultStandard RP	
		$rp = Get-AzRecoveryServicesBackupRecoveryPoint `
			-VaultId $vault.ID `
			-StartDate $backupStartTime `
			-EndDate $backupEndTime `
			-Item $item;
		
		$restoreJob = Restore-AzRecoveryServicesBackupItem -RecoveryPoint $rp[0] -ResolveConflict Overwrite -VaultId $vault.ID -VaultLocation $vault.Location -TargetStorageAccountName $targetSaName -TargetFileShareName $targetFileShareName | Wait-AzRecoveryServicesBackupJob -VaultId $vault.ID

		Assert-True { $restoreJob.Status -eq "Completed" }
	}
	finally
	{
		Cleanup-Vault $vault $item $container
	}
}