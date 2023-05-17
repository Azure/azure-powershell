if(($null -eq $TestName) -or ($TestName -contains 'Edit-AzRecoveryServicesBackupSchedulePolicyClientObject'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'Edit-AzRecoveryServicesBackupSchedulePolicyClientObject.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Edit-AzRecoveryServicesBackupSchedulePolicyClientObject' {

    It 'AzureVMStandardDaily' {
        $sub = $env.TestBackupSchedulePolicy.SubscriptionId
        $rgName = $env.TestBackupSchedulePolicy.ResourceGroupName
        $vaultName = $env.TestBackupSchedulePolicy.VaultName
        $newPolicyName = $env.TestBackupSchedulePolicy.NewPolicyName

        $DebugPreference = "Continue"
        Write-Debug  -Message $sub
        Write-Debug  -Message $rgName
        Write-Debug  -Message $vaultName
        Write-Debug  -Message $newPolicyName
        $DebugPreference = "SilentlyContinue"

        $pol = Get-AzRecoveryServicesPolicyTemplate -DatasourceType AzureVM
        $testPolicy = Edit-AzRecoveryServicesBackupSchedulePolicyClientObject -Policy $pol -PolicySubType "Standard" -BackupFrequency "Daily" -ScheduleTime "1:30 PM" -TimeZone "Tokyo Standard Time"
        
        # Default values for testing
        $testPolicy.RetentionPolicy.WeeklySchedule = $null
        $testPolicy.RetentionPolicy.MonthlySchedule = $null
        $testPolicy.RetentionPolicy.YearlySchedule = $null

        $testPolicy.SchedulePolicy.ScheduleRunFrequency | Should be "Daily"
        $testPolicy.SchedulePolicy.ScheduleRunTime[0].ToString("HH:mm:ss") | Should be "13:30:00"
        $testPolicy.TimeZone | Should be "Tokyo Standard Time"

        New-AzRecoveryServicesBackupPolicy -ResourceGroupName $rgName -VaultName $vaultName -Policy $testPolicy -PolicyName $newPolicyName

        # this Policy should be there - then delete it and then this policy shouldn't be there
        $policy = Get-AzRecoveryServicesBackupPolicy -ResourceGroupName $rgName -VaultName $vaultName -PolicyName $newPolicyName
        $policy.Name | Should be $newPolicyName

        Remove-AzRecoveryServicesBackupPolicy -PolicyName $newPolicyName -ResourceGroupName $rgName -VaultName $vaultName
    }

    It 'AzureVMEnhancedWeekly' {
        $sub = $env.TestBackupSchedulePolicy.SubscriptionId
        $rgName = $env.TestBackupSchedulePolicy.ResourceGroupName
        $vaultName = $env.TestBackupSchedulePolicy.VaultName
        $newPolicyName = $env.TestBackupSchedulePolicy.NewPolicyName

        $DebugPreference = "Continue"
        Write-Debug  -Message $sub
        Write-Debug  -Message $rgName
        Write-Debug  -Message $vaultName
        Write-Debug  -Message $newPolicyName
        $DebugPreference = "SilentlyContinue"

        $pol = Get-AzRecoveryServicesPolicyTemplate -DatasourceType AzureVM
        $testPolicy = Edit-AzRecoveryServicesBackupSchedulePolicyClientObject -Policy $pol -PolicySubType "Enhanced" -BackupFrequency "Weekly" -ScheduleRunDay @("Monday", "Thursday") -ScheduleTime "1:30 PM" -TimeZone "Tokyo Standard Time"
        
        # Default values for testing
        $testPolicy.RetentionPolicy.DailySchedule = $null
        $testPolicy.RetentionPolicy.MonthlySchedule = $null
        $testPolicy.RetentionPolicy.YearlySchedule = $null

        $testPolicy.SchedulePolicy.WeeklyScheduleRunDay | Should be @("Monday", "Thursday")
        $testPolicy.SchedulePolicy.WeeklyScheduleRunTime[0].ToString("HH:mm:ss") | Should be "13:30:00"
        $testPolicy.SchedulePolicy.Type | Should be "SimpleSchedulePolicyV2"
        $testPolicy.TimeZone | Should be "Tokyo Standard Time"
        
        New-AzRecoveryServicesBackupPolicy -ResourceGroupName $rgName -VaultName $vaultName -Policy $testPolicy -PolicyName $newPolicyName

        # this Policy should be there - then delete it and then this policy shouldn't be there
        $policy = Get-AzRecoveryServicesBackupPolicy -ResourceGroupName $rgName -VaultName $vaultName -PolicyName $newPolicyName
        $policy.Name | Should be $newPolicyName

        Remove-AzRecoveryServicesBackupPolicy -PolicyName $newPolicyName -ResourceGroupName $rgName -VaultName $vaultName
    }

    It 'AzureVMEnhancedHourly' {
        $sub = $env.TestBackupSchedulePolicy.SubscriptionId
        $rgName = $env.TestBackupSchedulePolicy.ResourceGroupName
        $vaultName = $env.TestBackupSchedulePolicy.VaultName
        $newPolicyName = $env.TestBackupSchedulePolicy.NewPolicyName

        $DebugPreference = "Continue"
        Write-Debug  -Message $sub
        Write-Debug  -Message $rgName
        Write-Debug  -Message $vaultName
        Write-Debug  -Message $newPolicyName
        $DebugPreference = "SilentlyContinue"

        $pol = Get-AzRecoveryServicesPolicyTemplate -DatasourceType AzureVM
        $testPolicy = Edit-AzRecoveryServicesBackupSchedulePolicyClientObject -Policy $pol -PolicySubType "Enhanced" -BackupFrequency "Hourly" -HourlyInterval 4 -HourlyScheduleWindowDuration 24 -ScheduleTime "1:30 PM" -TimeZone "Tokyo Standard Time"
        
        # Default values for testing
        $testPolicy.InstantRpRetentionRangeInDay = 7
        $testPolicy.RetentionPolicy.WeeklySchedule = $null
        $testPolicy.RetentionPolicy.MonthlySchedule = $null
        $testPolicy.RetentionPolicy.YearlySchedule = $null

        $testPolicy.SchedulePolicy.ScheduleRunFrequency | Should be "Hourly"
        $testPolicy.SchedulePolicy.HourlySchedule.Interval | Should be 4
        $testPolicy.SchedulePolicy.HourlySchedule.ScheduleWindowDuration | Should be 24
        $testPolicy.SchedulePolicy.HourlySchedule.ScheduleWindowStartTime.ToString("HH:mm:ss") | Should be "13:30:00"
        $testPolicy.SchedulePolicy.Type | Should be "SimpleSchedulePolicyV2"
        $testPolicy.TimeZone | Should be "Tokyo Standard Time"
        
        New-AzRecoveryServicesBackupPolicy -ResourceGroupName $rgName -VaultName $vaultName -Policy $testPolicy -PolicyName $newPolicyName

        # this Policy should be there - then delete it and then this policy shouldn't be there
        $policy = Get-AzRecoveryServicesBackupPolicy -ResourceGroupName $rgName -VaultName $vaultName -PolicyName $newPolicyName
        $policy.Name | Should be $newPolicyName

        Remove-AzRecoveryServicesBackupPolicy -PolicyName $newPolicyName -ResourceGroupName $rgName -VaultName $vaultName
    }

    It 'SAPHANADailyFull' {
        $sub = $env.TestBackupSchedulePolicy.SubscriptionId
        $rgName = $env.TestBackupSchedulePolicy.ResourceGroupName
        $vaultName = $env.TestBackupSchedulePolicy.VaultName
        $newPolicyName = $env.TestBackupSchedulePolicy.NewPolicyName

        $DebugPreference = "Continue"
        Write-Debug  -Message $sub
        Write-Debug  -Message $rgName
        Write-Debug  -Message $vaultName
        Write-Debug  -Message $newPolicyName
        $DebugPreference = "SilentlyContinue"

        $pol = Get-AzRecoveryServicesPolicyTemplate -DatasourceType SAPHANA
        $testPolicy = Edit-AzRecoveryServicesBackupSchedulePolicyClientObject -Policy $pol -BackupFrequency "Daily" -ScheduleTime "1:30 PM" -TimeZone "Tokyo Standard Time"
        
        $FullBackupPolicy =  $testPolicy.SubProtectionPolicy | Where-Object { $_.PolicyType -match "Full" }
        $FullBackupPolicy.SchedulePolicy.ScheduleRunFrequency | Should be "Daily"
        $FullBackupPolicy.SchedulePolicy.ScheduleRunTime[0].ToString("HH:mm:ss") | Should be "13:30:00"
        $testPolicy.Setting.TimeZone | Should be "Tokyo Standard Time"

        New-AzRecoveryServicesBackupPolicy -ResourceGroupName $rgName -VaultName $vaultName -Policy $testPolicy -PolicyName $newPolicyName

        # this Policy should be there - then delete it and then this policy shouldn't be there
        $policy = Get-AzRecoveryServicesBackupPolicy -ResourceGroupName $rgName -VaultName $vaultName -PolicyName $newPolicyName
        $policy.Name | Should be $newPolicyName

        Remove-AzRecoveryServicesBackupPolicy -PolicyName $newPolicyName -ResourceGroupName $rgName -VaultName $vaultName
    }

    It 'SAPHANAWeeklyDifferential' {
        $sub = $env.TestBackupSchedulePolicy.SubscriptionId
        $rgName = $env.TestBackupSchedulePolicy.ResourceGroupName
        $vaultName = $env.TestBackupSchedulePolicy.VaultName
        $newPolicyName = $env.TestBackupSchedulePolicy.NewPolicyName

        $DebugPreference = "Continue"
        Write-Debug  -Message $sub
        Write-Debug  -Message $rgName
        Write-Debug  -Message $vaultName
        Write-Debug  -Message $newPolicyName
        $DebugPreference = "SilentlyContinue"

        $pol = Get-AzRecoveryServicesPolicyTemplate -DatasourceType SAPHANA
        $ScheduleRunDay = @("Monday", "Thursday")
        $DifferentialRunDay = @("Tuesday", "Friday")
        $testPolicy = Edit-AzRecoveryServicesBackupSchedulePolicyClientObject -Policy $pol -BackupFrequency "Weekly" -ScheduleRunDay $ScheduleRunDay -EnableDifferentialBackup 1 -DifferentialRunDay $DifferentialRunDay -DifferentialScheduleTime "2:00 AM" -ScheduleTime "1:30 PM" -TimeZone "Tokyo Standard Time"
        
        $FullBackupPolicy =  $testPolicy.SubProtectionPolicy | Where-Object { $_.PolicyType -match "Full" }
        
        # Default values for testing
        $FullBackupPolicy.RetentionPolicy.DailySchedule = $null
        $FullBackupPolicy.RetentionPolicy.MonthlySchedule.RetentionScheduleWeekly.DaysOfTheWeek[0] = $ScheduleRunDay[0]
        $FullBackupPolicy.RetentionPolicy.YearlySchedule.RetentionScheduleWeekly.DaysOfTheWeek[0] = $ScheduleRunDay[0]
        
        $FullBackupPolicy.SchedulePolicy.ScheduleRunFrequency | Should be "Weekly"
        $FullBackupPolicy.SchedulePolicy.ScheduleRunDay | Should be $ScheduleRunDay
        $FullBackupPolicy.SchedulePolicy.ScheduleRunTime[0].ToString("HH:mm:ss") | Should be "13:30:00"
        $testPolicy.Setting.TimeZone | Should be "Tokyo Standard Time"

        $DifferentialPolicy =  $testPolicy.SubProtectionPolicy | Where-Object { $_.PolicyType -match "Differential" }

        # Default values for testing
        $DifferentialPolicy.RetentionPolicy = [Microsoft.Azure.PowerShell.Cmdlets.RecoveryServices.Models.Api20230201.SimpleRetentionPolicy]::new()
        $DifferentialPolicy.RetentionPolicy.Type = "SimpleRetentionPolicy"
        $DifferentialPolicy.RetentionPolicy.RetentionDurationCount = 30
        $DifferentialPolicy.RetentionPolicy.RetentionDurationType = "Days"

        $DifferentialPolicy.PolicyType | Should be "Differential"
        $DifferentialPolicy.SchedulePolicy.Type | Should be "SimpleSchedulePolicy"
        $DifferentialPolicy.SchedulePolicy.ScheduleRunFrequency | Should be "Weekly"
        $DifferentialPolicy.SchedulePolicy.ScheduleRunDay | Should be $DifferentialRunDay
        $DifferentialPolicy.SchedulePolicy.ScheduleRunTime[0].ToString("HH:mm:ss") | Should be "02:00:00"
        $DifferentialPolicy.SchedulePolicy.ScheduleWeeklyFrequency | Should be 0

        New-AzRecoveryServicesBackupPolicy -ResourceGroupName $rgName -VaultName $vaultName -Policy $testPolicy -PolicyName $newPolicyName
    
        # this Policy should be there - then delete it and then this policy shouldn't be there
        $policy = Get-AzRecoveryServicesBackupPolicy -ResourceGroupName $rgName -VaultName $vaultName -PolicyName $newPolicyName
        $policy.Name | Should be $newPolicyName

        Remove-AzRecoveryServicesBackupPolicy -PolicyName $newPolicyName -ResourceGroupName $rgName -VaultName $vaultName
    }
     
    It 'SAPHANWeeklyIncremental' {
        $sub = $env.TestBackupSchedulePolicy.SubscriptionId
        $rgName = $env.TestBackupSchedulePolicy.ResourceGroupName
        $vaultName = $env.TestBackupSchedulePolicy.VaultName
        $newPolicyName = $env.TestBackupSchedulePolicy.NewPolicyName

        $DebugPreference = "Continue"
        Write-Debug  -Message $sub
        Write-Debug  -Message $rgName
        Write-Debug  -Message $vaultName
        Write-Debug  -Message $newPolicyName
        $DebugPreference = "SilentlyContinue"

        $pol = Get-AzRecoveryServicesPolicyTemplate -DatasourceType SAPHANA
        $ScheduleRunDay = @("Monday", "Thursday")
        $IncrementalRunDay = @("Tuesday", "Friday")
        $testPolicy = Edit-AzRecoveryServicesBackupSchedulePolicyClientObject -Policy $pol -BackupFrequency "Weekly" -ScheduleRunDay $ScheduleRunDay -EnableIncrementalBackup 1 -IncrementalRunDay $IncrementalRunDay -IncrementalScheduleTime "2:00 AM" -ScheduleTime "1:30 PM" -TimeZone "Tokyo Standard Time"
        
        $FullBackupPolicy =  $testPolicy.SubProtectionPolicy | Where-Object { $_.PolicyType -match "Full" }

        # Default values for testing
        $FullBackupPolicy.RetentionPolicy.DailySchedule = $null
        $FullBackupPolicy.RetentionPolicy.MonthlySchedule.RetentionScheduleWeekly.DaysOfTheWeek[0] = $ScheduleRunDay[0]
        $FullBackupPolicy.RetentionPolicy.YearlySchedule.RetentionScheduleWeekly.DaysOfTheWeek[0] = $ScheduleRunDay[0]

        $FullBackupPolicy.SchedulePolicy.ScheduleRunFrequency | Should be "Weekly"
        $FullBackupPolicy.SchedulePolicy.ScheduleRunDay | Should be $ScheduleRunDay
        $FullBackupPolicy.SchedulePolicy.ScheduleRunTime[0].ToString("HH:mm:ss") | Should be "13:30:00"
        $testPolicy.Setting.TimeZone | Should be "Tokyo Standard Time"

        $IncrementalPolicy =  $testPolicy.SubProtectionPolicy | Where-Object { $_.PolicyType -match "Incremental" }

        # Default values for testing
        $IncrementalPolicy.RetentionPolicy = [Microsoft.Azure.PowerShell.Cmdlets.RecoveryServices.Models.Api20230201.SimpleRetentionPolicy]::new()
        $IncrementalPolicy.RetentionPolicy.Type = "SimpleRetentionPolicy"
        $IncrementalPolicy.RetentionPolicy.RetentionDurationCount = 30
        $IncrementalPolicy.RetentionPolicy.RetentionDurationType = "Days"

        $IncrementalPolicy.PolicyType | Should be "Incremental"
        $IncrementalPolicy.SchedulePolicy.Type | Should be "SimpleSchedulePolicy"
        $IncrementalPolicy.SchedulePolicy.ScheduleRunFrequency | Should be "Weekly"
        $IncrementalPolicy.SchedulePolicy.ScheduleRunDay | Should be $IncrementalRunDay
        $IncrementalPolicy.SchedulePolicy.ScheduleRunTime[0].ToString("HH:mm:ss") | Should be "02:00:00"
        $IncrementalPolicy.SchedulePolicy.ScheduleWeeklyFrequency | Should be 0
        
        New-AzRecoveryServicesBackupPolicy -ResourceGroupName $rgName -VaultName $vaultName -Policy $testPolicy -PolicyName $newPolicyName

        # this Policy should be there - then delete it and then this policy shouldn't be there
        $policy = Get-AzRecoveryServicesBackupPolicy -ResourceGroupName $rgName -VaultName $vaultName -PolicyName $newPolicyName
        $policy.Name | Should be $newPolicyName

        Remove-AzRecoveryServicesBackupPolicy -PolicyName $newPolicyName -ResourceGroupName $rgName -VaultName $vaultName
    }

    It 'SAPHANALog' {
        $sub = $env.TestBackupSchedulePolicy.SubscriptionId
        $rgName = $env.TestBackupSchedulePolicy.ResourceGroupName
        $vaultName = $env.TestBackupSchedulePolicy.VaultName
        $newPolicyName = $env.TestBackupSchedulePolicy.NewPolicyName

        $DebugPreference = "Continue"
        Write-Debug  -Message $sub
        Write-Debug  -Message $rgName
        Write-Debug  -Message $vaultName
        Write-Debug  -Message $newPolicyName
        $DebugPreference = "SilentlyContinue"

        $pol = Get-AzRecoveryServicesPolicyTemplate -DatasourceType SAPHANA
        $testPolicy = Edit-AzRecoveryServicesBackupSchedulePolicyClientObject -Policy $pol -EnableLogBackup 1 -LogBackupFrequencyInMin 120        

        $LogBackupPolicy =  $testPolicy.SubProtectionPolicy | Where-Object { $_.PolicyType -match "Log" }
        $LogBackupPolicy.PolicyType | Should be "Log"
        $LogBackupPolicy.SchedulePolicy.ScheduleFrequencyInMin | Should be 120

        New-AzRecoveryServicesBackupPolicy -ResourceGroupName $rgName -VaultName $vaultName -Policy $testPolicy -PolicyName $newPolicyName

        # this Policy should be there - then delete it and then this policy shouldn't be there
        $policy = Get-AzRecoveryServicesBackupPolicy -ResourceGroupName $rgName -VaultName $vaultName -PolicyName $newPolicyName
        $policy.Name | Should be $newPolicyName

        Remove-AzRecoveryServicesBackupPolicy -PolicyName $newPolicyName -ResourceGroupName $rgName -VaultName $vaultName
    }

}