### Example 1: Get cluster
```powershell
PS C:\> Get-AzVMwareCluster -Name azps_test_cluster -PrivateCloudName azps_test_cloud -ResourceGroupName azps_test_group

Name              Type
----              ----
azps_test_cluster Microsoft.AVS/privateClouds/clusters
```

Get cluster

### Example 2: Get cluster
```powershell
PS C:\> Get-AzVMwareCluster -InputObject "/subscriptions/ba75e79b-dd95-4025-9dbf-3a7ae8dff2b5/resourceGroups/azps_test_group/providers/Microsoft.AVS/privateClouds/azps_test_cloud/clusters/azps_test_cluster"

Name              Type
----              ----
azps_test_cluster Microsoft.AVS/privateClouds/clusters
```

Get cluster

### Example 3: List clusters
```powershell
PS C:\> Get-AzVMwareCluster -PrivateCloudName azps_test_cloud -ResourceGroupName azps_test_group

Name              Type
----              ----
azps_test_cluster Microsoft.AVS/privateClouds/clusters
```

List clusters