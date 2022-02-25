### Example 1: List details of the Source Control Configuration.
```powershell
Get-AzKubernetesConfiguration -ResourceGroupName azps_test_group -ClusterName azps_test_cluster -ClusterType ConnectedClusters
```

```output
Name          Type
----          ----
azpstestk8s01 Microsoft.KubernetesConfiguration/sourceControlConfigurations
azpstestk8s02 Microsoft.KubernetesConfiguration/sourceControlConfigurations
```

List details of the Source Control Configuration.

### Example 2: Gets details of the Source Control Configuration.
```powershell
Get-AzKubernetesConfiguration -ResourceGroupName azps_test_group -ClusterName azps_test_cluster -ClusterType ConnectedClusters -Name azpstestk8s01
```

```output
Name          Type
----          ----
azpstestk8s01 Microsoft.KubernetesConfiguration/sourceControlConfigurations
```

Gets details of the Source Control Configuration.