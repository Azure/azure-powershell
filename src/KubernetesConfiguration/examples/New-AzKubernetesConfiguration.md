### Example 1: Create a configuration for kubernetes cluster
```powershell
PS C:\> New-AzKubernetesConfiguration -ResourceGroupName azps_test_group -ClusterName azps_test_cluster -Name azpstestk8s01 -RepositoryUrl http://github.com/xxxx

Name          Type
----          ----
azpstestk8s01 Microsoft.KubernetesConfiguration/sourceControlConfigurations
```

This command creates a configuration for kubernetes cluster.

### Example 2: Create a configuration for kubernetes cluster with specify paramter OperatorNamespace
```powershell
PS C:\> New-AzKubernetesConfiguration -ResourceGroupName azps_test_group -ClusterName azps_test_cluster -Name azpstestk8s02 -RepositoryUrl http://github.com/xxxx -OperatorNamespace namespace-t01

Name          Type
----          ----
azpstestk8s02 Microsoft.KubernetesConfiguration/sourceControlConfigurations
```

This command creates a configuration in the new operator namespace for kubernetes cluster. Note, Unable to create a configuration in an existing operator namespace.