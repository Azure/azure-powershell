### Example 1: List information about the specified SIM policy by MobileNetwork Name.
```powershell
Get-AzMobileNetworkSimPolicy -MobileNetworkName azps-mn -ResourceGroupName azps_test_group
```

```output
Location Name              ResourceGroupName ProvisioningState RegistrationTimer UeAmbrDownlink UeAmbrUplink
-------- ----              ----------------- ----------------- ----------------- -------------- ------------
eastus   azps-mn-simpolicy azps_test_group   Succeeded         3240              1 Gbps         500 Mbps
```

List information about the specified SIM policy by MobileNetwork Name.

### Example 2: Get information about the specified SIM policy.
```powershell
Get-AzMobileNetworkSimPolicy -MobileNetworkName azps-mn -ResourceGroupName azps_test_group -Name azps-mn-simpolicy
```

```output
Location Name              ResourceGroupName ProvisioningState RegistrationTimer UeAmbrDownlink UeAmbrUplink
-------- ----              ----------------- ----------------- ----------------- -------------- ------------
eastus   azps-mn-simpolicy azps_test_group   Succeeded         3240              1 Gbps         500 Mbps
```

Get information about the specified SIM policy.