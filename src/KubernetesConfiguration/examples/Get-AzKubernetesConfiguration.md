### Example 1: List details of the Source Control Configuration.
```powershell
<<<<<<< HEAD
Get-AzKubernetesConfiguration -ResourceGroupName azpstest_gp -ClusterName azpstest_cluster_arc -ClusterType ConnectedClusters
```

```output
=======
PS C:\> Get-AzKubernetesConfiguration -ResourceGroupName azpstest_gp -ClusterName azpstest_cluster_arc -ClusterType ConnectedClusters

>>>>>>> 97176e9029ae7684a4ab56b6bec6966b134d4f91
Name                 RepositoryUrl          ResourceGroupName
----                 -------------          -----------------
azpstestk8s          http://github.com/xxxx azpstest_gp
azpstestk8s-operator http://github.com/xxxx azpstest_gp
```

List details of the Source Control Configuration.

### Example 2: Gets details of the Source Control Configuration.
```powershell
<<<<<<< HEAD
Get-AzKubernetesConfiguration -ResourceGroupName azpstest_gp -ClusterName azpstest_cluster_arc -ClusterType ConnectedClusters -Name azpstestk8s
```

```output
=======
PS C:\> Get-AzKubernetesConfiguration -ResourceGroupName azpstest_gp -ClusterName azpstest_cluster_arc -ClusterType ConnectedClusters -Name azpstestk8s

>>>>>>> 97176e9029ae7684a4ab56b6bec6966b134d4f91
Name        RepositoryUrl          ResourceGroupName
----        -------------          -----------------
azpstestk8s http://github.com/xxxx azpstest_gp
```

Gets details of the Source Control Configuration.