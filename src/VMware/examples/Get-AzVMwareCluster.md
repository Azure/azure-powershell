### Example 1: List clusters under resource group
```powershell
Get-AzVMwareCluster -PrivateCloudName azps_test_cloud -ResourceGroupName azps_test_group
```
```output
Name              Type                                 ResourceGroupName
----              ----                                 -----------------
azps_test_cluster Microsoft.AVS/privateClouds/clusters azps_test_group
```

List clusters under resource group

### Example 2: Get cluster by name in a private cloud
```powershell
Get-AzVMwareCluster -Name azps_test_cluster -PrivateCloudName azps_test_cloud -ResourceGroupName azps_test_group
```
```output
Name              Type                                 ResourceGroupName
----              ----                                 -----------------
azps_test_cluster Microsoft.AVS/privateClouds/clusters azps_test_group
```

Get cluster by name in a private cloud