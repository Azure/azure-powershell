### Example 1: Remove a specified reference data set by name
```powershell
Remove-AzTimeSeriesInsightsReferenceDataSet -EnvironmentName tsitest001 -Name dstest001 -ResourceGroupName testgroup

```

This command removes a specified reference data set.

### Example 2: Remove a specified reference data set by object
```powershell
$ds = Get-AzTimeSeriesInsightsReferenceDataSet -EnvironmentName tsitest001 -Name dstest001 -ResourceGroupName testgroup
Remove-AzTimeSeriesInsightsReferenceDataSet -InputObject $ds

```

This command removes a specified reference data set.
