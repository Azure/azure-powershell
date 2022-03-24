### Example 1: Get a Windows Virtual Desktop SessionHost by name
```powershell
Get-AzWvdSessionHost -ResourceGroupName ResourceGroupName -HostPoolName HostPoolName -Name SessionHostName
```

```output
Name                                               Type
----                                               ----
HostPoolName/SessionHostName Microsoft.DesktopVirtualization/hostpools/sessionhosts
```

This command gets a Windows Virtual Desktop SessionHost in a Host Pool.

### Example 2: List Windows Virtual Desktop SessionHosts
```powershell
Get-AzWvdSessionHost -ResourceGroupName ResourceGroupName -HostPoolName HostPoolName
```

```output
Name                                               Type
----                                               ----
HostPoolName/SessionHostName1 Microsoft.DesktopVirtualization/hostpools/sessionhosts
HostPoolName/SessionHostName2 Microsoft.DesktopVirtualization/hostpools/sessionhosts
```

This command lists a Windows Virtual Desktop SessionHosts in a Host Pool.

