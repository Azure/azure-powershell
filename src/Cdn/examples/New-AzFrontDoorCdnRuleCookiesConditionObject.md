### Example 1: Create an in-memory object for DeliveryRuleCookiesCondition
```powershell
New-AzFrontDoorCdnRuleCookiesConditionObject -Name Cookies -ParameterOperator Equal -ParameterSelector test -ParameterMatchValue test -ParameterNegateCondition $False -ParameterTransform Lowercase
```

```output
Name
----
Cookies
```

Create an in-memory object for DeliveryRuleCookiesCondition
