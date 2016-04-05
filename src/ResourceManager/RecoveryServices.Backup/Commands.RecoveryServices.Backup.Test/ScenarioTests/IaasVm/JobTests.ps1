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
$fixedStartDate = Get-Date -Date "2016-03-21 12:00:00"
$fixedStartDate = $fixedStartDate.ToUniversalTime()
$fixedEndDate = Get-Date -Date "2016-03-22 12:00:00"
$fixedEndDate = $fixedEndDate.ToUniversalTime()

function SetVaultContext
{
	$vault = Get-AzureRmRecoveryServicesVault -ResourceGroupName "phaniktRSV" -Name "phaniktRs1";
	Set-AzureRmRecoveryServicesVaultContext -Vault $vault;
}

function Test-GetJobsScenario
{
	SetVaultContext;
	$jobs = Get-AzureRmBackupJob -From $fixedStartDate -To $fixedEndDate
	foreach ($job in $jobs)
	{
		Assert-NotNull $job.InstanceId
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

	$filteredJobs = Get-AzureRmBackupJob -From $startTime -To $endTime

	# Adding a second here and there to make sure comparison works fine
	$startTime.AddSeconds(-1);
	$endTime.AddSeconds(1);

	echo 'EndTime ' + $endTime;
	echo 'StartTime ' + $startTime;

	foreach ($job in $filteredJobs)
	{
		echo $job.StartTime;

		Assert-AreEqual $job.StartTime.CompareTo($startTime) 1
		Assert-AreEqual $endTime.CompareTo($job.StartTime) 1
	}
}

function Test-GetJobsStatusFilter
{
	$status = "Failed";

	SetVaultContext;

	$filteredJobs = Get-AzureRmBackupJob -From $fixedStartDate -To $fixedEndDate -Status $status;

	foreach ($job in $filteredJobs)
	{
		Assert-AreEqual $job.Status $status
	}
}

function Test-GetJobsOperationFilter
{
	$operation = "Backup";

	SetVaultContext;

	$filteredJobs = Get-AzureRmBackupJob -From $fixedStartDate -To $fixedEndDate -Operation $operation;

	foreach ($job in $filteredJobs)
	{
		Assert-AreEqual $job.Operation $operation
	}
}

function Test-GetJobsBackupManagementTypeFilter
{
	$type = "AzureVM";

	SetVaultContext;

	$filteredJobs = Get-AzureRmBackupJob -From $fixedStartDate -To $fixedEndDate -BackupManagementType $type;

	foreach ($job in $filteredJobs)
	{
		Assert-AreEqual $job.BackupManagementType $type
	}
}

function Test-GetJobDetails
{
	SetVaultContext;
	$jobs = Get-AzureRmBackupJob -From $fixedStartDate -To $fixedEndDate
	foreach ($job in $jobs)
	{
		$jobDetails = Get-AzureRmBackupJobDetails -Job $job;
		$jobDetails2 = Get-AzureRmBackupJobDetails -JobId $job.InstanceId

		Assert-AreEqual $jobDetails.InstanceId $job.InstanceId
		Assert-AreEqual $jobDetails2.InstanceId $job.InstanceId

		break;
	}
}

function Test-WaitJobScenario
{
	SetVaultContext;
	$jobs = Get-AzureRmBackupJob -From $fixedStartDate -To $fixedEndDate
	foreach ($job in $jobs)
	{
		$waitedJob = Wait-AzureRmBackupJob -Job $job
		Assert-AreNotEqual $waitedJob.Status "InProgress"
		Assert-AreNotEqual $waitedJob.Status "Cancelling"
	}
	$waitedJobs = Wait-AzureRmBackupJob -Job $jobs
}

function Test-WaitJobPipeScenario
{
	SetVaultContext;
	$waitedJobs = Get-AzureRmBackupJob -From $fixedStartDate -To $fixedEndDate | Wait-AzureRmBackupJob
	foreach ($waitedJob in $waitedJobs)
	{
		Assert-AreNotEqual $waitedJob.Status "InProgress"
		Assert-AreNotEqual $waitedJob.Status "Cancelling"
	}
}

function Test-CancelJobScenario
{
	$startTime = Get-Date -Date "2016-04-04 21:00:00"
	$endTime = Get-Date -Date "2016-04-05 13:40:00"

	$runningJobs = Get-AzureRmBackupJob -From $startTime -To $endTime -Status "InProgress"
	foreach ($runningJob in $runningJobs)
	{
		$cancelledJob = Stop-AzureRmBackupJob -Job $runningJob
		Assert-AreNotEqual $cancelledJob.Status "InProgress"
	}
}