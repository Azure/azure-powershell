---
external help file: Az.Resources-help.xml
Module Name: Az.Resources
online version: https://learn.microsoft.com/powershell/module/az.resources/update-azpolicyexemption
schema: 2.0.0
---

# Update-AzPolicyExemption

## SYNOPSIS
This operation updates a policy exemption with the given scope and name.

## SYNTAX

### Name (Default)
```
Update-AzPolicyExemption -Name <String> [-Scope <String>] [-ExemptionCategory <String>]
 [-PolicyDefinitionReferenceId <String[]>] [-DisplayName <String>] [-Description <String>]
 [-ExpiresOn <DateTime>] [-ClearExpiration] [-Metadata <String>] [-ResourceSelector <IResourceSelector[]>]
 [-AssignmentScopeValidation <String>] [-BackwardCompatible] [-DefaultProfile <PSObject>]
 [-ProgressAction <ActionPreference>] [-WhatIf] [-Confirm] [<CommonParameters>]
```

### Id
```
Update-AzPolicyExemption [-ExemptionCategory <String>] [-PolicyDefinitionReferenceId <String[]>] -Id <String>
 [-DisplayName <String>] [-Description <String>] [-ExpiresOn <DateTime>] [-ClearExpiration]
 [-Metadata <String>] [-ResourceSelector <IResourceSelector[]>] [-AssignmentScopeValidation <String>]
 [-BackwardCompatible] [-DefaultProfile <PSObject>] [-ProgressAction <ActionPreference>] [-WhatIf] [-Confirm]
 [<CommonParameters>]
```

### InputObject
```
Update-AzPolicyExemption [-ExemptionCategory <String>] [-PolicyDefinitionReferenceId <String[]>]
 [-DisplayName <String>] [-Description <String>] [-ExpiresOn <DateTime>] [-ClearExpiration]
 [-Metadata <String>] [-ResourceSelector <IResourceSelector[]>] [-AssignmentScopeValidation <String>]
 [-BackwardCompatible] -InputObject <IPolicyExemption> [-DefaultProfile <PSObject>]
 [-ProgressAction <ActionPreference>] [-WhatIf] [-Confirm] [<CommonParameters>]
```

## DESCRIPTION
This operation updates a policy exemption with the given scope and name.

## EXAMPLES

### Example 1: Update the display name
```powershell
$ResourceGroup = Get-AzResourceGroup -Name 'ResourceGroup11'
 $PolicyExemption = Get-AzPolicyExemption -Name 'PolicyExemption07' -Scope $ResourceGroup.ResourceId
Update-AzPolicyExemption -Id $PolicyExemption.ResourceId -DisplayName 'Exempt VM creation limit'
```

The first command gets a resource group named ResourceGroup11 by using the Get-AzResourceGroup cmdlet.
The command stores that object in the $ResourceGroup variable.
The second command gets the policy exemption named PolicyExemption07 by using the Get-AzPolicyExemption cmdlet.
The command stores that object in the $PolicyExemption variable.
The final command updates the display name on the policy exemption on the resource group identified by the **ResourceId** property of $ResourceGroup.

### Example 2: Update the expiration date time
```powershell
$NextMonth = (Get-Date).AddMonths(1)
$PolicyExemption = Get-AzPolicyExemption -Name 'PolicyExemption07'
Update-AzPolicyExemption -Id $PolicyExemption.ResourceId -ExpiresOn $NextMonth
```

The first command gets the current date time by using the Get-Date cmdlet and add 1 month to the current date time
The command stores that object in the $NextMonth variable.
The second command gets the policy exemption named PolicyExemption07 by using the Get-AzPolicyExemption cmdlet.
The command stores that object in the $PolicyExemption variable.
The final command updates the expiration date time for the policy exemption on the default subscription.

### Example 3: Clear the expiration date time
```powershell
$PolicyExemption = Get-AzPolicyExemption -Name 'PolicyExemption07'
Update-AzPolicyExemption -Id $PolicyExemption.ResourceId -ClearExpiration
```

The first command gets the policy exemption named PolicyExemption07 by using the Get-AzPolicyExemption cmdlet.
The command stores that object in the $PolicyExemption variable.
The second command clears the expiration date time for the policy exemption on the default subscription.
The updated exemption will never expire.

### Example 4: Update the expiration category
```powershell
$PolicyExemption = Get-AzPolicyExemption -Name 'PolicyExemption07'
Update-AzPolicyExemption -Id $PolicyExemption.ResourceId -ExemptionCategory Mitigated
```

The first command gets the policy exemption named PolicyExemption07 by using the Get-AzPolicyExemption cmdlet.
The command stores that object in the $PolicyExemption variable.
The second command updates the expiration category for the policy exemption on the default subscription.
The updated exemption will never expire.

The first command gets the current date time by using the Get-Date cmdlet and add 1 month to the current date time
The command stores that object in the $NextMonth variable.
The second command gets the policy exemption named PolicyExemption07 by using the Get-AzPolicyExemption cmdlet.
The command stores that object in the $PolicyExemption variable.
The final command updates the expiration date time for the policy exemption on the default subscription.

### Example 5: Update resource selector
```powershell
$ResourceSelector = @{Name = "MyLocationSelector"; Selector = @(@{Kind = "resourceLocation"; NotIn = @("eastus", "eastus2")})}
Update-AzPolicyExemption -Name 'VirtualMachineExemption' -ResourceSelector $ResourceSelector
```

The first command creates a resource selector object that will be used to specify the exemption should only apply to resources in locations other than East US or East US 2 and stores it in the $ResourceSelector variable.
The final command updates the policy exemption named VirtualMachineExemption with the resource selector specified by $ResourceSelector.

### Example 6: [Backcompat] Clear the expiration date time
```powershell
$PolicyExemption = Get-AzPolicyExemption -Name 'PolicyExemption07'
Set-AzPolicyExemption -Id $PolicyExemption.ResourceId -ClearExpiration
```

The first command gets the policy exemption named PolicyExemption07 by using the Get-AzPolicyExemption cmdlet.
The command stores that object in the $PolicyExemption variable.
The second command clears the expiration date time for the policy exemption on the default subscription.
The updated exemption will never expire.

## PARAMETERS

### -AssignmentScopeValidation
The option whether validate the exemption is at or under the assignment scope.

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

### -ClearExpiration
Indicates whether to clear the expiration date and time of the policy exemption.

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
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

Required: False
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

### -Id
The ID of the policy assignment to delete.
Use the format '{scope}/providers/Microsoft.Authorization/policyAssignments/{policyAssignmentName}'.

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

### -InputObject

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Policy.Models.IPolicyExemption
Parameter Sets: InputObject
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName, ByValue)
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
Parameter Sets: Name
Aliases: PolicyExemptionName

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
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
Parameter Sets: Name
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

### Microsoft.Azure.PowerShell.Cmdlets.Policy.Models.IPolicyExemption

### System.Management.Automation.SwitchParameter

### System.Nullable`1[[System.DateTime, System.Private.CoreLib, Version=8.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e]]

### System.String

### System.String[]

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.Policy.Models.IPolicyExemption

## NOTES

ALIASES

Set-AzPolicyExemption

## RELATED LINKS
