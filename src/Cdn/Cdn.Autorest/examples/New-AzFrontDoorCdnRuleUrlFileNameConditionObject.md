### Example 1: Create an in-memory object for DeliveryRuleUrlFileNameCondition
```powershell
New-AzFrontDoorCdnRuleUrlFileNameConditionObject -Name UrlFileName -ParameterOperator Equal -ParameterMatchValue test -ParameterNegateCondition $False -ParameterTransform Lowercase
```

```output
Name
----
UrlFileName
```

Create an in-memory object for DeliveryRuleUrlFileNameCondition

