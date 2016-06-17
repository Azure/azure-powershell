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

function Test-GetItemScenario
{
	# 1. Get the vault
	$vault = Get-AzureRmRecoveryServicesVault -ResourceGroupName "RsvTestRG" -Name "PsTestRsVault";
	
	# 2. Set the vault context
	Set-AzureRmRecoveryServicesVaultContext -Vault $vault;
	
	# 3. Get the container
	$namedContainer = Get-AzureRmRecoveryServicesBackupContainer -ContainerType "AzureVM" -Status "Registered" -Name "mkheraniRMVM1";
	Assert-AreEqual $namedContainer.FriendlyName "mkheraniRMVM1";

	# VAR-1: Get all items for container
	$item = Get-AzureRmRecoveryServicesBackupItem -Container $namedContainer -WorkloadType "AzureVM";
	Assert-AreEqual $item.Name "iaasvmcontainerv2;mkheranirmvm1;mkheranirmvm1";

	# VAR-2: Get items for container with friendly name filter
	$item = Get-AzureRmRecoveryServicesBackupItem -Container $namedContainer -WorkloadType "AzureVM" -Name "mkheraniRMVM1";
	Assert-AreEqual $item.Name "iaasvmcontainerv2;mkheranirmvm1;mkheranirmvm1";

	# VAR-3: Get items for container with ProtectionStatus filter
	$item = Get-AzureRmRecoveryServicesBackupItem -Container $namedContainer -WorkloadType "AzureVM" -ProtectionStatus "Healthy";
	Assert-AreEqual $item.Name "iaasvmcontainerv2;mkheranirmvm1;mkheranirmvm1";

	# VAR-4: Get items for container with Status filter
	$item = Get-AzureRmRecoveryServicesBackupItem -Container $namedContainer -WorkloadType "AzureVM" -ProtectionState "IRPending";
	Assert-AreEqual $item.Name "iaasvmcontainerv2;mkheranirmvm1;mkheranirmvm1";

	# VAR-5: Get items for container with friendly name and ProtectionStatus filters
	$item = Get-AzureRmRecoveryServicesBackupItem -Container $namedContainer -WorkloadType "AzureVM" -Name "mkheraniRMVM1" -ProtectionStatus "Healthy";
	Assert-AreEqual $item.Name "iaasvmcontainerv2;mkheranirmvm1;mkheranirmvm1";

	# VAR-6: Get items for container with friendly name and Status filters
	$item = Get-AzureRmRecoveryServicesBackupItem -Container $namedContainer -WorkloadType "AzureVM" -Name "mkheraniRMVM1" -ProtectionState "IRPending";
	Assert-AreEqual $item.Name "iaasvmcontainerv2;mkheranirmvm1;mkheranirmvm1";

	# VAR-7: Get items for container with Status and ProtectionStatus filters
	$item = Get-AzureRmRecoveryServicesBackupItem -Container $namedContainer -WorkloadType "AzureVM" -ProtectionState "IRPending" -ProtectionStatus "Healthy";
	Assert-AreEqual $item.Name "iaasvmcontainerv2;mkheranirmvm1;mkheranirmvm1";

	# VAR-8: Get items for container with friendly name, Status and ProtectionStatus filters
	$item = Get-AzureRmRecoveryServicesBackupItem -Container $namedContainer -WorkloadType "AzureVM" -Name "mkheraniRMVM1" -ProtectionState "IRPending" -ProtectionStatus "Healthy";
	Assert-AreEqual $item.Name "iaasvmcontainerv2;mkheranirmvm1;mkheranirmvm1";
}

function Test-EnableAzureVMProtectionScenario
{
	$vault = Get-AzureRmRecoveryServicesVault -ResourceGroupName "RsvTestRG" -Name "PsTestRsVault";
	Set-AzureRmRecoveryServicesVaultContext -Vault $vault;

	$policy = Get-AzureRmRecoveryServicesBackupProtectionPolicy -Name "DefaultPolicy";

	$job = Enable-AzureRmRecoveryServicesBackupProtection -Name "mkheranirmvm1" -ResourceGroupName "mkheranirmvm1" -Policy $policy;
	Assert-AreEqual $job.Status "Completed";

}

function Test-DisableAzureVMProtectionScenario
{
	$vault = Get-AzureRmRecoveryServicesVault -ResourceGroupName "RsvTestRG" -Name "PsTestRsVault";
	
	# 2. Set the vault context
	Set-AzureRmRecoveryServicesVaultContext -Vault $vault;
	
	# 3. Get the container
	$namedContainer = Get-AzureRmRecoveryServicesBackupContainer -ContainerType "AzureVM" -Status "Registered" -Name "mkheraniRMVM1";
	Assert-AreEqual $namedContainer.FriendlyName "mkheraniRMVM1";

	# VAR-1: Get all items for container
	$item = Get-AzureRmRecoveryServicesBackupItem -Container $namedContainer -WorkloadType "AzureVM";
	Assert-AreEqual $item.Name "iaasvmcontainerv2;mkheranirmvm1;mkheranirmvm1";

	$job = Disable-AzureRmRecoveryServicesBackupProtection -Item $item -RemoveRecoveryPoints -Force;
	Assert-AreEqual $job.Status "Completed";
}

function Test-GetAzureVMRecoveryPointsScenario
{
	#Set vault context
		$vault = Get-AzureRmRecoveryServicesVault -ResourceGroupName "RsvTestRG" -Name "PsTestRsVault";
	
	# 2. Set the vault context
	Set-AzureRmRecoveryServicesVaultContext -Vault $vault;
	
	# 3. Get the container
	$namedContainer = Get-AzureRmRecoveryServicesBackupContainer -ContainerType "AzureVM" -Status "Registered" -Name "mkheraniRMVM1";
	Assert-AreEqual $namedContainer.FriendlyName "mkheraniRMVM1";

	# VAR-1: Get all items for container
	$item = Get-AzureRmRecoveryServicesBackupItem -Container $namedContainer -WorkloadType "AzureVM";
	$fixedStartDate = Get-Date -Date "2016-04-13 22:00:00"
	$startDate = $fixedStartDate.ToUniversalTime()
	$fixedEndDate = Get-Date -Date "2016-04-18 16:00:00"
	$endDate = $fixedEndDate.ToUniversalTime()

	
	$recoveryPoints = Get-AzureRMRecoveryServicesBackupRecoveryPoint -Item $item[0] -StartDate $startDate -EndDate $endDate
	if (!($recoveryPoints -eq $null))
	{
		foreach($recoveryPoint in $recoveryPoints)
		{
			Assert-NotNull $recoveryPoint.RecoveryPointTime 'RecoveryPointTime should not be null'
			Assert-NotNull $recoveryPoint.RecoveryPointType 'RecoveryPointType should not be null'
			Assert-NotNull $recoveryPoint.Name  'RecoveryPointId should not be null'
		}
	}
}

function Test-RestoreAzureVMRItemScenario
{
	#Set vault context
	$vault = Get-AzureRmRecoveryServicesVault -ResourceGroupName "shankcanaryrg" -Name "shankcanary2";
	
	# 2. Set the vault context
	Set-AzureRmRecoveryServicesVaultContext -Vault $vault;
	
	# 3. Get the container
	$namedContainer = Get-AzureRmRecoveryServicesBackupContainer -ContainerType "AzureVM" -Status "Registered" -Name "pra-vm2";
	Assert-AreEqual $namedContainer.FriendlyName "pra-vm2";

	# VAR-1: Get all items for container
	$item = Get-AzureRmRecoveryServicesBackupItem -Container $namedContainer -WorkloadType "AzureVM";

	$recoveryPoints = Get-AzureRMRecoveryServicesBackupRecoveryPoint -Item $item[0] -RecoveryPointId "28805629667760";
	
	$job = Restore-AzureRMRecoveryServicesBackupItem -RecoveryPoint $recoveryPoints[0] -StorageAccountName shraccanseastorv2 -StorageAccountResourceGroupName shraccanrg

	Assert-NotNull $job;
}

function Test-BackupItemScenario
{
	# 1. Get the vault
	$vault = Get-AzureRmRecoveryServicesVault -ResourceGroupName "RsvTestRG" -Name "PsTestRsVault";

	# 2. Set the vault context
	Set-AzureRmRecoveryServicesVaultContext -Vault $vault;
	
	# 3. Get the container
	$namedContainer = Get-AzureRmRecoveryServicesBackupContainer -ContainerType "AzureVM" -Status "Registered" -Name "mkheraniRMVM1";
	Assert-AreEqual $namedContainer.FriendlyName "mkheraniRMVM1";

	# 4: Get the item
	$item = Get-AzureRmRecoveryServicesBackupItem -Container $namedContainer -WorkloadType "AzureVM";
	Assert-AreEqual $item.Name "iaasvmcontainerv2;mkheranirmvm1;mkheranirmvm1";

	# 5: Trigger backup
	$job = Backup-AzureRmRecoveryServicesBackupItem -Item $item;
	Assert-NotNull $job;
}