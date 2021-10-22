### Example 1: Create a new Kubernetes Cluster Extension.
```powershell
PS C:\> New-AzKubernetesExtension -ClusterName azps_test_cluster -ClusterType ConnectedClusters -Name azps_test_extension -ResourceGroupName azps_test_group -ExtensionType Microsoft.Arcdataservices

Name                Type
----                ----
azps_test_extension Microsoft.KubernetesConfiguration/extensions
```

Create a new Kubernetes Cluster Extension.