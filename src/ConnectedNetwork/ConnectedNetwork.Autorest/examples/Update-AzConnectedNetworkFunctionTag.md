### Example 1: Update-AzConnectedNetworkFunctionTag
```powershell
$tags = @{ NewTag = "NewTagValue"}
Update-AzConnectedNetworkFunctionTag -NetworkFunctionName myNewVnf1 -ResourceGroupName myResources -Tag $tags
```

```output
Location    Name      Etag              ResourceGroupName
--------    ----      ----              -----------------
eastus2euap myNewVnf1 "sampleEtagValue" myResources
```

Creating an identity with field NewTag and value NewTagValue. Updating the tag of NF with resource name myNewVnf1 in resource group myResources.

### Example 2: Update-AzConnectedNetworkFunctionTag
```powershell
$tags = @{ NewTag = "NewTagValue"}
$vnf = @{ NetworkFunctionName = "myVnf1"; ResourceGroupName = "myResources"; SubscriptionId = "00000000-0000-0000-0000-000000000000"}
Update-AzConnectedNetworkFunctionTag -InputObject $vnf -Tag $tags
```

```output
Location    Name      Etag                                   ResourceGroupName
--------    ----      ----                                   -----------------
eastus2euap myNewVnf1 "0000f211-0000-3300-0000-61a9edc70000" myResources
```

Creating an identity with field NewTag and value NewTagValue. Creating an identity with NetworkFunctionName myVnf1, ResourceGroupName myResources and subscription.Updating the tag of NF specified in identity with the tags.