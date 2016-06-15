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

function Test-GetAzureSqlItemScenario
{
	# 1. Get the vault
	$vault = Get-AzureRmRecoveryServicesVault -ResourceGroupName "RsvTestRG" -Name "PsTestRsVault";
	
	# 2. Set the vault context
	Set-AzureRmRecoveryServicesVaultContext -Vault $vault;
	
	# 3. Get the container
	$namedContainer = Get-AzureRmRecoveryServicesBackupContainer -ContainerType "AzureSQL" -BackupManagementType "AzureSQL" -Name "Sql;testRG;ContosoServer";
	Assert-AreEqual $namedContainer.FriendlyName "Sql;testRG;ContosoServer";

	# VAR-1: Get all items for container
	$item = Get-AzureRmRecoveryServicesBackupItem -Container $namedContainer -WorkloadType "AzureSqlDb";
	Assert-AreEqual $item.Name "iaasvmcontainerv2;mkheranirmvm1;mkheranirmvm1";

	# VAR-2: Get named item for container
	$item = Get-AzureRmRecoveryServicesBackupItem -Container $namedContainer -WorkloadType "AzureSqlDb" -Name "iaasvmcontainerv2;mkheranirmvm1;mkheranirmvm1";
	Assert-AreEqual $item.Name "iaasvmcontainerv2;mkheranirmvm1;mkheranirmvm1";
}

function Test-DisableAzureSqlProtectionScenario
{
	$vault = Get-AzureRmRecoveryServicesVault -ResourceGroupName "RsvTestRG" -Name "PsTestRsVault";
	
	# 2. Set the vault context
	Set-AzureRmRecoveryServicesVaultContext -Vault $vault;
	
	# 3. Get the container
	$namedContainer = Get-AzureRmRecoveryServicesBackupContainer -ContainerType "AzureVM" -Status "Registered" -Name "mkheraniRMVM1";
	Assert-AreEqual $namedContainer.FriendlyName "mkheraniRMVM1";

	# Get named item for container
	$item = Get-AzureRmRecoveryServicesBackupItem -Container $namedContainer -WorkloadType "AzureSqlDb" -Name "iaasvmcontainerv2;mkheranirmvm1;mkheranirmvm1";
	Assert-AreEqual $item.Name "iaasvmcontainerv2;mkheranirmvm1;mkheranirmvm1";

	$job = Disable-AzureRmRecoveryServicesBackupProtection -Item $item;
	Assert-AreEqual $job.Status "Completed";
}

function Test-GetAzureSqlRecoveryPointsScenario
{
	#Set vault context
		$vault = Get-AzureRmRecoveryServicesVault -ResourceGroupName "RsvTestRG" -Name "PsTestRsVault";
	
	# 2. Set the vault context
	Set-AzureRmRecoveryServicesVaultContext -Vault $vault;
	
	# 3. Get the container
	$namedContainer = Get-AzureRmRecoveryServicesBackupContainer -ContainerType "AzureVM" -Status "Registered" -Name "mkheraniRMVM1";
	Assert-AreEqual $namedContainer.FriendlyName "mkheraniRMVM1";

	# Get named item for container
	$item = Get-AzureRmRecoveryServicesBackupItem -Container $namedContainer -WorkloadType "AzureSqlDb" -Name "iaasvmcontainerv2;mkheranirmvm1;mkheranirmvm1";
	Assert-AreEqual $item.Name "iaasvmcontainerv2;mkheranirmvm1;mkheranirmvm1";

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

