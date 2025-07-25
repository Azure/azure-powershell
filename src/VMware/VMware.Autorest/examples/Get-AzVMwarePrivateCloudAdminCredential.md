### Example 1: Get the admin credentials for the private cloud
```powershell
Get-AzVMwarePrivateCloudAdminCredential -PrivateCloudName azps_test_cloud -ResourceGroupName azps_test_group
```
```output
NsxtUsername VcenterUsername
------------ ---------------
admin        cloudadmin@vsphere.local
```

Get the admin credentials for the private cloud