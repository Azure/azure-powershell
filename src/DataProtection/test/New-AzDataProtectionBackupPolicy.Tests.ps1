$loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
if (-Not (Test-Path -Path $loadEnvPath)) {
    $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
}
. ($loadEnvPath)
$TestRecordingFile = Join-Path $PSScriptRoot 'New-AzDataProtectionBackupPolicy.Recording.json'
$currentPath = $PSScriptRoot
while(-not $mockingPath) {
    $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
    $currentPath = Split-Path -Path $currentPath -Parent
}
. ($mockingPath | Select-Object -First 1).FullName

Describe 'New-AzDataProtectionBackupPolicy' {
    It '__AllParameterSets' {
        $sub = $env.TestOssBackupScenario.SubscriptionId
        $rgName = $env.TestOssBackupScenario.ResourceGroupName
        $vaultName = $env.TestOssBackupScenario.VaultName
        $newPolicyName = $env.TestOssBackupScenario.NewPolicyName
        
        $DebugPreference = "Continue"
        Write-Debug  -Message $sub
        Write-Debug  -Message $rgName
        Write-Debug  -Message $vaultName
        $DebugPreference = "SilentlyContinue"

        $pol = Get-AzDataProtectionPolicyTemplate -DatasourceType AzureDatabaseForPostgreSQL
        
        $lifeCycle1 = New-AzDataProtectionRetentionLifeCycleClientObject -SourceDataStore ArchiveStore -SourceRetentionDurationType Months -SourceRetentionDurationCount 6
        $lifeCycle = New-AzDataProtectionRetentionLifeCycleClientObject -SourceDataStore VaultStore -SourceRetentionDurationType Months -SourceRetentionDurationCount 3 -TargetDataStore ArchiveStore -CopyOption CopyOnExpiryOption
         
        Edit-AzDataProtectionPolicyRetentionRuleClientObject -Policy $pol -Name Default -LifeCycles $lifeCycle, $lifeCycle1 -IsDefault $true
         
        $lifeCycle = New-AzDataProtectionRetentionLifeCycleClientObject -SourceDataStore VaultStore -SourceRetentionDurationType Months -SourceRetentionDurationCount 6 -TargetDataStore ArchiveStore -CopyOption CopyOnExpiryOption
        $lifeCycle1 = New-AzDataProtectionRetentionLifeCycleClientObject -SourceDataStore ArchiveStore -SourceRetentionDurationType Months -SourceRetentionDurationCount 12
         
        Edit-AzDataProtectionPolicyRetentionRuleClientObject -Policy $pol -Name Monthly -LifeCycles $lifeCycle, $lifeCycle1 -IsDefault $false
         
        $schDates = @(
        (
          (Get-Date -Year 2021 -Month 08 -Day 18 -Hour 10 -Minute 0 -Second 0)
        ),
        (
          (Get-Date -Year 2021 -Month 08 -Day 22 -Hour 10 -Minute 0 -Second 0) 
        ))

        $trigger =  New-AzDataProtectionPolicyTriggerScheduleClientObject -ScheduleDays $schDates -IntervalType Weekly -IntervalCount 1

        Edit-AzDataProtectionPolicyTriggerClientObject -Schedule $trigger -Policy $pol   
                  
        $tagCriteria = New-AzDataProtectionPolicyTagCriteriaClientObject -AbsoluteCriteria FirstOfMonth

        Edit-AzDataProtectionPolicyTagClientObject -Policy $pol -Name Monthly -Criteria $tagCriteria
         
        $newPolicy = New-AzDataProtectionBackupPolicy -ResourceGroupName $rgName -VaultName $vaultName -Name $newPolicyName -Policy $pol -SubscriptionId $sub

        # this Policy should be there - then delete it and then this policy shouldn't be there
        $policy = Get-AzDataProtectionBackupPolicy -SubscriptionId $sub -VaultName $vaultName -ResourceGroupName $rgName | where {$_.Name -eq $newPolicyName}
        $policy.Name | Should be $newPolicyName
        
        Remove-AzDataProtectionBackupPolicy -Name $newPolicyName -ResourceGroupName $rgName -SubscriptionId $sub -VaultName $vaultName
        $policy = Get-AzDataProtectionBackupPolicy -SubscriptionId $sub -VaultName $vaultName -ResourceGroupName $rgName | where {$_.Name -eq $newPolicyName}
        $policy | Should be $null
    }

    It 'AzureKubernetesServicePolicy' {
        $sub = $env.TestAksBackupScenario.SubscriptionId
        $rgName = $env.TestAksBackupScenario.ResourceGroupName
        $vaultName = $env.TestAksBackupScenario.VaultName
        $newPolicyName = $env.TestAksBackupScenario.NewPolicyName
        
        $pol = Get-AzDataProtectionPolicyTemplate -DatasourceType AzureKubernetesService
        
        # update backup schedule
        $schDates = @(
        (
          (Get-Date -Year 2023 -Month 03 -Day 18 -Hour 16 -Minute 0 -Second 0)
        ))
        $trigger =  New-AzDataProtectionPolicyTriggerScheduleClientObject -ScheduleDays $schDates -IntervalType Daily -IntervalCount 1
        Edit-AzDataProtectionPolicyTriggerClientObject -Schedule $trigger -Policy $pol   

        # add retention rules
        $lifeCycleDaily = New-AzDataProtectionRetentionLifeCycleClientObject -SourceDataStore OperationalStore -SourceRetentionDurationType Days -SourceRetentionDurationCount 8
        $lifeCycleWeekly = New-AzDataProtectionRetentionLifeCycleClientObject -SourceDataStore OperationalStore -SourceRetentionDurationType Weeks -SourceRetentionDurationCount 9

        Edit-AzDataProtectionPolicyRetentionRuleClientObject -Policy $pol -Name Daily -LifeCycles $lifeCycleDaily -IsDefault $false
        Edit-AzDataProtectionPolicyRetentionRuleClientObject -Policy $pol -Name Weekly -LifeCycles $lifeCycleWeekly -IsDefault $false
        
        # update tag criteria
        $tagCriteriaDaily = New-AzDataProtectionPolicyTagCriteriaClientObject -AbsoluteCriteria FirstOfDay
        Edit-AzDataProtectionPolicyTagClientObject -Policy $pol -Name Daily -Criteria $tagCriteriaDaily

        $tagCriteriaWeekly = New-AzDataProtectionPolicyTagCriteriaClientObject -AbsoluteCriteria FirstOfWeek 
        Edit-AzDataProtectionPolicyTagClientObject -Policy $pol -Name Weekly -Criteria $tagCriteriaWeekly

        $newPolicy = New-AzDataProtectionBackupPolicy -ResourceGroupName $rgName -VaultName $vaultName -Name $newPolicyName -Policy $pol -SubscriptionId $sub

        # this Policy should be there - then delete it and then this policy shouldn't be there
        $policy = Get-AzDataProtectionBackupPolicy -SubscriptionId $sub -VaultName $vaultName -ResourceGroupName $rgName | where {$_.Name -eq $newPolicyName}
        
        # verify policy
        $policy.Name | Should be $newPolicyName
        $policy.Property.PolicyRule[0].Trigger.ScheduleTimeZone | Should be "India Standard Time"
        $policy.Property.PolicyRule[2].Lifecycle[0].DeleteAfterDuration | Should be "P8D"
        $policy.Property.PolicyRule[3].Lifecycle[0].DeleteAfterDuration | Should be "P9W"

        # remove policy
        Remove-AzDataProtectionBackupPolicy -Name $newPolicyName -ResourceGroupName $rgName -SubscriptionId $sub -VaultName $vaultName
        $policy = Get-AzDataProtectionBackupPolicy -SubscriptionId $sub -VaultName $vaultName -ResourceGroupName $rgName | where {$_.Name -eq $newPolicyName}
        $policy | Should be $null
    }
}
