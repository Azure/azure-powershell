### Example 1: Delete express route authorization in private cloud
```powershell
PS C:\> Remove-AzVMwareExpressRouteAuthorization -PrivateCloudName azps_test_cloud -ResourceGroupName azps_test_group -Name azps_test_authorization

```

Delete express route authorization in private cloud

### Example 2: Delete express route authorization in private cloud
```powershell
PS C:\> Remove-AzVMwareExpressRouteAuthorization -InputObject "/subscriptions/ba75e79b-dd95-4025-9dbf-3a7ae8dff2b5/resourceGroups/azps_test_group/providers/Microsoft.AVS/privateClouds/azps_test_cloud/authorizations/azps_test_authorization

```

Delete express route authorization in private cloud