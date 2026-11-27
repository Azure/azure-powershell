### Example 1: Get a Azure Virtual Desktop SessionHost by name
```powershell
Get-AzWvdSessionHost -ResourceGroupName ResourceGroupName -HostPoolName HostPoolName -Name SessionHostName
```

```output
Name                                               Type
----                                               ----
HostPoolName/SessionHostName Microsoft.DesktopVirtualization/hostpools/sessionhosts
```

This command gets a Azure Virtual Desktop SessionHost in a Host Pool.

### Example 2: List Azure Virtual Desktop SessionHosts
```powershell
Get-AzWvdSessionHost -ResourceGroupName ResourceGroupName -HostPoolName HostPoolName
```

```output
Name                                               Type
----                                               ----
HostPoolName/SessionHostName1 Microsoft.DesktopVirtualization/hostpools/sessionhosts
HostPoolName/SessionHostName2 Microsoft.DesktopVirtualization/hostpools/sessionhosts
```

This command lists a Azure Virtual Desktop SessionHosts in a Host Pool.

