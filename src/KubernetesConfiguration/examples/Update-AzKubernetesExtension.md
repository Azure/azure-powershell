### Example 1: Update an existing Kubernetes Cluster Extension.
```powershell
<<<<<<< HEAD
Update-AzKubernetesExtension -ClusterName azpstest_cluster_arc -ClusterType ConnectedClusters -Name azpstest-extension -ResourceGroupName azpstest_gp -ConfigurationProtectedSetting @{"aa"="bb"}
```

```output
=======
PS C:\> Update-AzKubernetesExtension -ClusterName azpstest_cluster_arc -ClusterType ConnectedClusters -Name azpstest-extension -ResourceGroupName azpstest_gp -ConfigurationProtectedSetting @{"aa"="bb"}

>>>>>>> 97176e9029ae7684a4ab56b6bec6966b134d4f91
Name               ExtensionType           Version ProvisioningState AutoUpgradeMinorVersion ReleaseTrain
----               -------------           ------- ----------------- ----------------------- ------------
azpstest-extension azuremonitor-containers 2.9.2   Succeeded         True                    Stable
```

Update an existing Kubernetes Cluster Extension.