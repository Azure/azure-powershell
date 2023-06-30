---
external help file:
Module Name: Az.Resources
online version: https://learn.microsoft.com/powershell/module/az.resources/new-azpolicyexemption
schema: 2.0.0
---

# New-AzPolicyExemption

## SYNOPSIS
This operation creates or updates a policy exemption with the given scope and name.
Policy exemptions apply to all resources contained within their scope.
For example, when you create a policy exemption at resource group scope for a policy assignment at the same or above level, the exemption exempts to all applicable resources in the resource group.

## SYNTAX

```
New-AzPolicyExemption -Name <String> -Scope <String> -ExemptionCategory <ExemptionCategory>
 -PolicyAssignmentId <String> [-AssignmentScopeValidation <AssignmentScopeValidation>] [-Description <String>]
 [-DisplayName <String>] [-ExpiresOn <DateTime>] [-MetadataTable <IAny>]
 [-PolicyDefinitionReferenceId <String[]>] [-ResourceSelector <IResourceSelector[]>]
 [-DefaultProfile <PSObject>] [-Confirm] [-WhatIf] [<CommonParameters>]
```

## DESCRIPTION
This operation creates or updates a policy exemption with the given scope and name.
Policy exemptions apply to all resources contained within their scope.
For example, when you create a policy exemption at resource group scope for a policy assignment at the same or above level, the exemption exempts to all applicable resources in the resource group.

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

### -AssignmentScopeValidation
The option whether validate the exemption is at or under the assignment scope.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Policy.Support.AssignmentScopeValidation
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
The description of the policy exemption.

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
The display name of the policy exemption.

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

### -ExemptionCategory
The policy exemption category.
Possible values are Waiver and Mitigated.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Policy.Support.ExemptionCategory
Parameter Sets: (All)
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ExpiresOn
The expiration date and time (in UTC ISO 8601 format yyyy-MM-ddTHH:mm:ssZ) of the policy exemption.

```yaml
Type: System.DateTime
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -MetadataTable
The policy exemption metadata.
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
The name of the policy exemption to delete.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases: PolicyExemptionName

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -PolicyAssignmentId
The ID of the policy assignment that is being exempted.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -PolicyDefinitionReferenceId
The policy definition reference ID list when the associated policy assignment is an assignment of a policy set definition.

```yaml
Type: System.String[]
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
The scope of the policy exemption.
Valid scopes are: management group (format: '/providers/Microsoft.Management/managementGroups/{managementGroup}'), subscription (format: '/subscriptions/{subscriptionId}'), resource group (format: '/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}', or resource (format: '/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/{resourceProviderNamespace}/[{parentResourcePath}/]{resourceType}/{resourceName}'

```yaml
Type: System.String
Parameter Sets: (All)
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

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.Policy.Models.Api20220701Preview.IPolicyExemption

## NOTES

ALIASES

Set-AzPolicyExemption

COMPLEX PARAMETER PROPERTIES

To create the parameters described below, construct a hash table containing the appropriate properties. For information on hash tables, run Get-Help about_Hash_Tables.


`RESOURCESELECTOR <IResourceSelector[]>`: The resource selector list to filter policies by resource properties.
  - `[Name <String>]`: The name of the resource selector.
  - `[Selector <ISelector[]>]`: The list of the selector expressions.
    - `[In <String[]>]`: The list of values to filter in.
    - `[Kind <SelectorKind?>]`: The selector kind.
    - `[NotIn <String[]>]`: The list of values to filter out.

## RELATED LINKS

