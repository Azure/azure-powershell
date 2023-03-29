﻿# ----------------------------------------------------------------------------------
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

# $location = "southeastasia"
# $resourceGroupName = "pstestwlRG1bca8"
# $vaultName = "pstestwlRSV1bca8"

$newPolicyName = "testSqlPolicy"
$location = "centraluseuap"
$resourceGroupName = "iaasvm-pstest-rg"
$vaultName = "iaasvm-pstest-vault"

function Test-AzureVmWorkloadNonUTCPolicy
{
	$resourceGroupName = "hiagarg"
	$vaultName = "hiaga-zrs-vault"		
	$newSQLPolnonUTC = "sql-pstest-local-policy"	

	try
	{	
		# get vault
		$vault = Get-AzRecoveryServicesVault -ResourceGroupName $resourceGroupName -Name $vaultName

		$date= Get-Date -Hour 9 -Minute 0 -Second 0 -Year 2022 -Day 26 -Month 12 -Millisecond 0
		$date = [DateTime]::SpecifyKind($date,[DateTimeKind]::Utc)		

		## non-UTC policy timezone
		$timeZone = Get-TimeZone -ListAvailable | Where-Object { $_.Id -match "Tokyo" } 		
		
		# create SQL policies 
		$schPol = Get-AzRecoveryServicesBackupSchedulePolicyObject -WorkloadType MSSQL -BackupManagementType AzureWorkload -PolicySubType Standard
		$retPol = Get-AzRecoveryServicesBackupRetentionPolicyObject -WorkloadType MSSQL -BackupManagementType AzureWorkload
		$schPol.FullBackupSchedulePolicy.ScheduleRunFrequency = "Weekly"
		$schPol.FullBackupSchedulePolicy.ScheduleRunTimes[0] = $date
		$retPol.FullBackupRetentionPolicy.IsDailyScheduleEnabled = $false
		$retPol.FullBackupRetentionPolicy.IsMonthlyScheduleEnabled = $false
		$retPol.FullBackupRetentionPolicy.WeeklySchedule.DurationCountInWeeks = 35
		$retPol.FullBackupRetentionPolicy.YearlySchedule.DurationCountInYears = 2
		$schPol.IsDifferentialBackupEnabled = $true
		$schPol.DifferentialBackupSchedulePolicy.ScheduleRunDays[0] = "Wednesday"
		$schPol.DifferentialBackupSchedulePolicy.ScheduleRunTimes[0] = $date.AddHours(1)
		$retPol.DifferentialBackupRetentionPolicy.RetentionCount = 15
		$schPol.FullBackupSchedulePolicy.ScheduleRunTimeZone = $timeZone[0].Id
		
		$polLocal = New-AzRecoveryServicesBackupProtectionPolicy -Name $newSQLPolnonUTC -WorkloadType MSSQL -BackupManagementType AzureWorkload -RetentionPolicy $retPol -SchedulePolicy $schPol -VaultId $vault.ID
		
		# assert
		Assert-True { $polLocal.FullBackupSchedulePolicy.ScheduleRunTimes[0].Hour -eq 9 }
		Assert-True { $polLocal.FullBackupSchedulePolicy.ScheduleRunTimes[0].Kind -eq "Utc" }
		Assert-True { $polLocal.FullBackupSchedulePolicy.ScheduleRunTimeZone -eq "Tokyo Standard Time" }
		
		$schPol.FullBackupSchedulePolicy.ScheduleRunTimeZone = "UTC"
		Set-AzRecoveryServicesBackupProtectionPolicy -Policy $polLocal[0] -SchedulePolicy $schPol -VaultId $vault.ID
		$polLocal = Get-AzRecoveryServicesBackupProtectionPolicy -Name $newSQLPolnonUTC -VaultId $vault.ID

		Assert-True { $polLocal.FullBackupSchedulePolicy.ScheduleRunTimes[0].Hour -eq 9 }
		Assert-True { $polLocal.FullBackupSchedulePolicy.ScheduleRunTimes[0].Kind -eq "Utc" }
		Assert-True { $polLocal.FullBackupSchedulePolicy.ScheduleRunTimeZone -eq "UTC" }		
	}
	finally
	{
		# delete policies
		Remove-AzRecoveryServicesBackupProtectionPolicy -VaultId $vault.ID -Name $newSQLPolnonUTC -Force
	}
}

function Test-AzureVmWorkloadSmartTieringPolicy
{
	$location = "centraluseuap"
	$resourceGroupName = "hiagarg"
	$vaultName = "hiagaVault"
	$tierRecommendedPolicy =  "hiagaSQLArchiveTierRecommended"
	$tierAfterPolicy = "hiagaSQLArchiveTierAfter"	
	$archiveDisabledPolicy = "hiagaSQLArchiveDisabled"
	
	try
	{
		$vault = Get-AzRecoveryServicesVault -ResourceGroupName $resourceGroupName -Name $vaultName

		$schPol = Get-AzRecoveryServicesBackupSchedulePolicyObject -WorkloadType MSSQL -BackupManagementType AzureWorkload
		$retPol = Get-AzRecoveryServicesBackupRetentionPolicyObject -WorkloadType MSSQL -BackupManagementType AzureWorkload

		# error scenario - tier recommended not supported 
		Assert-ThrowsContains { $pol = New-AzRecoveryServicesBackupProtectionPolicy -Name $tierRecommendedPolicy -WorkloadType MSSQL  -BackupManagementType AzureWorkload -RetentionPolicy $retPol -SchedulePolicy $schPol -VaultId $vault.ID  -MoveToArchiveTier $true -TieringMode TierRecommended } `
		"Tiering mode TierRecommended is not supported for BackupManagementType AzureWorkload";
		
		
		# error scenario for tier after policy
		Assert-ThrowsContains { $pol = New-AzRecoveryServicesBackupProtectionPolicy -Name $tierAfterPolicy -WorkloadType MSSQL -BackupManagementType AzureWorkload -RetentionPolicy $retPol -SchedulePolicy $schPol -VaultId $vault.ID -MoveToArchiveTier $true -TieringMode TierAllEligible -TierAfterDuration 40 -TierAfterDurationType Days } `
		"TierAfterDuration needs to be >= 45 Days, at least one retention policy for full backup (daily / weekly / monthly / yearly) should be >= (TierAfter + 180) days";

		# create tier after policy 
		$pol = New-AzRecoveryServicesBackupProtectionPolicy -Name $tierAfterPolicy  -WorkloadType MSSQL  -BackupManagementType AzureWorkload -RetentionPolicy $retPol -SchedulePolicy $schPol -VaultId $vault.ID  -MoveToArchiveTier $true -TieringMode TierAllEligible -TierAfterDuration 45 -TierAfterDurationType Days
		
		Assert-True { $pol.Name -eq $tierAfterPolicy }	
		
		# modify policy
		$pol = Get-AzRecoveryServicesBackupProtectionPolicy  -VaultId $vault.ID | Where { $_.Name -match $tierAfterPolicy }
		Set-AzRecoveryServicesBackupProtectionPolicy -VaultId $vault.ID -Policy $pol[0] -MoveToArchiveTier $false
		Set-AzRecoveryServicesBackupProtectionPolicy -VaultId $vault.ID -Policy $pol[0] -MoveToArchiveTier $true -TieringMode TierAllEligible -TierAfterDuration 45 -TierAfterDurationType Days

		# create archive disabled policy 
		$pol = New-AzRecoveryServicesBackupProtectionPolicy -Name $archiveDisabledPolicy -WorkloadType MSSQL -BackupManagementType AzureWorkload -RetentionPolicy $retPol -SchedulePolicy $schPol -VaultId $vault.ID -MoveToArchiveTier $false
		Assert-True { $pol.Name -eq $archiveDisabledPolicy }	
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

function Test-AzureVmWorkloadPolicy
{
	$vault = Get-AzRecoveryServicesVault -ResourceGroupName $resourceGroupName -Name $vaultName
	
	# Get default policy objects
	$schedulePolicy = Get-AzRecoveryServicesBackupSchedulePolicyObject -WorkloadType MSSQL
	Assert-NotNull $schedulePolicy
	$retentionPolicy = Get-AzRecoveryServicesBackupRetentionPolicyObject -WorkloadType MSSQL
	Assert-NotNull $retentionPolicy

	# Create policy
	$policy = New-AzRecoveryServicesBackupProtectionPolicy `
		-VaultId $vault.ID `
		-Name $newPolicyName `
		-WorkloadType MSSQL `
		-RetentionPolicy $retentionPolicy `
		-SchedulePolicy $schedulePolicy
	Assert-NotNull $policy
	Assert-AreEqual $policy.Name $newPolicyName

	# Get policy
	$policy = Get-AzRecoveryServicesBackupProtectionPolicy `
		-VaultId $vault.ID `
		-Name $newPolicyName
	Assert-NotNull $policy
	Assert-AreEqual $policy.Name $newPolicyName

	# Get default policy objects (this data is generated partially at random. So, running this again gives different values)
	$schedulePolicy = Get-AzRecoveryServicesBackupSchedulePolicyObject -WorkloadType MSSQL
	$schedulePolicy.FullBackupSchedulePolicy.ScheduleRunFrequency = "Weekly"
	$schedulePolicy.IsDifferentialBackupEnabled = $true
	$schedulePolicy.IsCompression = $true
	Assert-NotNull $schedulePolicy
  
	$retentionPolicy = Get-AzRecoveryServicesBackupRetentionPolicyObject -WorkloadType MSSQL
	$retentionPolicy.FullBackupRetentionPolicy.IsDailyScheduleEnabled = $false
	$retentionPolicy.DifferentialBackupRetentionPolicy.RetentionCount = 31
	Assert-NotNull $retentionPolicy

	# Update policy
	Set-AzRecoveryServicesBackupProtectionPolicy `
		-VaultId $vault.ID `
		-RetentionPolicy $retentionPolicy `
		-SchedulePolicy $schedulePolicy `
		-Policy $policy
	$policy = Get-AzRecoveryServicesBackupProtectionPolicy `
		-VaultId $vault.ID `
		-Name $newPolicyName
	Assert-AreEqual $policy.DifferentialBackupRetentionPolicy.RetentionCount $retentionPolicy.DifferentialBackupRetentionPolicy.RetentionCount
	Assert-AreEqual $policy.IsCompression $schedulePolicy.IsCompression
	Assert-AreEqual $schedulePolicy.IsDifferentialBackupEnabled $true
	Assert-AreEqual $schedulePolicy.IsLogBackupEnabled $true

	# Fix Policy Update for failed items
	Set-AzRecoveryServicesBackupProtectionPolicy `
		-VaultId $vault.ID `
		-FixForInconsistentItems `
		-Policy $policy

	# Delete policy
	Remove-AzRecoveryServicesBackupProtectionPolicy `
		-VaultId $vault.ID `
		-Policy $policy `
		-Force
	$policy = Get-AzRecoveryServicesBackupProtectionPolicy `
		-VaultId $vault.ID `
		-WorkloadType MSSQL
	Assert-False { $policy.Name -contains $newPolicyName }
}