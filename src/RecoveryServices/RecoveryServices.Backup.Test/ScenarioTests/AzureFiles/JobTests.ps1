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
$resourceGroupName = "pstestrg8895"
$vaultName = "pstestrsv8895"
$fileShareFriendlyName = "fs1"
$fileShareName = "AzureFileShare;fs1"
$saName = "pstestsa8895"
$skuName="Standard_LRS"
$policyName = "afspolicy1"

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

function Test-AzureFSGetJob
{
	try
	{
		$vault = Get-AzRecoveryServicesVault -ResourceGroupName $resourceGroupName -Name $vaultName
		$item = Enable-Protection $vault $fileShareFriendlyName $saName

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

function Test-AzureFSWaitJob
{
	try
	{
		$vault = Get-AzRecoveryServicesVault -ResourceGroupName $resourceGroupName -Name $vaultName
 		$item = Enable-Protection $vault $fileShareFriendlyName $saName

		# Trigger backup and wait for completion
		$backupJob = Backup-AzRecoveryServicesBackupItem `
			-VaultId $vault.ID `
			-Item $item

		Assert-True { $backupJob.Status -eq "InProgress" }

		$backupJob = Wait-AzRecoveryServicesBackupJob -VaultId $vault.ID -Job $backupJob

		Assert-True { $backupJob.Status -eq "Completed" }

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

function Test-AzureFSCancelJob
{
	try
	{
		$vault = Get-AzRecoveryServicesVault -ResourceGroupName $resourceGroupName -Name $vaultName
 		$item = Enable-Protection $vault $fileShareFriendlyName $saName

		# Trigger backup and wait for completion
		$backupJob = Backup-AzRecoveryServicesBackupItem ` -VaultId $vault.ID -Item $item
		
		Assert-True { $backupJob.Status -eq "InProgress" }

		$cancelledJob = Stop-AzRecoveryServicesBackupJob -VaultId $vault.ID -Job $backupJob

		Assert-True { $cancelledJob.Status -ne "InProgress" }

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