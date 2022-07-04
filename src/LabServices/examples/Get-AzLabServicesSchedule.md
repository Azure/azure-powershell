### Example 1: Get all schedules for a lab.
```powershell
Get-AzLabServicesSchedule -ResourceGroupName "group name" -LabName "lab name"
```

```output
Name                   Type
----                   ----
schedule               Microsoft.LabServices/labs/schedules
secondschedule         Microsoft.LabServices/labs/schedules
```

Returns all lab schedules.