### Example 1: Scale up control plane count
```powershell
New-AzAksArcCluster -ClusterName azps_test_cluster -ResourceGroupName azps_test_group -ControlPlaneCount 3
```

Increase control plane count to 3 nodes. 

### Example 2: Enable autoscaling
```powershell
New-AzAksArcCluster -ClusterName azps_test_cluster -ResourceGroupName azps_test_group -EnableAutoScaling -MinCount 1 -MaxCount 5
```

Enable autoscaling in provisioned cluster. 

### Example 3: Enable NfCsiDriver
```powershell
New-AzAksArcCluster -ClusterName azps_test_cluster -ResourceGroupName azps_test_group -NfCsiDriverEnabled
```

Enable NfCsi driver in provisioned cluster. 

### Example 4: Enable SmbCsiDriver
```powershell
New-AzAksArcCluster -ClusterName azps_test_cluster -ResourceGroupName azps_test_group -SmbCsiDriverEnabled
```

Enable SmbCsi driver in provisioned cluster. 

### Example 5: Enable azure hybrid benefit
```powershell
New-AzAksArcCluster -ClusterName azps_test_cluster -ResourceGroupName azps_test_group -EnableAzureHybridBenefit
```

Enable Azure Hybrid User Benefits feature for a provisioned cluster.

### Example 6: Disable azure hybrid benefit
```powershell
New-AzAksArcCluster -ClusterName azps_test_cluster -ResourceGroupName azps_test_group -EnableAzureHybridBenefit:$false
```

Disable Azure Hybrid User Benefits feature for a provisioned cluster.

### Example 7: Disable autoscaling
```powershell
New-AzAksArcCluster -ClusterName azps_test_cluster -ResourceGroupName azps_test_group -EnableAutoScaling:$false
```

Disable autoscaling in provisioned cluster. 

### Example 8: Disable NfCsiDriver
```powershell
New-AzAksArcCluster -ClusterName azps_test_cluster -ResourceGroupName azps_test_group -NfCsiDriverEnabled:$false
```

Disable NfCsi driver in provisioned cluster. 

### Example 9: Disable SmbCsiDriver
```powershell
New-AzAksArcCluster -ClusterName azps_test_cluster -ResourceGroupName azps_test_group -SmbCsiDriverEnabled:$false
```

Disable SmbCsi driver in provisioned cluster. 


### Example 10: New aad admin GUIDS
```powershell
New-AzAksArcCluster -ClusterName azps_test_cluster -ResourceGroupName azps_test_group -AdminGroupObjectID @("2e00cb64-66d8-4c9c-92d8-6462caf99e33", "1b28ff4f-f7c5-4aaa-aa79-ba8b775ab443")
```

New aad admin GUIDS. 







