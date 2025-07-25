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
	$location = "centraluseuap" # "southeastasia"
	$resourceGroupName = "iaasvm-pstest-rg" # Create-ResourceGroup $location
	$vaultName = "iaasvm-pstest-vault"
	$vmName = "iaasvm-pstest-vm"

	try
	{
		# Setup
		$vm = Get-AzVM -ResourceGroupName $resourceGroupName -Name $vmName  # Create-VM $resourceGroupName $location
		$vault =  Get-AzRecoveryServicesVault -ResourceGroupName $resourceGroupName -Name $vaultName # Create-RecoveryServicesVault $resourceGroupName $location
		Set-AzRecoveryServicesVaultProperty -VaultId $vault.ID -SoftDeleteFeatureState "Disable"
		$item = Enable-Protection $vault $vm
		
		# VARIATION-1: Get All Containers with only mandatory parameters
		$containers = Get-AzRecoveryServicesBackupContainer `
			-VaultId $vault.ID `
			-ContainerType AzureVM;
		Assert-True { $containers.FriendlyName -contains $vm.Name }

		# VARIATION-2: Get Containers with friendly name filter
		$containers = Get-AzRecoveryServicesBackupContainer `
			-VaultId $vault.ID `
			-ContainerType AzureVM `
			-FriendlyName $vm.Name;
		Assert-True { $containers.FriendlyName -contains $vm.Name }

		# VARIATION-3: Get Containers with friendly name and resource group filters
		$containers = Get-AzRecoveryServicesBackupContainer `
			-VaultId $vault.ID `
			-ContainerType AzureVM `
			-FriendlyName $vm.Name `
			-ResourceGroupName $vm.ResourceGroupName;
		Assert-True { $containers.FriendlyName -contains $vm.Name }

		# VARIATION-4: Get Containers with resource group filter
		$containers = Get-AzRecoveryServicesBackupContainer `
			-VaultId $vault.ID `
			-ContainerType AzureVM `
			-ResourceGroupName $vm.ResourceGroupName;
		Assert-True { $containers.FriendlyName -contains $vm.Name }
	}
	finally
	{
		# Cleanup
		# Cleanup-ResourceGroup $resourceGroupName

		#disable protection with RemoveRecoveryPoints
		Disable-AzRecoveryServicesBackupProtection -Item $item -RemoveRecoveryPoints -VaultId $vault.ID -Force

		# enable soft delete 
		Set-AzRecoveryServicesVaultProperty -SoftDeleteFeatureState Enable -VaultId $vault.ID
	}
}