### Example 1: Remove the policy definition by name
```powershell
Remove-AzPolicyDefinition -Name 'VMPolicyDefinition'
```

This command removes the specified policy definition.

### Example 2: Remove policy definition by resource ID
```powershell
$PolicyDefinition = Get-AzPolicyDefinition -Name 'VMPolicyDefinition' 
Remove-AzPolicyDefinition -Id $PolicyDefinition.ResourceId -Force
```

This command removes the given policy definition without prompting the user.

### Example 3: [Backcompat] Remove policy definition by resource ID
```powershell
$PolicyDefinition = Get-AzPolicyDefinition -Name 'VMPolicyDefinition' 
Remove-AzPolicyDefinition -Id $PolicyDefinition.ResourceId -Force -BackwardCompatible
True
```

This command removes the given policy definition without prompting the user.