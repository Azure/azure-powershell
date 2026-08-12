### Example 1: Build an Application Insights discovery specification
```powershell
# Build an Application Insights specification for use with a discovery rule
New-AzMonitorHealthModelApplicationInsightsTopologySpecificationObject -ApplicationInsightsResourceId '/subscriptions/00000000-0000-0000-0000-000000000000/resourceGroups/azpwsh-test-rg/providers/Microsoft.Insights/components/contoso-ai'
```

Creates an Application Insights specification for use with a discovery rule.
