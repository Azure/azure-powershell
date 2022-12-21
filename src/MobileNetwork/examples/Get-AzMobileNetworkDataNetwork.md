### Example 1: List information about the specified data network by MobileNetwork Name.
```powershell
Get-AzMobileNetworkDataNetwork -MobileNetworkName azps-mn -ResourceGroupName azps_test_group
```

```output
Location Name                ResourceGroupName ProvisioningState
-------- ----                ----------------- -----------------
eastus   azps-mn-datanetwork azps_test_group   Succeeded
```

List information about the specified data network by MobileNetwork Name.

### Example 2: Get information about the specified data network.
```powershell
Get-AzMobileNetworkDataNetwork -MobileNetworkName azps-mn -ResourceGroupName azps_test_group -Name azps-mn-datanetwork
```

```output
Location Name                ResourceGroupName ProvisioningState
-------- ----                ----------------- -----------------
eastus   azps-mn-datanetwork azps_test_group   Succeeded
```

Get information about the specified data network.