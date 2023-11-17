### Example 1: Create Create an in-memory object for a time span
```powershell
$startDate = Get-Date -Year 2023 -Month 3 -Day 1
$endDate = Get-Date -Year 2023 -Month 3 -Day 2
New-AzAksTimeSpanObject -Start  $startDate -End $endDate
```

```output
End                 Start
---                 -----
3/2/2023 1:53:53 PM 3/1/2023 1:53:45 PM
```

*New-AzAksTimeSpanObject* creates an in-memory object of type *TimeSpan*. This object represents a time span and will be used for parameter *NotAllowedTime* in cmdlet *New-AzAksMaintenanceConfiguration*.


