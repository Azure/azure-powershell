### Example 1: Get Async Operation status
```powershell
Get-AzKubernetesConfigFluxOperationStatus -ClusterName azpstest_cluster_arc -ClusterType ConnectedClusters -FluxConfigurationName azpstestflux-k8s -ResourceGroupName azps_test_group -OperationId e9871335-7ba8-4100-8cb4-73b3464eb863
```

```output
Name                                 ResourceGroupName Status
----                                 ----------------- ------
e9871335-7ba8-4100-8cb4-73b3464eb863 azps_test_group   Succeeded
```

Get Async Operation status