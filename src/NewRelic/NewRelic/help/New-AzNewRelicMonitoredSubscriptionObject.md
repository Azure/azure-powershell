---
external help file: Az.NewRelic-help.xml
Module Name: Az.NewRelic
online version: https://learn.microsoft.com/powershell/module/Az.NewRelic/new-aznewrelicmonitoredsubscriptionobject
schema: 2.0.0
---

# New-AzNewRelicMonitoredSubscriptionObject

## SYNOPSIS
Create an in-memory object for MonitoredSubscription.

## SYNTAX

```
New-AzNewRelicMonitoredSubscriptionObject [-Error <String>] [-LogRuleFilteringTag <IFilteringTag[]>]
 [-LogRuleSendAadLog <String>] [-LogRuleSendActivityLog <String>] [-LogRuleSendSubscriptionLog <String>]
 [-MetricRuleFilteringTag <IFilteringTag[]>] [-MetricRuleSendMetric <String>] [-MetricRuleUserEmail <String>]
 [-Status <String>] [-SubscriptionId <String>] [<CommonParameters>]
```

## DESCRIPTION
Create an in-memory object for MonitoredSubscription.

## EXAMPLES

### Example 1: Create subscription object
```powershell
$includeFT = New-AzNewRelicFilteringTagObject -Action Include -Name testLogRule1 -Value filteringTag1
New-AzNewRelicMonitoredSubscriptionObject -LogRuleFilteringTag $includeFT -LogRuleSendAadLog Enabled -LogRuleSendActivityLog Enabled -LogRuleSendSubscriptionLog Enabled -MetricRuleFilteringTag $includeFT -MetricRuleUserEmail test@testing.com -Status Active -SubscriptionId 00000000-0000-0000-0000-000000000000
```

```output
Error                      : 
LogRuleFilteringTag        : {{
                               "name": "testLogRule1",
                               "value": "filteringTag1",
                               "action": "Include"
                             }}
LogRuleSendAadLog          : Enabled
LogRuleSendActivityLog     : Enabled
LogRuleSendSubscriptionLog : Enabled
MetricRuleFilteringTag     : {{
                               "name": "testLogRule1",
                               "value": "filteringTag1",
                               "action": "Include"
                             }}
MetricRuleSendMetric       : 
MetricRuleUserEmail        : test@testing.com
Status                     : Active
SubscriptionId             : 00000000-0000-0000-0000-000000000000
TagRuleProvisioningState   :
```

This command creates a subscription object.

## PARAMETERS

### -Error
The reason of not monitoring the subscription.

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

### -LogRuleFilteringTag
List of filtering tags to be used for capturing logs.
This only takes effect if SendActivityLogs flag is enabled.
If empty, all resources will be captured.
        If only Exclude action is specified, the rules will apply to the list of all available resources.
If Include actions are specified, the rules will only include resources with the associated tags.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.NewRelic.Models.IFilteringTag[]
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
Type: System.String
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
Type: System.String
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
Type: System.String
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

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.NewRelic.Models.IFilteringTag[]
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
Type: System.String
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -MetricRuleUserEmail
User Email.

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

### -Status
The state of monitoring.

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

### -SubscriptionId
The subscriptionId to be monitored.

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

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see [about_CommonParameters](http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.NewRelic.Models.MonitoredSubscription

## NOTES

## RELATED LINKS
