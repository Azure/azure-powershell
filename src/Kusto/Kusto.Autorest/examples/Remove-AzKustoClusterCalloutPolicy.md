### Example 1: Removing a callout policy from a cluster
```powershell
Remove-AzKustoClusterCalloutPolicy -ResourceGroupName rg1 -ClusterName cluster1 -SubscriptionId sub -CalloutPolicy @{CalloutId = "*_cosmosdb"}
```

The above command removes the callout policy with the CalloutId ending with "_cosmosdb" from the cluster "cluster1" in the resource group "rg1".


