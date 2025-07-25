### Example 1: Upgrade kubernetes version to latest possible
```powershell
Invoke-AzAksArcClusterUpgrade -ClusterName azps_test_cluster -ResourceGroupName azps_test_group
```

Upgrade cluster to latest kubernetes version. 

### Example 2: Upgrade kubernetes version to specified version
```powershell
Invoke-AzAksArcClusterUpgrade -ClusterName azps_test_cluster -ResourceGroupName azps_test_group -KubernetesVersion "1.28.5"
```

Upgrade cluster to the specified kubernetes version. 
