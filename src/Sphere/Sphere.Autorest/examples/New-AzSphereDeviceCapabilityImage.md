### Example 1: Generates the capability image for the device.
```powershell
New-AzSphereDeviceCapabilityImage -ResourceGroupName group-test -CatalogName test2024 -DeviceGroupName testdevicegroup2 -ProductName product2024 -DeviceName ****** -Capability 'ApplicationDevelopment' | Format-List
```

```output
Image : ************
```

This command generates the capability image for specified device.

