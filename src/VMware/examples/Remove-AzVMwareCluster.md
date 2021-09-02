### Example 1: Delete cluster in private cloud
```powershell
PS C:\> Remove-AzVMwareCluster -Name azps_test_cluster -PrivateCloudName azps_test_cloud -ResourceGroupName azps_test_group

```

Delete cluster in private cloud

### Example 2: Delete cluster by resource id in private cloud
```powershell
PS C:\> Remove-AzVMwareCluster -InputObject "/subscriptions/xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx/resourceGroups/azps_test_group/providers/Microsoft.AVS/privateClouds/azps_test_cloud/clusters/azps_test_cluster"

```

Delete cluster by resource id in private cloud