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

    It 'BlobHardeningOperationalPolicy' {
        $subId = $env.TestBlobHardeningScenario.SubscriptionId
        $resourceGroupName = $env.TestBlobHardeningScenario.ResourceGroupName
        $vaultName = $env.TestBlobHardeningScenario.VaultName
        $operationalPolicyName = $env.TestBlobHardeningScenario.OperationalPolicyName        
        
        # Create operational policy 
        $defaultPol = Get-AzDataProtectionPolicyTemplate -DatasourceType AzureBlob

        # Remove schedule 
        Edit-AzDataProtectionPolicyTriggerClientObject -Policy $defaultPol -RemoveSchedule 

        $lifeCycleOperationalTier = New-AzDataProtectionRetentionLifeCycleClientObject -SourceDataStore OperationalStore -SourceRetentionDurationType Days -SourceRetentionDurationCount 30 
 
        Edit-AzDataProtectionPolicyRetentionRuleClientObject -Policy $defaultPol -Name Default -LifeCycles $lifeCycleOperationalTier -IsDefault $true -OverwriteLifeCycle $true

        $opPolicy = New-AzDataProtectionBackupPolicy -SubscriptionId $subId -ResourceGroupName $resourceGroupName -VaultName $vaultName -Name $operationalPolicyName -Policy $defaultPol 
        
        # get operational policy - verify name 
        $opPolicy = Get-AzDataProtectionBackupPolicy -ResourceGroupName $resourceGroupName -VaultName $vaultName -SubscriptionId $subId -Name $operationalPolicyName

        $opPolicy.Name | Should be $operationalPolicyName
        $opPolicy.Property.PolicyRule.Count | Should be 1
        $opPolicy.Property.PolicyRule[0].Lifecycle[0].SourceDataStoreType | Should be "OperationalStore"

        #Remove policy
        Remove-AzDataProtectionBackupPolicy -Name $operationalPolicyName -ResourceGroupName $resourceGroupName -SubscriptionId $subId -VaultName $vaultName
        $opPolicy = Get-AzDataProtectionBackupPolicy -ResourceGroupName $resourceGroupName -VaultName $vaultName -SubscriptionId $subId | Where { $_.Name -match $operationalPolicyName }
        $opPolicy | Should be $null
    }

    It 'BlobHardeningVaultedPolicy' {
        $subId = $env.TestBlobHardeningScenario.SubscriptionId
        $resourceGroupName = $env.TestBlobHardeningScenario.ResourceGroupName
        $vaultName = $env.TestBlobHardeningScenario.VaultName
        $vaultedPolicyName = $env.TestBlobHardeningScenario.VaultPolicyName
        
        # get default 
        $defaultPol = Get-AzDataProtectionPolicyTemplate -DatasourceType AzureBlob

        # add retention rule weekly 
        $lifeCycleVaultTierWeekly = New-AzDataProtectionRetentionLifeCycleClientObject -SourceDataStore VaultStore -SourceRetentionDurationType Weeks -SourceRetentionDurationCount 4
        Edit-AzDataProtectionPolicyRetentionRuleClientObject -Policy $defaultPol -Name Weekly -LifeCycles $lifeCycleVaultTierWeekly -IsDefault $false

        # add weekly tag criteria
        $tagCriteria = New-AzDataProtectionPolicyTagCriteriaClientObject -AbsoluteCriteria FirstOfWeek
        Edit-AzDataProtectionPolicyTagClientObject -Policy $defaultPol -Name Weekly -Criteria $tagCriteria

        # create policy
        $vaultedPolicy = New-AzDataProtectionBackupPolicy -SubscriptionId $subId -ResourceGroupName $resourceGroupName -VaultName $vaultName -Name $vaultedPolicyName -Policy $defaultPol
        $vaultedPolicy = Get-AzDataProtectionBackupPolicy -ResourceGroupName $resourceGroupName -VaultName $vaultName -SubscriptionId $subId -Name $vaultedPolicyName

        # Verify 
        $vaultedPolicy.Name | Should be $vaultedPolicyName        
        $vaultedPolicy.Property.PolicyRule[-1].Lifecycle[0].SourceDataStoreType | Should be "VaultStore"

        #Remove policy
        Remove-AzDataProtectionBackupPolicy -Name $vaultedPolicyName -ResourceGroupName $resourceGroupName -SubscriptionId $subId -VaultName $vaultName
        $pol = Get-AzDataProtectionBackupPolicy -ResourceGroupName $resourceGroupName -VaultName $vaultName -SubscriptionId $subId | Where { $_.Name -match $vaultedPolicyName }
        $pol | Should be $null
    }

    It 'BlobHardeningHybridPolicy' {
        $subId = $env.TestBlobHardeningScenario.SubscriptionId
        $resourceGroupName = $env.TestBlobHardeningScenario.ResourceGroupName
        $vaultName = $env.TestBlobHardeningScenario.VaultName
        $operationalVaultedPolicyName = $env.TestBlobHardeningScenario.OperationalVaultedPolicyName

        # Create op + vault
        $defaultPol = Get-AzDataProtectionPolicyTemplate -DatasourceType AzureBlob

        $lifeCycleOperationalTier = New-AzDataProtectionRetentionLifeCycleClientObject -SourceDataStore OperationalStore -SourceRetentionDurationType Days -SourceRetentionDurationCount 30
        Edit-AzDataProtectionPolicyRetentionRuleClientObject -Policy $defaultPol -Name Default -LifeCycles $lifeCycleOperationalTier -IsDefault $true -OverwriteLifeCycle $false  

        # Weekly - 7W
        $lifeCycleVaultTierWeekly = New-AzDataProtectionRetentionLifeCycleClientObject -SourceDataStore VaultStore -SourceRetentionDurationType Weeks -SourceRetentionDurationCount 7
        Edit-AzDataProtectionPolicyRetentionRuleClientObject -Policy $defaultPol -Name Weekly -LifeCycles $lifeCycleVaultTierWeekly -IsDefault $false

        # Add weekly tag criteria
        $tagCriteria = New-AzDataProtectionPolicyTagCriteriaClientObject -AbsoluteCriteria FirstOfWeek
        Edit-AzDataProtectionPolicyTagClientObject -Policy $defaultPol -Name Weekly -Criteria $tagCriteria

        # Monthly - 5 Months
        $lifeCycleVaultTierMonthly = New-AzDataProtectionRetentionLifeCycleClientObject -SourceDataStore VaultStore -SourceRetentionDurationType Months -SourceRetentionDurationCount 5
        Edit-AzDataProtectionPolicyRetentionRuleClientObject -Policy $defaultPol -Name Monthly -LifeCycles $lifeCycleVaultTierMonthly -IsDefault $false

        $tagCriteria = New-AzDataProtectionPolicyTagCriteriaClientObject -AbsoluteCriteria FirstOfMonth
        Edit-AzDataProtectionPolicyTagClientObject -Policy $defaultPol -Name Monthly -Criteria $tagCriteria

        # Yearly - 1 Year
        $lifeCycleVaultTierYearly = New-AzDataProtectionRetentionLifeCycleClientObject -SourceDataStore VaultStore -SourceRetentionDurationType Years -SourceRetentionDurationCount 1
        Edit-AzDataProtectionPolicyRetentionRuleClientObject -Policy $defaultPol -Name Yearly -LifeCycles $lifeCycleVaultTierYearly -IsDefault $false

        $tagCriteria = New-AzDataProtectionPolicyTagCriteriaClientObject -AbsoluteCriteria FirstOfYear
        Edit-AzDataProtectionPolicyTagClientObject -Policy $defaultPol -Name Yearly -Criteria $tagCriteria

        # Schedule - Weekly, Sunday 2.30 am, West Europe Standard time 
        $scheduleDate = Get-Date
        $trigger =  New-AzDataProtectionPolicyTriggerScheduleClientObject -ScheduleDays $scheduleDate -IntervalType Weekly -IntervalCount 1
        Edit-AzDataProtectionPolicyTriggerClientObject -Schedule $trigger -Policy $defaultPol
        
        $defaultPol.PolicyRule[0].Trigger.ScheduleRepeatingTimeInterval[0] = "R/2023-05-09T02:30:00+01:00/P1W"

        $timeZone = Get-TimeZone -ListAvailable | Where-Object { $_.Id -match "Europe" }
        $defaultPol.PolicyRule[0].Trigger.ScheduleTimeZone = $timeZone[0].Id

        # create policy
        $operationalVaultedPolicy = New-AzDataProtectionBackupPolicy -SubscriptionId $subId -ResourceGroupName $resourceGroupName -VaultName $vaultName -Name $operationalVaultedPolicyName -Policy $defaultPol 
        $operationalVaultedPolicy = Get-AzDataProtectionBackupPolicy -ResourceGroupName $resourceGroupName -VaultName $vaultName -SubscriptionId $subId -Name $operationalVaultedPolicyName

        # Verify 
        $operationalVaultedPolicy.Name | Should be $operationalVaultedPolicyName        
        $operationalVaultedPolicy.Property.PolicyRule[-1].Lifecycle[0].SourceDataStoreType | Should be "VaultStore"
        $operationalVaultedPolicy.Property.PolicyRule.Lifecycle.SourceDataStoreType -contains "OperationalStore" | Should be $true

        #Remove policy
        Remove-AzDataProtectionBackupPolicy -Name $operationalVaultedPolicy -ResourceGroupName $resourceGroupName -SubscriptionId $subId -VaultName $vaultName
        $pol = Get-AzDataProtectionBackupPolicy -ResourceGroupName $resourceGroupName -VaultName $vaultName -SubscriptionId $subId | Where { $_.Name -match $operationalVaultedPolicy }
        $pol | Should be $null
    }
}
