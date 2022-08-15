### Example 1: Create a new traffic collector policy
```powershell
New-AzNetworkFunctionCollectorPolicy -collectorpolicyname cp1 -azuretrafficcollectorname atc -resourcegroupname rg1 -location eastus
```

```output
{
    "name": "cp1",
    "id": "/subscriptions/subid/resourceGroups/rg1/providers/Microsoft.NetworkFunction/AzureTrafficCollector/atc/collectorPolicies/cp1",
    "etag": "test",
    "type": "Microsoft.NetworkFunction/azureTrafficCollectors/collectorPolicies",
    "properties": {
        "ingestionPolicy": {
        "ingestionType": "IPFIX",
        "ingestionSources": [
            {
            "resourceId": "/subscriptions/subid/resourceGroups/rg1/providers/Microsoft.Network/expressRouteCircuits/circuitName",
            "sourceType": "Resource"
            }
        ]
        },
        "emissionPolicies": [
        {
            "emissionType": "IPFIX",
            "emissionDestinations": [
            {
                "destinationType": "AzureMonitor"
            }
            ]
        }
        ],
        "provisioningState": "Succeeded"
    }
    }
}
```

This cmdlet creates a new traffic collector policy.