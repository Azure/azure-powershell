### Example 1: Get latest policy states in current subscription scope
```powershell
Get-AzPolicyState
```

Gets latest policy state records generated in the last day for all resources within the subscription in current session context.

### Example 2: Get latest policy states in the specified subscription scope
```powershell
Get-AzPolicyState -SubscriptionId "fff10b27-fff3-fff5-fff8-fffbe01e86a5"
```

Gets latest policy state records generated in the last day for all resources within the specified subscription.

### Example 3: Get all policy states in current subscription scope
```powershell
Get-AzPolicyState -All
```

Gets all historical policy state records (including latest) generated in the last day for all resources within the subscription in current session context.

### Example 4: Get latest policy states in management group scope
```powershell
Get-AzPolicyState -ManagementGroupName "myManagementGroup"
```

Gets latest policy state records generated in the last day for all resources within the specified management group.

### Example 5: Get latest policy states in resource group scope in current subscription
```powershell
Get-AzPolicyState -ResourceGroupName "myResourceGroup"
```

Gets latest policy state records generated in the last day for all resources within the specified resource group (in the subscription in current session context).

### Example 6: Get latest policy states in resource group scope in the specified subscription
```powershell
Get-AzPolicyState -SubscriptionId "fff10b27-fff3-fff5-fff8-fffbe01e86a5" -ResourceGroupName "myResourceGroup"
```

Gets latest policy state records generated in the last day for all resources within the specified resource group (in the specified subscription).

### Example 7: Get latest policy states for a resource
```powershell
Get-AzPolicyState -ResourceId "/subscriptions/fff10b27-fff3-fff5-fff8-fffbe01e86a5/resourceGroups/myResourceGroup/providers/Microsoft.EventHub/namespaces/myns1/eventhubs/eh1/consumergroups/cg1"
```

Gets latest policy state records generated in the last day for the specified resource.

### Example 8: Get latest policy states for a policy set definition in current subscription
```powershell
Get-AzPolicyState -PolicySetDefinitionName "fff58873-fff8-fff5-fffc-fffbe7c9d697"
```

Gets latest policy state records generated in the last day for all resources (within the tenant in current session context) effected by the specified policy set definition (that exists in the subscription in current session context).

### Example 9: Get latest policy states for a policy set definition in the specified subscription
```powershell
Get-AzPolicyState -SubscriptionId "fff10b27-fff3-fff5-fff8-fffbe01e86a5" -PolicySetDefinitionName "fff58873-fff8-fff5-fffc-fffbe7c9d697"
```

Gets latest policy state records generated in the last day for all resources (within the tenant in current session context) effected by the specified policy set definition (that exists in the specified subscription).

### Example 10: Get latest policy states for a policy definition in current subscription
```powershell
Get-AzPolicyState -PolicyDefinitionName "fff58873-fff8-fff5-fffc-fffbe7c9d697"
```

Gets latest policy state records generated in the last day for all resources (within the tenant in current session context) effected by the specified policy definition (that exists in the subscription in current session context).

### Example 11: Get latest policy states for a policy definition in the specified subscription
```powershell
Get-AzPolicyState -SubscriptionId "fff10b27-fff3-fff5-fff8-fffbe01e86a5" -PolicyDefinitionName "fff58873-fff8-fff5-fffc-fffbe7c9d697"
```

Gets latest policy state records generated in the last day for all resources (within the tenant in current session context) effected by the specified policy definition (that exists in the specified subscription).

### Example 12: Get latest policy states for a policy assignment in current subscription
```powershell
Get-AzPolicyState -PolicyAssignmentName "ddd8ef92e3714a5ea3d208c1"
```

Gets latest policy state records generated in the last day for all resources (within the tenant in current session context) effected by the specified policy assignment (that exists at subscription scope in the subscription in current session context).

### Example 13: Get latest policy states for a policy assignment with the same scope as the specified subscription
```powershell
Get-AzPolicyState -SubscriptionId "fff10b27-fff3-fff5-fff8-fffbe01e86a5" -PolicyAssignmentName "ddd8ef92e3714a5ea3d208c1"
```

Gets latest policy state records generated in the last day for all resources (within the tenant in current session context) effected by the specified policy assignment (that exists at subscription scope in the specified subscription).

### Example 14: Get latest policy states for a policy assignment in the specified resource group in the current subscription
```powershell
Get-AzPolicyState -ResourceGroupName "myResourceGroup" -PolicyAssignmentName "ddd8ef92e3714a5ea3d208c1"
```

Gets latest policy state records generated in the last day for all resources (within the tenant in current session context) effected by the specified policy assignment (that exists in the resource group in the subscription in current session context).

### Example 15: Get latest policy states in current subscription scope, with OrderBy, Top and Select query options
```powershell
Get-AzPolicyState -OrderBy "Timestamp desc, PolicyAssignmentName asc" -Top 5 -Select "Timestamp, ResourceId, PolicyAssignmentId, PolicySetDefinitionId, PolicyDefinitionId, IsCompliant"
```

Gets latest policy state records generated in the last day for all resources within the subscription in current session context. 
The command orders the results by timestamp and policy assignment name properties, and takes only top 5 of those listed in that order.
It also selects to list only a subset of the columns for each record.

### Example 16: Get latest policy states in current subscription scope, with From and To query options
```powershell
Get-AzPolicyState -From "2018-03-08 00:00:00Z" -To "2018-03-15 00:00:00Z"
```

Gets latest policy state records generated within the date range specified for all resources within the subscription in current session context.

### Example 17: Get latest policy states in current subscription scope, with Filter query option
```powershell
Get-AzPolicyState -Filter "(PolicyDefinitionAction eq 'deny' or PolicyDefinitionAction eq 'audit') and ComplianceState eq 'NonCompliant' and ResourceLocation ne 'eastus'"
```

Gets latest policy state records generated in the last day for all resources within the subscription in current session context.
The command limits the results returned by filtering based on policy definition action (includes deny or audit actions), compliance status (includes only non-compliant status) and resource location (excludes eastus location).

### Example 18: Get latest policy states in current subscription scope, with Apply specifying row count aggregation
```powershell
Get-AzPolicyState -Apply "aggregate(`$count as NumberOfRecords)"
```

Gets the number of latest policy state records generated in the last day for all resources within the subscription in current session context.
The command returns the count of the policy state records only, which is returned inside AdditionalProperties property.

### Example 19: Get latest policy states in current subscription scope, with Apply specifying grouping with aggregation
```powershell
Get-AzPolicyState -Filter "ComplianceState eq 'NonCompliant'" -Apply "groupby((PolicyAssignmentId, PolicySetDefinitionId, PolicyDefinitionReferenceId, PolicyDefinitionId), aggregate(`$count as NumStates))" -OrderBy "NumStates desc" -Top 5
```

Gets latest policy state records generated in the last day for all resources within the subscription in current session context. 
The command limits the results returned by filtering based on compliance status (includes only non-compliant status).
It groups the results based on policy assignment, policy set definition, and policy definition, and computes the number of records in each group, which is returned inside AdditionalProperties property.
It orders the results by the count aggregation in descending order, and takes only top 5 of those listed in that order.

### Example 20: Get latest policy states in current subscription scope, with Apply specifying grouping without aggregation
```powershell
Get-AzPolicyState -Filter "ComplianceState eq 'NonCompliant'" -Apply "groupby((ResourceId))"
```

Gets latest policy state records generated in the last day for all resources within the subscription in current session context. 
The command limits the results returned by filtering based on compliance status (includes only non-compliant status).
It groups the results based on resource id.
This generates the list of all resources within the subscription that are non-compliant for at least one policy.

### Example 21: Get latest policy states in current subscription scope, with Apply specifying multiple groupings
```powershell
Get-AzPolicyState -Filter "ComplianceState eq 'NonCompliant'" -Apply "groupby((PolicyAssignmentId, PolicySetDefinitionId, PolicyDefinitionReferenceId, PolicyDefinitionId, ResourceId))/groupby((PolicyAssignmentId, PolicySetDefinitionId, PolicyDefinitionReferenceId, PolicyDefinitionId), aggregate(`$count as NumNonCompliantResources))" -OrderBy "NumNonCompliantResources desc" -Top 5
```

Gets latest policy state records generated in the last day for all resources within the subscription in current session context. 
The command limits the results returned by filtering based on compliance status (includes only non-compliant status).
It groups the results first based on policy assignment, policy set definition, policy definition, and resource id. 
Then, it further groups the results of this grouping with the same properties except for resource id, and computes the number of records in each of these groups, which is returned inside AdditionalProperties property.
It orders the results by the count aggregation in descending order, and takes only top 5 of those listed in that order.
This generates the top 5 policies with the most number of non-compliant resources.

### Example 22: Get latest policy states including policy evaluation details for a resource
```powershell
Get-AzPolicyState -ResourceId "/subscriptions/fff10b27-fff3-fff5-fff8-fffbe01e86a5/resourceGroups/myResourceGroup/providers/Microsoft.EventHub/namespaces/myns1/eventhubs/eh1/consumergroups/cg1" -Expand "PolicyEvaluationDetails"
```

Gets latest policy state records generated in the last day for the specified resource and expand policyEvaluationDetails.

### Example 23: Get latest component policy states for a resource (eg. vault) given a resource provider mode policy assignment
```powershell
Get-AzPolicyState -ResourceId "/subscriptions/fff10b27-fff3-fff5-fff8-fffbe01e86a5/resourceGroups/myResourceGroup/providers/Microsoft.KeyVault/vaults/myvault" -Filter "policyAssignmentId eq '/subscriptions/fff10b27-fff3-fff5-fff8-fffbe01e86a5/providers/Microsoft.Authorization/policyAssignments/ddd8ef92e3714a5ea3d208c1'" -Expand "Components(`$filter=ComplianceState eq 'NonCompliant' or ComplianceState eq 'Compliant')"
```

Gets latest component policy state records generated in the last day for the specified resource, given a resource provider mode policy assignment that references a resource provider mode policy definition.

### Example 24: Get latest component policy states for a resource (eg. vault) given a policy initiative assignment that contains a resource provider mode policy definition
```powershell
Get-AzPolicyState -ResourceId "/subscriptions/fff10b27-fff3-fff5-fff8-fffbe01e86a5/resourceGroups/myResourceGroup/providers/Microsoft.KeyVault/vaults/myvault" -Filter "policyAssignmentId eq '/subscriptions/fff10b27-fff3-fff5-fff8-fffbe01e86a5/providers/Microsoft.Authorization/policyAssignments/ddd8ef92e3714a5ea3d208c1' and policyDefinitionReferenceId eq 'myResourceProviderModeDefinitionReferenceId'" -Expand "Components(`$filter=ComplianceState eq 'NonCompliant' or ComplianceState eq 'Compliant')"
```

Gets latest component policy state records generated in the last day for the specified resource, given a resource provider mode policy assignment that references an initiative containing a resource provider mode policy definition.

### Example 25: Get latest component counts by compliance state for a resource (eg. vault) given a resource provider mode policy assignment
```powershell
Get-AzPolicyState -ResourceId "/subscriptions/fff10b27-fff3-fff5-fff8-fffbe01e86a5/resourceGroups/myResourceGroup/providers/Microsoft.KeyVault/vaults/myvault" -Filter "policyAssignmentId eq '/subscriptions/fff10b27-fff3-fff5-fff8-fffbe01e86a5/providers/Microsoft.Authorization/policyAssignments/ddd8ef92e3714a5ea3d208c1'" -Expand "Components(`$filter=ComplianceState eq 'NonCompliant' or ComplianceState eq 'Compliant' or ComplianceState eq 'Conflict';`$apply=groupby((complianceState),aggregate(`$count as count)))"
```

Gets latest component counts generated in the last day grouped by compliance state for the specified resource, given a resource provider mode policy assignment.

### Example 26: Get policy states for a management group scope policy assignment
```powershell
Get-AzPolicyState -SubscriptionId "fff10b27-fff3-fff5-fff8-fffbe01e86a5" -Filter "policyAssignmentId eq '/providers/Microsoft.Management/managementGroups/myManagementGroup/providers/Microsoft.Authorization/policyAssignments/ddd8ef92e3714a5ea3d208c1'"
```

Gets latest policy state records generated in the last day for all resources (within the tenant in current session context) in the specified subscription affected by the specified policy assignment (which is assigned to a management group which is an ancestor of the specified subscription).