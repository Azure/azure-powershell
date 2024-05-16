### Example 1: Update the description of a policy set definition
```powershell
$PolicySetDefinition = Get-AzPolicySetDefinition -ResourceId '/subscriptions/mySub/Microsoft.Authorization/policySetDefinitions/myPSSetDefinition'
Update-AzPolicySetDefinition -Id $PolicySetDefinition.ResourceId -Description 'Updated policy to not allow virtual machine creation'
```

The first command gets a policy set definition by using the Get-AzPolicySetDefinition cmdlet.
The command stores that object in the $PolicySetDefinition variable.
The second command updates the description of the policy set definition identified by the **ResourceId** property of $PolicySetDefinition.

### Example 2: Update the metadata of a policy set definition
```powershell
Update-AzPolicySetDefinition -Name 'VMPolicySetDefinition' -Metadata '{"category":"Virtual Machine"}'
```

This command updates the metadata of a policy set definition named VMPolicySetDefinition to indicate its category is "Virtual Machine".

### Example 3: Update the groups of a policy set definition
```powershell
Update-AzPolicySetDefinition -Name 'VMPolicySetDefinition' -GroupDefinition '[{ "name": "group1", "displayName": "Virtual Machine Security" }, { "name": "group2" }]'
```

This command updates the groups of a policy set definition named VMPolicySetDefinition.

### Example 4: Update the groups of a policy set definition using a hash table
```powershell
$groupsJson = ConvertTo-Json @{ name = "group1"; displayName = "Virtual Machine Security" }, @{ name = "group2" }
Update-AzPolicySetDefinition -Name 'VMPolicySetDefinition' -GroupDefinition $groupsJson
```

This command updates the groups of a policy set definition named VMPolicySetDefinition from a hash table.

### Example 5: [Backcompat] Update the metadata of a policy set definition
```powershell
Set-AzPolicySetDefinition -Name 'VMPolicySetDefinition' -Metadata '{"category":"Virtual Machine"}'
```

This command updates the metadata of a policy set definition named VMPolicySetDefinition to indicate its category is "Virtual Machine".
