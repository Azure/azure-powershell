---
external help file: Microsoft.Azure.PowerShell.Cmdlets.PolicyInsights.dll-help.xml
Module Name: Az.PolicyInsights
online version: https://learn.microsoft.com/powershell/module/az.policyinsights/stop-azpolicyremediation
schema: 2.0.0
---

# Stop-AzPolicyRemediation

## SYNOPSIS
Cancels an in-progress policy remediation.

## SYNTAX

### CancelBySubscriptionId (Default)
```
Stop-AzPolicyRemediation -Name <String> [-SubscriptionId <String>] [-DefaultProfile <PSObject>] [-AsJob]
 [-NoWait] [-ProgressAction <ActionPreference>] [-WhatIf] [-Confirm] [<CommonParameters>]
```

### CancelByResourceGroup
```
Stop-AzPolicyRemediation -Name <String> [-SubscriptionId <String>] -ResourceGroupName <String>
 [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-ProgressAction <ActionPreference>] [-WhatIf] [-Confirm]
 [<CommonParameters>]
```

### CancelByResourceId
```
Stop-AzPolicyRemediation [-Name <String>] -ResourceId <String> [-DefaultProfile <PSObject>] [-AsJob] [-NoWait]
 [-ProgressAction <ActionPreference>] [-WhatIf] [-Confirm] [<CommonParameters>]
```

### CancelByScope
```
Stop-AzPolicyRemediation -Name <String> -Scope <String> [-DefaultProfile <PSObject>] [-AsJob] [-NoWait]
 [-ProgressAction <ActionPreference>] [-WhatIf] [-Confirm] [<CommonParameters>]
```

### CancelByManagementGroup
```
Stop-AzPolicyRemediation -Name <String> -ManagementGroupId <String> [-DefaultProfile <PSObject>] [-AsJob]
 [-NoWait] [-ProgressAction <ActionPreference>] [-WhatIf] [-Confirm] [<CommonParameters>]
```

### CancelViaIdentity
```
Stop-AzPolicyRemediation -InputObject <IPolicyInsightsIdentity> [-DefaultProfile <PSObject>] [-AsJob] [-NoWait]
 [-ProgressAction <ActionPreference>] [-WhatIf] [-Confirm] [<CommonParameters>]
```

## DESCRIPTION
The **Stop-AzPolicyRemediation** cmdlet cancels an in-progress policy remediation.

Active deployments will be canceled and no new deployments will be created.

## EXAMPLES

### Example 1: Cancel a policy remediation at resource group scope
```powershell
Stop-AzPolicyRemediation -ResourceGroupName "myRG" -Name "remediation1"
```

This command cancels the remediation named 'remediation1' in resource group 'myRG'.

### Example 2: Cancel a management group remediation via piping
```powershell
$remediation = Get-AzPolicyRemediation -ManagementGroupName "mg1" -Name "remediation1"
$remediation | Stop-AzPolicyRemediation
```

This command cancels the remediation named 'remediation1' in management group 'mg1'.

## PARAMETERS

### -AsJob
Run the command as a job.

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
Parameter Sets: CancelViaIdentity
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
Parameter Sets: CancelByManagementGroup
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
Parameter Sets: CancelBySubscriptionId, CancelByResourceGroup, CancelByScope, CancelByManagementGroup
Aliases: RemediationName

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

```yaml
Type: System.String
Parameter Sets: CancelByResourceId
Aliases: RemediationName

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -NoWait
Run the command asynchronously

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

### -ResourceGroupName
Resource group name.

```yaml
Type: System.String
Parameter Sets: CancelByResourceGroup
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
Parameter Sets: CancelByResourceId
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
Parameter Sets: CancelByScope
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
Parameter Sets: CancelBySubscriptionId, CancelByResourceGroup
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

### Microsoft.Azure.PowerShell.Cmdlets.PolicyInsights.Models.IRemediation

## NOTES

## RELATED LINKS
