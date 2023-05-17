---
external help file:
Module Name: Az.RecoveryServices
online version: https://docs.microsoft.com/powershell/module/az.recoveryservices/edit-azrecoveryservicesbackupretentionpolicyclientobject
schema: 2.0.0
---

# Edit-AzrecoveryServicesBackupRetentionPolicyClientObject

## SYNOPSIS
Edits the retention settings for the policy client object

## SYNTAX

```
Edit-AzrecoveryServicesBackupRetentionPolicyClientObject -DatasourceType <DatasourceTypes>
 -Policy <IProtectionPolicy> [-DailyRetentionDurationInDays <Int32?>]
 [-DifferentialRetentionPeriodInDays <Int32?>] [-EnableDailyRetention <Boolean?>]
 [-EnableMonthlyRetention <Boolean?>] [-EnableWeeklyRetention <Boolean?>] [-EnableYearlyRetention <Boolean?>]
 [-IncrementalRetentionPeriodInDays <Int32?>] [-LogRetentionPeriodInDays <Int32?>] [-ModifyDifferentialBackup]
 [-ModifyFullBackup] [-ModifyIncrementalBackup] [-ModifyLogBackup] [-MonthlyRetentionDaysOfTheMonth <Int32[]>]
 [-MonthlyRetentionDaysOfTheWeek <String[]>] [-MonthlyRetentionDurationInMonths <Int32?>]
 [-MonthlyRetentionIsLastDayIncluded <Boolean?>] [-MonthlyRetentionScheduleType <String>]
 [-MonthlyRetentionWeeksOfTheMonth <String[]>] [-WeeklyRetentionDaysOfTheWeek <String[]>]
 [-WeeklyRetentionDurationInWeeks <Int32?>] [-YearlyRetentionDaysOfTheMonth <Int32[]>]
 [-YearlyRetentionDaysOfTheWeek <String[]>] [-YearlyRetentionDurationInYears <Int32?>]
 [-YearlyRetentionIsLastDayIncluded <Boolean?>] [-YearlyRetentionMonthsOfTheYear <String[]>]
 [-YearlyRetentionScheduleType <String>] [-YearlyRetentionWeeksOfTheMonth <String[]>] [<CommonParameters>]
```

## DESCRIPTION
Edits the retention settings for the policy client object

## EXAMPLES

### Example 1: Edit the daily retention
```powershell
$pol1=Get-AzRecoveryServicesPolicyTemplate -DatasourceType AzureVM
Edit-AzrecoveryServicesBackupRetentionPolicyClientObject -Policy $pol1 -DatasourceType AzureVM -EnableDailyRetention $true -DailyRetentionDurationInDays 56
$pol1.RetentionPolicy.DailySchedule.RetentionDuration | fl
```

```output

Count        : 56
DurationType : Days
```

The first command gets the default policy template for a given DatasourceType.
The second command modifies daily retention parameter in the obtained policy.
The third command is to display the modified policy.

### Example 2: Disable the daily retention
```powershell
$pol1.SchedulePolicy.ScheduleRunFrequency="Weekly"
Edit-AzrecoveryServicesBackupRetentionPolicyClientObject -Policy $pol1 -DatasourceType AzureVM -EnableDailyRetention $false
$pol1.RetentionPolicy.DailySchedule.RetentionDuration | fl
```

```output

Count        :
DurationType :
```

The first command sets the Schedule run frequency to Weekly.
The second command disables the daily retention.
The third command is to display the modified policy.

### Example 3: Edit the weekly retention
```powershell
$pol1.SchedulePolicy.ScheduleRunDay="Monday", "Tuesday", "Wednesday"
Edit-AzrecoveryServicesBackupRetentionPolicyClientObject -Policy $pol1 -DatasourceType AzureVM -EnableWeeklyRetention $true -WeeklyRetentionDurationInWeeks 34 -WeeklyRetentionDaysOfTheWeek Sunday,Monday
$pol1.RetentionPolicy.WeeklySchedule.RetentionDuration | fl
$pol1.RetentionPolicy.WeeklySchedule | fl
```

```output

Count        : 34
DurationType : Weeks



DaysOfTheWeek     : {Monday, Tuesday, Wednesday}
RetentionDuration : Microsoft.Azure.PowerShell.Cmdlets.RecoveryServices.Models.Api20230201.RetentionDura
                    tion
RetentionTime     : {5/22/2023 2:00:00 PM}
```

The first command sets the schedule run days.
The second command is used to modify the weekly retention fields in the policy.
Note that WeeklyRetentionDaysOfTheWeek can't modify days of the week for weekly schedule but parameter needs to be passed.
The 3-4 command is to display the modified policy.

### Example 4: Disable the weekly retention
```powershell
$pol1.SchedulePolicy.ScheduleRunFrequency="Daily"
Edit-AzrecoveryServicesBackupRetentionPolicyClientObject -Policy $pol1 -DatasourceType AzureVM -EnableWeeklyRetention $false
$pol1.RetentionPolicy.WeeklySchedule.RetentionDuration | fl
$pol1.RetentionPolicy.WeeklySchedule | fl
```

```output
Count        :
DurationType :



DaysOfTheWeek     :
RetentionDuration : Microsoft.Azure.PowerShell.Cmdlets.RecoveryServices.Models.Api20230201.RetentionDura
                    tion
RetentionTime     :
```

The first command sets the schedule run frequency to daily.
The second command disables the weekly retention.
The 3-4 command is to display the modified policy.

### Example 5: Edit the week based monthly retention when schedule run frequency is weekly
```powershell
$pol1.SchedulePolicy.ScheduleRunDay
Edit-AzrecoveryServicesBackupRetentionPolicyClientObject -Policy $pol1 -DatasourceType AzureVM -EnableMonthlyRetention $true -MonthlyRetentionScheduleType Weekly -MonthlyRetentionDurationInMonths 34 -MonthlyRetentionDaysOfTheWeek "Monday","Tuesday" -MonthlyRetentionWeeksOfTheMonth Second, Fourth
$pol1.RetentionPolicy.MonthlySchedule | fl
$pol1.RetentionPolicy.MonthlySchedule.RetentionDuration | fl
$pol1.RetentionPolicy.MonthlySchedule.RetentionScheduleWeekly | fl
```

```output

RetentionDuration           : Microsoft.Azure.PowerShell.Cmdlets.RecoveryServices.Models.Api20230201.RetentionDuration
RetentionScheduleDaily      : Microsoft.Azure.PowerShell.Cmdlets.RecoveryServices.Models.Api20230201.DailyRetentionFormat
RetentionScheduleFormatType : Weekly
RetentionScheduleWeekly     : Microsoft.Azure.PowerShell.Cmdlets.RecoveryServices.Models.Api20230201.WeeklyRetentionFormat
RetentionTime               : {5/22/2023 2:00:00 PM}



Count        : 34
DurationType : Months



DaysOfTheWeek   : {Monday, Tuesday}
WeeksOfTheMonth : {Second, Fourth}
```

The first command fetches the schedule run days for assigning values to days of week.
The second command edits the week based monthly retention policy.
The 3-5 command is to display the modified policy.

### Example 6: Edit the week based monthly retention when schedule run frequency is daily
```powershell
Edit-AzrecoveryServicesBackupRetentionPolicyClientObject -Policy $pol1 -DatasourceType AzureVM -EnableMonthlyRetention $true -MonthlyRetentionScheduleType Weekly -MonthlyRetentionDurationInMonths 34 -MonthlyRetentionDaysOfTheWeek "Monday","Saturday" -MonthlyRetentionWeeksOfTheMonth Second, Fourth
$pol1.RetentionPolicy.MonthlySchedule | fl
$pol1.RetentionPolicy.MonthlySchedule.RetentionDuration | fl
$pol1.RetentionPolicy.MonthlySchedule.RetentionScheduleWeekly | fl
```

```output

RetentionDuration           : Microsoft.Azure.PowerShell.Cmdlets.RecoveryServices.Models.Api20230201.RetentionDuration
RetentionScheduleDaily      : Microsoft.Azure.PowerShell.Cmdlets.RecoveryServices.Models.Api20230201.DailyRetentionFormat
RetentionScheduleFormatType : Weekly
RetentionScheduleWeekly     : Microsoft.Azure.PowerShell.Cmdlets.RecoveryServices.Models.Api20230201.WeeklyRetentionFormat
RetentionTime               : {5/22/2023 2:00:00 PM}



Count        : 34
DurationType : Months



DaysOfTheWeek   : {Monday, Saturday}
WeeksOfTheMonth : {Second, Fourth}
```

This command edits the week based monthly retention policy.
The 2-4 command is to display the modified policy.

### Example 7: Edit the day based monthly retention
```powershell
$pol1.SchedulePolicy.ScheduleRunFrequency="Daily"
Edit-AzrecoveryServicesBackupRetentionPolicyClientObject -Policy $pol1 -DatasourceType AzureVM -EnableMonthlyRetention $true -MonthlyRetentionScheduleType Daily -MonthlyRetentionDurationInMonths 45 -MonthlyRetentionDaysOfTheMonth 1,6,28
$pol1.RetentionPolicy.MonthlySchedule | fl
$pol1.RetentionPolicy.MonthlySchedule.RetentionDuration | fl
$pol1.RetentionPolicy.MonthlySchedule.RetentionScheduleDaily.DaysOfTheMonth | fl
```

```output

RetentionDuration           : Microsoft.Azure.PowerShell.Cmdlets.RecoveryServices.Models.Api20230201.RetentionDuration
RetentionScheduleDaily      : Microsoft.Azure.PowerShell.Cmdlets.RecoveryServices.Models.Api20230201.DailyRetentionFormat
RetentionScheduleFormatType : Daily
RetentionScheduleWeekly     : Microsoft.Azure.PowerShell.Cmdlets.RecoveryServices.Models.Api20230201.WeeklyRetentionFormat
RetentionTime               : {5/22/2023 2:00:00 PM}



Count        : 45
DurationType : Months



Date   : 1
IsLast :

Date   : 6
IsLast :

Date   : 28
IsLast :
```

The first command changes the schedule run frequency to daily.
The second command edits the day based monthly retention policy.
The 3-5 command is to display the modified policy.

### Example 8: Disable the monthly retention
```powershell
Edit-AzrecoveryServicesBackupRetentionPolicyClientObject -Policy $pol1 -DatasourceType AzureVM -EnableMonthlyRetention $false
$pol1.RetentionPolicy.MonthlySchedule | fl
$pol1.RetentionPolicy.MonthlySchedule.RetentionDuration | fl
```

```output

RetentionDuration           : Microsoft.Azure.PowerShell.Cmdlets.RecoveryServices.Models.Api20230201.RetentionDuration
RetentionScheduleDaily      : Microsoft.Azure.PowerShell.Cmdlets.RecoveryServices.Models.Api20230201.DailyRetentionFormat
RetentionScheduleFormatType :
RetentionScheduleWeekly     : Microsoft.Azure.PowerShell.Cmdlets.RecoveryServices.Models.Api20230201.WeeklyRetentionFormat
RetentionTime               :



Count        :
DurationType :
```

This command disables the monthly retention.
The 2-3 command is to display the modified policy.

### Example 9: Edit the week based yearly retention when schedule run frequency is weekly
```powershell
$pol1.SchedulePolicy.ScheduleRunDay
Edit-AzrecoveryServicesBackupRetentionPolicyClientObject -Policy $pol1 -DatasourceType AzureVM -EnableYearlyRetention $true -YearlyRetentionScheduleType Weekly -YearlyRetentionDurationInYears 34 -YearlyRetentionMonthsOfTheYear @("May", "June") -YearlyRetentionDaysOfTheWeek Monday, Tuesday -YearlyRetentionWeeksOfTheMonth First, Third
$pol1.RetentionPolicy.YearlySchedule | fl
$pol1.RetentionPolicy.YearlySchedule.RetentionDuration | fl
$pol1.RetentionPolicy.YearlySchedule.RetentionScheduleWeekly | fl
```

```output

MonthsOfYear                : {May, June}
RetentionDuration           : Microsoft.Azure.PowerShell.Cmdlets.RecoveryServices.Models.Api20230201.RetentionDuration
RetentionScheduleDaily      : Microsoft.Azure.PowerShell.Cmdlets.RecoveryServices.Models.Api20230201.DailyRetentionFormat
RetentionScheduleFormatType : Weekly
RetentionScheduleWeekly     : Microsoft.Azure.PowerShell.Cmdlets.RecoveryServices.Models.Api20230201.WeeklyRetentionFormat
RetentionTime               : {5/22/2023 2:00:00 PM}



Count        : 34
DurationType : Years



DaysOfTheWeek   : {Monday, Tuesday}
WeeksOfTheMonth : {First, Third}
```

The first command fetches the schedule run days for assigning values to days of week.
The second command edits the week based yearly retention policy when schedule run frequency is weekly.
The 3-5 command is to display the modified policy.

### Example 10: Edit the week based yearly retention when schedule run frequency is daily
```powershell
Edit-AzRecoveryServicesBackupRetentionPolicyClientObject -Policy $pol1 -DatasourceType AzureVM -EnableYearlyRetention $true -YearlyRetentionScheduleType Weekly -YearlyRetentionDurationInYears 67 -YearlyRetentionMonthsOfTheYear @("May", "June") -YearlyRetentionDaysOfTheWeek Monday, Saturday -YearlyRetentionWeeksOfTheMonth First, Third
$pol1.RetentionPolicy.YearlySchedule | fl
$pol1.RetentionPolicy.YearlySchedule.RetentionDuration | fl
$pol1.RetentionPolicy.YearlySchedule.RetentionScheduleWeekly | fl
```

```output

MonthsOfYear                : {May, June}
RetentionDuration           : Microsoft.Azure.PowerShell.Cmdlets.RecoveryServices.Models.Api20230201.RetentionDuration
RetentionScheduleDaily      : Microsoft.Azure.PowerShell.Cmdlets.RecoveryServices.Models.Api20230201.DailyRetentionFormat
RetentionScheduleFormatType : Weekly
RetentionScheduleWeekly     : Microsoft.Azure.PowerShell.Cmdlets.RecoveryServices.Models.Api20230201.WeeklyRetentionFormat
RetentionTime               : {5/22/2023 2:00:00 PM}



Count        : 67
DurationType : Years



DaysOfTheWeek   : {Monday, Saturday}
WeeksOfTheMonth : {First, Third}
```

This command edits the week based yearly retention policy when schedule run frequency is daily.
The 2-4 command is to display the modified policy.

### Example 11: Edit the day based yearly retention
```powershell
$pol1.SchedulePolicy.ScheduleRunFrequency="Daily"
Edit-AzrecoveryServicesBackupRetentionPolicyClientObject -Policy $pol1 -DatasourceType AzureVM -EnableYearlyRetention $true -YearlyRetentionScheduleType Daily -YearlyRetentionMonthsOfTheYear May,April -YearlyRetentionDaysOfTheMonth 1,2,3 -YearlyRetentionDurationInYears 43
$pol1.RetentionPolicy.YearlySchedule | fl
$pol1.RetentionPolicy.YearlySchedule.RetentionDuration | fl
$pol1.RetentionPolicy.YearlySchedule.RetentionScheduleDaily.DaysOfTheMonth | fl
```

```output

MonthsOfYear                : {May, April}
RetentionDuration           : Microsoft.Azure.PowerShell.Cmdlets.RecoveryServices.Models.Api20230201.RetentionDuration
RetentionScheduleDaily      : Microsoft.Azure.PowerShell.Cmdlets.RecoveryServices.Models.Api20230201.DailyRetentionFormat
RetentionScheduleFormatType : Daily
RetentionScheduleWeekly     : Microsoft.Azure.PowerShell.Cmdlets.RecoveryServices.Models.Api20230201.WeeklyRetentionFormat
RetentionTime               : {5/22/2023 2:00:00 PM}



Count        : 43
DurationType : Years



Date   : 1
IsLast :

Date   : 2
IsLast :

Date   : 3
IsLast :
```

The first command changes the schedule run frequency to daily.
The second command edits the day based yearly retention policy.
The 3-5 command is to display the modified policy.

### Example 12: Disable the yearly retention
```powershell
Edit-AzrecoveryServicesBackupRetentionPolicyClientObject -Policy $pol1 -DatasourceType AzureVM -EnableYearlyRetention $false
$pol1.RetentionPolicy.YearlySchedule | fl
$pol1.RetentionPolicy.YearlySchedule.RetentionDuration | fl
```

```output

MonthsOfYear                :
RetentionDuration           : Microsoft.Azure.PowerShell.Cmdlets.RecoveryServices.Models.Api20230201.RetentionDuration
RetentionScheduleDaily      : Microsoft.Azure.PowerShell.Cmdlets.RecoveryServices.Models.Api20230201.DailyRetentionFormat
RetentionScheduleFormatType :
RetentionScheduleWeekly     : Microsoft.Azure.PowerShell.Cmdlets.RecoveryServices.Models.Api20230201.WeeklyRetentionFormat
RetentionTime               :



Count        :
DurationType :
```

This command disables the yearly retention.
The 2-3 command is to display the modified policy.


# SAPHANA Policies

### Example 1: Edit the Full Backup daily retention
```powershell
$pol1=Get-AzRecoveryServicesPolicyTemplate -DatasourceType SAPHANA
Edit-AzrecoveryServicesBackupRetentionPolicyClientObject -Policy $pol1 -DatasourceType SAPHANA -ModifyFullBackup -EnableDailyRetention $true -DailyRetentionDurationInDays 32
$pol1.SubProtectionPolicy[0].RetentionPolicy.DailySchedule.RetentionDuration | fl
```

```output

Count        : 32
DurationType : Days
```

The first command gets the default policy template for a given DatasourceType.
The second command modifies the full backup daily retention parameter in the obtained policy.
The third command is to display the modified policy.

### Example 2: Disable the full backup daily retention
```powershell
$pol1.SubProtectionPolicy[0].SchedulePolicy.ScheduleRunFrequency="Weekly"
Edit-AzrecoveryServicesBackupRetentionPolicyClientObject -Policy $pol1 -DatasourceType SAPHANA -ModifyFullBackup -EnableDailyRetention $false
$pol1.SubProtectionPolicy[0].RetentionPolicy.DailySchedule.RetentionDuration | fl
```

```output

Count        :
DurationType :
```

The first command sets the Schedule run frequency to Weekly.
The second command disables the daily retention for full backup.
The third command is to display the modified policy.

### Example 3: Edit the full backup weekly retention
```powershell
$pol1.SubProtectionPolicy[0].SchedulePolicy.ScheduleRunDay="Monday","Tuesday","Wednesday"
Edit-AzrecoveryServicesBackupRetentionPolicyClientObject -Policy $pol1 -DatasourceType SAPHANA -ModifyFullBackup -EnableWeeklyRetention $true -WeeklyRetentionDurationInWeeks 11 -WeeklyRetentionDaysOfTheWeek Sunday
$pol1.SubProtectionPolicy[0].RetentionPolicy.WeeklySchedule.RetentionDuration | fl
$pol1.SubProtectionPolicy[0].RetentionPolicy.WeeklySchedule | fl
```

```output

DaysOfTheWeek     : {Monday, Tuesday, Wednesday}
RetentionDuration : Microsoft.Azure.PowerShell.Cmdlets.RecoveryServices.Models.Api20230201.RetentionDuration
RetentionTime     : {9/30/2020 7:30:00 PM}



Count        : 11
DurationType : Weeks
```

This command is used to modify the full backup weekly retention fields in the policy.
Note that WeeklyRetentionDaysOfTheWeek can't modify days of week for weekly schedule but parameter needs to be passed.
The 3-4 command is to display the modified policy.

### Example 4: Disable the weekly retention
```powershell
$pol1.SubProtectionPolicy[0].SchedulePolicy.ScheduleRunFrequency="Daily"
Edit-AzrecoveryServicesBackupRetentionPolicyClientObject -Policy $pol1 -DatasourceType SAPHANA -ModifyFullBackup -EnableWeeklyRetention $false
$pol1.SubProtectionPolicy[0].RetentionPolicy.WeeklySchedule.RetentionDuration | fl
$pol1.SubProtectionPolicy[0].RetentionPolicy.WeeklySchedule | fl
```

```output

Count        :
DurationType :



DaysOfTheWeek     :
RetentionDuration : Microsoft.Azure.PowerShell.Cmdlets.RecoveryServices.Models.Api20230201.RetentionDuration
RetentionTime     :
```

This command disables the full backup weekly retention.
The 3-4 command is to display the modified policy.

### Example 5: Edit the week based monthly retention when schedule run frequency is weekly
```powershell
$pol1.SubProtectionPolicy[0].SchedulePolicy.ScheduleRunDay
Edit-AzrecoveryServicesBackupRetentionPolicyClientObject -Policy $pol1 -DatasourceType SAPHANA -ModifyFullBackup -EnableMonthlyRetention $true -MonthlyRetentionScheduleType Weekly -MonthlyRetentionDurationInMonths 34 -MonthlyRetentionDaysOfTheWeek Monday -MonthlyRetentionWeeksOfTheMonth First, Last
$pol1.SubProtectionPolicy[0].RetentionPolicy.MonthlySchedule | fl
$pol1.SubProtectionPolicy[0].RetentionPolicy.MonthlySchedule.RetentionDuration | fl
$pol1.SubProtectionPolicy[0].RetentionPolicy.MonthlySchedule.RetentionScheduleWeekly | fl
```

```output

RetentionDuration           : Microsoft.Azure.PowerShell.Cmdlets.RecoveryServices.Models.Api20230201.RetentionDuration
RetentionScheduleDaily      : Microsoft.Azure.PowerShell.Cmdlets.RecoveryServices.Models.Api20230201.DailyRetentionFormat
RetentionScheduleFormatType : Weekly
RetentionScheduleWeekly     : Microsoft.Azure.PowerShell.Cmdlets.RecoveryServices.Models.Api20230201.WeeklyRetentionFormat
RetentionTime               : {9/30/2020 7:30:00 PM}



Count        : 34
DurationType : Months



DaysOfTheWeek   : {Monday}
WeeksOfTheMonth : {First, Last}
```

The first command fetches the schedule run days for assigning values to days of week.
The second command edits the full backup week based monthly retention policy.
The 3-5 command is to display the modified policy.

### Example 6: Edit the week based monthly retention when schedule run frequency is daily
```powershell
Edit-AzrecoveryServicesBackupRetentionPolicyClientObject -Policy $pol1 -DatasourceType SAPHANA -ModifyFullBackup -EnableMonthlyRetention $true -MonthlyRetentionScheduleType Weekly -MonthlyRetentionDurationInMonths 34 -MonthlyRetentionDaysOfTheWeek Monday,Sunday
$pol1.SubProtectionPolicy[0].RetentionPolicy.MonthlySchedule | fl
$pol1.SubProtectionPolicy[0].RetentionPolicy.MonthlySchedule.RetentionDuration | fl
$pol1.SubProtectionPolicy[0].RetentionPolicy.MonthlySchedule.RetentionScheduleWeekly | fl
```

```output

RetentionDuration           : Microsoft.Azure.PowerShell.Cmdlets.RecoveryServices.Models.Api20230201.RetentionDuration
RetentionScheduleDaily      : Microsoft.Azure.PowerShell.Cmdlets.RecoveryServices.Models.Api20230201.DailyRetentionFormat
RetentionScheduleFormatType : Weekly
RetentionScheduleWeekly     : Microsoft.Azure.PowerShell.Cmdlets.RecoveryServices.Models.Api20230201.WeeklyRetentionFormat
RetentionTime               : {9/30/2020 7:30:00 PM}



Count        : 34
DurationType : Months



DaysOfTheWeek   : {Monday, Sunday}
WeeksOfTheMonth : {First, Last}
```

This command edits the full backup week based monthly retention policy.
The 2-4 command is to display the modified policy.

### Example 7: Edit the day based monthly retention
```powershell
$pol1.SubProtectionPolicy[0].SchedulePolicy.ScheduleRunFrequency="Daily"
Edit-AzrecoveryServicesBackupRetentionPolicyClientObject -Policy $pol1 -DatasourceType SAPHANA -ModifyFullBackup -EnableMonthlyRetention $true -MonthlyRetentionScheduleType Daily -MonthlyRetentionDaysOfTheMonth 1,2,3 -MonthlyRetentionDurationInMonths 67
$pol1.SubProtectionPolicy[0].RetentionPolicy.MonthlySchedule | fl
$pol1.SubProtectionPolicy[0].RetentionPolicy.MonthlySchedule.RetentionDuration | fl
$pol1.SubProtectionPolicy[0].RetentionPolicy.MonthlySchedule.RetentionScheduleDaily.DaysOfTheMonth | fl
```

```output

RetentionDuration           : Microsoft.Azure.PowerShell.Cmdlets.RecoveryServices.Models.Api20230201.RetentionDuration
RetentionScheduleDaily      : Microsoft.Azure.PowerShell.Cmdlets.RecoveryServices.Models.Api20230201.DailyRetentionFormat
RetentionScheduleFormatType : Daily
RetentionScheduleWeekly     : Microsoft.Azure.PowerShell.Cmdlets.RecoveryServices.Models.Api20230201.WeeklyRetentionFormat
RetentionTime               : {9/30/2020 7:30:00 PM}



Count        : 67
DurationType : Months



Date   : 1
IsLast :

Date   : 2
IsLast :

Date   : 3
IsLast :
```

The first command changes the full backup schedule run frequency to daily.
The second command edits the day based monthly retention policy.
The 3-5 command is to display the modified policy.

### Example 8: Disable the full backup monthly retention
```powershell
Edit-AzrecoveryServicesBackupRetentionPolicyClientObject -Policy $pol1 -DatasourceType SAPHANA -ModifyFullBackup -EnableMonthlyRetention $false
$pol1.SubProtectionPolicy[0].RetentionPolicy.MonthlySchedule | fl
$pol1.SubProtectionPolicy[0].RetentionPolicy.MonthlySchedule.RetentionDuration | fl
```

```output

RetentionDuration           : Microsoft.Azure.PowerShell.Cmdlets.RecoveryServices.Models.Api20230201.RetentionDuration
RetentionScheduleDaily      : Microsoft.Azure.PowerShell.Cmdlets.RecoveryServices.Models.Api20230201.DailyRetentionFormat
RetentionScheduleFormatType :
RetentionScheduleWeekly     : Microsoft.Azure.PowerShell.Cmdlets.RecoveryServices.Models.Api20230201.WeeklyRetentionFormat
RetentionTime               :



Count        :
DurationType :
```

This command disables the full backup monthly retention.
The 2-3 command is to display the modified policy.

### Example 9: Edit the full backup week based yearly retention when schedule run frequency is weekly
```powershell
$pol1.SubProtectionPolicy[0].SchedulePolicy.ScheduleRunDay
Edit-AzrecoveryServicesBackupRetentionPolicyClientObject -Policy $pol1 -DatasourceType SAPHANA -ModifyFullBackup -EnableYearlyRetention $true -YearlyRetentionScheduleType Weekly -YearlyRetentionDurationInYears 47 -YearlyRetentionMonthsOfTheYear May,June -YearlyRetentionDaysOfTheWeek Monday -YearlyRetentionWeeksOfTheMonth Last,First
$pol1.SubProtectionPolicy[0].RetentionPolicy.YearlySchedule | fl
$pol1.SubProtectionPolicy[0].RetentionPolicy.YearlySchedule.RetentionDuration | fl
$pol1.SubProtectionPolicy[0].RetentionPolicy.YearlySchedule.RetentionScheduleWeekly | fl
```

```output

MonthsOfYear                : {May, June}
RetentionDuration           : Microsoft.Azure.PowerShell.Cmdlets.RecoveryServices.Models.Api20230201.RetentionDuration
RetentionScheduleDaily      : Microsoft.Azure.PowerShell.Cmdlets.RecoveryServices.Models.Api20230201.DailyRetentionFormat
RetentionScheduleFormatType : Weekly
RetentionScheduleWeekly     : Microsoft.Azure.PowerShell.Cmdlets.RecoveryServices.Models.Api20230201.WeeklyRetentionFormat
RetentionTime               : {9/30/2020 7:30:00 PM}



Count        : 47
DurationType : Years



DaysOfTheWeek   : {Monday}
WeeksOfTheMonth : {Last, First}
```

The first command fetches the schedule run days for assigning values to days of week.
The second command edits the full backup week based yearly retention policy when schedule run frequency is weekly.
The 3-5 command is to display the modified policy.

### Example 10: Edit the full backup week based yearly retention when schedule run frequency is daily
```powershell
Edit-AzrecoveryServicesBackupRetentionPolicyClientObject -Policy $pol1 -DatasourceType SAPHANA -ModifyFullBackup -EnableYearlyRetention $true -YearlyRetentionScheduleType Weekly -YearlyRetentionDurationInYears 47 -YearlyRetentionMonthsOfTheYear May,June -YearlyRetentionDaysOfTheWeek Monday -YearlyRetentionWeeksOfTheMonth Last,First
$pol1.SubProtectionPolicy[0].RetentionPolicy.YearlySchedule | fl
$pol1.SubProtectionPolicy[0].RetentionPolicy.YearlySchedule.RetentionDuration | fl
$pol1.SubProtectionPolicy[0].RetentionPolicy.YearlySchedule.RetentionScheduleWeekly | fl
```

```output

MonthsOfYear                : {May, June}
RetentionDuration           : Microsoft.Azure.PowerShell.Cmdlets.RecoveryServices.Models.Api20230201.RetentionDuration
RetentionScheduleDaily      : Microsoft.Azure.PowerShell.Cmdlets.RecoveryServices.Models.Api20230201.DailyRetentionFormat
RetentionScheduleFormatType : Weekly
RetentionScheduleWeekly     : Microsoft.Azure.PowerShell.Cmdlets.RecoveryServices.Models.Api20230201.WeeklyRetentionFormat
RetentionTime               : {9/30/2020 7:30:00 PM}



Count        : 47
DurationType : Years



DaysOfTheWeek   : {Monday}
WeeksOfTheMonth : {Last, First}
```

This command edits the full backup week based yearly retention policy when schedule run frequency is daily.
The 2-4 command is to display the modified policy.

### Example 11: Edit the full backup day based yearly retention
```powershell
$pol1.SubProtectionPolicy[0].SchedulePolicy.ScheduleRunFrequency="Daily"
Edit-AzrecoveryServicesBackupRetentionPolicyClientObject -Policy $pol1 -DatasourceType SAPHANA -ModifyFullBackup -EnableYearlyRetention $true -YearlyRetentionScheduleType Daily -YearlyRetentionDurationInYears 76 -YearlyRetentionMonthsOfTheYear May,July -YearlyRetentionDaysOfTheMonth 7,17,27
$pol1.SubProtectionPolicy[0].RetentionPolicy.YearlySchedule | fl
$pol1.SubProtectionPolicy[0].RetentionPolicy.YearlySchedule.RetentionDuration | fl
$pol1.SubProtectionPolicy[0].RetentionPolicy.YearlySchedule.RetentionScheduleDaily.DaysOfTheMonth | fl
```

```output

MonthsOfYear                : {May, July}
RetentionDuration           : Microsoft.Azure.PowerShell.Cmdlets.RecoveryServices.Models.Api20230201.RetentionDuration
RetentionScheduleDaily      : Microsoft.Azure.PowerShell.Cmdlets.RecoveryServices.Models.Api20230201.DailyRetentionFormat
RetentionScheduleFormatType : Daily
RetentionScheduleWeekly     : Microsoft.Azure.PowerShell.Cmdlets.RecoveryServices.Models.Api20230201.WeeklyRetentionFormat
RetentionTime               : {9/30/2020 7:30:00 PM}



Count        : 76
DurationType : Years



Date   : 7
IsLast :

Date   : 17
IsLast :

Date   : 27
IsLast :
```

The first command changes the full backup schedule run frequency to daily.
The second command edits the day based yearly retention policy.
The 3-5 command is to display the modified policy.

### Example 12: Disable the yearly retention
```powershell
Edit-AzrecoveryServicesBackupRetentionPolicyClientObject -Policy $pol1 -DatasourceType SAPHANA -ModifyFullBackup -EnableYearlyRetention $false
$pol1.SubProtectionPolicy[0].RetentionPolicy.YearlySchedule | fl
$pol1.SubProtectionPolicy[0].RetentionPolicy.YearlySchedule.RetentionDuration | fl
```

```output

MonthsOfYear                :
RetentionDuration           : Microsoft.Azure.PowerShell.Cmdlets.RecoveryServices.Models.Api20230201.RetentionDuration
RetentionScheduleDaily      : Microsoft.Azure.PowerShell.Cmdlets.RecoveryServices.Models.Api20230201.DailyRetentionFormat
RetentionScheduleFormatType :
RetentionScheduleWeekly     : Microsoft.Azure.PowerShell.Cmdlets.RecoveryServices.Models.Api20230201.WeeklyRetentionFormat
RetentionTime               :



Count        :
DurationType :
```

This command disables the full backup yearly retention.
The 2-3 command is to display the modified policy.

### Example 13: Modify Differential backup retention policy
```powershell
$pol1.SubProtectionPolicy[0].SchedulePolicy.ScheduleRunFrequency="Weekly"
Edit-AzrecoveryServicesBackupRetentionPolicyClientObject -Policy $pol1 -DatasourceType SAPHANA -ModifyDifferentialBackup -DifferentialRetentionPeriodInDays 23 
$pol1.SubProtectionPolicy[2].RetentionPolicy | fl
```

```output

RetentionDurationCount : 23
RetentionDurationType  : Days
Type                   : SimpleRetentionPolicy
```

This command modifies the differential backup retention policy.
The third command is to display the modified policy.

### Example 14: Modify Incremental backup retention policy
```powershell
$pol1.SubProtectionPolicy[0].SchedulePolicy.ScheduleRunFrequency="Weekly"
Edit-AzrecoveryServicesBackupRetentionPolicyClientObject -Policy $pol1 -DatasourceType SAPHANA -IncrementalRetentionPeriodInDays 64 -ModifyIncrementalBackup
$pol1.SubProtectionPolicy[2].RetentionPolicy | fl
```

```output

RetentionDurationCount : 23
RetentionDurationType  : Days
Type                   : SimpleRetentionPolicy
```

This command modifies the incremental backup retention policy.
The third command is to display the modified policy.

### Example 15: Modify Log backup retention policy
```powershell
Edit-AzrecoveryServicesBackupRetentionPolicyClientObject -Policy $pol1 -DatasourceType SAPHANA -LogRetentionPeriodInDays 23 -ModifyLogBackup
$pol1.SubProtectionPolicy[1].RetentionPolicy | fl
```

```output

RetentionDurationCount : 23
RetentionDurationType  : Days
Type                   : SimpleRetentionPolicy
```

This command modifies the log backup retention policy.
The third command is to display the modified policy.

## PARAMETERS

### -DailyRetentionDurationInDays
Specifies the daily schedule duration in days.

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

### -DatasourceType
Datasource Type

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.RecoveryServices.Support.DatasourceTypes
Parameter Sets: (All)
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -DifferentialRetentionPeriodInDays
Specifies the retention period for Differential Backup

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

### -EnableDailyRetention
Boolean parameter to Enable/Disable Daily retention

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

### -EnableMonthlyRetention
Boolean parameter to Enable/Disable Monthly retention

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

### -EnableWeeklyRetention
Boolean parameter to Enable/Disable Weekly retention

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

### -EnableYearlyRetention
Boolean parameter to Enable/Disable Yearly retention

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

### -IncrementalRetentionPeriodInDays
Specifies the retention period for Incremental Backup

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

### -LogRetentionPeriodInDays
Specifies the retention period for Log Backup

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

### -ModifyDifferentialBackup
Switch parameter to modify differential backup retention policy.
You can use this parameter for DataSourceType: MSSQL, SAPHANA

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ModifyFullBackup
Switch parameter to modify FullBackup retention policy.
You can use this parameter for DataSourceType: MSSQL, SAPHANA

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ModifyIncrementalBackup
Switch parameter to modify incremental backup retention policy.
You can use this parameter for DataSourceType: MSSQL, SAPHANA

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ModifyLogBackup
Switch parameter to modify log backup retention policy.
You can use this parameter for DataSourceType: MSSQL, SAPHANA

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -MonthlyRetentionDaysOfTheMonth
Specifies the days of the month for the monthly schedule.

```yaml
Type: System.Int32[]
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -MonthlyRetentionDaysOfTheWeek
Specifies the days of the week for the monthly schedule.

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

### -MonthlyRetentionDurationInMonths
Specifies the monthly schedule duration in months.

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

### -MonthlyRetentionIsLastDayIncluded
Boolean parameter to enable the day based monthly retention on last day of the month.

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

### -MonthlyRetentionScheduleType
Specifies the retention schedule type for the monthly schedule: Week Based/Day Based

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

### -MonthlyRetentionWeeksOfTheMonth
Specifies the weeks of the month for the monthly schedule.

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

### -WeeklyRetentionDaysOfTheWeek
Specifies the days of the week for the weekly schedule.

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

### -WeeklyRetentionDurationInWeeks
Specifies the weekly schedule duration in weeks.

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

### -YearlyRetentionDaysOfTheMonth
Specifies the days of the month for the monthly schedule.

```yaml
Type: System.Int32[]
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -YearlyRetentionDaysOfTheWeek
Specifies the days of the week for the yearly schedule.

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

### -YearlyRetentionDurationInYears
Specifies the yearly schedule duration in years.

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

### -YearlyRetentionIsLastDayIncluded
Boolean parameter to enable the day based yearly retention on last day of the month.

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

### -YearlyRetentionMonthsOfTheYear
Specifies the months of the year for the yearly schedule.

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

### -YearlyRetentionScheduleType
Specifies the retention schedule type for the yearly schedule.

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

### -YearlyRetentionWeeksOfTheMonth
Specifies the weeks of the month for the monthly schedule.

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

