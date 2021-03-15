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

function Test-AzureVMCrossRegionRestore
{
	$location = "centraluseuap"
	$resourceGroupName = Create-ResourceGroup $location 24

	try
	{
		# Setup
		$vault = Create-RecoveryServicesVault $resourceGroupName $location 25

		# waiting for service to reflect
		Start-TestSleep 20000

		# Enable CRR
		Set-AzRecoveryServicesBackupProperty -Vault $vault -EnableCrossRegionRestore

		# waiting for service to reflect
		Start-TestSleep 30000

		# Assert that the vault is now CRR enabled
		$crr = Get-AzRecoveryServicesBackupProperty -Vault $vault
		Assert-True { $crr.CrossRegionRestore -eq $true }
	}
	finally
	{
		# Cleanup
		Cleanup-ResourceGroup $resourceGroupName
	}
}

function Test-AzureRSVaultMSI
{
	try
	{		
		$location = "southeastasia"
		$resourceGroupName = Create-ResourceGroup $location 22	
		$vault = Create-RecoveryServicesVault $resourceGroupName $location
	
		# disable soft delete for successful cleanup
		Set-AzRecoveryServicesVaultProperty -VaultId $vault.ID -SoftDeleteFeatureState "Disable"
	
		# get Identity - verify Empty 
		$vault = Get-AzRecoveryServicesVault -Name $vault.Name -ResourceGroupName $vault.ResourceGroupName
		Assert-True { $vault.Identity -eq $null }
		
		# set Identity - verify System assigned
		$updatedVault = Update-AzRecoveryServicesVault -ResourceGroupName $vault.ResourceGroupName -Name $vault.Name -IdentityType "SystemAssigned"
		Assert-True { $updatedVault.Identity.Type -eq "SystemAssigned" }
	
		# remove Identity - verify empty again 
		$rm = Update-AzRecoveryServicesVault -ResourceGroupName $vault.ResourceGroupName -Name $vault.Name -IdentityType "None"
		Assert-True { $rm.Identity.Type -eq "None" }	
	}
	finally
	{
		# Cleanup
		Cleanup-ResourceGroup $resourceGroupName
	}
}

function Test-AzureBackupDataMove
{
	$sourceLocation = "eastus2euap"
	$sourceResourceGroup = Create-ResourceGroup $sourceLocation 21

	$targetLocation = "centraluseuap"
	$targetResourceGroup = Create-ResourceGroup $targetLocation 23
		
	$vm = Create-VM $sourceResourceGroup $sourceLocation 3
	$vault1 = Create-RecoveryServicesVault $sourceResourceGroup $sourceLocation
	$vault2 = Create-RecoveryServicesVault $targetResourceGroup $targetLocation
	Enable-Protection $vault1 $vm
		
	# disable soft delete for successful cleanup
	Set-AzRecoveryServicesVaultProperty -VaultId $vault1.ID -SoftDeleteFeatureState "Disable"
	Set-AzRecoveryServicesVaultProperty -VaultId $vault2.ID -SoftDeleteFeatureState "Disable"

	# data move v2 to v1 fails due to TargetVaultNotEmpty
	Assert-ThrowsContains { Copy-AzRecoveryServicesVault -SourceVault $vault2 -TargetVault $vault1 -Force } `
		"Please provide an empty target vault. The target vault should not have any backup items or backup containers";			

	# data move from v1 to v2 succeeds
	$dataMove = Copy-AzRecoveryServicesVault -SourceVault $vault1 -TargetVault $vault2 -Force;
	Assert-True { $dataMove -contains "Please monitor the operation using Az-RecoveryServicesBackupJob cmdlet" }			
}

function Test-AzureVMGetItems
{
	$location = "southeastasia"
	$resourceGroupName = Create-ResourceGroup $location

	try
	{
		# Setup
		$vm = Create-VM $resourceGroupName $location 1
		$vm2 = Create-VM $resourceGroupName $location 12
		$vault = Create-RecoveryServicesVault $resourceGroupName $location
		Enable-Protection $vault $vm
		Enable-Protection $vault $vm2
		$policy = Get-AzRecoveryServicesBackupProtectionPolicy `
			-VaultId $vault.ID `
			-Name "DefaultPolicy"

		$container = Get-AzRecoveryServicesBackupContainer `
			-VaultId $vault.ID `
			-ContainerType AzureVM `
			-Status Registered `
			-FriendlyName $vm.Name
		
		# VARIATION-1: Get all items for container
		$items = Get-AzRecoveryServicesBackupItem `
			-VaultId $vault.ID `
			-Container $container `
			-WorkloadType AzureVM;
		Assert-True { $items.VirtualMachineId -contains $vm.Id }

		# VARIATION-2: Get items for container with friendly name filter.
		# Here we will be testing a case when two VMs with overlapping names are protected.
		$items = Get-AzRecoveryServicesBackupItem `
			-VaultId $vault.ID `
			-Container $container `
			-WorkloadType AzureVM `
			-Name $vm.Name;
		Assert-True { $items.Count -eq 1 }
		Assert-True { $items.VirtualMachineId -contains $vm.Id }
		Assert-NotNull $items[0].LastBackupTime

		# VARIATION-3: Get items for container with ProtectionStatus filter
		$items = Get-AzRecoveryServicesBackupItem `
			-VaultId $vault.ID `
			-Container $container `
			-WorkloadType AzureVM `
			-ProtectionStatus Healthy;
		Assert-True { $items.VirtualMachineId -contains $vm.Id }

		# VARIATION-4: Get items for container with Status filter
		$items = Get-AzRecoveryServicesBackupItem `
			-VaultId $vault.ID `
			-Container $container `
			-WorkloadType AzureVM `
			-ProtectionState IRPending;
		Assert-True { $items.VirtualMachineId -contains $vm.Id }

		# VARIATION-5: Get items for container with friendly name and ProtectionStatus filters
		$items = Get-AzRecoveryServicesBackupItem `
			-VaultId $vault.ID `
			-Container $container `
			-WorkloadType AzureVM `
			-Name $vm.Name `
			-ProtectionStatus Healthy;
		Assert-True { $items.VirtualMachineId -contains $vm.Id }

		# VARIATION-6: Get items for container with friendly name and Status filters
		$items = Get-AzRecoveryServicesBackupItem `
			-VaultId $vault.ID `
			-Container $container `
			-WorkloadType AzureVM `
			-Name $vm.Name `
			-ProtectionState IRPending;
		Assert-True { $items.VirtualMachineId -contains $vm.Id }

		# VARIATION-7: Get items for container with Status and ProtectionStatus filters
		$items = Get-AzRecoveryServicesBackupItem `
			-VaultId $vault.ID `
			-Container $container `
			-WorkloadType AzureVM `
			-ProtectionState IRPending `
			-ProtectionStatus Healthy;
		Assert-True { $items.VirtualMachineId -contains $vm.Id }

		# VARIATION-8: Get items for container with friendly name, Status and ProtectionStatus filters
		$items = Get-AzRecoveryServicesBackupItem `
			-VaultId $vault.ID `
			-Container $container `
			-WorkloadType AzureVM `
			-Name $vm.Name `
			-ProtectionState IRPending `
			-ProtectionStatus Healthy;
		Assert-True { $items.VirtualMachineId -contains $vm.Id }

		# VARIATION-9: Get items for Vault Id and Policy
		$items = Get-AzRecoveryServicesBackupItem `
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
	$location = "southeastasia"
	$resourceGroupName = Create-ResourceGroup $location

	try
	{
		# Setup
		$vm = Create-VM $resourceGroupName $location
		$vault = Create-RecoveryServicesVault $resourceGroupName $location

		# Sleep to give the service time to add the default policy to the vault
        Start-TestSleep 5000

		# Get default policy
		$policy = Get-AzRecoveryServicesBackupProtectionPolicy `
			-VaultId $vault.ID `
			-Name "DefaultPolicy";
	
		# Enable protection
		Enable-AzRecoveryServicesBackupProtection `
			-VaultId $vault.ID `
			-Policy $policy `
			-Name $vm.Name `
			-ResourceGroupName $vm.ResourceGroupName;

		$policy = Get-AzRecoveryServicesBackupProtectionPolicy `
			-VaultId $vault.ID `
			-Name "DefaultPolicy";

		Assert-True {$policy.ProtectedItemsCount -eq 1};

		$container = Get-AzRecoveryServicesBackupContainer `
			-VaultId $vault.ID `
			-ContainerType AzureVM `
			-Status Registered;

		$item = Get-AzRecoveryServicesBackupItem `
			-VaultId $vault.ID `
			-Container $container `
			-WorkloadType AzureVM

		# Disable protection
		Disable-AzRecoveryServicesBackupProtection `
			-VaultId $vault.ID `
			-Item $item `
			-RemoveRecoveryPoints `
			-Force;
		
		$policy = Get-AzRecoveryServicesBackupProtectionPolicy `
			-VaultId $vault.ID `
			-Name "DefaultPolicy";

		Assert-True {$policy.ProtectedItemsCount -eq 0};

	}
	finally
	{
		# Cleanup
		Cleanup-ResourceGroup $resourceGroupName
	}
}

function Test-AzureVMGetRPs
{
	$location = "southeastasia"
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
		$recoveryPoint = Get-AzRecoveryServicesBackupRecoveryPoint `
			-VaultId $vault.ID `
			-StartDate $backupStartTime `
			-EndDate $backupEndTime `
			-Item $item;
	
		Assert-NotNull $recoveryPoint;
		Assert-True { $recoveryPoint.SourceResourceId -match $vm.Id };

		# Test 2: Get Recovery point detail
		$recoveryPointDetail = Get-AzRecoveryServicesBackupRecoveryPoint `
			-VaultId $vault.ID `
			-RecoveryPointId $recoveryPoint[0].RecoveryPointId `
			-Item $item;
	
		Assert-NotNull $recoveryPointDetail;

		# Negative test cases
		# 1. StartDate < EndDate
		Assert-ThrowsContains { Get-AzRecoveryServicesBackupRecoveryPoint `
			-VaultId $vault.ID `
			-StartDate $backupEndTime `
			-EndDate $backupStartTime `
			-Item $item } `
			"End date should be greater than start date";
		
		# 2. rangeStart > DateTime.UtcNow
		$backupStartTime1 = Get-QueryDateInUtc $((Get-Date).AddYears(100)) "BackupStartTime1"
        Assert-ThrowsContains { Get-AzRecoveryServicesBackupRecoveryPoint `
			-VaultId $vault.ID `
			-StartDate $backupStartTime1 `
			-Item $item } `
			"Start date\time should be less than current UTC date\time";

		# 3. rangeStart.Kind != DateTimeKind.Utc
		$backupStartTime2 = Get-QueryDateLocal $((Get-Date).AddDays(-20)) "BackupStartTime2"
        Assert-ThrowsContains { Get-AzRecoveryServicesBackupRecoveryPoint `
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
	$location = "southeastasia"
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

		Assert-ThrowsContains { Restore-AzRecoveryServicesBackupItem `
			-VaultId $vault.ID `
			-VaultLocation $vault.Location `
			-RecoveryPoint $rp `
			-StorageAccountName $saName `
			-StorageAccountResourceGroupName $resourceGroupName `
			-UseOriginalStorageAccount } `
			"This recovery point doesn’t have the capability to restore disks to their original storage account. Re-run the restore command without the UseOriginalStorageAccountForDisks parameter.";

		$restoreJob1 = Restore-AzRecoveryServicesBackupItem `
			-VaultId $vault.ID `
			-VaultLocation $vault.Location `
			-RecoveryPoint $rp `
			-StorageAccountName $saName `
			-RestoreAsUnmanagedDisks `
			-StorageAccountResourceGroupName $resourceGroupName | `
				Wait-AzRecoveryServicesBackupJob -VaultId $vault.ID

		Assert-True { $restoreJob1.Status -eq "Completed" }   

		$restoreJob2 = Restore-AzRecoveryServicesBackupItem `
			-VaultId $vault.ID `
			-VaultLocation $vault.Location `
			-RecoveryPoint $rp `
			-StorageAccountName $saName `
			-StorageAccountResourceGroupName $resourceGroupName `
			-TargetResourceGroupName $targetResourceGroupName | `
				Wait-AzRecoveryServicesBackupJob -VaultId $vault.ID

		Assert-True { $restoreJob2.Status -eq "Completed" }
	}
	finally
	{
		# Cleanup
		Cleanup-ResourceGroup $resourceGroupName
		Cleanup-ResourceGroup $targetResourceGroupName
	}
}

function Test-AzureUnmanagedVMFullRestore
{
	$location = "southeastasia"
	$resourceGroupName = Create-ResourceGroup $location
	
	try
	{
		$saName = Create-SA $resourceGroupName $location
		$vm = Create-UnmanagedVM $resourceGroupName $location $saName
		$vault = Create-RecoveryServicesVault $resourceGroupName $location
		$item = Enable-Protection $vault $vm $resourceGroupName
		$backupJob = Backup-Item $vault $item
		$rp = Get-RecoveryPoint $vault $item $backupJob

		$restoreJob = Restore-AzRecoveryServicesBackupItem `
			-VaultId $vault.ID `
			-VaultLocation $vault.Location `
			-RecoveryPoint $rp `
			-StorageAccountName $saName `
			-StorageAccountResourceGroupName $resourceGroupName `
			-UseOriginalStorageAccount | Wait-AzRecoveryServicesBackupJob -VaultId $vault.ID
		
		Assert-True { $restoreJob.Status -eq "Completed" }
	}
	finally
	{
		Cleanup-ResourceGroup $resourceGroupName
	}
}

function Test-AzureVMRPMountScript
{
	$location = "southeastasia"
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
		$mountScriptDetails = Get-AzRecoveryServicesBackupRPMountScript `
			-VaultId $vault.ID `
			-RecoveryPoint $rp

		Assert-NotNull $mountScriptDetails.OsType
		Assert-NotNull $mountScriptDetails.Password
		Assert-NotNull $mountScriptDetails.Filename
		Assert-NotNull $mountScriptDetails.FilePath

		Write-Output $mountScriptDetails

		# Disable the mount script of recovery point
		Disable-AzRecoveryServicesBackupRPMountScript -VaultId $vault.ID -RecoveryPoint $rp
	}
	finally
	{
		# Cleanup
		Cleanup-ResourceGroup $resourceGroupName
	}
}

function Test-AzureVMBackup
{
	$location = "southeastasia"
	$resourceGroupName = Create-ResourceGroup $location

	try
	{
		# Setup
		$vault = Create-RecoveryServicesVault $resourceGroupName $location
		$vm = Create-VM $resourceGroupName $location
		$item = Enable-Protection $vault $vm
		
		# Trigger backup and wait for completion
		$backupJob = Backup-AzRecoveryServicesBackupItem `
			-VaultId $vault.ID `
			-Item $item | Wait-AzRecoveryServicesBackupJob -VaultId $vault.ID

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
	$location = "southeastasia"
	$resourceGroupName = Create-ResourceGroup $location

	try
	{
		# Setup
		$vm = Create-VM $resourceGroupName $location
		$vault = Create-RecoveryServicesVault $resourceGroupName $location

		# Sleep to give the service time to add the default policy to the vault
        Start-TestSleep 5000

		Set-AzRecoveryServicesVaultContext -Vault $vault

		# Get default policy
		$policy = Get-AzRecoveryServicesBackupProtectionPolicy `
			-Name "DefaultPolicy";
	
		# Enable protection
		Enable-AzRecoveryServicesBackupProtection `
			-Policy $policy `
			-Name $vm.Name `
			-ResourceGroupName $vm.ResourceGroupName;

		$container = Get-AzRecoveryServicesBackupContainer `
			-ContainerType AzureVM `
			-Status Registered;

		$item = Get-AzRecoveryServicesBackupItem `
			-Container $container `
			-WorkloadType AzureVM

		# Disable protection
		Disable-AzRecoveryServicesBackupProtection `
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

function Test-AzureVMSoftDelete
{
	$location = "southeastasia"
	$resourceGroupName = Create-ResourceGroup $location

	try
	{	
		#Setup
		$vault = Create-RecoveryServicesVault $resourceGroupName $location
		$vm = Create-VM $resourceGroupName $location
		
		
		$item = Enable-Protection $vault $vm
		$backupJob = Backup-Item $vault $item
		
		#SoftDelete
		
		Disable-AzRecoveryServicesBackupProtection `
			-VaultId $vault.ID `
			-Item $item `
			-RemoveRecoveryPoints `
			-Force;

		#Check if the item is in a softdeleted state

		$container = Get-AzRecoveryServicesBackupContainer `
			-VaultId $vault.ID `
			-ContainerType "AzureVM" `
			-FriendlyName $vm.Name;

		$item = Get-AzRecoveryServicesBackupItem `
			-VaultId $vault.ID `
			-Container $container `
			-WorkloadType "AzureVM";

		#rehydrate the softdeleted item

		Undo-AzRecoveryServicesBackupItemDeletion `
			-VaultId $vault.ID `
			-Item $item;

		$item = Get-AzRecoveryServicesBackupItem `
			-VaultId $vault.ID `
			-Container $container `
			-WorkloadType "AzureVM";

		#check if item is in a rehydrated state
		Assert-True { $item.ProtectionState -eq "ProtectionStopped" }

	}
	finally
	{
		#write cleanup for softdeleted state
	}
}

function Test-AzureVMSetVaultProperty
{
	$location = "southeastasia"
	$resourceGroupName = Create-ResourceGroup $location
	try
	{
		$vault = Create-RecoveryServicesVault $resourceGroupName $location
		$VaultProperty = Get-AzRecoveryServicesVaultProperty -VaultId $vault.ID

		Assert-True { $VaultProperty.SoftDeleteFeatureState -eq "Enabled" }

		Set-AzRecoveryServicesVaultProperty -VaultId $vault.ID -SoftDeleteFeatureState "Disable"
		$VaultProperty = Get-AzRecoveryServicesVaultProperty -VaultId $vault.ID
		Assert-True { $VaultProperty.SoftDeleteFeatureState -eq "Disabled" }
	}
	finally
	{
		# Cleanup
		Cleanup-ResourceGroup $resourceGroupName
	}
}

function Test-AzureVMDiskExclusion
{
	$location = "southeastasia"
	$resourceGroupName = Create-ResourceGroup $location
	$storageType = 'Standard_LRS'
	try
	{
		$saName = Create-SA $resourceGroupName $location
		$vault = Create-RecoveryServicesVault $resourceGroupName $location
		Set-AzRecoveryServicesVaultProperty -VaultId $vault.ID -SoftDeleteFeatureState "Disable"

		$vm = Create-VM $resourceGroupName $location
		$diskConfig = New-AzDiskConfig -SkuName $storageType -Location $location -CreateOption "Empty" -DiskSizeGB 32
		$dataDisk1 = New-AzDisk -DiskName "disk1" -Disk $diskConfig -ResourceGroupName $resourceGroupName
		$dataDisk2 = New-AzDisk -DiskName "disk2" -Disk $diskConfig -ResourceGroupName $resourceGroupName
		$dataDisk3 = New-AzDisk -DiskName "disk3" -Disk $diskConfig -ResourceGroupName $resourceGroupName

		$vm = Get-AzVM -Name $vm.Name -ResourceGroupName $resourceGroupName 
		$vm = Add-AzVMDataDisk -VM $vm -Name "disk1" -CreateOption "Attach" -ManagedDiskId $dataDisk1.Id -Lun 0
		$vm = Add-AzVMDataDisk -VM $vm -Name "disk2" -CreateOption "Attach" -ManagedDiskId $dataDisk2.Id -Lun 1
		$vm = Add-AzVMDataDisk -VM $vm -Name "disk3" -CreateOption "Attach" -ManagedDiskId $dataDisk3.Id -Lun 2

		Update-AzVM -VM $vm -ResourceGroupName $resourceGroupName

		$policy = Get-AzRecoveryServicesBackupProtectionPolicy `
			-VaultId $vault.ID -Name "DefaultPolicy";

		$arr = ("0", "1")

		Enable-AzRecoveryServicesBackupProtection `
		-VaultId $vault.ID `
		-Name $vm.Name `
		-Policy $policy `
		-InclusionDisksList $arr `
		-ResourceGroupName	$resourceGroupName;

		$item = Get-AzRecoveryServicesBackupItem `
			-VaultId $vault.ID `
			-BackupManagementType "AzureVM" `
			-WorkloadType "AzureVM";

		$arr = ("1", "2")

		Enable-AzRecoveryServicesBackupProtection `
		-VaultId $vault.ID `
		-Item $item `
		-ExclusionDisksList $arr;

		$item = Get-AzRecoveryServicesBackupItem `
			-VaultId $vault.ID `
			-BackupManagementType "AzureVM" `
			-WorkloadType "AzureVM";

		Assert-True { $item.DiskLunList.Count -eq 2}
		Assert-True { $item.DiskLunList[0] -eq 1}
		Assert-True { $item.DiskLunList[1] -eq 2}
		Assert-True { $item.IsInclusionList -eq $false}

		$backupJob = Backup-Item $vault $item
		$backupStartTime = $backupJob.StartTime.AddMinutes(-1);
		$backupEndTime = $backupJob.EndTime.AddMinutes(1);
		$rp = Get-AzRecoveryServicesBackupRecoveryPoint `
			-VaultId $vault.ID `
			-Item $item `
			-StartDate $backupStartTime `
			-EndDate $backupEndTime;

		$arr = ("0")

		$restoreJob = Restore-AzRecoveryServicesBackupItem `
			-VaultId $vault.ID `
			-VaultLocation $vault.Location `
			-RecoveryPoint $rp `
			-RestoreAsUnmanagedDisks `
			-StorageAccountName $saName `
			-StorageAccountResourceGroupName $resourceGroupName `
			-RestoreDiskList $arr | Wait-AzRecoveryServicesBackupJob -VaultId $vault.ID
		
		Assert-True { $restoreJob.Status -eq "Completed" }

		Disable-AzRecoveryServicesBackupProtection `
			-Item $item `
			-VaultId $vault.ID `
			-RemoveRecoveryPoints `
			-Force;

	}
	finally
	{
		cleanup-ResourceGroup $resourceGroupName
	}
}
