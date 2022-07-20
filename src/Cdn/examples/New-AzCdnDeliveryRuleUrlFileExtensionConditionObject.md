### Example 1: Create an in-memory object for AzureCDN DeliveryRuleUrlFileExtensionCondition
```powershell
New-AzCdnDeliveryRuleUrlFileExtensionConditionObject -Name UrlFileExtension -ParameterOperator Equal -ParameterMatchValue txt -ParameterNegateCondition $False -ParameterTransform Lowercase
```

```output
Name
----
UrlFileExtension
```

Create an in-memory object for AzureCDN DeliveryRuleUrlFileExtensionCondition

