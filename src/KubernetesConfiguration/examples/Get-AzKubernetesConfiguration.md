### Example 1: List details of the Source Control Configuration.
```powershell
PS C:\> Get-AzKubernetesConfiguration -ResourceGroupName azps_test_group -ClusterName azps_test_cluster -ClusterType ConnectedClusters

Name          Type
----          ----
azpstestk8s01 Microsoft.KubernetesConfiguration/sourceControlConfigurations
azpstestk8s02 Microsoft.KubernetesConfiguration/sourceControlConfigurations
```

List details of the Source Control Configuration.

### Example 2: Gets details of the Source Control Configuration.
```powershell
PS C:\> Get-AzKubernetesConfiguration -ResourceGroupName azps_test_group -ClusterName azps_test_cluster -ClusterType ConnectedClusters -Name azpstestk8s01

Name          Type
----          ----
azpstestk8s01 Microsoft.KubernetesConfiguration/sourceControlConfigurations
```

Gets details of the Source Control Configuration.