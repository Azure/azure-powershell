### Example 1: Update the display name
```powershell
$ResourceGroup = Get-AzResourceGroup -Name 'ResourceGroup11'
$PolicyEnrollment = Get-AzPolicyEnrollment -Name 'PolicyEnrollment07' -Scope $ResourceGroup.ResourceId
Update-AzPolicyEnrollment -Id $PolicyEnrollment.Id -DisplayName 'Enrollment for VM location policy'
```

The first command gets a resource group named ResourceGroup11 by using the Get-AzResourceGroup cmdlet.
The command stores that object in the $ResourceGroup variable.
The second command gets the policy enrollment named PolicyEnrollment07 by using the Get-AzPolicyEnrollment cmdlet.
The command stores that object in the $PolicyEnrollment variable.
The final command updates the display name on the policy enrollment identified by the **Id** property of $PolicyEnrollment.

### Example 2: Update via pipeline
```powershell
$PolicyEnrollment = Get-AzPolicyEnrollment -Name 'PolicyEnrollment07'
$PolicyEnrollment.DisplayName = 'Updated VM Enrollment'
$PolicyEnrollment | Update-AzPolicyEnrollment
```

The first command gets the policy enrollment named PolicyEnrollment07 by using the Get-AzPolicyEnrollment cmdlet and stores it in the $PolicyEnrollment variable.
The second command sets a new display name on the $PolicyEnrollment object.
The final command pipes the modified object to Update-AzPolicyEnrollment to persist the change.

### Example 3: Update the resource selector
```powershell
$ResourceGroup = Get-AzResourceGroup -Name 'ResourceGroup11'
$ResourceSelector = @{Name = "MyLocationSelector"; Selector = @(@{Kind = "resourceLocation"; NotIn = @("eastus", "eastus2")})}
Update-AzPolicyEnrollment -Name 'VirtualMachinePolicyEnrollment' -Scope $ResourceGroup.ResourceId -ResourceSelector $ResourceSelector
```
The first command gets a resource group named ResourceGroup11 by using the Get-AzResourceGroup cmdlet.
The second command creates a resource selector object that limits the enrollment to resources in locations other than East US or East US 2 and stores it in the $ResourceSelector variable.
The final command updates the policy enrollment named VirtualMachinePolicyEnrollment with the resource selector specified by $ResourceSelector.

