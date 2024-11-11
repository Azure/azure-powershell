---
external help file: Az.Resources-help.xml
Module Name: Az.Resources
online version: https://learn.microsoft.com/powershell/module/az.resources/get-azpolicyexemption
schema: 2.0.0
---

# Get-AzPolicyExemption

## SYNOPSIS
Gets policy exemptions.

## SYNTAX

### Name (Default)
```
Get-AzPolicyExemption [-Name <String>] [-Scope <String>] [-PolicyAssignmentIdFilter <String>]
 [-BackwardCompatible] [-DefaultProfile <PSObject>] [-ProgressAction <ActionPreference>] [<CommonParameters>]
```

### IncludeDescendent
```
Get-AzPolicyExemption [-Scope <String>] [-IncludeDescendent] [-BackwardCompatible] [-DefaultProfile <PSObject>]
 [-ProgressAction <ActionPreference>] [<CommonParameters>]
```

### Id
```
Get-AzPolicyExemption [-PolicyAssignmentIdFilter <String>] -Id <String> [-BackwardCompatible]
 [-DefaultProfile <PSObject>] [-ProgressAction <ActionPreference>] [<CommonParameters>]
```

## DESCRIPTION
The **Get-AzPolicyExemption** cmdlet gets a collection of policy exemptions or a specific policy exemption identified by name or ID.

## EXAMPLES

### Example 1 Get all policy exemptions
```powershell
Get-AzPolicyExemption
```

This command gets all the policy exemptions in the current subscription.
If you need to list all the exemptions related to the given scope, including those from ancestor scopes and those from descendent scopes you need to pass the `-IncludeDescendent` parameter.

### Example 2: Get a specific policy exemption
```powershell
$ResourceGroup = Get-AzResourceGroup -Name 'ResourceGroup11'
Get-AzPolicyExemption -Name 'PolicyExemption07' -Scope $ResourceGroup.ResourceId
```

The first command gets a resource group named ResourceGroup11 by using the Get-AzResourceGroup cmdlet and stores it in the $ResourceGroup variable.
The second command gets the policy exemption named PolicyExemption07 for the scope that the **ResourceId** property of $ResourceGroup identifies.

### Example 3: Get all policy exemptions associated with a policy assignment
```powershell
$Assignment = Get-AzPolicyAssignment -Name 'PolicyAssignment07'
Get-AzPolicyExemption -PolicyAssignmentIdFilter $Assignment.ResourceId
```

The first command gets a policy assignment named PolicyAssignment07.
The second command gets all of the policy exemptions that are assigned with the policy assignment.

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
The fully qualified resource Id of the exemption.

```yaml
Type: System.String
Parameter Sets: Id
Aliases: ResourceId

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -IncludeDescendent
Causes the list of returned policy exemptions to include all exemptions related to the given scope, including those from ancestor scopes and those from descendent scopes.
If not provided, only exemptions at and above the given scope are included.

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
The name of the policy exemption.

```yaml
Type: System.String
Parameter Sets: Name
Aliases: PolicyExemptionName

Required: False
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -PolicyAssignmentIdFilter
The policy assignment id filter.

```yaml
Type: System.String
Parameter Sets: Name, Id
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
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

### -Scope
The scope of the policy exemption.
Valid scopes are: management group (format: '/providers/Microsoft.Management/managementGroups/{managementGroup}'), subscription (format: '/subscriptions/{subscriptionId}'), resource group (format: '/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}', or resource (format: '/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/{resourceProviderNamespace}/[{parentResourcePath}/]{resourceType}/{resourceName}'

```yaml
Type: System.String
Parameter Sets: Name, IncludeDescendent
Aliases:

Required: False
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

### Microsoft.Azure.PowerShell.Cmdlets.Policy.Models.IPolicyExemption

## NOTES

## RELATED LINKS
