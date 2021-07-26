### Example 1: List global reach connection in a private cloud
```powershell
PS C:\> Get-AzVMwareGlobalReachConnection -PrivateCloudName azps_test_cloud -ResourceGroupName azps_test_group

Name          Type
----          ----
azps_test_grc Microsoft.AVS/privateClouds/globalReachConnections
```

List global reach connection in a private cloud

### Example 2: Get a global reach connection by name in a private cloud
```powershell
PS C:\>  Get-AzVMwareGlobalReachConnection -Name azps_test_grc -PrivateCloudName azps_test_cloud -ResourceGroupName azps_test_group

Name          Type
----          ----
azps_test_grc Microsoft.AVS/privateClouds/globalReachConnections
```

Get a global reach connection by name in a private cloud

### Example 3: Get a global reach connection by InputObject in a private cloud
```powershell
PS C:\>  Get-AzVMwareGlobalReachConnection -InputObject "/subscriptions/ba75e79b-dd95-4025-9dbf-3a7ae8dff2b5/resourceGroups/azps_test_group/providers/Microsoft.AVS/privateClouds/azps_test_cloud/globalReachConnections/azps_test_grc"

Name          Type
----          ----
azps_test_grc Microsoft.AVS/privateClouds/globalReachConnections
```

Get a global reach connection by InputObject in a private cloud