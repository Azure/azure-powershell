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

#Have to hard-code this because time keeps changing with every run and we cannot use recorded sessions
$fixedStartDate = Get-Date -Date "2016-04-17 11:30:00Z"
$fixedStartDate = $fixedStartDate.ToUniversalTime()
$fixedEndDate = Get-Date -Date "2016-04-18 11:30:00Z"
$fixedEndDate = $fixedEndDate.ToUniversalTime()

function SetVaultContext
{
	$vault = Get-AzureRmRecoveryServicesVault -ResourceGroupName "RsvTestRG" -Name "RsvTestRN";
	Set-AzureRmRecoveryServicesVaultContext -Vault $vault;
}

function Test-GetJobsScenario
{
	SetVaultContext;
	$jobs = Get-AzureRmRecoveryServicesBackupJob -From $fixedStartDate -To $fixedEndDate
	foreach ($job in $jobs)
	{
		Assert-NotNull $job.JobId
		Assert-NotNull $job.Operation
		Assert-NotNull $job.Status
		Assert-NotNull $job.WorkloadName
	}
}

function Test-GetJobsTimeFilter
{
	$endTime = $fixedEndDate;
	$startTime = $fixedStartDate;

	SetVaultContext;

	$filteredJobs = Get-AzureRmRecoveryServicesBackupJob -From $startTime -To $endTime

	# Adding a second here and there to make sure comparison works fine
	$startTime.AddSeconds(-1);
	$endTime.AddSeconds(1);

	echo 'EndTime ' + $endTime;
	echo 'StartTime ' + $startTime;

	foreach ($job in $filteredJobs)
	{
		echo $job.StartTime;

		Assert-AreEqual $job.StartTime.ToUniversalTime().CompareTo($startTime) 1
		Assert-AreEqual $endTime.CompareTo($job.StartTime.ToUniversalTime()) 1
	}
}

function Test-GetJobsStatusFilter
{
	$status = "Failed";

	SetVaultContext;

	$filteredJobs = Get-AzureRmRecoveryServicesBackupJob -From $fixedStartDate -To $fixedEndDate -Status $status;

	foreach ($job in $filteredJobs)
	{
		Assert-AreEqual $job.Status $status
	}
}

function Test-GetJobsOperationFilter
{
	$operation = "Backup";

	SetVaultContext;

	$filteredJobs = Get-AzureRmRecoveryServicesBackupJob -From $fixedStartDate -To $fixedEndDate -Operation $operation;

	foreach ($job in $filteredJobs)
	{
		Assert-AreEqual $job.Operation $operation
	}
}

function Test-GetJobsBackupManagementTypeFilter
{
	$type = "AzureVM";

	SetVaultContext;

	$filteredJobs = Get-AzureRmRecoveryServicesBackupJob -From $fixedStartDate -To $fixedEndDate -BackupManagementType $type;

	foreach ($job in $filteredJobs)
	{
		Assert-AreEqual $job.BackupManagementType $type
	}
}

function Test-GetJobDetails
{
	SetVaultContext;
	$jobs = Get-AzureRmRecoveryServicesBackupJob -From $fixedStartDate -To $fixedEndDate
	foreach ($job in $jobs)
	{
		$jobDetails = Get-AzureRmRecoveryServicesBackupJobDetails -Job $job;
		$jobDetails2 = Get-AzureRmRecoveryServicesBackupJobDetails -JobId $job.JobId

		Assert-AreEqual $jobDetails.JobId $job.JobId
		Assert-AreEqual $jobDetails2.JobId $job.JobId

		break;
	}
}

function Test-WaitJobScenario
{
	SetVaultContext;
	$jobs = Get-AzureRmRecoveryServicesBackupJob -From $fixedStartDate -To $fixedEndDate
	foreach ($job in $jobs)
	{
		$waitedJob = Wait-AzureRmRecoveryServicesBackupJob -Job $job
		Assert-AreNotEqual $waitedJob.Status "InProgress"
		Assert-AreNotEqual $waitedJob.Status "Cancelling"
	}
	$waitedJobs = Wait-AzureRmRecoveryServicesBackupJob -Job $jobs
}

function Test-WaitJobPipeScenario
{
	SetVaultContext;
	$waitedJobs = Get-AzureRmRecoveryServicesBackupJob -From $fixedStartDate -To $fixedEndDate | Wait-AzureRmRecoveryServicesBackupJob
	foreach ($waitedJob in $waitedJobs)
	{
		Assert-AreNotEqual $waitedJob.Status "InProgress"
		Assert-AreNotEqual $waitedJob.Status "Cancelling"
	}
}

function Test-CancelJobScenario
{
	$1fixedStartDate = Get-Date -Date "2016-04-19 17:00:00"
	$1fixedStartDate = $1fixedStartDate.ToUniversalTime()
	$1fixedEndDate = Get-Date -Date "2016-04-20 17:00:00"
	$1fixedEndDate = $1fixedEndDate.ToUniversalTime()
	SetVaultContext;
	$runningJobs = Get-AzureRmRecoveryServicesBackupJob -From $1fixedStartDate -To $1fixedEndDate -Status "InProgress" -Operation "Backup"
	foreach ($runningJob in $runningJobs)
	{
		$cancelledJob = Stop-AzureRmRecoveryServicesBackupJob -Job $runningJob
		Assert-AreNotEqual $cancelledJob.Status "InProgress"
	}
}