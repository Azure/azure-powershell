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

### Name (Default)
```
Update-AzPolicyAssignment -Name <String> [-Scope <String>] [-Description <String>] [-DisplayName <String>]
 [-EnforcementMode <String>] [-IdentityId <String>] [-IdentityType <String>] [-Location <String>]
 [-Metadata <String>] [-NonComplianceMessage <PSObject[]>] [-NotScope <String[]>] [-Override <IOverride[]>]
 [-ResourceSelector <IResourceSelector[]>] [-DefaultProfile <PSObject>] [-Confirm] [-WhatIf]
 [<CommonParameters>]
```

### Id
```
Update-AzPolicyAssignment -Id <String> [-Description <String>] [-DisplayName <String>]
 [-EnforcementMode <String>] [-IdentityId <String>] [-IdentityType <String>] [-Location <String>]
 [-Metadata <String>] [-NonComplianceMessage <PSObject[]>] [-NotScope <String[]>] [-Override <IOverride[]>]
 [-ResourceSelector <IResourceSelector[]>] [-DefaultProfile <PSObject>] [-Confirm] [-WhatIf]
 [<CommonParameters>]
```

### IdParameterObject
```
Update-AzPolicyAssignment -Id <String> -PolicyParameterObject <PSObject> [-Description <String>]
 [-DisplayName <String>] [-EnforcementMode <String>] [-IdentityId <String>] [-IdentityType <String>]
 [-Location <String>] [-Metadata <String>] [-NonComplianceMessage <PSObject[]>] [-NotScope <String[]>]
 [-Override <IOverride[]>] [-ResourceSelector <IResourceSelector[]>] [-DefaultProfile <PSObject>] [-Confirm]
 [-WhatIf] [<CommonParameters>]
```

### IdParameterString
```
Update-AzPolicyAssignment -Id <String> -PolicyParameter <String> [-Description <String>]
 [-DisplayName <String>] [-EnforcementMode <String>] [-IdentityId <String>] [-IdentityType <String>]
 [-Location <String>] [-Metadata <String>] [-NonComplianceMessage <PSObject[]>] [-NotScope <String[]>]
 [-Override <IOverride[]>] [-ResourceSelector <IResourceSelector[]>] [-DefaultProfile <PSObject>] [-Confirm]
 [-WhatIf] [<CommonParameters>]
```

### InputObject
```
Update-AzPolicyAssignment -InputObject <IPolicyAssignment> [-Description <String>] [-DisplayName <String>]
 [-EnforcementMode <String>] [-IdentityId <String>] [-IdentityType <String>] [-Location <String>]
 [-Metadata <String>] [-NonComplianceMessage <PSObject[]>] [-NotScope <String[]>] [-Override <IOverride[]>]
 [-ResourceSelector <IResourceSelector[]>] [-DefaultProfile <PSObject>] [-Confirm] [-WhatIf]
 [<CommonParameters>]
```

### NameParameterObject
```
Update-AzPolicyAssignment -Name <String> -PolicyParameterObject <PSObject> [-Scope <String>]
 [-Description <String>] [-DisplayName <String>] [-EnforcementMode <String>] [-IdentityId <String>]
 [-IdentityType <String>] [-Location <String>] [-Metadata <String>] [-NonComplianceMessage <PSObject[]>]
 [-NotScope <String[]>] [-Override <IOverride[]>] [-ResourceSelector <IResourceSelector[]>]
 [-DefaultProfile <PSObject>] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### NameParameterString
```
Update-AzPolicyAssignment -Name <String> -PolicyParameter <String> [-Scope <String>] [-Description <String>]
 [-DisplayName <String>] [-EnforcementMode <String>] [-IdentityId <String>] [-IdentityType <String>]
 [-Location <String>] [-Metadata <String>] [-NonComplianceMessage <PSObject[]>] [-NotScope <String[]>]
 [-Override <IOverride[]>] [-ResourceSelector <IResourceSelector[]>] [-DefaultProfile <PSObject>] [-Confirm]
 [-WhatIf] [<CommonParameters>]
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
{{ Add output here (remove the output block if the example doesn't have an output) }}
```

{{ Add description here }}

### Example 2: {{ Add title here }}
```powershell
{{ Add code here }}
```

```output
{{ Add output here (remove the output block if the example doesn't have an output) }}
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
Possible values are Default, DoNotEnforce, and Enroll.

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
Accept pipeline input: True (ByValue, ByPropertyName)
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
Parameter Sets: IdParameterString, NameParameterString
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
Parameter Sets: IdParameterObject, NameParameterObject
Aliases:

Required: True
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

