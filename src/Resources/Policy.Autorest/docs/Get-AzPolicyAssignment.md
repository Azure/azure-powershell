---
external help file:
Module Name: Az.Resources
online version: https://learn.microsoft.com/powershell/module/az.resources/get-azpolicyassignment
schema: 2.0.0
---

# Get-AzPolicyAssignment

## SYNOPSIS
Gets policy assignments.

## SYNTAX

### Default (Default)
```
Get-AzPolicyAssignment [-BackwardCompatible] [-DefaultProfile <PSObject>] [<CommonParameters>]
```

### Id
```
Get-AzPolicyAssignment -Id <String> [-BackwardCompatible] [-DefaultProfile <PSObject>] [<CommonParameters>]
```

### IncludeDescendent
```
Get-AzPolicyAssignment -IncludeDescendent [-Scope <String>] [-BackwardCompatible] [-DefaultProfile <PSObject>]
 [<CommonParameters>]
```

### Name
```
Get-AzPolicyAssignment -Name <String> [-Scope <String>] [-BackwardCompatible] [-DefaultProfile <PSObject>]
 [<CommonParameters>]
```

### PolicyDefinitionId
```
Get-AzPolicyAssignment -PolicyDefinitionId <String> [-Scope <String>] [-BackwardCompatible]
 [-DefaultProfile <PSObject>] [<CommonParameters>]
```

### Scope
```
Get-AzPolicyAssignment -Scope <String> [-BackwardCompatible] [-DefaultProfile <PSObject>] [<CommonParameters>]
```

## DESCRIPTION
The **Get-AzPolicyAssignment** cmdlet gets all policy assignments or particular assignments.
Identify a policy assignment to get by name and scope or by ID.

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

### -Id
The ID of the policy assignment to get.
Use the format '{scope}/providers/Microsoft.Authorization/policyAssignments/{policyAssignmentName}'.

```yaml
Type: System.String
Parameter Sets: Id
Aliases: ResourceId, PolicyAssignmentId

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -IncludeDescendent
Causes the list of returned policy assignments to include all assignments related to the given scope, including those from ancestor scopes and those from descendent scopes.
If not provided, only assignments at and above the given scope are included.

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: IncludeDescendent
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -Name
The name of the policy assignment to get.

```yaml
Type: System.String
Parameter Sets: Name
Aliases: PolicyAssignmentName

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -PolicyDefinitionId
Get all policy assignments that target the given policy definition [fully qualified] ID.

```yaml
Type: System.String
Parameter Sets: PolicyDefinitionId
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -Scope
The scope of the policy assignment.
Valid scopes are: management group (format: '/providers/Microsoft.Management/managementGroups/{managementGroup}'), subscription (format: '/subscriptions/{subscriptionId}'), resource group (format: '/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}', or resource (format: '/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/{resourceProviderNamespace}/[{parentResourcePath}/]{resourceType}/{resourceName}'

```yaml
Type: System.String
Parameter Sets: IncludeDescendent, Name, PolicyDefinitionId, Scope
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see [about_CommonParameters](http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

### System.Management.Automation.SwitchParameter

### System.String

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.Policy.Models.IPolicyAssignment

## NOTES

## RELATED LINKS

