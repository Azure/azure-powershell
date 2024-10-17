### Example 1: List all bgp peers of a connected cluster
```powershell
Get-AzKubernetesRuntimeBgpPeer -ArcConnectedClusterId /subscriptions/00000000-1111-2222-3333-444444444444/resourceGroups/example/providers/Microsoft.Kubernetes/connectedClusters/cluster1
```

List all bgp peers of a connected cluster

### Example 2: Get a bgp peer of a connected cluster
```powershell
Get-AzKubernetesRuntimeBgpPeer -ArcConnectedClusterId /subscriptions/00000000-1111-2222-3333-444444444444/resourceGroups/example/providers/Microsoft.Kubernetes/connectedClusters/cluster1 -Name "test1"
```

Get a bgp peer of a connected cluster

