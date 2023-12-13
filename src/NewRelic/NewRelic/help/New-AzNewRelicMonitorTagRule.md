---
external help file:
Module Name: Az.NewRelic
online version: https://learn.microsoft.com/powershell/module/az.newrelic/new-aznewrelicmonitortagrule
schema: 2.0.0
---

# New-AzNewRelicMonitorTagRule

## SYNOPSIS
Create a TagRule

## SYNTAX

```
New-AzNewRelicMonitorTagRule -MonitorName <String> -ResourceGroupName <String> -RuleSetName <String>
 [-SubscriptionId <String>] [-LogRuleFilteringTag <IFilteringTag[]>] [-LogRuleSendAadLog <SendAadLogsStatus>]
 [-LogRuleSendActivityLog <SendActivityLogsStatus>] [-LogRuleSendSubscriptionLog <SendSubscriptionLogsStatus>]
 [-MetricRuleFilteringTag <IFilteringTag[]>] [-MetricRuleSendMetric <SendMetricsStatus>]
 [-MetricRuleUserEmail <String>] [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-Confirm] [-WhatIf]
 [<CommonParameters>]
```

## DESCRIPTION
Create a TagRule

## EXAMPLES

### Example 1: Create tag rule
```powershell
New-AzNewRelicMonitorTagRule -MonitorName test-01 -ResourceGroupName ps-test -RuleSetName default -LogRuleSendAadLog 'Disabled' -LogRuleSendActivityLog 'Enabled' -LogRuleSendSubscriptionLog 'Disabled' -MetricRuleSendMetric 'Enabled' -MetricRuleUserEmail v-jiaji@outlook.com
```

```output
Name    SystemDataCreatedAt  SystemDataCreatedBy   SystemDataCreatedByType SystemDataLastModifiedAt SystemDataLastModifiedBy SystemDataLastModifiedByType ResourceGroupName RetryAfter
----    -------------------  -------------------   ----------------------- ------------------------ ------------------------ ---------------------------- ----------------- ----------
default 6/28/2023 6:03:14 AM v-jiaji@outlook.com User                    6/28/2023 6:03:14 AM     v-jiaji@outlook.com    User                         ps-test
```

Create monitor tag rule with specified monitor and default name

## PARAMETERS

### -AsJob
Run the command as a job

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

### -LogRuleFilteringTag
List of filtering tags to be used for capturing logs.
This only takes effect if SendActivityLogs flag is enabled.
If empty, all resources will be captured.If only Exclude action is specified, the rules will apply to the list of all available resources.
If Include actions are specified, the rules will only include resources with the associated tags.
To construct, see NOTES section for LOGRULEFILTERINGTAG properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.NewRelic.Models.Api20220701.IFilteringTag[]
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
Type: Microsoft.Azure.PowerShell.Cmdlets.NewRelic.Support.SendAadLogsStatus
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
Type: Microsoft.Azure.PowerShell.Cmdlets.NewRelic.Support.SendActivityLogsStatus
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
Type: Microsoft.Azure.PowerShell.Cmdlets.NewRelic.Support.SendSubscriptionLogsStatus
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
To construct, see NOTES section for METRICRULEFILTERINGTAG properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.NewRelic.Models.Api20220701.IFilteringTag[]
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -MetricRuleSendMetric
Flag specifying if metrics should be sent for the Monitor resource.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.NewRelic.Support.SendMetricsStatus
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -MetricRuleUserEmail
User Email

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

### -MonitorName
Name of the Monitors resource

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: True
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

### -ResourceGroupName
The name of the resource group.
The name is case insensitive.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -RuleSetName
Name of the TagRule

```yaml
Type: System.String
Parameter Sets: (All)
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
Parameter Sets: (All)
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

### Microsoft.Azure.PowerShell.Cmdlets.NewRelic.Models.Api20220701.ITagRule

## NOTES

ALIASES

COMPLEX PARAMETER PROPERTIES

To create the parameters described below, construct a hash table containing the appropriate properties. For information on hash tables, run Get-Help about_Hash_Tables.


`LOGRULEFILTERINGTAG <IFilteringTag[]>`: List of filtering tags to be used for capturing logs. This only takes effect if SendActivityLogs flag is enabled. If empty, all resources will be captured.If only Exclude action is specified, the rules will apply to the list of all available resources. If Include actions are specified, the rules will only include resources with the associated tags.
  - `[Action <TagAction?>]`: Valid actions for a filtering tag. Exclusion takes priority over inclusion.
  - `[Name <String>]`: The name (also known as the key) of the tag.
  - `[Value <String>]`: The value of the tag.

`METRICRULEFILTERINGTAG <IFilteringTag[]>`: List of filtering tags to be used for capturing metrics.
  - `[Action <TagAction?>]`: Valid actions for a filtering tag. Exclusion takes priority over inclusion.
  - `[Name <String>]`: The name (also known as the key) of the tag.
  - `[Value <String>]`: The value of the tag.

## RELATED LINKS

