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

function Get-AzureWorkloadContainer
{
	try
	{
		Get-AzureRmRecoveryServicesVault -ResourceGroupName 'sisi-RSV' -Name 'sisi-RSV-29-6' | Set-AzureRmRecoveryServicesVaultContext
		
		# VARIATION-1: Get All Containers with only mandatory parameters
		$containers = Get-AzureRmRecoveryServicesBackupContainer `
			-ContainerType AzureWorkload
	}
	finally
	{
		
	}
}

function Register-AzureWorkloadContainer
{
	try
	{
		Get-AzureRmRecoveryServicesVault -ResourceGroupName 'sisi-RSV' -Name 'sisi-RSV-29-6' | Set-AzureRmRecoveryServicesVaultContext
		
		# VARIATION-1: Get All Containers with only mandatory parameters
		$containers = Register-AzRecoveryServicesBackupContainer `
			-ResourceId "/subscriptions/da364f0f-307b-41c9-9d47-b7413ec45535/resourceGroups/sisi-RSV/providers/Microsoft.Compute/virtualMachines/sisi-vm" `
			-BackupManagementType AzureWorkload `
			-WorkloadType MSSQL
	}
	finally
	{
		
	}
}

function Unregister-AzureWorkloadContainer
{
	try
	{
		Get-AzureRmRecoveryServicesVault -ResourceGroupName 'sisi-RSV' -Name 'sisi-RSV-29-6' | Set-AzureRmRecoveryServicesVaultContext
		
		$containers = Get-AzureRmRecoveryServicesBackupContainer `
			-ContainerType AzureWorkload
		
		Unregister-AzureRmRecoveryServicesBackupContainer `
		-Container $containers[0]


	}
	finally
	{
		
	}
}