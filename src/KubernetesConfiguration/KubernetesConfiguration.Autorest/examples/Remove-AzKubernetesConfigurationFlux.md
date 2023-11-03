### Example 1: This will delete the YAML file used to set up the Flux Configuration, thus stopping future sync from the source repo.
```powershell
Remove-AzKubernetesConfigurationFlux -ClusterName azpstest_cluster_arc -ClusterType ConnectedClusters -Name azpstestflux-k8s -ResourceGroupName azps_test_group
```

This will delete the YAML file used to set up the Flux Configuration, thus stopping future sync from the source repo.

### Example 2: This will delete the YAML file used to set up the Flux Configuration, thus stopping future sync from the source repo.
```powershell
Get-AzKubernetesConfigurationFlux -ClusterName azpstest_cluster_arc -ClusterType ConnectedClusters -Name azpstestflux-k8s -ResourceGroupName azps_test_group | Remove-AzKubernetesConfigurationFlux
```

This will delete the YAML file used to set up the Flux Configuration, thus stopping future sync from the source repo.