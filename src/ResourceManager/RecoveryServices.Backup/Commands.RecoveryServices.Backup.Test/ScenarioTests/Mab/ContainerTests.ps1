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

function Test-MabGetContainers
{
	$vault = Get-AzureRmRecoveryServicesVault -ResourceGroupName "pstestrg" -Name "pstestrsvault";
	Set-AzureRmRecoveryServicesVaultContext -Vault $vault;
	$containers = Get-AzureRmRecoveryServicesBackupContainer -ContainerType "Windows" -BackupManagementType "MARS";
	
	Assert-AreEqual $containers[0].FriendlyName "ADIT-PC.FAREAST.CORP.MICROSOFT.COM";

	$namedContainer = Get-AzureRmRecoveryServicesBackupContainer -ContainerType "Windows" -BackupManagementType "MARS" -Name "ADIT-PC.FAREAST.CORP.MICROSOFT.COM";
	Assert-AreEqual $namedContainer.FriendlyName "ADIT-PC.FAREAST.CORP.MICROSOFT.COM";
}

function Test-MabUnregisterContainer
{
	$vault = Get-AzureRmRecoveryServicesVault -ResourceGroupName "pstestrg" -Name "pstestrsvault";
	Set-AzureRmRecoveryServicesVaultContext -Vault $vault;
	
	$container = Get-AzureRmRecoveryServicesBackupContainer -ContainerType "Windows" -BackupManagementType "MARS" -Name "ADIT-PC.FAREAST.CORP.MICROSOFT.COM";
	Assert-AreEqual $container.FriendlyName "ADIT-PC.FAREAST.CORP.MICROSOFT.COM";

	Unregister-AzureRmRecoveryServicesBackupContainer -Container $container;
	$container = Get-AzureRmRecoveryServicesBackupContainer -ContainerType "Windows" -BackupManagementType "MARS" -Name "ADIT-PC.FAREAST.CORP.MICROSOFT.COM";
	Assert-Null $container;
}