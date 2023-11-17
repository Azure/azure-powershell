### Example 1: Create an in-memory object for DeliveryRuleRequestBodyCondition
```powershell
New-AzFrontDoorCdnRuleRequestBodyConditionObject -Name RequestBody -ParameterOperator Equal -ParameterMatchValue test -ParameterNegateCondition $False -ParameterTransform Lowercase
```

```output
Name
----
RequestBody
```

Create an in-memory object for DeliveryRuleRequestBodyCondition