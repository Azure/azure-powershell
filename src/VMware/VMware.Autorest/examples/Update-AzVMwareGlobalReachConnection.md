### Example 1: Update a global reach connection in a private cloud
```powershell
Update-AzVMwareGlobalReachConnection -Name azps_test_grc -PrivateCloudName azps_test_cloud -ResourceGroupName azps_test_group
```
```output
Name          Type                                               ResourceGroupName
----          ----                                               -----------------
azps_test_grc Microsoft.AVS/privateClouds/globalReachConnections azps_test_group
```

Update a global reach connection in a private cloud