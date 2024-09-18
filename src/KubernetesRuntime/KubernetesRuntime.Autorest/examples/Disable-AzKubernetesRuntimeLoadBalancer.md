### Example 1: Disable Arc Networking service in a connected cluster
```powershell
Disable-AzKubernetesRuntimeLoadBalancer -ArcConnectedClusterId /subscriptions/00000000-1111-2222-3333-444444444444/resourceGroups/example/providers/Microsoft.Kubernetes/connectedClusters/cluster1
```

Disables Arc Networking service in a connected cluster. Returns the deleted Azure resources.
