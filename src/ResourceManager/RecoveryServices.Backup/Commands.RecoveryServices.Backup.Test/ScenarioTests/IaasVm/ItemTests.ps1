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
	$item = Get-AzureRmRecoveryServicesBackupItem -Container $namedContainer -WorkloadType "AzureVM" -Status "IRPending";
	Assert-AreEqual $item.Name "iaasvmcontainerv2;mkheranirmvm1;mkheranirmvm1";

	# VAR-5: Get items for container with friendly name and ProtectionStatus filters
	$item = Get-AzureRmRecoveryServicesBackupItem -Container $namedContainer -WorkloadType "AzureVM" -Name "mkheraniRMVM1" -ProtectionStatus "Healthy";
	Assert-AreEqual $item.Name "iaasvmcontainerv2;mkheranirmvm1;mkheranirmvm1";

	# VAR-6: Get items for container with friendly name and Status filters
	$item = Get-AzureRmRecoveryServicesBackupItem -Container $namedContainer -WorkloadType "AzureVM" -Name "mkheraniRMVM1" -Status "IRPending";
	Assert-AreEqual $item.Name "iaasvmcontainerv2;mkheranirmvm1;mkheranirmvm1";

	# VAR-7: Get items for container with Status and ProtectionStatus filters
	$item = Get-AzureRmRecoveryServicesBackupItem -Container $namedContainer -WorkloadType "AzureVM" -Status "IRPending" -ProtectionStatus "Healthy";
	Assert-AreEqual $item.Name "iaasvmcontainerv2;mkheranirmvm1;mkheranirmvm1";

	# VAR-8: Get items for container with friendly name, Status and ProtectionStatus filters
	$item = Get-AzureRmRecoveryServicesBackupItem -Container $namedContainer -WorkloadType "AzureVM" -Name "mkheraniRMVM1" -Status "IRPending" -ProtectionStatus "Healthy";
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
	$vault = Get-AzureRmRecoveryServicesVault -ResourceGroupName "phaniktRSV" -Name "phaniktRs1";
	Set-AzureRmRecoveryServicesVaultContext -Vault $vault;

	$namedContainer = Get-AzureRmRecoveryServicesBackupContainer -ContainerType "AzureVM" -Status "Registered" -Name "mylinux1";
	Assert-AreEqual $namedContainer.FriendlyName "mylinux1";

	$item = Get-AzureRmRecoveryServicesBackupItem -Container $namedContainer -WorkloadType "AzureVM";
	$startDate = (Get-Date).AddDays(-7)
	$endDate = Get-Date
	$rps = Get-AzureRMRecoveryServicesBackupRecoveryPoint -Item $item -StartDate $startDate -EndDate $endDate
	Assert-NotNull "RPList should not be null"
}

function Test-RestoreAzureVMRItemScenario
{
	#Set vault context
	$vault = Get-AzureRmRecoveryServicesVault -ResourceGroupName "phaniktRSV" -Name "phaniktRs1";
	Set-AzureRmRecoveryServicesVaultContext -Vault $vault;

	$namedContainer = Get-AzureRmRecoveryServicesBackupContainer -ContainerType "AzureVM" -Status "Registered" -Name "mylinux1";
	Assert-AreEqual $namedContainer.FriendlyName "mylinux1";

	$item = Get-AzureRmRecoveryServicesBackupItem -Container $namedContainer -WorkloadType "AzureVM";
	$startDate = (Get-Date).AddDays(-7)
	$endDate = Get-Date
	$rps = Get-AzureRMRecoveryServicesBackupRecoveryPoint -Item $item -StartDate $startDate -EndDate $endDate
	
	$job = Restore-AzureRMRecoveryServicesBackupItem -RecoveryPoint $rps[0] -StorageAccountName mkheranirestorestrtest -StorageAccountResourceGroupName mkheranirestorestrtest

	Assert-AreEqual $job.Status "Completed";
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