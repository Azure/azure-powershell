### Example 1: Get all schedules for a lab.
```powershell
<<<<<<< HEAD
Get-AzLabServicesSchedule -ResourceGroupName "group name" -LabName "lab name"
```

```output
=======
PS C:\> Get-AzLabSchedule -ResourceGroupName "group name" -LabName "lab name"

>>>>>>> 97176e9029ae7684a4ab56b6bec6966b134d4f91
Name                   Type
----                   ----
schedule               Microsoft.LabServices/labs/schedules
secondschedule         Microsoft.LabServices/labs/schedules
<<<<<<< HEAD
=======

>>>>>>> 97176e9029ae7684a4ab56b6bec6966b134d4f91
```

Returns all lab schedules.