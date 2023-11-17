### Example 1: List details of the Source Control Configuration.
```powershell
Get-AzKubernetesConfiguration -ResourceGroupName azps_test_group -ClusterName azpstest_cluster_arc -ClusterType ConnectedClusters
```

```output
Name                 RepositoryUrl          ResourceGroupName
----                 -------------          -----------------
azpstestk8s          http://github.com/xxxx azps_test_group
azpstestk8s-operator http://github.com/xxxx azps_test_group
```

List details of the Source Control Configuration.

### Example 2: Gets details of the Source Control Configuration.
```powershell
Get-AzKubernetesConfiguration -ResourceGroupName azps_test_group -ClusterName azpstest_cluster_arc -ClusterType ConnectedClusters -Name azpstestk8s
```

```output
Name        RepositoryUrl          ResourceGroupName
----        -------------          -----------------
azpstestk8s http://github.com/xxxx azps_test_group
```

Gets details of the Source Control Configuration.