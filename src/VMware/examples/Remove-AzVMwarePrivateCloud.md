### Example 1: Delete private cloud
```powershell
Remove-AzVMwarePrivateCloud -ResourceGroupName azps_test_group -Name azps_test_cloud

```

Delete private cloud

### Example 2: Delete private cloud
```powershell
Get-AzVMwarePrivateCloud -ResourceGroupName azps_test_group -Name azps_test_cloud | Remove-AzVMwarePrivateCloud

```

Delete private cloud