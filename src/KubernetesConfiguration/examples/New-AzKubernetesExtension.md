### Example 1: Create a new Kubernetes Cluster Extension.
```powershell
PS C:\> New-AzKubernetesExtension -ClusterName azps_test_cluster -ClusterType ConnectedClusters -Name azps_test_extension -ResourceGroupName azps_test_group -ExtensionType Microsoft.Arcdataservices

Name                ExtensionType             Version      ProvisioningState AutoUpgradeMinorVersion ReleaseTrain ResourceGroupName
----                -------------             -------      ----------------- ----------------------- ------------ -----------------
azps_test_extension microsoft.arcdataservices 1.0.16701001 Succeeded         True                    Stable       azps_test_group
```

Create a new Kubernetes Cluster Extension.