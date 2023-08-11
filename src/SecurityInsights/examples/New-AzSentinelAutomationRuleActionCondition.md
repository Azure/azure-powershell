### Example 1: Create a PropertyChanged automation rule condition object for automation rule
```powershell
New-AzSentinelAutomationRuleActionCondition -Type PropertyChanged -ChangedPropertyName IncidentOwner
```

```output
ConditionPropertyChangeType : 
ConditionPropertyName       : IncidentOwner
ConditionPropertyOperator   : 
ConditionPropertyValue      : 
ConditionType               : PropertyChanged
```

This command creates an automation rule condition object for automation rule
