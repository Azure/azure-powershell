### Example 1: Update a Azure Virtual Desktop SessionHostManagement by HostPool Name
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
eastus     default Microsoft.DesktopVirtualization/hostpools/sessionhostmanagements
```

This command Updates a Azure Virtual Desktop SessionHostManagement on a HostPool.
