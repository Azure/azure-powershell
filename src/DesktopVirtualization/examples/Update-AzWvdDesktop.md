### Example 1: Update a Windows Virtual Desktop Desktop
```powershell
Update-AzWvdDesktop -ResourceGroupName ResourceGroupName `
                    -ApplicationGroupName ApplicationGroupName `
                    -Name DesktopName `
                    -FriendlyName 'Friendly name' `
                    -Description 'Description'
```

```output
Name                             Type
----                             ----
ApplicationGroupName/DesktopName Microsoft.DesktopVirtualization/applicationgroups/desktops
```

This command updates a Windows Virtual Desktop Desktop in an applicaton Group.

