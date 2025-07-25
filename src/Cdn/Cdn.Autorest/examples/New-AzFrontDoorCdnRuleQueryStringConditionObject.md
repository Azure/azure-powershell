### Example 1: Create an in-memory object for DeliveryRuleQueryStringCondition
```powershell
New-AzFrontDoorCdnRuleQueryStringConditionObject -Name QueryString -ParameterOperator Equal -ParameterMatchValue test -ParameterNegateCondition $False -ParameterTransform Lowercase
```

```output
Name
----
QueryString
```

Create an in-memory object for DeliveryRuleQueryStringCondition