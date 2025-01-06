### Example 1: List all load balancers of a connected cluster
```powershell
Get-AzKubernetesRuntimeLoadBalancer -ArcConnectedClusterId /subscriptions/00000000-1111-2222-3333-444444444444/resourceGroups/example/providers/Microsoft.Kubernetes/connectedClusters/cluster1
```

List all load balancers of a connected cluster

### Example 2: Get a load balancer of a connected cluster
```powershell
Get-AzKubernetesRuntimeLoadBalancer -ArcConnectedClusterId /subscriptions/00000000-1111-2222-3333-444444444444/resourceGroups/example/providers/Microsoft.Kubernetes/connectedClusters/cluster1 -Name "test1"
```

Get a load balancer of a connected cluster

