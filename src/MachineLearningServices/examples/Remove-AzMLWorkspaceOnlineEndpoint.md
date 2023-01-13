### Example 1: Delete Online Endpoint (asynchronous)
```powershell
Remove-AzMLWorkspaceOnlineEndpoint -ResourceGroupName ml-rg-test -WorkspaceName mlworkspace-cli01 -Name online-pwsh01
```

```output
```

Delete Online Endpoint (asynchronous)

### Example 2: Delete Online Endpoint (asynchronous) by pipeline
```powershell
Get-AzMLWorkspaceOnlineEndpoint -ResourceGroupName ml-rg-test -WorkspaceName mlworkspace-cli01 -Name online-pwsh01 | Remove-AzMLWorkspaceOnlineEndpoint
```

```output
```

Delete Online Endpoint (asynchronous) by pipeline

