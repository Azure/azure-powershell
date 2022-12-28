### Example 1: Updates SIM group tags.
```powershell
Update-AzMobileNetworkSimGroup -SimGroupName azps-mn-simgroup -ResourceGroupName azps_test_group -Tag @{"abc"="123"}
```

```output
Location Name             ResourceGroupName ProvisioningState IdentityType
-------- ----             ----------------- ----------------- ------------
eastus   azps-mn-simgroup azps_test_group   Succeeded         UserAssigned
```

Updates SIM group tags.