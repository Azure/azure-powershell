### Example 1: List all Namespace ID's in a cluster
```powershell
Get-AzEventHubClusterNamespace -ResourceGroupName myResourceGroup -ClusterName myCluster
```

```output
Id
--
/subscriptions/{subscriptionId}/resourceGroups/myResourceGroup/providers/Microsoft.EventHub/namespaces/myNamespace1
/subscriptions/{subscriptionId}/resourceGroups/myResourceGroup/providers/Microsoft.EventHub/namespaces/myNamespace2
```
