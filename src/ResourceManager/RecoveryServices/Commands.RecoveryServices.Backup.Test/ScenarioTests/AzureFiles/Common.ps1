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

# Setup Instructions:
# 1. Create a resource group
#New-AzureRmResourceGroup -Name $resourceGroupName -Location $location

# 2. Create a storage account and a recovery services vault
# New-AzureRmStorageAccount -ResourceGroupName $resourceGroupName -Name $saName -Location $location -SkuName $skuName
# New-AzureRmRecoveryServicesVault -Name $vaultName -ResourceGroupName $resourceGroupName -Location $Location

# 3. Create a file share in the storage account
# $storageAcct = Get-AzureRmStorageAccount -ResourceGroupName $resourceGroupName -Name $saName
# New-AzureStorageShare -Name $fileShareFriendlyName -Context $storageAcct.Context

# 4. Create a backup policy for file shares
# $vault = Get-AzureRmRecoveryServicesVault -ResourceGroupName $resourceGroupName -Name $vaultName
# $schedulePolicy = Get-AzureRmRecoveryServicesBackupSchedulePolicyObject -WorkloadType AzureFiles
# $retentionPolicy = Get-AzureRmRecoveryServicesBackupRetentionPolicyObject -WorkloadType AzureFiles
# $policy = New-AzureRmRecoveryServicesBackupProtectionPolicy -VaultId $vault.ID `
#		-Name $policyName `
#		-WorkloadType AzureFiles `
#		-RetentionPolicy $retentionPolicy `
#		-SchedulePolicy $schedulePolicy

 function Enable-Protection(
	$vault, 
	$fileShareName,
	$saName)
{
	$container = Get-AzureRmRecoveryServicesBackupContainer `
		-VaultId $vault.ID `
		-ContainerType AzureStorage `
		-FriendlyName $saName;

 	if ($container -eq $null)
	{
		$policy = Get-AzureRmRecoveryServicesBackupProtectionPolicy `
			-VaultId $vault.ID `
			-Name $policyName;
	
		Enable-AzureRmRecoveryServicesBackupProtection `
			-VaultId $vault.ID `
			-Policy $policy `
			-Name $fileShareName `
			-storageAccountName $saName | Out-Null
 		$container = Get-AzureRmRecoveryServicesBackupContainer `
			-VaultId $vault.ID `
			-ContainerType AzureStorage `
			-FriendlyName $saName;
	}
	
	$item = Get-AzureRmRecoveryServicesBackupItem `
		-VaultId $vault.ID `
		-Container $container `
		-WorkloadType AzureFiles `
		-Name $fileShareName
 	return $item
}
function Cleanup-Vault(
	$vault,
	$item,
	$container)
{
	# Disable Protection
	Disable-AzureRmRecoveryServicesBackupProtection `
		-VaultId $vault.ID `
		-Item $item `
		-RemoveRecoveryPoints `
		-Force;
	Unregister-AzureRmRecoveryServicesBackupContainer `
	-VaultId $vault.ID `
	-Container $container
}