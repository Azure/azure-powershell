### Example 1: Get a Azure Virtual Desktop SessionHostProvisioningStatus by HostPoolName
```powershell
Get-AzWvdSessionHostProvisioningStatus -ResourceGroupName ResourceGroupName -HostPoolName HostPoolName
```

```output
Location   Name                 Type
--------   ----                 ----
eastus     default Microsoft.DesktopVirtualization/hostpools/sessionhostManagements/sessionHostProvisioningStatuses
```

This command gets a Azure Virtual Desktop SessionHostProvisioningStatus in a HostPool.
