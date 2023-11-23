### Example 1: List global reach connection in a private cloud
```powershell
Get-AzVMwareGlobalReachConnection -PrivateCloudName azps_test_cloud -ResourceGroupName azps_test_group
```
```output
Name          Type                                               ResourceGroupName
----          ----                                               -----------------
azps_test_grc Microsoft.AVS/privateClouds/globalReachConnections azps_test_group
```

List global reach connection in a private cloud

### Example 2: Get a global reach connection by name in a private cloud
```powershell
Get-AzVMwareGlobalReachConnection -Name azps_test_grc -PrivateCloudName azps_test_cloud -ResourceGroupName azps_test_group
```
```output
Name          Type                                               ResourceGroupName
----          ----                                               -----------------
azps_test_grc Microsoft.AVS/privateClouds/globalReachConnections azps_test_group
```

Get a global reach connection by name in a private cloud