### Example 1: List addon under resource group
```powershell
PS C:\> Get-AzVMwareAddon -PrivateCloudName azps_test_cloud -ResourceGroupName azps_test_group

Name Type                               ResourceGroupName
---- ----                               -----------------
srm  Microsoft.AVS/privateClouds/addons azps_test_group
vr   Microsoft.AVS/privateClouds/addons azps_test_group
```

List addon under resource group

### Example 2: Get an addon by name in a private cloud
```powershell
PS C:\> Get-AzVMwareAddon -AddonType vr -PrivateCloudName azps_test_cloud -ResourceGroupName azps_test_group

Name Type                               ResourceGroupName
---- ----                               -----------------
vr   Microsoft.AVS/privateClouds/addons azps_test_group
```

Get an addon by name in a private cloud