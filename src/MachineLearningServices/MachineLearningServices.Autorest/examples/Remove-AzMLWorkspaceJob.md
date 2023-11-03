### Example 1: Deletes a Job (asynchronous)
```powershell
Remove-AzMLWorkspaceJob -ResourceGroupName ml-rg-test -WorkspaceName mlworkspace-test01 -Name commandJob01
```

```output
```

Deletes a Job (asynchronous)

### Example 2: Deletes a Job (asynchronous) by pipeline
```powershell
Get-AzMLWorkspaceJob -ResourceGroupName ml-rg-test -WorkspaceName mlworkspace-test01 -Name commandJob01 | Remove-AzMLWorkspaceJob
```

```output
```

Deletes a Job (asynchronous) by pipeline

