### Example 1: Delete Inference Endpoint Deployment (asynchronous)
```powershell
Remove-AzMLWorkspaceOnlineDeployment -ResourceGroupName ml-rg-test -WorkspaceName mlworkspace-cli01 -EndpointName online-pwsh01 -Name pwshblue01
```

```output
```

Delete Inference Endpoint Deployment (asynchronous)

### Example 2: Delete Inference Endpoint Deployment (asynchronous) by pipeline
```powershell
Get-AzMLWorkspaceOnlineDeployment -ResourceGroupName ml-rg-test -WorkspaceName mlworkspace-cli01 -EndpointName online-pwsh01 -Name pwshblue01 | Remove-AzMLWorkspaceOnlineDeployment
```

```output
```

Delete Inference Endpoint Deployment (asynchronous) by pipeline

