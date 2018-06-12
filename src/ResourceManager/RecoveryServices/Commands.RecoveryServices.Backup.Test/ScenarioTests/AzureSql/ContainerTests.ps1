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

function Test-AzureSqlGetContainers
{
	$vault = Get-AzureRmRecoveryServicesVault -ResourceGroupName "sqlpaasrg" -Name "sqlpaasrn";
	$containers = Get-AzureRmRecoveryServicesBackupContainer `
		-VaultId $vault.ID `
		-ContainerType "AzureSQL" `
		-BackupManagementType "AzureSQL";
	
	Assert-AreEqual $containers[0].Name "Sql;sqlpaasrg;sqlpaasserver";

	$namedContainer = Get-AzureRmRecoveryServicesBackupContainer `
		-VaultId $vault.ID `
		-ContainerType "AzureSQL" `
		-BackupManagementType "AzureSQL" `
		-Name "Sql;sqlpaasrg;sqlpaasserver";
	Assert-AreEqual $namedContainer.Name "Sql;sqlpaasrg;sqlpaasserver";
}

function Test-AzureSqlUnregisterContainer
{
	$vault = Get-AzureRmRecoveryServicesVault -ResourceGroupName "sqlpaasrg" -Name "sqlpaasrn";
	
	$container = Get-AzureRmRecoveryServicesBackupContainer `
		-VaultId $vault.ID `
		-ContainerType "AzureSQL" `
		-BackupManagementType "AzureSQL" `
		-Name "Sql;sqlpaasrg;sqlpaasserver";
	Assert-AreEqual $container.Name "Sql;sqlpaasrg;sqlpaasserver";

	Unregister-AzureRmRecoveryServicesBackupContainer -VaultId $vault.ID -Container $container;
	$container = Get-AzureRmRecoveryServicesBackupContainer `
		-VaultId $vault.ID `
		-ContainerType "AzureSQL" `
		-BackupManagementType "AzureSQL" `
		-Name "Sql;sqlpaasrg;sqlpaasserver";
	Assert-Null $container;
}