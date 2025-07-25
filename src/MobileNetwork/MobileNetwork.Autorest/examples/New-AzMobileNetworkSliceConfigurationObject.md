### Example 1: Create an in-memory object for SliceConfiguration.
```powershell
$ServiceResourceId = New-AzMobileNetworkServiceResourceIdObject -Id "/subscriptions/{subId}/resourceGroups/azps_test_group/providers/Microsoft.MobileNetwork/mobileNetworks/azps-mn/services/azps-mn-service"

$DataNetworkConfiguration = New-AzMobileNetworkDataNetworkConfigurationObject -AllowedService $ServiceResourceId -DataNetworkId "/subscriptions/{subId}/resourceGroups/azps_test_group/providers/Microsoft.MobileNetwork/mobileNetworks/azps-mn/dataNetworks/azps-mn-datanetwork" -SessionAmbrDownlink "1 Gbps" -SessionAmbrUplink "500 Mbps" -FiveQi 9 -AllocationAndRetentionPriorityLevel 9 -DefaultSessionType 'IPv4' -MaximumNumberOfBufferedPacket 200 -PreemptionCapability 'NotPreempt' -PreemptionVulnerability 'Preemptable'

New-AzMobileNetworkSliceConfigurationObject -DataNetworkConfiguration $DataNetworkConfiguration -DefaultDataNetworkId "/subscriptions/{subId}/resourceGroups/azps_test_group/providers/Microsoft.MobileNetwork/mobileNetworks/azps-mn/dataNetworks/azps-mn-datanetwork" -SliceId "/subscriptions/{subId}/resourceGroups/azps_test_group/providers/Microsoft.MobileNetwork/mobileNetworks/azps-mn/slices/azps-mn-slice"
```

```output
DataNetworkConfiguration
------------------------
{{…
```

Create an in-memory object for SliceConfiguration.