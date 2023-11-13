### Example 1: Create an in-memory object for AzureCDN DeliveryRuleRequestBodyCondition
```powershell
New-AzCdnDeliveryRuleRequestBodyConditionObject -Name RequestBody -ParameterOperator Equal -ParameterMatchValue test -ParameterNegateCondition $False -ParameterTransform Lowercase
```

```output
Name
----
RequestBody
```

Create an in-memory object for AzureCDN DeliveryRuleRequestBodyCondition



