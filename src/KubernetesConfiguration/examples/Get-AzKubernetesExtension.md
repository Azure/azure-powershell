### Example 1: Gets Kubernetes Cluster Extension.
```powershell
Get-AzKubernetesExtension -ClusterName azpstest_cluster_arc -ClusterType ConnectedClusters -Name azpstest-extension -ResourceGroupName azps_test_group
```

```output
Name               ExtensionType           Version ProvisioningState AutoUpgradeMinorVersion ReleaseTrain
----               -------------           ------- ----------------- ----------------------- ------------
azpstest-extension azuremonitor-containers 2.9.2   Succeeded         True                    Stable
```

Gets Kubernetes Cluster Extension.

### Example 2: List Kubernetes Cluster Extension.
```powershell
Get-AzKubernetesExtension -ClusterName azpstest_cluster_arc -ClusterType ConnectedClusters -ResourceGroupName azps_test_group
```

```output
Name               ExtensionType           Version ProvisioningState AutoUpgradeMinorVersion ReleaseTrain
----               -------------           ------- ----------------- ----------------------- ------------
azpstest-extension azuremonitor-containers 2.9.2   Succeeded         True                    Stable
flux               microsoft.flux          1.0.0   Succeeded         True                    Stable
```

List Kubernetes Cluster Extension.