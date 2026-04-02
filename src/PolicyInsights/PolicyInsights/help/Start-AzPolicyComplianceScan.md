---
external help file: Microsoft.Azure.PowerShell.Cmdlets.PolicyInsights.dll-help.xml
Module Name: Az.PolicyInsights
online version: https://learn.microsoft.com/powershell/module/az.policyinsights/start-azpolicycompliancescan
schema: 2.0.0
---

# Start-AzPolicyComplianceScan

## SYNOPSIS
Triggers a policy compliance evaluation for all resources in a subscription or resource group.

## SYNTAX

### SubscriptionScope (Default)
```
Start-AzPolicyComplianceScan [-SubscriptionId <String>] [-DefaultProfile <PSObject>] [-AsJob] [-NoWait]
 [-PassThru] [-ProgressAction <ActionPreference>] [-WhatIf] [-Confirm] [<CommonParameters>]
```

### ResourceGroupScope
```
Start-AzPolicyComplianceScan [-ResourceGroupName <String>] [-DefaultProfile <PSObject>] [-AsJob] [-NoWait]
 [-PassThru] [-ProgressAction <ActionPreference>] [-WhatIf] [-Confirm] [<CommonParameters>]
```

## DESCRIPTION
The **Start-AzPolicyComplianceScan** cmdlet starts a policy compliance evaluation for a subscription or resource group.

All resources within that scope will have their compliance state evaluated against all assigned policies.

## EXAMPLES

### Example 1: Start a compliance scan at subscription scope
```powershell
Start-AzPolicyComplianceScan
```

This command starts a policy compliance evaluation for the active subscription.

### Example 2: Start a compliance scan at resource group scope
```powershell
Start-AzPolicyComplianceScan -ResourceGroupName "myRG"
```

This command starts a policy compliance evaluation for the "myRG" resource group in the active subscription.

### Example 3: Start a compliance scan and wait for it to complete in the background
```powershell
$job = Start-AzPolicyComplianceScan -AsJob
$job | Wait-Job
```

This command starts a policy compliance evaluation for the active subscription as a job, then it waits for the scan to complete.

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
Parameter Sets: ResourceGroupScope
Aliases:

Required: False
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
Parameter Sets: SubscriptionScope
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

## OUTPUTS

### System.Boolean

## NOTES

## RELATED LINKS
