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
	$vault = Get-AzureRmRecoveryServicesVault -ResourceGroupName "pstestrg" -Name "pstestrsvault";
	Set-AzureRmRecoveryServicesVaultContext -Vault $vault;
	
	$namedContainer = Get-AzureRmRecoveryServicesContainer -ContainerType "AzureVM" -Status "Registered" -Name "pstestv2vm1";
	Assert-AreEqual $namedContainer.FriendlyName "pstestv2vm1";

	$item = Get-AzureRmRecoveryServices=Item -Container $namedContainer -WorkloadType "AzureVM";
	echo $item.Name;
}

function Test-EnableAzureVMProtectionScenario
{
	$vault = Get-AzureRmRecoveryServicesVault -ResourceGroupName "phaniktRSV" -Name "phaniktRs1";
	Set-AzureRmRecoveryServicesVaultContext -Vault $vault;

	$policy = Get-AzureRmRecoveryServicesBackupProtectionPolicy -Name "pwtest1"	

	$job = Enable-AzureRmRecoveryServicesBackupProtection -Name "mylinux1" -ResourceGroupName "mylinux1"  -WorkloadType "AzureVM" -Policy $policy;
	Assert-AreEqual $job.Status "Completed";

}

function Test-DisableAzureVMProtectionScenario
{
	$vault = Get-AzureRmRecoveryServicesVault -ResourceGroupName "phaniktRSV" -Name "phaniktRs1";
	Set-AzureRmRecoveryServicesVaultContext -Vault $vault;
	
	$namedContainer = Get-AzureRmRecoveryServicesContainer -ContainerType "AzureVM" -Status "Registered" -Name "mylinux1";
	Assert-AreEqual $namedContainer.FriendlyName "mylinux1";

	$item = Get-AzureRmRecoveryServicesBackupItem -Container $namedContainer -WorkloadType "AzureVM";

	$job = Disable-AzureRmRecoveryServicesBackupProtection -Item $item -Force;
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
	$rps = Get-AzureRMRecoveryServicesRecoveryPoint -Item $item -StartDate $startDate -EndDate $endDate
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
	$rps = Get-AzureRMRecoveryServicesRecoveryPoint -Item $item -StartDate $startDate -EndDate $endDate
	
	$job = Restore-AzureRMRecoveryServicesBackupItem -RecoveryPoint $rps[0] -StorageAccountName mkheranirestorestrtest -StorageAccountResourceGroupName mkheranirestorestrtest

	Assert-AreEqual $job.Status "Completed";
}

function Test-BackupItemScenario
{
	$vault = Get-AzureRmRecoveryServicesVault -ResourceGroupName "pstestrg" -Name "pstestrsvault";
	Set-AzureRmRecoveryServicesVaultContext -Vault $vault;
	
	$namedContainer = Get-AzureRmRecoveryServicesBackupContainer -ContainerType "AzureVM" -Status "Registered" -Name "pstestv2vm1";
	Assert-AreEqual $namedContainer.FriendlyName "pstestv2vm1";

	$item = Get-AzureRmRecoveryServicesBackupItem -Container $namedContainer -WorkloadType "AzureVM";
	echo $item.Name;

	$job = Backup-AzureRmRecoveryServicesItem -Item $item;
	Assert-NotNull $job;
}