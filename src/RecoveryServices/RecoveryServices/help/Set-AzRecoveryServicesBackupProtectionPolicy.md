---
external help file: Az.RecoveryServices-help.xml
Module Name: Az.RecoveryServices
ms.assetid: D614B509-82DD-42FB-B975-D72CD3355E3E
online version: https://learn.microsoft.com/powershell/module/az.recoveryservices/set-azrecoveryservicesbackupprotectionpolicy
schema: 2.0.0
---

# Set-AzRecoveryServicesBackupprotectionPolicy

## SYNOPSIS
Modifies a Backup protection policy.

## SYNTAX

## DESCRIPTION
The **Set-AzRecoveryServicesBackupProtectionPolicy** cmdlet modifies an existing Azure Backup protection policy.
You can modify the Backup schedule and retention policy components.
Any changes you make affect the backup and retention of the items associated with the policy.
Set the vault context by using the Set-AzRecoveryServicesVaultContext cmdlet before you use the current cmdlet.

## EXAMPLES

### Example 1: Modify a Backup protection policy
```powershell
$SchPol = Get-AzRecoveryServicesBackupSchedulePolicyObject -WorkloadType "AzureVM" 
$SchPol.ScheduleRunTimes.Clear()
$Time = Get-Date
$Time1 = Get-Date -Year $Time.Year -Month $Time.Month -Day $Time.Day -Hour $Time.Hour -Minute 0 -Second 0 -Millisecond 0
$Time1 = $Time1.ToUniversalTime()
$SchPol.ScheduleRunTimes.Add($Time1)
$SchPol.ScheduleRunFrequency.Clear
$SchPol.ScheduleRunDays.Add("Monday")
$SchPol.ScheduleRunFrequency="Weekly"
$RetPol = Get-AzRecoveryServicesBackupRetentionPolicyObject -WorkloadType "AzureVM" 
$RetPol.IsDailyScheduleEnabled=$false
$RetPol.DailySchedule.DurationCountInDays = 0
$RetPol.IsWeeklyScheduleEnabled=$true 
$RetPol.WeeklySchedule.DaysOfTheWeek.Add("Monday")
$RetPol.WeeklySchedule.DurationCountInWeeks = 365
$vault = Get-AzRecoveryServicesVault -ResourceGroupName "azurefiles" -Name "azurefilesvault"
$Pol= Get-AzRecoveryServicesBackupProtectionPolicy -Name "TestPolicy" -VaultId $vault.ID
$Pol.SnapshotRetentionInDays=5
Set-AzRecoveryServicesBackupProtectionPolicy -Policy $Pol -SchedulePolicy $SchPol -RetentionPolicy $RetPol -BackupSnapshotResourceGroup "snapshotResourceGroupPrefix" -BackupSnapshotResourceGroupSuffix "snapshotResourceGroupSuffix"
```

Here is the high-level description of the steps to be followed for modifying a protection policy: 
1.	Get a base SchedulePolicyObject and base RetentionPolicyObject. Store them in some variable.
2.	Set the different parameters of schedule and retention policy object as per your requirement. For example- In the above sample script, we are trying to set a weekly protection policy. Hence, we changed the schedule frequency to "Weekly" and also updated the schedule run time. In the retention policy object, we updated the weekly retention duration and set the correct "weekly schedule enabled" flag. In case you want to set a Daily policy, set the "daily schedule enabled" flag to true and assign appropriate values for other object parameters.
3.	Get the backup protection policy that you want to modify and store it in a variable. In the above example, we retrieved the backup policy with the name "TestPolicy" that we wanted to modify.
4.	Modify the backup protection policy retrieved in step 3 using the modified schedule policy object and retention policy object. We use BackupSnapshotResourceGroup, BackupSnapshotResourceGroupSuffix parameter to update the snapshot resource group name for instant RPs.

### Example 2: Modify Azure fileshare policy for multiple backups per day
```powershell
$schedulePolicy = Get-AzRecoveryServicesBackupSchedulePolicyObject -WorkloadType AzureFiles -BackupManagementType AzureStorage -ScheduleRunFrequency Hourly
$retentionPolicy = Get-AzRecoveryServicesBackupRetentionPolicyObject -WorkloadType AzureFiles -BackupManagementType AzureStorage -ScheduleRunFrequency Hourly
$timeZone = Get-TimeZone
$schedulePolicy.ScheduleRunTimeZone = $timeZone.Id
$startTime = Get-Date -Date "2021-12-22T06:00:00.00+00:00"
$schedulePolicy.ScheduleWindowStartTime = $startTime.ToUniversalTime()
$schedulePolicy.ScheduleInterval = 6
$schedulePolicy.ScheduleWindowDuration = 14
$retentionPolicy.DailySchedule.DurationCountInDays = 6
$policy = Get-AzRecoveryServicesBackupProtectionPolicy -Name "TestPolicy" -VaultId $vault.ID
Set-AzRecoveryServicesBackupProtectionPolicy -Policy $policy -VaultId $vault.ID -SchedulePolicy $schedulePolicy -RetentionPolicy $retentionPolicy
```

Here is the high-level description of the steps to be followed for modifying a fileshare policy for multiple backups per day: 
1.	Get a base hourly SchedulePolicyObject and base hourly RetentionPolicyObject. Store them in some variable.
2.	Set the different parameters of schedule and retention policy object as per your requirement. For example- In the above sample script, we are trying to set the $timeZone in which we want to run the schedule we are setting the start time of the Hourly schedule, setting hourly interval (in hours), after which the backup will be retriggered on the same day, duration (in hours) for which the schedule will run. Next we are modifying the retention setting for daily recovery points.
3.	Get the backup protection policy that you want to modify and store it in a variable. In the above example, we retrieved the backup policy with the name "TestPolicy" that we wanted to modify.
4.	Modify the backup protection policy retrieved in step 3 using the modified schedule policy object and retention policy object.

### Example 3: Modify AzureWorkload policy to enable Archive smart tiering
```powershell
$pol = Set-AzRecoveryServicesBackupProtectionPolicy -VaultId $vault.ID -Policy $policy -MoveToArchiveTier $true -TieringMode TierAllEligible -TierAfterDuration 60 -TierAfterDurationType Days
```

This command is used to modify policy to enable archive smart tiering for the policy $policy, we set -MoveToArchiveTier parameter to $true to enable tiering. We choose TieringMode to be TierAllEligible to move all eligible recovery points to archive after certain duration given by TierAfterDuration and TierAfterDurationType parameters. In order to move recommended recovery points to Archive for AzureVM use TieringMode TierRecommended.

### Example 4: Disable smart tiering on an existing policy
```powershell
$pol = Set-AzRecoveryServicesBackupProtectionPolicy -VaultId $vault.ID -Policy $policy -MoveToArchiveTier $false
```

This command is used to disable archive smart tiering for the policy $policy, we set -MoveToArchiveTier parameter to $false. Please note that disabling archive smart tiering might have cost implications.

## PARAMETERS

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see [about_CommonParameters](http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

### Microsoft.Azure.Commands.RecoveryServices.Backup.Cmdlets.Models.PolicyBase

### System.String

## OUTPUTS

### Microsoft.Azure.Commands.RecoveryServices.Backup.Cmdlets.Models.JobBase

## NOTES

## RELATED LINKS

[Get-AzRecoveryServicesBackupProtectionPolicy](./Get-AzRecoveryServicesBackupProtectionPolicy.md)

[Get-AzRecoveryServicesBackupRetentionPolicyObject](./Get-AzRecoveryServicesBackupRetentionPolicyObject.md)

[New-AzRecoveryServicesBackupProtectionPolicy](./New-AzRecoveryServicesBackupProtectionPolicy.md)

[Remove-AzRecoveryServicesBackupProtectionPolicy](./Remove-AzRecoveryServicesBackupProtectionPolicy.md)


