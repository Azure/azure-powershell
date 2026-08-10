### Example 1: Build a Log Analytics query signal
```powershell
$unhealthy = New-AzMonitorHealthModelThresholdRuleV2Object -Operator GreaterThan -Threshold 10
$rules = New-AzMonitorHealthModelEvaluationRuleObject -UnhealthyRule $unhealthy
New-AzMonitorHealthModelLogAnalyticsQuerySignalDefinitionPropertiesObject -QueryText 'AppExceptions | summarize Count = count()' -ValueColumnName Count -TimeGrain PT15M -EvaluationRule $rules -DisplayName 'Exception count'
```

Creates the property object for a signal definition backed by a Log Analytics query. ValueColumnName selects the column holding the numeric value.
