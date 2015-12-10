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
$ResourceName = "backuprn2"
$DataSourceType = "VM"
$Location = "westus"
$PolicyName = "Policy10";
$PolicyId = "c87bbada-6e1b-4db2-b76c-9062d28959a4";
$POName = "iaasvmcontainer;hydrarecordvm;hydrarecordvm"
$Type = "AzureVM"
$RetentionType = "Days"
$BackupTime =  "2015-06-13T20:30:00"
$DaysOfWeek = "Monday"
$RetentionDuration = 30
$BackupType = "Full"
$ScheduleType = "Daily"

<#
.SYNOPSIS
Tests creating new resource group and a simple resource.
#>
function Test-GetAzureBackupProtectionPolicyTests
{
	$vault = Get-AzureRmBackupVault -Name $ResourceName;
	$protectionPolicies = Get-AzureRmBackupProtectionPolicy -vault $vault
	Assert-NotNull $protectionPolicies 'Protection Policies should not be null'
	foreach($protectionPolicy in $protectionPolicies)
	{
		Assert-NotNull $protectionPolicy.Name 'Name should not be null'
		Assert-NotNull $protectionPolicy.Type 'Type should not be null'
		Assert-NotNull $protectionPolicy.BackupTime 'BackupTime should not be null'
		Assert-NotNull $protectionPolicy.RetentionPolicy 'RetentionPolicy should not be null'
		Assert-NotNull $protectionPolicy.ResourceGroupName 'ResourceGroupName should not be null'
		Assert-NotNull $protectionPolicy.ResourceName 'ResourceName should not be null'
		Assert-NotNull $protectionPolicy.Location 'Location should not be null'
	}
}

function Test-GetAzureBackupProtectionPolicyByNameTests
{
	$vault = Get-AzureRmBackupVault -Name $ResourceName;
	$protectionPolicy = Get-AzureRmBackupProtectionPolicy -vault $vault -Name $PolicyName
	
	Assert-NotNull $protectionPolicy.Name 'Name should not be null'
	Assert-NotNull $protectionPolicy.Type 'Type should not be null'
	Assert-NotNull $protectionPolicy.BackupTime 'BackupTime should not be null'
	Assert-NotNull $protectionPolicy.RetentionPolicy 'RetentionPolicy should not be null'
	Assert-NotNull $protectionPolicy.ResourceGroupName 'ResourceGroupName should not be null'
	Assert-NotNull $protectionPolicy.ResourceName 'ResourceName should not be null'
	Assert-NotNull $protectionPolicy.Location 'Location should not be null'
	
}

function Test-NewAzureBackupProtectionPolicyTests
{	
	$vault = Get-AzureRmBackupVault -Name $ResourceName;
	$r1 = New-AzureRmBackupRetentionPolicyObject -DailyRetention -Retention 20
	$r2 = New-AzureRmBackupRetentionPolicyObject -WeeklyRetention -DaysOfWeek "Monday" -Retention 10
	$r = ($r1, $r2)

	$protectionPolicy = New-AzureRmBackupProtectionPolicy -vault $vault -Name $PolicyName -Type $Type -Daily -RetentionPolicy $r -BackupTime $BackupTime
	
	Assert-NotNull $protectionPolicy.Name 'Name should not be null'
	Assert-NotNull $protectionPolicy.Type 'Type should not be null'
	Assert-NotNull $protectionPolicy.BackupTime  'BackupTime  should not be null'
	Assert-NotNull $protectionPolicy.RetentionPolicy 'RetentionPolicy should not be null'
	Assert-NotNull $protectionPolicy.ResourceGroupName 'ResourceGroupName should not be null'
	Assert-NotNull $protectionPolicy.ResourceName 'ResourceName should not be null'
	Assert-NotNull $protectionPolicy.Location 'Location should not be null'
}

function Test-SetAzureBackupProtectionPolicyTests
{	
	$vault = Get-AzureRmBackupVault -Name $ResourceName;
	$protectionPolicy = Get-AzureRmBackupProtectionPolicy -vault $vault -Name $PolicyName
	$policyNewName = "policy09-new"
	
	Set-AzureRmBackupProtectionPolicy -ProtectionPolicy $protectionPolicy -NewName $policyNewName	
}

function Test-RemoveAzureBackupProtectionPolicyTests
{	

	$vault = Get-AzureRmBackupVault -Name $ResourceName;
	$protectionPolicy = Get-AzureRmBackupProtectionPolicy -vault $vault -Name $PolicyName
	
	Remove-AzureRmBackupProtectionPolicy -ProtectionPolicy $protectionPolicy -Force
}