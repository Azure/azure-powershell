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

$containerName = "psbvtsqlvm"
$resourceGroupName = "pstestwlRG1bca8"
$vaultName = "pstestwlRSV1bca8"
$resourceId = "/subscriptions/38304e13-357e-405e-9e9a-220351dcce8c/resourceGroups/pscloudtestrg/providers/Microsoft.Compute/virtualMachines/psbvtsqlvm"
$filepath = "C:\"
$restoreAsFilesVault = "iaasvmsqlworkloadexistingvault1"
$resourceIdForFileDB = $resourceId
$policyName = "HourlyLogBackup"
$instanceName = "sqlinstance;mssqlserver"

function Test-AzureVmWorkloadCrossRegionRestore
{
	$resourceGroupName = "hiagarg"
	$vaultId = "/subscriptions/38304e13-357e-405e-9e9a-220351dcce8c/resourceGroups/hiagarg/providers/Microsoft.RecoveryServices/vaults/hiagaVault"
	$sourceDBName = "model"
	$location = "centraluseuap"
	$recoveryPointId = "174141832383313" # $rp[1].RecoveryPointId
	$itemName = "SQLDataBase;mssqlserver;model"
	$containerNameSubstr = "sql-pstest-vm1"


	$targetResourceGroup = "clitest-rg-donotuse"
	$targetVault = "clitest-vault-secondary-donotuse"
	$targetDBName = "model_restored_08_12_2023_1745"
	$overwrite = "Yes"

	try
	{   
		$secvault = Get-AzRecoveryServicesVault -ResourceGroupName $targetResourceGroup -Name $targetVault
		$item = Get-AzRecoveryServicesBackupItem -BackupManagementType AzureWorkload -WorkloadType MSSQL -VaultId $vaultId -UseSecondaryRegion | Where-Object { $_.Name -eq $itemName -and $_.ContainerName -match $containerNameSubstr}

		$rp = Get-AzRecoveryServicesBackupRecoveryPoint -Item $item[0] -VaultId $vaultId -UseSecondaryRegion -RecoveryPointId $recoveryPointId

		$seccontainer =  Get-AzRecoveryServicesBackupContainer -ContainerType AzureVMAppContainer -VaultId $secvault.ID
		$secitem = Get-AzRecoveryServicesBackupItem -Container $seccontainer -VaultId $secvault.ID -WorkloadType MSSQL

		$targetInstance = Get-AzRecoveryServicesBackupProtectableItem -WorkloadType MSSQL -ItemType SQLInstance -VaultId $secvault.ID		 

		$workloadConfig = Get-AzRecoveryServicesBackupWorkloadRecoveryConfig -RecoveryPoint $rp[0] -TargetItem $targetInstance -AlternateWorkloadRestore -VaultId $vaultId -TargetContainer $seccontainer[0] -UseSecondaryRegion

		$workloadConfig.RestoredDBName = $targetDBName
		$workloadConfig.OverwriteWLIfpresent = $overwrite

		$crrJob = Restore-AzRecoveryServicesBackupItem -WLRecoveryConfig $workloadConfig -VaultId $vaultID -RestoreToSecondaryRegion -VaultLocation $location
  
		while($crrJob.Status -eq "InProgress"){
			Start-TestSleep -Seconds 12
			$crrJob = Get-AzRecoveryServicesBackupJobDetail -VaultId $vaultId -UseSecondaryRegion -JobId $crrJob.JobId -VaultLocation $location
		}

		Assert-True {$crrJob.Status -eq "Completed"}
	}
	finally	
	{						
		# no cleanup
	}
}

function Test-AzureVmWorkloadCrossSubscriptionRestore
{
	$resourceGroupName = "sqlcontainer-pstest-rg"
	$vaultName = "sqlcontainer-pstest-vault"
	$location = "centraluseuap"

	try
	{
		$vault = Get-AzRecoveryServicesVault -ResourceGroupName $resourceGroupName -Name $vaultName
		Assert-True { $vault.Properties.RestoreSettings.CrossSubscriptionRestoreSettings.CrossSubscriptionRestoreState -eq "Enabled" }

		# Disable/Enable CSR state
		$vault = Update-AzRecoveryServicesVault -ResourceGroupName $resourceGroupName -Name $vaultName -CrossSubscriptionRestoreState Disabled
		Assert-True { $vault.Properties.RestoreSettings.CrossSubscriptionRestoreSettings.CrossSubscriptionRestoreState -eq "Disabled" }
	}
	finally	
	{						
		$vault = Update-AzRecoveryServicesVault -ResourceGroupName $resourceGroupName -Name $vaultName -CrossSubscriptionRestoreState Enabled
		Assert-True { $vault.Properties.RestoreSettings.CrossSubscriptionRestoreSettings.CrossSubscriptionRestoreState -eq "Enabled" }
	}
}

function Test-AzureVmWorkloadProtectableItem
{
	try
	{
		$vault = Get-AzRecoveryServicesVault -ResourceGroupName $resourceGroupName -Name $vaultName

		$container = Register-AzRecoveryServicesBackupContainer `
			-ResourceId $resourceId `
			-BackupManagementType AzureWorkload `
			-WorkloadType MSSQL `
			-VaultId $vault.ID `
			-Force
		Assert-AreEqual $container.Status "Registered"
		
		$protectableItems = Get-AzRecoveryServicesBackupProtectableItem `
			-VaultId $vault.ID `
			-Container $container `
			-WorkloadType "MSSQL";
		Assert-True { $protectableItems.ServerName -contains $containerName }

		$protectableItemsParentID = Get-AzRecoveryServicesBackupProtectableItem `
			-VaultId $vault.ID `
			-ParentID $protectableItems[0].Id;
		Assert-True { $protectableItemsParentID.ServerName -contains $containerName }

		$protectableItems = Get-AzRecoveryServicesBackupProtectableItem `
			-VaultId $vault.ID `
			-Container $container `
			-WorkloadType "MSSQL" `
			-ItemType "SQLInstance";
		Assert-True { $protectableItems.ProtectableItemType -contains "SQLInstance" }
		Assert-False { $protectableItems.ProtectableItemType -contains "SQLDataBase" }
		
		$protectableItems = Get-AzRecoveryServicesBackupProtectableItem `
			-VaultId $vault.ID `
			-Container $container `
			-WorkloadType "MSSQL" `
			-ItemType "SQLDataBase";
		Assert-True { $protectableItems.ProtectableItemType -contains "SQLDataBase" }
		Assert-False { $protectableItems.ProtectableItemType -contains "SQLInstance" }

		$protectableItems = Get-AzRecoveryServicesBackupProtectableItem `
			-VaultId $vault.ID `
			-Container $container `
			-WorkloadType "MSSQL" `
			-Name $instanceName `
			-ServerName $containerName;

		Assert-True { $protectableItems.ProtectableItemType -contains "SQLInstance" }
		Assert-True { $protectableItems.Count -eq 1}
	}
	finally
	{
		#Unregister container
		Unregister-AzRecoveryServicesBackupContainer `
			-VaultId $vault.ID `
			-Container $container
	}
}

function Test-AzureVmWorkloadInitializeProtectableItem
{
	try
	{
		$vault = Get-AzRecoveryServicesVault -ResourceGroupName $resourceGroupName -Name $vaultName
		
		$container = Register-AzRecoveryServicesBackupContainer `
			-ResourceId $resourceId `
			-BackupManagementType AzureWorkload `
			-WorkloadType MSSQL `
			-VaultId $vault.ID `
			-Force
		Assert-AreEqual $container.Status "Registered";

		$protectableItems = Get-AzRecoveryServicesBackupProtectableItem `
			-VaultId $vault.ID `
			-Container $container `
			-WorkloadType "MSSQL";
		Assert-True { $protectableItems.ServerName -contains $containerName }

		Initialize-AzRecoveryServicesBackupProtectableItem `
			-VaultId $vault.ID `
			-Container $container `
			-WorkloadType "MSSQL";

		$newprotectableItems = Get-AzRecoveryServicesBackupProtectableItem `
			-VaultId $vault.ID `
			-Container $container `
			-WorkloadType "MSSQL";
		Assert-True { $newprotectableItems.count -ge $protectableItems.count }
	}
	finally
	{
		#Unregister container
		Unregister-AzRecoveryServicesBackupContainer `
			-VaultId $vault.ID `
			-Container $container
	}
}

function Test-AzureVmWorkloadEnableProtectableItem
{
	try
	{
		$vault = Get-AzRecoveryServicesVault -ResourceGroupName $resourceGroupName -Name $vaultName
		
		$policy = Get-AzRecoveryServicesBackupProtectionPolicy `
			-VaultId $vault.ID `
			-Name $policyName
		
		$container = Register-AzRecoveryServicesBackupContainer `
			-ResourceId $resourceId `
			-BackupManagementType AzureWorkload `
			-WorkloadType MSSQL `
			-VaultId $vault.ID `
			-Force
		Assert-AreEqual $container.Status "Registered";

		$protectableItems = Get-AzRecoveryServicesBackupProtectableItem `
			-VaultId $vault.ID `
			-Container $container `
			-WorkloadType "MSSQL";

		Enable-AzRecoveryServicesBackupProtection `
			-VaultId $vault.ID `
			-Policy $policy `
			-ProtectableItem $protectableItems[1]

		$item = Get-AzRecoveryServicesBackupItem `
			-VaultId $vault.ID `
			-Container $container `
			-WorkloadType MSSQL;
		Assert-True { $item.Name -contains $protectableItems[1].Name }
		Assert-True { $item.LastBackupStatus -eq "IRPending" }
		Assert-True { $item.ProtectionPolicyName -eq $policyName }
	}
	finally
	{
		Cleanup-Vault $vault $item $container
	}
}

function Test-AzureVmWorkloadEnableAutoProtectableItem
{
	try
	{
		$vault = Get-AzRecoveryServicesVault -ResourceGroupName $resourceGroupName -Name $vaultName
		
		$policy = Get-AzRecoveryServicesBackupProtectionPolicy `
			-VaultId $vault.ID `
			-Name $policyName
		
		$container = Register-AzRecoveryServicesBackupContainer `
			-ResourceId $resourceId `
			-BackupManagementType AzureWorkload `
			-WorkloadType MSSQL `
			-VaultId $vault.ID `
			-Force
		Assert-AreEqual $container.Status "Registered";

		$protectableInstances = Get-AzRecoveryServicesBackupProtectableItem `
			-VaultId $vault.ID `
			-Container $container `
			-WorkloadType "MSSQL" `
			-ItemType "SQLInstance";
		
		$protectableItems = Get-AzRecoveryServicesBackupProtectableItem `
			-VaultId $vault.ID `
			-Container $container `
			-WorkloadType "MSSQL";

		Enable-AzRecoveryServicesBackupProtection `
			-VaultId $vault.ID `
			-Policy $policy `
			-ProtectableItem $protectableItems[1]

		$item = Get-AzRecoveryServicesBackupItem `
			-VaultId $vault.ID `
			-Container $container `
			-WorkloadType MSSQL;

		Assert-True { $item.Count -eq 1 }

		$enableResult = Get-AzRecoveryServicesBackupProtectableItem `
			-VaultId $vault.ID `
			-Container $container `
			-WorkloadType "MSSQL" `
			-ItemType "SQLInstance" | Enable-AzRecoveryServicesBackupAutoProtection `
				-VaultId $vault.ID `
				-BackupManagementType "AzureWorkload" `
				-WorkloadType "MSSQL" `
				-Policy $policy `
				-PassThru;

		Assert-AreEqual $enableResult $True

		$disableResult = Disable-AzRecoveryServicesBackupAutoProtection `
			-VaultId $vault.ID `
			-InputItem $protectableInstances[0] `
			-BackupManagementType "AzureWorkload" `
			-WorkloadType "MSSQL" `
			-PassThru;

		Assert-AreEqual $disableResult $True

		$items = Get-AzRecoveryServicesBackupItem `
			-VaultId $vault.ID `
			-Container $container `
			-WorkloadType MSSQL;
		
		Assert-True { $items.Count -eq 1 }

		foreach($protectedItem in $items)
		{
			Disable-AzureRmRecoveryServicesBackupProtection `
				-VaultId $vault.ID `
				-Item $protectedItem `
				-RemoveRecoveryPoints `
				-Force;
		}

		$item = Get-AzRecoveryServicesBackupItem `
			-VaultId $vault.ID `
			-Container $container `
			-WorkloadType MSSQL;

		Assert-True { $item.Count -eq 0 }
	}
	finally
	{
		#Unregister container
		Unregister-AzRecoveryServicesBackupContainer `
			-VaultId $vault.ID `
			-Container $container
	}
}

function Test-AzureVmWorkloadBackupProtectionItem
{
	$resourceGroupName = "hiagarg"
	$vaultName = "hiagaVault"	
	$sourceDBName = "master"
	$containerFriendlyName = "sql-pstest-vm1"

	try
	{   
		# test trigger adhoc backup
		$vault = Get-AzRecoveryServicesVault -ResourceGroupName $resourceGroupName -Name $vaultName
		$item = Get-AzRecoveryServicesBackupItem -BackupManagementType AzureWorkload -WorkloadType MSSQL -VaultId $vault.ID | Where-Object { $_.Name -match $sourceDBName -and $_.ContainerName -match $containerFriendlyName}

		$backupJob = Backup-AzRecoveryServicesBackupItem `
			-VaultId $vault.ID `
			-Item $item[0] `
			-BackupType "Full" | Wait-AzRecoveryServicesBackupJob -VaultId $vault.ID

		Assert-True { $backupJob.Status -eq "Completed" }
	}
	finally
	{
		# no cleanup
	}
}

function Test-AzureVmWorkloadGetRPs
{
	try
	{
		# Test 1: Get latest recovery point; should be only one
		$vault = Get-AzRecoveryServicesVault -ResourceGroupName $resourceGroupName -Name $vaultName
		$container = Register-AzRecoveryServicesBackupContainer `
			-ResourceId $resourceId `
			-BackupManagementType AzureWorkload `
			-WorkloadType MSSQL `
			-VaultId $vault.ID `
			-Force

		Enable-Protection $vault $container

		$item = Get-AzRecoveryServicesBackupItem `
			-VaultId $vault.ID `
			-Container $container `
			-WorkloadType MSSQL;

		$backupJob = Get-AzRecoveryServicesBackupItem `
			-VaultId $vault.ID `
			-Container $container `
			-WorkloadType MSSQL | Backup-AzRecoveryServicesBackupItem `
			-VaultId $vault.ID `
			-BackupType "Full" | Wait-AzRecoveryServicesBackupJob -VaultId $vault.ID

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

function Test-AzureVmWorkloadGetLogChains
{
	try
	{
		# Test 1: Get latest recovery point; should be only one
		$vault = Get-AzRecoveryServicesVault -ResourceGroupName $resourceGroupName -Name $vaultName
		$container = Register-AzRecoveryServicesBackupContainer `
			-ResourceId $resourceId `
			-BackupManagementType AzureWorkload `
			-WorkloadType MSSQL `
			-VaultId $vault.ID `
			-Force

		$policy = Get-AzRecoveryServicesBackupProtectionPolicy `
			-VaultId $vault.ID `
			-Name $policyName

		$protectableItems = Get-AzRecoveryServicesBackupProtectableItem `
			-VaultId $vault.ID `
			-Container $container `
			-WorkloadType "MSSQL";

		Enable-AzRecoveryServicesBackupProtection `
			-VaultId $vault.ID `
			-Policy $policy `
			-ProtectableItem $protectableItems[4]

		$item = Get-AzRecoveryServicesBackupItem `
			-VaultId $vault.ID `
			-Container $container `
			-WorkloadType MSSQL;

		$backupJob = Backup-AzRecoveryServicesBackupItem `
			-VaultId $vault.ID `
			-Item $item `
			-BackupType "Full" | Wait-AzRecoveryServicesBackupJob -VaultId $vault.ID

		$backupJob2 = Backup-AzRecoveryServicesBackupItem `
			-VaultId $vault.ID `
			-Item $item `
			-BackupType "Log" | Wait-AzRecoveryServicesBackupJob -VaultId $vault.ID

		$backupStartTime = $backupJob2.StartTime.AddMinutes(-10);
		$backupEndTime = $backupJob2.EndTime.AddMinutes(10);

		$recoveryLogChain = Get-AzRecoveryServicesBackupItem `
			-VaultId $vault.ID `
			-Container $container `
			-WorkloadType MSSQL | Get-AzRecoveryServicesBackupRecoveryLogChain `
			-VaultId $vault.ID `
			-StartDate $backupStartTime `
			-EndDate $backupEndTime;
	
		Assert-NotNull $recoveryLogChain[0];
	}
	finally
	{
		Cleanup-Vault $vault $item $container
	}
}
function Test-AzureVmWorkloadFullRestore
{
	try
	{
		$vault = Get-AzRecoveryServicesVault -ResourceGroupName $resourceGroupName -Name $vaultName
		$container = Register-AzRecoveryServicesBackupContainer `
			-ResourceId $resourceId `
			-BackupManagementType AzureWorkload `
			-WorkloadType MSSQL `
			-VaultId $vault.ID `
			-Force

		$policy = Get-AzRecoveryServicesBackupProtectionPolicy `
			-VaultId $vault.ID `
			-Name $policyName

		$protectableItems = Get-AzRecoveryServicesBackupProtectableItem `
			-VaultId $vault.ID `
			-Container $container `
			-WorkloadType "MSSQL" `
			-ItemType "SQLDataBase";

		$protectableInstances = Get-AzRecoveryServicesBackupProtectableItem `
			-VaultId $vault.ID `
			-Container $container `
			-WorkloadType "MSSQL" `
			-ItemType "SQLInstance";

		Enable-AzRecoveryServicesBackupProtection `
			-VaultId $vault.ID `
			-Policy $policy `
			-ProtectableItem $protectableItems[3];

		$item = Get-AzRecoveryServicesBackupItem `
			-VaultId $vault.ID `
			-Container $container `
			-WorkloadType MSSQL;

		$backupJob = Backup-AzRecoveryServicesBackupItem `
			-VaultId $vault.ID `
			-Item $item[0] `
			-BackupType "Full" | Wait-AzRecoveryServicesBackupJob -VaultId $vault.ID

		$backupStartTime = $backupJob.StartTime.AddMinutes(-1);
		$backupEndTime = $backupJob.EndTime.AddMinutes(1);

		$recoveryPoint = Get-AzRecoveryServicesBackupRecoveryPoint `
			-VaultId $vault.ID `
			-StartDate $backupStartTime `
			-EndDate $backupEndTime `
			-Item $item;

		$restoreJob1 = Get-AzRecoveryServicesBackupRecoveryPoint `
			-VaultId $vault.ID `
			-StartDate $backupStartTime `
			-EndDate $backupEndTime `
			-Item $item | Get-AzRecoveryServicesBackupWorkloadRecoveryConfig `
				-VaultId $vault.ID `
				-TargetItem $protectableInstances[0] `
				–AlternateWorkloadRestore | Restore-AzRecoveryServicesBackupItem `
					-VaultId $vault.ID | Wait-AzureRmRecoveryServicesBackupJob -VaultId $vault.ID
		
		Assert-True { $restoreJob1.Status -eq "Completed" }

		$restoreConfig2 = Get-AzRecoveryServicesBackupWorkloadRecoveryConfig `
			-VaultId $vault.ID `
			-RecoveryPoint $recoveryPoint[0] `
			–OriginalWorkloadRestore;

		Assert-NotNull $restoreConfig2

		$restoreJob2 = Restore-AzRecoveryServicesBackupItem `
			-VaultId $vault.ID `
			-WLRecoveryConfig $restoreConfig2 | Wait-AzureRmRecoveryServicesBackupJob -VaultId $vault.ID
		
		Assert-True { $restoreJob2.Status -eq "Completed" }
		
		## Log Restores
		$backupJob2 = Backup-AzRecoveryServicesBackupItem `
			-VaultId $vault.ID `
			-Item $item[0] `
			-BackupType "Full" | Wait-AzRecoveryServicesBackupJob -VaultId $vault.ID

		$backupJob3 = Backup-AzRecoveryServicesBackupItem `
			-VaultId $vault.ID `
			-Item $item[0] `
			-BackupType "Log" | Wait-AzRecoveryServicesBackupJob -VaultId $vault.ID

		$backupStartTime = $backupJob3.StartTime.AddMinutes(-1);
		$backupEndTime = $backupJob3.EndTime.AddMinutes(1);

		$recoveryLogChain = Get-AzRecoveryServicesBackupRecoveryLogChain `
			-VaultId $vault.ID `
			-StartDate $backupStartTime `
			-EndDate $backupEndTime `
			-Item $item[0];

		$restoreConfig3 = Get-AzRecoveryServicesBackupWorkloadRecoveryConfig `
			-VaultId $vault.ID `
			-PointInTime $recoveryLogChain[0].StartTime.AddMinutes(1) `
			-Item $item[0] `
			-TargetItem $protectableInstances[0] `
			–AlternateWorkloadRestore;

		Assert-NotNull $restoreConfig3

		$restoreJob3 = Restore-AzRecoveryServicesBackupItem `
			-VaultId $vault.ID `
			-WLRecoveryConfig $restoreConfig3 | Wait-AzureRmRecoveryServicesBackupJob -VaultId $vault.ID
		
		Assert-True { $restoreJob3.Status -eq "Completed" }

		$restoreConfig4 = Get-AzRecoveryServicesBackupWorkloadRecoveryConfig `
			-VaultId $vault.ID `
			-PointInTime $recoveryLogChain[0].StartTime.AddMinutes(1) `
			-Item $item[0] `
			–OriginalWorkloadRestore;

		Assert-NotNull $restoreConfig4

		$restoreJob4 = Restore-AzRecoveryServicesBackupItem `
			-VaultId $vault.ID `
			-WLRecoveryConfig $restoreConfig4 | Wait-AzureRmRecoveryServicesBackupJob -VaultId $vault.ID
		
		Assert-True { $restoreJob4.Status -eq "Completed" }
	}
	finally
	{
		Cleanup-Vault $vault $item $container
	}
}

function Test-AzureVmWorkloadFullRestoreWithFiles
{
	try
	{
		$vault = Get-AzRecoveryServicesVault -ResourceGroupName "psbvtrg" -Name "pssqlbvtvault"
		$container = Register-AzRecoveryServicesBackupContainer `
			-ResourceId $resourceIdForFileDB `
			-BackupManagementType AzureWorkload `
			-WorkloadType MSSQL `
			-VaultId $vault.ID `
			-Force

		$policy = Get-AzRecoveryServicesBackupProtectionPolicy `
			-VaultId $vault.ID `
			-Name $policyName

		$protectableItems = Get-AzRecoveryServicesBackupProtectableItem `
			-VaultId $vault.ID `
			-Container $container `
			-WorkloadType "MSSQL" `
			-ItemType "SQLDataBase";

		$protectableInstances = Get-AzRecoveryServicesBackupProtectableItem `
			-VaultId $vault.ID `
			-Container $container `
			-WorkloadType "MSSQL" `
			-ItemType "SQLInstance";

		Enable-AzRecoveryServicesBackupProtection `
			-VaultId $vault.ID `
			-Policy $policy `
			-ProtectableItem $protectableItems[4];

		$item = Get-AzRecoveryServicesBackupItem `
			-VaultId $vault.ID `
			-Container $container `
			-WorkloadType MSSQL;

		$backupJob = Backup-AzRecoveryServicesBackupItem `
			-VaultId $vault.ID `
			-Item $item[0] `
			-BackupType "Full" | Wait-AzRecoveryServicesBackupJob -VaultId $vault.ID

		$backupStartTime = $backupJob.StartTime.AddMinutes(-1);
		$backupEndTime = $backupJob.EndTime.AddMinutes(1);

		$recoveryPoint = Get-AzRecoveryServicesBackupRecoveryPoint `
			-VaultId $vault.ID `
			-StartDate $backupStartTime `
			-EndDate $backupEndTime `
			-Item $item;

		$restoreJob1 = Get-AzRecoveryServicesBackupRecoveryPoint `
			-VaultId $vault.ID `
			-StartDate $backupStartTime `
			-EndDate $backupEndTime `
			-Item $item | Get-AzRecoveryServicesBackupWorkloadRecoveryConfig `
				-VaultId $vault.ID `
				-TargetItem $protectableInstances[0] `
				–AlternateWorkloadRestore | Restore-AzRecoveryServicesBackupItem `
					-VaultId $vault.ID | Wait-AzureRmRecoveryServicesBackupJob -VaultId $vault.ID
		
		Assert-True { $restoreJob1.Status -eq "Completed" }
	}
	finally
	{
			Cleanup-Vault $vault $item $container
	}
}

function Test-AzureVmWorkloadRestoreAsFiles
{
	$vault = Get-AzRecoveryServicesVault -Name $restoreAsFilesVault
	
	$container = Get-AzRecoveryServicesBackupContainer `
		-VaultId $vault.ID `
		-ContainerType "AzureVMAppContainer";

	$item = Get-AzRecoveryServicesBackupItem `
		-VaultId $vault.ID `
		-BackupManagementType "AzureWorkload" `
		-WorkloadType "MSSQL";

	[datetime]$endtime = get-date -Year 2020 -Month 1 -Day 31 -Minute 35 -Hour 23 -Second 15 -Format "dddd MM/dd/yyyy HH:mm:ss Z"
	$endtime = $endtime.ToUniversalTime()
	[datetime]$starttime = $endtime.AddDays(-30)
	$starttime = $starttime.ToUniversalTime()

	$rp = Get-AzRecoveryServicesBackupRecoveryPoint -VaultId $vault.ID -Item $item -StartDate $starttime -EndDate $endtime
	$time = get-date -Year 2020 -Month 1 -Day 30 -Minute 5
	$config = Get-AzRecoveryServicesBackupWorkloadRecoveryConfig `
		-VaultId $vault.ID -PointInTime $time -Item $item -RestoreAsFiles `
		-FilePath $filepath -TargetContainer $container -FromFull $rp[3];

	$restorejob1 = Restore-AzRecoveryServicesBackupItem `
		-VaultId $vault.ID `
		-WLRecoveryConfig $config | Wait-AzureRmRecoveryServicesBackupJob -VaultId $vault.ID;

	Assert-True { $restorejob1.Status -eq "Completed" }

	$config = Get-AzRecoveryServicesBackupWorkloadRecoveryConfig `
		-VaultId $vault.ID -RecoveryPoint $rp[0] -Item $item -RestoreAsFiles `
		-FilePath $filepath -TargetContainer $container;

	$restorejob2 = Restore-AzRecoveryServicesBackupItem `
		-VaultId $vault.ID `
		-WLRecoveryConfig $config | Wait-AzureRmRecoveryServicesBackupJob -VaultId $vault.ID

	Assert-True { $restorejob2.Status -eq "Completed" }

	$config = Get-AzRecoveryServicesBackupWorkloadRecoveryConfig `
		-VaultId $vault.ID -PointInTime $time -Item $item -RestoreAsFiles `
		-FilePath $filepath -TargetContainer $container;

	$restorejob3 = Restore-AzRecoveryServicesBackupItem `
		-VaultId $vault.ID `
		-WLRecoveryConfig $config | Wait-AzureRmRecoveryServicesBackupJob -VaultId $vault.ID

	Assert-True { $restorejob3.Status -eq "Completed" }

}
