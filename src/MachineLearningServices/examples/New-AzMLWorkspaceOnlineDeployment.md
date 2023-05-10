### Example 1: Create or update Inference Endpoint Deployment (asynchronous)
```powershell
New-AzMLWorkspaceOnlineDeployment -ResourceGroupName ml-rg-test -WorkspaceName mlworkspace-cli01 -EndpointName online-pwsh01 -Name blue -Location "eastus" -EndpointComputeType 'Managed' `
-CodeId "/subscriptions/9e223dbe-3399-4e19-88eb-0975f02ac87f/resourceGroups/ml-rg-test/providers/Microsoft.MachineLearningServices/workspaces/mlworkspace-cli01/codes/787fc793-1ac7-414e-a035-7248767b7b23/versions/1" -CodeScoringScript "score.py" `
-EnvironmentId "/subscriptions/9e223dbe-3399-4e19-88eb-0975f02ac87f/resourceGroups/ml-rg-test/providers/Microsoft.MachineLearningServices/workspaces/mlworkspace-cli01/environments/CliV2AnonymousEnvironment/versions/8a424b013f5b0177929a1697d772da41" `
-Model "/subscriptions/9e223dbe-3399-4e19-88eb-0975f02ac87f/resourceGroups/ml-rg-test/providers/Microsoft.MachineLearningServices/workspaces/mlworkspace-cli01/models/a99089c5-23a6-4431-9ecd-37c70f01c9bc/versions/1" -InstanceType "Standard_F2s_v2" `
-SkuName "Default" -SkuCapacity 1
```

```output
Location Name SystemDataCreatedAt  SystemDataCreatedBy                 SystemDataCreatedByType SystemDataLastModifiedAt SystemDataLastModifiedBy SystemDataLastModifiedByType AzureAsyncOperation Kind    ResourceGroupName
-------- ---- -------------------  -------------------                 ----------------------- ------------------------ ------------------------ ---------------------------- ------------------- ----    -----------------
eastus   blue 5/19/2022 2:52:06 AM Lucas Yao (Wicresoft North America)                         5/19/2022 2:52:06 AM                                                                               Managed ml-rg-test
```

Create or update Inference Endpoint Deployment (asynchronous)

