
### Example 1: Get a Windows Virtual Desktop HostPool by name

```powershell
Get-AzWvdHostPool -ResourceGroupName ResourceGroupName -Name HostPoolName
```

```output
Location   Name                 Type
--------   ----                 ----
eastus     HostPoolName Microsoft.DesktopVirtualization/hostpools
```

This command gets a Windows Virtual Desktop HostPool in a Resource Group.

### Example 2: List Windows Virtual Desktop HostPools

```powershell
Get-AzWvdHostPool -ResourceGroupName ResourceGroupName
```

```output
Location   Name          Type
--------   ----          ----
eastus     HostPoolName1 Microsoft.DesktopVirtualization/hostpools
eastus     HostPoolName2 Microsoft.DesktopVirtualization/hostpools
```

This command lists a Windows Virtual Desktop HostPools in a Resource Group.
