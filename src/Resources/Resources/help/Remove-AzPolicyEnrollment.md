---
external help file:
Module Name: Az.Resources
online version: https://learn.microsoft.com/powershell/module/az.resources/remove-azpolicyenrollment
schema: 2.0.0
---

# Remove-AzPolicyEnrollment

## SYNOPSIS
Deletes a policy enrollment.

## SYNTAX

### DeleteByNameAndScope (Default)
```
Remove-AzPolicyEnrollment -Name <String> -Scope <String> [-Force] [-DefaultProfile <PSObject>] [-PassThru]
 [-Confirm] [-WhatIf] [<CommonParameters>]
```

### DeleteById
```
Remove-AzPolicyEnrollment -Id <String> [-Force] [-DefaultProfile <PSObject>] [-PassThru] [-Confirm] [-WhatIf]
 [<CommonParameters>]
```

### DeleteByInputObject
```
Remove-AzPolicyEnrollment -InputObject <IPolicyEnrollment> [-Force] [-DefaultProfile <PSObject>] [-PassThru]
 [-Confirm] [-WhatIf] [<CommonParameters>]
```

## DESCRIPTION
The **Remove-AzPolicyEnrollment** cmdlet deletes a policy enrollment, given its name and the scope it was created in.
The scope of a policy enrollment is the part of its ID preceding '/providers/Microsoft.Authorization/policyEnrollments/{policyEnrollmentName}'.

## EXAMPLES

### Example 1: Remove policy enrollment by name and scope
```powershell
$ResourceGroup = Get-AzResourceGroup -Name 'ResourceGroup11'
Remove-AzPolicyEnrollment -Name 'PolicyEnrollment07' -Scope $ResourceGroup.ResourceId -Confirm
```

The first command gets a resource group named ResourceGroup11 by using the Get-AzResourceGroup cmdlet.
The command stores that object in the $ResourceGroup variable.
The second command removes the policy enrollment named PolicyEnrollment07 at the resource group scope.
The **ResourceId** property of $ResourceGroup identifies the resource group.

### Example 2: Remove policy enrollment by ID
```powershell
$ResourceGroup = Get-AzResourceGroup -Name 'ResourceGroup11'
$PolicyEnrollment = Get-AzPolicyEnrollment -Name 'PolicyEnrollment07' -Scope $ResourceGroup.ResourceId
Remove-AzPolicyEnrollment -Id $PolicyEnrollment.Id -Force
```

The first command gets a resource group named ResourceGroup11, and then stores that object in the $ResourceGroup variable.
The second command gets the policy enrollment at a resource group level, and then stores it in the $PolicyEnrollment variable.
The **ResourceId** property of $ResourceGroup identifies the resource group.
The final command removes the policy enrollment that the **Id** property of $PolicyEnrollment identifies, bypassing the confirmation prompt with the **Force** parameter.

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

### -Force
When $true, skip confirmation prompts

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

### -Id
The ID of the policy enrollment to delete.
Use the format '{scope}/providers/Microsoft.Authorization/policyEnrollments/{policyEnrollmentName}'.

```yaml
Type: System.String
Parameter Sets: DeleteById
Aliases: ResourceId, PolicyEnrollmentId

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -InputObject
The policy enrollment object to delete.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Policy.Models.IPolicyEnrollment
Parameter Sets: DeleteByInputObject
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -Name
The name of the policy enrollment.

```yaml
Type: System.String
Parameter Sets: DeleteByNameAndScope
Aliases: PolicyEnrollmentName

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -PassThru
Returns true when the command succeeds

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

### -Scope
The scope of the policy enrollment.
Valid scopes are: management group (format: '/providers/Microsoft.Management/managementGroups/{managementGroup}'), subscription (format: '/subscriptions/{subscriptionId}'), resource group (format: '/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}'), or resource (format: '/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/{resourceProviderNamespace}/[{parentResourcePath}/]{resourceType}/{resourceName}')

```yaml
Type: System.String
Parameter Sets: DeleteByNameAndScope
Aliases:

Required: True
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

### Microsoft.Azure.PowerShell.Cmdlets.Policy.Models.IPolicyEnrollment

### System.String

## OUTPUTS

### System.Boolean

## NOTES

## RELATED LINKS

