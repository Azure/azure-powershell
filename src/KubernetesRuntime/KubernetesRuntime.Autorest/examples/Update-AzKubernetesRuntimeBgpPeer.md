### Example 1: Update a bgp peer from a connected cluster
```powershell
Update-AzKubernetesRuntimeBgpPeer -Name test1 -ArcConnectedClusterId /subscriptions/00000000-1111-2222-3333-444444444444/resourceGroups/example/providers/Microsoft.Kubernetes/connectedClusters/cluster1 -MyAsn 10000 -PeerAsn 20000 -PeerAddress 192.168.50.2
```

Update a bgp peer from a connected cluster.
