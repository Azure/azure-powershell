### Example 1: Get all policy assignments
```powershell
Get-AzPolicyAssignment
```

This command gets all the policy assignments.

### Example 2: Get a specific policy assignment
```powershell
$ResourceGroup = Get-AzResourceGroup -Name 'ResourceGroup11'
Get-AzPolicyAssignment -Name 'PolicyAssignment07' -Scope $ResourceGroup.ResourceId
```

The first command gets a resource group named ResourceGroup11 by using the Get-AzResourceGroup cmdlet and stores it in the $ResourceGroup variable.
The second command gets the policy assignment named PolicyAssignment07 for the scope that the **ResourceId** property of $ResourceGroup identifies.

### Example 3: Get all policy assignments assigned to a management group
```powershell
$mgId = 'myManagementGroup'
Get-AzPolicyAssignment -Scope '/providers/Microsoft.Management/managementgroups/$mgId'
```

The first command specifies the ID of the management group to query.
The second command gets all of the policy assignments that are assigned to the management group with ID 'myManagementGroup'.

### Example 4: Get the scope, policy set definition identifier, and display name of all policy assignments formatted as a list

```powershell
Get-AzPolicyAssignment | Select-Object -Property Scope, PolicyDefinitionID, DisplayName | Format-List
```

This command is useful when you need to find the reader-friendly **DisplayName** property of an Azure
Policy assignment.

### Example 5: [Backcompat] Get the scope, policy set definition identifier, and display name of all policy assignments formatted as a list

```powershell
Get-AzPolicyAssignment -BackwardCompatible | Select-Object -ExpandProperty properties | Select-Object -Property Scope, PolicyDefinitionID, DisplayName | Format-List
```

This command is useful when you need to find the reader-friendly **DisplayName** property of an Azure
Policy assignment.
