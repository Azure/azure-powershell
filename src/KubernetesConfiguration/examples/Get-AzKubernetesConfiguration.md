### Example 1: List details of the Source Control Configuration.
```powershell
PS C:\> Get-AzKubernetesConfiguration -ResourceGroupName azpstest_gp -ClusterName azpstest_cluster_arc -ClusterType ConnectedClusters

Name                 RepositoryUrl          ResourceGroupName
----                 -------------          -----------------
azpstestk8s          http://github.com/xxxx azpstest_gp
azpstestk8s-operator http://github.com/xxxx azpstest_gp
```

List details of the Source Control Configuration.

### Example 2: Gets details of the Source Control Configuration.
```powershell
PS C:\> Get-AzKubernetesConfiguration -ResourceGroupName azpstest_gp -ClusterName azpstest_cluster_arc -ClusterType ConnectedClusters -Name azpstestk8s

Name        RepositoryUrl          ResourceGroupName
----        -------------          -----------------
azpstestk8s http://github.com/xxxx azpstest_gp
```

Gets details of the Source Control Configuration.