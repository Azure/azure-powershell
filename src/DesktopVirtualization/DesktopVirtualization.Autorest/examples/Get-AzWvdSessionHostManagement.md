### Example 1: Get a Azure Virtual Desktop SessionHostManagement by HostPoolName
```powershell
Get-AzWvdSessionHostManagement -ResourceGroupName ResourceGroupName -HostPoolName HostPoolName
```

```output
Location   Name                 Type
--------   ----                 ----
eastus     default Microsoft.DesktopVirtualization/hostpools/sessionhostmanagements
```

This command gets a Azure Virtual Desktop SessionHostManagement in a Resource Group.
