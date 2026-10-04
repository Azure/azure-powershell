### Example 1: Build a static threshold rule
```powershell
# Build a static threshold rule for use in an evaluation rule
New-AzMonitorHealthModelThresholdRuleV2Object -Operator GreaterThan -Threshold 90
```

Creates a threshold rule using the GreaterThan operator and a threshold of 90.
