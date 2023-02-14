### Example 1: Update existing schedule.
```powershell
<<<<<<< HEAD
Update-AzLabServicesSchedule -ResourceGroupName "Group Name" -LabName "Lab Name" -Name "Schedule Name" -Note "Update note."
```

```output
=======
PS C:\> Update-AzLabServicesSchedule -ResourceGroupName "Group Name" -LabName "Lab Name" -Name "Schedule Name" -Note "Update note."

>>>>>>> 97176e9029ae7684a4ab56b6bec6966b134d4f91
Name                   Type
----                   ----
Schedule Name          Microsoft.LabServices/labs/schedules
```

Updated the schedule to add additional note information.
