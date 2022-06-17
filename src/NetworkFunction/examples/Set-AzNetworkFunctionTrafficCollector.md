### Example 1: Updates a traffic collector
```powershell
Set-AzNetworkFunctionTrafficCollector -name atctestps -resourcegroup test -location eastus
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