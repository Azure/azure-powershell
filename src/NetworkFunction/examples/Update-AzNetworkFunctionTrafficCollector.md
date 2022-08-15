### Example 1: Updates a traffic collector
```powershell
Update-AzNetworkFunctionTrafficCollector -name atctestps -resourcegroupname test -location eastus
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

This cmdlet updates a traffic collector.