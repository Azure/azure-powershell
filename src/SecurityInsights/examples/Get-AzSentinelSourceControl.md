### Example 1: List all Source Controls
```powershell
PS C:\> Get-AzSentinelSourceControl -ResourceGroupName "myResourceGroupName" -workspaceName "myWorkspaceName"

{{ Add output here }}
```

This command lists all Source Controls under a Microsoft Sentinel workspace.

### Example 2: Get a Source Control
```powershell
PS C:\> Get-AzSentinelSourceControl -ResourceGroupName "myResourceGroupName" -workspaceName "myWorkspaceName" -Id "mySourceControlId"

{{ Add output here }}
```

This command gets a Source Control.

### Example 3: Get a SourceControl by object Id
```powershell
PS C:\> $SourceControls = Get-AzSentinelSourceControl -ResourceGroupName "myResourceGroupName" -workspaceName "myWorkspaceName"
PS C:\> $SourceControls[0] | Get-AzSentinelSourceControl

{{ Add output here }}
```

This command gets a Source Control by object