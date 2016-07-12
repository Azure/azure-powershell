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

function Test-GetAzureSqlContainer
{
	$vault = Get-AzureRmRecoveryServicesVault -ResourceGroupName "RsvTestRG" -Name "RsvTestRN";
	Set-AzureRmRecoveryServicesVaultContext -Vault $vault;
	$containers = Get-AzureRmRecoveryServicesBackupContainer `
		-ContainerType "AzureSQL" -BackupManagementType "AzureSQL";
	
	Assert-AreEqual $containers[0].Name "Sql;testRG;ContosoServer";

	$namedContainer = Get-AzureRmRecoveryServicesBackupContainer `
		-ContainerType "AzureSQL" `
		-BackupManagementType "AzureSQL" `
		-Name "Sql;testRG;ContosoServer";
	Assert-AreEqual $namedContainer.Name "Sql;testRG;ContosoServer";
}

function Test-UnregisterAzureSqlContainer
{
	$vault = Get-AzureRmRecoveryServicesVault -ResourceGroupName "RsvTestRG" -Name "RsvTestRN";
	Set-AzureRmRecoveryServicesVaultContext -Vault $vault;
	
	$container = Get-AzureRmRecoveryServicesBackupContainer `
		-ContainerType "AzureSQL" `
		-BackupManagementType "AzureSQL" `
		-Name "Sql;testRG;ContosoServer";
	Assert-AreEqual $container.Name "Sql;testRG;ContosoServer";

	Unregister-AzureRmRecoveryServicesBackupContainer -Container $container;
	$container = Get-AzureRmRecoveryServicesBackupContainer `
		-ContainerType "AzureSQL" `
		-BackupManagementType "AzureSQL" `
		-Name "Sql;testRG;ContosoServer";
	Assert-Null $container;
}