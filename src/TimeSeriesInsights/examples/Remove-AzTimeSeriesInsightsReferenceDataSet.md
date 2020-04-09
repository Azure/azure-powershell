### Example 1: Remove a specified reference data set by name
```powershell
PS C:\> Remove-AzTimeSeriesInsightsReferenceDataSet -EnvironmentName tsitest001 -Name dstest001 -ResourceGroupName testgroup

```

This command removes a specified reference data set.

### Example 2: Remove a specified reference data set by object
```powershell
PS C:\> $ds = Get-AzTimeSeriesInsightsReferenceDataSet -EnvironmentName tsitest001 -Name dstest001 -ResourceGroupName testgroup
PS C:\> Remove-AzTimeSeriesInsightsReferenceDataSet -InputObject $ds

```

This command removes a specified reference data set.
