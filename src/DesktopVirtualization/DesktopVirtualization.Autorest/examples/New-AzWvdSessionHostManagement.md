### Example 1: Create a Azure Virtual Desktop SessionHostManagement by HostPool Name
```powershell
New-AzWvdSessionHostManagement -ResourceGroupName ResourceGroupName `
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

This command creates a Azure Virtual Desktop SessionHostManagement on a HostPool.
