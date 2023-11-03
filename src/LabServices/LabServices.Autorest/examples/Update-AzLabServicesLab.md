### Example 1: Update existing lab.
```powershell
PS C:\> Update-AzLabServicesLab -ResourceGroupName "Group Name" -Name "Lab Name" -AutoShutdownProfileShutdownOnDisconnect Enabled -AutoShutdownProfileDisconnectDelay "00:25:00"

Location Name
-------- ----
westus2  Lab Name
```

This example updates the lab and enables the Shutdown on Disconnect option setting the delay at 25 minutes.
