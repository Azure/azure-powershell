### Example 1: Update an existing Kubernetes Cluster Extension.
```powershell
PS C:\>  Update-AzKubernetesExtension -ClusterName azps_test_cluster -ClusterType ConnectedClusters -Name azps_test_extension -ResourceGroupName azps_test_group -ConfigurationProtectedSetting @{"aa"="bb"}

Name                Type
----                ----
azps_test_extension Microsoft.KubernetesConfiguration/extensions
```

Update an existing Kubernetes Cluster Extension.