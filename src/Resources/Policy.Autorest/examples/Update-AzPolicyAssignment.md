### Example 1: Update the display name
```powershell
$ResourceGroup = Get-AzResourceGroup -Name 'ResourceGroup11'
$PolicyAssignment = Get-AzPolicyAssignment -Name 'PolicyAssignment' -Scope $ResourceGroup.ResourceId
Update-AzPolicyAssignment -Id $PolicyAssignment.ResourceId -DisplayName 'Do not allow VM creation'
```

The first command gets a resource group named ResourceGroup11 by using the Get-AzResourceGroup cmdlet.
The command stores that object in the $ResourceGroup variable.
The second command gets the policy assignment named PolicyAssignment by using the Get-AzPolicyAssignment cmdlet.
The command stores that object in the $PolicyAssignment variable.
The final command updates the display name on the policy assignment on the resource group identified by the **ResourceId** property of $ResourceGroup.

### Example 2: Add a system assigned managed identity to the policy assignment
```powershell
$PolicyAssignment = Get-AzPolicyAssignment -Name 'PolicyAssignment'
Update-AzPolicyAssignment -Id $PolicyAssignment.ResourceId -IdentityType 'SystemAssigned' -Location 'westus'
```

The first command gets the policy assignment named PolicyAssignment from the current subscription by using the Get-AzPolicyAssignment cmdlet.
The command stores that object in the $PolicyAssignment variable.
The final command assigns a system assigned managed identity to the policy assignment.

### Example 3: Add a user assigned managed identity to the policy assignment
```powershell
$PolicyAssignment = Get-AzPolicyAssignment -Name 'PolicyAssignment'
$UserAssignedIdentity = Get-AzUserAssignedIdentity -ResourceGroupName 'ResourceGroup1' -Name 'UserAssignedIdentity1'
 Update-AzPolicyAssignment -Id $PolicyAssignment.ResourceId -IdentityType 'UserAssigned' -Location 'westus' -IdentityId $UserAssignedIdentity.Id
```

The first command gets the policy assignment named PolicyAssignment from the current subscription by using the Get-AzPolicyAssignment cmdlet.
The command stores that object in the $PolicyAssignment variable.
The second command gets the user assigned managed identity named UserAssignedIdentity1 by using the Get-AzUserAssignedIdentity cmdlet and stores it in the $UserAssignedIdentity variable.
The final command assigns the user assigned managed identity identified by the **Id** property of $UserAssignedIdentity to the policy assignment.

### Example 4: Update policy assignment parameters with new policy parameter object
```powershell
$Locations = Get-AzLocation | Where-Object {($_.displayname -like 'france*') -or ($_.displayname -like 'uk*')}
$AllowedLocations = @{'listOfAllowedLocations'=($Locations.location)}
$PolicyAssignment = Get-AzPolicyAssignment -Name 'PolicyAssignment'
Update-AzPolicyAssignment -Id $PolicyAssignment.ResourceId -PolicyParameterObject $AllowedLocations
```

The first and second commands create an object containing all Azure regions whose names start with "france" or "uk".
The second command stores that object in the $AllowedLocations variable.
The third command gets the policy assignment named 'PolicyAssignment'
The command stores that object in the $PolicyAssignment variable.
The final command updates the parameter values on the policy assignment named PolicyAssignment.

### Example 5: Update policy assignment parameters with policy parameter file
<!-- Skip: Output cannot be split from code -->
Create a file called _AllowedLocations.json_ in the local working directory with the following content.

```powershell
{
  "listOfAllowedLocations":  {
    "value": [
      "uksouth",
      "ukwest",
      "francecentral",
      "francesouth"
    ]
  }
}

Update-AzPolicyAssignment -Name 'PolicyAssignment' -PolicyParameter .\AllowedLocations.json
```

The command updates the policy assignment named 'PolicyAssignment' using the policy parameter file AllowedLocations.json from the local working directory.

### Example 6: Update an enforcementMode
```powershell
$ResourceGroup = Get-AzResourceGroup -Name 'ResourceGroup11'
$PolicyAssignment = Get-AzPolicyAssignment -Name 'PolicyAssignment' -Scope $ResourceGroup.ResourceId
Update-AzPolicyAssignment -Id $PolicyAssignment.ResourceId -EnforcementMode Default
```

The first command gets a resource group named ResourceGroup11 by using the Get-AzResourceGroup cmdlet.
The command stores that object in the $ResourceGroup variable.
The second command gets the policy assignment named PolicyAssignment by using the Get-AzPolicyAssignment cmdlet.
The command stores that object in the $PolicyAssignment variable.
The final command updates the enforcementMode property on the policy assignment on the resource group identified by the **ResourceId** property of $ResourceGroup.

### Example 7: Update non-compliance messages
```powershell
$PolicyAssignment = Get-AzPolicyAssignment -Name 'VirtualMachinePolicy'
Update-AzPolicyAssignment -Id $PolicyAssignment.ResourceId -NonComplianceMessage @{Message="All resources must follow resource naming guidelines."}
```

The first command gets the policy assignment named VirtualMachinePolicy by using the Get-AzPolicyAssignment cmdlet and stores it in the $PolicyAssignment variable.
The final command updates the non-compliance messages on the policy assignment with a new message that will be displayed if a resource is denied by the policy.

### Example 8: Update resource selector
```powershell
$ResourceSelector = @{Name = "MyLocationSelector"; Selector = @(@{Kind = "resourceLocation"; NotIn = @("eastus", "eastus2")})}
Update-AzPolicyAssignment -Name 'VirtualMachinePolicyAssignment' -ResourceSelector $ResourceSelector
```

The first command creates a resource selector object that will be used to specify the assignment should only apply to resources not located in East US or East US 2 and stores it in the $ResourceSelector variable.
The final command updates the policy assignment named VirtualMachinePolicyAssignment with the resource selector specified by $ResourceSelector.

### Example 9: Update override
```powershell
$Selector = @{Kind = "resourceLocation"; NotIn = @("eastus", "eastus2")}
$Override = @(@{Kind = "policyEffect"; Value = 'Disabled'; Selector = @($Selector)})
Update-AzPolicyAssignment -Name 'VirtualMachinePolicyAssignment' -Override $Override
```

The first command creates a location selector specifying locations other than East US or East US 2 and stores in in the $Selector variable.
The second command creates an override object that will be used to specify that the assigned definition should have a Disabled effect in the locations identified by $Selector.
The final command updates the policy assignment named VirtualMachinePolicyAssignment with the override specified by $Override.

### Example 10: [Backcompat] Update an enforcementMode
```powershell
$ResourceGroup = Get-AzResourceGroup -Name 'ResourceGroup11'
$PolicyAssignment = Get-AzPolicyAssignment -Name 'PolicyAssignment' -Scope $ResourceGroup.ResourceId
Set-AzPolicyAssignment -Id $PolicyAssignment.ResourceId -EnforcementMode Default
```

The first command gets a resource group named ResourceGroup11 by using the Get-AzResourceGroup cmdlet.
The command stores that object in the $ResourceGroup variable.
The second command gets the policy assignment named PolicyAssignment by using the Get-AzPolicyAssignment cmdlet.
The command stores that object in the $PolicyAssignment variable.
The final command updates the enforcementMode property on the policy assignment on the resource group identified by the **ResourceId** property of $ResourceGroup.
