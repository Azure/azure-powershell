### Example 1: Gets Kubernetes Cluster Extension.
```powershell
PS C:\> Get-AzKubernetesExtension -ClusterName azps_test_cluster -ClusterType ConnectedClusters -Name azps_test_extension -ResourceGroupName azps_test_group

Name                ExtensionType             Version      ProvisioningState AutoUpgradeMinorVersion ReleaseTrain ResourceGroupName
----                -------------             -------      ----------------- ----------------------- ------------ -----------------
azps_test_extension microsoft.arcdataservices 1.0.16701001 Succeeded         True                    Stable       azps_test_group
```

Gets Kubernetes Cluster Extension.

### Example 2: List Kubernetes Cluster Extension.
```powershell
PS C:\> Get-AzKubernetesExtension -ClusterName azps_test_cluster -ClusterType ConnectedClusters -ResourceGroupName azps_test_group

Name                ExtensionType             Version      ProvisioningState AutoUpgradeMinorVersion ReleaseTrain ResourceGroupName
----                -------------             -------      ----------------- ----------------------- ------------ -----------------
azps_test_extension microsoft.arcdataservices 1.0.16701001 Succeeded         True                    Stable       azps_test_group
```

List Kubernetes Cluster Extension.