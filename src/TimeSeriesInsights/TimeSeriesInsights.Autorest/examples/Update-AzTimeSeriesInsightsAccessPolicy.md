### Example 1: Update a specified access policy by name
```powershell
Update-AzTimeSeriesInsightsAccessPolicy -EnvironmentName tsitest001 -Name policy001 -ResourceGroupName testgroup -Role Contributor,Reader
```
```output
Name      Type
----      ----
policy001 Microsoft.TimeSeriesInsights/Environments/AccessPolicies
```

This command updates a specified access policy.

### Example 2: Update a specified access policy by object
```powershell
$policy = Get-AzTimeSeriesInsightsAccessPolicy -EnvironmentName tsitest001 -ResourceGroupName testgroup -Name policy001
Update-AzTimeSeriesInsightsAccessPolicy -InputObject $policy -Role Contributor
```
```output
Name      Type
----      ----
policy001 Microsoft.TimeSeriesInsights/Environments/AccessPolicies
```

This command updates a specified access policy.