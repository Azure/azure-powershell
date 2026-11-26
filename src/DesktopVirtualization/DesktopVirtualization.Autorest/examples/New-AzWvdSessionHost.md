### Example 1: Create an Azure Virtual Desktop SessionHost
```powershell
New-AzWvdSessionHost -ResourceGroupName resourceGroup1 -HostPoolName hostPool1 -Name sessionHost1.microsoft.com
```

```output
Name                                          Type
----                                          ----
hostPool1/sessionHost1.microsoft.com          Microsoft.DesktopVirtualization/hostpools/sessionhosts
```

This command creates a new Azure Virtual Desktop SessionHost in a Host Pool.

### Example 2: Create an Azure Virtual Desktop SessionHost with friendly name
```powershell
New-AzWvdSessionHost -ResourceGroupName resourceGroup1 `
                     -HostPoolName hostPool1 `
                     -Name sessionHost1.microsoft.com `
                     -FriendlyName 'Friendly Name' `
                     -AllowNewSession
```

```output
Name                                          Type
----                                          ----
hostPool1/sessionHost1.microsoft.com          Microsoft.DesktopVirtualization/hostpools/sessionhosts
```

This command creates a new Azure Virtual Desktop SessionHost in a Host Pool with a friendly name and allows new sessions.
