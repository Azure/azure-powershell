### Example 1: Get predictive metric for autoscale setting
```powershell
Get-AzAutoscalePredictiveMetric -AutoscaleSettingName test-autoscalesetting -ResourceGroupName test-group -Timespan "2021-10-14T22:00:00.000Z/2021-10-16T22:00:00.000Z" -Aggregation "Total" -Interval ([System.TimeSpan]::New(0,60,0)) -MetricName "PercentageCPU" -MetricNamespace
 "Microsoft.Compute/virtualMachineScaleSets"
```

Get predictive metric for autoscale setting