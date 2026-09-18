### Example 1: Update a load balancer from a connected cluster
```powershell
Update-AzKubernetesRuntimeLoadBalancer -Name test1 -ArcConnectedClusterId /subscriptions/00000000-1111-2222-3333-444444444444/resourceGroups/example/providers/Microsoft.Kubernetes/connectedClusters/cluster1 -Address 192.168.50.5/32
```

Update a load balancer from a connected cluster


