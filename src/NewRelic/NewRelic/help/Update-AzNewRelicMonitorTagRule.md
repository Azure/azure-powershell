---
external help file: Az.NewRelic-help.xml
Module Name: Az.NewRelic
online version: https://learn.microsoft.com/powershell/module/az.newrelic/update-aznewrelicmonitortagrule
schema: 2.0.0
---

# Update-AzNewRelicMonitorTagRule

## SYNOPSIS
Update a TagRule

## SYNTAX

### UpdateExpanded (Default)
```
Update-AzNewRelicMonitorTagRule -MonitorName <String> -ResourceGroupName <String> -RuleSetName <String>
 [-SubscriptionId <String>] [-LogRuleFilteringTag <IFilteringTag[]>] [-LogRuleSendAadLog <String>]
 [-LogRuleSendActivityLog <String>] [-LogRuleSendSubscriptionLog <String>]
 [-MetricRuleFilteringTag <IFilteringTag[]>] [-MetricRuleSendMetric <String>] [-MetricRuleUserEmail <String>]
 [-DefaultProfile <PSObject>] [-WhatIf] [-Confirm] [<CommonParameters>]
```

### UpdateViaJsonString
```
Update-AzNewRelicMonitorTagRule -MonitorName <String> -ResourceGroupName <String> -RuleSetName <String>
 [-SubscriptionId <String>] -JsonString <String> [-DefaultProfile <PSObject>]
 [-WhatIf] [-Confirm] [<CommonParameters>]
```

### UpdateViaJsonFilePath
```
Update-AzNewRelicMonitorTagRule -MonitorName <String> -ResourceGroupName <String> -RuleSetName <String>
 [-SubscriptionId <String>] -JsonFilePath <String> [-DefaultProfile <PSObject>]
 [-WhatIf] [-Confirm] [<CommonParameters>]
```

### UpdateViaIdentityMonitorExpanded
```
Update-AzNewRelicMonitorTagRule -RuleSetName <String> -MonitorInputObject <INewRelicIdentity>
 [-LogRuleFilteringTag <IFilteringTag[]>] [-LogRuleSendAadLog <String>] [-LogRuleSendActivityLog <String>]
 [-LogRuleSendSubscriptionLog <String>] [-MetricRuleFilteringTag <IFilteringTag[]>]
 [-MetricRuleSendMetric <String>] [-MetricRuleUserEmail <String>] [-DefaultProfile <PSObject>]
 [-WhatIf] [-Confirm] [<CommonParameters>]
```

### UpdateViaIdentityExpanded
```
Update-AzNewRelicMonitorTagRule -InputObject <INewRelicIdentity> [-LogRuleFilteringTag <IFilteringTag[]>]
 [-LogRuleSendAadLog <String>] [-LogRuleSendActivityLog <String>] [-LogRuleSendSubscriptionLog <String>]
 [-MetricRuleFilteringTag <IFilteringTag[]>] [-MetricRuleSendMetric <String>] [-MetricRuleUserEmail <String>]
 [-DefaultProfile <PSObject>] [-WhatIf] [-Confirm] [<CommonParameters>]
```

## DESCRIPTION
Update a TagRule

## EXAMPLES

### Example 1: Update specific TagRule with specified monitor resource
```powershell
Update-AzNewRelicMonitorTagRule -MonitorName test-03 -ResourceGroupName ps-test -RuleSetName default -LogRuleSendActivityLog 'Enabled'
```

```output
Name    SystemDataCreatedAt  SystemDataCreatedBy   SystemDataCreatedByType SystemDataLastModifiedAt SystemDataLastModifiedBy SystemDataLastModifiedByType ResourceGroupName RetryAfter
----    -------------------  -------------------   ----------------------- ------------------------ ------------------------ ---------------------------- ----------------- ----------
default 6/28/2023 9:29:45 AM user1@outlook.com User                    6/29/2023 8:12:51 AM     user1@outlook.com    User                         ps-test
```

Update specific TagRule with specified monitor resource

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

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.NewRelic.Models.INewRelicIdentity
Parameter Sets: UpdateViaIdentityExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -JsonFilePath
Path of Json file supplied to the Update operation

```yaml
Type: System.String
Parameter Sets: UpdateViaJsonFilePath
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -JsonString
Json string supplied to the Update operation

```yaml
Type: System.String
Parameter Sets: UpdateViaJsonString
Aliases:

Required: True
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

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.NewRelic.Models.IFilteringTag[]
Parameter Sets: UpdateExpanded, UpdateViaIdentityMonitorExpanded, UpdateViaIdentityExpanded
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
Parameter Sets: UpdateExpanded, UpdateViaIdentityMonitorExpanded, UpdateViaIdentityExpanded
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
Parameter Sets: UpdateExpanded, UpdateViaIdentityMonitorExpanded, UpdateViaIdentityExpanded
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
Parameter Sets: UpdateExpanded, UpdateViaIdentityMonitorExpanded, UpdateViaIdentityExpanded
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
Parameter Sets: UpdateExpanded, UpdateViaIdentityMonitorExpanded, UpdateViaIdentityExpanded
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
Parameter Sets: UpdateExpanded, UpdateViaIdentityMonitorExpanded, UpdateViaIdentityExpanded
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
Parameter Sets: UpdateExpanded, UpdateViaIdentityMonitorExpanded, UpdateViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -MonitorInputObject
Identity Parameter

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.NewRelic.Models.INewRelicIdentity
Parameter Sets: UpdateViaIdentityMonitorExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -MonitorName
Name of the Monitors resource

```yaml
Type: System.String
Parameter Sets: UpdateExpanded, UpdateViaJsonString, UpdateViaJsonFilePath
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
Parameter Sets: UpdateExpanded, UpdateViaJsonString, UpdateViaJsonFilePath
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
Parameter Sets: UpdateExpanded, UpdateViaJsonString, UpdateViaJsonFilePath, UpdateViaIdentityMonitorExpanded
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
Parameter Sets: UpdateExpanded, UpdateViaJsonString, UpdateViaJsonFilePath
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

### Microsoft.Azure.PowerShell.Cmdlets.NewRelic.Models.INewRelicIdentity

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.NewRelic.Models.ITagRule

## NOTES

## RELATED LINKS
