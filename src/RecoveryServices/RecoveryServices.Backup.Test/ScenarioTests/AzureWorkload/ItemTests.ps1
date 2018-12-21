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

function Test-AzureVmWorkloadProtectableItem
{
	try
	{
		Get-AzureRmRecoveryServicesVault -ResourceGroupName 'shracrg' -Name 'shracsql' | Set-AzureRmRecoveryServicesVaultContext
		$items = Get-AzRecoveryServicesBackupProtectableItem -ProtectableItemType "SQLDataBase"
	}
	finally
	{
	
	}
}

function Test-AzureVmWorkloadProtectedItem
{
	try
	{
		Get-AzureRmRecoveryServicesVault -ResourceGroupName 'shracrg' -Name 'shracsql' | Set-AzureRmRecoveryServicesVaultContext
		$items = Get-AzRecoveryServicesBackupItem -BackupManagementType "AzureWorkload" -WorkloadType MSSQL
	}
	finally
	{
	
	}
}

function Test-AzureVmWorkloadNewProtectableItem
{
	try
	{
		Get-AzureRmRecoveryServicesVault -ResourceGroupName 'shracrg' -Name 'shracsql' | Set-AzureRmRecoveryServicesVaultContext
		$items = New-AzRecoveryServicesBackupProtectableItem -WorkloadType MSSQL
	}
	finally
	{
	
	}
}