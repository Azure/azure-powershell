### Example 1: Create an in-memory object for time in a week
```powershell
New-AzAksTimeInWeekObject -Day 'Sunday' -HourSlot 1,2
```

```output
Day    HourSlot
---    --------
Sunday {1, 2}
```

*New-AzAksTimeInWeekObject* creates an in-memory object of type *TimeInWeek*. This object represents time in a week. and will be used for parameter *TimeInWeek* in cmdlet *New-AzAksMaintenanceConfiguration*.


