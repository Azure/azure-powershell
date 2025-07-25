### Example 1: List information about the specified service by MobileNetwork Name.
```powershell
Get-AzMobileNetworkService -MobileNetworkName azps-mn -ResourceGroupName azps_test_group
```

```output
Location Name            ResourceGroupName ProvisioningState Precedence MaximumBitRateDownlink MaximumBitRateUplink QoPolicyAllocationAndRetentionPriorityLevel QoPolicyFiveQi
-------- ----            ----------------- ----------------- ---------- ---------------------- -------------------- ------------------------------------------- --------------
eastus   azps-mn-service azps_test_group   Succeeded         0          1 Gbps                 500 Mbps             9                                           9
```

List information about the specified service by MobileNetwork Name.

### Example 2: Get information about the specified service.
```powershell
Get-AzMobileNetworkService -MobileNetworkName azps-mn -ResourceGroupName azps_test_group -Name azps-mn-service
```

```output
Location Name            ResourceGroupName ProvisioningState Precedence MaximumBitRateDownlink MaximumBitRateUplink QoPolicyAllocationAndRetentionPriorityLevel QoPolicyFiveQi
-------- ----            ----------------- ----------------- ---------- ---------------------- -------------------- ------------------------------------------- --------------
eastus   azps-mn-service azps_test_group   Succeeded         0          1 Gbps                 500 Mbps             9                                           9
```

Get information about the specified service.