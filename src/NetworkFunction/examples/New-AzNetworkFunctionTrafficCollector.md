### Example 1: Create a new traffic collector
```powershell
New-AzNetworkFunctionTrafficCollector -name atctestps -resourcegroupname test -location eastus
```

```output
{
    "CollectorPolicies": [],
    "Etag": "testEtag",
    "Id": "id",
    "Location": "eastus",
    "Name": "atctestps",
    "ProvisioningState": {},
    "Tags": {},
    "Type": "Microsoft.NetworkFunction/AzureTrafficCollectors",
    "VirtualHubId": null
}
```

This cmdlet creates a new traffic collector.