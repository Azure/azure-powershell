### Example 1: Updates a traffic collector tag
```powershell
Update-AzNetworkFunctionTrafficCollectorTag -azuretrafficcollectorname atc -resourcegroup rg1
```

```output
{
    "name": "atc",
    "id": "/subscriptions/subid/resourceGroups/rg1/providers/Microsoft.NetworkFunction/azureTrafficCollectors/atc",
    "type": "Microsoft.NetworkFunction/azureTrafficCollectors",
    "etag": "test",
    "location": "West US",
    "tags": {
        "key1": "value1",
        "key2": "value2"
    },
    "properties": {
        "collectorPolicies": [],
        "provisioningState": "Succeeded"
    }
}
```

This cmdlet updates a traffic collector tag.