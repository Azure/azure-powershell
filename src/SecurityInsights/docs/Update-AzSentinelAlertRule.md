---
external help file:
Module Name: Az.SecurityInsights
online version: https://learn.microsoft.com/powershell/module/az.securityinsights/update-azsentinelalertrule
schema: 2.0.0
---

# Update-AzSentinelAlertRule

## SYNOPSIS
Create the alert rule.

## SYNTAX

### UpdateScheduled (Default)
```
Update-AzSentinelAlertRule -ResourceGroupName <String> -RuleId <String> -WorkspaceName <String> -Scheduled
 [-SubscriptionId <String>] [-AlertDescriptionFormat <String>] [-AlertDisplayNameFormat <String>]
 [-AlertRuleTemplateName <String>] [-AlertSeverityColumnName <String>] [-AlertTacticsColumnName <String>]
 [-CreateIncident] [-Description <String>] [-Disabled] [-DisplayName <String>] [-Enabled]
 [-EntityMapping <EntityMapping>] [-EventGroupingSettingAggregationKind <String>]
 [-GroupByAlertDetail <String>] [-GroupByCustomDetail <String[]>] [-GroupByEntity <String>]
 [-GroupingConfigurationEnabled] [-LookbackDuration <TimeSpan>] [-MatchingMethod <String>] [-Query <String>]
 [-QueryFrequency <TimeSpan>] [-QueryPeriod <TimeSpan>] [-ReOpenClosedIncident] [-Severity <String>]
 [-SuppressionDuration <TimeSpan>] [-SuppressionEnabled] [-Tactic <String>] [-TriggerOperator <String>]
 [-TriggerThreshold <Int32>] [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-Confirm] [-WhatIf]
 [<CommonParameters>]
```

### UpdateFusionMLTI
```
Update-AzSentinelAlertRule -ResourceGroupName <String> -RuleId <String> -WorkspaceName <String> -FusionMLorTI
 [-SubscriptionId <String>] [-AlertRuleTemplateName <String>] [-Description <String>] [-Disabled] [-Enabled]
 [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### UpdateMicrosoftSecurityIncidentCreation
```
Update-AzSentinelAlertRule -ResourceGroupName <String> -RuleId <String> -WorkspaceName <String>
 -MicrosoftSecurityIncidentCreation [-SubscriptionId <String>] [-AlertRuleTemplateName <String>]
 [-Description <String>] [-Disabled] [-DisplayNamesExcludeFilter <String>] [-DisplayNamesFilter <String>]
 [-Enabled] [-ProductFilter <String>] [-SeveritiesFilter <String[]>] [-DefaultProfile <PSObject>] [-AsJob]
 [-NoWait] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### UpdateViaIdentityFusionMLTI
```
Update-AzSentinelAlertRule -InputObject <ISecurityInsightsIdentity> -FusionMLorTI
 [-AlertRuleTemplateName <String>] [-Description <String>] [-Disabled] [-Enabled] [-DefaultProfile <PSObject>]
 [-AsJob] [-NoWait] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### UpdateViaIdentityMicrosoftSecurityIncidentCreation
```
Update-AzSentinelAlertRule -InputObject <ISecurityInsightsIdentity> -MicrosoftSecurityIncidentCreation
 [-AlertRuleTemplateName <String>] [-Description <String>] [-Disabled] [-DisplayNamesExcludeFilter <String>]
 [-DisplayNamesFilter <String>] [-Enabled] [-ProductFilter <String>] [-SeveritiesFilter <String[]>]
 [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### UpdateViaIdentityUpdateScheduled
```
Update-AzSentinelAlertRule -InputObject <ISecurityInsightsIdentity> -Scheduled
 [-AlertDescriptionFormat <String>] [-AlertDisplayNameFormat <String>] [-AlertRuleTemplateName <String>]
 [-AlertSeverityColumnName <String>] [-AlertTacticsColumnName <String>] [-CreateIncident]
 [-Description <String>] [-Disabled] [-DisplayName <String>] [-Enabled] [-EntityMapping <EntityMapping>]
 [-EventGroupingSettingAggregationKind <String>] [-GroupByAlertDetail <String>]
 [-GroupByCustomDetail <String[]>] [-GroupByEntity <String>] [-GroupingConfigurationEnabled]
 [-LookbackDuration <TimeSpan>] [-MatchingMethod <String>] [-Query <String>] [-QueryFrequency <TimeSpan>]
 [-QueryPeriod <TimeSpan>] [-ReOpenClosedIncident] [-Severity <String>] [-SuppressionDuration <TimeSpan>]
 [-SuppressionEnabled] [-Tactic <String>] [-TriggerOperator <String>] [-TriggerThreshold <Int32>]
 [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-Confirm] [-WhatIf] [<CommonParameters>]
```

## DESCRIPTION
Create the alert rule.

## EXAMPLES

### Example 1: Update an scheduled alert rule
```powershell
Update-AzSentinelAlertRule -ResourceGroupName "si-jj-test" -WorkspaceName "si-test-ws" -ruleId "727fde97-bd0a-4b6d-a730-9d77fbcdb786" -Query "SecurityAlert | take 2" -Scheduled
```

```output
AlertDetailOverrideAlertDescriptionFormat  : 
AlertDetailOverrideAlertDisplayNameFormat  : 
AlertDetailOverrideAlertDynamicProperty    : 
AlertDetailOverrideAlertSeverityColumnName : 
AlertDetailOverrideAlertTacticsColumnName  : 
AlertRuleTemplateName                      : 
CustomDetail                               : {
                                             }
Description                                : 
DisplayName                                : Powershell Exection Alert (Several Times per Hour)
Enabled                                    : True
EntityMapping                              : 
Etag                                       : "070059b5-0000-0100-0000-64cc9b500000"
EventGroupingSettingAggregationKind        : 
GroupingConfigurationEnabled               : False
GroupingConfigurationGroupByAlertDetail    : 
GroupingConfigurationGroupByCustomDetail   : 
GroupingConfigurationGroupByEntity         : 
GroupingConfigurationLookbackDuration      : 05:00:00
GroupingConfigurationMatchingMethod        : AllEntities
GroupingConfigurationReopenClosedIncident  : False
Id                                         : /subscriptions/9e223dbe-3399-4e19-88eb-0975f02ac87f/resourceGroups/si-jj-test/providers/Microsoft.OperationalInsights/workspaces/s 
                                             i-test-ws/providers/Microsoft.SecurityInsights/alertRules/727fde97-bd0a-4b6d-a730-9d77fbcdb786
IncidentConfigurationCreateIncident        : False
Kind                                       : Scheduled
LastModifiedUtc                            : 8/4/2023 6:31:44 AM
Name                                       : 727fde97-bd0a-4b6d-a730-9d77fbcdb786
Query                                      : SecurityAlert | take 2
QueryFrequency                             : 01:00:00
QueryPeriod                                : 01:00:00
Severity                                   : Low
SuppressionDuration                        : 05:00:00
SuppressionEnabled                         : False
SystemDataCreatedAt                        : 
SystemDataCreatedBy                        : 
SystemDataCreatedByType                    : 
SystemDataLastModifiedAt                   : 
SystemDataLastModifiedBy                   : 
SystemDataLastModifiedByType               : 
Tactic                                     : 
Technique                                  : 
TemplateVersion                            : 
TriggerOperator                            : GreaterThan
TriggerThreshold                           : 10
Type                                       : Microsoft.SecurityInsights/alertRules
```

This command updates a scheduled alert rule

## PARAMETERS

### -AlertDescriptionFormat


```yaml
Type: System.String
Parameter Sets: UpdateScheduled, UpdateViaIdentityUpdateScheduled
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -AlertDisplayNameFormat


```yaml
Type: System.String
Parameter Sets: UpdateScheduled, UpdateViaIdentityUpdateScheduled
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -AlertRuleTemplateName


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

### -AlertSeverityColumnName


```yaml
Type: System.String
Parameter Sets: UpdateScheduled, UpdateViaIdentityUpdateScheduled
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -AlertTacticsColumnName


```yaml
Type: System.String
Parameter Sets: UpdateScheduled, UpdateViaIdentityUpdateScheduled
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

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

### -CreateIncident


```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: UpdateScheduled, UpdateViaIdentityUpdateScheduled
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

### -Description


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

### -Disabled


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

### -DisplayName


```yaml
Type: System.String
Parameter Sets: UpdateScheduled, UpdateViaIdentityUpdateScheduled
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -DisplayNamesExcludeFilter


```yaml
Type: System.String
Parameter Sets: UpdateMicrosoftSecurityIncidentCreation, UpdateViaIdentityMicrosoftSecurityIncidentCreation
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -DisplayNamesFilter


```yaml
Type: System.String
Parameter Sets: UpdateMicrosoftSecurityIncidentCreation, UpdateViaIdentityMicrosoftSecurityIncidentCreation
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Enabled


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

### -EntityMapping
To construct, see NOTES section for ENTITYMAPPING properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.SecurityInsights.Models.EntityMapping
Parameter Sets: UpdateScheduled, UpdateViaIdentityUpdateScheduled
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -EventGroupingSettingAggregationKind


```yaml
Type: System.String
Parameter Sets: UpdateScheduled, UpdateViaIdentityUpdateScheduled
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -FusionMLorTI


```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: UpdateFusionMLTI, UpdateViaIdentityFusionMLTI
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -GroupByAlertDetail


```yaml
Type: System.String
Parameter Sets: UpdateScheduled, UpdateViaIdentityUpdateScheduled
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -GroupByCustomDetail


```yaml
Type: System.String[]
Parameter Sets: UpdateScheduled, UpdateViaIdentityUpdateScheduled
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -GroupByEntity


```yaml
Type: System.String
Parameter Sets: UpdateScheduled, UpdateViaIdentityUpdateScheduled
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -GroupingConfigurationEnabled


```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: UpdateScheduled, UpdateViaIdentityUpdateScheduled
Aliases:

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
Type: Microsoft.Azure.PowerShell.Cmdlets.SecurityInsights.Models.ISecurityInsightsIdentity
Parameter Sets: UpdateViaIdentityFusionMLTI, UpdateViaIdentityMicrosoftSecurityIncidentCreation, UpdateViaIdentityUpdateScheduled
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -LookbackDuration


```yaml
Type: System.TimeSpan
Parameter Sets: UpdateScheduled, UpdateViaIdentityUpdateScheduled
Aliases:

Required: False
Position: Named
Default value: New-TimeSpan -Hours 5
Accept pipeline input: False
Accept wildcard characters: False
```

### -MatchingMethod


```yaml
Type: System.String
Parameter Sets: UpdateScheduled, UpdateViaIdentityUpdateScheduled
Aliases:

Required: False
Position: Named
Default value: "AllEntities"
Accept pipeline input: False
Accept wildcard characters: False
```

### -MicrosoftSecurityIncidentCreation


```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: UpdateMicrosoftSecurityIncidentCreation, UpdateViaIdentityMicrosoftSecurityIncidentCreation
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

### -ProductFilter


```yaml
Type: System.String
Parameter Sets: UpdateMicrosoftSecurityIncidentCreation, UpdateViaIdentityMicrosoftSecurityIncidentCreation
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Query


```yaml
Type: System.String
Parameter Sets: UpdateScheduled, UpdateViaIdentityUpdateScheduled
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -QueryFrequency


```yaml
Type: System.TimeSpan
Parameter Sets: UpdateScheduled, UpdateViaIdentityUpdateScheduled
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -QueryPeriod


```yaml
Type: System.TimeSpan
Parameter Sets: UpdateScheduled, UpdateViaIdentityUpdateScheduled
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ReOpenClosedIncident


```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: UpdateScheduled, UpdateViaIdentityUpdateScheduled
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
Parameter Sets: UpdateFusionMLTI, UpdateMicrosoftSecurityIncidentCreation, UpdateScheduled
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -RuleId
Alert rule ID

```yaml
Type: System.String
Parameter Sets: UpdateFusionMLTI, UpdateMicrosoftSecurityIncidentCreation, UpdateScheduled
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Scheduled


```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: UpdateScheduled, UpdateViaIdentityUpdateScheduled
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -SeveritiesFilter


```yaml
Type: System.String[]
Parameter Sets: UpdateMicrosoftSecurityIncidentCreation, UpdateViaIdentityMicrosoftSecurityIncidentCreation
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Severity


```yaml
Type: System.String
Parameter Sets: UpdateScheduled, UpdateViaIdentityUpdateScheduled
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -SubscriptionId
The ID of the target subscription.

```yaml
Type: System.String
Parameter Sets: UpdateFusionMLTI, UpdateMicrosoftSecurityIncidentCreation, UpdateScheduled
Aliases:

Required: False
Position: Named
Default value: (Get-AzContext).Subscription.Id
Accept pipeline input: False
Accept wildcard characters: False
```

### -SuppressionDuration


```yaml
Type: System.TimeSpan
Parameter Sets: UpdateScheduled, UpdateViaIdentityUpdateScheduled
Aliases:

Required: False
Position: Named
Default value: New-TimeSpan -Hours 5
Accept pipeline input: False
Accept wildcard characters: False
```

### -SuppressionEnabled


```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: UpdateScheduled, UpdateViaIdentityUpdateScheduled
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Tactic


```yaml
Type: System.String
Parameter Sets: UpdateScheduled, UpdateViaIdentityUpdateScheduled
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -TriggerOperator


```yaml
Type: System.String
Parameter Sets: UpdateScheduled, UpdateViaIdentityUpdateScheduled
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -TriggerThreshold


```yaml
Type: System.Int32
Parameter Sets: UpdateScheduled, UpdateViaIdentityUpdateScheduled
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -WorkspaceName
The name of the workspace.

```yaml
Type: System.String
Parameter Sets: UpdateFusionMLTI, UpdateMicrosoftSecurityIncidentCreation, UpdateScheduled
Aliases:

Required: True
Position: Named
Default value: None
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

### Microsoft.Azure.PowerShell.Cmdlets.SecurityInsights.Models.ISecurityInsightsIdentity

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.SecurityInsights.Models.IAlertRule

## NOTES

## RELATED LINKS

