### Example 1: Update existing schedule.
```powershell
Update-AzLabServicesSchedule -ResourceGroupName "Group Name" -LabName "Lab Name" -Name "Schedule Name" -Note "Update note."
```

```output
Name                   Type
----                   ----
Schedule Name          Microsoft.LabServices/labs/schedules
```

Updated the schedule to add additional note information.
