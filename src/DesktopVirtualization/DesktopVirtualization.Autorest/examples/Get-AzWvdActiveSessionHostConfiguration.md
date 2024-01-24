
### Example 1: Get a Windows Virtual Desktop ActiveSessionHostConfiguration by HostPoolName

```powershell
Get-AzWvdActiveSessionHostConfiguration -ResourceGroupName ResourceGroupName -HostPoolName HostPoolName
```

```output
Location   Name                 Type
--------   ----                 ----
eastus     HostPoolName Microsoft.DesktopVirtualization/hostpools/{hostpoolName}/activeSessionHostConfigurations
```

This command gets a Windows Virtual Desktop ActiveSessionHostConfiguration in a Resource Group.
