### Example 1: List all Entity Relations for a given Entity 
```powershell
 Get-AzSentinelEntityRelation -ResourceGroupName "myResourceGroupName" -workspaceName "myWorkspaceName" -EntityId "myEntityId"
```

This command lists all Entity Relations for a given Entity.

### Example 2: Get an Entity Relation
```powershell
 Get-AzSentinelEntityRelation -ResourceGroupName "myResourceGroupName" -workspaceName "myWorkspaceName" -EntityId "myEntityId" -RelationName "myEntityRelationId"
```

This command gets an Entity Relation for a given Entity.

### Example 3: Get an Entity Relation by object Id
```powershell
 $EntityRelations = Get-AzSentinelEntityRelation -ResourceGroupName "myResourceGroupName" -workspaceName "myWorkspaceName" -EntityId "myEntityId"
 $EntityRelations[0] | Get-AzSentinelEntityRelation
```

This command gets a Entity Relation by object