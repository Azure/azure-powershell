### Example 1: Get all nodepools in a provisioned cluster. 
```powershell
Get-AzAksArcNodepool -ClusterName azps_test_cluster -ResourceGroupName azps_test_group
```

```output
Name                  ResourceGroupName
----                  -----------------
azps_test_nodepool1    azps_test_group
azps_test_nodepool2    azps_test_group
```

This command gets the provisioned cluster's nodepools. 

### Example 2: Get a specific nodepool in a provisioned cluster. 
```powershell
Get-AzAksArcNodepool -ClusterName azps_test_cluster -ResourceGroupName azps_test_group -Name azps_test_nodepool1
```

This command gets the specified provisioned cluster nodepool.

