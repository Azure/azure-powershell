### Example 1: Create an in-memory object for AzureCDN DeliveryRuleUrlFileNameCondition
```powershell
New-AzCdnDeliveryRuleUrlFileNameConditionObject -Name UrlFileName -ParameterOperator Equal -ParameterMatchValue test -ParameterNegateCondition $False -ParameterTransform Lowercase
```

```output
Name
----
UrlFileName
```

Create an in-memory object for AzureCDN DeliveryRuleUrlFileNameCondition

