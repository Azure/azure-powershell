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

<#
.SYNOPSIS
Test Recovery Services Backup Vault
#>

function Test-AzureVMGetContainers
{
	$location = Get-ResourceGroupLocation
	$resourceGroupName = Create-ResourceGroup $location

	try
	{
		# Setup
		$vm = Create-VM $resourceGroupName $location
		$vault = Create-RecoveryServicesVault $resourceGroupName $location
		Enable-Protection $vault $vm
		
		Set-AzureRmRecoveryServicesVaultContext -Vault $vault;

		# VARIATION-1: Get All Containers with only mandatory parameters
		$containers = Get-AzureRmRecoveryServicesBackupContainer `
			-ContainerType AzureVM `
			-Status Registered;
		Assert-True { $containers.FriendlyName -contains $vm.Name }

		# VARIATION-2: Get Containers with friendly name filter
		$containers = Get-AzureRmRecoveryServicesBackupContainer `
			-ContainerType AzureVM `
			-Status Registered `
			-Name $vm.Name;
		Assert-True { $containers.FriendlyName -contains $vm.Name }

		# VARIATION-3: Get Containers with friendly name and resource group filters
		$containers = Get-AzureRmRecoveryServicesBackupContainer `
			-ContainerType AzureVM `
			-Status Registered `
			-Name $vm.Name `
			-ResourceGroupName $vm.ResourceGroupName;
		Assert-True { $containers.FriendlyName -contains $vm.Name }

		# VARIATION-4: Get Containers with resource group filter
		$containers = Get-AzureRmRecoveryServicesBackupContainer `
			-ContainerType AzureVM `
			-Status Registered `
			-ResourceGroupName $vm.ResourceGroupName;
		Assert-True { $containers.FriendlyName -contains $vm.Name }
	}
	finally
	{
		# Cleanup
		Cleanup-ResourceGroup $resourceGroupName
	}
}