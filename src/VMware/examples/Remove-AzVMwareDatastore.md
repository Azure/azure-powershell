### Example 1: Delete a datastore in a private cloud cluster.
```powershell
Remove-AzVMwareDatastore -ClusterName azps_test_cluster -Name azps_test_datastore -PrivateCloudName azps_test_cloud -ResourceGroupName azps_test_group
```

Delete a datastore in a private cloud cluster.

### Example 2: Delete a datastore in a private cloud cluster.
```powershell
Get-AzVMwareDatastore -ClusterName azps_test_cluster -Name azps_test_datastore -PrivateCloudName azps_test_cloud -ResourceGroupName azps_test_group | Remove-AzVMwareDatastore
```

Delete a datastore in a private cloud cluster.