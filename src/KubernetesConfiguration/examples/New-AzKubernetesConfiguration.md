### Example 1: Create a configuration for kubernetes cluster
```powershell
PS C:\> New-AzConnectedKubernetes -ClusterName azpstest_cluster_arc -ResourceGroupName azpstest_gp -Location eastus
PS C:\> New-AzKubernetesConfiguration -ResourceGroupName azpstest_gp -ClusterName azpstest_cluster_arc -Name azpstestk8s -RepositoryUrl http://github.com/xxxx -ClusterType ConnectedClusters

Name        RepositoryUrl          ResourceGroupName
----        -------------          -----------------
azpstestk8s http://github.com/xxxx azpstest_gp
```

This command creates a configuration for kubernetes cluster.

### Example 2: Create a configuration for kubernetes cluster with specify paramter OperatorNamespace
```powershell
PS C:\> New-AzConnectedKubernetes -ClusterName azpstest_cluster_arc -ResourceGroupName azpstest_gp -Location eastus
PS C:\> New-AzKubernetesConfiguration -ResourceGroupName azpstest_gp -ClusterName azpstest_cluster_arc -Name azpstestk8s-operator -RepositoryUrl http://github.com/xxxx -OperatorNamespace namespace-t01 -ClusterType ConnectedClusters

Name                 RepositoryUrl          ResourceGroupName
----                 -------------          -----------------
azpstestk8s-operator http://github.com/xxxx azpstest_gp
```

This command creates a configuration in the new operator namespace for kubernetes cluster. Note, Unable to create a configuration in an existing operator namespace.