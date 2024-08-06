### Example 1: Create model reference
```powershell
$model = Get-AzMLWorkspaceModelVersion -ResourceGroupName group-test -WorkspaceName mlworkspace-test -Version 1 -Name model1
New-AzMLWorkspaceIdAssetReferenceObject -AssetId $model.Id -ReferenceType 'Id'
```

```output
ReferenceType AssetId
------------- -------
Id            /subscriptions/11111111-2222-3333-4444-123456789101/resourceGroups/group-test/providers/Microsoft.MachineLearningServices/workspaces/mlworkspace-test/models/model1
```

This command creates model reference object.

