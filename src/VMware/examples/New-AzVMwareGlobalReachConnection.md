### Example 1: Create a global reach connection in a private cloud
```powershell
PS C:\> New-AzVMwareGlobalReachConnection -Name azps_test_grc -PrivateCloudName azps_test_cloud -ResourceGroupName azps_test_group -AuthorizationKey "df530ffb-5a57-4437-a3eb-08e4c73ce011" -PeerExpressRouteResourceId "/subscriptions/7f1fae41-7708-4fa4-89b3-f6552cad2fc1/resourceGroups/tnt16-cust-mp01-mock01/providers/Microsoft.Network/expressRouteCircuits/tnt16-cust-mp01-mock01-er"

Name          Type
----          ----
azps_test_grc Microsoft.AVS/privateClouds/globalReachConnections
```

Create a global reach connection in a private cloud