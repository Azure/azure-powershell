### Example 1: Create an in-memory object for AzureCDN DeliveryRuleCookiesCondition
```powershell
New-AzCdnDeliveryRuleCookiesConditionObject -Name Cookies -ParameterOperator Equal -ParameterSelector test -ParameterMatchValue test -ParameterNegateCondition $False -ParameterTransform Lowercase
```

```output
Name
----
Cookies
```

Create an in-memory object for AzureCDN DeliveryRuleCookiesCondition


