### Example 1: Build a static threshold rule
```powershell
New-AzMonitorHealthModelThresholdRuleV2Object -Operator GreaterThan -Threshold 90
```

Creates a threshold rule that trips when the signal value goes above 90.
