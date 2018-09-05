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

function Test-AzureFileJob
{
	$location = "southeastasia"
	$resourceGroupName = "sam-rg-sea-can"
	$vaultName = "sam-rv-sea-can"

	try
	{
		$vault = Get-AzureRmRecoveryServicesVault -ResourceGroupName $resourceGroupName -Name $vaultName
		$jobs = Get-AzureRmRecoveryServicesBackupJob -VaultId $vault.ID

		# Test 2: Job details
		foreach ($job in $jobs)
		{
			$jobDetails = Get-AzureRmRecoveryServicesBackupJobDetails -VaultId $vault.ID -Job $job;
			$jobDetails2 = Get-AzureRmRecoveryServicesBackupJobDetails `
				-VaultId $vault.ID `
				-JobId $job.JobId

			Assert-AreEqual $jobDetails.JobId $job.JobId
			Assert-AreEqual $jobDetails2.JobId $job.JobId
		}
	}
	finally
	{
		# Cleanup
	}
}

function Test-AzureFileWaitJob
{
	$location = "westus"
	$resourceGroupName = "sisi-RSV"

	try
	{
		
		$vault = Get-AzureRmRecoveryServicesVault -ResourceGroupName $resourceGroupName -Name "sisi-RSV-29-6"
		$container = Get-AzureRmRecoveryServicesBackupContainer `
			-VaultId $vault.ID `
			-ContainerType AzureStorage `
			-Status Registered `
			-FriendlyName "sisisa";
 		$item = Get-AzureRmRecoveryServicesBackupItem `
			-VaultId $vault.ID `
			-Container $container[16] `
			-WorkloadType AzureFiles `
			-Name "sharetest"
		
		# Trigger backup and wait for completion
		$backupJob = Backup-AzureRmRecoveryServicesBackupItem `
			-VaultId $vault.ID `
			-Item $item[0]

		Assert-True { $backupJob.Status -eq "InProgress" }

		$backupJob = Wait-AzureRmRecoveryServicesBackupJob -VaultId $vault.ID -Job $backupJob

		Assert-True { $backupJob.Status -eq "Completed" }
	}
	finally
	{
		# Cleanup
	}
}

function Test-AzureFileCancelJob
{
	$location = "westus"
	$resourceGroupName = "sisi-RSV"

	try
	{
		$vault = Get-AzureRmRecoveryServicesVault -ResourceGroupName $resourceGroupName -Name "sisi-RSV-29-6"
		$container = Get-AzureRmRecoveryServicesBackupContainer `
			-VaultId $vault.ID `
			-ContainerType AzureStorage `
			-Status Registered `
			-FriendlyName "sisisa";
 		$item = Get-AzureRmRecoveryServicesBackupItem `
			-VaultId $vault.ID `
			-Container $container[16] `
			-WorkloadType AzureFiles `
			-Name "sharetest"
		
		$backupJob = Backup-AzureRmRecoveryServicesBackupItem `
			-VaultId $vault.ID `
			-Item $item[0]

		Assert-True { $backupJob.Status -eq "InProgress" }

		$cancelledJob = Stop-AzureRmRecoveryServicesBackupJob -VaultId $vault.ID -Job $backupJob

		Assert-True { $cancelledJob.Status -ne "InProgress" }
	}
	finally
	{
		# Cleanup
	}
}