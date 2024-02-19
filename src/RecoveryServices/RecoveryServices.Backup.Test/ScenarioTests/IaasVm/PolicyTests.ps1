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

function Test-AzureVMCrashconsistentPolicy
{
	$location = "centraluseuap"
	$resourceGroupName = "hiagarg"
	$vaultName = "hiagaVault"
	$newPolicyName = "PScrashConsistentPolicy"
	
	try
	{
		$vault = Get-AzRecoveryServicesVault -ResourceGroupName $resourceGroupName -Name $vaultName
				
		# get weekly default schedule
		$schedulePolicy = Get-AzRecoveryServicesBackupSchedulePolicyObject -WorkloadType AzureVM -BackupManagementType AzureVM -PolicySubType Enhanced -ScheduleRunFrequency Weekly
		Assert-NotNull $schedulePolicy

		# get default weekly retention schedule 
		$retentionPolicy = Get-AzRecoveryServicesBackupRetentionPolicyObject -WorkloadType AzureVM -BackupManagementType AzureVM -ScheduleRunFrequency Weekly
		Assert-NotNull $retentionPolicy

		# create crash consistent policy
		$policy = New-AzRecoveryServicesBackupProtectionPolicy -Name $newPolicyName -WorkloadType AzureVM -BackupManagementType AzureVM -RetentionPolicy $retentionPolicy -SchedulePolicy $schedulePolicy -VaultId $vault.ID -SnapshotConsistencyType OnlyCrashConsistent

		# validate crash consistent
		$policy = Get-AzRecoveryServicesBackupProtectionPolicy -VaultId $vault.ID -Name $newPolicyName
		Assert-NotNull $policy
		Assert-AreEqual $policy.Name $newPolicyName
		Assert-AreEqual $policy.SnapshotConsistencyType "OnlyCrashConsistent"

        # update consistency type to default
		$policy = Set-AzRecoveryServicesBackupProtectionPolicy -Policy $policy -SnapshotConsistencyType Default -VaultId $vault.ID
		$policy = Get-AzRecoveryServicesBackupProtectionPolicy -VaultId $vault.ID -Name $newPolicyName
		Assert-AreEqual $policy.SnapshotConsistencyType $null	
		
		# update consistency type to OnlyCrashConsistent
		$policy = Set-AzRecoveryServicesBackupProtectionPolicy -Policy $policy -SnapshotConsistencyType OnlyCrashConsistent -VaultId $vault.ID
		$policy = Get-AzRecoveryServicesBackupProtectionPolicy -VaultId $vault.ID -Name $newPolicyName
		Assert-AreEqual $policy.SnapshotConsistencyType "OnlyCrashConsistent"
	}
	finally
	{
		# Cleanup		
		# Delete policy
		$policy = Get-AzRecoveryServicesBackupProtectionPolicy -VaultId $vault.ID -Name $newPolicyName
		Remove-AzRecoveryServicesBackupProtectionPolicy -VaultId $vault.ID -Policy $policy -Force
	}
}

function Test-AzureVMNonUTCPolicy
{
	$resourceGroupName = "hiagarg"
	$vaultName = "hiaga-zrs-vault"
	$newVMPolUTC = "vm-pstest-utc-policy"
	$newVMPolnonUTC = "vm-pstest-local-policy"
	
	try
	{	
		# get vault
		$vault = Get-AzRecoveryServicesVault -ResourceGroupName $resourceGroupName -Name $vaultName

		# create VM policies 

		## get schedule/retention policy objects
		$schPol = Get-AzRecoveryServicesBackupSchedulePolicyObject -WorkloadType AzureVM -BackupManagementType AzureVM -PolicySubType Standard -ScheduleRunFrequency Daily
		$retPol = Get-AzRecoveryServicesBackupRetentionPolicyObject -WorkloadType AzureVM -BackupManagementType AzureVM -ScheduleRunFrequency  Daily
		
		$date= Get-Date -Hour 9 -Minute 0 -Second 0 -Year 2022 -Day 26 -Month 12 -Millisecond 0
		$date = [DateTime]::SpecifyKind($date,[DateTimeKind]::Utc)
		$schPol.ScheduleRunTimes[0] = $date

		$retPol.WeeklySchedule.DurationCountInWeeks = 10
		$retPol.IsYearlyScheduleEnabled = $false

		
		$polUTC = New-AzRecoveryServicesBackupProtectionPolicy -Name $newVMPolUTC -WorkloadType AzureVM -BackupManagementType AzureVM -RetentionPolicy $retPol -SchedulePolicy $schPol -MoveToArchiveTier $true -TieringMode TierRecommended -VaultId $vault.ID
		
		## non-UTC policy timezone
		$timeZone = Get-TimeZone -ListAvailable | Where-Object { $_.Id -match "Tokyo" } 
		$schPol.ScheduleRunTimeZone = $timeZone[0].Id

		$polLocal = New-AzRecoveryServicesBackupProtectionPolicy -Name $newVMPolnonUTC -WorkloadType AzureVM -BackupManagementType AzureVM -RetentionPolicy $retPol -SchedulePolicy $schPol -MoveToArchiveTier $true -TieringMode TierAllEligible -VaultId $vault.ID -TierAfterDurationType Months -TierAfterDuration 3
		
		# assert 
		Assert-True { $polUTC.Name -eq $newVMPolUTC }
		Assert-True { $polLocal.Name -eq $newVMPolnonUTC }
		
		#$polUTC.SchedulePolicy.ScheduleRunTimes[0]  -match "9:00:00"
		#$polLocal.SchedulePolicy.ScheduleRunTimes[0]  -match "9:00:00"
		Assert-True { $polUTC.SchedulePolicy.ScheduleRunTimes[0].Hour -eq 9 }
		Assert-True { $polUTC.SchedulePolicy.ScheduleRunTimes[0].Kind -eq "Utc" }
		
		Assert-True { $polLocal.SchedulePolicy.ScheduleRunTimes[0].Hour -eq 9 }
		Assert-True { $polLocal.SchedulePolicy.ScheduleRunTimes[0].Kind -eq "Utc" }
		
		Assert-True { $polUTC.SchedulePolicy.ScheduleRunTimeZone -eq "UTC" }
		Assert-True { $polLocal.SchedulePolicy.ScheduleRunTimeZone -eq "Tokyo Standard Time" }
	}
	finally
	{
		# delete policies
		Remove-AzRecoveryServicesBackupProtectionPolicy -VaultId $vault.ID -Name $newVMPolUTC -Force
		Remove-AzRecoveryServicesBackupProtectionPolicy -VaultId $vault.ID -Name $newVMPolnonUTC -Force
	}
}

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
		$pol = New-AzRecoveryServicesBackupProtectionPolicy -Name $tierRecommendedPolicy  -WorkloadType AzureVM  -BackupManagementType AzureVM -RetentionPolicy $retPol -SchedulePolicy $schPol -VaultId $vault.ID  -MoveToArchiveTier $true -TieringMode TierRecommended -BackupSnapshotResourceGroup "rgpref1" -BackupSnapshotResourceGroupSuffix "suffix1"

		Assert-True { $pol.Name -eq $tierRecommendedPolicy }		
		Assert-True { $pol.AzureBackupRGName -match "rgpref1" }
		Assert-True { $pol.AzureBackupRGNameSuffix -match "suffix1" }		

		# error scenario for tier after policy
		Assert-ThrowsContains { $pol = New-AzRecoveryServicesBackupProtectionPolicy -Name $tierAfterPolicy  -WorkloadType AzureVM  -BackupManagementType AzureVM -RetentionPolicy $retPol -SchedulePolicy $schPol -VaultId $vault.ID  -MoveToArchiveTier $true -TieringMode TierAllEligible -TierAfterDuration 2 -TierAfterDurationType Months -BackupSnapshotResourceGroup "rgpref1" -BackupSnapshotResourceGroupSuffix "suffix1"} `
		"TierAfterDuration needs to be >= 3 months, at least one of monthly or yearly retention should be >= (TierAfterDuration + 6) months";

		# create tier after policy 
		$pol = New-AzRecoveryServicesBackupProtectionPolicy -Name $tierAfterPolicy -WorkloadType AzureVM  -BackupManagementType AzureVM -RetentionPolicy $retPol -SchedulePolicy $schPol -VaultId $vault.ID  -MoveToArchiveTier $true -TieringMode TierAllEligible -TierAfterDuration 3 -TierAfterDurationType Months  -BackupSnapshotResourceGroup "rgpref1" -BackupSnapshotResourceGroupSuffix "suffix1"

		Assert-True { $pol.Name -eq $tierAfterPolicy }
		Assert-True { $pol.AzureBackupRGName -match "rgpref1" }
		Assert-True { $pol.AzureBackupRGNameSuffix -match "suffix1" }

		# modify policy 
		$pol = Get-AzRecoveryServicesBackupProtectionPolicy  -VaultId $vault.ID | Where { $_.Name -match $tierRecommendedPolicy }
		Set-AzRecoveryServicesBackupProtectionPolicy -VaultId $vault.ID -Policy $pol[0] -MoveToArchiveTier $false

		$pol = Get-AzRecoveryServicesBackupProtectionPolicy  -VaultId $vault.ID | Where { $_.Name -match $tierRecommendedPolicy }
		Assert-True { $pol.AzureBackupRGName -match "rgpref1" }
		Assert-True { $pol.AzureBackupRGNameSuffix -match "suffix1" }

		Set-AzRecoveryServicesBackupProtectionPolicy -VaultId $vault.ID -Policy $pol[0] -MoveToArchiveTier $true -TieringMode TierRecommended -BackupSnapshotResourceGroup "rgpref2"
		
		# error scenario for retention policy
		$pol = Get-AzRecoveryServicesBackupProtectionPolicy  -VaultId $vault.ID | Where { $_.Name -match $tierRecommendedPolicy }
		Assert-True { $pol.AzureBackupRGName -match "rgpref2" }
		Assert-True { $pol.AzureBackupRGNameSuffix -eq $null }

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
	$location = "centraluseuap" # "eastasia"
	$resourceGroupName = Create-ResourceGroup $location 26

	try
	{
		# Setup
		$vault = Create-RecoveryServicesVault $resourceGroupName $location 27
		
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
		# $oldVault = Get-AzRecoveryServicesVault -ResourceGroupName $oldResourceGroupName -Name $oldVaultName
		# $oldPolicy = Get-AzRecoveryServicesBackupProtectionPolicy -Name $oldPolicyName -VaultId $oldVault.ID
		# Assert-AreEqual $oldPolicy.RetentionPolicy.DailySchedule.DurationCountInDays 180
		
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