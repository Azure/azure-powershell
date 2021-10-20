### Example 1: Create schedule body.
```powershell
PS C:\> $scheduleBody = New-AzLabServicesScheduleObject -StartAt "$((Get-Date).AddHours(5))" `
            -StopAt "$((Get-Date).AddHours(6))" `
            -RecurrencePatternFrequency 'Weekly' `
            -RecurrencePatternInterval 1 `
            -RecurrencePatternWeekDay @($((Get-Date).DayOfWeek)) `
            -RecurrencePatternExpirationDate $((Get-Date).AddDays(20)) `
            -TimeZoneId 'America/Los_Angeles'
PS C:\> New-AzLabServicesSchedule -ResourceGroupName "Group Name" -LabName "Lab Name" -Name "Schedule Name" -Body $scheduleBody


Name
----
Schedule Name
```

This cmdlet creates the minimum information to save or update a schedule using the body parameter.
