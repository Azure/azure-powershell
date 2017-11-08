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

function Test-AzureVMGetJobs
{
	$location = Get-ResourceGroupLocation
	$resourceGroupName = Create-ResourceGroup $location
	
	try
	{
		# Setup
		$vm1 = Create-VM $resourceGroupName $location 1
		$vault = Create-RecoveryServicesVault $resourceGroupName $location
		Enable-Protection $vault $vm1

		Set-AzureRmRecoveryServicesVaultContext -Vault $vault;

		# Test 1: Triggering a new job increases job count

		$startDate1 = Get-QueryDateInUtc $((Get-Date).AddDays(-1)) "StartDate1"
		$endDate1 = Get-QueryDateInUtc $(Get-Date) "EndDate1"

		$jobs = Get-AzureRmRecoveryServicesBackupJob -From $startDate1 -To $endDate1
		$jobCount1 = $jobs.Count

		$vm2 = Create-VM $resourceGroupName $location 2
		Enable-Protection $vault $vm2

		$endDate2 = Get-QueryDateInUtc $(Get-Date) "EndDate2"

		$jobs = Get-AzureRmRecoveryServicesBackupJob -From $startDate1 -To $endDate2
		$jobCount2 = $jobs.Count

		Assert-True { $jobCount1 -lt $jobCount2 }

		# Test 2: Job details
		foreach ($job in $jobs)
		{
			$jobDetails = Get-AzureRmRecoveryServicesBackupJobDetails -Job $job;
			$jobDetails2 = Get-AzureRmRecoveryServicesBackupJobDetails -JobId $job.JobId

			Assert-AreEqual $jobDetails.JobId $job.JobId
			Assert-AreEqual $jobDetails2.JobId $job.JobId
		}

		# Test 3: Job Status filter
		$jobs = Get-AzureRmRecoveryServicesBackupJob -From $startDate1 -To $endDate2 -Status Completed
		Assert-True { $jobs.Count -gt 0}

		# Test 4: Job Operation filter
		$jobs = Get-AzureRmRecoveryServicesBackupJob -From $startDate1 -To $endDate2 -Operation ConfigureBackup
		Assert-True { $jobs.Count -gt 0}

		# Test 5: Job BackupManagementType filter
		$jobs = Get-AzureRmRecoveryServicesBackupJob -From $startDate1 -To $endDate2 -BackupManagementType AzureVM
		Assert-True { $jobs.Count -gt 0}
	}
	finally
	{
		# Cleanup
		Cleanup-ResourceGroup $resourceGroupName
	}
}

function Test-AzureVMGetJobsTimeFilter
{
	$location = Get-ResourceGroupLocation
	$resourceGroupName = Create-ResourceGroup -Location $location
	
	try
	{
		# Setup
		$vm1 = Create-VM $resourceGroupName $location 1
		$vm2 = Create-VM $resourceGroupName $location 2
		$vault = Create-RecoveryServicesVault $resourceGroupName $location
		Enable-Protection $vault $vm1
		Enable-Protection $vault $vm2

		Set-AzureRmRecoveryServicesVaultContext -Vault $vault;

		# Generic time filter test

		$startTime1 = Get-QueryDateInUtc $((Get-Date).AddDays(-1)) "StartTime1"
		$endTime1 = Get-QueryDateInUtc $(Get-Date) "EndTime1"

		$filteredJobs = Get-AzureRmRecoveryServicesBackupJob -From $startTime1 -To $endTime1

		# Adding a second here and there to make sure comparison works fine
		$startTime1.AddSeconds(-1);
		$endTime1.AddSeconds(1);

		foreach ($job in $filteredJobs)
		{
			Assert-AreEqual $job.StartTime.ToUniversalTime().CompareTo($startTime1) 1
			Assert-AreEqual $endTime1.CompareTo($job.StartTime.ToUniversalTime()) 1
		}

		# Negative test cases

		# 1. rangeEnd <= rangeStart
		Assert-ThrowsContains { Get-AzureRmRecoveryServicesBackupJob -From $endTime1 -To $startTime1; } `
			"To filter should not be less than From filter";
		
		# 2. rangeStart.Kind != DateTimeKind.Utc
		$startTime2 = Get-QueryDateLocal $((Get-Date).AddDays(-20)) "StartTime2"
		$endTime2 = $endTime1
		Assert-ThrowsContains { Get-AzureRmRecoveryServicesBackupJob -From $startTime2 -To $endTime2 } `
			"Please specify From and To filter values in UTC. Other timezones are not supported";

		# 3. rangeEnd.Subtract(rangeStart) > TimeSpan.FromDays(30)
		$startTime3 = Get-QueryDateInUtc $((Get-Date).AddDays(-40)) "StartTime3"
		$endTime3 = Get-QueryDateInUtc $(Get-Date) "EndTime3"
		Assert-ThrowsContains { Get-AzureRmRecoveryServicesBackupJob -From $startTime3 -To $endTime3 } `
			"To filter should not be more than 30 days away from From filter";

		# 4. rangeStart > DateTime.UtcNow
		$startTime4 = Get-QueryDateInUtc $((Get-Date).AddYears(100).AddDays(-1)) "StartTime4"
		$endTime4 = Get-QueryDateInUtc $((Get-Date).AddYears(100)) "EndTime4"
		Assert-ThrowsContains { Get-AzureRmRecoveryServicesBackupJob -From $startTime4 -To $endTime4 } `
			"From date should be less than current UTC time";
	}
	finally
	{
		# Cleanup
		Cleanup-ResourceGroup $resourceGroupName
	}
}

function Test-AzureVMWaitJob
{
	$location = Get-ResourceGroupLocation
	$resourceGroupName = Create-ResourceGroup -Location $location

	try
	{
		# Setup
		$vm = Create-VM $resourceGroupName $location
		$vault = Create-RecoveryServicesVault $resourceGroupName $location
		$item = Enable-Protection $vault $vm
		
		Set-AzureRmRecoveryServicesVaultContext -Vault $vault;

		$backupJob = Backup-AzureRmRecoveryServicesBackupItem -Item $item

		Assert-True { $backupJob.Status -eq "InProgress" }

		$backupJob = Wait-AzureRmRecoveryServicesBackupJob -Job $backupJob

		Assert-True { $backupJob.Status -eq "Completed" }
	}
	finally
	{
		# Cleanup
		Cleanup-ResourceGroup $resourceGroupName
	}
}

function Test-AzureVMCancelJob
{
	$location = Get-ResourceGroupLocation
	$resourceGroupName = Create-ResourceGroup -Location $location

	try
	{
		# Setup
		$vm = Create-VM $resourceGroupName $location
		$vault = Create-RecoveryServicesVault $resourceGroupName $location
		$item = Enable-Protection $vault $vm
		
		Set-AzureRmRecoveryServicesVaultContext -Vault $vault;

		$backupJob = Backup-AzureRmRecoveryServicesBackupItem -Item $item

		Assert-True { $backupJob.Status -eq "InProgress" }

		$cancelledJob = Stop-AzureRmRecoveryServicesBackupJob -Job $backupJob

		Assert-True { $cancelledJob.Status -ne "InProgress" }
	}
	finally
	{
		# Cleanup
		Cleanup-ResourceGroup $resourceGroupName
	}
}