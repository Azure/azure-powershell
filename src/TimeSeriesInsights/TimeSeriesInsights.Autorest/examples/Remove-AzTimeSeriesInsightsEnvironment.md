### Example 1: Remove a time series insights environment by name
```powershell
Remove-AzTimeSeriesInsightsEnvironment -ResourceGroupName testgroup -Name tsill

```

This command removes a time series insights environment.

### Example 2: Remove a time series insights environment by object
```powershell
$env = Get-AzTimeSeriesInsightsEnvironment -ResourceGroupName testgroup -Name tsill
Remove-AzTimeSeriesInsightsEnvironment -InputObject $env

```

This command removes a time series insights environment.

