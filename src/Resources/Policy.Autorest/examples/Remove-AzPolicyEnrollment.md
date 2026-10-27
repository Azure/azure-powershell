### Example 1: Remove policy enrollment by name and scope
```powershell
$ResourceGroup = Get-AzResourceGroup -Name 'ResourceGroup11'
Remove-AzPolicyEnrollment -Name 'PolicyEnrollment07' -Scope $ResourceGroup.ResourceId -Confirm
```

The first command gets a resource group named ResourceGroup11 by using the Get-AzResourceGroup cmdlet.
The command stores that object in the $ResourceGroup variable.
The second command removes the policy enrollment named PolicyEnrollment07 at the resource group scope.
The **ResourceId** property of $ResourceGroup identifies the resource group.

### Example 2: Remove policy enrollment by ID
```powershell
$ResourceGroup = Get-AzResourceGroup -Name 'ResourceGroup11'
$PolicyEnrollment = Get-AzPolicyEnrollment -Name 'PolicyEnrollment07' -Scope $ResourceGroup.ResourceId
Remove-AzPolicyEnrollment -Id $PolicyEnrollment.Id -Force
```

The first command gets a resource group named ResourceGroup11, and then stores that object in the $ResourceGroup variable.
The second command gets the policy enrollment at a resource group level, and then stores it in the $PolicyEnrollment variable.
The **ResourceId** property of $ResourceGroup identifies the resource group.
The final command removes the policy enrollment that the **Id** property of $PolicyEnrollment identifies, bypassing the confirmation prompt with the **Force** parameter.

