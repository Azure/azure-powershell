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
$ContainerName = "iaasvmcontainer;dev01testing;dev01testing"
$ContainerType = "IaasVMContainer"
$DataSourceType = "VM"
$DataSourceId = "17593283453810"
$Location = "SouthEast Asia"
$PolicyName = "Policy9";
$PolicyId = "c87bbada-6e1b-4db2-b76c-9062d28959a4";
$POName = "iaasvmcontainer;dev01testing;dev01testing"

<#
.SYNOPSIS
Tests creating new resource group and a simple resource.
#>
function Test-GetAzureBackupProtectionPolicyTests
{
	$protectionPolicies = Get-AzureBackupProtectionPolicy -ResourceGroupName $ResourceGroupName -ResourceName $ResourceName -Location $Location
	Assert-NotNull $protectionPolicies 'Protection Policies should not be null'
	foreach($protectionPolicy in $protectionPolicies)
	{
		Assert-NotNull $protectionPolicy.InstanceId 'InstanceId should not be null'
		Assert-NotNull $protectionPolicy.Name 'Name should not be null'
		Assert-NotNull $protectionPolicy.WorkloadType 'WorkloadType should not be null'
		Assert-NotNull $protectionPolicy.BackupType 'BackupType should not be null'
		Assert-NotNull $protectionPolicy.ScheduleRunTimes 'ScheduleRunTimes should not be null'
		Assert-NotNull $protectionPolicy.RetentionDuration 'RetentionDuration should not be null'
		Assert-NotNull $protectionPolicy.ResourceGroupName 'ResourceGroupName should not be null'
		Assert-NotNull $protectionPolicy.ResourceName 'ResourceName should not be null'
	}
}

function GetAzureRecoveryPointTest
{
    $azureBackUpItem = New-Object Microsoft.Azure.Commands.AzureBackup.Cmdlets.AzureBackupItem
	$azureBackUpItem.ResourceGroupName = $ResourceGroupName
	$azureBackUpItem.ResourceName = $ResourceGroupName
	$azureBackUpItem.Location = $Location
	$azureBackUpItem.ContainerUniqueName = $ContainerName
	$azureBackUpItem.ContainerType = $ContainerType
	$azureBackUpItem.DataSourceId = $DataSourceId
	$azureBackUpItem.Type = $DataSourceType
	$recoveryPoints = Get-AzureBackupRecoveryPoint -Item $azureBackUpItem
	if (!($recoveryPoints -eq $null))
	{
	foreach($recoveryPoint in $recoveryPoints)
	{
	    Assert-NotNull $recoveryPoint.RecoveryPointTime 'RecoveryPointTime should not be null'
		Assert-NotNull $recoveryPoint.RecoveryPointType 'RecoveryPointType should not be null'
		Assert-NotNull $recoveryPoint.RecoveryPointId  'RecoveryPointId should not be null'
	}
}

function Test-GetAzureBackupItemTests
{
	$azureBackUpContainer = New-Object Microsoft.Azure.Commands.AzureBackup.Cmdlets.AzureBackupContainer
	$azureBackUpContainer.ResourceGroupName = $ResourceGroupName
	$azureBackUpContainer.ResourceName = $ResourceName
	$azureBackUpContainer.Location = $Location
	$azureBackUpContainer.ContainerUniqueName = $ContainerName
	$azureBackUpContainer.ContainerType = $ContainerType
	$item = Get-AzureBackupItem -Container $azureBackUpContainer
	if (!($item -eq $null))
	{
		foreach($backupitem in $item)
		{   
			Assert-NotNull $backupitem.ProtectionStatus 'ProtectionStatus should not be null'    
			Assert-NotNull $backupitem.Name 'Name should not be null'            
			Assert-NotNull $backupitem.Type 'Type should not be null'            
			Assert-NotNull $backupitem.ContainerType 'ContainerType should not be null'      
			Assert-NotNull $backupitem.ContainerUniqueName 'ContainerUniqueName should not be null'
			Assert-NotNull $backupitem.ResourceGroupName 'ResourceGroupName should not be null'  
			Assert-NotNull $backupitem.ResourceName 'ResourceName should not be null'      
			Assert-NotNull $backupitem.Location 'Location should not be null' 
		}
	}
}

function Test-EnableDisableAzureBackupProtectionTest
{	
	$policy = New-Object Microsoft.Azure.Commands.AzureBackup.Cmdlets.AzureBackupProtectionPolicy
	$policy.InstanceId = $PolicyId
	$policy.Name = $PolicyName
	$policy.ResourceGroupName = $ResourceGroupName
	$policy.ResourceName = $ResourceName
	$policy.Location = $Location
	$policy.WorkloadType = "VM"
	$policy.RetentionType = "1"
	$policy.ScheduleRunTimes =  "2015-06-13T20:30:00"

	$azureBackUpItem = New-Object Microsoft.Azure.Commands.AzureBackup.Cmdlets.AzureBackupItem
	$azureBackUpItem.ResourceGroupName = $ResourceGroupName
	$azureBackUpItem.ResourceName = $ResourceName
	$azureBackUpItem.Location = $Location
	$azureBackUpItem.ContainerUniqueName = $ContainerName
	$azureBackUpItem.ContainerType = $ContainerType
	$azureBackUpItem.DataSourceId = $DataSourceId
	$azureBackUpItem.Type = $DataSourceType
	$azureBackUpItem.Name = $POName

	$jobId = Enable-AzureBackupProtection -Item $azureBackUpItem -Policy $policy 
	sleep(20)
	$jobId1 = Disable-AzureBackupProtection -Item $azureBackUpItem
	sleep(20)
	$jobId2 = Enable-AzureBackupProtection -Item $azureBackUpItem -Policy $policy 
}

function BackUpAzureBackUpItemTest
{
    $azureBackUpItem = New-Object Microsoft.Azure.Commands.AzureBackup.Cmdlets.AzureBackupItem
	$azureBackUpItem.ResourceGroupName = $ResourceGroupName
	$azureBackUpItem.ResourceName = $ResourceName
	$azureBackUpItem.Location = $Location
	$azureBackUpItem.ContainerUniqueName = $ContainerName
	$azureBackUpItem.ContainerType = $ContainerType
	$azureBackUpItem.DataSourceId = $DataSourceId
	$azureBackUpItem.Type = $DataSourceType
	$jobId = Backup-AzureBackupItem -Item $azureBackUpItem
}


function Test-GetAzureBackupJob
{
	$OneMonthBack = Get-Date;
	$OneMonthBack = $OneMonthBack.AddDays(-30);
	$jobs = Get-AzureBackupJob -ResourceGroupName $ResourceGroupName -ResourceName $ResourceName -Location $Location -From $OneMonthBack -Debug
	Assert-NotNull $jobs 'Jobs list should not be null'
	foreach($job in $jobs)
	{
		Assert-NotNull $jobs.InstanceId 'JobID should not be null';
		Assert-NotNull $jobs.StartTime 'StartTime should not be null';
		Assert-NotNull $jobs.WorkloadType 'WorkloadType should not be null';
		Assert-NotNull $jobs.WorkloadName 'WorkloadName should not be null';
		Assert-NotNull $jobs.Status 'Status should not be null';
		Assert-NotNull $jobs.Operation 'Operation should not be null';

		$jobDetails = Get-AzureBackupJobDetails -ResourceGroupName $ResourceGroupName -ResourceName $ResourceName -Location $Location -Job $job
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


function Test-StopAzureBackupJob
{
	$OneMonthBack = Get-Date;
	$OneMonthBack = $OneMonthBack.AddDays(-30);
	#TODO
	#Call trigger backup and get an inprogress job
	$jobsList = Get-AzureBackupJob -ResourceGroupName $ResourceGroupName -ResourceName $ResourceName -Location $Location -From $OneMonthBack #-Operation 'Backup' -Status 'InProgress'

	Stop-AzureBackupJob -ResourceGroupName $ResourceGroupName -ResourceName $ResourceName -Location $Location -Job $jobsList[0];
	$jobDetails = Get-AzureBackupJobDetails -ResourceGroupName $ResourceGroupName -ResourceName $ResourceName -Location $Location -Job $jobsList[0];
	#Assert-AreEqual 'Cancelling' $jobDetails.Status
}
