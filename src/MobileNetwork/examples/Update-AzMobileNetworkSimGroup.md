### Example 1: Updates SIM group tags.
```powershell
Update-AzMobileNetworkSimGroup -SimGroupName azps-mn-simgroup -ResourceGroupName azps_test_group -Tag @{"abc"="123"}
```

```output
<<<<<<< HEAD
Location Name             ResourceGroupName ProvisioningState IdentityType
-------- ----             ----------------- ----------------- ------------
eastus   azps-mn-simgroup azps_test_group   Succeeded         UserAssigned
=======
Location Name             ResourceGroupName ProvisioningState
-------- ----             ----------------- -----------------
eastus   azps-mn-simgroup azps_test_group   Succeeded
>>>>>>> 97176e9029ae7684a4ab56b6bec6966b134d4f91
```

Updates SIM group tags.