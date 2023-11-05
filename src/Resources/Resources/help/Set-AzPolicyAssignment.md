---
external help file: Az.Resources-help.xml
Module Name: Az.Resources
ms.assetid: C3B2C33F-8BD4-4E31-9450-EF6A3A6A5325
online version: https://learn.microsoft.com/powershell/module/az.resources/set-azpolicyassignment
schema: 2.0.0
---

# Set-AzPolicyAssignment

## SYNOPSIS
Modifies a policy assignment.

## SYNTAX

## DESCRIPTION
The **Set-AzPolicyAssignment** cmdlet modifies a policy assignment.
Specify an assignment by ID or by name and scope.

## EXAMPLES

### Example 1: Update the display name
```powershell
$ResourceGroup = Get-AzResourceGroup -Name 'ResourceGroup11'
$PolicyAssignment = Get-AzPolicyAssignment -Name 'PolicyAssignment' -Scope $ResourceGroup.ResourceId
Set-AzPolicyAssignment -Id $PolicyAssignment.ResourceId -DisplayName 'Do not allow VM creation'
```

The first command gets a resource group named ResourceGroup11 by using the Get-AzResourceGroup cmdlet.
The command stores that object in the $ResourceGroup variable.
The second command gets the policy assignment named PolicyAssignment by using the Get-AzPolicyAssignment cmdlet.
The command stores that object in the $PolicyAssignment variable.
The final command updates the display name on the policy assignment on the resource group identified by the **ResourceId** property of $ResourceGroup.

### Example 2: Add a system assigned managed identity to the policy assignment
```powershell
$PolicyAssignment = Get-AzPolicyAssignment -Name 'PolicyAssignment'
Set-AzPolicyAssignment -Id $PolicyAssignment.ResourceId -IdentityType 'SystemAssigned' -Location 'westus'
```

The first command gets the policy assignment named PolicyAssignment from the current subscription by using the Get-AzPolicyAssignment cmdlet.
The command stores that object in the $PolicyAssignment variable.
The final command assigns a system assigned managed identity to the policy assignment.

### Example 3: Add a user assigned managed identity to the policy assignment
```powershell
$PolicyAssignment = Get-AzPolicyAssignment -Name 'PolicyAssignment'
$UserAssignedIdentity = Get-AzUserAssignedIdentity -ResourceGroupName 'ResourceGroup1' -Name 'UserAssignedIdentity1'
 Set-AzPolicyAssignment -Id $PolicyAssignment.ResourceId -IdentityType 'UserAssigned' -Location 'westus' -IdentityId $UserAssignedIdentity.Id
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
Set-AzPolicyAssignment -Id $PolicyAssignment.ResourceId -PolicyParameterObject $AllowedLocations
```

The first and second commands create an object containing all Azure regions whose names start with "france" or "uk".
The second command stores that object in the $AllowedLocations variable.
The third command gets the policy assignment named 'PolicyAssignment'
The command stores that object in the $PolicyAssignment variable.
The final command updates the parameter values on the policy assignment named PolicyAssignment.

### Example 5: Update policy assignment parameters with policy parameter file
<!-- Skip: Output cannot be splitted from code -->
Create a file called _AllowedLocations.json_ in the local working directory with the following content.

```
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
```

```powershell
Set-AzPolicyAssignment -Name 'PolicyAssignment' -PolicyParameter .\AllowedLocations.json
```

The command updates the policy assignment named 'PolicyAssignment' using the policy parameter file AllowedLocations.json from the local working directory.

### Example 6: Update an enforcementMode
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

### Example 7: Update non-compliance messages
```powershell
$PolicyAssignment = Get-AzPolicyAssignment -Name 'VirtualMachinePolicy'
Set-AzPolicyAssignment -Id $PolicyAssignment.ResourceId -NonComplianceMessage @{Message="All resources must follow resource naming guidelines."}
```

The first command gets the policy assignment named VirtualMachinePolicy by using the Get-AzPolicyAssignment cmdlet and stores it in the $PolicyAssignment variable.
The final command updates the non-compliance messages on the policy assignment with a new message that will be displayed if a resource is denied by the policy.

## PARAMETERS

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see [about_CommonParameters](http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

### System.String

### System.String[]

### System.Nullable`1[[Microsoft.Azure.Commands.ResourceManager.Cmdlets.Entities.Policy.PolicyAssignmentEnforcementMode, Microsoft.Azure.PowerShell.Cmdlets.ResourceManager, Version=3.5.0.0, Culture=neutral, PublicKeyToken=null]]

### Microsoft.Azure.Commands.ResourceManager.Cmdlets.Implementation.Policy.PsPolicyAssignment

### Microsoft.Azure.Commands.ResourceManager.Cmdlets.Implementation.Policy.PsNonComplianceMessage[]

## OUTPUTS

### Microsoft.Azure.Commands.ResourceManager.Cmdlets.Implementation.Policy.PsPolicyAssignment

## NOTES

## RELATED LINKS

[Get-AzPolicyAssignment](./Get-AzPolicyAssignment.md)

[New-AzPolicyAssignment](./New-AzPolicyAssignment.md)

[Remove-AzPolicyAssignment](./Remove-AzPolicyAssignment.md)


