
### Example 1: Get a Windows Virtual Desktop SessionHostConfiguration by HostPoolName

```powershell
Get-AzWvdSessionHostConfiguration -ResourceGroupName ResourceGroupName -HostPoolName HostPoolName
```

```output
Location   Name                 Type
--------   ----                 ----
eastus     HostPoolName Microsoft.DesktopVirtualization/hostpools/{hostpoolName}/sessionHostConfigurations
```

This command gets a Windows Virtual Desktop SessionHostConfiguration in a Resource Group.
