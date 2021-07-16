### Example 1: Delete cloud link
```powershell
PS C:\> Remove-AzVMwareCloudLink -Name azps_test_cloudlink -PrivateCloudName azps_test_cloud -ResourceGroupName azps_test_group

```

Delete cloud link

### Example 2: Delete cloud link
```powershell
PS C:\> Remove-AzVMwareCloudLink -InputObject "/subscriptions/ba75e79b-dd95-4025-9dbf-3a7ae8dff2b5/resourceGroups/azps_test_group/providers/Microsoft.AVS/privateClouds/azps_test_cloud/cloudLinks/azps_test_cloudlink"

```

Delete cloud link