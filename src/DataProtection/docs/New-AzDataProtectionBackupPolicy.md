---
external help file:
Module Name: Az.DataProtection
online version: https://learn.microsoft.com/powershell/module/az.dataprotection/new-azdataprotectionbackuppolicy
schema: 2.0.0
---

# New-AzDataProtectionBackupPolicy

## SYNOPSIS
Creates a new backup policy in a given backup vault

## SYNTAX

```
New-AzDataProtectionBackupPolicy -Name <String> -Policy <IBackupPolicy> -ResourceGroupName <String>
 -VaultName <String> [-DefaultProfile <PSObject>] [-SubscriptionId <String>] [-Confirm] [-WhatIf]
 [<CommonParameters>]
```

## DESCRIPTION
Creates a new backup policy in a given backup vault

## EXAMPLES

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
The second, third commands create two different backup lifecycles for vault and archive store respectively.
The backup stays in vaultstore for 3 Months, and then copies on expiry to the Archive store and stays there till 6 months.
The fourth command updates the policy object with lifecycles created.
The fifth, sixth commands create the custom schedule object for the backup policy, twice weekly starting from $schDates.
The seventh command updates the policy object with custom schedule.
The eighth, ninth, tenth commands update the Monthly retention rule with custom lifecycles.
The eleventh, twelth commands create a tag criteria for Monthly policy.
Tag criteria needs to be added for each custom retention rule (automatically added for default retention rule).
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

### Example 4: Create a operational policy for AzureBlob
```powershell
$defaultPol = Get-AzDataProtectionPolicyTemplate -DatasourceType AzureBlob
Edit-AzDataProtectionPolicyTriggerClientObject -Policy $defaultPol -RemoveSchedule
$lifeCycleOperationalTier = New-AzDataProtectionRetentionLifeCycleClientObject -SourceDataStore OperationalStore -SourceRetentionDurationType Days -SourceRetentionDurationCount 30
Edit-AzDataProtectionPolicyRetentionRuleClientObject -Policy $defaultPol -Name Default -LifeCycles $lifeCycleOperationalTier -IsDefault $true -OverwriteLifeCycle $true
$opPolicy = New-AzDataProtectionBackupPolicy -SubscriptionId "xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx" -ResourceGroupName "resourceGroupName" -VaultName "vaultName" -Name "operationalPolicyName" -Policy $defaultPol
```

```output
Name                        Type
----                        ----
operationalPolicyName       Microsoft.DataProtection/backupVaults/backupPolicies
```

The first command gets the default policy template for AzureBlob.
Policy template is by default vaulted policy.
The second command removes the vaulted policy schedule since we are creating operational policy.
The third command creates a operational store lifecycle for 30 Days.
The fourth command overwrites the vault lifecycle with operational store lifecycle.
The last command creates the operational store policy.

### Example 4: Create a vaulted policy for AzureBlob
```powershell
$defaultPol = Get-AzDataProtectionPolicyTemplate -DatasourceType AzureBlob
$lifeCycleVaultTierWeekly = New-AzDataProtectionRetentionLifeCycleClientObject -SourceDataStore VaultStore -SourceRetentionDurationType Weeks -SourceRetentionDurationCount 4
Edit-AzDataProtectionPolicyRetentionRuleClientObject -Policy $defaultPol -Name Weekly -LifeCycles $lifeCycleVaultTierWeekly -IsDefault $false
$tagCriteria = New-AzDataProtectionPolicyTagCriteriaClientObject -AbsoluteCriteria FirstOfWeek
Edit-AzDataProtectionPolicyTagClientObject -Policy $defaultPol -Name Weekly -Criteria $tagCriteria
$vaultedPolicy = New-AzDataProtectionBackupPolicy -SubscriptionId "xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx" -ResourceGroupName "resourceGroupName" -VaultName "vaultName" -Name "vaultedPolicyName" -Policy $defaultPol
```

```output
Name                        Type
----                        ----
vaultedPolicyName       Microsoft.DataProtection/backupVaults/backupPolicies
```

The first command gets the default vaulted policy template for AzureBlob.
The second command defines a weekly lifecycle in vault store.
The third command updates the defaultPol object with weekly lifecycle.
The third and fourth command defines and updates the defaultPol with weekly tag criteria.
The last command creates the vault store policy.

### Example 5: Create a operational and vaulted policy for AzureBlob
```powershell
$defaultPol = Get-AzDataProtectionPolicyTemplate -DatasourceType AzureBlob
$lifeCycleOperationalTier = New-AzDataProtectionRetentionLifeCycleClientObject -SourceDataStore OperationalStore -SourceRetentionDurationType Days -SourceRetentionDurationCount 30
Edit-AzDataProtectionPolicyRetentionRuleClientObject -Policy $defaultPol -Name Default -LifeCycles $lifeCycleOperationalTier -IsDefault $true -OverwriteLifeCycle $false  
$lifeCycleVaultTierWeekly = New-AzDataProtectionRetentionLifeCycleClientObject -SourceDataStore VaultStore -SourceRetentionDurationType Weeks -SourceRetentionDurationCount 7
Edit-AzDataProtectionPolicyRetentionRuleClientObject -Policy $defaultPol -Name Weekly -LifeCycles $lifeCycleVaultTierWeekly -IsDefault $false
$tagCriteria = New-AzDataProtectionPolicyTagCriteriaClientObject -AbsoluteCriteria FirstOfWeek
Edit-AzDataProtectionPolicyTagClientObject -Policy $defaultPol -Name Weekly -Criteria $tagCriteria
$lifeCycleVaultTierMonthly = New-AzDataProtectionRetentionLifeCycleClientObject -SourceDataStore VaultStore -SourceRetentionDurationType Months -SourceRetentionDurationCount 5
Edit-AzDataProtectionPolicyRetentionRuleClientObject -Policy $defaultPol -Name Monthly -LifeCycles $lifeCycleVaultTierMonthly -IsDefault $false
$tagCriteria = New-AzDataProtectionPolicyTagCriteriaClientObject -AbsoluteCriteria FirstOfMonth
Edit-AzDataProtectionPolicyTagClientObject -Policy $defaultPol -Name Monthly -Criteria $tagCriteria
$lifeCycleVaultTierYearly = New-AzDataProtectionRetentionLifeCycleClientObject -SourceDataStore VaultStore -SourceRetentionDurationType Years -SourceRetentionDurationCount 1
Edit-AzDataProtectionPolicyRetentionRuleClientObject -Policy $defaultPol -Name Yearly -LifeCycles $lifeCycleVaultTierYearly -IsDefault $false
$tagCriteria = New-AzDataProtectionPolicyTagCriteriaClientObject -AbsoluteCriteria FirstOfYear
Edit-AzDataProtectionPolicyTagClientObject -Policy $defaultPol -Name Yearly -Criteria $tagCriteria
$scheduleDate = Get-Date
$trigger =  New-AzDataProtectionPolicyTriggerScheduleClientObject -ScheduleDays $scheduleDate -IntervalType Weekly -IntervalCount 1
Edit-AzDataProtectionPolicyTriggerClientObject -Schedule $trigger -Policy $defaultPol
$defaultPol.PolicyRule[0].Trigger.ScheduleRepeatingTimeInterval[0] = "R/2023-05-09T02:30:00+01:00/P1W"
$timeZone = Get-TimeZone -ListAvailable | Where-Object { $_.Id -match "Europe" }
$defaultPol.PolicyRule[0].Trigger.ScheduleTimeZone = $timeZone[0].Id
$operationalVaultedPolicy = New-AzDataProtectionBackupPolicy -SubscriptionId "xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx" -ResourceGroupName "resourceGroupName" -VaultName "vaultName" -Name "operationalVaultedPolicyName" -Policy $defaultPol 
```

```output
Name                               Type
----                               ----
operationalVaultedPolicyName       Microsoft.DataProtection/backupVaults/backupPolicies
```

The first command gets the default vaulted policy template for AzureBlob.
The second to fifteenth command defines and updates the Operational, vaulted weekly, monthly, yearly lifecycle and tagcriteria.
Next we define a trigger object with schedule time and timzone, set it to 2:30 AM West Europe standard time.
The last command creates the hybrid AzureBlob policy.

## PARAMETERS

### -DefaultProfile


```yaml
Type: System.Management.Automation.PSObject
Parameter Sets: (All)
Aliases: AzureRMContext, AzureCredential

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Name
Policy Name

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Policy
Policy Request Object
To construct, see NOTES section for POLICY properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202301.IBackupPolicy
Parameter Sets: (All)
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ResourceGroupName
Resource Group Name

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -SubscriptionId
Subscription Id

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -VaultName
Vault Name

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Confirm
Prompts you for confirmation before running the cmdlet.

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: (All)
Aliases: cf

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -WhatIf
Shows what would happen if the cmdlet runs.
The cmdlet is not run.

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: (All)
Aliases: wi

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see [about_CommonParameters](http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202301.IBaseBackupPolicyResource

## NOTES

ALIASES

COMPLEX PARAMETER PROPERTIES

To create the parameters described below, construct a hash table containing the appropriate properties. For information on hash tables, run Get-Help about_Hash_Tables.


`POLICY <IBackupPolicy>`: Policy Request Object
  - `DatasourceType <String[]>`: Type of datasource for the backup management
  - `ObjectType <String>`: 
  - `PolicyRule <IBasePolicyRule[]>`: Policy rule dictionary that contains rules for each backuptype i.e Full/Incremental/Logs etc
    - `Name <String>`: 
    - `ObjectType <String>`: 
    - `DataStoreObjectType <String>`: Type of Datasource object, used to initialize the right inherited type
    - `DataStoreType <DataStoreTypes>`: type of datastore; Operational/Vault/Archive
    - `TriggerObjectType <String>`: Type of the specific object - used for deserializing
    - `Lifecycle <ISourceLifeCycle[]>`: 
      - `DeleteAfterDuration <String>`: Duration of deletion after given timespan
      - `DeleteAfterObjectType <String>`: Type of the specific object - used for deserializing
      - `SourceDataStoreObjectType <String>`: Type of Datasource object, used to initialize the right inherited type
      - `SourceDataStoreType <DataStoreTypes>`: type of datastore; Operational/Vault/Archive
      - `[TargetDataStoreCopySetting <ITargetCopySetting[]>]`: 
        - `CopyAfterObjectType <String>`: Type of the specific object - used for deserializing
        - `DataStoreObjectType <String>`: Type of Datasource object, used to initialize the right inherited type
        - `DataStoreType <DataStoreTypes>`: type of datastore; Operational/Vault/Archive
    - `[BackupParameterObjectType <String>]`: Type of the specific object - used for deserializing
    - `[IsDefault <Boolean?>]`: 

## RELATED LINKS

