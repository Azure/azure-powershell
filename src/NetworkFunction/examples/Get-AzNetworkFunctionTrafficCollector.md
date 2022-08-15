### Example 1: Get list of traffic collectors in selected subscription
```powershell
Get-AzNetworkFunctionTrafficCollector
```

```output
[{
    "CollectorPolicies": [
      "testPolicy"
    ],
    "Etag": "testEtag",
    "Id": "id",
    "Location": "location",
    "Name": "atcname",
    "ProvisioningState": {},
    "Tags": {},
    "Type": "Microsoft.NetworkFunction/AzureTrafficCollectors",
    "VirtualHubId": null
  }]
```

This cmdlet gets list of traffic collectors in selected subscription.

### Example 2: Get list of traffic collectors by resource group
```powershell
Get-AzNetworkFunctionTrafficCollector -ResourceGroupName test
```

```output
[{
    "CollectorPolicies": [
      "testPolicy"
    ],
    "Etag": "testEtag",
    "Id": "id",
    "Location": "location",
    "Name": "atcname",
    "ProvisioningState": {},
    "Tags": {},
    "Type": "Microsoft.NetworkFunction/AzureTrafficCollectors",
    "VirtualHubId": null
  }]
```

This cmdlet gets list of traffic collectors by resource group.

### Example 3: Get list of traffic collectors by name
```powershell
Get-AzNetworkFunctionTrafficCollector -ResourceGroupName test -name test
```

```output
[{
    "CollectorPolicies": [
      "testPolicy"
    ],
    "Etag": "testEtag",
    "Id": "id",
    "Location": "location",
    "Name": "atcname",
    "ProvisioningState": {},
    "Tags": {},
    "Type": "Microsoft.NetworkFunction/AzureTrafficCollectors",
    "VirtualHubId": null
  }]
```

This cmdlet gets list of traffic collectors by name.
