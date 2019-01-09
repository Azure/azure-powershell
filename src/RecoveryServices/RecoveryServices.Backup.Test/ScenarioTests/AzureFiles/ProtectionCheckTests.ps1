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

$location = "southeastasia"
$resourceGroupName = "pstestFSRG1bca8f8e"
$vaultName = "PSTestFSRSV1bca8f8e"
$fileShareFriendlyName = "pstestfs1bca8f8e"
$fileShareName = "AzureFileShare;pstestfs1bca8f8e"
$saName = "pstestsa1bca8f8e"
$skuName="Standard_LRS"
$policyName = "AFSBackupPolicy"
$storageAccountId = "/subscriptions/da364f0f-307b-41c9-9d47-b7413ec45535/resourceGroups/pstestFSRG1bca8f8e/providers/Microsoft.Storage/storageAccounts/pstestsa1bca8f8e"

# Setup Instructions:
# 1. Create a resource group
# New-AzResourceGroup -Name $resourceGroupName -Location $location

# 2. Create a storage account and a recovery services vault
# New-AzStorageAccount -ResourceGroupName $resourceGroupName -Name $saName -Location $location -SkuName $skuName
# New-AzRecoveryServicesVault -Name $vaultName -ResourceGroupName $resourceGroupName -Location $Location

# 3. Create a file share in the storage account
# $storageAcct = Get-AzStorageAccount -ResourceGroupName $resourceGroupName -Name $saName
# New-AzureStorageShare -Name $fileShareFriendlyName -Context $storageAcct.Context

# 4. Create a backup policy for file shares
# $vault = Get-AzRecoveryServicesVault -ResourceGroupName $resourceGroupName -Name $vaultName
# $schedulePolicy = Get-AzRecoveryServicesBackupSchedulePolicyObject -WorkloadType AzureFiles
# $retentionPolicy = Get-AzRecoveryServicesBackupRetentionPolicyObject -WorkloadType AzureFiles
# $policy = New-AzRecoveryServicesBackupProtectionPolicy -VaultId $vault.ID `
#		-Name $policyName `
#		-WorkloadType AzureFiles `
#		-RetentionPolicy $retentionPolicy `
#		-SchedulePolicy $schedulePolicy

function Test-AzureFSProtectionCheck
{
	try
	{
  $status = Get-AzRecoveryServicesBackupStatus `
			-ResourceId $storageAccountId `
			-ProtectableObjectName $fileShareFriendlyName `
			-Type AzureFiles

		Assert-NotNull $status
		Assert-False { $status.BackedUp }

		$vault = Get-AzRecoveryServicesVault -ResourceGroupName $resourceGroupName -Name $vaultName
		$item = Enable-Protection $vault $fileShareFriendlyName $saName
		
		$status = Get-AzRecoveryServicesBackupStatus `
			-ResourceId $storageAccountId `
			-ProtectableObjectName $fileShareFriendlyName `
			-Type AzureFiles

		Assert-NotNull $status
		Assert-True { $status.BackedUp }
		Assert-True { $status.VaultId -eq $vault.ID }

		$container = Get-AzRecoveryServicesBackupContainer `
			-VaultId $vault.ID `
			-ContainerType AzureStorage `
			-Status Registered `
			-FriendlyName $saName
	}
	finally
	{
		Cleanup-Vault $vault $item $container
	}
}