### Example 1: Start Aks cluster with resource group name and cluster name
```powershell
PS C:\> Start-AzAksCluster -ResourceGroupName group -Name myCluster
```

Start Aks cluster with resource group name and cluster name.

### Example 2: Start Aks cluster with pipeline
```powershell
PS C:\> Get-AzAksCluster -ResourceGroupName group -Name myCluster | Start-AzAksCluster
```

Start Aks cluster with pipeline.
