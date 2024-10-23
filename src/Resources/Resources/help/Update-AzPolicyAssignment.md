---
external help file: Az.Resources-help.xml
Module Name: Az.Resources
online version: https://learn.microsoft.com/powershell/module/az.resources/update-azpolicyassignment
schema: 2.0.0
---

# Update-AzPolicyAssignment

## SYNOPSIS
This operation updates a policy assignment with the given scope and name.
Policy assignments apply to all resources contained within their scope.
For example, when you assign a policy at resource group scope, that policy applies to all resources in the group.

## SYNTAX

### Name (Default)
```
Update-AzPolicyAssignment -Name <String> [-Scope <String>] [-NotScope <String[]>] [-DisplayName <String>]
 [-Description <String>] [-Metadata <String>] [-Location <String>] [-EnforcementMode <String>]
 [-IdentityType <String>] [-IdentityId <String>] [-NonComplianceMessage <PSObject[]>] [-Override <IOverride[]>]
 [-ResourceSelector <IResourceSelector[]>] [-BackwardCompatible] [-DefaultProfile <PSObject>]
 [-ProgressAction <ActionPreference>] [-WhatIf] [-Confirm] [<CommonParameters>]
```

### NameParameterObject
```
Update-AzPolicyAssignment -Name <String> [-Scope <String>] [-NotScope <String[]>] [-DisplayName <String>]
 [-Description <String>] [-Metadata <String>] [-Location <String>] [-EnforcementMode <String>]
 [-IdentityType <String>] [-IdentityId <String>] [-NonComplianceMessage <PSObject[]>] [-Override <IOverride[]>]
 [-ResourceSelector <IResourceSelector[]>] [-BackwardCompatible] -PolicyParameterObject <PSObject>
 [-DefaultProfile <PSObject>] [-ProgressAction <ActionPreference>] [-WhatIf] [-Confirm] [<CommonParameters>]
```

### NameParameterString
```
Update-AzPolicyAssignment -Name <String> [-Scope <String>] [-NotScope <String[]>] [-DisplayName <String>]
 [-Description <String>] [-Metadata <String>] [-Location <String>] [-EnforcementMode <String>]
 [-IdentityType <String>] [-IdentityId <String>] [-NonComplianceMessage <PSObject[]>] [-Override <IOverride[]>]
 [-ResourceSelector <IResourceSelector[]>] [-BackwardCompatible] -PolicyParameter <String>
 [-DefaultProfile <PSObject>] [-ProgressAction <ActionPreference>] [-WhatIf] [-Confirm] [<CommonParameters>]
```

### Id
```
Update-AzPolicyAssignment -Id <String> [-NotScope <String[]>] [-DisplayName <String>] [-Description <String>]
 [-Metadata <String>] [-Location <String>] [-EnforcementMode <String>] [-IdentityType <String>]
 [-IdentityId <String>] [-NonComplianceMessage <PSObject[]>] [-Override <IOverride[]>]
 [-ResourceSelector <IResourceSelector[]>] [-BackwardCompatible] [-DefaultProfile <PSObject>]
 [-ProgressAction <ActionPreference>] [-WhatIf] [-Confirm] [<CommonParameters>]
```

### IdParameterObject
```
Update-AzPolicyAssignment -Id <String> [-NotScope <String[]>] [-DisplayName <String>] [-Description <String>]
 [-Metadata <String>] [-Location <String>] [-EnforcementMode <String>] [-IdentityType <String>]
 [-IdentityId <String>] [-NonComplianceMessage <PSObject[]>] [-Override <IOverride[]>]
 [-ResourceSelector <IResourceSelector[]>] [-BackwardCompatible] -PolicyParameterObject <PSObject>
 [-DefaultProfile <PSObject>] [-ProgressAction <ActionPreference>] [-WhatIf] [-Confirm] [<CommonParameters>]
```

### IdParameterString
```
Update-AzPolicyAssignment -Id <String> [-NotScope <String[]>] [-DisplayName <String>] [-Description <String>]
 [-Metadata <String>] [-Location <String>] [-EnforcementMode <String>] [-IdentityType <String>]
 [-IdentityId <String>] [-NonComplianceMessage <PSObject[]>] [-Override <IOverride[]>]
 [-ResourceSelector <IResourceSelector[]>] [-BackwardCompatible] -PolicyParameter <String>
 [-DefaultProfile <PSObject>] [-ProgressAction <ActionPreference>] [-WhatIf] [-Confirm] [<CommonParameters>]
```

### InputObject
```
Update-AzPolicyAssignment [-NotScope <String[]>] [-DisplayName <String>] [-Description <String>]
 [-Metadata <String>] [-Location <String>] [-EnforcementMode <String>] [-IdentityType <String>]
 [-IdentityId <String>] [-NonComplianceMessage <PSObject[]>] [-Override <IOverride[]>]
 [-ResourceSelector <IResourceSelector[]>] [-BackwardCompatible] -InputObject <IPolicyAssignment>
 [-DefaultProfile <PSObject>] [-ProgressAction <ActionPreference>] [-WhatIf] [-Confirm] [<CommonParameters>]
```

## DESCRIPTION
This operation updates a policy assignment with the given scope and name.
Policy assignments apply to all resources contained within their scope.
For example, when you assign a policy at resource group scope, that policy applies to all resources in the group.

## EXAMPLES

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

## PARAMETERS

### -BackwardCompatible
Causes cmdlet to return artifacts using legacy format placing policy-specific properties in a property bag object.

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -DefaultProfile
The DefaultProfile parameter is not functional.
Use the SubscriptionId parameter when available if executing the cmdlet against a different subscription.

```yaml
Type: System.Management.Automation.PSObject
Parameter Sets: (All)
Aliases: AzureRMContext, AzureCredential

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Description
This message will be part of response in case of policy violation.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -DisplayName
The display name of the policy assignment.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -EnforcementMode
The policy assignment enforcement mode.
Possible values are Default and DoNotEnforce.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -Id
The ID of the policy assignment to update.
Use the format '{scope}/providers/Microsoft.Authorization/policyAssignments/{policyAssignmentName}'.

```yaml
Type: System.String
Parameter Sets: Id, IdParameterObject, IdParameterString
Aliases: ResourceId, PolicyAssignmentId

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -IdentityId
The user identity associated with the policy.
The user identity dictionary key references will be ARM resource ids in the form: '/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.ManagedIdentity/userAssignedIdentities/{identityName}'.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -IdentityType
The identity type.
This is the only required field when adding a system or user assigned identity to a resource.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -InputObject

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Policy.Models.IPolicyAssignment
Parameter Sets: InputObject
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName, ByValue)
Accept wildcard characters: False
```

### -Location
The location of the policy assignment.
Only required when utilizing managed identity.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -Metadata
The policy assignment metadata.
Metadata is an open ended object and is typically a collection of key value pairs.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -Name
The name of the policy assignment.

```yaml
Type: System.String
Parameter Sets: Name, NameParameterObject, NameParameterString
Aliases: PolicyAssignmentName

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -NonComplianceMessage
The messages that describe why a resource is non-compliant with the policy.
To construct, see NOTES section for NONCOMPLIANCEMESSAGE properties and create a hash table.

```yaml
Type: System.Management.Automation.PSObject[]
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -NotScope
The policy's excluded scopes.

```yaml
Type: System.String[]
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -Override
The policy property value override.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Policy.Models.IOverride[]
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -PolicyParameter
The parameter values for the assigned policy rule.
The keys are the parameter names.

```yaml
Type: System.String
Parameter Sets: NameParameterString, IdParameterString
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -PolicyParameterObject
The parameter values for the assigned policy rule.
The keys are the parameter names.

```yaml
Type: System.Management.Automation.PSObject
Parameter Sets: NameParameterObject, IdParameterObject
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ProgressAction
{{ Fill ProgressAction Description }}

```yaml
Type: System.Management.Automation.ActionPreference
Parameter Sets: (All)
Aliases: proga

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ResourceSelector
The resource selector list to filter policies by resource properties.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Policy.Models.IResourceSelector[]
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Scope
The scope of the policy assignment.
Valid scopes are: management group (format: '/providers/Microsoft.Management/managementGroups/{managementGroup}'), subscription (format: '/subscriptions/{subscriptionId}'), resource group (format: '/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}', or resource (format: '/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/{resourceProviderNamespace}/[{parentResourcePath}/]{resourceType}/{resourceName}'

```yaml
Type: System.String
Parameter Sets: Name, NameParameterObject, NameParameterString
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -Confirm
Prompts you for confirmation before running the cmdlet.

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: (All)
Aliases: cf

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -WhatIf
Shows what would happen if the cmdlet runs.
The cmdlet is not run.

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: (All)
Aliases: wi

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see [about_CommonParameters](http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

### Microsoft.Azure.PowerShell.Cmdlets.Policy.Models.IPolicyAssignment

### System.Management.Automation.PSObject[]

### System.String

### System.String[]

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.Policy.Models.IPolicyAssignment

## NOTES

ALIASES

Set-AzPolicyAssignment

## RELATED LINKS
