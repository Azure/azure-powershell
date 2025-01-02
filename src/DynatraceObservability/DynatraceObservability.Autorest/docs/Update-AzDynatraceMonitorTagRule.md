---
external help file:
Module Name: Az.DynatraceObservability
online version: https://learn.microsoft.com/powershell/module/az.dynatraceobservability/update-azdynatracemonitortagrule
schema: 2.0.0
---

# Update-AzDynatraceMonitorTagRule

## SYNOPSIS
Update a TagRule

## SYNTAX

### UpdateExpanded (Default)
```
Update-AzDynatraceMonitorTagRule -MonitorName <String> -ResourceGroupName <String> [-SubscriptionId <String>]
 [-LogRuleFilteringTag <IFilteringTag[]>] [-LogRuleSendAadLog <SendAadLogsStatus>]
 [-LogRuleSendActivityLog <SendActivityLogsStatus>] [-LogRuleSendSubscriptionLog <SendSubscriptionLogsStatus>]
 [-MetricRuleFilteringTag <IFilteringTag[]>] [-DefaultProfile <PSObject>] [-Confirm] [-WhatIf]
 [<CommonParameters>]
```

### UpdateViaIdentityExpanded
```
Update-AzDynatraceMonitorTagRule -InputObject <IDynatraceObservabilityIdentity>
 [-LogRuleFilteringTag <IFilteringTag[]>] [-LogRuleSendAadLog <SendAadLogsStatus>]
 [-LogRuleSendActivityLog <SendActivityLogsStatus>] [-LogRuleSendSubscriptionLog <SendSubscriptionLogsStatus>]
 [-MetricRuleFilteringTag <IFilteringTag[]>] [-DefaultProfile <PSObject>] [-Confirm] [-WhatIf]
 [<CommonParameters>]
```

## DESCRIPTION
Update a TagRule

## EXAMPLES

### Example 1: Update a tag rule for the dynatrace monitor
```powershell
$tagFilter = New-AzDynatraceMonitorFilteringTagObject -Action 'Include' -Name 'Environment' -Value 'Prod'
Update-AzDynatraceMonitorTagRule -ResourceGroupName dyobrg -MonitorName dyob-pwsh01 -LogRuleFilteringTag $tagFilter
```

```output
Name    ResourceGroupName ProvisioningState LogRuleSendAadLog
----    ----------------- ----------------- -----------------
default dyobrg            Succeeded         Disabled
```

This command updates a tag rule for the dynatrace monitor.

### Example 2: Update a tag rule for the dynatrace monitor by pipeline
```powershell
$tagFilter = New-AzDynatraceMonitorFilteringTagObject -Action 'Include' -Name 'Environment' -Value 'Prod'
Get-AzDynatraceMonitorTagRule -ResourceGroupName dyobrg -MonitorName dyob-pwsh01 | Update-AzDynatraceMonitorTagRule -LogRuleFilteringTag $tagFilter
```

```output
Name    ResourceGroupName ProvisioningState LogRuleSendAadLog
----    ----------------- ----------------- -----------------
default dyobrg            Succeeded         Disabled
```

This command updates a tag rule for the dynatrace monitor by pipeline.

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

### -InputObject
Identity Parameter
To construct, see NOTES section for INPUTOBJECT properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.DynatraceObservability.Models.IDynatraceObservabilityIdentity
Parameter Sets: UpdateViaIdentityExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -LogRuleFilteringTag
List of filtering tags to be used for capturing logs.
This only takes effect if SendActivityLogs flag is enabled.
If empty, all resources will be captured.If only Exclude action is specified, the rules will apply to the list of all available resources.
If Include actions are specified, the rules will only include resources with the associated tags.
To construct, see NOTES section for LOGRULEFILTERINGTAG properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.DynatraceObservability.Models.Api20210901.IFilteringTag[]
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -LogRuleSendAadLog
Flag specifying if AAD logs should be sent for the Monitor resource.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.DynatraceObservability.Support.SendAadLogsStatus
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -LogRuleSendActivityLog
Flag specifying if activity logs from Azure resources should be sent for the Monitor resource.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.DynatraceObservability.Support.SendActivityLogsStatus
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -LogRuleSendSubscriptionLog
Flag specifying if subscription logs should be sent for the Monitor resource.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.DynatraceObservability.Support.SendSubscriptionLogsStatus
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -MetricRuleFilteringTag
List of filtering tags to be used for capturing metrics.
If empty, all resources will be captured.
If only Exclude action is specified, the rules will apply to the list of all available resources.
If Include actions are specified, the rules will only include resources with the associated tags.
To construct, see NOTES section for METRICRULEFILTERINGTAG properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.DynatraceObservability.Models.Api20210901.IFilteringTag[]
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -MonitorName
Monitor resource name

```yaml
Type: System.String
Parameter Sets: UpdateExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ResourceGroupName
The name of the resource group.
The name is case insensitive.

```yaml
Type: System.String
Parameter Sets: UpdateExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -SubscriptionId
The ID of the target subscription.

```yaml
Type: System.String
Parameter Sets: UpdateExpanded
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

### Microsoft.Azure.PowerShell.Cmdlets.DynatraceObservability.Models.IDynatraceObservabilityIdentity

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.DynatraceObservability.Models.Api20210901.ITagRule

## NOTES

## RELATED LINKS

