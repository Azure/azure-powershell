### Example 1: Get all schedules for a lab.
```powershell
PS C:\> Get-AzLabSchedule -ResourceGroupName "group name" -LabName "lab name"

Name                   Type
----                   ----
schedule               Microsoft.LabServices/labs/schedules
secondschedule         Microsoft.LabServices/labs/schedules

```

Returns all lab schedules.