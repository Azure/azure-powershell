### Example 1: Remove storage class from a connected cluster
```powershell
Remove-AzKubernetesRuntimeStorageClass `
    -ArcConnectedClusterId /subscriptions/00000000-1111-2222-3333-444444444444/resourceGroups/example/providers/Microsoft.Kubernetes/connectedClusters/cluster1 -Name "default"
```

Remove a storage class from a connected cluster.

