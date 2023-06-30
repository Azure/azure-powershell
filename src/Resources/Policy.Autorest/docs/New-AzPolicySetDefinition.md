---
external help file:
Module Name: Az.Resources
online version: https://learn.microsoft.com/powershell/module/az.resources/new-azpolicysetdefinition
schema: 2.0.0
---

# New-AzPolicySetDefinition

## SYNOPSIS
This operation creates or updates a policy set definition in the given subscription with the given name.

## SYNTAX

### CreateExpanded (Default)
```
New-AzPolicySetDefinition -Name <String> [-SubscriptionId <String>] [-Description <String>]
 [-DisplayName <String>] [-MetadataTable <IAny>] [-ParameterTable <Hashtable>]
 [-PolicyDefinition <IPolicyDefinitionReference[]>] [-PolicyDefinitionGroup <IPolicyDefinitionGroup[]>]
 [-PolicyType <PolicyType>] [-DefaultProfile <PSObject>] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### CreateExpanded1
```
New-AzPolicySetDefinition -Name <String> [-Description <String>] [-DisplayName <String>]
 [-MetadataTable <IAny>] [-ParameterTable <Hashtable>] [-PolicyDefinition <IPolicyDefinitionReference[]>]
 [-PolicyDefinitionGroup <IPolicyDefinitionGroup[]>] [-PolicyType <PolicyType>] [-DefaultProfile <PSObject>]
 [-Confirm] [-WhatIf] [<CommonParameters>]
```

### CreateViaIdentityExpanded1
```
New-AzPolicySetDefinition -InputObject <IPolicyIdentity> [-Description <String>] [-DisplayName <String>]
 [-MetadataTable <IAny>] [-ParameterTable <Hashtable>] [-PolicyDefinition <IPolicyDefinitionReference[]>]
 [-PolicyDefinitionGroup <IPolicyDefinitionGroup[]>] [-PolicyType <PolicyType>] [-DefaultProfile <PSObject>]
 [-Confirm] [-WhatIf] [<CommonParameters>]
```

## DESCRIPTION
This operation creates or updates a policy set definition in the given subscription with the given name.

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

### -Description
The policy set definition description.

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

### -DisplayName
The display name of the policy set definition.

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
Identity Parameter
To construct, see NOTES section for INPUTOBJECT properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Policy.Models.IPolicyIdentity
Parameter Sets: CreateViaIdentityExpanded1
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -MetadataTable
The policy set definition metadata.
Metadata is an open ended object and is typically a collection of key value pairs.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Policy.Models.IAny
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Name
The name of the policy set definition to create.

```yaml
Type: System.String
Parameter Sets: CreateExpanded, CreateExpanded1
Aliases: PolicySetDefinitionName

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ParameterTable
The policy set definition parameters that can be used in policy definition references.

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

### -PolicyDefinition
An array of policy definition references.
To construct, see NOTES section for POLICYDEFINITION properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Policy.Models.Api20210601.IPolicyDefinitionReference[]
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -PolicyDefinitionGroup
The metadata describing groups of policy definition references within the policy set definition.
To construct, see NOTES section for POLICYDEFINITIONGROUP properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Policy.Models.Api20210601.IPolicyDefinitionGroup[]
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -PolicyType
The type of policy definition.
Possible values are NotSpecified, BuiltIn, Custom, and Static.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Policy.Support.PolicyType
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -SubscriptionId
The ID of the target subscription.

```yaml
Type: System.String
Parameter Sets: CreateExpanded
Aliases:

Required: False
Position: Named
Default value: (Get-AzContext).Subscription.Id
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

### Microsoft.Azure.PowerShell.Cmdlets.Policy.Models.Api20210601.IPolicySetDefinition

## NOTES

ALIASES

Set-AzPolicySetDefinition

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

`POLICYDEFINITION <IPolicyDefinitionReference[]>`: An array of policy definition references.
  - `PolicyDefinitionId <String>`: The ID of the policy definition or policy set definition.
  - `[GroupName <String[]>]`: The name of the groups that this policy definition reference belongs to.
  - `[Id <String>]`: A unique id (within the policy set definition) for this policy definition reference.
  - `[Parameter <IParameterValues>]`: The parameter values for the referenced policy rule. The keys are the parameter names.
    - `[(Any) <IParameterValuesValue>]`: This indicates any property can be added to this object.

`POLICYDEFINITIONGROUP <IPolicyDefinitionGroup[]>`: The metadata describing groups of policy definition references within the policy set definition.
  - `Name <String>`: The name of the group.
  - `[AdditionalMetadataId <String>]`: A resource ID of a resource that contains additional metadata about the group.
  - `[Category <String>]`: The group's category.
  - `[Description <String>]`: The group's description.
  - `[DisplayName <String>]`: The group's display name.

## RELATED LINKS

