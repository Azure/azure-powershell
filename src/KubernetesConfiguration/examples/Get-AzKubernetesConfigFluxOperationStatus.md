### Example 1: Get Async Operation status
```powershell
PS C:\> Get-AzKubernetesConfigFluxOperationStatus -ClusterName azpstest_cluster_arc -ClusterType ConnectedClusters -FluxConfigurationName azpstestflux-k8s -ResourceGroupName azpstest_gp -OperationId e9871335-7ba8-4100-8cb4-73b3464eb863

Name                                 ResourceGroupName Status
----                                 ----------------- ------
e9871335-7ba8-4100-8cb4-73b3464eb863 azpstest_gp       Succeeded
```

Get Async Operation status