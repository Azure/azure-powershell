### Example 1: Delete an addon in a private cloud
```powershell
PS C:\> Remove-AzVMwareAddon -AddonType vr -PrivateCloudName azps_test_cloud -ResourceGroupName azps_test_group

```

Delete an addon in a private cloud

### Example 2: Delete an addon in a private cloud
```powershell
PS C:\> Get-AzVMwareAddon -AddonType vr -PrivateCloudName azps_test_cloud -ResourceGroupName azps_test_group | Remove-AzVMwareAddon

```

Delete an addon in a private cloud