### Example 1: Policy exemption at subscription level
```powershell
$Subscription = Get-AzSubscription -SubscriptionName 'Subscription01'
$Assignment = Get-AzPolicyAssignment -Name 'VirtualMachinePolicyAssignment'
New-AzPolicyExemption -Name 'VirtualMachinePolicyExemption' -PolicyAssignment $Assignment -Scope "/subscriptions/$($Subscription.Id)" -ExemptionCategory Waiver
```

The first command gets a subscription named Subscription01 by using the Get-AzSubscription cmdlet and stores it in the $Subscription variable.
The second command gets the policy assignment named VirtualMachinePolicyAssignment by using the Get-AzPolicyAssignment cmdlet and stores it in the $Assignment variable.
The final command exempts the policy assignment in $Assignment at the level of the subscription identified by the subscription scope string.

### Example 2: Policy exemption at resource group level
```powershell
$ResourceGroup = Get-AzResourceGroup -Name 'ResourceGroup11'
$Assignment = Get-AzPolicyAssignment -Name 'VirtualMachinePolicyAssignment'
New-AzPolicyExemption -Name 'VirtualMachinePolicyAssignment' -PolicyAssignment $Assignment -Scope $ResourceGroup.ResourceId -ExemptionCategory Mitigated
```

The first command gets a resource group named ResourceGroup11 by using the Get-AzResourceGroup cmdlet and stores it in the $ResourceGroup variable.
The second command gets the policy assignment named VirtualMachinePolicyAssignment by using the Get-AzPolicyAssignment cmdlet and stores it in the $Assignment variable.
The final command exempts the policy assignment in $Assignment at the level of the resource group identified by the **ResourceId** property of $ResourceGroup.

### Example 3: Policy exemption at management group level
```powershell
$ManagementGroup = Get-AzManagementGroup -GroupName 'AManagementGroup'
$Assignment = Get-AzPolicyAssignment -Name 'VirtualMachinePolicyAssignment'
New-AzPolicyExemption -Name 'VirtualMachinePolicyAssignment' -PolicyAssignment $Assignment -Scope $ManagementGroup.Id -ExemptionCategory Mitigated
```

The first command gets a management group named AManagementGroup by using the Get-AzManagementGroup cmdlet and stores it in the $ManagementGroup variable.
The second command gets the policy assignment named VirtualMachinePolicyAssignment by using the Get-AzPolicyAssignment cmdlet and stores it in the $Assignment variable.
The final command exempts the policy assignment in $Assignment at the level of the management group identified by the **Id** property of $ManagementGroup.

### Example 4: Policy exemption at resource level
```powershell
$VM = Get-AzVM -Name 'SpecialVM'
$Assignment = Get-AzPolicyAssignment -Name 'VirtualMachinePolicyAssignment'
New-AzPolicyExemption -Name 'VirtualMachinePolicyAssignment' -PolicyAssignment $Assignment -Scope $SpecialVM.Id -ExemptionCategory Waiver
```

The first command gets a VM named SpecialVM by using the Get-AzVM cmdlet and stores it in the $VM variable.
The second command gets the policy assignment named VirtualMachinePolicyAssignment by using the Get-AzPolicyAssignment cmdlet and stores it in the $Assignment variable.
The final command exempts the resource identified by the **Id** property of $VM from the policy assignment in $Assignment.
