### Example 1: Delete cluster in private cloud
```powershell
PS C:\> Remove-AzVMwareCluster -Name azps_test_cluster -PrivateCloudName azps_test_cloud -ResourceGroupName azps_test_group

```

Delete cluster in private cloud

### Example 2: Delete cluster in private cloud
```powershell
PS C:\> Remove-AzVMwareCluster -InputObject "/subscriptions/ba75e79b-dd95-4025-9dbf-3a7ae8dff2b5/resourceGroups/azps_test_group/providers/Microsoft.AVS/privateClouds/azps_test_cloud/clusters/azps_test_cluster"

```

Delete cluster in private cloud