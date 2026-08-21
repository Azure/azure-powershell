### Example 1: Get policy events in current subscription scope
```powershell
Get-AzPolicyEvent
```

Gets policy event records generated in the last day for all resources within the subscription in current session context.

### Example 2: Get policy events in the specified subscription scope
```powershell
Get-AzPolicyEvent -SubscriptionId "fff10b27-fff3-fff5-fff8-fffbe01e86a5"
```

Gets policy event records generated in the last day for all resources within the specified subscription.

### Example 3: Get policy events in management group scope
```powershell
Get-AzPolicyEvent -ManagementGroupName "myManagementGroup"
```

Gets policy event records generated in the last day for all resources within the specified management group.

### Example 4: Get policy events in resource group scope in current subscription
```powershell
Get-AzPolicyEvent -ResourceGroupName "myResourceGroup"
```

Gets policy event records generated in the last day for all resources within the specified resource group (in the subscription in current session context).

### Example 5: Get policy events in resource group scope in the specified subscription
```powershell
Get-AzPolicyEvent -SubscriptionId "fff10b27-fff3-fff5-fff8-fffbe01e86a5" -ResourceGroupName "myResourceGroup"
```

Gets policy event records generated in the last day for all resources within the specified resource group (in the specified subscription).

### Example 6: Get policy events for a resource
```powershell
Get-AzPolicyEvent -ResourceId "/subscriptions/fff10b27-fff3-fff5-fff8-fffbe01e86a5/resourceGroups/myResourceGroup/providers/Microsoft.EventHub/namespaces/myns1/eventhubs/eh1/consumergroups/cg1"
```

Gets policy event records generated in the last day for the specified resource.

### Example 7: Get policy events for a policy set definition in current subscription
```powershell
Get-AzPolicyEvent -PolicySetDefinitionName "fff58873-fff8-fff5-fffc-fffbe7c9d697"
```

Gets policy event records generated in the last day for all resources (within the tenant in current session context) effected by the specified policy set definition (that exists in the subscription in current session context).

### Example 8: Get policy events for a policy set definition in the specified subscription
```powershell
Get-AzPolicyEvent -SubscriptionId "fff10b27-fff3-fff5-fff8-fffbe01e86a5" -PolicySetDefinitionName "fff58873-fff8-fff5-fffc-fffbe7c9d697"
```

Gets policy event records generated in the last day for all resources (within the tenant in current session context) effected by the specified policy set definition (that exists in the specified subscription).

### Example 9: Get policy events for a policy definition in current subscription
```powershell
Get-AzPolicyEvent -PolicyDefinitionName "fff58873-fff8-fff5-fffc-fffbe7c9d697"
```

Gets policy event records generated in the last day for all resources (within the tenant in current session context) effected by the specified policy definition (that exists in the subscription in current session context).

### Example 10: Get policy events for a policy definition in the specified subscription
```powershell
Get-AzPolicyEvent -SubscriptionId "fff10b27-fff3-fff5-fff8-fffbe01e86a5" -PolicyDefinitionName "fff58873-fff8-fff5-fffc-fffbe7c9d697"
```

Gets policy event records generated in the last day for all resources (within the tenant in current session context) effected by the specified policy definition (that exists in the specified subscription).

### Example 11: Get policy events for a policy assignment in current subscription
```powershell
Get-AzPolicyEvent -PolicyAssignmentName "ddd8ef92e3714a5ea3d208c1"
```

Gets policy event records generated in the last day for all resources (within the tenant in current session context) effected by the specified policy assignment (that exists in the subscription in current session context).

### Example 12: Get policy events for a policy assignment in the specified subscription
```powershell
Get-AzPolicyEvent -SubscriptionId "fff10b27-fff3-fff5-fff8-fffbe01e86a5" -PolicyAssignmentName "ddd8ef92e3714a5ea3d208c1"
```

Gets policy event records generated in the last day for all resources (within the tenant in current session context) effected by the specified policy assignment (that exists in the specified subscription).

### Example 13: Get policy events for a policy assignment in the specified resource group in the current subscription
```powershell
Get-AzPolicyEvent -ResourceGroupName "myResourceGroup" -PolicyAssignmentName "ddd8ef92e3714a5ea3d208c1"
```

Gets policy event records generated in the last day for all resources (within the tenant in current session context) effected by the specified policy assignment (that exists in the resource group in the subscription in current session context).

### Example 14: Get policy events in current subscription scope, with OrderBy, Top and Select query options
```powershell
Get-AzPolicyEvent -OrderBy "Timestamp desc, PolicyAssignmentName asc" -Top 5 -Select "Timestamp, ResourceId, PolicyAssignmentId, PolicySetDefinitionId, PolicyDefinitionId"
```

Gets policy event records generated in the last day for all resources within the subscription in current session context. 
The command orders the results by timestamp and policy assignment name properties, and takes only top 5 of those listed in that order.
It also selects to list only a subset of the columns for each record.

### Example 15: Get policy events in current subscription scope, with From and To query options
```powershell
Get-AzPolicyEvent -From "2018-03-08 00:00:00Z" -To "2018-03-15 00:00:00Z"
```

Gets policy event records generated within the date range specified for all resources within the subscription in current session context.

### Example 16: Get policy events in current subscription scope, with Filter query option
```powershell
Get-AzPolicyEvent -Filter "(PolicyDefinitionAction eq 'deny' or PolicyDefinitionAction eq 'audit') and ResourceLocation ne 'eastus'"
```

Gets policy event records generated in the last day for all resources within the subscription in current session context.
The command limits the results returned by filtering based on policy definition action (includes deny or audit actions) and resource location (excludes eastus location).

### Example 17: Get policy events in current subscription scope, with Apply specifying row count aggregation
```powershell
Get-AzPolicyEvent -Apply "aggregate(`$count as NumberOfRecords)"
```

Gets the number of policy event records generated in the last day for all resources within the subscription in current session context.
The command returns the count of the policy event records only, which is returned inside AdditionalProperties property.

### Example 18: Get policy events in current subscription scope, with Apply specifying grouping with aggregation
```powershell
Get-AzPolicyEvent -Filter "PolicyDefinitionAction eq 'audit' or PolicyDefinitionAction eq 'deny'" -Apply "groupby((PolicyAssignmentId, PolicyDefinitionId, PolicyDefinitionAction, ResourceId), aggregate(`$count as NumEvents))" -OrderBy "NumEvents desc" -Top 5
```

Gets policy event records generated in the last day for all resources within the subscription in current session context. 
The command limits the results returned by filtering based on policy definition action (includes only audit and deny events).
It groups the results based on policy assignment, policy definition, policy definition action, and resource id, and computes the number of records in each group, which is returned inside AdditionalProperties property.
It orders the results by the count aggregation in descending order, and takes only top 5 of those listed in that order.

### Example 19: Get policy events in current subscription scope, with Apply specifying grouping without aggregation
```powershell
Get-AzPolicyEvent -Filter "PolicyDefinitionAction eq 'audit' or PolicyDefinitionAction eq 'deny'" -Apply "groupby((ResourceId))"
```

Gets policy event records generated in the last day for all resources within the subscription in current session context. 
The command limits the results returned by filtering based on policy definition action (includes only audit and deny events).
It groups the results based on resource id.
This generates the list of all resources within the subscription that generated a policy event for at least one audit or deny policy.

### Example 20: Get policy events in current subscription scope, with Apply specifying multiple groupings
```powershell
Get-AzPolicyEvent -Filter "PolicyDefinitionAction eq 'deny'" -Apply "groupby((PolicyAssignmentId, PolicyDefinitionId, ResourceId))/groupby((PolicyAssignmentId, PolicyDefinitionId), aggregate(`$count as NumDeniedResources))" -OrderBy "NumDeniedResources desc" -Top 5
```

Gets policy event records generated in the last day for all resources within the subscription in current session context. 
The command limits the results returned by filtering based on policy definition action (includes only deny events).
It groups the results first based on policy assignment, policy definition, and resource id. 
Then, it further groups the results of this grouping with the same properties except for resource id, and computes the number of records in each of these groups, which is returned inside AdditionalProperties property.
It orders the results by the count aggregation in descending order, and takes only top 5 of those listed in that order.
This generates the top 5 deny policies with the most number of denied resources.