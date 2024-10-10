
### Example 1: Get a Azure Virtual Desktop HostPool by name

```powershell
Get-AzWvdHostPool -ResourceGroupName ResourceGroupName -Name HostPoolName
```

```output
Location   Name                 Type
--------   ----                 ----
eastus     HostPoolName Microsoft.DesktopVirtualization/hostpools
```

This command gets a Azure Virtual Desktop HostPool in a Resource Group.

### Example 2: List Azure Virtual Desktop HostPools

```powershell
Get-AzWvdHostPool -ResourceGroupName ResourceGroupName
```

```output
Location   Name          Type
--------   ----          ----
eastus     HostPoolName1 Microsoft.DesktopVirtualization/hostpools
eastus     HostPoolName2 Microsoft.DesktopVirtualization/hostpools
```

This command lists a Azure Virtual Desktop HostPools in a Resource Group.
