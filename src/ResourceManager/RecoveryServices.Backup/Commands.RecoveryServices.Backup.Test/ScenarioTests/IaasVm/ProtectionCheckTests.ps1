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

function Test-AzureVMProtectionCheck
{
	$location = Get-ResourceGroupLocation
	$resourceGroupName = Create-ResourceGroup $location

	try
	{
		# Setup
		$vm = Create-GalleryVM $resourceGroupName $location

		$status = Get-AzureRmRecoveryServicesBackupStatus `
			-Name $vm.Name `
			-ResourceGroupName $vm.ResourceGroupName `
			-Type $vm.Type

		Assert-Null $status

		$vault = Create-RecoveryServicesVault $resourceGroupName $location
		Enable-Protection $vault $vm
		
		$checkVault = Get-AzureRmRecoveryServicesBackupStatus -ResourceId $vm.Id
		Assert-NotNull $checkVault
		Assert-True { $vault.Name -eq $checkVault.Name }
		Assert-True { $vault.ResourceGroupName -eq $checkVault.ResourceGroupName }

		Delete-Vault $vault

		$status = Get-AzureRmRecoveryServicesBackupStatus -ResourceId $vm.Id

		Assert-Null $status
	}
	finally
	{
		# Cleanup
		Cleanup-ResourceGroup $resourceGroupName
	}
}