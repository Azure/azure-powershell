### Example 1: Delete authorization in private cloud
```powershell
PS C:\> Remove-AzVMwareAuthorization -PrivateCloudName azps_test_cloud -ResourceGroupName azps_test_group -Name azps_test_authorization

```

Delete authorization in private cloud

### Example 2: Delete authorization in private cloud
```powershell
PS C:\> Remove-AzVMwareAuthorization -InputObject "/subscriptions/xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx/resourceGroups/azps_test_group/providers/Microsoft.AVS/privateClouds/azps_test_cloud/authorizations/azps_test_authorization

```

Delete authorization in private cloud