### Example 1: Delete private cloud
```powershell
PS C:\> Remove-AzVMwarePrivateCloud -ResourceGroupName azps_test_group -Name azps_test_cloud

```

Delete private cloud

### Example 2: Delete private cloud
```powershell
PS C:\> Get-AzVMwarePrivateCloud -ResourceGroupName azps_test_group -Name azps_test_cloud | Remove-AzVMwarePrivateCloud

```

Delete private cloud