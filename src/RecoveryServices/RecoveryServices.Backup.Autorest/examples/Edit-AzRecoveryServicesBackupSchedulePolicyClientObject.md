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
