### Example 1: Creates/updates a batch inference deployment (asynchronous)
```powershell
# The Reference Type includes Data Path, Output Path and Id.
# You can use following command to create it then pass it as value to Property parameter of the New-AzMLWorkspaceBatchDeployment cmdlet.
# New-AzMLWorkspaceIdAssetReferenceObject
# New-AzMLWorkspaceDataPathAssetReferenceObject
# New-AzMLWorkspaceOutputPathAssetReferenceObject
$model = New-AzMLWorkspaceIdAssetReferenceObject -AssetId '/subscriptions/11111111-2222-3333-4444-123456789101/resourceGroups/joyer-test/providers/Microsoft.MachineLearningServices/workspaces/mlworkspace-test002/models/openai-embeddings/versions/1' -ReferenceType 'Id'
New-AzMLWorkspaceBatchDeployment -ResourceGroupName ml-rg-test -WorkspaceName mlworkspace-cli01 -EndpointName batch-pwsh03 -Name nonmlflowdp -Location "eastus" `
-CodeId "/subscriptions/11111111-2222-3333-4444-123456789101/resourceGroups/ml-rg-test/providers/Microsoft.MachineLearningServices/workspaces/mlworkspace-cli01/codes/bd430754-fba7-4a63-a6b8-8ea8635767f3/versions/1" -CodeScoringScript "digit_identification.py" `
-EnvironmentId "/subscriptions/11111111-2222-3333-4444-123456789101/resourceGroups/ml-rg-test/providers/Microsoft.MachineLearningServices/workspaces/mlworkspace-cli01/environments/CliV2AnonymousEnvironment/versions/5d230430f302e7876f9b64710733f68e" `
-Model $model `
-ComputeId "/subscriptions/11111111-2222-3333-4444-123456789101/resourceGroups/ml-rg-test/providers/Microsoft.MachineLearningServices/workspaces/mlworkspace-cli01/computes/batch-cluster"
```

```output
Location Name        SystemDataCreatedAt SystemDataCreatedBy                 SystemDataCreatedByType SystemDataLastModifiedAt SystemDataLastModifiedBy SystemDataLastModifiedByType  Kind ResourceGroupName
-------- ----        ------------------- -------------------                 ----------------------- ------------------------ ------------------------ ----------------------------  ---- -----------------
eastus   nonmlflowdp 6/1/2022 6:19:16 AM UserName (Example)                  6/1/2022 6:19:16 AM                                                                                          ml-rg-test
```

Creates/updates a batch inference deployment (asynchronous)
