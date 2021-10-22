### Example 1: Update Lab plan
```powershell
PS C:\> Update-AzLabServicesLabPlan -ResourceGroupName "Group Name" -Name "LabPlan Name" -DefaultAutoShutdownProfileShutdownOnDisconnect 'Enabled' -DefaultAutoShutdownProfileDisconnectDelay "00:17:00"

Location Name
-------- ----
westus2  LabPlan Name
```

This example updates the lab plan enabling the Shutdown on disconnect with a delay of 17 minutes.
