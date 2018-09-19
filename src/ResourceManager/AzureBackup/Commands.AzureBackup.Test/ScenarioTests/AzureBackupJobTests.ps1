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

$ResourceGroupName = "backuprg"
$ResourceName = "backuprn"
$ContainerName = "iaasvmcontainer;hydrarecordvm;hydrarecordvm"
$ContainerType = "IaasVMContainer"
$DataSourceType = "VM"
$DataSourceId = "17593283453810"
$Location = "SouthEast Asia"
$PolicyName = "Policy9";
$PolicyId = "c87bbada-6e1b-4db2-b76c-9062d28959a4";
$POName = "iaasvmcontainer;hydrarecordvm;hydrarecordvm"
$ItemName = "iaasvmcontainer;hydrarecordvm;hydrarecordvm"

# startTime%20eq%20'2015-07-15%2009:39:29%20AM'%20and%20endTime%20eq%20'2015-08-14%2009:39:29%20AM'",

function Test-GetAzureRMBackupJob
{
	$vault = Get-AzureRmBackupVault -Name $ResourceName;
	$OneMonthBack = Get-Date -Date "2015-07-15 09:39:29Z";
	$now = Get-Date -Date "2015-08-14 09:39:29Z";
	$jobs = Get-AzureRmBackupJob -Vault $vault -From $OneMonthBack -To $now
	Assert-NotNull $jobs 'Jobs list should not be null'
	foreach($job in $jobs)
	{
		Assert-NotNull $jobs.InstanceId 'JobID should not be null';
		Assert-NotNull $jobs.StartTime 'StartTime should not be null';
		Assert-NotNull $jobs.WorkloadType 'WorkloadType should not be null';
		Assert-NotNull $jobs.WorkloadName 'WorkloadName should not be null';
		Assert-NotNull $jobs.Status 'Status should not be null';
		Assert-NotNull $jobs.Operation 'Operation should not be null';

		$jobDetails = Get-AzureRmBackupJobDetails -Job $job
		Assert-NotNull $jobDetails.InstanceId 'JobID should not be null';
		Assert-NotNull $jobDetails.StartTime 'StartTime should not be null';
		Assert-NotNull $jobDetails.WorkloadType 'WorkloadType should not be null';
		Assert-NotNull $jobDetails.WorkloadName 'WorkloadName should not be null';
		Assert-NotNull $jobDetails.Status 'Status should not be null';
		Assert-NotNull $jobDetails.Operation 'Operation should not be null';
		Assert-NotNull $jobDetails.Properties 'Properties in job details cannot be null';
		Assert-NotNull $jobDetails.SubTasks 'SubTasks in job details cannot be null';
	}
}


function Test-StopAzureRMBackupJob
{
    $AzureRMBackupItem = New-Object Microsoft.Azure.Commands.AzureBackup.Models.AzureRMBackupItem
	$AzureRMBackupItem.ResourceGroupName = $ResourceGroupName
	$AzureRMBackupItem.ResourceName = $ResourceName
	$AzureRMBackupItem.Location = $Location
	$AzureRMBackupItem.ContainerUniqueName = $ContainerName
	$AzureRMBackupItem.ItemName = $ItemName
	$job = Backup-AzureRmBackupItem -Item $AzureRMBackupItem

	Stop-AzureRmBackupJob -Job $job;
	Wait-AzureRmBackupJob -Job $job;
	$jobDetails = Get-AzureRmBackupJobDetails -Job $job;
	Assert-AreEqual 'Cancelled' $jobDetails.Status
}
