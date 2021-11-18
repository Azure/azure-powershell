### Example 1: List all Entity Query Templates
```powershell
PS C:\> Get-AzSentinelEntityQueryTemplate -ResourceGroupName "myResourceGroupName" -workspaceName "myWorkspaceName"

{{ Add output here }}
```

This command lists all Entity Query Templates under a Microsoft Sentinel workspace.

### Example 2: Get an Entity Query Template
```powershell
PS C:\> Get-AzSentinelEntityQueryTemplate -ResourceGroupName "myResourceGroupName" -workspaceName "myWorkspaceName" -Id "myEntityQueryTemplateId"

{{ Add output here }}
```

This command gets an Entity Query Template.

### Example 3: Get an Entity Query Template by object Id
```powershell
PS C:\> $EntityQueryTemplates = Get-AzSentinelEntityQueryTemplate -ResourceGroupName "myResourceGroupName" -workspaceName "myWorkspaceName"
PS C:\> $EntityQueryTemplates[0] | Get-AzSentinelEntityQueryTemplate

{{ Add output here }}
```

This command gets a Entity Query Template by object.