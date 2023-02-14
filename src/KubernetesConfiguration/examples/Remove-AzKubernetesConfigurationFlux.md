### Example 1: This will delete the YAML file used to set up the Flux Configuration, thus stopping future sync from the source repo.
```powershell
<<<<<<< HEAD
Remove-AzKubernetesConfigurationFlux -ClusterName azpstest_cluster_arc -ClusterType ConnectedClusters -Name azpstestflux-k8s -ResourceGroupName azpstest_gp
=======
PS C:\> Remove-AzKubernetesConfigurationFlux -ClusterName azpstest_cluster_arc -ClusterType ConnectedClusters -Name azpstestflux-k8s -ResourceGroupName azpstest_gp

>>>>>>> 97176e9029ae7684a4ab56b6bec6966b134d4f91
```

This will delete the YAML file used to set up the Flux Configuration, thus stopping future sync from the source repo.

### Example 2: This will delete the YAML file used to set up the Flux Configuration, thus stopping future sync from the source repo.
```powershell
<<<<<<< HEAD
Get-AzKubernetesConfigurationFlux -ClusterName azpstest_cluster_arc -ClusterType ConnectedClusters -Name azpstestflux-k8s -ResourceGroupName azpstest_gp | Remove-AzKubernetesConfigurationFlux
=======
PS C:\> Get-AzKubernetesConfigurationFlux -ClusterName azpstest_cluster_arc -ClusterType ConnectedClusters -Name azpstestflux-k8s -ResourceGroupName azpstest_gp | Remove-AzKubernetesConfigurationFlux

>>>>>>> 97176e9029ae7684a4ab56b6bec6966b134d4f91
```

This will delete the YAML file used to set up the Flux Configuration, thus stopping future sync from the source repo.