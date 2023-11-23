### Example 1: Create a new Kubernetes Cluster Extension.
```powershell
New-AzKubernetesExtension -ClusterName azpstest_cluster_arc -ClusterType ConnectedClusters -Name azpstest-extension -ResourceGroupName azps_test_group -ExtensionType azuremonitor-containers
```

```output
Name               ExtensionType           Version ProvisioningState AutoUpgradeMinorVersion ReleaseTrain
----               -------------           ------- ----------------- ----------------------- ------------
azpstest-extension azuremonitor-containers 2.9.2   Succeeded         True                    Stable
```

Create a new Kubernetes Cluster Extension.

### Example 2: Create a Flux Cluster Extension.
```powershell
New-AzKubernetesExtension -ClusterName azpstest_cluster_arc -ClusterType ConnectedClusters -Name flux -ResourceGroupName azps_test_group -ExtensionType microsoft.flux -AutoUpgradeMinorVersion -ReleaseNamespace flux-system -IdentityType 'SystemAssigned'
```

```output
Name ExtensionType  Version ProvisioningState AutoUpgradeMinorVersion ReleaseTrain
---- -------------  ------- ----------------- ----------------------- ------------
flux microsoft.flux 1.0.0   Succeeded         True                    Stable
```

Create a Flux Cluster Extension.