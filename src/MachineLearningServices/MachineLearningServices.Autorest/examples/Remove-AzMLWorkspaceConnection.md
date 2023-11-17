### Example 1: Delete a workspace connection
```powershell
Remove-AzMLWorkspaceConnection -ResourceGroupName ml-rg-test -WorkspaceName mlworkspace-test01 -ConnectionName test01
```

```output
```

Delete a workspace connection

### Example 2: Delete a workspace connection by pipeline
```powershell
Get-AzMLWorkspaceConnection -ResourceGroupName ml-rg-test -WorkspaceName mlworkspace-test01 -ConnectionName test01 | Remove-AzMLWorkspaceConnection
```

```output
```

Delete a workspace connection by pipeline
