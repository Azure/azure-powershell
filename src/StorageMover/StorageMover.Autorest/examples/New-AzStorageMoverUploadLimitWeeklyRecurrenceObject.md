### Example 1: Create an upload limit weekly recurrence object 
```powershell
New-AzStorageMoverUploadLimitWeeklyRecurrenceObject -Day 'Monday','Tuesday','Friday' -LimitInMbps 100 -EndTimeHour 5 -StartTimeHour 1 -StartTimeMinute 30 -EndTimeMinute 0
```

```output
Day                       EndTimeHour EndTimeMinute LimitInMbps StartTimeHour StartTimeMinute
---                       ----------- ------------- ----------- ------------- ---------------
{Monday, Tuesday, Friday} 5           0             100         1             30
```

This command creates an upload limit weekly recurrence object.