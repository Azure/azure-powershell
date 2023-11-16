### Example 1: Delete component container
```powershell
Remove-AzMLWorkspaceComponentContainer -ResourceGroupName ml-rg-test -WorkspaceName mlworkspace-cli01 -Name component-pwsh01
```

```output
```

Delete component container

### Example 2: Delete component container by pipeline

```powershell
Get-AzMLWorkspaceComponentContainer -ResourceGroupName ml-rg-test -WorkspaceName mlworkspace-cli01 -Name component-pwsh01 | Remove-AzMLWorkspaceComponentContainer
```

```output
```

Delete component container by pipeline
