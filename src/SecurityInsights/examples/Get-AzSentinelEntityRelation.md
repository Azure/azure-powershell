### Example 1: List all Entity Relations for a given Entity 
```powershell
PS C:\> Get-AzSentinelEntityRelation -ResourceGroupName "myResourceGroupName" -workspaceName "myWorkspaceName" -EntityId "myEntityId"
```

This command lists all Entity Relations for a given Entity.

### Example 2: Get an Entity Relation
```powershell
PS C:\> Get-AzSentinelEntityRelation -ResourceGroupName "myResourceGroupName" -workspaceName "myWorkspaceName" -EntityId "myEntityId" -Id "myEntityRelationId"
```

This command gets an Entity Relation for a given Entity.

### Example 3: Get an Entity Relation by object Id
```powershell
PS C:\> $EntityRelations = Get-AzSentinelEntityRelation -ResourceGroupName "myResourceGroupName" -workspaceName "myWorkspaceName" -EntityId "myEntityId"
PS C:\> $EntityRelations[0] | Get-AzSentinelEntityRelation

```

This command gets a Entity Relation by object