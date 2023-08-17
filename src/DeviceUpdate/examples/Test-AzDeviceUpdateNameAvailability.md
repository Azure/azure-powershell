### Example 1: Checks ADU resource name availability.
```powershell
$data = New-AzDeviceUpdateCheckNameAvailabilityRequestObject -Name azpstest-account -Type "Microsoft.DeviceUpdate/accounts"
Test-AzDeviceUpdateNameAvailability -Request $data
```

```output
Message NameAvailable Reason
------- ------------- ------
        True
```

Checks ADU resource name availability.

### Example 2: Checks ADU resource name availability.
```powershell
Test-AzDeviceUpdateNameAvailability -Name azpstest-account -Type "Microsoft.DeviceUpdate/accounts"
```

```output
Message NameAvailable Reason
------- ------------- ------
        True
```

Checks ADU resource name availability.