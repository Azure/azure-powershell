### Example 1: Delete a workspace connection
```powershell
Remove-AzMLWorkspaceConnection -ResourceGroupName ml-rg-test -WorkspaceName mlworkspace-test01 -Name test01
```

Delete a workspace connection

### Example 2: Delete a workspace connection by pipeline
```powershell
Get-AzMLWorkspaceConnection -ResourceGroupName ml-rg-test -WorkspaceName mlworkspace-test01 -Name test01 | Remove-AzMLWorkspaceConnection
```

Delete a workspace connection by pipeline

