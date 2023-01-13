### Example 1: Remove a configuation of Kubernetes Cluster by name
```powershell
PS C:\> Remove-AzKubernetesConfiguration -ResourceGroupName azpstest_gp -ClusterName azpstest_cluster_arc -Name  azpstestk8s -ClusterType ConnectedClusters

```

This command removes a configuation of Kubernetes Cluster by name.

### Example 2: Remove a configuation of Kubernetes Cluster by object
```powershell
PS C:\> $kubConf = Get-AzKubernetesConfiguration -ClusterName azpstest_cluster_arc -ClusterType ConnectedClusters -ResourceGroupName azpstest_gp -Name azpstestk8s-operator
Remove-AzKubernetesConfiguration -InputObject $kubConf

```

This command removes a configuation of Kubernetes Cluster by object.