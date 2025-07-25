### Example 1: List details of the Flux Configuration.
```powershell
Get-AzKubernetesConfigurationFlux -ClusterName azpstest_cluster_arc -ClusterType ConnectedClusters -ResourceGroupName azps_test_group
```

```output
Name             ResourceGroupName
----             -----------------
azpstestflux-k8s azps_test_group
```

List details of the Flux Configuration.

### Example 2: Gets details of the Flux Configuration.
```powershell
Get-AzKubernetesConfigurationFlux -ClusterName azpstest_cluster_arc -ClusterType ConnectedClusters -Name azpstestflux-k8s -ResourceGroupName azps_test_group
```

```output
Name             ResourceGroupName
----             -----------------
azpstestflux-k8s azps_test_group
```

Gets details of the Flux Configuration.