### Example 1: Get latest non-compliant policy states summary in current subscription scope
```powershell
Get-AzPolicyStateSummary
```

Gets the summary view of latest policy compliance states generated in the last day for all resources within the subscription in current session context.

### Example 2: Get latest non-compliant policy states summary in the specified subscription scope
```powershell
Get-AzPolicyStateSummary -SubscriptionId "fff10b27-fff3-fff5-fff8-fffbe01e86a5"
```

Gets the summary view of latest policy compliance states generated in the last day for all resources within the specified subscription.

### Example 3: Get latest non-compliant policy states summary in management group scope
```powershell
Get-AzPolicyStateSummary -ManagementGroupName "myManagementGroup"
```

Gets the summary view of latest policy compliance states generated in the last day for all resources within the specified management group.

### Example 4: Get latest non-compliant policy states summary in resource group scope in current subscription
```powershell
Get-AzPolicyStateSummary -ResourceGroupName "myResourceGroup"
```

Gets the summary view of latest policy compliance states generated in the last day for all resources within the specified resource group (in the subscription in current session context).

### Example 5: Get latest non-compliant policy states summary in resource group scope in the specified subscription
```powershell
Get-AzPolicyStateSummary -SubscriptionId "fff10b27-fff3-fff5-fff8-fffbe01e86a5" -ResourceGroupName "myResourceGroup"
```

Gets the summary view of latest policy compliance states generated in the last day for all resources within the specified resource group (in the specified subscription).

### Example 6: Get latest non-compliant policy states summary for a resource
```powershell
Get-AzPolicyStateSummary -ResourceId "/subscriptions/fff10b27-fff3-fff5-fff8-fffbe01e86a5/resourceGroups/myResourceGroup/providers/Microsoft.EventHub/namespaces/myns1/eventhubs/eh1/consumergroups/cg1"
```

Gets the summary view of latest policy compliance states generated in the last day for the specified resource.

### Example 7: Get latest non-compliant policy states summary for a policy set definition in current subscription
```powershell
Get-AzPolicyStateSummary -PolicySetDefinitionName "fff58873-fff8-fff5-fffc-fffbe7c9d697"
```

Gets the summary view of latest policy compliance states generated in the last day for all resources (within the tenant in current session context) effected by the specified policy set definition (that exists in the subscription in current session context).

### Example 8: Get latest non-compliant policy states summary for a policy set definition in the specified subscription
```powershell
Get-AzPolicyStateSummary -SubscriptionId "fff10b27-fff3-fff5-fff8-fffbe01e86a5" -PolicySetDefinitionName "fff58873-fff8-fff5-fffc-fffbe7c9d697"
```

Gets the summary view of latest policy compliance states generated in the last day for all resources (within the tenant in current session context) effected by the specified policy set definition (that exists in the specified subscription).

### Example 9: Get latest non-compliant policy states summary for a policy definition in current subscription
```powershell
Get-AzPolicyStateSummary -PolicyDefinitionName "fff58873-fff8-fff5-fffc-fffbe7c9d697"
```

Gets the summary view of latest policy compliance states generated in the last day for all resources (within the tenant in current session context) effected by the specified policy definition (that exists in the subscription in current session context).

### Example 10: Get latest non-compliant policy states summary for a policy definition in the specified subscription
```powershell
Get-AzPolicyStateSummary -SubscriptionId "fff10b27-fff3-fff5-fff8-fffbe01e86a5" -PolicyDefinitionName "fff58873-fff8-fff5-fffc-fffbe7c9d697"
```

Gets the summary view of latest policy compliance states generated in the last day for all resources (within the tenant in current session context) effected by the specified policy definition (that exists in the specified subscription).

### Example 11: Get latest non-compliant policy states summary for a policy assignment in current subscription
```powershell
Get-AzPolicyStateSummary -PolicyAssignmentName "ddd8ef92e3714a5ea3d208c1"
```

Gets the summary view of latest policy compliance states generated in the last day for all resources (within the tenant in current session context) effected by the specified policy assignment (that exists in the subscription in current session context).

### Example 12: Get latest non-compliant policy states summary for a policy assignment in the specified subscription
```powershell
Get-AzPolicyStateSummary -SubscriptionId "fff10b27-fff3-fff5-fff8-fffbe01e86a5" -PolicyAssignmentName "ddd8ef92e3714a5ea3d208c1"
```

Gets the summary view of latest policy compliance states generated in the last day for all resources (within the tenant in current session context) effected by the specified policy assignment (that exists in the specified subscription).

### Example 13: Get latest non-compliant policy states summary for a policy assignment in the specified resource group in the current subscription
```powershell
Get-AzPolicyStateSummary -ResourceGroupName "myResourceGroup" -PolicyAssignmentName "ddd8ef92e3714a5ea3d208c1"
```

Gets the summary view of latest policy compliance states generated in the last day for all resources (within the tenant in current session context) effected by the specified policy assignment (that exists in the resource group in the subscription in current session context).

### Example 14: Get latest non-compliant policy states summary in current subscription scope, with Top query option
```powershell
Get-AzPolicyStateSummary -Top 5
```

Gets the summary view of latest policy compliance states generated in the last day for all resources within the subscription in current session context. 
The command orders the policy assignment summaries in the results by non-compliant resource counts in descending order, and takes only top 5 of those policy assignment summaries.

### Example 15: Get latest non-compliant policy states summary in current subscription scope, with From and To query options
```powershell
Get-AzPolicyStateSummary -From "2018-03-08 00:00:00Z" -To "2018-03-15 00:00:00Z"
```

Gets the summary view of latest policy compliance states generated within the date range specified for all resources within the subscription in current session context.

### Example 16: Get latest non-compliant policy states summary in current subscription scope, with Filter query option
```powershell
Get-AzPolicyStateSummary -Filter "(PolicyDefinitionAction eq 'deny' or PolicyDefinitionAction eq 'audit') and ResourceLocation ne 'eastus'"
```

Gets the summary view of latest policy compliance states generated in the last day for all resources within the subscription in current session context.
The command limits the results returned by filtering based on policy definition action (includes deny or audit actions), and resource location (excludes eastus location).