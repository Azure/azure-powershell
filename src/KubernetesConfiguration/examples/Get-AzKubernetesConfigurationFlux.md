### Example 1: List details of the Flux Configuration.
```powershell
PS C:\> Get-AzKubernetesConfigurationFlux -ClusterName azpstest_cluster_arc -ClusterType ConnectedClusters -ResourceGroupName azpstest_gp

Name             ResourceGroupName
----             -----------------
azpstestflux-k8s azpstest_gp
```

List details of the Flux Configuration.

### Example 2: Gets details of the Flux Configuration.
```powershell
PS C:\> Get-AzKubernetesConfigurationFlux -ClusterName azpstest_cluster_arc -ClusterType ConnectedClusters -Name azpstestflux-k8s -ResourceGroupName azpstest_gp

Name             ResourceGroupName
----             -----------------
azpstestflux-k8s azpstest_gp
```

Gets details of the Flux Configuration.