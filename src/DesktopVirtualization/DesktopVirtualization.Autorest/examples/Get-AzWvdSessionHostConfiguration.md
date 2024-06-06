### Example 1: Get a Azure Virtual Desktop SessionHostConfiguration by HostPoolName
```powershell
Get-AzWvdSessionHostConfiguration -ResourceGroupName ResourceGroupName -HostPoolName HostPoolName
```

```output
Location   Name                 Type
--------   ----                 ----
eastus     default Microsoft.DesktopVirtualization/hostpools/sessionhostconfigurations
```

This command gets a Azure Virtual Desktop SessionHostConfiguration in a Resource Group.
