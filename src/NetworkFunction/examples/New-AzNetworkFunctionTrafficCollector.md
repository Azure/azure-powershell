### Example 1: Create a new traffic collector
```powershell
New-AzNetworkFunctionTrafficCollector -name atctestps -resourcegroupname test -location eastus | Format-List
```

```output
CollectorPolicies : {}
Etag              : cf0336a2-7454-4aa4-add9-1de3e2291143
Id                : /subscriptions/62364504-2406-418e-971c-05822ff72fad/resourceGroups/test/providers/Microsoft.NetworkFunction/azureTrafficCollectors/atctestps
Location          : eastus
Name              : atctestps
ProvisioningState : Succeeded
Tags              : Microsoft.Azure.PowerShell.Cmdlets.AzureTrafficCollector.Models.ResourceTags
Type              : Microsoft.NetworkFunction/AzureTrafficCollectors
```

This cmdlet creates a new traffic collector.