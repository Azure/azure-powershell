### Example 1: Updates a SIM.
```powershell
Update-AzMobileNetworkSim -GroupName azps-mn-simgroup -Name azps-mn-sim -ResourceGroupName azps_test_group -AuthenticationKey 00112233445566778899AABBCCDDEEFF -DeviceType Mobile -IntegratedCircuitCardIdentifier 8900000000000000001 -OperatorKeyCode 00000000000000000000000000000001 -SimPolicyId "/subscriptions/{subId}/resourceGroups/azps_test_group/providers/Microsoft.MobileNetwork/mobileNetworks/azps-mn/simPolicies/azps-mn-simpolicy"
```

```output
Name        ResourceGroupName ProvisioningState
----        ----------------- -----------------
azps-mn-sim azps_test_group   Succeeded
```

This command updates a SIM.