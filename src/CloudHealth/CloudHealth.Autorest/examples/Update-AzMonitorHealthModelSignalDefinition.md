### Example 1: Raise the thresholds on a signal definition
```powershell
# Update the thresholds on the signal definition cpu-utilization
$degraded = New-AzMonitorHealthModelThresholdRuleV2Object -Operator GreaterThan -Threshold 75
$unhealthy = New-AzMonitorHealthModelThresholdRuleV2Object -Operator GreaterThan -Threshold 95
$rules = New-AzMonitorHealthModelEvaluationRuleObject -DegradedRule $degraded -UnhealthyRule $unhealthy
$property = New-AzMonitorHealthModelResourceMetricSignalDefinitionPropertiesObject -MetricNamespace 'Microsoft.Compute/virtualMachines' -MetricName 'Percentage CPU' -TimeGrain PT5M -AggregationType Average -EvaluationRule $rules -DisplayName 'CPU Utilization'
Update-AzMonitorHealthModelSignalDefinition -HealthModelName azpwsh-healthmodel1 -ResourceGroupName azpwsh-test-rg -Name cpu-utilization -Property $property
```

Updates the degraded threshold to 75 and the unhealthy threshold to 95.
