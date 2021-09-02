### Example 1: Update cluster size by name
```powershell
PS C:\> Update-AzVMwareCluster -Name azps_test_cluster -PrivateCloudName azps_test_cloud -ResourceGroupName azps_test_group -ClusterSize 4

Name              Type
----              ----
azps_test_cluster Microsoft.AVS/privateClouds/clusters
```

Update cluster size by name

### Example 2: Update cluster size by resource id
```powershell
PS C:\> Update-AzVMwareCluster -InputObject "/subscriptions/xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx/resourceGroups/azps_test_group/providers/Microsoft.AVS/privateClouds/azps_test_cloud/clusters/azps_test_cluster" -ClusterSize 4

Name              Type
----              ----
azps_test_cluster Microsoft.AVS/privateClouds/clusters
```

Update cluster size by resource id