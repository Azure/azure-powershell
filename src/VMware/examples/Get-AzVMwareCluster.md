### Example 1: List clusters under resource group
```powershell
PS C:\> Get-AzVMwareCluster -PrivateCloudName azps_test_cloud -ResourceGroupName azps_test_group

Name              Type
----              ----
azps_test_cluster Microsoft.AVS/privateClouds/clusters
```

List clusters under resource group

### Example 2: Get cluster by name in a private cloud
```powershell
PS C:\> Get-AzVMwareCluster -Name azps_test_cluster -PrivateCloudName azps_test_cloud -ResourceGroupName azps_test_group

Name              Type
----              ----
azps_test_cluster Microsoft.AVS/privateClouds/clusters
```

Get cluster by name in a private cloud

### Example 3: Get cluster by resource id in a private cloud
```powershell
PS C:\> Get-AzVMwareCluster -InputObject "/subscriptions/xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx/resourceGroups/azps_test_group/providers/Microsoft.AVS/privateClouds/azps_test_cloud/clusters/azps_test_cluster"

Name              Type
----              ----
azps_test_cluster Microsoft.AVS/privateClouds/clusters
```

Get cluster by resource id in a private cloud