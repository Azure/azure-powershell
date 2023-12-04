### Example 1: Update existing schedule.
```powershell
PS C:\> Update-AzLabServicesSchedule -ResourceGroupName "Group Name" -LabName "Lab Name" -Name "Schedule Name" -Note "Update note."

Name                   Type
----                   ----
Schedule Name          Microsoft.LabServices/labs/schedules
```

Updated the schedule to add additional note information.
