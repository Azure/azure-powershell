### Example 1: Delete authorization in private cloud
```powershell
PS C:\> Remove-AzVMwareAuthorization -PrivateCloudName azps_test_cloud -ResourceGroupName azps_test_group -Name azps_test_authorization

```

Delete authorization in private cloud

### Example 2: Delete authorization in private cloud
```powershell
PS C:\> Get-AzVMwareAuthorization -PrivateCloudName azps_test_cloud -ResourceGroupName azps_test_group -Name azps_test_authorization | Remove-AzVMwareAuthorization

```

Delete authorization in private cloud