---
external help file: Az.Datadog-help.xml
Module Name: Az.Datadog
online version: https://learn.microsoft.com/powershell/module/az.datadog/new-azdatadogtagrule
schema: 2.0.0
---

# New-AzDatadogTagRule

## SYNOPSIS
Create a tag rule set for a given monitor resource.

## SYNTAX

### CreateExpanded (Default)
```
New-AzDatadogTagRule -MonitorName <String> -Name <String> -ResourceGroupName <String>
 [-SubscriptionId <String>] [-AgentRuleEnableAgentMonitoring] [-AgentRuleFilteringTag <IFilteringTag[]>]
 [-Automuting] [-CustomMetric] [-LogRuleFilteringTag <IFilteringTag[]>] [-LogRuleSendAadLog]
 [-LogRuleSendResourceLog] [-LogRuleSendSubscriptionLog] [-MetricRuleFilteringTag <IFilteringTag[]>]
 [-DefaultProfile <PSObject>] [-WhatIf] [-Confirm] [<CommonParameters>]
```

### CreateViaJsonString
```
New-AzDatadogTagRule -MonitorName <String> -Name <String> -ResourceGroupName <String>
 [-SubscriptionId <String>] -JsonString <String> [-DefaultProfile <PSObject>]
 [-WhatIf] [-Confirm] [<CommonParameters>]
```

### CreateViaJsonFilePath
```
New-AzDatadogTagRule -MonitorName <String> -Name <String> -ResourceGroupName <String>
 [-SubscriptionId <String>] -JsonFilePath <String> [-DefaultProfile <PSObject>]
 [-WhatIf] [-Confirm] [<CommonParameters>]
```

### CreateViaIdentityMonitorExpanded
```
New-AzDatadogTagRule -Name <String> -MonitorInputObject <IDatadogIdentity> [-AgentRuleEnableAgentMonitoring]
 [-AgentRuleFilteringTag <IFilteringTag[]>] [-Automuting] [-CustomMetric]
 [-LogRuleFilteringTag <IFilteringTag[]>] [-LogRuleSendAadLog] [-LogRuleSendResourceLog]
 [-LogRuleSendSubscriptionLog] [-MetricRuleFilteringTag <IFilteringTag[]>] [-DefaultProfile <PSObject>]
 [-WhatIf] [-Confirm] [<CommonParameters>]
```

### CreateViaIdentityExpanded
```
New-AzDatadogTagRule -InputObject <IDatadogIdentity> [-AgentRuleEnableAgentMonitoring]
 [-AgentRuleFilteringTag <IFilteringTag[]>] [-Automuting] [-CustomMetric]
 [-LogRuleFilteringTag <IFilteringTag[]>] [-LogRuleSendAadLog] [-LogRuleSendResourceLog]
 [-LogRuleSendSubscriptionLog] [-MetricRuleFilteringTag <IFilteringTag[]>] [-DefaultProfile <PSObject>]
 [-WhatIf] [-Confirm] [<CommonParameters>]
```

## DESCRIPTION
Create a tag rule set for a given monitor resource.

## EXAMPLES

### Example 1: Create or update a tag rule set for a given monitor resource
```powershell
$ftobjArray = @()
$ftobjArray += New-AzDatadogFilteringTagObject -Action "Include" -Value "Prod" -Name "Environment"
$ftobjArray += New-AzDatadogFilteringTagObject -Action "Exclude" -Value "Dev" -Name "Environment"
New-AzDatadogTagRule -ResourceGroupName azure-rg-Datadog -MonitorName Datadog -Name 'test' -LogRuleFilteringTag $ftobjArray
```

```output
Name    Type
----    ----
default microsoft.Datadog/monitors/tagrules
```

This command creates or updates a tag rule set for a given monitor resource.

### Example 2: Create or update a tag rule set for a given monitor resource by pipeline
```powershell
$ftobjArray = @()
$ftobjArray += New-AzDatadogFilteringTagObject -Action "Include" -Value "Prod" -Name "Environment"
$ftobjArray += New-AzDatadogFilteringTagObject -Action "Exclude" -Value "Dev" -Name "Environment"
Get-AzDatadogTagRule -ResourceGroupName azure-rg-Datadog -MonitorName Datadog -Name 'default' | New-AzDatadogTagRule -LogRuleFilteringTag $ftobjArray
```

```output
Name    Type
----    ----
default microsoft.Datadog/monitors/tagrules
```

This command creates or updates a tag rule set for a given monitor resource by pipeline.

## PARAMETERS

### -AgentRuleEnableAgentMonitoring
Flag specifying if agent monitoring should be enabled for the Monitor resource.

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: CreateExpanded, CreateViaIdentityMonitorExpanded, CreateViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -AgentRuleFilteringTag
List of filtering tags to be used for capturing metrics.
If empty, all resources will be captured.
If only Exclude action is specified, the rules will apply to the list of all available resources.
If Include actions are specified, the rules will only include resources with the associated tags.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Datadog.Models.IFilteringTag[]
Parameter Sets: CreateExpanded, CreateViaIdentityMonitorExpanded, CreateViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Automuting
Configuration to enable/disable auto-muting flag

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: CreateExpanded, CreateViaIdentityMonitorExpanded, CreateViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -CustomMetric
Configuration to enable/disable custom metrics.
If enabled, custom metrics from app insights will be sent.

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: CreateExpanded, CreateViaIdentityMonitorExpanded, CreateViaIdentityExpanded
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
Type: Microsoft.Azure.PowerShell.Cmdlets.Datadog.Models.IDatadogIdentity
Parameter Sets: CreateViaIdentityExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -JsonFilePath
Path of Json file supplied to the Create operation

```yaml
Type: System.String
Parameter Sets: CreateViaJsonFilePath
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -JsonString
Json string supplied to the Create operation

```yaml
Type: System.String
Parameter Sets: CreateViaJsonString
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -LogRuleFilteringTag
List of filtering tags to be used for capturing logs.
This only takes effect if SendResourceLogs flag is enabled.
If empty, all resources will be captured.
If only Exclude action is specified, the rules will apply to the list of all available resources.
If Include actions are specified, the rules will only include resources with the associated tags.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Datadog.Models.IFilteringTag[]
Parameter Sets: CreateExpanded, CreateViaIdentityMonitorExpanded, CreateViaIdentityExpanded
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
Parameter Sets: CreateExpanded, CreateViaIdentityMonitorExpanded, CreateViaIdentityExpanded
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
Parameter Sets: CreateExpanded, CreateViaIdentityMonitorExpanded, CreateViaIdentityExpanded
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
Parameter Sets: CreateExpanded, CreateViaIdentityMonitorExpanded, CreateViaIdentityExpanded
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

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Datadog.Models.IFilteringTag[]
Parameter Sets: CreateExpanded, CreateViaIdentityMonitorExpanded, CreateViaIdentityExpanded
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
Type: Microsoft.Azure.PowerShell.Cmdlets.Datadog.Models.IDatadogIdentity
Parameter Sets: CreateViaIdentityMonitorExpanded
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
Parameter Sets: CreateExpanded, CreateViaJsonString, CreateViaJsonFilePath
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
Parameter Sets: CreateExpanded, CreateViaJsonString, CreateViaJsonFilePath, CreateViaIdentityMonitorExpanded
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
Parameter Sets: CreateExpanded, CreateViaJsonString, CreateViaJsonFilePath
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
Parameter Sets: CreateExpanded, CreateViaJsonString, CreateViaJsonFilePath
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

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.Datadog.Models.IMonitoringTagRules

## NOTES

## RELATED LINKS
