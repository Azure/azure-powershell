### Example 1: List Inference Endpoint Deployment Skus
```powershell
Get-AzMLWorkspaceOnlineDeploymentSku -ResourceGroupName ml-rg-test -WorkspaceName mlworkspace-cli01 -EndpointName online-cli01 -Name blue
```

```output
ResourceType
------------
Microsoft.MachineLearning.Services/endpoints/deployments
```

List Inference Endpoint Deployment Skus
