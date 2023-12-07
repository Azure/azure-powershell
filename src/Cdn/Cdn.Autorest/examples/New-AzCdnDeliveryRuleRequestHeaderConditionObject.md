### Example 1: Create an in-memory object for AzureCDN DeliveryRuleRequestHeaderCondition
```powershell
New-AzCdnDeliveryRuleRequestHeaderConditionObject  -Name RequestHeader -ParameterOperator Equal -ParameterSelector test -ParameterMatchValue test -ParameterNegateCondition $False -ParameterTransform Lowercase
```

```output
Name
----
RequestHeader
```

Create an in-memory object for AzureCDN DeliveryRuleRequestHeaderCondition


