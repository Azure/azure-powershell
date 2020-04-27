### Example 1: Get a Windows Virtual Desktop ApplicationGroup by name
```powershell
PS C:\> Get-AzWvdApplicationGroup -ResourceGroupName ResourceGroupName -Name ApplicationGroupName

Location   Name                 Type
--------   ----                 ----
eastus     ApplicationGroupName Microsoft.DesktopVirtualization/applicationgroups
```

This command gets a Windows Virtual Desktop ApplicationGroup in a Resource Group.

### Example 2: List Windows Virtual Desktop ApplicationGroups
```powershell
PS C:\> Get-AzWvdApplicationGroup -ResourceGroupName ResourceGroupName

Location   Name                  Type
--------   ----                  ----
eastus     ApplicationGroupName1 Microsoft.DesktopVirtualization/applicationgroups
eastus     ApplicationGroupName2 Microsoft.DesktopVirtualization/applicationgroups
```

This command lists a Windows Virtual Desktop ApplicationGroups in a Resource Group.

