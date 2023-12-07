### Example 1: Create an in-memory object for DataNetworkConfiguration.
```powershell
$ServiceResourceId = New-AzMobileNetworkServiceResourceIdObject -Id "/subscriptions/{subId}/resourceGroups/azps_test_group/providers/Microsoft.MobileNetwork/mobileNetworks/azps-mn/services/azps-mn-service"

New-AzMobileNetworkDataNetworkConfigurationObject -AllowedService $ServiceResourceId -DataNetworkId "/subscriptions/{subId}/resourceGroups/azps_test_group/providers/Microsoft.MobileNetwork/mobileNetworks/azps-mn/dataNetworks/azps-mn-datanetwork" -SessionAmbrDownlink "1 Gbps" -SessionAmbrUplink "500 Mbps" -FiveQi 9 -AllocationAndRetentionPriorityLevel 9 -DefaultSessionType 'IPv4' -MaximumNumberOfBufferedPacket 200 -PreemptionCapability 'NotPreempt' -PreemptionVulnerability 'Preemptable'
```

```output
AdditionalAllowedSessionType AllocationAndRetentionPriorityLevel DefaultSessionType FiveQi MaximumNumberOfBufferedPacket PreemptionCapability PreemptionVulnerability
---------------------------- ----------------------------------- ------------------ ------ ----------------------------- -------------------- -----------------------
                             9                                   IPv4               9      200                           NotPreempt           Preemptable
```

Create an in-memory object for DataNetworkConfiguration.