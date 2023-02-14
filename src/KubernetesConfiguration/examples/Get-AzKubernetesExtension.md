### Example 1: Gets Kubernetes Cluster Extension.
```powershell
<<<<<<< HEAD
Get-AzKubernetesExtension -ClusterName azpstest_cluster_arc -ClusterType ConnectedClusters -Name azpstest-extension -ResourceGroupName azpstest_gp
```

```output
=======
PS C:\> Get-AzKubernetesExtension -ClusterName azpstest_cluster_arc -ClusterType ConnectedClusters -Name azpstest-extension -ResourceGroupName azpstest_gp

>>>>>>> 97176e9029ae7684a4ab56b6bec6966b134d4f91
Name               ExtensionType           Version ProvisioningState AutoUpgradeMinorVersion ReleaseTrain
----               -------------           ------- ----------------- ----------------------- ------------
azpstest-extension azuremonitor-containers 2.9.2   Succeeded         True                    Stable
```

Gets Kubernetes Cluster Extension.

### Example 2: List Kubernetes Cluster Extension.
```powershell
<<<<<<< HEAD
Get-AzKubernetesExtension -ClusterName azpstest_cluster_arc -ClusterType ConnectedClusters -ResourceGroupName azpstest_gp
```

```output
=======
PS C:\> Get-AzKubernetesExtension -ClusterName azpstest_cluster_arc -ClusterType ConnectedClusters -ResourceGroupName azpstest_gp

>>>>>>> 97176e9029ae7684a4ab56b6bec6966b134d4f91
Name               ExtensionType           Version ProvisioningState AutoUpgradeMinorVersion ReleaseTrain
----               -------------           ------- ----------------- ----------------------- ------------
azpstest-extension azuremonitor-containers 2.9.2   Succeeded         True                    Stable
flux               microsoft.flux          1.0.0   Succeeded         True                    Stable
```

List Kubernetes Cluster Extension.