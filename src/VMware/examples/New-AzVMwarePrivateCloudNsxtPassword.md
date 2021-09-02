### Example 1: Rotate the NSX-T Manager password
```powershell
PS C:\> New-AzVMwarePrivateCloudNsxtPassword -ResourceGroupName azps_test_group -PrivateCloudName azps_test_cloud -PassThru

True
```

Rotate the NSX-T Manager password

### Example 2: Rotate the NSX-T Manager password
```powershell
PS C:\> New-AzVMwarePrivateCloudNsxtPassword -InputObject "/subscriptions/xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx/resourceGroups/azps_test_group/providers/Microsoft.AVS/privateClouds/azps_test_cloud" -PassThru

True
```

Rotate the NSX-T Manager password