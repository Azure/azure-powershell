---
external help file:
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

### UpdateExpanded1 (Default)
```
Update-AzPolicyAssignment -Id <String> [-IdentityType <ResourceIdentityType>]
 [-IdentityUserAssignedIdentity <Hashtable>] [-Location <String>] [-Override <IOverride[]>]
 [-ResourceSelector <IResourceSelector[]>] [-DefaultProfile <PSObject>] [-Confirm] [-WhatIf]
 [<CommonParameters>]
```

### UpdateExpanded
```
Update-AzPolicyAssignment -Name <String> -Scope <String> [-IdentityType <ResourceIdentityType>]
 [-IdentityUserAssignedIdentity <Hashtable>] [-Location <String>] [-Override <IOverride[]>]
 [-ResourceSelector <IResourceSelector[]>] [-DefaultProfile <PSObject>] [-Confirm] [-WhatIf]
 [<CommonParameters>]
```

### UpdateViaIdentityExpanded
```
Update-AzPolicyAssignment -InputObject <IPolicyIdentity> [-IdentityType <ResourceIdentityType>]
 [-IdentityUserAssignedIdentity <Hashtable>] [-Location <String>] [-Override <IOverride[]>]
 [-ResourceSelector <IResourceSelector[]>] [-DefaultProfile <PSObject>] [-Confirm] [-WhatIf]
 [<CommonParameters>]
```

### UpdateViaIdentityExpanded1
```
Update-AzPolicyAssignment -InputObject <IPolicyIdentity> [-IdentityType <ResourceIdentityType>]
 [-IdentityUserAssignedIdentity <Hashtable>] [-Location <String>] [-Override <IOverride[]>]
 [-ResourceSelector <IResourceSelector[]>] [-DefaultProfile <PSObject>] [-Confirm] [-WhatIf]
 [<CommonParameters>]
```

## DESCRIPTION
This operation updates a policy assignment with the given scope and name.
Policy assignments apply to all resources contained within their scope.
For example, when you assign a policy at resource group scope, that policy applies to all resources in the group.

## EXAMPLES

### Example 1: {{ Add title here }}
```powershell
{{ Add code here }}
```

```output
{{ Add output here }}
```

{{ Add description here }}

### Example 2: {{ Add title here }}
```powershell
{{ Add code here }}
```

```output
{{ Add output here }}
```

{{ Add description here }}

## PARAMETERS

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

### -Id
The ID of the policy assignment to update.
Use the format '{scope}/providers/Microsoft.Authorization/policyAssignments/{policyAssignmentName}'.

```yaml
Type: System.String
Parameter Sets: UpdateExpanded1
Aliases: PolicyAssignmentId

Required: True
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
Parameter Sets: (All)
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
Parameter Sets: UpdateViaIdentityExpanded, UpdateViaIdentityExpanded1
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
Accept pipeline input: False
Accept wildcard characters: False
```

### -Name
The name of the policy assignment.

```yaml
Type: System.String
Parameter Sets: UpdateExpanded
Aliases: PolicyAssignmentName

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Override
The policy property value override.
To construct, see NOTES section for OVERRIDE properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Policy.Models.ApiV1.IOverride[]
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ResourceSelector
The resource selector list to filter policies by resource properties.
To construct, see NOTES section for RESOURCESELECTOR properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Policy.Models.ApiV1.IResourceSelector[]
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
Parameter Sets: UpdateExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
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

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.Policy.Models.Api20220601.IPolicyAssignment

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

`OVERRIDE <IOverride[]>`: The policy property value override.
  - `[Kind <OverrideKind?>]`: The override kind.
  - `[Selector <ISelector[]>]`: The list of the selector expressions.
    - `[In <String[]>]`: The list of values to filter in.
    - `[Kind <SelectorKind?>]`: The selector kind.
    - `[NotIn <String[]>]`: The list of values to filter out.
  - `[Value <String>]`: The value to override the policy property.

`RESOURCESELECTOR <IResourceSelector[]>`: The resource selector list to filter policies by resource properties.
  - `[Name <String>]`: The name of the resource selector.
  - `[Selector <ISelector[]>]`: The list of the selector expressions.
    - `[In <String[]>]`: The list of values to filter in.
    - `[Kind <SelectorKind?>]`: The selector kind.
    - `[NotIn <String[]>]`: The list of values to filter out.

## RELATED LINKS

