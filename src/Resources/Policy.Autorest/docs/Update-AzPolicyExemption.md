---
external help file:
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
Update-AzPolicyExemption -Name <String> [-ExemptionCategory <String>]
 [-PolicyDefinitionReferenceId <String[]>] [-Scope <String>] [-AssignmentScopeValidation <String>]
 [-BackwardCompatible] [-ClearExpiration] [-Description <String>] [-DisplayName <String>]
 [-ExpiresOn <DateTime?>] [-Metadata <String>] [-DefaultProfile <PSObject>] [-Confirm] [-WhatIf]
 [<CommonParameters>]
```

### Id
```
Update-AzPolicyExemption -Id <String> [-ExemptionCategory <String>] [-PolicyDefinitionReferenceId <String[]>]
 [-AssignmentScopeValidation <String>] [-BackwardCompatible] [-ClearExpiration] [-Description <String>]
 [-DisplayName <String>] [-ExpiresOn <DateTime?>] [-Metadata <String>] [-DefaultProfile <PSObject>] [-Confirm]
 [-WhatIf] [<CommonParameters>]
```

### InputObject
```
Update-AzPolicyExemption -InputObject <IPolicyExemption> [-ExemptionCategory <String>]
 [-PolicyDefinitionReferenceId <String[]>] [-AssignmentScopeValidation <String>] [-BackwardCompatible]
 [-ClearExpiration] [-Description <String>] [-DisplayName <String>] [-ExpiresOn <DateTime?>]
 [-Metadata <String>] [-DefaultProfile <PSObject>] [-Confirm] [-WhatIf] [<CommonParameters>]
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

### Example 5: [Backcompat] Clear the expiration date time
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
Type: System.Nullable`1[[System.DateTime, System.Private.CoreLib, Version=8.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e]]
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
Accept pipeline input: True (ByValue, ByPropertyName)
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

