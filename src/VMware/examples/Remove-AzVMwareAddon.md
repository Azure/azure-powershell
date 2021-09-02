### Example 1: Delete an addon in a private cloud
```powershell
PS C:\> Remove-AzVMwareAddon -AddonType vr -PrivateCloudName azps_test_cloud -ResourceGroupName azps_test_group

```

Delete an addon in a private cloud

### Example 2: Delete an addon by resource id in a private cloud
```powershell
PS C:\> Remove-AzVMwareAddon -InputObject "/subscriptions/xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx/resourceGroups/azps_test_group/providers/Microsoft.AVS/privateClouds/azps_test_cloud/addons/srm"

```

Delete an addon by resource id in a private cloud