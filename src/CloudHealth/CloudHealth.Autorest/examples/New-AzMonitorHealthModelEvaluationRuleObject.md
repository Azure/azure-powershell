### Example 1: Combine degraded and unhealthy thresholds
```powershell
# Build an evaluation rule object from a degraded and an unhealthy threshold
$degraded = New-AzMonitorHealthModelThresholdRuleV2Object -Operator GreaterThan -Threshold 70
$unhealthy = New-AzMonitorHealthModelThresholdRuleV2Object -Operator GreaterThan -Threshold 90
New-AzMonitorHealthModelEvaluationRuleObject -DegradedRule $degraded -UnhealthyRule $unhealthy
```

Creates the evaluation rules for a signal definition.
Only the unhealthy rule is required.
