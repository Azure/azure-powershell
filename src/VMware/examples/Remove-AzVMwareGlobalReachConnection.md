### Example 1: Delete a global reach connection in a private cloud
```powershell
Remove-AzVMwareGlobalReachConnection -Name azps_test_grc -PrivateCloudName azps_test_cloud -ResourceGroupName azps_test_group

```

Delete a global reach connection in a private cloud

### Example 2: Delete a global reach connection in a private cloud
```powershell
Get-AzVMwareGlobalReachConnection -Name azps_test_grc -PrivateCloudName azps_test_cloud -ResourceGroupName azps_test_group | Remove-AzVMwareGlobalReachConnection

```

Delete a global reach connection in a private cloud