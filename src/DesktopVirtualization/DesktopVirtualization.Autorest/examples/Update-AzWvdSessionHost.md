### Example 1: Update a Windows Virtual Desktop SessionHost by name
```powershell
Update-AzWvdSessionHost -ResourceGroupName ResourceGroupName `
                            -HostPoolName HostPoolName `
                            -Name SessionHostName `
                            -AllowNewSession:$false
```

```output
Name                                               Type
----                                               ----
HostPoolName/SessionHostName Microsoft.DesktopVirtualization/hostpools/sessionhosts
```

This command updates a Windows Virtual Desktop SessionHost in a Host Pool.

