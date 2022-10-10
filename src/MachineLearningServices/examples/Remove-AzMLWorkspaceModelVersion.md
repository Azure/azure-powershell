### Example 1: Delete model version
```powershell
Remove-AzMLWorkspaceModelVersion  -ResourceGroupName ml-rg-test -WorkspaceName mlworkspace-cli01 -Name modelcontainerpwsh01 -Version 1
```

```output
```

Delete model version

### Example 2: Delete model version by pipeline
```powershell
Get-AzMLWorkspaceModelVersion  -ResourceGroupName ml-rg-test -WorkspaceName mlworkspace-cli01 -Name modelcontainerpwsh01 -Version 1 | Remove-AzMLWorkspaceModelVersion 
```

```output
```

Delete model version by pipeline

