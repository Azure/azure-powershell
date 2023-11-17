### Example 1: Creates or updates a data network.
```powershell
New-AzMobileNetworkDataNetwork -MobileNetworkName azps-mn -Name azps-mn-datanetwork -ResourceGroupName azps_test_group -Location eastus
```

```output
Location Name                ResourceGroupName ProvisioningState
-------- ----                ----------------- -----------------
eastus   azps-mn-datanetwork azps_test_group   Succeeded
```

Creates or updates a data network.
Must be created in the same location as its parent mobile network.