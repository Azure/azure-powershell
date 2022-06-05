### Example 1: Cancels a Job (asynchronous)
```powershell
Stop-AzMLWorkspaceJob -ResourceGroupName ml-rg-test -WorkspaceName mlworkspace-test01 -Name commandJob01
```

```output
```

Cancels a Job (asynchronous)

### Example 2: Cancels a Job (asynchronous) by pipeline
```powershell
Get-AzMLWorkspaceJob -ResourceGroupName ml-rg-test -WorkspaceName mlworkspace-test01 -Name commandJob01 | Stop-AzMLWorkspaceJob
```

```output
```

Cancels a Job (asynchronous) by pipeline

