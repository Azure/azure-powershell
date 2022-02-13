### Example 1: Get Aks node pool upgrade profile with resource group name and cluster name
```powershell
PS C:\> Get-AzAksNodePoolUpgradeProfile -ResourceGroupName group -ClusterName myCluster -AgentPoolName default

Name    Type
----    ----
default Microsoft.ContainerService/managedClusters/agentPools/upgradeProfiles
```

Get Aks node pool upgrade profile with resource group name and cluster name.
