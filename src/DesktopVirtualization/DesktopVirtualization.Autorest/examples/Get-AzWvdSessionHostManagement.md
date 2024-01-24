
### Example 1: Get a Windows Virtual Desktop SessionHostManagement by HostPoolName

```powershell
Get-AzWvdSessionHostManagement -ResourceGroupName ResourceGroupName -HostPoolName HostPoolName
```

```output
Location   Name                 Type
--------   ----                 ----
eastus     HostPoolName Microsoft.DesktopVirtualization/hostpools/{hostpoolName}/sessionHostManagements
```

This command gets a Windows Virtual Desktop SessionHostManagement in a Resource Group.

