### Example 1: Create an ExpressRoute Circuit Authorization in a private cloud
```powershell
PS C:\> New-AzVMwareExpressRouteAuthorization -Name azps_test_authorization -PrivateCloudName azps_test_cloud -ResourceGroupName azps_test_group

Name                    Type
----                    ----
azps_test_authorization Microsoft.AVS/privateClouds/authorizations
```

Create an ExpressRoute Circuit Authorization in a private cloud