### Example 1: Remove a configuation of Kubernetes Cluster by name
```powershell
<<<<<<< HEAD
Remove-AzKubernetesConfiguration -ResourceGroupName azpstest_gp -ClusterName azpstest_cluster_arc -Name  azpstestk8s -ClusterType ConnectedClusters
=======
PS C:\> Remove-AzKubernetesConfiguration -ResourceGroupName azpstest_gp -ClusterName azpstest_cluster_arc -Name  azpstestk8s -ClusterType ConnectedClusters

>>>>>>> 97176e9029ae7684a4ab56b6bec6966b134d4f91
```

This command removes a configuation of Kubernetes Cluster by name.

### Example 2: Remove a configuation of Kubernetes Cluster by object
```powershell
<<<<<<< HEAD
$kubConf = Get-AzKubernetesConfiguration -ClusterName azpstest_cluster_arc -ClusterType ConnectedClusters -ResourceGroupName azpstest_gp -Name azpstestk8s-operator
Remove-AzKubernetesConfiguration -InputObject $kubConf
=======
PS C:\> $kubConf = Get-AzKubernetesConfiguration -ClusterName azpstest_cluster_arc -ClusterType ConnectedClusters -ResourceGroupName azpstest_gp -Name azpstestk8s-operator
Remove-AzKubernetesConfiguration -InputObject $kubConf

>>>>>>> 97176e9029ae7684a4ab56b6bec6966b134d4f91
```

This command removes a configuation of Kubernetes Cluster by object.