### Example 1: Stop Aks cluster with resource group name and cluster name
```powershell
Stop-AzAksCluster -ResourceGroupName group -Name myCluster
```

Stop Aks cluster with resource group name and cluster name.

### Example 2: Stop Aks cluster with pipeline
```powershell
Get-AzAksCluster -ResourceGroupName group -Name myCluster | Stop-AzAksCluster
```

Stop Aks cluster with pipeline.


