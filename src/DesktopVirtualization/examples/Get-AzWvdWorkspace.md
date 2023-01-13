### Example 1: Get a Windows Virtual Desktop Workspace by name
```powershell
Get-AzWvdWorkspace -ResourceGroupName ResourceGroupName -Name WorkspaceName
```

```output
Location   Name                 Type
--------   ----                 ----
eastus     WorkspaceName Microsoft.DesktopVirtualization/workspaces
```

This command gets a Windows Virtual Desktop Workspace in a Resource Group.

### Example 2: List Windows Virtual Desktop Workspaces
```powershell
Get-AzWvdWorkspace -ResourceGroupName ResourceGroupName
```

```output
Location   Name           Type
--------   ----           ----
eastus     WorkspaceName1 Microsoft.DesktopVirtualization/workspaces
eastus     WorkspaceName2 Microsoft.DesktopVirtualization/workspaces
```

This command lists a Windows Virtual Desktop Workspaces in a Resource Group.

