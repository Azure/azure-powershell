### Example 1: Get Insights and Activities for an Entity
```powershell
PS C:\> Get-AzSentinelEntityAcivity -ResourceGroupName "myResourceGroupName" -workspaceName "myWorkspaceName" -EntityId "myEntityId"

{{ Add output here }}
```

This command gets insights and activities for an Entity.

### Example 2: Get Insights and Activities for an Entity by object Id
```powershell
PS C:\> $Entity = Get-AzSentinelEntity -ResourceGroupName "myResourceGroupName" -workspaceName "myWorkspaceName" -EntityId "myEntityId"
PS C:\> $Entity | Get-AzSentinelEntityActivity

{{ Add output here }}
```

This command gets insights and activies for an Entity by object