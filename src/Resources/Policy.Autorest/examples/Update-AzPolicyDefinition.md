### Example 1: Update the description of a policy definition
```powershell
$PolicyDefinition = Get-AzPolicyDefinition -Name 'VMPolicyDefinition'
Update-AzPolicyDefinition -Id $PolicyDefinition.ResourceId -Description 'Updated policy to not allow virtual machine creation'
```

The first command gets a policy definition named VMPolicyDefinition by using the Get-AzPolicyDefinition cmdlet.
The command stores that object in the $PolicyDefinition variable.
The second command updates the description of the policy definition identified by the **ResourceId** property of $PolicyDefinition.

### Example 2: Update the mode of a policy definition
```powershell
Update-AzPolicyDefinition -Name 'VMPolicyDefinition' -Mode 'All'
```

This command updates the policy definition named VMPolicyDefinition by using the Update-AzPolicyDefinition cmdlet to 
set its mode property to 'All'.

### Example 3: Update the metadata of a policy definition
```powershell
Update-AzPolicyDefinition -Name 'VMPolicyDefinition' -Metadata '{"category":"Virtual Machine"}'
```

This command updates the metadata of a policy definition named VMPolicyDefinition to indicate its category is "Virtual Machine".

### Example 3: [Backcompat] Update the mode of a policy definition
```powershell
Set-AzPolicyDefinition -Name 'VMPolicyDefinition' -Mode 'All'
```

This command updates the policy definition named VMPolicyDefinition by using the Set-AzPolicyDefinition alias of the Update-AzPolicyDefinition cmdlet to set its mode property to 'All'.
