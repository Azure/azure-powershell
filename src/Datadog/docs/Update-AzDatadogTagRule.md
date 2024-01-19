---
external help file:
Module Name: Az.Datadog
online version: https://learn.microsoft.com/powershell/module/az.datadog/update-azdatadogtagrule
schema: 2.0.0
---

# Update-AzDatadogTagRule

## SYNOPSIS
Create a tag rule set for a given monitor resource.

## SYNTAX

### UpdateExpanded (Default)
```
Update-AzDatadogTagRule -MonitorName <String> -Name <String> -ResourceGroupName <String>
 [-SubscriptionId <String>] [-LogRuleFilteringTag <IFilteringTag[]>] [-LogRuleSendAadLog]
 [-LogRuleSendResourceLog] [-LogRuleSendSubscriptionLog] [-MetricRuleFilteringTag <IFilteringTag[]>]
 [-DefaultProfile <PSObject>] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### Update
```
Update-AzDatadogTagRule -MonitorName <String> -Name <String> -ResourceGroupName <String>
 -Body <IMonitoringTagRules> [-SubscriptionId <String>] [-DefaultProfile <PSObject>] [-Confirm] [-WhatIf]
 [<CommonParameters>]
```

### UpdateViaIdentity
```
Update-AzDatadogTagRule -InputObject <IDatadogIdentity> -Body <IMonitoringTagRules>
 [-DefaultProfile <PSObject>] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### UpdateViaIdentityExpanded
```
Update-AzDatadogTagRule -InputObject <IDatadogIdentity> [-LogRuleFilteringTag <IFilteringTag[]>]
 [-LogRuleSendAadLog] [-LogRuleSendResourceLog] [-LogRuleSendSubscriptionLog]
 [-MetricRuleFilteringTag <IFilteringTag[]>] [-DefaultProfile <PSObject>] [-Confirm] [-WhatIf]
 [<CommonParameters>]
```

### UpdateViaIdentityMonitor
```
Update-AzDatadogTagRule -MonitorInputObject <IDatadogIdentity> -Name <String> -Body <IMonitoringTagRules>
 [-DefaultProfile <PSObject>] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### UpdateViaIdentityMonitorExpanded
```
Update-AzDatadogTagRule -MonitorInputObject <IDatadogIdentity> -Name <String>
 [-LogRuleFilteringTag <IFilteringTag[]>] [-LogRuleSendAadLog] [-LogRuleSendResourceLog]
 [-LogRuleSendSubscriptionLog] [-MetricRuleFilteringTag <IFilteringTag[]>] [-DefaultProfile <PSObject>]
 [-Confirm] [-WhatIf] [<CommonParameters>]
```

## DESCRIPTION
Create a tag rule set for a given monitor resource.

## EXAMPLES

### Example 1: {{ Add title here }}
```powershell
{{ Add code here }}
```

```output
{{ Add output here (remove the output block if the example doesn't have an output) }}
```

{{ Add description here }}

### Example 2: {{ Add title here }}
```powershell
{{ Add code here }}
```

```output
{{ Add output here (remove the output block if the example doesn't have an output) }}
```

{{ Add description here }}

## PARAMETERS

### -Body
Capture logs and metrics of Azure resources based on ARM tags.
To construct, see NOTES section for BODY properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Datadog.Models.IMonitoringTagRules
Parameter Sets: Update, UpdateViaIdentity, UpdateViaIdentityMonitor
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
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
To construct, see NOTES section for INPUTOBJECT properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Datadog.Models.IDatadogIdentity
Parameter Sets: UpdateViaIdentity, UpdateViaIdentityExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -LogRuleFilteringTag
List of filtering tags to be used for capturing logs.
This only takes effect if SendResourceLogs flag is enabled.
If empty, all resources will be captured.
If only Exclude action is specified, the rules will apply to the list of all available resources.
If Include actions are specified, the rules will only include resources with the associated tags.
To construct, see NOTES section for LOGRULEFILTERINGTAG properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Datadog.Models.IFilteringTag[]
Parameter Sets: UpdateExpanded, UpdateViaIdentityExpanded, UpdateViaIdentityMonitorExpanded
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
Type: System.Management.Automation.SwitchParameter
Parameter Sets: UpdateExpanded, UpdateViaIdentityExpanded, UpdateViaIdentityMonitorExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -LogRuleSendResourceLog
Flag specifying if Azure resource logs should be sent for the Monitor resource.

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: UpdateExpanded, UpdateViaIdentityExpanded, UpdateViaIdentityMonitorExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -LogRuleSendSubscriptionLog
Flag specifying if Azure subscription logs should be sent for the Monitor resource.

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: UpdateExpanded, UpdateViaIdentityExpanded, UpdateViaIdentityMonitorExpanded
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
Type: Microsoft.Azure.PowerShell.Cmdlets.Datadog.Models.IFilteringTag[]
Parameter Sets: UpdateExpanded, UpdateViaIdentityExpanded, UpdateViaIdentityMonitorExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -MonitorInputObject
Identity Parameter
To construct, see NOTES section for MONITORINPUTOBJECT properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Datadog.Models.IDatadogIdentity
Parameter Sets: UpdateViaIdentityMonitor, UpdateViaIdentityMonitorExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -MonitorName
Monitor resource name

```yaml
Type: System.String
Parameter Sets: Update, UpdateExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Name
Rule set name

```yaml
Type: System.String
Parameter Sets: Update, UpdateExpanded, UpdateViaIdentityMonitor, UpdateViaIdentityMonitorExpanded
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
Parameter Sets: Update, UpdateExpanded
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
Parameter Sets: Update, UpdateExpanded
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

### Microsoft.Azure.PowerShell.Cmdlets.Datadog.Models.IDatadogIdentity

### Microsoft.Azure.PowerShell.Cmdlets.Datadog.Models.IMonitoringTagRules

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.Datadog.Models.IMonitoringTagRules

## NOTES

## RELATED LINKS

