### Example 1: Deletes the specified private endpoint connection associated with the device update account.
```powershell
Remove-AzDeviceUpdatePrivateEndpointConnection -AccountName azpstest-account -Name azpstest-privateendpoint -ResourceGroupName azpstest_gp
```

Deletes the specified private endpoint connection associated with the device update account.

### Example 2: Deletes the specified private endpoint connection associated with the device update account.
```powershell
Get-AzDeviceUpdatePrivateEndpointConnection -AccountName azpstest-account -ResourceGroupName azpstest_gp | Remove-AzDeviceUpdatePrivateEndpointConnection
```

Deletes the specified private endpoint connection associated with the device update account.