### Example 1: Create an in-memory object for AzureCDN DeliveryRule
```powershell
$cond1 = New-AzCdnDeliveryRuleCookiesConditionObject -Name Cookies -ParameterOperator Equal -ParameterSelector test -ParameterMatchValue test -ParameterNegateCondition $False -ParameterTransform Lowercase
$action1 = New-AzCdnDeliveryRuleResponseHeaderActionObject -Name ModifyResponseHeader -ParameterHeaderAction Append -ParameterHeaderName a1 -ParameterValue a1
$action2 = New-AzCdnDeliveryRuleRequestHeaderActionObject -Name ModifyRequestHeader -ParameterHeaderAction Append -ParameterHeaderName a1 -ParameterValue a1


$conditions = @($cond1)
$actions = @($action1, $action2)
New-AzCdnDeliveryRuleObject -Name "Rule1" -Condition $conditions -Action $actions -Order 1
```

```output
Name  Order
----  -----
Rule1 1
```

Create an in-memory object for AzureCDN DeliveryRule



