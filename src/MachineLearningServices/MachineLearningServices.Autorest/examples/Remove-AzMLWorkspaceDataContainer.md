### Example 1: Delete data container
```powershell
Remove-AzMLWorkspaceDataContainer -ResourceGroupName ml-rg-test -WorkspaceName mlworkspace-test01 -Name datacontainer-pwsh01
```

```output
```

Delete data container

### Example 2: Delete data container by pipeline
```powershell
Get-AzMLWorkspaceDataContainer -ResourceGroupName ml-rg-test -WorkspaceName mlworkspace-test01 -Name datacontainer-pwsh01 | Remove-AzMLWorkspaceDataContainer
```

```output
```

Delete data container by pipeline

