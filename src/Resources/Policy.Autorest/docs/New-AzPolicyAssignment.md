---
external help file:
Module Name: Az.Resources
online version: https://learn.microsoft.com/powershell/module/az.resources/new-azpolicyassignment
schema: 2.0.0
---

# New-AzPolicyAssignment

## SYNOPSIS
This operation creates or updates a policy assignment with the given scope and name.
Policy assignments apply to all resources contained within their scope.
For example, when you assign a policy at resource group scope, that policy applies to all resources in the group.

## SYNTAX

### Default (Default)
```
New-AzPolicyAssignment -Name <String> [-Scope <String>] [-BackwardCompatible] [-Description <String>]
 [-DisplayName <String>] [-EnforcementMode <EnforcementMode>] [-IdentityId <String>]
 [-IdentityType <ResourceIdentityType>] [-Location <String>] [-Metadata <String>]
 [-NonComplianceMessage <PSObject[]>] [-NotScope <String[]>] [-PolicyDefinition <PSObject>]
 [-PolicySetDefinition <PSObject>] [-DefaultProfile <PSObject>] [<CommonParameters>]
```

### CreateExpanded
```
New-AzPolicyAssignment [-Description <String>] [-DisplayName <String>] [-EnforcementMode <EnforcementMode>]
 [-IdentityType <ResourceIdentityType>] [-IdentityUserAssignedIdentity <Hashtable>] [-Location <String>]
 [-NotScope <String[]>] [-DefaultProfile <PSObject>] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### CreateExpanded1
```
New-AzPolicyAssignment [-Description <String>] [-DisplayName <String>] [-EnforcementMode <EnforcementMode>]
 [-IdentityType <ResourceIdentityType>] [-IdentityUserAssignedIdentity <Hashtable>] [-Location <String>]
 [-NotScope <String[]>] [-DefaultProfile <PSObject>] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### CreateViaIdentityExpanded1
```
New-AzPolicyAssignment -InputObject <IPolicyIdentity> [-Description <String>] [-DisplayName <String>]
 [-EnforcementMode <EnforcementMode>] [-IdentityType <ResourceIdentityType>]
 [-IdentityUserAssignedIdentity <Hashtable>] [-Location <String>] [-NotScope <String[]>]
 [-DefaultProfile <PSObject>] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### ParameterObject
```
New-AzPolicyAssignment -Name <String> -PolicyDefinition <PSObject> -PolicyParameterObject <Hashtable>
 [-Scope <String>] [-BackwardCompatible] [-Description <String>] [-DisplayName <String>]
 [-EnforcementMode <EnforcementMode>] [-IdentityId <String>] [-IdentityType <ResourceIdentityType>]
 [-Location <String>] [-Metadata <String>] [-NonComplianceMessage <PSObject[]>] [-NotScope <String[]>]
 [-PolicySetDefinition <PSObject>] [-DefaultProfile <PSObject>] [<CommonParameters>]
```

### ParameterString
```
New-AzPolicyAssignment -Name <String> -PolicyDefinition <PSObject> -PolicyParameter <String> [-Scope <String>]
 [-BackwardCompatible] [-Description <String>] [-DisplayName <String>] [-EnforcementMode <EnforcementMode>]
 [-IdentityId <String>] [-IdentityType <ResourceIdentityType>] [-Location <String>] [-Metadata <String>]
 [-NonComplianceMessage <PSObject[]>] [-NotScope <String[]>] [-PolicySetDefinition <PSObject>]
 [-DefaultProfile <PSObject>] [<CommonParameters>]
```

### SetParameterObject
```
New-AzPolicyAssignment -Name <String> -PolicyParameterObject <Hashtable> -PolicySetDefinition <PSObject>
 [-Scope <String>] [-BackwardCompatible] [-Description <String>] [-DisplayName <String>]
 [-EnforcementMode <EnforcementMode>] [-IdentityId <String>] [-IdentityType <ResourceIdentityType>]
 [-Location <String>] [-Metadata <String>] [-NonComplianceMessage <PSObject[]>] [-NotScope <String[]>]
 [-PolicyDefinition <PSObject>] [-DefaultProfile <PSObject>] [<CommonParameters>]
```

### SetParameterString
```
New-AzPolicyAssignment -Name <String> -PolicyParameter <String> -PolicySetDefinition <PSObject>
 [-Scope <String>] [-BackwardCompatible] [-Description <String>] [-DisplayName <String>]
 [-EnforcementMode <EnforcementMode>] [-IdentityId <String>] [-IdentityType <ResourceIdentityType>]
 [-Location <String>] [-Metadata <String>] [-NonComplianceMessage <PSObject[]>] [-NotScope <String[]>]
 [-PolicyDefinition <PSObject>] [-DefaultProfile <PSObject>] [<CommonParameters>]
```

## DESCRIPTION
This operation creates or updates a policy assignment with the given scope and name.
Policy assignments apply to all resources contained within their scope.
For example, when you assign a policy at resource group scope, that policy applies to all resources in the group.

## EXAMPLES

### Example 1: Policy assignment at subscription level
```powershell
$Subscription = Get-AzSubscription -SubscriptionName 'Subscription01'
$Policy = Get-AzPolicyDefinition -Name 'VirtualMachinePolicy'
New-AzPolicyAssignment -Name 'VirtualMachinePolicyAssignment' -PolicyDefinition $Policy -Scope "/subscriptions/$($Subscription.Id)"
```

The first command gets a subscription named Subscription01 by using the Get-AzSubscription cmdlet and stores it in the $Subscription variable.
The second command gets the policy definition named VirtualMachinePolicy by using the Get-AzPolicyDefinition cmdlet and stores it in the $Policy variable.
The final command assigns the policy in $Policy at the level of the subscription identified by the subscription scope string.

### Example 2: Policy assignment at resource group level
```powershell
$ResourceGroup = Get-AzResourceGroup -Name 'ResourceGroup11'
$Policy = Get-AzPolicyDefinition -Name 'VirtualMachinePolicy'
New-AzPolicyAssignment -Name 'VirtualMachinePolicyAssignment' -PolicyDefinition $Policy -Scope $ResourceGroup.ResourceId
```

The first command gets a resource group named ResourceGroup11 by using the Get-AzResourceGroup cmdlet and stores it in the $ResourceGroup variable.
The second command gets the policy definition named VirtualMachinePolicy by using the Get-AzPolicyDefinition cmdlet and stores it in the $Policy variable.
The final command assigns the policy in $Policy at the level of the resource group identified by the **ResourceId** property of $ResourceGroup.

### Example 3: Policy assignment at resource group level with policy parameter object
```powershell
$ResourceGroup = Get-AzResourceGroup -Name 'ResourceGroup11'
$Policy = Get-AzPolicyDefinition -BuiltIn | Where-Object {$_.DisplayName -eq 'Allowed locations'}
$Locations = Get-AzLocation | Where-Object displayname -like '*east*'
$AllowedLocations = @{'listOfAllowedLocations'=($Locations.location)}
New-AzPolicyAssignment -Name 'RestrictLocationPolicyAssignment' -PolicyDefinition $Policy -Scope $ResourceGroup.ResourceId -PolicyParameterObject $AllowedLocations
```

The first command gets a resource group named ResourceGroup11 by using the Get-AzResourceGroup cmdlet.
The command stores that object in the $ResourceGroup variable.
The second command gets the built-in policy definition for allowed locations by using the Get-AzPolicyDefinition cmdlet.
The command stores that object in the $Policy variable.
The third and fourth commands create an object containing all Azure regions with "east" in the name.
The commands store that object in the $AllowedLocations variable.
The final command assigns the policy in $Policy at the level of a resource group using the policy parameter object in $AllowedLocations.
The **ResourceId** property of $ResourceGroup identifies the resource group.

### Example 4: Policy assignment at resource group level with policy parameter file
```powershell
{
    "listOfAllowedLocations":  {
      "value": [
        "westus",
        "westeurope",
        "japanwest"
      ]
    }
}

$ResourceGroup = Get-AzResourceGroup -Name 'ResourceGroup11'
$Policy = Get-AzPolicyDefinition -BuiltIn | Where-Object {$_.DisplayName -eq 'Allowed locations'}
New-AzPolicyAssignment -Name 'RestrictLocationPolicyAssignment' -PolicyDefinition $Policy -Scope $ResourceGroup.ResourceId -PolicyParameter .\AllowedLocations.json
```

The first command gets a resource group named ResourceGroup11 by using the Get-AzResourceGroup cmdlet and stores it in the $ResourceGroup variable.
The second command gets the built-in policy definition for allowed locations by using the Get-AzPolicyDefinition cmdlet and stores it in the $Policy variable.
The final command assigns the policy in $Policy at the resource group identified by the **ResourceId** property of $ResourceGroup using the policy parameter file AllowedLocations.json from the local working directory.

### Example 5: Policy assignment with a system assigned managed identity
```powershell
$ResourceGroup = Get-AzResourceGroup -Name 'ResourceGroup11'
$Policy = Get-AzPolicyDefinition -Name 'VirtualMachinePolicy'
New-AzPolicyAssignment -Name 'VirtualMachinePolicyAssignment' -PolicyDefinition $Policy -Scope $ResourceGroup.ResourceId -Location 'eastus' -IdentityType 'SystemAssigned'
```

The first command gets a resource group named ResourceGroup11 by using the Get-AzResourceGroup cmdlet and stores it in the $ResourceGroup variable.
The second command gets the policy definition named VirtualMachinePolicy by using the Get-AzPolicyDefinition cmdlet and stores it in the $Policy variable.
The final command assigns the policy in $Policy to the resource group.
A system assigned managed identity is automatically created and assigned to the policy assignment.

### Example 6: Policy assignment with a user assigned managed identity
```powershell
$ResourceGroup = Get-AzResourceGroup -Name 'ResourceGroup11'
$Policy = Get-AzPolicyDefinition -Name 'VirtualMachinePolicy'
$UserAssignedIdentity = Get-AzUserAssignedIdentity -ResourceGroupName 'ResourceGroup1' -Name 'UserAssignedIdentity1'
New-AzPolicyAssignment -Name 'VirtualMachinePolicyAssignment' -PolicyDefinition $Policy -Scope $ResourceGroup.ResourceId -Location 'eastus' -IdentityType 'UserAssigned' -IdentityId $UserAssignedIdentity.Id
```

The first command gets a resource group named ResourceGroup11 by using the Get-AzResourceGroup cmdlet and stores it in the $ResourceGroup variable.
The second command gets the policy definition named VirtualMachinePolicy by using the Get-AzPolicyDefinition cmdlet and stores it in the $Policy variable.
The third command gets the user assigned managed identity named UserAssignedIdentity1 by using the Get-AzUserAssignedIdentity cmdlet and stores it in the $UserAssignedIdentity variable.
The final command assigns the policy in $Policy to the resource group.
The user assigned managed identity identified by the **Id** property of $UserAssignedIdentity is assigned to the policy assignment by passing the **Id*** property to the IdentityId parameter.

### Example 7: Policy assignment with an enforcement mode property
```powershell
$Subscription = Get-AzSubscription -SubscriptionName 'Subscription01'
$Policy = Get-AzPolicyDefinition -Name 'VirtualMachinePolicy'
New-AzPolicyAssignment -Name 'VirtualMachinePolicyAssignment' -PolicyDefinition $Policy -Scope "/subscriptions/$($Subscription.Id)" -EnforcementMode DoNotEnforce
```

The first command gets a subscription named Subscription01 by using the Get-AzSubscription cmdlet and stores it in the $Subscription variable.
The second command gets the policy definition named VirtualMachinePolicy by using the Get-AzPolicyDefinition cmdlet and stores it in the $Policy variable.
The final command assigns the policy in $Policy at the level of the subscription identified by the subscription scope string.

The assignment is set with an EnforcementMode value of _DoNotEnforce_ i.e.
the policy effect is not enforced during resource creation or update.

### Example 8: Policy assignment with non-compliance messages
```powershell
$PolicySet = Get-AzPolicySetDefinition -Name 'VirtualMachinePolicySet'
$NonComplianceMessages = @(@{Message="Only DsV2 SKUs are allowed."; PolicyDefinitionReferenceId="DefRef1"}, @{Message="Virtual machines must follow cost management best practices."})
New-AzPolicyAssignment -Name 'VirtualMachinePolicyAssignment' -PolicySetDefinition $PolicySet -NonComplianceMessage $NonComplianceMessages
```

The first command gets the policy set definition named VirtualMachinePolicySet by using the Get-AzPolicySetDefinition cmdlet and stores it in the $PolicySet variable.
The second command creates an array of non-compliance messages.
One general purpose message for the entire assignment and one message specific to a SKU restriction policy within the assigned policy set definition.
The final command assigns the policy set definition in $PolicySet to the subscription with two non-compliance messages that will be shown if a resource is denied by policy.

### Example 9: [Backcompat] Policy assignment at resource group level with policy parameter object
```powershell
$ResourceGroup = Get-AzResourceGroup -Name 'ResourceGroup11'
$Policy = Get-AzPolicyDefinition -BuiltIn | Where-Object {$_.Properties.DisplayName -eq 'Allowed locations'}
$Locations = Get-AzLocation | Where-Object displayname -like '*east*'
$AllowedLocations = @{'listOfAllowedLocations'=($Locations.location)}
New-AzPolicyAssignment -Name 'RestrictLocationPolicyAssignment' -PolicyDefinition $Policy -Scope $ResourceGroup.ResourceId -PolicyParameterObject $AllowedLocations
```

The first command gets a resource group named ResourceGroup11 by using the Get-AzResourceGroup cmdlet.
The command stores that object in the $ResourceGroup variable.
The second command gets the built-in policy definition for allowed locations by using the Get-AzPolicyDefinition cmdlet.
The command stores that object in the $Policy variable.
The third and fourth commands create an object containing all Azure regions with "east" in the name.
The commands store that object in the $AllowedLocations variable.
The final command assigns the policy in $Policy at the level of a resource group using the policy parameter object in $AllowedLocations.
The **ResourceId** property of $ResourceGroup identifies the resource group.

### Example 10: [Backcompat] Policy assignment at resource group level with policy parameter file
```powershell
{
    "listOfAllowedLocations":  {
      "value": [
        "westus",
        "westeurope",
        "japanwest"
      ]
    }
}

$ResourceGroup = Get-AzResourceGroup -Name 'ResourceGroup11'
$Policy = Get-AzPolicyDefinition -BuiltIn | Where-Object {$_.Properties.DisplayName -eq 'Allowed locations'}
New-AzPolicyAssignment -Name 'RestrictLocationPolicyAssignment' -PolicyDefinition $Policy -Scope $ResourceGroup.ResourceId -PolicyParameter .\AllowedLocations.json
```

The first command gets a resource group named ResourceGroup11 by using the Get-AzResourceGroup cmdlet and stores it in the $ResourceGroup variable.
The second command gets the built-in policy definition for allowed locations by using the Get-AzPolicyDefinition cmdlet and stores it in the $Policy variable.
The final command assigns the policy in $Policy at the resource group identified by the **ResourceId** property of $ResourceGroup using the policy parameter file AllowedLocations.json from the local working directory.

## PARAMETERS

### -BackwardCompatible
Causes cmdlet to return artifacts using legacy format placing policy-specific properties in a property bag object.

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: Default, ParameterObject, ParameterString, SetParameterObject, SetParameterString
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
Type: Microsoft.Azure.PowerShell.Cmdlets.Policy.Support.EnforcementMode
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -IdentityId
The user identity associated with the policy.
The user identity dictionary key references will be ARM resource ids in the form: '/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.ManagedIdentity/userAssignedIdentities/{identityName}'.

```yaml
Type: System.String
Parameter Sets: Default, ParameterObject, ParameterString, SetParameterObject, SetParameterString
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
Type: Microsoft.Azure.PowerShell.Cmdlets.Policy.Support.ResourceIdentityType
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -IdentityUserAssignedIdentity
The user identity associated with the policy.
The user identity dictionary key references will be ARM resource ids in the form: '/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.ManagedIdentity/userAssignedIdentities/{identityName}'.

```yaml
Type: System.Collections.Hashtable
Parameter Sets: CreateExpanded, CreateExpanded1, CreateViaIdentityExpanded1
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -InputObject
Identity Parameter
To construct, see NOTES section for INPUTOBJECT properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Policy.Models.IPolicyIdentity
Parameter Sets: CreateViaIdentityExpanded1, Default, ParameterObject, ParameterString, SetParameterObject, SetParameterString
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
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
Parameter Sets: Default, ParameterObject, ParameterString, SetParameterObject, SetParameterString
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
Parameter Sets: Default, ParameterObject, ParameterString, SetParameterObject, SetParameterString
Aliases: PolicyAssignmentName

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -NonComplianceMessage
The messages that describe why a resource is non-compliant with the policy.

```yaml
Type: System.Management.Automation.PSObject[]
Parameter Sets: Default, ParameterObject, ParameterString, SetParameterObject, SetParameterString
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

### -PolicyDefinition
The ID of the policy definition or policy set definition being assigned.
To construct, see NOTES section for POLICYDEFINITION properties and create a hash table.

```yaml
Type: System.Management.Automation.PSObject
Parameter Sets: Default, ParameterObject, ParameterString, SetParameterObject, SetParameterString
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue, ByPropertyName)
Accept wildcard characters: False
```

### -PolicyParameter
The parameter values for the assigned policy rule.
The keys are the parameter names.

```yaml
Type: System.String
Parameter Sets: ParameterString, SetParameterString
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
Type: System.Collections.Hashtable
Parameter Sets: ParameterObject, SetParameterObject
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -PolicySetDefinition
The ID of the policy definition or policy set definition being assigned.
To construct, see NOTES section for POLICYSETDEFINITION properties and create a hash table.

```yaml
Type: System.Management.Automation.PSObject
Parameter Sets: Default, ParameterObject, ParameterString, SetParameterObject, SetParameterString
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue, ByPropertyName)
Accept wildcard characters: False
```

### -Scope
The scope of the policy assignment.
Valid scopes are: management group (format: '/providers/Microsoft.Management/managementGroups/{managementGroup}'), subscription (format: '/subscriptions/{subscriptionId}'), resource group (format: '/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}', or resource (format: '/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/{resourceProviderNamespace}/[{parentResourcePath}/]{resourceType}/{resourceName}'

```yaml
Type: System.String
Parameter Sets: Default, ParameterObject, ParameterString, SetParameterObject, SetParameterString
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

### Microsoft.Azure.PowerShell.Cmdlets.Policy.Models.IPolicyIdentity

### Microsoft.Azure.PowerShell.Cmdlets.Policy.Support.EnforcementMode

### System.Management.Automation.PSObject

### System.Management.Automation.PSObject[]

### System.String

### System.String[]

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.Policy.Models.Api20210601.IPolicyAssignment

## NOTES

ALIASES

COMPLEX PARAMETER PROPERTIES

To create the parameters described below, construct a hash table containing the appropriate properties. For information on hash tables, run Get-Help about_Hash_Tables.


`INPUTOBJECT <IPolicyIdentity>`: Identity Parameter
  - `[Id <String>]`: Resource identity path
  - `[ManagementGroupId <String>]`: The ID of the management group.
  - `[ParentResourcePath <String>]`: The parent resource path. Use empty string if there is none.
  - `[PolicyAssignmentId <String>]`: The ID of the policy assignment to delete. Use the format '{scope}/providers/Microsoft.Authorization/policyAssignments/{policyAssignmentName}'.
  - `[PolicyAssignmentName <String>]`: The name of the policy assignment to delete.
  - `[PolicyDefinitionName <String>]`: The name of the policy definition to create.
  - `[PolicyExemptionName <String>]`: The name of the policy exemption to delete.
  - `[PolicySetDefinitionName <String>]`: The name of the policy set definition to create.
  - `[ResourceGroupName <String>]`: The name of the resource group that contains policy assignments.
  - `[ResourceName <String>]`: The name of the resource.
  - `[ResourceProviderNamespace <String>]`: The namespace of the resource provider. For example, the namespace of a virtual machine is Microsoft.Compute (from Microsoft.Compute/virtualMachines)
  - `[ResourceType <String>]`: The resource type name. For example the type name of a web app is 'sites' (from Microsoft.Web/sites).
  - `[Scope <String>]`: The scope of the policy assignment. Valid scopes are: management group (format: '/providers/Microsoft.Management/managementGroups/{managementGroup}'), subscription (format: '/subscriptions/{subscriptionId}'), resource group (format: '/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}', or resource (format: '/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/{resourceProviderNamespace}/[{parentResourcePath}/]{resourceType}/{resourceName}'
  - `[SubscriptionId <String>]`: The ID of the target subscription.

`NONCOMPLIANCEMESSAGETABLE <INonComplianceMessage[]>`: The messages that describe why a resource is non-compliant with the policy.
  - `Message <String>`: A message that describes why a resource is non-compliant with the policy. This is shown in 'deny' error messages and on resource's non-compliant compliance results.
  - `[PolicyDefinitionReferenceId <String>]`: The policy definition reference ID within a policy set definition the message is intended for. This is only applicable if the policy assignment assigns a policy set definition. If this is not provided the message applies to all policies assigned by this policy assignment.

`POLICYDEFINITION <PSObject>`: The ID of the policy definition or policy set definition being assigned.
  - `[Description <String>]`: The policy definition description.
  - `[DisplayName <String>]`: The display name of the policy definition.
  - `[Metadata <IPolicyDefinitionPropertiesMetadata>]`: The policy definition metadata.  Metadata is an open ended object and is typically a collection of key value pairs.
    - `[(Any) <Object>]`: This indicates any property can be added to this object.
  - `[Mode <String>]`: The policy definition mode. Some examples are All, Indexed, Microsoft.KeyVault.Data.
  - `[Parameter <IParameterDefinitions>]`: The parameter definitions for parameters used in the policy rule. The keys are the parameter names.
    - `[(Any) <Object>]`: This indicates any property can be added to this object.
  - `[PolicyRule <IPolicyDefinitionPropertiesPolicyRule>]`: The policy rule.
    - `[(Any) <Object>]`: This indicates any property can be added to this object.
  - `[PolicyType <PolicyType?>]`: The type of policy definition. Possible values are NotSpecified, BuiltIn, Custom, and Static.
  - `[SystemDataCreatedAt <DateTime?>]`: The timestamp of resource creation (UTC).
  - `[SystemDataCreatedBy <String>]`: The identity that created the resource.
  - `[SystemDataCreatedByType <CreatedByType?>]`: The type of identity that created the resource.
  - `[SystemDataLastModifiedAt <DateTime?>]`: The timestamp of resource last modification (UTC)
  - `[SystemDataLastModifiedBy <String>]`: The identity that last modified the resource.
  - `[SystemDataLastModifiedByType <CreatedByType?>]`: The type of identity that last modified the resource.

`POLICYSETDEFINITION <PSObject>`: The ID of the policy definition or policy set definition being assigned.
  - `[Description <String>]`: The policy set definition description.
  - `[DisplayName <String>]`: The display name of the policy set definition.
  - `[Metadata <IPolicySetDefinitionPropertiesMetadata>]`: The policy set definition metadata.  Metadata is an open ended object and is typically a collection of key value pairs.
    - `[(Any) <Object>]`: This indicates any property can be added to this object.
  - `[Parameter <IParameterDefinitions>]`: The policy set definition parameters that can be used in policy definition references.
    - `[(Any) <Object>]`: This indicates any property can be added to this object.
  - `[PolicyDefinition <IPolicyDefinitionReference[]>]`: An array of policy definition references.
    - `PolicyDefinitionId <String>`: The ID of the policy definition or policy set definition.
    - `[GroupName <String[]>]`: The name of the groups that this policy definition reference belongs to.
    - `[Id <String>]`: A unique id (within the policy set definition) for this policy definition reference.
    - `[Parameter <IParameterValues>]`: The parameter values for the referenced policy rule. The keys are the parameter names.
      - `[(Any) <Object>]`: This indicates any property can be added to this object.
  - `[PolicyDefinitionGroup <IPolicyDefinitionGroup[]>]`: The metadata describing groups of policy definition references within the policy set definition.
    - `Name <String>`: The name of the group.
    - `[AdditionalMetadataId <String>]`: A resource ID of a resource that contains additional metadata about the group.
    - `[Category <String>]`: The group's category.
    - `[Description <String>]`: The group's description.
    - `[DisplayName <String>]`: The group's display name.
  - `[PolicyType <PolicyType?>]`: The type of policy definition. Possible values are NotSpecified, BuiltIn, Custom, and Static.
  - `[SystemDataCreatedAt <DateTime?>]`: The timestamp of resource creation (UTC).
  - `[SystemDataCreatedBy <String>]`: The identity that created the resource.
  - `[SystemDataCreatedByType <CreatedByType?>]`: The type of identity that created the resource.
  - `[SystemDataLastModifiedAt <DateTime?>]`: The timestamp of resource last modification (UTC)
  - `[SystemDataLastModifiedBy <String>]`: The identity that last modified the resource.
  - `[SystemDataLastModifiedByType <CreatedByType?>]`: The type of identity that last modified the resource.

## RELATED LINKS

