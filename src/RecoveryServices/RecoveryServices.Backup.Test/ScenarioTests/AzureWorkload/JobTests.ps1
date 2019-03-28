
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

function Test-AzureVmWorkloadGetJob
{
	try
	{
		$vault = Get-AzRecoveryServicesVault -ResourceGroupName $resourceGroupName -Name $vaultName
		$container = Register-AzRecoveryServicesBackupContainer `
			-ResourceId $resourceId `
			-BackupManagementType AzureWorkload `
			-WorkloadType MSSQL `
			-VaultId $vault.ID `
			-Force

		Enable-Protection $vault $container

		$item = Get-AzRecoveryServicesBackupItem `
			-VaultId $vault.ID `
			-Container $container `
			-WorkloadType MSSQL;

		$startDate1 = Get-QueryDateInUtc $((Get-Date).AddDays(-1)) "StartDate1"
		$endDate1 = Get-QueryDateInUtc $(Get-Date) "EndDate1"

		$jobs = Get-AzRecoveryServicesBackupJob -VaultId $vault.ID -From $startDate1 -To $endDate1

		foreach ($job in $jobs)
		{
			$jobDetails = Get-AzRecoveryServicesBackupJobDetails -VaultId $vault.ID -Job $job;
			$jobDetails2 = Get-AzRecoveryServicesBackupJobDetails `
				-VaultId $vault.ID `
				-JobId $job.JobId

			Assert-AreEqual $jobDetails.JobId $job.JobId
			Assert-AreEqual $jobDetails2.JobId $job.JobId
		}
	}
	finally
	{
		Cleanup-Vault $vault $item $container
	}
}

function Test-AzureVmWorkloadWaitJob
{
	try
	{
		$vault = Get-AzRecoveryServicesVault -ResourceGroupName $resourceGroupName -Name $vaultName
 		$container = Register-AzRecoveryServicesBackupContainer `
			-ResourceId $resourceId `
			-BackupManagementType AzureWorkload `
			-WorkloadType MSSQL `
			-VaultId $vault.ID `
			-Force

		Enable-Protection $vault $container

		$item = Get-AzRecoveryServicesBackupItem `
			-VaultId $vault.ID `
			-Container $container `
			-WorkloadType MSSQL;

		# Trigger backup and wait for completion
		$backupJob = Backup-AzRecoveryServicesBackupItem `
			-VaultId $vault.ID `
			-Item $item `
			-BackupType "Full";

		Assert-True { $backupJob.Status -eq "InProgress" }

		$backupJob = Wait-AzRecoveryServicesBackupJob -VaultId $vault.ID -Job $backupJob

		Assert-True { $backupJob.Status -eq "Completed" }
	}
	finally
	{
		Cleanup-Vault $vault $item $container
	}
}

function Test-AzureVmWorkloadCancelJob
{
	try
	{
		$vault = Get-AzRecoveryServicesVault -ResourceGroupName $resourceGroupName -Name $vaultName
 		$container = Register-AzRecoveryServicesBackupContainer `
			-ResourceId $resourceId `
			-BackupManagementType AzureWorkload `
			-WorkloadType MSSQL `
			-VaultId $vault.ID `
			-Force

		Enable-Protection $vault $container

		$item = Get-AzRecoveryServicesBackupItem `
			-VaultId $vault.ID `
			-Container $container `
			-WorkloadType MSSQL;

		# Trigger backup and wait for completion
		$backupJob = Backup-AzRecoveryServicesBackupItem `
			-VaultId $vault.ID `
			-Item $item `
			-BackupType "Full";
		
		Assert-True { $backupJob.Status -eq "InProgress" }

		$cancelledJob = Stop-AzRecoveryServicesBackupJob -VaultId $vault.ID -Job $backupJob

		Assert-True { $cancelledJob.Status -ne "InProgress" }
	}
	finally
	{
		Cleanup-Vault $vault $item $container
	}
}