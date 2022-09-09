### Example 1: Update the state of specified private endpoint connection associated with the device update account.
```powershell
New-AzDeviceUpdatePrivateEndpointConnection -AccountName azpstest-account -Name azpstest-privateendpoint -ResourceGroupName azpstest_gp -PrivateLinkServiceConnectionStateDescription "Description: Approved" -PrivateLinkServiceConnectionStateStatus 'Approved'
```

```output
Name                     ProvisioningState ResourceGroupName PrivateLinkServiceConnectionStateStatus
----                     ----------------- ----------------- ---------------------------------------
azpstest-privateendpoint Succeeded         azpstest_gp       Approved
```

Update the state of specified private endpoint connection associated with the device update account.