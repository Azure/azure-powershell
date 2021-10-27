### Example 1: Update an existing Kubernetes Cluster Extension.
```powershell
PS C:\>  Update-AzKubernetesExtension -ClusterName azps_test_cluster -ClusterType ConnectedClusters -Name azps_test_extension -ResourceGroupName azps_test_group -ConfigurationProtectedSetting @{"aa"="bb"}

Name                ExtensionType             Version      ProvisioningState AutoUpgradeMinorVersion ResourceGroupName
----                -------------             -------      ----------------- ----------------------- -----------------
azps_test_extension microsoft.arcdataservices 1.0.16701001 Succeeded         True                    azps_test_group
```

Update an existing Kubernetes Cluster Extension.