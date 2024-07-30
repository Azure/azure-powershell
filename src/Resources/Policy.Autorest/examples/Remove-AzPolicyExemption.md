### Example 1: Remove policy exemption by name and scope
```powershell
$ResourceGroup = Get-AzResourceGroup -Name 'ResourceGroup11'
Remove-AzPolicyExemption -Name 'PolicyExemption07' -Scope $ResourceGroup.ResourceId -Confirm
```

The first command gets a resource group named ResourceGroup11 by using the Get-AzResourceGroup cmdlet.
The command stores that object in the $ResourceGroup variable.
The second command removes the policy exemption named PolicyExemption07 that was assigned at a resource group level.
The **ResourceId** property of $ResourceGroup identifies the resource group.

### Example 2: Remove policy exemption by ID
```powershell
$ResourceGroup = Get-AzResourceGroup -Name 'ResourceGroup11' 
$PolicyExemption = Get-AzPolicyExemption -Name 'PolicyExemption07' -Scope $ResourceGroup.ResourceId
Remove-AzPolicyExemption -Id $PolicyExemption.ResourceId -Confirm
```

The first command gets a resource group named ResourceGroup11, and then stores that object in the $ResourceGroup variable.
The second command gets the policy exemption at a resource group level, and then stores it in the $PolicyExemption variable.
The **ResourceId** property of $ResourceGroup identifies the resource group.
The final command removes the policy exemption that the **ResourceId** property of $PolicyExemption identifies.

### Example 3: [Backcompat] Remove policy exemption by ID
```powershell
$ResourceGroup = Get-AzResourceGroup -Name 'ResourceGroup11' 
$PolicyExemption = Get-AzPolicyExemption -Name 'PolicyExemption07' -Scope $ResourceGroup.ResourceId
Remove-AzPolicyExemption -Id $PolicyExemption.ResourceId -Force -BackwardCompatible
True
```

The first command gets a resource group named ResourceGroup11, and then stores that object in the $ResourceGroup variable.
The second command gets the policy exemption at a resource group level, and then stores it in the $PolicyExemption variable.
The **ResourceId** property of $ResourceGroup identifies the resource group.
The final command removes the policy exemption that the **ResourceId** property of $PolicyExemption identifies.
