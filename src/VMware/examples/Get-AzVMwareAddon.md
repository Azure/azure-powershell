### Example 1: List addon under resource group
```powershell
PS C:\> Get-AzVMwareAddon -PrivateCloudName azps_test_cloud -ResourceGroupName azps_test_group

Name Type
---- ----
srm  Microsoft.AVS/privateClouds/addons
vr   Microsoft.AVS/privateClouds/addons
```

List addon under resource group

### Example 2: Get an addon by name in a private cloud
```powershell
PS C:\> Get-AzVMwareAddon -AddonType vr -PrivateCloudName azps_test_cloud -ResourceGroupName azps_test_group

Name Type
---- ----
vr   Microsoft.AVS/privateClouds/addons
```

Get an addon by name in a private cloud

### Example 3: Get an addon by resource id in a private cloud
```powershell
PS C:\> Get-AzVMwareAddon -InputObject "/subscriptions/xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx/resourceGroups/azps_test_group/providers/Microsoft.AVS/privateClouds/azps_test_cloud/addons/vr"

Name Type
---- ----
vr   Microsoft.AVS/privateClouds/addons
```

Get an addon by resource id in a private cloud