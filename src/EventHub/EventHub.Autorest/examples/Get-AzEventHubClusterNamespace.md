### Example 1: List all Namespace ID's in a cluster
```powershell
Get-AzEventHubClusterNamespace -ResourceGroupName myResourceGroup -ClusterName DefaultCluster-11
```

```output
Id
--
/subscriptions/subscriptionId/resourceGroups/myResourceGroup/providers/Microsoft.EventHub/namespaces/myNamespace1
/subscriptions/subscriptionId/resourceGroups/myResourceGroup/providers/Microsoft.EventHub/namespaces/myNamespace2
```

Lists ID's of all namespaces created in EventHubs dedicated cluster `DefaultCluster-11`.