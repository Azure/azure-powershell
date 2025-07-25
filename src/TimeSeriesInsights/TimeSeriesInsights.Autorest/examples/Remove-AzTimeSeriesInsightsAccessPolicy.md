### Example 1: Remove a specified access policy by name
```powershell
Remove-AzTimeSeriesInsightsAccessPolicy -EnvironmentName tsitest001 -Name policy001 -ResourceGroupName testgroup

```

This command removes a specified access policy.

### Example 2: Remove a specified access policy by object
```powershell
$policy = Get-AzTimeSeriesInsightsAccessPolicy -EnvironmentName tsitest001 -Name policy001 -ResourceGroupName testgroup
Remove-AzTimeSeriesInsightsAccessPolicy -InputObject $policy

```

This command removes a specified access policy.


