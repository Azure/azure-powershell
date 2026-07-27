### Example 1: Policy enrollment at subscription scope
```powershell
$Subscription = Get-AzSubscription -SubscriptionName 'Subscription01'
$Assignment = Get-AzPolicyAssignment -Name 'VirtualMachinePolicyAssignment'
New-AzPolicyEnrollment -Name 'VirtualMachinePolicyEnrollment' -PolicyAssignmentId $Assignment.Id -Scope "/subscriptions/$($Subscription.Id)" -DisplayName 'VM Policy Enrollment'
```

The first command gets a subscription named Subscription01 by using the Get-AzSubscription cmdlet and stores it in the $Subscription variable.
The second command gets the policy assignment named VirtualMachinePolicyAssignment by using the Get-AzPolicyAssignment cmdlet and stores it in the $Assignment variable. The assignment must have EnforcementMode set to Enroll.
The final command creates the policy enrollment for the assignment in $Assignment at the level of the subscription identified by the subscription scope string.

### Example 2: Policy enrollment at management group scope
```powershell
$ManagementGroup = Get-AzManagementGroup -GroupName 'AManagementGroup'
$Assignment = Get-AzPolicyAssignment -Name 'VirtualMachinePolicyAssignment'
New-AzPolicyEnrollment -Name 'VirtualMachinePolicyEnrollment' -PolicyAssignmentId $Assignment.Id -Scope $ManagementGroup.Id -Description 'Enrollment for VM policy at MG level'
```

The first command gets a management group named AManagementGroup by using the Get-AzManagementGroup cmdlet and stores it in the $ManagementGroup variable.
The second command gets the policy assignment named VirtualMachinePolicyAssignment by using the Get-AzPolicyAssignment cmdlet and stores it in the $Assignment variable. The assignment must have EnforcementMode set to Enroll.
The final command creates the policy enrollment for the assignment in $Assignment at the management group scope identified by the **Id** property of $ManagementGroup.

### Example 3: Policy enrollment with resource selector
```powershell
$subscription = (Get-AzContext).Subscription
$Assignment = Get-AzPolicyAssignment -Name 'VirtualMachinePolicyAssignment'
$ResourceSelector = @{Name = "MyLocationSelector"; Selector = @(@{Kind = "resourceLocation"; In = @("eastus", "eastus2")})}
New-AzPolicyEnrollment -Name 'VirtualMachinePolicyEnrollment' -Scope $subscription.Id -PolicyAssignmentId $Assignment.Id -ResourceSelector $ResourceSelector
```
The first command gets the subscription that the enrollment will be created at, the currently used one.
The second command gets the policy assignment named VirtualMachinePolicyAssignment by using the Get-AzPolicyAssignment cmdlet and stores it in the $Assignment variable.
The third command creates a resource selector object that limits the enrollment to resources located in East US or East US 2 and stores it in the $ResourceSelector variable.
The final command creates the policy enrollment for the assignment in $Assignment with the resource selector specified by $ResourceSelector.