### Example 1: Delete a addon in a private cloud
```powershell
PS C:\> Remove-AzVMwareAddon -Name vr -PrivateCloudName azps_test_cloud -ResourceGroupName azps_test_group

```

Delete a addon in a private cloud

### Example 2: Delete a addon
```powershell
PS C:\> Remove-AzVMwareAddon -InputObject "/subscriptions/ba75e79b-dd95-4025-9dbf-3a7ae8dff2b5/resourceGroups/azps_test_group/providers/Microsoft.AVS/privateClouds/azps_test_cloud/addons/srm"

```

Delete a addon