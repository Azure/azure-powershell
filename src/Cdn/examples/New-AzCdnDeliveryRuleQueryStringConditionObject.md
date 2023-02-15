### Example 1: Create an in-memory object for AzureCDN DeliveryRuleQueryStringCondition
```powershell
New-AzCdnDeliveryRuleQueryStringConditionObject -Name QueryString -ParameterOperator Equal -ParameterMatchValue test -ParameterNegateCondition $False -ParameterTransform Lowercase
```

```output
Name
----
QueryString
```

Create an in-memory object for AzureCDN DeliveryRuleQueryStringCondition


