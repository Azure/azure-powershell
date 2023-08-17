### Example 1: Delete model container
```powershell
Remove-AzMLWorkspaceModelContainer -ResourceGroupName ml-rg-test -WorkspaceName mlworkspace-cli01 -Name modelcontainerpwsh01
```

```output
```

Delete model container

### Example 2: Delete model container by pipeline
```powershell
Get-AzMLWorkspaceModelContainer -ResourceGroupName ml-rg-test -WorkspaceName mlworkspace-cli01 -Name modelcontainerpwsh01 | Remove-AzMLWorkspaceModelContainer 
```

```output
```

Delete model container by pipeline

