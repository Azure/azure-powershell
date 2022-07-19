### Example 1: List details of the Source Control Configuration.
```powershell
Get-AzKubernetesConfiguration -ResourceGroupName azpstest_gp -ClusterName azpstest_cluster_arc -ClusterType ConnectedClusters
```

```output
Name                 RepositoryUrl          ResourceGroupName
----                 -------------          -----------------
azpstestk8s          http://github.com/xxxx azpstest_gp
azpstestk8s-operator http://github.com/xxxx azpstest_gp
```

List details of the Source Control Configuration.

### Example 2: Gets details of the Source Control Configuration.
```powershell
Get-AzKubernetesConfiguration -ResourceGroupName azpstest_gp -ClusterName azpstest_cluster_arc -ClusterType ConnectedClusters -Name azpstestk8s
```

```output
Name        RepositoryUrl          ResourceGroupName
----        -------------          -----------------
azpstestk8s http://github.com/xxxx azpstest_gp
```

Gets details of the Source Control Configuration.