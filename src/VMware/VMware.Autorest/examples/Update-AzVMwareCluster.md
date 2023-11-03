### Example 1: Update cluster size by name
```powershell
Update-AzVMwareCluster -Name azps_test_cluster -PrivateCloudName azps_test_cloud -ResourceGroupName azps_test_group -ClusterSize 4
```
```output
Name              Type                                 ResourceGroupName
----              ----                                 -----------------
azps_test_cluster Microsoft.AVS/privateClouds/clusters azps_test_group
```

Update cluster size by name

### Example 2: Update cluster size
```powershell
Get-AzVMwareCluster -Name azps_test_cluster -PrivateCloudName azps_test_cloud -ResourceGroupName azps_test_group | Update-AzVMwareCluster -ClusterSize 4
```
```output
Name              Type                                 ResourceGroupName
----              ----                                 -----------------
azps_test_cluster Microsoft.AVS/privateClouds/clusters azps_test_group
```

Update cluster size