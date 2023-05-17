---
external help file:
Module Name: Az.RecoveryServices
online version: https://docs.microsoft.com/powershell/module/az.recoveryservices/edit-azrecoveryservicesbackupschedulepolicyclientobject
schema: 2.0.0
---

# Edit-AzRecoveryServicesBackupSchedulePolicyClientObject

## SYNOPSIS
Edits the schedule policy in the specified backup policy object.

## SYNTAX

```
Edit-AzRecoveryServicesBackupSchedulePolicyClientObject -Policy <IProtectionPolicy>
 [-BackupFrequency <String>] [-DifferentialRunDay <String[]>] [-DifferentialScheduleTime <String>]
 [-EnableDifferentialBackup <Boolean?>] [-EnableIncrementalBackup <Boolean?>] [-EnableLogBackup <Boolean?>]
 [-HourlyInterval <Int32?>] [-HourlyScheduleWindowDuration <Int32?>] [-IncrementalRunDay <String[]>]
 [-IncrementalScheduleTime <String>] [-LogBackupFrequencyInMin <Int32?>] [-PolicySubType <PolicySubTypes>]
 [-ScheduleRunDay <String[]>] [-ScheduleTime <String>] [-TimeZone <String>] [<CommonParameters>]
```

## DESCRIPTION
Edits the schedule policy in the specified backup policy object.

## EXAMPLES

### Example 1: Editing AzureVM backup schedule policy to standard daily full backup 
```powershell
$pol = Get-AzRecoveryServicesPolicyTemplate -DatasourceType AzureVM
$editedPolicy = Edit-AzRecoveryServicesBackupSchedulePolicyClientObject -Policy $pol -PolicySubType "Standard" -BackupFrequency "Daily" -ScheduleTime "1:30 PM" -TimeZone "Tokyo Standard Time"
$editedPolicy.SchedulePolicy | fl
```

```output
HourlySchedule          : Microsoft.Azure.PowerShell.Cmdlets.RecoveryServices.Models.Api20230201.HourlySchedule
ScheduleRunDay          :
ScheduleRunFrequency    : Daily
ScheduleRunTime         : {6/19/2023 1:30:00 PM}
ScheduleWeeklyFrequency : 0
Type                    : SimpleSchedulePolicy
```

This creates a standard daily full backup schedule for AzureVM

### Example 2: Editing AzureVM backup schedule policy to enhanced weekly full backup
```powershell
$pol = Get-AzRecoveryServicesPolicyTemplate -DatasourceType AzureVM
$editedPolicy = Edit-AzRecoveryServicesBackupSchedulePolicyClientObject -Policy $pol -PolicySubType "Enhanced" -BackupFrequency "Weekly" -ScheduleRunDay @("Monday", "Thursday") -ScheduleTime "1:30 PM" -TimeZone "Tokyo Standard Time"
$editedPolicy.SchedulePolicy | fl
```

```output
DailyScheduleRunTime  :
HourlySchedule        : Microsoft.Azure.PowerShell.Cmdlets.RecoveryServices.Models.Api20230201.HourlySchedule
ScheduleRunFrequency  : Weekly
Type                  : SimpleSchedulePolicyV2
WeeklyScheduleRunDay  : {Monday, Thursday}
WeeklyScheduleRunTime : {6/19/2023 1:30:00 PM}
```

This creates an enhanced weekly full backup schedule for AzureVM

### Example 3: Editing AzureVM backup schedule policy to enhanced hourly full backup
```powershell
$pol = Get-AzRecoveryServicesPolicyTemplate -DatasourceType AzureVM
$editedPolicy = Edit-AzRecoveryServicesBackupSchedulePolicyClientObject -Policy $pol -PolicySubType "Enhanced" -BackupFrequency "Hourly" -HourlyInterval 4 -HourlyScheduleWindowDuration 24 -ScheduleTime "1:30 PM" -TimeZone "Tokyo Standard Time"
$editedPolicy.SchedulePolicy | fl
$editedPolicy.SchedulePolicy.HourlySchedule | fl
```

```output
DailyScheduleRunTime  :
HourlySchedule        : Microsoft.Azure.PowerShell.Cmdlets.RecoveryServices.Models.Api20230201.HourlySchedule
ScheduleRunFrequency  : Hourly
Type                  : SimpleSchedulePolicyV2
WeeklyScheduleRunDay  :
WeeklyScheduleRunTime :

Interval                : 4
ScheduleWindowDuration  : 24
ScheduleWindowStartTime : 6/19/2023 1:30:00 PM
```

This creates an enhanced hourly full backup schedule for AzureVM

### Example 4: Editing SAPHANA backup schedule policy to daily or weekly full backup
```powershell
$pol = Get-AzRecoveryServicesPolicyTemplate -DatasourceType SAPHANA
$editedPolicy = Edit-AzRecoveryServicesBackupSchedulePolicyClientObject -Policy $pol -BackupFrequency "Daily" -ScheduleTime "1:30 PM" -TimeZone "Tokyo Standard Time"
$FullBackupPolicy =  $editedPolicy.SubProtectionPolicy | Where-Object { $_.PolicyType -match "Full" }
$FullBackupPolicy.SchedulePolicy | fl

$pol = Get-AzRecoveryServicesPolicyTemplate -DatasourceType SAPHANA
$editedPolicy = Edit-AzRecoveryServicesBackupSchedulePolicyClientObject -Policy $pol -BackupFrequency "Weekly" -ScheduleRunDay @("Monday", "Thursday") -ScheduleTime "1:30 PM" -TimeZone "Tokyo Standard Time"
$FullBackupPolicy =  $editedPolicy.SubProtectionPolicy | Where-Object { $_.PolicyType -match "Full" }
$FullBackupPolicy.SchedulePolicy | fl
```

```output
HourlySchedule          : Microsoft.Azure.PowerShell.Cmdlets.RecoveryServices.Models.Api20230201.HourlySchedule
ScheduleRunDay          :
ScheduleRunFrequency    : Daily
ScheduleRunTime         : {6/19/2023 1:30:00 PM}
ScheduleWeeklyFrequency : 0
Type                    : SimpleSchedulePolicy

HourlySchedule          : Microsoft.Azure.PowerShell.Cmdlets.RecoveryServices.Models.Api20230201.HourlySchedule
ScheduleRunDay          : {Monday, Thursday}
ScheduleRunFrequency    : Weekly
ScheduleRunTime         : {6/19/2023 1:30:00 PM}
ScheduleWeeklyFrequency : 0
Type                    : SimpleSchedulePolicy
```

This creates daily and weekly full backup schedules respectively for SAPHANA

### Example 5: Editing SAPHANA backup schedule policy to differential or incremental backup 
```powershell
$pol = Get-AzRecoveryServicesPolicyTemplate -DatasourceType SAPHANA
$editedPolicy = Edit-AzRecoveryServicesBackupSchedulePolicyClientObject -Policy $pol -BackupFrequency "Weekly" -ScheduleRunDay @("Monday", "Thursday") -EnableDifferentialBackup 1 -DifferentialRunDay @("Tuesday", "Friday") -DifferentialScheduleTime "2:00 AM" -ScheduleTime "1:30 PM" -TimeZone "Tokyo Standard Time"
$FullBackupPolicy =  $editedPolicy.SubProtectionPolicy | Where-Object { $_.PolicyType -match "Full" }
$FullBackupPolicy.SchedulePolicy | fl
$DifferentialPolicy = $editedPolicy.SubProtectionPolicy | Where-Object { $_.PolicyType -match "Differential" }
$DifferentialPolicy.SchedulePolicy | fl

$pol = Get-AzRecoveryServicesPolicyTemplate -DatasourceType SAPHANA
$editedPolicy = Edit-AzRecoveryServicesBackupSchedulePolicyClientObject -Policy $pol -BackupFrequency "Weekly" -ScheduleRunDay @("Monday", "Thursday") -EnableIncrementalBackup 1 -IncrementalRunDay @("Tuesday", "Friday") -IncrementalScheduleTime "2:00 AM" -ScheduleTime "1:30 PM" -TimeZone "Tokyo Standard Time"
$FullBackupPolicy =  $editedPolicy.SubProtectionPolicy | Where-Object { $_.PolicyType -match "Full" }
$FullBackupPolicy.SchedulePolicy | fl
$IncrementalPolicy = $editedPolicy.SubProtectionPolicy | Where-Object { $_.PolicyType -match "Incremental" }
$IncrementalPolicy.SchedulePolicy | fl
```

```output
Differential

HourlySchedule          : Microsoft.Azure.PowerShell.Cmdlets.RecoveryServices.Models.Api20230201.HourlySchedule
ScheduleRunDay          : {Monday, Thursday}
ScheduleRunFrequency    : Weekly
ScheduleRunTime         : {6/20/2023 1:30:00 PM}
ScheduleWeeklyFrequency : 0
Type                    : SimpleSchedulePolicySAPHanaDatabase

HourlySchedule          : Microsoft.Azure.PowerShell.Cmdlets.RecoveryServices.Models.Api20230201.HourlySchedule
ScheduleRunDay          : {Tuesday, Friday}
ScheduleRunFrequency    : Weekly
ScheduleRunTime         : {6/20/2023 2:00:00 AM}
ScheduleWeeklyFrequency : 0
Type                    : SimpleSchedulePolicy

Incremental

HourlySchedule          : Microsoft.Azure.PowerShell.Cmdlets.RecoveryServices.Models.Api20230201.HourlySchedule
ScheduleRunDay          : {Monday, Thursday}
ScheduleRunFrequency    : Weekly
ScheduleRunTime         : {6/20/2023 1:30:00 PM}
ScheduleWeeklyFrequency : 0
Type                    : SimpleSchedulePolicy

HourlySchedule          : Microsoft.Azure.PowerShell.Cmdlets.RecoveryServices.Models.Api20230201.HourlySchedule
ScheduleRunDay          : {Tuesday, Friday}
ScheduleRunFrequency    : Weekly
ScheduleRunTime         : {6/20/2023 2:00:00 AM}
ScheduleWeeklyFrequency : 0
Type                    : SimpleSchedulePolicy
```

This creates differential and incremental backup schedules respectively for SAPHANA

### Example 6: Editing SAPHANA backup schedule policy Log Backup
```powershell
$pol = Get-AzRecoveryServicesPolicyTemplate -DatasourceType SAPHANA
$editedPolicy = Edit-AzRecoveryServicesBackupSchedulePolicyClientObject -Policy $pol -EnableLogBackup 1 -LogBackupFrequencyInMin 120
$LogBackupPolicy = $editedPolicy.SubProtectionPolicy | Where-Object { $_.PolicyType -match "Log" }
$LogBackupPolicy.SchedulePolicy | fl
```

```output
ScheduleFrequencyInMin : 120
Type                   : LogSchedulePolicy
```

This edits the Log backup frequency to 120 minutes for SAPHANA backup schedule policy

## PARAMETERS

### -BackupFrequency
Specifies the frequency of backup.

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

### -DifferentialRunDay
Specifies the days of the week for differential backup.

```yaml
Type: System.String[]
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -DifferentialScheduleTime
Specifies the time at which differential backup must be taken.

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

### -EnableDifferentialBackup
Specifies whether the user wants to enable differential backup.

```yaml
Type: System.Nullable`1[[System.Boolean, System.Private.CoreLib, Version=7.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e]]
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -EnableIncrementalBackup
Specifies whether the user wants to enable incremental backup.

```yaml
Type: System.Nullable`1[[System.Boolean, System.Private.CoreLib, Version=7.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e]]
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -EnableLogBackup
Specifies whether the user needs to make a log backup

```yaml
Type: System.Nullable`1[[System.Boolean, System.Private.CoreLib, Version=7.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e]]
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -HourlyInterval
Specifies the interval between backups in hours.

```yaml
Type: System.Nullable`1[[System.Int32, System.Private.CoreLib, Version=7.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e]]
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -HourlyScheduleWindowDuration
Specifies the duration over which backup is taken in hours.

```yaml
Type: System.Nullable`1[[System.Int32, System.Private.CoreLib, Version=7.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e]]
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -IncrementalRunDay
Specifies the days of the week for incremental backup.

```yaml
Type: System.String[]
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -IncrementalScheduleTime
Specifies the time at which incremental backup must be taken.

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

### -LogBackupFrequencyInMin
Specifies the frequency of log backups in minutes

```yaml
Type: System.Nullable`1[[System.Int32, System.Private.CoreLib, Version=7.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e]]
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Policy
Specifies the policy to be edited.
To construct, see NOTES section for POLICY properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.RecoveryServices.Models.Api20230201.IProtectionPolicy
Parameter Sets: (All)
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -PolicySubType
Specifies the policy sub type for AzureVM.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.RecoveryServices.Support.PolicySubTypes
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ScheduleRunDay
Specifies the days of the week for weekly backup.

```yaml
Type: System.String[]
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ScheduleTime
Specifies the time at which backup must be taken.

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

### -TimeZone
Specifies the standard time zone.

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

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see [about_CommonParameters](http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.RecoveryServices.Models.Api20230201.IProtectionPolicy

## NOTES

ALIASES

COMPLEX PARAMETER PROPERTIES

To create the parameters described below, construct a hash table containing the appropriate properties. For information on hash tables, run Get-Help about_Hash_Tables.


`POLICY <IProtectionPolicy>`: Specifies the policy to be edited.
  - `BackupManagementType <String>`: This property will be used as the discriminator for deciding the specific types in the polymorphic chain of types.
  - `[ProtectedItemsCount <Int32?>]`: Number of items associated with this policy.
  - `[ResourceGuardOperationRequest <String[]>]`: ResourceGuard Operation Requests

## RELATED LINKS

