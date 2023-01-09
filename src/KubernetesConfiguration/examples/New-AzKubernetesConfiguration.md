### Example 1: Create a configuration for Kubernetes Cluster
```powershell
New-AzConnectedKubernetes -ClusterName azpstest_cluster_arc -ResourceGroupName azpstest_gp -Location eastus
New-AzKubernetesConfiguration -ResourceGroupName azpstest_gp -ClusterName azpstest_cluster_arc -Name azpstestk8s -RepositoryUrl http://github.com/xxxx -ClusterType ConnectedClusters
```

```output
Name        RepositoryUrl          ResourceGroupName
----        -------------          -----------------
azpstestk8s http://github.com/xxxx azpstest_gp
```

This command creates a configuration for Kubernetes Cluster.

### Example 2: Create a configuration for Kubernetes Cluster with specify paramter OperatorNamespace
```powershell
New-AzConnectedKubernetes -ClusterName azpstest_cluster_arc -ResourceGroupName azpstest_gp -Location eastus
New-AzKubernetesConfiguration -ResourceGroupName azpstest_gp -ClusterName azpstest_cluster_arc -Name azpstestk8s-operator -RepositoryUrl http://github.com/xxxx -OperatorNamespace namespace-t01 -ClusterType ConnectedClusters
```

```output
Name                 RepositoryUrl          ResourceGroupName
----                 -------------          -----------------
azpstestk8s-operator http://github.com/xxxx azpstest_gp
```

This command creates a configuration in the new operator namespace for Kubernetes Cluster. Note, Unable to create a configuration in an existing operator namespace.