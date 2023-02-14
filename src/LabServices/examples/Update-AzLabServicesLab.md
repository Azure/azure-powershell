### Example 1: Update existing lab.
```powershell
<<<<<<< HEAD
Update-AzLabServicesLab -ResourceGroupName "Group Name" -Name "Lab Name" -AutoShutdownProfileShutdownOnDisconnect Enabled -AutoShutdownProfileDisconnectDelay "00:25:00"
```

```output
=======
PS C:\> Update-AzLabServicesLab -ResourceGroupName "Group Name" -Name "Lab Name" -AutoShutdownProfileShutdownOnDisconnect Enabled -AutoShutdownProfileDisconnectDelay "00:25:00"

>>>>>>> 97176e9029ae7684a4ab56b6bec6966b134d4f91
Location Name
-------- ----
westus2  Lab Name
```

This example updates the lab and enables the Shutdown on Disconnect option setting the delay at 25 minutes.
