### Example 1: Get a Azure Virtual Desktop SessionHostProvisioningStatuses by HostPoolName
```powershell
Get-AzWvdSessionHostProvisioningStatuses -ResourceGroupName ResourceGroupName -HostPoolName HostPoolName
```

```output
Location   Name                 Type
--------   ----                 ----
eastus     default Microsoft.DesktopVirtualization/hostpools/sessionhostProvisioningStatuses
```

This command gets a Azure Virtual Desktop SessionHostProvisioningStatuses in a HostPool.
