### Example 1: Create a global reach connection in a private cloud
```powershell
New-AzVMwareGlobalReachConnection -Name azps_test_grc -PrivateCloudName azps_test_cloud -ResourceGroupName azps_test_group -AuthorizationKey "df530ffb-5a57-4437-a3eb-08e4c73ce011" -PeerExpressRouteResourceId "/subscriptions/xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx/resourceGroups/tnt16-cust-mp01-mock01/providers/Microsoft.Network/expressRouteCircuits/tnt16-cust-mp01-mock01-er"
```
```output
Name          Type                                               ResourceGroupName
----          ----                                               -----------------
azps_test_grc Microsoft.AVS/privateClouds/globalReachConnections azps_test_group
```

Create a global reach connection in a private cloud