### Example 1: Creates or updates a SIM.
```powershell
$staticIp = New-AzMobileNetworkSimStaticIPPropertiesObject -StaticIPIpv4Address 10.0.0.20

New-AzMobileNetworkSim -GroupName azps-mn-simgroup -Name azps-mn-sim -ResourceGroupName azps_test_group  -InternationalMobileSubscriberIdentity 000000000000001 -AuthenticationKey 00112233445566778899AABBCCDDEEFF -DeviceType Mobile -IntegratedCircuitCardIdentifier 8900000000000000001 -OperatorKeyCode 00000000000000000000000000000001 -SimPolicyId "/subscriptions/{subId}/resourceGroups/azps_test_group/providers/Microsoft.MobileNetwork/mobileNetworks/azps-mn/simPolicies/azps-mn-simpolicy" -StaticIPConfiguration $staticIp
```

```output
Name        ResourceGroupName ProvisioningState
----        ----------------- -----------------
azps-mn-sim azps_test_group   Succeeded
```

Creates or updates a SIM.