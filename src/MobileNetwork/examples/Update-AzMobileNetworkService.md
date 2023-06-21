### Example 1: Updates service.
```powershell
Update-AzMobileNetworkService -MobileNetworkName azps-mn -ServiceName azps-mn-service -ResourceGroupName azps_test_group -Tag @{"abc"="123"} -ServicePrecedence 0
```

```output
Location Name            ResourceGroupName ProvisioningState Precedence MaximumBitRateDownlink MaximumBitRateUplink QoPolicyAllocationAndRetentionPriorityLevel QoPolicyFiveQi
-------- ----            ----------------- ----------------- ---------- ---------------------- -------------------- ------------------------------------------- --------------
eastus   azps-mn-service azps_test_group   Succeeded         0          1 Gbps                 500 Mbps             9                                           9
```

Updates service.