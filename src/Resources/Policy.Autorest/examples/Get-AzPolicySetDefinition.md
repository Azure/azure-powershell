### Example 1: Get all policy set definitions
```powershell
Get-AzPolicySetDefinition
```

This command gets all the policy set definitions.

### Example 2: Get policy set definition from current subscription by name
```powershell
Get-AzPolicySetDefinition -Name 'VMPolicySetDefinition'
```

This command gets the policy set definition named VMPolicySetDefinition from the current default subscription.

### Example 3: Get policy set definition from subscription by name
```powershell
Get-AzPolicySetDefinition -Name 'VMPolicySetDefinition' -subscriptionId '3bf44b72-c631-427a-b8c8-53e2595398ca'
```

This command gets the policy definition named VMPolicySetDefinition from the subscription with ID 3bf44b72-c631-427a-b8c8-53e2595398ca.

### Example 4: Get all custom policy set definitions from management group
```powershell
Get-AzPolicySetDefinition -ManagementGroupName 'Dept42' -Custom
```

This command gets all custom policy set definitions from the management group named Dept42.

### Example 5: Get policy set definitions from a given category
```powershell
Get-AzPolicySetDefinition | Where-Object {$_.metadata.category -eq "Virtual Machine"}
```

This command gets all policy set definitions in category "Virtual Machine".

### Example 6: [Backcompat] Get policy set definitions from a given category
```powershell
Get-AzPolicySetDefinition -BackwardCompatible | Where-Object {$_.Properties.metadata.category -eq "Virtual Machine"}
```

This command gets all policy set definitions in category "Virtual Machine".
