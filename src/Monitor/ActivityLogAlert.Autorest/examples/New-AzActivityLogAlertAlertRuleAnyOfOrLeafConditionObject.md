### Example 1: Create alert rule condition
```powershell
New-AzActivityLogAlertAlertRuleAnyOfOrLeafConditionObject -Equal Administrative -Field category
```

Create alert rule condition

### Example 2: Create alert rule condition with leaf condition
```powershell
$any=New-AzActivityLogAlertAlertRuleLeafConditionObject -Field properties.incidentType -Equal Maintenance
New-AzActivityLogAlertAlertRuleAnyOfOrLeafConditionObject -AnyOf $any
```

Create alert rule condition with leaf condition