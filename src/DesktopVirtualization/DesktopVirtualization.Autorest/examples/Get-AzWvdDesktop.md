### Example 1: Get a Windows Virtual Desktop Desktop by name
```powershell
Get-AzWvdDesktop -ResourceGroupName ResourceGroupName -ApplicationGroupName ApplicationGroupName -Name DesktopName
```

```output
Name                             Type
----                             ----
ApplicationGroupName/DesktopName Microsoft.DesktopVirtualization/applicationgroups/desktops
```

This command gets a Windows Virtual Desktop Desktop in an application Group.

### Example 2: List Windows Virtual Desktop Desktops
```powershell
Get-AzWvdDesktop -ResourceGroupName ResourceGroupName -ApplicationGroupName ApplicationGroupName
```

```output
Name                             Type
----                             ----
ApplicationGroupName/DesktopName Microsoft.DesktopVirtualization/applicationgroups/desktops
```

This command lists Windows Virtual Desktop Desktops in an application Group.

