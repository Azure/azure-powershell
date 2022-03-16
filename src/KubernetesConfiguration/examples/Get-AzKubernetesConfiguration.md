### Example 1: List details of the Source Control Configuration.
```powershell
Get-AzKubernetesConfiguration -ResourceGroupName azps_test_group -ClusterName azps_test_cluster -ClusterType ConnectedClusters
```

```output
Name          RepositoryUrl          ResourceGroupName
----          -------------          -----------------
azpstestk8s01 http://github.com/xxxx azps_test_group
azpstestk8s02 http://github.com/xxxx azps_test_group
```

List details of the Source Control Configuration.

### Example 2: Gets details of the Source Control Configuration.
```powershell
Get-AzKubernetesConfiguration -ResourceGroupName azps_test_group -ClusterName azps_test_cluster -ClusterType ConnectedClusters -Name azpstestk8s01
```

```output
Name          RepositoryUrl          ResourceGroupName
----          -------------          -----------------
azpstestk8s01 http://github.com/xxxx azps_test_group
```

Gets details of the Source Control Configuration.