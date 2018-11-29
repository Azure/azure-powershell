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
$resourceGroupName = "shracrgnew"
$vaultName = "shracvault"

function Test-AzureVmWorkloadGetJob
{
	try
	{
    $vault = Get-AzureRmRecoveryServicesVault -ResourceGroupName $resourceGroupName -Name $vaultName

    $startDate1 = Get-QueryDateInUtc $((Get-Date).AddDays(-20)) "StartDate1"
		$endDate1 = Get-QueryDateInUtc $(Get-Date) "EndDate1"

    $jobs = Get-AzureRmRecoveryServicesBackupJob -VaultId $vault.ID -BackupManagementType AzureWorkload -From $startDate1 -To $endDate1
	}
	finally
	{
    # Cleanup
	}
}