### Example 1: Delete a global reach connection in a private cloud
```powershell
PS C:\> Remove-AzVMwareGlobalReachConnection -Name azps_test_grc -PrivateCloudName azps_test_cloud -ResourceGroupName azps_test_group

```

Delete a global reach connection in a private cloud

### Example 2: Delete a global reach connection in a private cloud
```powershell
PS C:\> Remove-AzVMwareGlobalReachConnection -InputObject "/subscriptions/ba75e79b-dd95-4025-9dbf-3a7ae8dff2b5/resourceGroups/azps_test_group/providers/Microsoft.AVS/privateClouds/azps_test_cloud/globalReachConnections/azps_test_grc"

```

Delete a global reach connection in a private cloud