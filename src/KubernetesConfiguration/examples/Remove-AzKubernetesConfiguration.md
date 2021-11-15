### Example 1: Remove a configuation of kubernetes cluster by name
```powershell
PS C:\> Remove-AzKubernetesConfiguration -ResourceGroupName azps_test_group -ClusterName azps_test_cluster -Name  azpstestk8s01 -ClusterType ConnectedClusters

```

This command removes a configuation of kubernetes cluster by name.

### Example 2: Remove a configuation of kubernetes cluster by object
```powershell
PS C:\> $kubConf = Get-AzKubernetesConfiguration -ClusterName azps_test_cluster -ClusterType ConnectedClusters -ResourceGroupName azps_test_group -Name azpstestk8s02
PS C:\> Remove-AzKubernetesConfiguration -InputObject $kubConf

```

This command removes a configuation of kubernetes cluster by object.