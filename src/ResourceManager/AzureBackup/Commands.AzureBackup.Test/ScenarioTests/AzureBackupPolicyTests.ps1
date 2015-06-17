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
$DataSourceType = "VM"
$Location = "SouthEast Asia"
$PolicyName = "Policy9";
$PolicyId = "c87bbada-6e1b-4db2-b76c-9062d28959a4";
$POName = "iaasvmcontainer;dev01testing;dev01testing"
$WorkloadType = "VM"
$RetentionType = "Days"
$ScheduleRunTimes =  "2015-06-13T20:30:00"
$ScheduleRunDays = "Monday"
$RetentionDuration = 30
$BackupType = "Full"
$ScheduleType = "Daily"

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
		Assert-NotNull $protectionPolicy.Location 'Location should not be null'
	}
}

function Test-GetAzureBackupProtectionPolicyByNameTests
{
	$protectionPolicy = Get-AzureBackupProtectionPolicy -ResourceGroupName $ResourceGroupName -ResourceName $ResourceName -Location $Location -Name $PolicyName
	
	Assert-NotNull $protectionPolicy.InstanceId 'InstanceId should not be null'
	Assert-NotNull $protectionPolicy.Name 'Name should not be null'
	Assert-NotNull $protectionPolicy.WorkloadType 'WorkloadType should not be null'
	Assert-NotNull $protectionPolicy.BackupType 'BackupType should not be null'
	Assert-NotNull $protectionPolicy.ScheduleRunTimes 'ScheduleRunTimes should not be null'
	Assert-NotNull $protectionPolicy.RetentionDuration 'RetentionDuration should not be null'
	Assert-NotNull $protectionPolicy.ResourceGroupName 'ResourceGroupName should not be null'
	Assert-NotNull $protectionPolicy.ResourceName 'ResourceName should not be null'
	Assert-NotNull $protectionPolicy.Location 'Location should not be null'
	
}

function Test-NewAzureBackupProtectionPolicyTests
{	
	$protectionPolicy = New-AzureBackupProtectionPolicy -Name $PolicyName -WorkloadType $WorkloadType -BackupType $BackupType -Daily -RetentionType $RetentionType -RetentionDuration $RetentionDuration -ScheduleRunTimes $ScheduleRunTimes -ResourceGroupName  $ResourceGroupName -ResourceName $ResourceName -Location $Location
	
	Assert-NotNull $protectionPolicy.InstanceId 'InstanceId should not be null'
	Assert-NotNull $protectionPolicy.Name 'Name should not be null'
	Assert-NotNull $protectionPolicy.WorkloadType 'WorkloadType should not be null'
	Assert-NotNull $protectionPolicy.BackupType 'BackupType should not be null'
	Assert-NotNull $protectionPolicy.ScheduleRunTimes 'ScheduleRunTimes should not be null'
	Assert-NotNull $protectionPolicy.RetentionDuration 'RetentionDuration should not be null'
	Assert-NotNull $protectionPolicy.ResourceGroupName 'ResourceGroupName should not be null'
	Assert-NotNull $protectionPolicy.ResourceName 'ResourceName should not be null'
	Assert-NotNull $protectionPolicy.Location 'Location should not be null'
}

function Test-SetAzureBackupProtectionPolicyTests
{	
	$policy = New-Object Microsoft.Azure.Commands.AzureBackup.Cmdlets.AzureBackupProtectionPolicy
	$policy.InstanceId = $PolicyId
	$policy.Name = $PolicyName
	$policy.ResourceGroupName = $ResourceGroupName
	$policy.ResourceName = $ResourceName
	$policy.Location = $Location
	$policy.WorkloadType = $WorkloadType
	$policy.RetentionType = $RetentionType
	$policy.ScheduleRunTimes =  $ScheduleRunTimes
	$policy.ScheduleType = $ScheduleType
	$policyNewName = "policy09_new"
	
	$protectionPolicy = New-AzureBackupProtectionPolicy -ProtectionPolicy $policy -NewName $policyNewName

	Assert-NotNull $protectionPolicy.InstanceId 'InstanceId should not be null'
	Assert-NotNull $protectionPolicy.Name 'Name should not be null'
	Assert-NotNull $protectionPolicy.WorkloadType 'WorkloadType should not be null'
	Assert-NotNull $protectionPolicy.BackupType 'BackupType should not be null'
	Assert-NotNull $protectionPolicy.ScheduleRunTimes 'ScheduleRunTimes should not be null'
	Assert-NotNull $protectionPolicy.RetentionDuration 'RetentionDuration should not be null'
	Assert-NotNull $protectionPolicy.ResourceGroupName 'ResourceGroupName should not be null'
	Assert-NotNull $protectionPolicy.ResourceName 'ResourceName should not be null'
	Assert-NotNull $protectionPolicy.Location 'Location should not be null'
}

function Test-RemoveAzureBackupProtectionPolicyTests
{	
	$policyNewName = "policy09_new"
	$policy = New-Object Microsoft.Azure.Commands.AzureBackup.Cmdlets.AzureBackupProtectionPolicy
	$policy.InstanceId = $PolicyId
	$policy.Name = $policyNewName
	$policy.ResourceGroupName = $ResourceGroupName
	$policy.ResourceName = $ResourceName
	$policy.Location = $Location
	$policy.WorkloadType = $WorkloadType
	$policy.RetentionType = $RetentionType
	$policy.ScheduleRunTimes =  $ScheduleRunTimes
	$policy.ScheduleType = $ScheduleType
	
	Remove-AzureBackupProtectionPolicy -ProtectionPolicy $policy
}
