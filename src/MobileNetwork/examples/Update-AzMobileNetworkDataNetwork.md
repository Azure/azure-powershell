### Example 1: Updates data network.
```powershell
Update-AzMobileNetworkDataNetwork -MobileNetworkName azps-mn -DataNetworkName azps-mn-datanetwork -ResourceGroupName azps_test_group -Tag @{"abc"="12"}
```

```output
Location Name                ResourceGroupName ProvisioningState
-------- ----                ----------------- -----------------
eastus   azps-mn-datanetwork azps_test_group   Succeeded
```

Updates data network.