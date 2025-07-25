### Example 1: Delete component version
```powershell
Remove-AzMLWorkspaceComponentVersion -ResourceGroupName ml-rg-test -WorkspaceName mlworkspace-cli01 -Name componentpwsh01 -Version 1
```

```output
```

 Delete component version

### Example 2:  Delete component version by pipeline
```powershell
Get-AzMLWorkspaceComponentVersion -ResourceGroupName ml-rg-test -WorkspaceName mlworkspace-cli01 -Name componentpwsh01 -Version 1 | Remove-AzMLWorkspaceComponentVersion
```

```output
```

 Delete component version by pipeline

