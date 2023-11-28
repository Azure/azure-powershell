### Example 1: Create an in-memory object for DeliveryRuleSocketAddrCondition
```powershell
 New-AzFrontDoorCdnRuleSocketAddrConditionObject -Name SocketAddr -ParameterOperator IPMatch -ParameterMatchValue 222.10.0.1
```

```output
Name
----
SocketAddr
```

Create an in-memory object for DeliveryRuleSocketAddrCondition