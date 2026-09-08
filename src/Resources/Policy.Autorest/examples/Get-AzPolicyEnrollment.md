### Example 1: Get all policy enrollments
```powershell
Get-AzPolicyEnrollment
```

This command gets all the policy enrollments in the current subscription. If you need to list all enrollments related to the given scope, including those from ancestor scopes and those from descendant scopes, pass the `-IncludeDescendent` parameter.

### Example 2: Get a specific policy enrollment by name and scope
```powershell
$ResourceGroup = Get-AzResourceGroup -Name 'ResourceGroup11'
Get-AzPolicyEnrollment -Name 'PolicyEnrollment07' -Scope $ResourceGroup.ResourceId
```

The first command gets a resource group named ResourceGroup11 by using the Get-AzResourceGroup cmdlet and stores it in the $ResourceGroup variable.
The second command gets the policy enrollment named PolicyEnrollment07 for the scope that the **ResourceId** property of $ResourceGroup identifies.

### Example 3: Get all policy enrollments at management group scope
```powershell
$ManagementGroup = Get-AzManagementGroup -GroupName 'AManagementGroup'
Get-AzPolicyEnrollment -ManagementGroupId $ManagementGroup.Name
```

The first command gets a management group named AManagementGroup by using the Get-AzManagementGroup cmdlet and stores it in the $ManagementGroup variable.
The second command gets all policy enrollments at the management group scope identified by the **Name** property of $ManagementGroup.