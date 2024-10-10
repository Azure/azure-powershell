### Example 1: Get a Azure Virtual Desktop Desktop by name
```powershell
Get-AzWvdDesktop -ResourceGroupName ResourceGroupName -ApplicationGroupName ApplicationGroupName -Name DesktopName
```

```output
Name                             Type
----                             ----
ApplicationGroupName/DesktopName Microsoft.DesktopVirtualization/applicationgroups/desktops
```

This command gets a Azure Virtual Desktop Desktop in an application Group.

### Example 2: List Azure Virtual Desktop Desktops
```powershell
Get-AzWvdDesktop -ResourceGroupName ResourceGroupName -ApplicationGroupName ApplicationGroupName
```

```output
Name                             Type
----                             ----
ApplicationGroupName/DesktopName Microsoft.DesktopVirtualization/applicationgroups/desktops
```

This command lists Azure Virtual Desktop Desktops in an application Group.

