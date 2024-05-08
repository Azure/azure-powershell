### Example 1: Remove policy set definition by resource ID
```powershell
$PolicySetDefinition = Get-AzPolicySetDefinition -ResourceId '/subscriptions/mySub/Microsoft.Authorization/policySetDefinitions/myPSSetDefinition'
Remove-AzPolicySetDefinition -Id $PolicySetDefinition.ResourceId -Force
```

The first command gets a policy set definition by using the Get-AzPolicySetDefinition cmdlet.
The command stores it in the $PolicySetDefinition variable.
The second command removes the policy set definition identified by the **ResourceId** property of $PolicySetDefinition.

### Example 2: [Backcompat] Remove policy set definition by resource ID
```powershell
$PolicySetDefinition = Get-AzPolicySetDefinition -ResourceId '/subscriptions/mySub/Microsoft.Authorization/policySetDefinitions/myPSSetDefinition'
Remove-AzPolicySetDefinition -Id $PolicySetDefinition.ResourceId -Force -BackwardCompatible
True
```

The first command gets a policy set definition by using the Get-AzPolicySetDefinition cmdlet.
The command stores it in the $PolicySetDefinition variable.
The second command removes the policy set definition identified by the **ResourceId** property of $PolicySetDefinition.
