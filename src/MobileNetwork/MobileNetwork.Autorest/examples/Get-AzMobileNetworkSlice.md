### Example 1: List information about the specified network slice by MobileNetwork Name.
```powershell
Get-AzMobileNetworkSlice -MobileNetworkName azps-mn -ResourceGroupName azps_test_group
```

```output
Location Name          ResourceGroupName ProvisioningState SnssaiSst SnssaiSd
-------- ----          ----------------- ----------------- --------- --------
eastus   azps-mn-slice azps_test_group   Succeeded         1         1abcde
```

List information about the specified network slice by MobileNetwork Name.

### Example 2: Get information about the specified network slice.
```powershell
Get-AzMobileNetworkSlice -MobileNetworkName azps-mn -ResourceGroupName azps_test_group -SliceName azps-mn-slice
```

```output
Location Name          ResourceGroupName ProvisioningState SnssaiSst SnssaiSd
-------- ----          ----------------- ----------------- --------- --------
eastus   azps-mn-slice azps_test_group   Succeeded         1         1abcde
```

Get information about the specified network slice.