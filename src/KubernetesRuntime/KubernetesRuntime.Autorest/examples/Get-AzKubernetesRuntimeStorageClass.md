### Example 1: List all storage classes of a connected cluster 
```powershell
Get-AzKubernetesRuntimeStorageClass -ArcConnectedClusterId /subscriptions/00000000-1111-2222-3333-444444444444/resourceGroups/example/providers/Microsoft.Kubernetes/connectedClusters/cluster1
```

Lists all storage classes of a connected cluster.

### Example 2: Get a storage class of a connected cluster
```powershell
Get-AzKubernetesRuntimeStorageClass -ArcConnectedClusterId /subscriptions/00000000-1111-2222-3333-444444444444/resourceGroups/example/providers/Microsoft.Kubernetes/connectedClusters/cluster1 -Name "default"
```

Gets detailed information of a storage class of a connected cluster
