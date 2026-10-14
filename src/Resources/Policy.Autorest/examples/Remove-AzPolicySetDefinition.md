### Example 1: Remove the policy set definition by name
```powershell
Remove-AzPolicySetDefinition -Name 'myPSSetDefinition'
```

This command removes the specified policy set definition.

### Example 2: Remove policy set definition by resource ID
```powershell
$PolicySetDefinition = Get-AzPolicySetDefinition -ResourceId '/subscriptions/mySub/Microsoft.Authorization/policySetDefinitions/myPSSetDefinition'
Remove-AzPolicySetDefinition -Id $PolicySetDefinition.Id -Force
```

The first command gets a policy set definition by using the Get-AzPolicySetDefinition cmdlet.
The command stores it in the $PolicySetDefinition variable.
The second command removes the policy set definition identified by the **ResourceId** property of $PolicySetDefinition.

### Example 3: Remove policy set definition version by name
```powershell
Remove-AzPolicySetDefinition -Name 'myPSSetDefinition' -Version '1.0.1' -PassThru
```

This command removes the specified policy set definition version and will return true when the command succeeds.