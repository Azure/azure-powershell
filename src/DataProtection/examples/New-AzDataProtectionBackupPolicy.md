### Example 1: Create a default policy
```powershell
$defaultPol = Get-AzDataProtectionPolicyTemplate -DatasourceType AzureDisk
New-AzDataProtectionBackupPolicy -SubscriptionId "xxxx-xxx-xxx" -ResourceGroupName sarath-rg -VaultName sarath-vault -Name "MyPolicy" -Policy $defaultPol
```

```output
Name              Type
----              ----
MyPolicy       Microsoft.DataProtection/backupVaults/backupPolicies
```

This command creates a default policy for Azure disk datasource type.

### Example 2: Create a policy for AzureDatabaseForPostgreSQL, this example covers a sophisticated policy using powerShell
```powershell
$defaultPol = Get-AzDataProtectionPolicyTemplate -DatasourceType AzureDatabaseForPostgreSQL
$lifeCycleVault = New-AzDataProtectionRetentionLifeCycleClientObject -SourceDataStore VaultStore -SourceRetentionDurationType Months -SourceRetentionDurationCount 3 -TargetDataStore ArchiveStore -CopyOption CopyOnExpiryOption
$lifeCycleArchive = New-AzDataProtectionRetentionLifeCycleClientObject -SourceDataStore ArchiveStore -SourceRetentionDurationType Months -SourceRetentionDurationCount 6
Edit-AzDataProtectionPolicyRetentionRuleClientObject -Policy $defaultPol -Name Default -LifeCycles $lifeCycleVault, $lifeCycleArchive -IsDefault $true
$schDates = @(
(
    (Get-Date -Year 2021 -Month 08 -Day 18 -Hour 10 -Minute 0 -Second 0)
),
(
    (Get-Date -Year 2021 -Month 08 -Day 22 -Hour 10 -Minute 0 -Second 0) 
))

$trigger =  New-AzDataProtectionPolicyTriggerScheduleClientObject -ScheduleDays $schDates -IntervalType Weekly -IntervalCount 1
Edit-AzDataProtectionPolicyTriggerClientObject -Schedule $trigger -Policy $defaultPol   
$lifeCycleVault = New-AzDataProtectionRetentionLifeCycleClientObject -SourceDataStore VaultStore -SourceRetentionDurationType Months -SourceRetentionDurationCount 6 -TargetDataStore ArchiveStore -CopyOption CopyOnExpiryOption
$lifeCycleArchive = New-AzDataProtectionRetentionLifeCycleClientObject -SourceDataStore ArchiveStore -SourceRetentionDurationType Months -SourceRetentionDurationCount 12
Edit-AzDataProtectionPolicyRetentionRuleClientObject -Policy $defaultPol -Name Monthly -LifeCycles $lifeCycleVault, $lifeCycleArchive -IsDefault $false
$tagCriteria = New-AzDataProtectionPolicyTagCriteriaClientObject -AbsoluteCriteria FirstOfMonth
Edit-AzDataProtectionPolicyTagClientObject -Policy $defaultPol -Name Monthly -Criteria $tagCriteria
New-AzDataProtectionBackupPolicy -SubscriptionId "xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx" -ResourceGroupName "resourceGroupName" -VaultName "vaultName" -Name "newOSSPolicy" -Policy $defaultPol
```

```output
Name              Type
----              ----
MyPolicy       Microsoft.DataProtection/backupVaults/backupPolicies
```

The first command gets the default policy template for AzureDatabaseForPostgreSQL.
The second, third commands create two different backup lifecycles for vault and archive store respectively. The backup stays in vaultstore for 3 Months, and then copies on expiry to the Archive store and stays there till 6 months.
The fourth command updates the policy object with lifecycles created.
The fifth, sixth commands create the custom schedule object for the backup policy, twice weekly starting from $schDates.
The seventh command updates the policy object with custom schedule.
The eighth, ninth, tenth commands update the Monthly retention rule with custom lifecycles.
The eleventh, twelth commands create a tag criteria for Monthly policy. Tag criteria needs to be added for each custom retention rule (automatically added for default retention rule).
The last command creates the policy.

### Example 3: Create a policy for AzureKubernetesService
```powershell
$defaultPol = Get-AzDataProtectionPolicyTemplate -DatasourceType AzureKubernetesService
$schDate = @(
(
    (Get-Date -Year 2023 -Month 03 -Day 18 -Hour 16 -Minute 0 -Second 0)
))
$trigger =  New-AzDataProtectionPolicyTriggerScheduleClientObject -ScheduleDays $schDate -IntervalType Daily -IntervalCount 1
Edit-AzDataProtectionPolicyTriggerClientObject -Schedule $trigger -Policy $defaultPol
$lifeCycleDaily = New-AzDataProtectionRetentionLifeCycleClientObject -SourceDataStore OperationalStore -SourceRetentionDurationType Days -SourceRetentionDurationCount 8
$lifeCycleWeekly = New-AzDataProtectionRetentionLifeCycleClientObject -SourceDataStore OperationalStore -SourceRetentionDurationType Weeks -SourceRetentionDurationCount 9
Edit-AzDataProtectionPolicyRetentionRuleClientObject -Policy $defaultPol -Name Daily -LifeCycles $lifeCycleDaily -IsDefault $false
Edit-AzDataProtectionPolicyRetentionRuleClientObject -Policy $defaultPol -Name Weekly -LifeCycles $lifeCycleWeekly -IsDefault $false
$tagCriteriaDaily = New-AzDataProtectionPolicyTagCriteriaClientObject -AbsoluteCriteria FirstOfDay
Edit-AzDataProtectionPolicyTagClientObject -Policy $defaultPol -Name Daily -Criteria $tagCriteriaDaily
$tagCriteriaWeekly = New-AzDataProtectionPolicyTagCriteriaClientObject -AbsoluteCriteria FirstOfWeek 
Edit-AzDataProtectionPolicyTagClientObject -Policy $defaultPol -Name Weekly -Criteria $tagCriteriaWeekly
$newPolicy = New-AzDataProtectionBackupPolicy -ResourceGroupName "resourceGroupName" -VaultName "vaultName" -Name "newAKSPolicy" -Policy $defaultPol -SubscriptionId "xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx"
```

```output
Name              Type
----              ----
newAKSPolicy       Microsoft.DataProtection/backupVaults/backupPolicies
```

The first command gets the default policy template for AzureKubernetesService.
The second, third commands create the custom schedule object for the backup policy, Daily starting from $schDate.
The fourth command updates the policy object with custom schedule.
The fifth, sixth commands create two backup lifecycles for daily and weekly recovery points.
The seventh, eight commands update the policy object with lifecycles created.
Next we create FirstOfDay, FirstOfWeek tag criteria and update the policy.
The last command creates the policy.
        