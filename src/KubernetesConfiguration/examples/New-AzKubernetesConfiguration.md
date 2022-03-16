### Example 1: Create a configuration for kubernetes cluster
```powershell
New-AzKubernetesConfiguration -ResourceGroupName azps_test_group -ClusterName azps_test_cluster -Name azpstestk8s01 -RepositoryUrl http://github.com/xxxx
```

```output
Name          Type
----          ----
azpstestk8s01 Microsoft.KubernetesConfiguration/sourceControlConfigurations
```

This command creates a configuration for kubernetes cluster.

### Example 2: Create a configuration for kubernetes cluster with specify paramter OperatorNamespace
```powershell
New-AzKubernetesConfiguration -ResourceGroupName azps_test_group -ClusterName azps_test_cluster -Name azpstestk8s02 -RepositoryUrl http://github.com/xxxx -OperatorNamespace namespace-t01
```

```output
Name          RepositoryUrl          ResourceGroupName
----          -------------          -----------------
azpstestk8s02 http://github.com/xxxx azps_test_group
```

This command creates a configuration in the new operator namespace for kubernetes cluster. Note, Unable to create a configuration in an existing operator namespace.