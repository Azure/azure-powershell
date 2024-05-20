### Example 1: Create a provisioned cluster with default configuration
```powershell
New-AzAksArcNodepool -ClusterName azps_test_cluster -ResourceGroupName azps_test_group -VnetId azps_vnet_arm_id -CustomLocationName azps_customlocation_arm_id -ControlPlaneEndpointHostIP azps_ip
```
Create a provisioned cluster with default configuration. 

### Example 2: Create a provisioned cluster with specified control plane node count. 
```powershell
New-AzAksArcNodepool -ClusterName azps_test_cluster -ResourceGroupName azps_test_group -VnetId azps_vnet_arm_id -CustomLocationName azps_customlocation_arm_id -ControlPlaneEndpointHostIP azps_ip -EnableAutoScaling -MinCount 1 -MaxCount 5
```

Create a provisioned cluster with specified control plane node count. 

### Example 3: Create a provisioned cluster with specified kubernetes version. 
```powershell
New-AzAksArcNodepool -ClusterName azps_test_cluster -ResourceGroupName azps_test_group -VnetId azps_vnet_arm_id -CustomLocationName azps_customlocation_arm_id -ControlPlaneEndpointHostIP azps_ip -KubernetesVersion "1.22.2"
```

Enable NfCsi driver in provisioned cluster. 

### Example 4: Enable SmbCsiDriver
```powershell
New-AzAksArcNodepool -ClusterName azps_test_cluster -ResourceGroupName azps_test_group -SmbCsiDriverEnabled
```

Enable SmbCsi driver in provisioned cluster. 

### Example 5: Enable azure hybrid benefit
```powershell
New-AzAksArcNodepool -ClusterName azps_test_cluster -ResourceGroupName azps_test_group -LicenseProfileAzureHybridBenefit
```

Enable Azure Hybrid User Benefits feature for a provisioned cluster.

### Example 6: Disable azure hybrid benefit
```powershell
New-AzAksArcNodepool -ClusterName azps_test_cluster -ResourceGroupName azps_test_group -LicenseProfileAzureHybridBenefit:$false
```

Disable Azure Hybrid User Benefits feature for a provisioned cluster.

### Example 7: Disable autoscaling
```powershell
New-AzAksArcNodepool -ClusterName azps_test_cluster -ResourceGroupName azps_test_group -EnableAutoScaling:$false
```

Disable autoscaling in provisioned cluster. 

### Example 8: Disable NfCsiDriver
```powershell
New-AzAksArcNodepool -ClusterName azps_test_cluster -ResourceGroupName azps_test_group -NfCsiDriverEnabled:$false
```

Disable NfCsi driver in provisioned cluster. 

### Example 9: Disable SmbCsiDriver
```powershell
New-AzAksArcNodepool -ClusterName azps_test_cluster -ResourceGroupName azps_test_group -SmbCsiDriverEnabled:$false
```

Disable SmbCsi driver in provisioned cluster. 


### Example 10: New aad admin GUIDS
```powershell
New-AzAksArcNodepool -ClusterName azps_test_cluster -ResourceGroupName azps_test_group -adminGroupObjectIDs @("2e00cb64-66d8-4c9c-92d8-6462caf99e33", "1b28ff4f-f7c5-4aaa-aa79-ba8b775ab443")
```

Update aad admin GUIDS. 







