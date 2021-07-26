### Example 1: List the admin credentials for the private cloud
```powershell
PS C:\> Get-AzVMwarePrivateCloudAdminCredential -PrivateCloudName azps_test_cloud -ResourceGroupName azps_test_group

NsxtUsername VcenterUsername
------------ ---------------
admin        cloudadmin@vsphere.local
```

List the admin credentials for the private cloud

### Example 2: List the admin credentials for the private cloud
```powershell
PS C:\> Get-AzVMwarePrivateCloudAdminCredential -InputObject "/subscriptions/ba75e79b-dd95-4025-9dbf-3a7ae8dff2b5/resourceGroups/azps_test_group/providers/Microsoft.AVS/privateClouds/azps_test_cloud"

NsxtUsername VcenterUsername
------------ ---------------
admin        cloudadmin@vsphere.local
```

List the admin credentials for the private cloud