### Example 1: Get a Windows Virtual Desktop Worksapce by name
```powershell
PS C:\> Get-AzWvdWorksapce -ResourceGroupName ResourceGroupName -Name WorkspaceName

Location   Name                 Type
--------   ----                 ----
eastus     WorkspaceName Microsoft.DesktopVirtualization/workspaces
```

This command gets a Windows Virtual Desktop Workspace in a Resource Group.

### Example 2: List Windows Virtual Desktop Workspaces
```powershell
PS C:\> Get-AzWvdWorksapce -ResourceGroupName ResourceGroupName

Location   Name           Type
--------   ----           ----
eastus     WorkspaceName1 Microsoft.DesktopVirtualization/workspaces
eastus     WorkspaceName2 Microsoft.DesktopVirtualization/workspaces
```

This command lists a Windows Virtual Desktop Workspaces in a Resource Group.

