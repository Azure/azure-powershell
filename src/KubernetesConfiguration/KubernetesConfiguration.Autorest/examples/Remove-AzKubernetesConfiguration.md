### Example 1: Remove a configuation of Kubernetes Cluster by name
```powershell
Remove-AzKubernetesConfiguration -ResourceGroupName azps_test_group -ClusterName azpstest_cluster_arc -Name  azpstestk8s -ClusterType ConnectedClusters
```

This command removes a configuation of Kubernetes Cluster by name.

### Example 2: Remove a configuation of Kubernetes Cluster by object
```powershell
Get-AzKubernetesConfiguration -ClusterName azpstest_cluster_arc -ClusterType ConnectedClusters -ResourceGroupName azps_test_group -Name azpstestk8s-operator | Remove-AzKubernetesConfiguration
```

This command removes a configuation of Kubernetes Cluster by object.