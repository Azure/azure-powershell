### Example 1: Get the specified private link resource associated with the device update account.
```powershell
Get-AzDeviceUpdatePrivateLinkResource -AccountName azpstest-account -ResourceGroupName azpstest_gp
```

```output
Name         GroupId
----         -------
DeviceUpdate DeviceUpdate
```

Get the specified private link resource associated with the device update account.

### Example 2: Get the specified private link resource associated with the device update account and group id.
```powershell
Get-AzDeviceUpdatePrivateLinkResource -AccountName azpstest-account -ResourceGroupName azpstest_gp -GroupId DeviceUpdate
```

```output
Name         GroupId
----         -------
DeviceUpdate DeviceUpdate
```

Get the specified private link resource associated with the device update account and group id.