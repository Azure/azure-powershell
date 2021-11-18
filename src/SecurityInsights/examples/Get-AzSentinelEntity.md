### Example 1: List all Entities
```powershell
PS C:\> Get-AzSentinelEntity -ResourceGroupName "myResourceGroupName" -workspaceName "myWorkspaceName"

{{ Add output here }}
```

This command lists all Entities under a Microsoft Sentinel workspace.

### Example 2: Get an Entity
```powershell
PS C:\> Get-AzSentinelEntity -ResourceGroupName "myResourceGroupName" -workspaceName "myWorkspaceName" -Id "myEntityId"

{{ Add output here }}
```

This command gets an Entity.

### Example 3: Get a Entity by object Id
```powershell
PS C:\> $Entitys = Get-AzSentinelEntity -ResourceGroupName "myResourceGroupName" -workspaceName "myWorkspaceName"
PS C:\> $Entitys[0] | Get-AzSentinelEntity

{{ Add output here }}
```

This command gets an Entity by object