### Example 1: Creates or updates Account.
```powershell
$privateEndpointConnection = New-AzDeviceUpdatePrivateEndpointConnectionObject -PrivateLinkServiceConnectionStateDescription "Description: Approved" -PrivateLinkServiceConnectionStateStatus 'Approved'
New-AzDeviceUpdateAccount -Name azpstest-account -ResourceGroupName azpstest_gp -Location eastus -IdentityType 'SystemAssigned' -PrivateEndpointConnection $privateEndpointConnection -PublicNetworkAccess 'Enabled' -Sku 'Standard'
```

```output
Name             Location Sku      ResourceGroupName
----             -------- ---      -----------------
azpstest-account eastus   Standard azpstest_gp
```

Creates or updates Account.