### Example 1: Create a load balancer from a connected cluster
```powershell
New-AzKubernetesRuntimeLoadBalancer -Name test1 -ArcConnectedClusterId /subscriptions/00000000-1111-2222-3333-444444444444/resourceGroups/example/providers/Microsoft.Kubernetes/connectedClusters/cluster1 -Address "192.168.50.1/32" -AdvertiseMode ARP
```

Create a load balancer from a connected cluster.

### Example 2: Create a load balancer with service selector specified
```powershell
New-AzKubernetesRuntimeLoadBalancer -Name test1 -ArcConnectedClusterId /subscriptions/00000000-1111-2222-3333-444444444444/resourceGroups/example/providers/Microsoft.Kubernetes/connectedClusters/cluster1 -Address "192.168.50.1/32" -AdvertiseMode ARP -ServiceSelector @{"a"= "b"; "c"="d"}
```

Create a load balancer with service selector specified. It restricts the load balancer works for related service.

### Example 3: Create a load balancer with bgp peers specified
```powershell
New-AzKubernetesRuntimeLoadBalancer -Name test1 -ArcConnectedClusterId /subscriptions/00000000-1111-2222-3333-444444444444/resourceGroups/example/providers/Microsoft.Kubernetes/connectedClusters/cluster1 -Address "192.168.50.1/32" -AdvertiseMode ARP -BgpPeer bgptest1
```

Create a load balancer with bgp peers specified. It restricts the the list of bgp peers the load balancer should advertise to.

