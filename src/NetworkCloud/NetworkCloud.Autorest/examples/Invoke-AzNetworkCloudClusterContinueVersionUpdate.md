### Example 1: Resume an update for a cluster with a matching update strategy that has paused after completing a segment.
```powershell
Invoke-AzNetworkCloudClusterContinueVersionUpdate -ResourceGroupName resourceGroupName -ClusterName clusterName -SubscriptionId subscriptionId -MachineGroupTargetingMode "AlphaByRack"  
```

This command resumes an update for a cluster with a matching update strategy that has paused after completing a segment.