### Example 1: Create a new schedule in a lab.
```powershell
<<<<<<< HEAD
New-AzLabServicesSchedule `
=======
PS C:\>  New-AzLabServicesSchedule `
>>>>>>> 97176e9029ae7684a4ab56b6bec6966b134d4f91
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
<<<<<<< HEAD
```

```output
=======

>>>>>>> 97176e9029ae7684a4ab56b6bec6966b134d4f91
Name
----
Schedule Name
```

Create a weekly schedule.

