### Example 1: Create a new schedule in a lab.
```powershell
PS C:\>  New-AzLabServicesSchedule `
            -ResourceGroupName "Group Name" `
            -LabName "Lab Name" `
            -Name "Schedule Name" `
            -StartAt "$((Get-Date).AddHours(5))" `
            -StopAt "$((Get-Date).AddHours(6))" `
            -RecurrencePatternFrequency 'Weekly' `
            -RecurrencePatternInterval 1 `
            -RecurrencePatternWeekDay @($((Get-Date).DayOfWeek)) `
            -RecurrencePatternExpirationDate $((Get-Date).AddDays(20)) `
            -TimeZoneId 'America/Los_Angeles'

Name
----
Schedule Name
```

Create a weekly schedule.

