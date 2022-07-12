### Example 1: Create an in-memory object for AzureCDN DeliveryRulePostArgsCondition
```powershell
New-AzCdnDeliveryRulePostArgsConditionObject -Name PostArgs -ParameterOperator Equal -ParameterMatchValue test -ParameterNegateCondition $False -ParameterSelector test -ParameterTransform Lowercase
```

```output
Name
----
PostArgs
```

Create an in-memory object for AzureCDN DeliveryRulePostArgsCondition



