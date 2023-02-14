### Example 1: Update Lab plan
```powershell
<<<<<<< HEAD
Update-AzLabServicesLabPlan -ResourceGroupName "Group Name" -Name "LabPlan Name" -DefaultAutoShutdownProfileShutdownOnDisconnect 'Enabled' -DefaultAutoShutdownProfileDisconnectDelay "00:17:00"
```

```output
=======
PS C:\> Update-AzLabServicesLabPlan -ResourceGroupName "Group Name" -Name "LabPlan Name" -DefaultAutoShutdownProfileShutdownOnDisconnect 'Enabled' -DefaultAutoShutdownProfileDisconnectDelay "00:17:00"

>>>>>>> 97176e9029ae7684a4ab56b6bec6966b134d4f91
Location Name
-------- ----
westus2  LabPlan Name
```

This example updates the lab plan enabling the Shutdown on disconnect with a delay of 17 minutes.
