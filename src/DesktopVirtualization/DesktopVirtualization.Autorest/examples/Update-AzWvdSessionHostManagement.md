### Example 1: Update a Windows Virtual Desktop SessionHostManagement by HostPool Name
```powershell
Update-AzWvdSessionHostManagement -ResourceGroupName ResourceGroupName `
                            -HostPoolName HostPoolName `
                            -ScheduledDateTimeZone "Alaskan Standard Time" `
                            -deleteOriginalVm `
                            -maxVmsRemoved 4`
                            -logOffDelayMinutes 5`
                            -logOffMessage "logging off for hostpool update."
```

```output
Location   Name                 Type
--------   ----                 ----
eastus     default Microsoft.DesktopVirtualization/hostpools/{hostPoolName}/sessionHostManagements
```

This command Updates a Windows Virtual Desktop SessionHostManagement on a HostPool.
