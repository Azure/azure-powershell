### Example 1: Create scale rule metric dimension object
```powershell
New-AzAutoscaleScaleRuleMetricDimensionObject -DimensionName VMName -Operator 'Equals' -Value test-vm
```

Create scale rule metric dimension object