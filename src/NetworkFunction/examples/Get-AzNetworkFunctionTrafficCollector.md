### Example 1: Get list of traffic collectors in selected subscription
```powershell
Get-AzNetworkFunctionTrafficCollector | Format-List
```

```output
CollectorPolicies : {}
Etag              : cf0336a2-7454-4aa4-add9-1de3e2291143
Id                : /subscriptions/62364504-2406-418e-971c-05822ff72fad/resourceGroups/atcTest/providers/Microsoft.NetworkFunction/azureTrafficCollectors/pstestjuly18
Location          : eastus
Name              : pstestjuly18
ProvisioningState : Failed
Tags              : Microsoft.Azure.PowerShell.Cmdlets.AzureTrafficCollector.Models.ResourceTags
Type              : Microsoft.NetworkFunction/AzureTrafficCollectors

CollectorPolicies : {}
Etag              : cedea0e9-e9e4-4b2e-816f-dad184d6b424
Id                : /subscriptions/62364504-2406-418e-971c-05822ff72fad/resourceGroups/atcTest/providers/Microsoft.NetworkFunction/azureTrafficCollectors/newpsatc
Location          : eastus
Name              : newpsatc
ProvisioningState : Succeeded
Tags              : Microsoft.Azure.PowerShell.Cmdlets.AzureTrafficCollector.Models.ResourceTags
Type              : Microsoft.NetworkFunction/AzureTrafficCollectors
```

This cmdlet gets list of traffic collectors in selected subscription.

### Example 2: Get list of traffic collectors by resource group
```powershell
Get-AzNetworkFunctionTrafficCollector -ResourceGroupName test | Format-List
```

```output
CollectorPolicies : {}
Etag              : cedea0e9-e9e4-4b2e-816f-dad184d6b424
Id                : /subscriptions/62364504-2406-418e-971c-05822ff72fad/resourceGroups/test/providers/Microsoft.NetworkFunction/azureTrafficCollectors/newpsatc
Location          : eastus
Name              : newpsatc
ProvisioningState : Succeeded
Tags              : Microsoft.Azure.PowerShell.Cmdlets.AzureTrafficCollector.Models.ResourceTags
Type              : Microsoft.NetworkFunction/AzureTrafficCollectors
```

This cmdlet gets list of traffic collectors by resource group.

### Example 3: Get list of traffic collectors by name
```powershell
Get-AzNetworkFunctionTrafficCollector -ResourceGroupName test -name test | Format-List
```

```output
CollectorPolicies : {}
Etag              : cedea0e9-e9e4-4b2e-816f-dad184d6b424
Id                : /subscriptions/62364504-2406-418e-971c-05822ff72fad/resourceGroups/test/providers/Microsoft.NetworkFunction/azureTrafficCollectors/test
Location          : eastus
Name              : newpsatc
ProvisioningState : Succeeded
Tags              : Microsoft.Azure.PowerShell.Cmdlets.AzureTrafficCollector.Models.ResourceTags
Type              : Microsoft.NetworkFunction/AzureTrafficCollectors
```

This cmdlet gets list of traffic collectors by name.
