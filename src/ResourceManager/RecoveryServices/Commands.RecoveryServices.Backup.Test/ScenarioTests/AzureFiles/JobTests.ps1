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

#Setup Instructions:
#1. Create a resource group
#2. Create a storage account and a recovery services vault
#3. Create a file share in the storage account
#4. Fill the below global variables accordingly

$location = "westus"
$resourceGroupName = "sisi-RSV"
$vaultName = "sisi-RSV-29-6"
$fileShareName = "pstestfileshare"
$fileShareFullName = "AzureFileShare;pstestfileshare"
$saName = "pstestsaa"

function Test-AzureFileJob
{
	$vault = Get-AzureRmRecoveryServicesVault -ResourceGroupName $resourceGroupName -Name $vaultName
	$item = Enable-Protection $vault $fileShareName $saName

	$startDate1 = Get-QueryDateInUtc $((Get-Date).AddDays(-1)) "StartDate1"
	$endDate1 = Get-QueryDateInUtc $(Get-Date) "EndDate1"

	$jobs = Get-AzureRmRecoveryServicesBackupJob -VaultId $vault.ID -From $startDate1 -To $endDate1

	foreach ($job in $jobs)
	{
		$jobDetails = Get-AzureRmRecoveryServicesBackupJobDetails -VaultId $vault.ID -Job $job;
		$jobDetails2 = Get-AzureRmRecoveryServicesBackupJobDetails `
			-VaultId $vault.ID `
			-JobId $job.JobId

		Assert-AreEqual $jobDetails.JobId $job.JobId
		Assert-AreEqual $jobDetails2.JobId $job.JobId
	}

	$container = Get-AzureRmRecoveryServicesBackupContainer `
		-VaultId $vault.ID `
		-ContainerType AzureStorage `
		-Status Registered `
		-Name $saName
	
	# Disable protection
	Disable-AzureRmRecoveryServicesBackupProtection `
		-VaultId $vault.ID `
		-Item $item `
		-RemoveRecoveryPoints `
		-Force;
	Unregister-AzureRmRecoveryServicesBackupContainer `
	-VaultId $vault.ID `
	-Container $container
}

function Test-AzureFileWaitJob
{
	$vault = Get-AzureRmRecoveryServicesVault -ResourceGroupName $resourceGroupName -Name $vaultName
 	$item = Enable-Protection $vault $fileShareName $saName

	# Trigger backup and wait for completion
	$backupJob = Backup-AzureRmRecoveryServicesBackupItem `
		-VaultId $vault.ID `
		-Item $item

	Assert-True { $backupJob.Status -eq "InProgress" }

	$backupJob = Wait-AzureRmRecoveryServicesBackupJob -VaultId $vault.ID -Job $backupJob

	Assert-True { $backupJob.Status -eq "Completed" }

	$container = Get-AzureRmRecoveryServicesBackupContainer `
		-VaultId $vault.ID `
		-ContainerType AzureStorage `
		-Status Registered `
		-Name $saName
	
	# Disable protection
	Disable-AzureRmRecoveryServicesBackupProtection `
		-VaultId $vault.ID `
		-Item $item `
		-RemoveRecoveryPoints `
		-Force;
	Unregister-AzureRmRecoveryServicesBackupContainer `
	-VaultId $vault.ID `
	-Container $container
}

function Test-AzureFileCancelJob
{
	$vault = Get-AzureRmRecoveryServicesVault -ResourceGroupName $resourceGroupName -Name $vaultName
 	$item = Enable-Protection $vault $fileShareName $saName

	# Trigger backup and wait for completion
	$backupJob = Backup-AzureRmRecoveryServicesBackupItem ` -VaultId $vault.ID -Item $item
		
	Assert-True { $backupJob.Status -eq "InProgress" }

	$cancelledJob = Stop-AzureRmRecoveryServicesBackupJob -VaultId $vault.ID -Job $backupJob

	Assert-True { $cancelledJob.Status -ne "InProgress" }

	$container = Get-AzureRmRecoveryServicesBackupContainer `
		-VaultId $vault.ID `
		-ContainerType AzureStorage `
		-Status Registered `
		-Name $saName
	
	# Disable protection
	Disable-AzureRmRecoveryServicesBackupProtection `
		-VaultId $vault.ID `
		-Item $item `
		-RemoveRecoveryPoints `
		-Force;
	Unregister-AzureRmRecoveryServicesBackupContainer `
	-VaultId $vault.ID `
	-Container $container
}