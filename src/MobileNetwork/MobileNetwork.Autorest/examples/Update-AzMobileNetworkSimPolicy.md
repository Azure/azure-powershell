### Example 1: Updates SIM policy.
```powershell
Update-AzMobileNetworkSimPolicy -MobileNetworkName azps-mn -SimPolicyName azps-mn-simpolicy -ResourceGroupName azps_test_group -Tag @{"abc"="123"}
```

```output
Location Name              ResourceGroupName ProvisioningState RegistrationTimer UeAmbrDownlink UeAmbrUplink
-------- ----              ----------------- ----------------- ----------------- -------------- ------------
eastus   azps-mn-simpolicy azps_test_group   Succeeded         3240              1 Gbps         500 Mbps
```

Updates SIM policy.