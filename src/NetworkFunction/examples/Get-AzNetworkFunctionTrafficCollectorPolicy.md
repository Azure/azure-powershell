### Example 1: Get list of collector policies by atc name and resource group
```powershell
Get-AzNetworkFunctionTrafficCollectorPolicy -AzureTrafficCollectorName test -resourcegroup test
```

```output
[{
"name": "atc",
"id": "/subscriptions/subid/resourceGroups/rg1/providers/Microsoft.NetworkFunction/azureTrafficCollectors/atc/collectorPolicies/cp1",
"etag": "testEtag",
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
}]
```

This cmdlet gets list of traffic collector policies by atc name and resource group.
