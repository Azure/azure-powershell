### Example 1: Create scheduled query rule
```powershell
$subscriptionId=(Get-AzContext).SubscriptionId
$dimension = New-AzScheduledQueryRuleDimensionObject -Name Computer -Operator Include -Value *
$condition=New-AzScheduledQueryRuleConditionObject -Dimension $dimension -Query "Perf | where ObjectName == `"Processor`" and CounterName == `"% Processor Time`" | summarize AggregatedValue = avg(CounterValue) by bin(TimeGenerated, 5m), Computer" -TimeAggregation "Average" -MetricMeasureColumn "AggregatedValue" -Operator "GreaterThan" -Threshold "70" -FailingPeriodNumberOfEvaluationPeriod 1 -FailingPeriodMinFailingPeriodsToAlert 1
New-AzScheduledQueryRule -Name test-rule -ResourceGroupName test-group -Location eastus -DisplayName test-rule -Scope "/subscriptions/$subscriptionId/resourceGroups/test-group/providers/Microsoft.Compute/virtualMachines/test-vm" -Severity 4 -WindowSize ([System.TimeSpan]::New(0,10,0)) -EvaluationFrequency ([System.TimeSpan]::New(0,5,0)) -CriterionAllOf $condition
```

Create scheduled query rule