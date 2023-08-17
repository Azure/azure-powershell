### Example 1: Posts a restart action to a compute instance
```powershell
Restart-AzMLWorkspaceCompute -ResourceGroupName ml-rg-test -WorkspaceName mlworkspace-test01 -Name compute02
```

```output
```

Posts a restart action to a compute instance

### Example 2: Posts a restart action to a compute instance by pipeline
```powershell
Get-AzMLWorkspaceCompute -ResourceGroupName ml-rg-test -WorkspaceName mlworkspace-test01 -Name compute02 | Restart-AzMLWorkspaceCompute
```

```output
```

Posts a restart action to a compute instance by pipeline

