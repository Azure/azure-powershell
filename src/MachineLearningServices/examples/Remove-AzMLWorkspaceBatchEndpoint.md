### Example 1: Delete Batch Inference Endpoint (asynchronous)
```powershell
Remove-AzMLWorkspaceBatchEndpoint -ResourceGroupName ml-rg-test -WorkspaceName mlworkspace-cli01 -Name batchpwsh01-key
```

```output
```

Delete Batch Inference Endpoint (asynchronous)

### Example 2: Delete Batch Inference Endpoint (asynchronous) by pipeline
```powershell
Get-AzMLWorkspaceBatchEndpoint -ResourceGroupName ml-rg-test -WorkspaceName mlworkspace-cli01 -Name batchpwsh01-key | Remove-AzMLWorkspaceBatchEndpoint
```

```output
```

Delete Batch Inference Endpoint (asynchronous) by pipeline

