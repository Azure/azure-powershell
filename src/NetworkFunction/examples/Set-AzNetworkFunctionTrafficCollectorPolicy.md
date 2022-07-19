### Example 1: Update a traffic collector policy
```powershell
Set-AzNetworkFunctionTrafficCollectorPolicy -collectorpolicyname cp1 -azuretrafficcollectorname -atc -resourcegroup rg1
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

This cmdlet updates a traffic collector policy.
