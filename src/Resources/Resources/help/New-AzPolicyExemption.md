---
external help file: Az.Resources-help.xml
Module Name: Az.Resources
online version: https://learn.microsoft.com/powershell/module/az.resources/new-azpolicyexemption
schema: 2.0.0
---

# New-AzPolicyExemption

## SYNOPSIS
Creates or updates a policy exemption.

## SYNTAX

```
New-AzPolicyExemption -Name <String> -ExemptionCategory <String> -PolicyAssignment <PSObject> [-Scope <String>]
 [-PolicyDefinitionReferenceId <String[]>] [-AssignmentScopeValidation <String>] [-DisplayName <String>]
 [-Description <String>] [-ExpiresOn <DateTime>] [-Metadata <String>] [-ResourceSelector <IResourceSelector[]>]
 [-BackwardCompatible] [-DefaultProfile <PSObject>] [-ProgressAction <ActionPreference>] [-WhatIf] [-Confirm]
 [<CommonParameters>]
```

## DESCRIPTION
The **New-AzPolicyExemption** cmdlet creates a policy exemption with the given scope and name.

## EXAMPLES

### Example 1: Policy exemption at subscription level
```powershell
$Subscription = Get-AzSubscription -SubscriptionName 'Subscription01'
$Assignment = Get-AzPolicyAssignment -Name 'VirtualMachinePolicyAssignment'
New-AzPolicyExemption -Name 'VirtualMachinePolicyExemption' -PolicyAssignment $Assignment -Scope "/subscriptions/$($Subscription.Id)" -ExemptionCategory Waiver
```

The first command gets a subscription named Subscription01 by using the Get-AzSubscription cmdlet and stores it in the $Subscription variable.
The second command gets the policy assignment named VirtualMachinePolicyAssignment by using the Get-AzPolicyAssignment cmdlet and stores it in the $Assignment variable.
The final command exempts the policy assignment in $Assignment at the level of the subscription identified by the subscription scope string.

### Example 2: Policy exemption at resource group level
```powershell
$ResourceGroup = Get-AzResourceGroup -Name 'ResourceGroup11'
$Assignment = Get-AzPolicyAssignment -Name 'VirtualMachinePolicyAssignment'
New-AzPolicyExemption -Name 'VirtualMachinePolicyAssignment' -PolicyAssignment $Assignment -Scope $ResourceGroup.ResourceId -ExemptionCategory Mitigated
```

The first command gets a resource group named ResourceGroup11 by using the Get-AzResourceGroup cmdlet and stores it in the $ResourceGroup variable.
The second command gets the policy assignment named VirtualMachinePolicyAssignment by using the Get-AzPolicyAssignment cmdlet and stores it in the $Assignment variable.
The final command exempts the policy assignment in $Assignment at the level of the resource group identified by the **ResourceId** property of $ResourceGroup.

### Example 3: Policy exemption at management group level
```powershell
$ManagementGroup = Get-AzManagementGroup -GroupName 'AManagementGroup'
$Assignment = Get-AzPolicyAssignment -Name 'VirtualMachinePolicyAssignment'
New-AzPolicyExemption -Name 'VirtualMachinePolicyAssignment' -PolicyAssignment $Assignment -Scope $ManagementGroup.Id -ExemptionCategory Mitigated
```

The first command gets a management group named AManagementGroup by using the Get-AzManagementGroup cmdlet and stores it in the $ManagementGroup variable.
The second command gets the policy assignment named VirtualMachinePolicyAssignment by using the Get-AzPolicyAssignment cmdlet and stores it in the $Assignment variable.
The final command exempts the policy assignment in $Assignment at the level of the management group identified by the **Id** property of $ManagementGroup.

### Example 4: Policy exemption at resource level
```powershell
$VM = Get-AzVM -Name 'SpecialVM'
$Assignment = Get-AzPolicyAssignment -Name 'VirtualMachinePolicyAssignment'
New-AzPolicyExemption -Name 'VirtualMachinePolicyAssignment' -PolicyAssignment $Assignment -Scope $SpecialVM.Id -ExemptionCategory Waiver
```

The first command gets a VM named SpecialVM by using the Get-AzVM cmdlet and stores it in the $VM variable.
The second command gets the policy assignment named VirtualMachinePolicyAssignment by using the Get-AzPolicyAssignment cmdlet and stores it in the $Assignment variable.
The final command exempts the resource identified by the **Id** property of $VM from the policy assignment in $Assignment.

### Example 5: Policy exemption with resource selector
```powershell
$Assignment = Get-AzPolicyAssignment -Name 'VirtualMachineAssignment'
$ResourceSelector = @{Name = "MyLocationSelector"; Selector = @(@{Kind = "resourceLocation"; In = @("eastus", "eastus2")})}
New-AzPolicyExemption -Name 'VirtualMachinePolicyExemption' -PolicyAssignment $Assignment -ResourceSelector $ResourceSelector
```

The first command gets the policy assignment named VirtualMachineAssignment by using the Get-AzPolicyAssignment cmdlet and stores it in the $Assignment variable.
The second command creates a resource selector object that will be used to specify the exemption should only apply to resources located in East US or East US 2 and stores it in the $ResourceSelector variable.
The final command creates a policy exemption for the assignment $Assignment with the resource selector specified by $ResourceSelector.

## PARAMETERS

### -AssignmentScopeValidation
Whether to validate the exemption is at or under the assignment scope.

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

### -ExemptionCategory
The policy exemption category

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -ExpiresOn
The expiration date and time (in UTC ISO 8601 format yyyy-MM-ddTHH:mm:ssZ) of the policy exemption.

```yaml
Type: System.Nullable`1[System.DateTime]
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
The name of the policy exemption.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases: PolicyExemptionName

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -PolicyAssignment
The policy assignment id filter.

```yaml
Type: System.Management.Automation.PSObject
Parameter Sets: (All)
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName, ByValue)
Accept wildcard characters: False
```

### -PolicyDefinitionReferenceId
The policy definition reference ID list when the associated policy assignment is for a policy set (initiative).

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
The scope of the policy exemption.
Valid scopes are: management group (format: '/providers/Microsoft.Management/managementGroups/{managementGroup}'), subscription (format: '/subscriptions/{subscriptionId}'), resource group (format: '/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}', or resource (format: '/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/{resourceProviderNamespace}/[{parentResourcePath}/]{resourceType}/{resourceName}'

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

### System.Management.Automation.PSObject

### System.Nullable`1[[System.DateTime, System.Private.CoreLib, Version=8.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e]]

### System.String

### System.String[]

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.Policy.Models.IPolicyExemption

## NOTES

## RELATED LINKS
