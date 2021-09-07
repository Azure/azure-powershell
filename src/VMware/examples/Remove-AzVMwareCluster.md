### Example 1: Delete cluster in private cloud
```powershell
PS C:\> Remove-AzVMwareCluster -Name azps_test_cluster -PrivateCloudName azps_test_cloud -ResourceGroupName azps_test_group

```

Delete cluster in private cloud

### Example 2: Delete cluster in private cloud
```powershell
PS C:\> Get-AzVMwareCluster -Name azps_test_cluster -PrivateCloudName azps_test_cloud -ResourceGroupName azps_test_group | Remove-AzVMwareCluster

```

Delete cluster in private cloud