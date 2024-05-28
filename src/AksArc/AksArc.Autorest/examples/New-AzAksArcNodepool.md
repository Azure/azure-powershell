### Example 1: Create a nodepool
```powershell
New-AzAksArcNodepool -ClusterName azps_test_cluster -ResourceGroupName azps_test_group -Name azps_test_nodepool_example
```

Adds a nodepool in the provisioned cluster with default configuration.

### Example 2: Create a nodepool with 3 nodes
```powershell
New-AzAksArcNodepool -ClusterName azps_test_cluster -ResourceGroupName azps_test_group -Name azps_test_nodepool_example -Count 3
```

Adds a nodepool in the provisioned cluster with 3 worker nodes. 

