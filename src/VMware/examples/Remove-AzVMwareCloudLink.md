### Example 1: Delete a cloud link
```powershell
PS C:\> Remove-AzVMwareCloudLink -Name azps_test_cloudlink -PrivateCloudName azps_test_cloud -ResourceGroupName azps_test_group

```

Delete a cloud link

### Example 2: Delete a cloud link by resource id
```powershell
PS C:\> Remove-AzVMwareCloudLink -InputObject "/subscriptions/xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx/resourceGroups/azps_test_group/providers/Microsoft.AVS/privateClouds/azps_test_cloud/cloudLinks/azps_test_cloudlink"

```

Delete a cloud link by resource id