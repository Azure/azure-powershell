### Example 1: Create an in-memory object for SliceConfiguration.
```powershell
$ServiceResourceId = New-AzMobileNetworkServiceResourceIdObject -Id "/subscriptions/{subId}/resourceGroups/azps_test_group/providers/Microsoft.MobileNetwork/mobileNetworks/azps-mn/services/azps-mn-service"

$DataNetworkConfiguration = New-AzMobileNetworkDataNetworkConfigurationObject -AllowedService $ServiceResourceId -DataNetworkId "/subscriptions/{subId}/resourceGroups/azps_test_group/providers/Microsoft.MobileNetwork/mobileNetworks/azps-mn/dataNetworks/azps-mn-datanetwork" -SessionAmbrDownlink "1 Gbps" -SessionAmbrUplink "500 Mbps" -FiveQi 9 -AllocationAndRetentionPriorityLevel 9 -DefaultSessionType 'IPv4' -MaximumNumberOfBufferedPacket 200 -PreemptionCapability 'NotPreempt' -PreemptionVulnerability 'Preemptable'

<<<<<<< HEAD
New-AzMobileNetworkSliceConfigurationObject -DataNetworkConfiguration $DataNetworkConfiguration -DefaultDataNetworkId "/subscriptions/{subId}/resourceGroups/azps_test_group/providers/Microsoft.MobileNetwork/mobileNetworks/azps-mn/dataNetworks/azps-mn-datanetwork" -SlouseId "/subscriptions/{subId}/resourceGroups/azps_test_group/providers/Microsoft.MobileNetwork/mobileNetworks/azps-mn/slices/azps-mn-slice"
=======
New-AzMobileNetworkSliceConfigurationObject -DataNetworkConfiguration $DataNetworkConfiguration -DefaultDataNetworkId "/subscriptions/{subId}/resourceGroups/azps_test_group/providers/Microsoft.MobileNetwork/mobileNetworks/azps-mn/dataNetworks/azps-mn-datanetwork" -SliceId "/subscriptions/{subId}/resourceGroups/azps_test_group/providers/Microsoft.MobileNetwork/mobileNetworks/azps-mn/slices/azps-mn-slice"
>>>>>>> 97176e9029ae7684a4ab56b6bec6966b134d4f91
```

```output
DataNetworkConfiguration
------------------------
{{…
```

Create an in-memory object for SliceConfiguration.