### Example 1: Start Aks cluster with resource group name and cluster name
```powershell
Start-AzAksCluster -ResourceGroupName group -Name myCluster
```

Start Aks cluster with resource group name and cluster name.

### Example 2: Start Aks cluster with pipeline
```powershell
Get-AzAksCluster -ResourceGroupName group -Name myCluster | Start-AzAksCluster
```

Start Aks cluster with pipeline.


