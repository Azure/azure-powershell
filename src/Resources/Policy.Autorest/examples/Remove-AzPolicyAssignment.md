### Example 1: Remove policy assignment by name and scope
```powershell
$ResourceGroup = Get-AzResourceGroup -Name 'ResourceGroup11'
Remove-AzPolicyAssignment -Name 'PolicyAssignment07' -Scope $ResourceGroup.ResourceId -Force
```

The first command gets a resource group named ResourceGroup11 by using the Get-AzResourceGroup cmdlet.
The command stores that object in the $ResourceGroup variable.
The second command removes the policy assignment named PolicyAssignment07 that was assigned at a resource group level.
The **ResourceId** property of $ResourceGroup identifies the resource group.

### Example 2: Remove policy assignment by ID
```powershell
$ResourceGroup = Get-AzResourceGroup -Name 'ResourceGroup11' 
$PolicyAssignment = Get-AzPolicyAssignment -Name 'PolicyAssignment07' -Scope $ResourceGroup.ResourceId
Remove-AzPolicyAssignment -Id $PolicyAssignment.ResourceId -Confirm:$false
```

The first command gets a resource group named ResourceGroup11, and then stores that object in the $ResourceGroup variable.
The second command gets the policy assignment at a resource group level, and then stores it in the $PolicyAssignment variable.
The **ResourceId** property of $ResourceGroup identifies the resource group.
The final command removes the policy assignment that the **ResourceId** property of $PolicyAssignment identifies.

### Example 3: [Backcompat] Remove policy assignment by ID
```powershell
$ResourceGroup = Get-AzResourceGroup -Name 'ResourceGroup11' 
$PolicyAssignment = Get-AzPolicyAssignment -Name 'PolicyAssignment07' -Scope $ResourceGroup.ResourceId
Remove-AzPolicyAssignment -Id $PolicyAssignment.ResourceId -Confirm:$false -BackwardCompatible
True
```

The first command gets a resource group named ResourceGroup11, and then stores that object in the $ResourceGroup variable.
The second command gets the policy assignment at a resource group level, and then stores it in the $PolicyAssignment variable.
The **ResourceId** property of $ResourceGroup identifies the resource group.
The final command removes the policy assignment that the **ResourceId** property of $PolicyAssignment identifies.
