### Example 1: Update an ExpressRoute Circuit Authorization in a private cloud
```powershell
Update-AzVMwareAuthorization -Name azps_test_authorization -PrivateCloudName azps_test_cloud -ResourceGroupName azps_test_group
```
```output
ExpressRouteAuthorizationId : ExpressRouteURI
ExpressRouteId              : ExpressRouteId
Id                          : Id
Key                         : GUID
Name                        : azps_test_authorization
ProvisioningState           : Succeeded
ResourceGroupName           : azps_test_group
Type                        : Microsoft.AVS/privateClouds/authorizations
```

Update an ExpressRoute Circuit Authorization in a private cloud