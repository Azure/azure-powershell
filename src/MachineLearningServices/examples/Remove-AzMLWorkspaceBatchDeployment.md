### Example 1: Delete Batch Inference deployment (asynchronous)
```powershell
Remove-AzMLWorkspaceBatchDeployment -ResourceGroupName ml-rg-test -WorkspaceName mlworkspace-cli01 -EndpointName batch-pwsh03 -Name nonmlflowdp
```

```output
```

Delete Batch Inference deployment (asynchronous)

### Example 2: Delete Batch Inference deployment (asynchronous) by pipeline
```powershell
Get-AzMLWorkspaceBatchDeployment -ResourceGroupName ml-rg-test -WorkspaceName mlworkspace-cli01 -EndpointName batch-pwsh03 -Name nonmlflowdp | Remove-AzMLWorkspaceBatchDeployment
```

```output
```

Delete Batch Inference deployment (asynchronous) by pipeline

