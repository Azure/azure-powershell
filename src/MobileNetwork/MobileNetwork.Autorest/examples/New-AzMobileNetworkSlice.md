### Example 1: Creates or updates a network slice.
```powershell
New-AzMobileNetworkSlice -MobileNetworkName azps-mn -ResourceGroupName azps_test_group -SliceName azps-mn-slice -Location eastus -SnssaiSst 1 -SnssaiSd "1abcde"
```

```output
Location Name          ResourceGroupName ProvisioningState SnssaiSst SnssaiSd
-------- ----          ----------------- ----------------- --------- --------
eastus   azps-mn-slice azps_test_group   Succeeded         1         1abcde
```

Creates or updates a network slice.
Must be created in the same location as its parent mobile network.