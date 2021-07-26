### Example 1: Rotate the vCenter password
```powershell
PS C:\> New-AzVMwarePrivateCloudVcenterPassword -ResourceGroupName azps_test_group -PrivateCloudName azps_test_cloud -PassThru

True
```

Rotate the vCenter password

### Example 2: Rotate the vCenter password
```powershell
PS C:\> New-AzVMwarePrivateCloudVcenterPassword -InputObject "/subscriptions/ba75e79b-dd95-4025-9dbf-3a7ae8dff2b5/resourceGroups/azps_test_group/providers/Microsoft.AVS/privateClouds/azps_test_cloud"

True
```

Rotate the vCenter password