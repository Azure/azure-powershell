### Example 1: Get Aks node pool upgrade profile with resource group name and cluster name
```powershell
Get-AzAksNodePoolUpgradeProfile -ResourceGroupName group -ClusterName myCluster -AgentPoolName default
```

```output
Name    Type
----    ----
default Microsoft.ContainerService/managedClusters/agentPools/upgradeProfiles
```

Get Aks node pool upgrade profile with resource group name and cluster name.


