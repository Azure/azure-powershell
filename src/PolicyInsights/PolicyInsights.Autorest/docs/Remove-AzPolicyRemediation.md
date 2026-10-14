---
external help file:
Module Name: Az.PolicyInsights
online version: https://learn.microsoft.com/powershell/module/az.policyinsights/remove-azpolicyremediation
schema: 2.0.0
---

# Remove-AzPolicyRemediation

## SYNOPSIS
Deletes a policy remediation.

## SYNTAX

### DeleteBySubscriptionId (Default)
```
Remove-AzPolicyRemediation -Name <String> [-SubscriptionId <String>] [-DefaultProfile <PSObject>] [-AllowStop]
 [-AsJob] [-PassThru] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### DeleteByManagementGroup
```
Remove-AzPolicyRemediation -ManagementGroupId <String> -Name <String> [-DefaultProfile <PSObject>]
 [-AllowStop] [-AsJob] [-PassThru] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### DeleteByResourceGroup
```
Remove-AzPolicyRemediation -Name <String> -ResourceGroupName <String> [-SubscriptionId <String>]
 [-DefaultProfile <PSObject>] [-AllowStop] [-AsJob] [-PassThru] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### DeleteByResourceId
```
Remove-AzPolicyRemediation -ResourceId <String> [-Name <String>] [-DefaultProfile <PSObject>] [-AllowStop]
 [-AsJob] [-PassThru] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### DeleteByScope
```
Remove-AzPolicyRemediation -Name <String> -Scope <String> [-DefaultProfile <PSObject>] [-AllowStop] [-AsJob]
 [-PassThru] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### DeleteViaIdentity
```
Remove-AzPolicyRemediation -InputObject <IPolicyInsightsIdentity> [-DefaultProfile <PSObject>] [-AllowStop]
 [-AsJob] [-PassThru] [-Confirm] [-WhatIf] [<CommonParameters>]
```

## DESCRIPTION
The **Remove-AzPolicyRemediation** cmdlet deletes a policy remediation.

The remediation must be in a terminal state in order to be deleted.

However, this cmdlet has a switch that allows it to force a remediation to stop if it's still in progress and then will proceed to delete it.

## EXAMPLES

### Example 1: Delete a policy remediation at resource group scope
```powershell
Remove-AzPolicyRemediation -ResourceGroupName "myRG" -Name "remediation1"
```

This command deletes the remediation named 'remediation1' in resource group 'myRG'.

### Example 2: Delete a management group remediation via piping
```powershell
$remediation = Get-AzPolicyRemediation -ManagementGroupId "mg1" -Name "remediation1"
$remediation | Remove-AzPolicyRemediation -Confirm
```

This command deletes the remediation named 'remediation1' from management group 'mg1'.
A confirmation prompt will be presented before deleting the resource.

### Example 3: Cancel and delete a policy remediation
```powershell
Remove-AzPolicyRemediation -ResourceGroupName "myRG" -Name "remediation1" -AllowStop
```

This command deletes the remediation named 'remediation1' in resource group 'myRG'.
If the remediation is in-progress it will be canceled before being deleted.

## PARAMETERS

### -AllowStop
Allow the remediation to be canceled if it is in-progress.
Harmless if the remediation is already in a terminal state.
Without this switch, the cmdlet will throw an error if the remediation is not in a terminal state.

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

### -AsJob
Run cmdlet in the background.

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

### -InputObject
Identity Parameter

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.PolicyInsights.Models.IPolicyInsightsIdentity
Parameter Sets: DeleteViaIdentity
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -ManagementGroupId
Management group ID.

```yaml
Type: System.String
Parameter Sets: DeleteByManagementGroup
Aliases: ManagementGroupName

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Name
The name of the remediation.

```yaml
Type: System.String
Parameter Sets: DeleteByManagementGroup, DeleteByResourceGroup, DeleteByResourceId, DeleteByScope, DeleteBySubscriptionId
Aliases: RemediationName

Required: True
Position: Named
Default value: None
Accept pipeline input: False
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

### -ResourceGroupName
Resource group name.

```yaml
Type: System.String
Parameter Sets: DeleteByResourceGroup
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ResourceId
ID of the resource that the remediation was made for or full Resource ID of the remediation.

```yaml
Type: System.String
Parameter Sets: DeleteByResourceId
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Scope
Scope of the resource.
E.g.
'/subscriptions/\{subscriptionId}/resourceGroups/\{rgName}'.

```yaml
Type: System.String
Parameter Sets: DeleteByScope
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -SubscriptionId
The ID of the target subscription.
Uses current subscription if one isn't provided.

```yaml
Type: System.String
Parameter Sets: DeleteByResourceGroup, DeleteBySubscriptionId
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

### Microsoft.Azure.PowerShell.Cmdlets.PolicyInsights.Models.IPolicyInsightsIdentity

## OUTPUTS

### System.Boolean

## NOTES

## RELATED LINKS

