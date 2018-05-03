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

function Test-AzureSqlGetItems
{
	# 1. Get the vault
	$vault = Get-AzureRmRecoveryServicesVault -ResourceGroupName "sqlpaasrg" -Name "sqlpaasrn";
	
	# 2. Set the vault context
	Set-AzureRmRecoveryServicesVaultContext -Vault $vault;
	
	# 3. Get the container
	$namedContainer = Get-AzureRmRecoveryServicesBackupContainer `
		-ContainerType "AzureSQL" `
		-BackupManagementType "AzureSQL" `
		-Name "Sql;sqlpaasrg;sqlpaasserver";
	Assert-AreEqual $namedContainer.Name "Sql;sqlpaasrg;sqlpaasserver";

	# VAR-1: Get all items for container
	$item = Get-AzureRmRecoveryServicesBackupItem `
		-Container $namedContainer -WorkloadType "AzureSQLDatabase";
	Assert-AreEqual $item.Name "dsName;satyay-sea-d1-fc1-catalog-2016-11-11-17-20;661f0942-d5b7-486a-b3cb-68f97d325a3c";

	# VAR-2: Get named item for container
	$item = Get-AzureRmRecoveryServicesBackupItem `
		-Container $namedContainer `
		-WorkloadType "AzureSQLDatabase" `
		-Name "dsName;satyay-sea-d1-fc1-catalog-2016-11-11-17-20;661f0942-d5b7-486a-b3cb-68f97d325a3c";
	Assert-AreEqual $item.Name "dsName;satyay-sea-d1-fc1-catalog-2016-11-11-17-20;661f0942-d5b7-486a-b3cb-68f97d325a3c";
}

function Test-AzureSqlDisableProtection
{
	#1. Get the vault
	$vault = Get-AzureRmRecoveryServicesVault -ResourceGroupName "sqlpaasrg" -Name "sqlpaasrn";
	
	# 2. Set the vault context
	Set-AzureRmRecoveryServicesVaultContext -Vault $vault;
	
	# 3. Get the container
	$namedContainer = Get-AzureRmRecoveryServicesBackupContainer `
		-ContainerType "AzureSQL" `
		-BackupManagementType "AzureSQL" `
		-Name "Sql;sqlpaasrg;sqlpaasserver";
	Assert-AreEqual $namedContainer.Name "Sql;sqlpaasrg;sqlpaasserver";

	# 4. Get named item for container
	$item = Get-AzureRmRecoveryServicesBackupItem `
		-Container $namedContainer `
		-WorkloadType "AzureSQLDatabase" `
		-Name "dsName;satyay-sea-d1-fc1-catalog-2016-11-11-17-20;661f0942-d5b7-486a-b3cb-68f97d325a3c";
	Assert-AreEqual $item.Name "dsName;satyay-sea-d1-fc1-catalog-2016-11-11-17-20;661f0942-d5b7-486a-b3cb-68f97d325a3c";

	$job = Disable-AzureRmRecoveryServicesBackupProtection `
		-Item $item -RemoveRecoveryPoints -Force;
}

function Test-AzureSqlGetRPs
{
	#Set vault context
	$vault = Get-AzureRmRecoveryServicesVault -ResourceGroupName "sqlpaasrg" -Name "sqlpaasrn";
	
	# 2. Set the vault context
	Set-AzureRmRecoveryServicesVaultContext -Vault $vault;
	
	# 3. Get the container
	$namedContainer = Get-AzureRmRecoveryServicesBackupContainer `
		-ContainerType "AzureSQL" `
		-BackupManagementType "AzureSQL" `
		-Name "Sql;sqlpaasrg;sqlpaasserver";
	Assert-AreEqual $namedContainer.Name "Sql;sqlpaasrg;sqlpaasserver";

	# Get named item for container
	$item = Get-AzureRmRecoveryServicesBackupItem `
		-Container $namedContainer `
		-WorkloadType "AzureSQLDatabase" `
		-Name "dsName;satyay-sea-d1-fc1-catalog-2016-11-11-17-20;661f0942-d5b7-486a-b3cb-68f97d325a3c";
	Assert-AreEqual $item.Name "dsName;satyay-sea-d1-fc1-catalog-2016-11-11-17-20;661f0942-d5b7-486a-b3cb-68f97d325a3c";

	$fixedStartDate = Get-Date -Date "2016-06-13 16:30:00Z"
	$startDate = $fixedStartDate.ToUniversalTime()
	$fixedEndDate = Get-Date -Date "2016-06-18 10:30:00Z"
	$endDate = $fixedEndDate.ToUniversalTime()
	
	$recoveryPoints = Get-AzureRMRecoveryServicesBackupRecoveryPoint `
		-Item $item[0] -StartDate $startDate -EndDate $endDate
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

