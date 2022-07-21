### Example 1: This will delete the YAML file used to set up the Flux Configuration, thus stopping future sync from the source repo.
```powershell
PS C:\> Remove-AzKubernetesConfigurationFlux -ClusterName azpstest_cluster_arc -ClusterType ConnectedClusters -Name azpstestflux-k8s -ResourceGroupName azpstest_gp

```

This will delete the YAML file used to set up the Flux Configuration, thus stopping future sync from the source repo.

### Example 2: This will delete the YAML file used to set up the Flux Configuration, thus stopping future sync from the source repo.
```powershell
PS C:\> Get-AzKubernetesConfigurationFlux -ClusterName azpstest_cluster_arc -ClusterType ConnectedClusters -Name azpstestflux-k8s -ResourceGroupName azpstest_gp | Remove-AzKubernetesConfigurationFlux

```

This will delete the YAML file used to set up the Flux Configuration, thus stopping future sync from the source repo.