### Example 1: Create an in-memory object for DeliveryRuleRequestHeaderCondition
```powershell
New-AzFrontDoorCdnRuleRequestHeaderConditionObject -Name RequestHeader -ParameterOperator Equal -ParameterSelector test -ParameterMatchValue test -ParameterNegateCondition $False -ParameterTransform Lowercase
```

```output
Name
----
RequestHeader
```

Create an in-memory object for DeliveryRuleRequestHeaderCondition