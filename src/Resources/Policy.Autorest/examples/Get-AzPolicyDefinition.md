### Example 1: Get all policy definitions
```powershell
Get-AzPolicyDefinition
```

This command gets all the policy definitions.

### Example 2: Get policy definition from current subscription by name
```powershell
Get-AzPolicyDefinition -Name 'VMPolicyDefinition'
```

This command gets the policy definition named VMPolicyDefinition from the current default subscription.

### Example 3: Get policy definition from management group by name
```powershell
Get-AzPolicyDefinition -Name 'VMPolicyDefinition' -ManagementGroupName 'Dept42'
```

This command gets the policy definition named VMPolicyDefinition from the management group named Dept42.

### Example 4: Get all built-in policy definitions from subscription
```powershell
Get-AzPolicyDefinition -SubscriptionId '3bf44b72-c631-427a-b8c8-53e2595398ca' -Builtin
```

This command gets all built-in policy definitions from the subscription with ID 3bf44b72-c631-427a-b8c8-53e2595398ca.

### Example 5: Get policy definitions from a given category
```powershell
Get-AzPolicyDefinition | Where-Object {$_.Properties.metadata.category -eq 'Tags'}
```

This command gets all policy definitions in the category **Tags**.

### Example 6: Get the display name, description, policy type, and metadata of all policy definitions formatted as a list

```powershell
Get-AzPolicyDefinition | Select-Object -Property DisplayName, Description, PolicyType, Metadata | Format-List
```

This command is useful when you need to find the reader-friendly **DisplayName** property of an Azure
Policy definition. You can parse the **Metadata** property to discover the policy definition's version number and category assignment.

### Example 7: [Backcompat] Get the display name, description, policy type, and metadata of all policy definitions formatted as a list

```powershell
Get-AzPolicyDefinition -BackwardCompatible | Select-Object -ExpandProperty properties | Select-Object -Property DisplayName, Description, PolicyType, Metadata | Format-List
```

This command is useful when you need to find the reader-friendly **DisplayName** property of an Azure
Policy definition. You can parse the **Metadata** property to discover the policy definition's version number and category assignment.
