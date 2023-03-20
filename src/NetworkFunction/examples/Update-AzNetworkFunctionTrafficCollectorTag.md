### Example 1: Updates a traffic collector tag
```powershell
Update-AzNetworkFunctionTrafficCollectorTag -azuretrafficcollectorname atc -resourcegroupname rg1 | Format-List
```

```output
Name              : atc
Etag              : cf0336a2-7454-4aa4-add9-1de3e2291143
Id                : /subscriptions/subid/resourceGroups/rg1/providers/Microsoft.NetworkFunction/azureTrafficCollectors/atc
Type              : Microsoft.NetworkFunction/azureTrafficCollectors
Location          : West US
Tags              : {
                        "key1": "value1",
                        "key2": "value2"
                    }
Properties        : {
                        "collectorPolicies": [],
                        "provisioningState": "Succeeded"
                    }
```

This cmdlet updates a traffic collector tag.