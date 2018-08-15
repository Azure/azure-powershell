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

function Test-AzureVMGetItems
{
	$location = Get-ResourceGroupLocation
	$resourceGroupName = Create-ResourceGroup $location

	try
	{
		# Setup
		$vm = Create-VM $resourceGroupName $location 1
		$vm2 = Create-VM $resourceGroupName $location 12
		$vault = Create-RecoveryServicesVault $resourceGroupName $location
		Enable-Protection $vault $vm
		Enable-Protection $vault $vm2
		$policy = Get-AzureRmRecoveryServicesBackupProtectionPolicy `
			-VaultId $vault.ID `
			-Name "DefaultPolicy"

		$container = Get-AzureRmRecoveryServicesBackupContainer `
			-VaultId $vault.ID `
			-ContainerType AzureVM `
			-Status Registered `
			-Name $vm.Name
		
		# VARIATION-1: Get all items for container
		$items = Get-AzureRmRecoveryServicesBackupItem `
			-VaultId $vault.ID `
			-Container $container `
			-WorkloadType AzureVM;
		Assert-True { $items.VirtualMachineId -contains $vm.Id }

		# VARIATION-2: Get items for container with friendly name filter.
		# Here we will be testing a case when two VMs with overlapping names are protected.
		$items = Get-AzureRmRecoveryServicesBackupItem `
			-VaultId $vault.ID `
			-Container $container `
			-WorkloadType AzureVM `
			-Name $vm.Name;
		Assert-True { $items.Count -eq 1 }
		Assert-True { $items.VirtualMachineId -contains $vm.Id }
		Assert-NotNull $items[0].LastBackupTime

		# VARIATION-3: Get items for container with ProtectionStatus filter
		$items = Get-AzureRmRecoveryServicesBackupItem `
			-VaultId $vault.ID `
			-Container $container `
			-WorkloadType AzureVM `
			-ProtectionStatus Healthy;
		Assert-True { $items.VirtualMachineId -contains $vm.Id }

		# VARIATION-4: Get items for container with Status filter
		$items = Get-AzureRmRecoveryServicesBackupItem `
			-VaultId $vault.ID `
			-Container $container `
			-WorkloadType AzureVM `
			-ProtectionState IRPending;
		Assert-True { $items.VirtualMachineId -contains $vm.Id }

		# VARIATION-5: Get items for container with friendly name and ProtectionStatus filters
		$items = Get-AzureRmRecoveryServicesBackupItem `
			-VaultId $vault.ID `
			-Container $container `
			-WorkloadType AzureVM `
			-Name $vm.Name `
			-ProtectionStatus Healthy;
		Assert-True { $items.VirtualMachineId -contains $vm.Id }

		# VARIATION-6: Get items for container with friendly name and Status filters
		$items = Get-AzureRmRecoveryServicesBackupItem `
			-VaultId $vault.ID `
			-Container $container `
			-WorkloadType AzureVM `
			-Name $vm.Name `
			-ProtectionState IRPending;
		Assert-True { $items.VirtualMachineId -contains $vm.Id }

		# VARIATION-7: Get items for container with Status and ProtectionStatus filters
		$items = Get-AzureRmRecoveryServicesBackupItem `
			-VaultId $vault.ID `
			-Container $container `
			-WorkloadType AzureVM `
			-ProtectionState IRPending `
			-ProtectionStatus Healthy;
		Assert-True { $items.VirtualMachineId -contains $vm.Id }

		# VARIATION-8: Get items for container with friendly name, Status and ProtectionStatus filters
		$items = Get-AzureRmRecoveryServicesBackupItem `
			-VaultId $vault.ID `
			-Container $container `
			-WorkloadType AzureVM `
			-Name $vm.Name `
			-ProtectionState IRPending `
			-ProtectionStatus Healthy;
		Assert-True { $items.VirtualMachineId -contains $vm.Id }

		# VARIATION-9: Get items for Vault Id and Policy
		$items = Get-AzureRmRecoveryServicesBackupItem `
			-VaultId $vault.ID `
			-Policy $policy;
		Assert-True { $items.VirtualMachineId -contains $vm.Id }
	}
	finally
	{
		# Cleanup
		Cleanup-ResourceGroup $resourceGroupName
	}
}

function Test-AzureVMProtection
{
	$location = Get-ResourceGroupLocation
	$resourceGroupName = Create-ResourceGroup $location

	try
	{
		# Setup
		$vm = Create-VM $resourceGroupName $location
		$vault = Create-RecoveryServicesVault $resourceGroupName $location

		# Get default policy
		$policy = Get-AzureRmRecoveryServicesBackupProtectionPolicy `
			-VaultId $vault.ID `
			-Name "DefaultPolicy";
	
		# Enable protection
		Enable-AzureRmRecoveryServicesBackupProtection `
			-VaultId $vault.ID `
			-Policy $policy `
			-Name $vm.Name `
			-ResourceGroupName $vm.ResourceGroupName;

		$container = Get-AzureRmRecoveryServicesBackupContainer `
			-VaultId $vault.ID `
			-ContainerType AzureVM `
			-Status Registered;

		$item = Get-AzureRmRecoveryServicesBackupItem `
			-VaultId $vault.ID `
			-Container $container `
			-WorkloadType AzureVM

		# Disable protection
		Disable-AzureRmRecoveryServicesBackupProtection `
			-VaultId $vault.ID `
			-Item $item `
			-RemoveRecoveryPoints `
			-Force;
	}
	finally
	{
		# Cleanup
		Cleanup-ResourceGroup $resourceGroupName
	}
}

function Test-AzureVMGetRPs
{
	$location = Get-ResourceGroupLocation
	$resourceGroupName = Create-ResourceGroup $location

	try
	{
  		# Setup
		$vm = Create-VM $resourceGroupName $location
		$vault = Create-RecoveryServicesVault $resourceGroupName $location
		$item = Enable-Protection $vault $vm
		$backupJob = Backup-Item $vault $item

		# Test 1: Get latest recovery point; should be only one
		$backupStartTime = $backupJob.StartTime.AddMinutes(-1);
		$backupEndTime = $backupJob.EndTime.AddMinutes(1);
		$recoveryPoint = Get-AzureRmRecoveryServicesBackupRecoveryPoint `
			-VaultId $vault.ID `
			-StartDate $backupStartTime `
			-EndDate $backupEndTime `
			-Item $item;
	
		Assert-NotNull $recoveryPoint;
		Assert-True { $recoveryPoint.SourceResourceId -match $vm.Id };

		# Test 2: Get Recovery point detail
		$recoveryPointDetail = Get-AzureRmRecoveryServicesBackupRecoveryPoint `
			-VaultId $vault.ID `
			-RecoveryPointId $recoveryPoint[0].RecoveryPointId `
			-Item $item;
	
		Assert-NotNull $recoveryPointDetail;

		# Negative test cases
		# 1. StartDate < EndDate
		Assert-ThrowsContains { Get-AzureRmRecoveryServicesBackupRecoveryPoint `
			-VaultId $vault.ID `
			-StartDate $backupEndTime `
			-EndDate $backupStartTime `
			-Item $item } `
			"End date should be greater than start date";
		
		# 2. rangeStart > DateTime.UtcNow
		$backupStartTime1 = Get-QueryDateInUtc $((Get-Date).AddYears(100)) "BackupStartTime1"
        Assert-ThrowsContains { Get-AzureRmRecoveryServicesBackupRecoveryPoint `
			-VaultId $vault.ID `
			-StartDate $backupStartTime1 `
			-Item $item } `
			"Start date\time should be less than current UTC date\time";

		# 3. rangeStart.Kind != DateTimeKind.Utc
		$backupStartTime2 = Get-QueryDateLocal $((Get-Date).AddDays(-20)) "BackupStartTime2"
        Assert-ThrowsContains { Get-AzureRmRecoveryServicesBackupRecoveryPoint `
			-VaultId $vault.ID `
			-StartDate $backupStartTime2 `
			-Item $item } `
			"Please specify startdate and enddate in UTC format";
	}
	finally
	{
		# Cleanup
		Cleanup-ResourceGroup $resourceGroupName
	}
}

function Test-AzureVMFullRestore
{
	$location = Get-ResourceGroupLocation
	$resourceGroupName = Create-ResourceGroup $location
	$targetResourceGroupName = Create-ResourceGroup $location 1

	try
	{
		# Setup
		$saName = Create-SA $resourceGroupName $location
		$vm = Create-VM $resourceGroupName $location
		$vault = Create-RecoveryServicesVault $resourceGroupName $location
		$item = Enable-Protection $vault $vm
		$backupJob = Backup-Item $vault $item
		$rp = Get-RecoveryPoint $vault $item $backupJob

		Assert-ThrowsContains { Restore-AzureRmRecoveryServicesBackupItem `
			-VaultId $vault.ID `
			-VaultLocation $vault.Location `
			-RecoveryPoint $rp `
			-StorageAccountName $saName `
			-StorageAccountResourceGroupName $resourceGroupName `
			-UseOriginalStorageAccount } `
			"This recovery point doesn’t have the capability to restore disks to their original storage account. Re-run the restore command without the UseOriginalStorageAccountForDisks parameter.";

		$restoreJob1 = Restore-AzureRmRecoveryServicesBackupItem `
			-VaultId $vault.ID `
			-VaultLocation $vault.Location `
			-RecoveryPoint $rp `
			-StorageAccountName $saName `
			-StorageAccountResourceGroupName $resourceGroupName | `
				Wait-AzureRmRecoveryServicesBackupJob -VaultId $vault.ID

		Assert-True { $restoreJob1.Status -eq "Completed" }   

		$restoreJob2 = Restore-AzureRmRecoveryServicesBackupItem `
			-VaultId $vault.ID `
			-VaultLocation $vault.Location `
			-RecoveryPoint $rp `
			-StorageAccountName $saName `
			-StorageAccountResourceGroupName $resourceGroupName `
			-TargetResourceGroupName $targetResourceGroupName | `
				Wait-AzureRmRecoveryServicesBackupJob -VaultId $vault.ID

		Assert-True { $restoreJob2.Status -eq "Completed" }
	}
	finally
	{
		# Cleanup
		Cleanup-ResourceGroup $resourceGroupName
		Cleanup-ResourceGroup $targetResourceGroupName
	}
}

function Test-AzureVMRPMountScript
{
	$location = Get-ResourceGroupLocation
	$resourceGroupName = Create-ResourceGroup $location

	try
	{
		# Setup
		$vm = Create-VM $resourceGroupName $location
		$vault = Create-RecoveryServicesVault $resourceGroupName $location
		$item = Enable-Protection $vault $vm
		$backupJob = Backup-Item $vault $item
		$rp = Get-RecoveryPoint $vault $item $backupJob

		# Get details of mount script of recovery point
		$mountScriptDetails = Get-AzureRmRecoveryServicesBackupRPMountScript `
			-VaultId $vault.ID `
			-RecoveryPoint $rp

		Assert-NotNull $mountScriptDetails.OsType
		Assert-NotNull $mountScriptDetails.Password
		Assert-NotNull $mountScriptDetails.Filename
		Assert-NotNull $mountScriptDetails.FilePath

		Write-Output $mountScriptDetails

		# Disable the mount script of recovery point
		Disable-AzureRmRecoveryServicesBackupRPMountScript -VaultId $vault.ID -RecoveryPoint $rp
	}
	finally
	{
		# Cleanup
		Cleanup-ResourceGroup $resourceGroupName
	}
}

function Test-AzureVMBackup
{
	$location = Get-ResourceGroupLocation
	$resourceGroupName = Create-ResourceGroup $location

	try
	{
		# Setup
		$vm = Create-VM $resourceGroupName $location
		$vault = Create-RecoveryServicesVault $resourceGroupName $location
		$item = Enable-Protection $vault $vm
		
		# Trigger backup and wait for completion
		$backupJob = Backup-AzureRmRecoveryServicesBackupItem `
			-VaultId $vault.ID `
			-Item $item | Wait-AzureRmRecoveryServicesBackupJob -VaultId $vault.ID

		Assert-True { $backupJob.Status -eq "Completed" }
	}
	finally
	{
		# Cleanup
		Cleanup-ResourceGroup $resourceGroupName
	}
}

function Test-AzureVMSetVaultContext
{
	$location = Get-ResourceGroupLocation
	$resourceGroupName = Create-ResourceGroup $location

	try
	{
		# Setup
		$vm = Create-VM $resourceGroupName $location
		$vault = Create-RecoveryServicesVault $resourceGroupName $location

		Set-AzureRmRecoveryServicesVaultContext -Vault $vault

		# Get default policy
		$policy = Get-AzureRmRecoveryServicesBackupProtectionPolicy `
			-Name "DefaultPolicy";
	
		# Enable protection
		Enable-AzureRmRecoveryServicesBackupProtection `
			-Policy $policy `
			-Name $vm.Name `
			-ResourceGroupName $vm.ResourceGroupName;

		$container = Get-AzureRmRecoveryServicesBackupContainer `
			-ContainerType AzureVM `
			-Status Registered;

		$item = Get-AzureRmRecoveryServicesBackupItem `
			-Container $container `
			-WorkloadType AzureVM

		# Disable protection
		Disable-AzureRmRecoveryServicesBackupProtection `
			-Item $item `
			-RemoveRecoveryPoints `
			-Force;
	}
	finally
	{
		# Cleanup
		Cleanup-ResourceGroup $resourceGroupName
	}
}