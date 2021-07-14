### Example 1: Get cluster
```powershell
PS C:\> Get-AzVMwareCluster -Name azps_test_cluster -PrivateCloudName azps_test_cloud -ResourceGroupName azps_test_group

Name              Type
----              ----
azps_test_cluster Microsoft.AVS/privateClouds/clusters
```

Get cluster

### Example 2: List clusters
```powershell
PS C:\> Get-AzVMwareCluster -PrivateCloudName azps_test_cloud -ResourceGroupName azps_test_group

Name              Type
----              ----
azps_test_cluster Microsoft.AVS/privateClouds/clusters
```

List clusters