### Example 1: Build an Application Insights discovery specification
```powershell
New-AzMonitorHealthModelApplicationInsightsTopologySpecificationObject -ApplicationInsightsResourceId '/subscriptions/00000000-0000-0000-0000-000000000000/resourceGroups/azpwsh-test-rg/providers/Microsoft.Insights/components/contoso-ai'
```

Creates the specification for a discovery rule that builds entities from an Application Insights application map.
