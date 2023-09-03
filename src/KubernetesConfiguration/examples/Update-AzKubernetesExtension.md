### Example 1: Update an existing Kubernetes Cluster Extension.
```powershell
Update-AzKubernetesExtension -ClusterName azpstest_cluster_arc -ClusterType ConnectedClusters -Name azpstest-extension -ResourceGroupName azps_test_group -ConfigurationProtectedSetting @{"aa"="bb"}
```

```output
Name               ExtensionType           Version ProvisioningState AutoUpgradeMinorVersion ReleaseTrain
----               -------------           ------- ----------------- ----------------------- ------------
azpstest-extension azuremonitor-containers 2.9.2   Succeeded         True                    Stable
```

Update an existing Kubernetes Cluster Extension.