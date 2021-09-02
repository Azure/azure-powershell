### Example 1: Get the admin credentials for the private cloud
```powershell
PS C:\> Get-AzVMwarePrivateCloudAdminCredential -PrivateCloudName azps_test_cloud -ResourceGroupName azps_test_group

NsxtUsername VcenterUsername
------------ ---------------
admin        cloudadmin@vsphere.local
```

Get the admin credentials for the private cloud

### Example 2: Get the admin credentials by resource id for the private cloud
```powershell
PS C:\> Get-AzVMwarePrivateCloudAdminCredential -InputObject "/subscriptions/xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx/resourceGroups/azps_test_group/providers/Microsoft.AVS/privateClouds/azps_test_cloud"

NsxtUsername VcenterUsername
------------ ---------------
admin        cloudadmin@vsphere.local
```

Get the admin credentials by resource id for the private cloud