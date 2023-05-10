### Example 1: Updates SIM group.
```powershell
Update-AzMobileNetworkSimGroup -SimGroupName azps-mn-simgroup -ResourceGroupName azps_test_group -Tag @{"abc"="123"}
```

```output
Location Name             ResourceGroupName ProvisioningState
-------- ----             ----------------- -----------------
eastus   azps-mn-simgroup azps_test_group   Succeeded
```

Updates SIM group.