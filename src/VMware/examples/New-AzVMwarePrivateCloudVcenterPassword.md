### Example 1: Rotate the vCenter password
```powershell
PS C:\> New-AzVMwarePrivateCloudVcenterPassword -ResourceGroupName azps_test_group -PrivateCloudName azps_test_cloud -PassThru

True
```

Rotate the vCenter password

### Example 2: Rotate the vCenter password by resource id
```powershell
PS C:\> New-AzVMwarePrivateCloudVcenterPassword -InputObject "/subscriptions/xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx/resourceGroups/azps_test_group/providers/Microsoft.AVS/privateClouds/azps_test_cloud" -PassThru

True
```

Rotate the vCenter password by resource id