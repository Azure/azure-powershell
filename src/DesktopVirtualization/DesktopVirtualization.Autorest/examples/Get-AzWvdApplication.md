### Example 1: Get a Windows Virtual Desktop Application by name
```powershell
Get-AzWvdApplication -ResourceGroupName ResourceGroupName -ApplicationGroupName ApplicationGroupName -Name ApplicationName
```

```output
Name                                 Type
----                                 ----
ApplicationGroupName/ApplicationName Microsoft.DesktopVirtualization/applicationgroups/applications
```

This command gets a Windows Virtual Desktop Application in an applicaton Group.

### Example 2: List Windows Virtual Desktop Applications
```powershell
Get-AzWvdApplication -ResourceGroupName ResourceGroupName -ApplicationGroupName ApplicationGroupName
```

```output
Name                                 Type
----                                 ----
ApplicationGroupName/ApplicationName1 Microsoft.DesktopVirtualization/applicationgroups/applications
ApplicationGroupName/ApplicationName2 Microsoft.DesktopVirtualization/applicationgroups/applications
```

This command Lists Windows Virtual Desktop Applications in an applicaton Group.

