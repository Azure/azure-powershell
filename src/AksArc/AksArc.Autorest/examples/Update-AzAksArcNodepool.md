### Example 1: Scale up nodes in provisioned cluster nodepool. 
```powershell
Update-AzAksArcNodepool -ClusterName azps_test_cluster -ResourceGroupName azps_test_group -Name azps_test_nodepool_example -Count 3
```

Scales up the number of nodes in the provisioned cluster nodepool. 

### Example 2: Update tags in nodepool
```powershell
Update-AzAksArcNodepool -ClusterName azps_test_cluster -ResourceGroupName azps_test_group -Name azps_test_nodepool_example -Tag @{'key1'= 1; 'key2'= 2}
```

Adds the specified tags to the nodepool resource. 

### Example 3: Enable autoscaling in nodepool
```powershell
Update-AzAksArcNodepool -ClusterName azps_test_cluster -ResourceGroupName azps_test_group -Name azps_test_nodepool_example -EnableAutoScaling -MinCount 1 -MaxCount 5
```

Enables autoscaling in the nodepool with specified MinCount and MaxCount. 


