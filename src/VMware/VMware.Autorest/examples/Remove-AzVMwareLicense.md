### Example 1: Remove a VMware license
```powershell
Remove-AzVMwareLicense -PrivateCloudName azps_test_cloud -ResourceGroupName azps_test_group
```

Removes the VMware license from the specified private cloud and resource group.

### Example 2: Remove a VMware license
```powershell
Get-AzVMwareLicense -PrivateCloudName azps_test_cloud -ResourceGroupName azps_test_group | Remove-AzVMwareLicense
```

Removes the VMware license from the specified private cloud and resource group.