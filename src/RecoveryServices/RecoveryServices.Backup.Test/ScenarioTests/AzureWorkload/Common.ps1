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

$containerName = "pstestwlvm1bca8"
$resourceGroupName = "pstestwlRG1bca8"
$vaultName = "pstestwlRSV1bca8"
$resourceId = "/subscriptions/da364f0f-307b-41c9-9d47-b7413ec45535/resourceGroups/pstestwlRG1bca8/providers/Microsoft.Compute/virtualMachines/pstestwlvm1bca8"
$policyName = "HourlyLogBackup"

 function Enable-Protection(
	$vault,
	$container)
{
	$policy = Get-AzRecoveryServicesBackupProtectionPolicy `
		-VaultId $vault.ID `
		-Name $policyName

	$protectableItems = Get-AzRecoveryServicesBackupProtectableItem `
		-VaultId $vault.ID `
		-Container $container `
		-WorkloadType "MSSQL";

	Enable-AzRecoveryServicesBackupProtection `
		-VaultId $vault.ID `
		-Policy $policy `
		-ProtectableItem $protectableItems[1]

	$item = Get-AzRecoveryServicesBackupItem `
		-VaultId $vault.ID `
		-Container $container `
		-WorkloadType MSSQL;

 	return $item
}
function Cleanup-Vault(
	$vault,
	$item,
	$container)
{
	Disable-AzureRmRecoveryServicesBackupProtection `
			-VaultId $vault.ID `
			-Item $item `
			-RemoveRecoveryPoints `
			-Force;

	#Unregister container
	Unregister-AzRecoveryServicesBackupContainer `
		-VaultId $vault.ID `
		-Container $container
}