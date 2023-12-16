### Example 1: List all access policies under a specified environment
```powershell
Get-AzTimeSeriesInsightsAccessPolicy -EnvironmentName tsitest001 -ResourceGroupName testgroup
```
```output
Name      Type
----      ----
policy001 Microsoft.TimeSeriesInsights/Environments/AccessPolicies
policy002 Microsoft.TimeSeriesInsights/Environments/AccessPolicies
```

This command lists all access policies under a specified environment.

### Example 2: Get a specified access policy by name
```powershell
Get-AzTimeSeriesInsightsAccessPolicy -EnvironmentName tsitest001 -ResourceGroupName testgroup -Name policy001
```
```output
Name      Type
----      ----
policy001 Microsoft.TimeSeriesInsights/Environments/AccessPolicies
```

This command gets a specified access policy.

### Example 3: Get a specified access policy by object
```powershell
$ap = Get-AzTimeSeriesInsightsAccessPolicy -EnvironmentName tsi-envv8u56x -ResourceGroupName tsi-test-i01k5l -Name tsi-apilgj5y 
Get-AzTimeSeriesInsightsAccessPolicy -InputObject $ap
```
```output
Name      Type
----      ----
policy001 Microsoft.TimeSeriesInsights/Environments/AccessPolicies
```

This command gets a specified access policy.