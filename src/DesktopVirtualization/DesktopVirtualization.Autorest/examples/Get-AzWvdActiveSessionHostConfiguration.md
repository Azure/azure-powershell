### Example 1: Get a Azure Virtual Desktop ActiveSessionHostConfiguration by HostPoolName
```powershell
Get-AzWvdActiveSessionHostConfiguration -ResourceGroupName ResourceGroupName -HostPoolName HostPoolName
```

```output
Location   Name                 Type
--------   ----                 ----
eastus     default Microsoft.DesktopVirtualization/hostpools/activesessionHostconfigurations
```

This command gets a Azure Virtual Desktop ActiveSessionHostConfiguration in a Resource Group.
