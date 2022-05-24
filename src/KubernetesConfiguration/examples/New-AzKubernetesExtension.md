### Example 1: Create a new Kubernetes Cluster Extension.
```powershell
PS C:\> New-AzKubernetesExtension -ClusterName azpstest_cluster_arc -ClusterType ConnectedClusters -Name azpstest-extension -ResourceGroupName azpstest_gp -ExtensionType azuremonitor-containers

Name               ExtensionType           Version ProvisioningState AutoUpgradeMinorVersion ReleaseTrain
----               -------------           ------- ----------------- ----------------------- ------------
azpstest-extension azuremonitor-containers 2.9.2   Succeeded         True                    Stable
```

Create a new Kubernetes Cluster Extension.

### Example 2: Create a Flux Cluster Extension.
```powershell
PS C:\> New-AzKubernetesExtension -ClusterName azpstest_cluster_arc -ClusterType ConnectedClusters -Name flux -ResourceGroupName azpstest_gp -ExtensionType microsoft.flux -AutoUpgradeMinorVersion -ClusterReleaseNamespace flux-system -IdentityType 'SystemAssigned'

Name ExtensionType  Version ProvisioningState AutoUpgradeMinorVersion ReleaseTrain
---- -------------  ------- ----------------- ----------------------- ------------
flux microsoft.flux 1.0.0   Succeeded         True                    Stable
```

Create a Flux Cluster Extension.