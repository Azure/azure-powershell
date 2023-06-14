### Example 1: Create an in-memory object for DeliveryRuleRemoteAddressCondition
```powershell
New-AzFrontDoorCdnRuleRemoteAddressConditionObject -Name RemoteAddress -ParameterOperator GeoMatch -ParameterMatchValue BJ -ParameterNegateCondition $False -ParameterTransform Lowercase
```

```output
Name
----
RemoteAddress
```

Create an in-memory object for DeliveryRuleRemoteAddressCondition