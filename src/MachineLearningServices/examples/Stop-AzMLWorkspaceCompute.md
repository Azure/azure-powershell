### Example 1: Posts a stop action to a compute instance
```powershell
Stop-AzMLWorkspaceCompute -ResourceGroupName ml-rg-test -WorkspaceName mlworkspace-test01 -Name compute02
```

```output
```

Posts a stop action to a compute instance

### Example 2: Posts a stop action to a compute instance by pipeline
```powershell
Get-AzMLWorkspaceCompute -ResourceGroupName ml-rg-test -WorkspaceName mlworkspace-test01 -Name compute02 | Stop-AzMLWorkspaceCompute 
```

```output
```

Posts a stop action to a compute instance by pipeline
