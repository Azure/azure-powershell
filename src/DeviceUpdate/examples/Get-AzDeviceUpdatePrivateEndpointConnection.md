### Example 1: Get the specified private endpoint connection associated with the device update account.
```powershell
Get-AzDeviceUpdatePrivateEndpointConnection -AccountName azpstest-account -ResourceGroupName azpstest_gp
```

```output
Name                     ProvisioningState ResourceGroupName PrivateLinkServiceConnectionStateStatus
----                     ----------------- ----------------- ---------------------------------------
azpstest-privateendpoint Succeeded         azpstest_gp       Approved
```

Get the specified private endpoint connection associated with the device update account.

### Example 2: Get the specified private endpoint connection associated with the device update account and private endpoint.
```powershell
Get-AzDeviceUpdatePrivateEndpointConnection -AccountName azpstest-account -ResourceGroupName azpstest_gp -Name azpstest-privateendpoint
```

```output
Name                     ProvisioningState ResourceGroupName PrivateLinkServiceConnectionStateStatus
----                     ----------------- ----------------- ---------------------------------------
azpstest-privateendpoint Succeeded         azpstest_gp       Approved
```

Get the specified private endpoint connection associated with the device update account and private endpoint.