### Example 1: Updates a traffic collector tag
```powershell
Update-AzNetworkFunctionCollectorPolicyTag -collectorpolicyname cp1 -azuretrafficcollectorname atc -resourcegroupname rg1 | Format-List
```

```output
Name              : cp1
Etag              : 72090554-7e3b-43f2-80ad-99a9020dcb11
Id                : /subscriptions/subid/resourceGroups/rg1/providers/Microsoft.NetworkFunction/azureTrafficCollectors/atc/collectorPolicies/cp1
Type              : Microsoft.NetworkFunction/azureTrafficCollectors/collectorPolicies
Location          : West US
Tags              : {
                        "key1": "value1",
                        "key2": "value2"
                    }
Properties        : {
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
```

This cmdlet updates a collector policy tag.