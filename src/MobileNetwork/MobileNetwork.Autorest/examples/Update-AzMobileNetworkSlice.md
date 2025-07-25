### Example 1: Updates slice.
```powershell
Update-AzMobileNetworkSlice -MobileNetworkName azps-mn -ResourceGroupName azps_test_group -SliceName azps-mn-slice -Tag @{"abc"="123"} -SnssaiSst 1
```

```output
Location Name          ResourceGroupName ProvisioningState SnssaiSst SnssaiSd
-------- ----          ----------------- ----------------- --------- --------
eastus   azps-mn-slice azps_test_group   Succeeded         1         1abcde
```

Updates slice.