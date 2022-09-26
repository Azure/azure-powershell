### Example 1: Delete a cloud link
```powershell
Remove-AzVMwareCloudLink -Name azps_test_cloudlink -PrivateCloudName azps_test_cloud -ResourceGroupName azps_test_group

```

Delete a cloud link

### Example 2: Delete a cloud link
```powershell
Get-AzVMwareCloudLink -PrivateCloudName azps_test_cloud -ResourceGroupName azps_test_group -Name azps_test_cloudlink | Remove-AzVMwareCloudLink

```

Delete a cloud link