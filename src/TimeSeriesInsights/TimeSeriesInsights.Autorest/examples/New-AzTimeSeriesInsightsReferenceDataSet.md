### Example 1: Create a reference data set for a specified environment  
```powershell
$mykeyproperties = @{ "name" = "device01"; "type" = "Double"}
New-AzTimeSeriesInsightsReferenceDataSet -EnvironmentName tsitest001 -Name dstest001 -ResourceGroupName testgroup -Location eastus -DataStringComparisonBehavior Ordinal -KeyProperty $mykeyproperties
```
```output
Location Name      Type
-------- ----      ----
eastus   dstest001 Microsoft.TimeSeriesInsights/Environments/ReferenceDataSets
```

This command creates a reference data set for a specific environment.
