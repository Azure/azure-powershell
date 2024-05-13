### Example 1 Get all policy exemptions
```powershell
Get-AzPolicyExemption
```

This command gets all the policy exemptions in the current subscription. If you need to list all the exemptions related to the given scope, including those from ancestor scopes and those from descendent scopes you need to pass the `-IncludeDescendent` parameter.

### Example 2: Get a specific policy exemption
```powershell
$ResourceGroup = Get-AzResourceGroup -Name 'ResourceGroup11'
Get-AzPolicyExemption -Name 'PolicyExemption07' -Scope $ResourceGroup.ResourceId
```

The first command gets a resource group named ResourceGroup11 by using the Get-AzResourceGroup cmdlet and stores it in the $ResourceGroup variable.
The second command gets the policy exemption named PolicyExemption07 for the scope that the **ResourceId** property of $ResourceGroup identifies.

### Example 3: Get all policy exemptions associated with a policy assignment
```powershell
$Assignment = Get-AzPolicyAssignment -Name 'PolicyAssignment07'
Get-AzPolicyExemption -PolicyAssignmentIdFilter $Assignment.ResourceId
```

The first command gets a policy assignment named PolicyAssignment07.
The second command gets all of the policy exemptions that are assigned with the policy assignment.
