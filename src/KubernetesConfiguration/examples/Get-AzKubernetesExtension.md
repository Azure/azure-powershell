### Example 1: Gets Kubernetes Cluster Extension.
```powershell
PS C:\> Get-AzKubernetesExtension -ClusterName azps_test_cluster -ClusterType ConnectedClusters -Name azps_test_extension -ResourceGroupName azps_test_group

Name                Type
----                ----
azps_test_extension Microsoft.KubernetesConfiguration/extensions
```

Gets Kubernetes Cluster Extension.

### Example 2: List Kubernetes Cluster Extension.
```powershell
PS C:\> Get-AzKubernetesExtension -ClusterName azps_test_cluster -ClusterType ConnectedClusters -ResourceGroupName azps_test_group

Name                Type
----                ----
azps_test_extension Microsoft.KubernetesConfiguration/extensions
```

List Kubernetes Cluster Extension.