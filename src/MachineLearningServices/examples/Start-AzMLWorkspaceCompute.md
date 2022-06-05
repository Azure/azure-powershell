### Example 1: Posts a start action to a compute instance
```powershell
Start-AzMLWorkspaceCompute -ResourceGroupName ml-rg-test -WorkspaceName mlworkspace-test01 -Name compute02
```

```output
```

Posts a start action to a compute instance

### Example 2: Posts a start action to a compute instance by pipeline
```powershell
Get-AzMLWorkspaceCompute -ResourceGroupName ml-rg-test -WorkspaceName mlworkspace-test01 -Name compute02 | Start-AzMLWorkspaceCompute 
```

```output
```

Posts a start action to a compute instance by pipeline

