### Example 1: Create alert rule condition
```powershell
New-AzAlertRuleAnyOfOrLeafConditionObject -Equal Administrative -Field category
```

Create alert rule condition

### Example 2: Create alert rule condition with leaf condition
```powershell
$any=New-AzAlertRuleLeafConditionObject -Field properties.incidentType -Equal Maintenance
New-AzAlertRuleAnyOfOrLeafConditionObject -AnyOf $any
```

Create alert rule condition with leaf condition

