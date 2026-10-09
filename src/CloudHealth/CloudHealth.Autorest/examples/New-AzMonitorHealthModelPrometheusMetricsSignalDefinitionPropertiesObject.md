### Example 1: Build a Prometheus metrics signal
```powershell
# Build a signal definition property object backed by a Prometheus query
$unhealthy = New-AzMonitorHealthModelThresholdRuleV2Object -Operator GreaterThan -Threshold 0.05
$rules = New-AzMonitorHealthModelEvaluationRuleObject -UnhealthyRule $unhealthy
New-AzMonitorHealthModelPrometheusMetricsSignalDefinitionPropertiesObject -QueryText 'rate(http_requests_failed_total[5m])' -TimeGrain PT5M -EvaluationRule $rules -DisplayName 'Failed request rate'
```

Creates the property object for a signal definition backed by a Prometheus query.
