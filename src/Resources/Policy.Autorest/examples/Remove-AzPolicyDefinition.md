### Example 1: Remove the policy definition by name
```powershell
Remove-AzPolicyDefinition -Name 'VMPolicyDefinition'
```

This command removes the specified policy definition.

### Example 2: Remove policy definition by resource ID
```powershell
$PolicyDefinition = Get-AzPolicyDefinition -Name 'VMPolicyDefinition' 
Remove-AzPolicyDefinition -Id $PolicyDefinition.Id -Force
```

This command removes the given policy definition without prompting the user.

### Example 3: Remove policy definition version by name
```powershell
Remove-AzPolicyDefinition -Name 'VMPolicyDefinition' -Version '1.0.1' -PassThru
```

This command removes the specified policy definition version and will return true when the command succeeds.