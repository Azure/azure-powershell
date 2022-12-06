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

$resourceGroupName = "RecoveryServicesBackupTestRg";
$resourceName = "PsTestRsVault";
$policyName = "PsTestPolicy";
$defaultPolicyName = "DefaultPolicy";
$DefaultSnapshotDays = 2;
$UpdatedSnapShotDays = 5;
$rgPrefix = "RecoveryServices";
$rgsuffix = "Policy";

# Test old polices in the VaultId
$oldResourceGroupName = "sambit_rg"
$oldVaultName = "sambit"
$oldPolicyName = "iaasvmretentioncheck"

function Test-AzureVMSmartTieringPolicy
{
	$location = "centraluseuap"
	$resourceGroupName = "hiagarg"
	$vaultName = "hiagaVault"
	$tierRecommendedPolicy =  "hiagaVMArchiveTierRecomm"
	$tierAfterPolicy = "hiagaVMArchiveTierAfter"
	
	try
	{
		$vault = Get-AzRecoveryServicesVault -ResourceGroupName $resourceGroupName -Name $vaultName

		$schPol = Get-AzRecoveryServicesBackupSchedulePolicyObject -WorkloadType AzureVM -BackupManagementType AzureVM -PolicySubType Enhanced -ScheduleRunFrequency Weekly 
		$retPol = Get-AzRecoveryServicesBackupRetentionPolicyObject -WorkloadType AzureVM -BackupManagementType AzureVM -ScheduleRunFrequency  Weekly 

		# create tier recommended policy 
		$pol = New-AzRecoveryServicesBackupProtectionPolicy -Name $tierRecommendedPolicy  -WorkloadType AzureVM  -BackupManagementType AzureVM -RetentionPolicy $retPol -SchedulePolicy $schPol -VaultId $vault.ID  -MoveToArchiveTier $true -TieringMode TierRecommended 

		Assert-True { $pol.Name -eq $tierRecommendedPolicy }
		
		# error scenario for tier after policy
		Assert-ThrowsContains { $pol = New-AzRecoveryServicesBackupProtectionPolicy -Name $tierAfterPolicy  -WorkloadType AzureVM  -BackupManagementType AzureVM -RetentionPolicy $retPol -SchedulePolicy $schPol -VaultId $vault.ID  -MoveToArchiveTier $true -TieringMode TierAllEligible -TierAfterDuration 2 -TierAfterDurationType Months } `
		"TierAfterDuration needs to be >= 3 months, at least one of monthly or yearly retention should be >= (TierAfterDuration + 6) months";

		# create tier after policy 
		$pol = New-AzRecoveryServicesBackupProtectionPolicy -Name $tierAfterPolicy -WorkloadType AzureVM  -BackupManagementType AzureVM -RetentionPolicy $retPol -SchedulePolicy $schPol -VaultId $vault.ID  -MoveToArchiveTier $true -TieringMode TierAllEligible -TierAfterDuration 3 -TierAfterDurationType Months

		Assert-True { $pol.Name -eq $tierAfterPolicy }

		# modify policy 
		$pol = Get-AzRecoveryServicesBackupProtectionPolicy  -VaultId $vault.ID | Where { $_.Name -match $tierRecommendedPolicy }
		Set-AzRecoveryServicesBackupProtectionPolicy -VaultId $vault.ID -Policy $pol[0] -MoveToArchiveTier $false
		Set-AzRecoveryServicesBackupProtectionPolicy -VaultId $vault.ID -Policy $pol[0] -MoveToArchiveTier $true -TieringMode TierRecommended
		
		# error scenario for retention policy
		$pol = Get-AzRecoveryServicesBackupProtectionPolicy  -VaultId $vault.ID | Where { $_.Name -match $tierRecommendedPolicy }
		$pol.RetentionPolicy.IsYearlyScheduleEnabled = $false
		$pol.RetentionPolicy.MonthlySchedule.DurationCountInMonths = 8

		Assert-ThrowsContains { Set-AzRecoveryServicesBackupProtectionPolicy -VaultId $vault.ID -Policy $pol -RetentionPolicy $pol.RetentionPolicy } `
		"At least one of monthly or yearly retention should be >= 9 months as smart tiering is enabled for this policy. Please modify retention or disable smart tiering. Please note that disabling smart tiering may involve additional costs";
	}
	finally
	{
		# Cleanup		
		# Delete policy
		$pol = Get-AzRecoveryServicesBackupProtectionPolicy  -VaultId $vault.ID | Where { $_.Name -match "Archive" }

		foreach ($policy in $pol){
		   Remove-AzRecoveryServicesBackupProtectionPolicy -VaultId $vault.ID -Policy $policy -Force
		}
	}
}

function Test-AzureVMEnhancedPolicy
{
	$location = "centraluseuap"
	$resourceGroupName = "hiagarg"
	$vaultName = "hiagaVault"
	$newEnhPolicyName = "psTestEnhancedPolicy"
	$scheduleRunTime = "2021-12-22T06:00:00.00+00:00"
	
	try
	{
		$vault = Get-AzRecoveryServicesVault -ResourceGroupName $resourceGroupName -Name $vaultName
		
		# create Enhanced policy weekly
		# get weekly default schedule
		$schedulePolicy = Get-AzRecoveryServicesBackupSchedulePolicyObject -WorkloadType AzureVM -BackupManagementType AzureVM -PolicySubType Enhanced -ScheduleRunFrequency Weekly
		Assert-NotNull $schedulePolicy

		# get default weekly retention schedule 
		$retentionPolicy = Get-AzRecoveryServicesBackupRetentionPolicyObject -WorkloadType AzureVM -BackupManagementType AzureVM -ScheduleRunFrequency Weekly
		Assert-NotNull $retentionPolicy

		# create v2 policy
		$policy = New-AzRecoveryServicesBackupProtectionPolicy -Name $newEnhPolicyName -WorkloadType AzureVM -BackupManagementType AzureVM -RetentionPolicy $retentionPolicy -SchedulePolicy $schedulePolicy -VaultId $vault.ID

		Assert-NotNull $policy
		Assert-AreEqual $policy.Name $newEnhPolicyName		
		Assert-AreEqual $policy.PolicySubType "Enhanced"

        # modify Enhanced policy weekly 		
		$timeZone = Get-TimeZone -ListAvailable | Where-Object { $_.Id -match "India" }
		$schedulePolicy.ScheduleRunTimeZone = $timeZone.Id
		$scheduleTime = (Get-Date -Date $scheduleRunTime).ToUniversalTime()
		$schedulePolicy.WeeklySchedule.ScheduleRunTimes[0] = $scheduleTime
		
		$policy = Get-AzRecoveryServicesBackupProtectionPolicy -VaultId $vault.ID -Name $newEnhPolicyName
		
		Assert-NotNull $policy
		Assert-AreEqual $policy.Name $newEnhPolicyName
		Assert-AreEqual $policy.PolicySubType "Enhanced"

		Set-AzRecoveryServicesBackupProtectionPolicy -Policy $policy -VaultId $vault.ID -SchedulePolicy $schedulePolicy		

	    # modify Enhanced policy weekly to Daily
		$schedulePolicy = Get-AzRecoveryServicesBackupSchedulePolicyObject -WorkloadType AzureVM -BackupManagementType AzureVM -PolicySubType Enhanced -ScheduleRunFrequency Daily
		$retentionPolicy = Get-AzRecoveryServicesBackupRetentionPolicyObject -WorkloadType AzureVM -BackupManagementType AzureVM -ScheduleRunFrequency Daily

		$policy = Get-AzRecoveryServicesBackupProtectionPolicy -VaultId $vault.ID -Name $newEnhPolicyName
		Assert-True { $policy.SchedulePolicy.ScheduleRunTimeZone -match "India" }

		Set-AzRecoveryServicesBackupProtectionPolicy -Policy $policy -VaultId $vault.ID -SchedulePolicy $schedulePolicy -RetentionPolicy $retentionPolicy

        # if we try giving non UTC time we would get an error 
		$scheduleTime = (Get-Date -Hour 6 -Minute 0 -Second 0)
		$schedulePolicy.DailySchedule.ScheduleRunTImes[0] = $scheduleTime	
		
		Assert-ThrowsContains {Set-AzRecoveryServicesBackupProtectionPolicy -Policy $policy -VaultId $vault.ID -SchedulePolicy $schedulePolicy } `
			"ScheduleTimes in Schedule should be in UTC Timezone, have ONE time and must be of multiples of 30 Mins with seconds and milliseconds set to 0"
	}
	finally
	{
		# Cleanup		
		# Delete policy
		$policy = Get-AzRecoveryServicesBackupProtectionPolicy -VaultId $vault.ID -Name $newEnhPolicyName
		Remove-AzRecoveryServicesBackupProtectionPolicy -VaultId $vault.ID -Policy $policy -Force
	}
}

function Test-AzureVMPolicy
{
	$location = "eastasia"
	$resourceGroupName = Create-ResourceGroup $location

	try
	{
		# Setup
		$vault = Create-RecoveryServicesVault $resourceGroupName $location
		
		# Get default policy objects
		$schedulePolicy = Get-AzRecoveryServicesBackupSchedulePolicyObject -WorkloadType AzureVM
		Assert-NotNull $schedulePolicy
		$retentionPolicy = Get-AzRecoveryServicesBackupRetentionPolicyObject -WorkloadType AzureVM
		Assert-NotNull $retentionPolicy

		# Create policy
		$policyName = "newPolicy"
		$policy = New-AzRecoveryServicesBackupProtectionPolicy `
			-VaultId $vault.ID `
			-Name $policyName `
			-WorkloadType AzureVM `
			-RetentionPolicy $retentionPolicy `
			-SchedulePolicy $schedulePolicy
		Assert-NotNull $policy
		Assert-AreEqual $policy.Name $policyName
		Assert-AreEqual $policy.SnapshotRetentionInDays $DefaultSnapshotDays

		# Get policy to test older policies
		$oldVault = Get-AzRecoveryServicesVault -ResourceGroupName $oldResourceGroupName -Name $oldVaultName
		$oldPolicy = Get-AzRecoveryServicesBackupProtectionPolicy -Name $oldPolicyName -VaultId $oldVault.ID
		Assert-AreEqual $oldPolicy.RetentionPolicy.DailySchedule.DurationCountInDays 180
		
		# Get policy
	    $policy = Get-AzRecoveryServicesBackupProtectionPolicy `
			-VaultId $vault.ID `
			-Name $policyName
		Assert-NotNull $policy
		Assert-AreEqual $policy.Name $policyName

		$defaultPolicy = Get-AzRecoveryServicesBackupProtectionPolicy `
			-VaultId $vault.ID `
			-Name $defaultPolicyName
		Assert-NotNull $defaultPolicy
		Assert-AreEqual $defaultPolicy.Name $defaultPolicyName

		# Get default policy objects (this data is generated partially at random. So, running this again gives different values)
		$schedulePolicy = Get-AzRecoveryServicesBackupSchedulePolicyObject -WorkloadType AzureVM
		Assert-NotNull $schedulePolicy
		$retentionPolicy = Get-AzRecoveryServicesBackupRetentionPolicyObject -WorkloadType AzureVM
		Assert-NotNull $retentionPolicy

		#update snapshot days
		$policy.SnapshotRetentionInDays = $UpdatedSnapShotDays;
		$policy.AzureBackupRGName = $rgPrefix;
		$policy.AzureBackupRGNameSuffix	= $rgsuffix;

		# Update policy
		Set-AzRecoveryServicesBackupProtectionPolicy `
			-VaultId $vault.ID `
			-RetentionPolicy $retentionPolicy `
			-SchedulePolicy $schedulePolicy `
			-Policy $policy

		$policy = Get-AzRecoveryServicesBackupProtectionPolicy `
			-VaultId $vault.ID `
			-Name $policyName
		Assert-AreEqual $policy.SnapshotRetentionInDays $UpdatedSnapShotDays

		# Delete policy
		Remove-AzRecoveryServicesBackupProtectionPolicy `
			-VaultId $vault.ID `
			-Policy $policy `
			-Force
	}
	finally
	{
		# Cleanup
		Cleanup-ResourceGroup $resourceGroupName
	}
}