### Example 1: Create a daily schedule object
```powershell
$date = Get-Date
New-AzDataProtectionPolicyTriggerScheduleClientObject -ScheduleDays $date -IntervalType Daily -IntervalCount 1
```

```output
R/2021-03-03T12:49:55+05:30/P1D
```

This command creates a daily schedule for Azure Backup Rule

### Example 2: Create an hourly schedule object
```powershell
$date = Get-Date
New-AzDataProtectionPolicyTriggerScheduleClientObject -ScheduleDays $date -IntervalType Hourly -IntervalCount 4
```

```output
R/2021-03-03T12:49:55+05:30/PT4H
```

This command creates an hourly scheudle for Azure Backup Rule.

