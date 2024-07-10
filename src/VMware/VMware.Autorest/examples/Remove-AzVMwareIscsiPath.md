### Example 1: Delete a IscsiPath in a private cloud
```powershell
Remove-AzVMwareIscsiPath -PrivateCloudName azps_test_cloud -ResourceGroupName azps_test_group
```

Delete a IscsiPath in a private cloud

### Example 2: Delete a datastore in a private cloud cluster.
```powershell
Get-AzVMwareIscsiPath -PrivateCloudName azps_test_cloud -ResourceGroupName azps_test_group | Remove-AzVMwareIscsiPath
```

Delete a IscsiPath in a private cloud