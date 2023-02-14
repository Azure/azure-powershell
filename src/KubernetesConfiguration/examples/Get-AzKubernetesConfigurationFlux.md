### Example 1: List details of the Flux Configuration.
```powershell
<<<<<<< HEAD
Get-AzKubernetesConfigurationFlux -ClusterName azpstest_cluster_arc -ClusterType ConnectedClusters -ResourceGroupName azpstest_gp
```

```output
=======
PS C:\> Get-AzKubernetesConfigurationFlux -ClusterName azpstest_cluster_arc -ClusterType ConnectedClusters -ResourceGroupName azpstest_gp

>>>>>>> 97176e9029ae7684a4ab56b6bec6966b134d4f91
Name             ResourceGroupName
----             -----------------
azpstestflux-k8s azpstest_gp
```

List details of the Flux Configuration.

### Example 2: Gets details of the Flux Configuration.
```powershell
<<<<<<< HEAD
Get-AzKubernetesConfigurationFlux -ClusterName azpstest_cluster_arc -ClusterType ConnectedClusters -Name azpstestflux-k8s -ResourceGroupName azpstest_gp
```

```output
=======
PS C:\> Get-AzKubernetesConfigurationFlux -ClusterName azpstest_cluster_arc -ClusterType ConnectedClusters -Name azpstestflux-k8s -ResourceGroupName azpstest_gp

>>>>>>> 97176e9029ae7684a4ab56b6bec6966b134d4f91
Name             ResourceGroupName
----             -----------------
azpstestflux-k8s azpstest_gp
```

Gets details of the Flux Configuration.