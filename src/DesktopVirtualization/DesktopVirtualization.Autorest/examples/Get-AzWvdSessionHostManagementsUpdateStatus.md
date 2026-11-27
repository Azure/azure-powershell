### Example 1: Get a Azure Virtual Desktop SessionHostManagementUpdateStatus by HostPoolName
```powershell
Get-AzWvdSessionHostManagementsUpdateStatus -ResourceGroupName ResourceGroupName -HostPoolName HostPoolName
```

```output
Location   Name                 Type
--------   ----                 ----
eastus     default Microsoft.DesktopVirtualization/hostpools/sessionhostManagements/UpdateStatuses
```

This command gets a Azure Virtual Desktop SessionHostManagementUpdateStatus in a HostPool.
