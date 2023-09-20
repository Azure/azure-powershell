---
external help file:
Module Name: Az.SecurityInsights
online version: https://learn.microsoft.com/powershell/module/az.securityinsights/new-azsentinelalertrule
schema: 2.0.0
---

# New-AzSentinelAlertRule

## SYNOPSIS
Create the alert rule.

## SYNTAX

### FusionMLTI (Default)
```
New-AzSentinelAlertRule -ResourceGroupName <String> -WorkspaceName <String> -AlertRuleTemplate <String>
 -Kind <String> [-RuleId <String>] [-SubscriptionId <String>] [-Enabled] [-DefaultProfile <PSObject>] [-AsJob]
 [-NoWait] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### MicrosoftSecurityIncidentCreation
```
New-AzSentinelAlertRule -ResourceGroupName <String> -WorkspaceName <String> -DisplayName <String>
 -Kind <String> -ProductFilter <String> [-RuleId <String>] [-SubscriptionId <String>]
 [-AlertRuleTemplateName <String>] [-Description <String>] [-DisplayNamesExcludeFilter <String[]>]
 [-DisplayNamesFilter <String[]>] [-Enabled] [-SeveritiesFilter <String[]>] [-DefaultProfile <PSObject>]
 [-AsJob] [-NoWait] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### Scheduled
```
New-AzSentinelAlertRule -ResourceGroupName <String> -WorkspaceName <String> -DisplayName <String>
 -Kind <String> -Query <String> -QueryFrequency <TimeSpan> -QueryPeriod <TimeSpan> -Severity <String>
 -TriggerOperator <String> -TriggerThreshold <Int32> [-RuleId <String>] [-SubscriptionId <String>]
 [-AlertDescriptionFormat <String>] [-AlertDisplayNameFormat <String>] [-AlertRuleTemplateName <String>]
 [-AlertSeverityColumnName <String>] [-AlertTacticsColumnName <String>] [-CreateIncident]
 [-Description <String>] [-Enabled] [-EntityMapping <EntityMapping[]>]
 [-EventGroupingSettingAggregationKind <String>] [-GroupByAlertDetail <String[]>]
 [-GroupByCustomDetail <String[]>] [-GroupByEntity <String[]>] [-GroupingConfigurationEnabled]
 [-LookbackDuration <TimeSpan>] [-MatchingMethod <String>] [-ReOpenClosedIncident]
 [-SuppressionDuration <TimeSpan>] [-SuppressionEnabled] [-Tactic <String[]>] [-DefaultProfile <PSObject>]
 [-AsJob] [-NoWait] [-Confirm] [-WhatIf] [<CommonParameters>]
```

## DESCRIPTION
Create the alert rule.

## EXAMPLES

### Example 1: Create the Fusion Alert rule
```powershell
$AlertRuleTemplateName = "f71aba3d-28fb-450b-b192-4e76a83015c8"
New-AzSentinelAlertRule -ResourceGroupName "si-jj-test" -WorkspaceName "si-test-ws" -Kind Fusion -Enabled -AlertRuleTemplate $AlertRuleTemplateName
```

This command creates an Alert Rule of the Fusion kind based on the template "Advanced Multistage Attack Detection"

### Example 2: Create a Microsoft Security Incident Creation Alert Rule
```powershell
$AlertRuleTemplateName = "a2e0eb51-1f11-461a-999b-cd0ebe5c7a72"
New-AzSentinelAlertRule -ResourceGroupName "si-jj-test" -WorkspaceName "si-test-ws" -Kind MicrosoftSecurityIncidentCreation -Enabled -AlertRuleTemplateName $AlertRuleTemplateName -ProductFilter "Azure Security Center for IoT" -DisplayName "testing displayname"
```

```output
AlertRuleTemplateName        : a2e0eb51-1f11-461a-999b-cd0ebe5c7a72
Description                  : 
DisplayName                  : testing displayname
DisplayNamesExcludeFilter    : 
DisplayNamesFilter           : 
Enabled                      : True
Etag                         : "160073ee-0000-0100-0000-64ca18a50000"
Id                           : /subscriptions/9e223dbe-3399-4e19-88eb-0975f02ac87f/resourceGroups/si-jj-test/providers/Microsoft.OperationalInsights/workspaces/si-test-ws/prov 
                               iders/Microsoft.SecurityInsights/alertRules/2b52d061-3ecf-43d9-9193-16aac078f7b5
Kind                         : MicrosoftSecurityIncidentCreation
LastModifiedUtc              : 8/2/2023 8:49:41 AM
Name                         : 2b52d061-3ecf-43d9-9193-16aac078f7b5
ProductFilter                : Azure Security Center for IoT
SeveritiesFilter             : 
SystemDataCreatedAt          : 
SystemDataCreatedBy          : 
SystemDataCreatedByType      : 
SystemDataLastModifiedAt     : 
SystemDataLastModifiedBy     : 
SystemDataLastModifiedByType : 
Type                         : Microsoft.SecurityInsights/alertRules
```

This command creates an Alert Rule of the MicrosoftSecurityIncidentCreation kind based on the template for Create incidents based on Azure Security Center for IoT alerts.

### Example 3: Create a Scheduled Alert Rule
```powershell
New-AzSentinelAlertRule -ResourceGroupName "si-jj-test" -WorkspaceName "si-test-ws" -Kind Scheduled -Enabled -DisplayName "Powershell Exection Alert (Several Times per Hour)" -Severity Low -Query "SecurityEvent" -QueryFrequency (New-TimeSpan -Hours 1) -QueryPeriod (New-TimeSpan -Hours 1) -TriggerThreshold 10 -TriggerOperator GreaterThan
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
Etag                                       : "1600bff7-0000-0100-0000-64ca1b0d0000"
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
LastModifiedUtc                            : 8/2/2023 8:59:57 AM
Name                                       : 727fde97-bd0a-4b6d-a730-9d77fbcdb786
Query                                      : SecurityEvent
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

This command creates an Alert Rule of the Scheduled kind.
Please note that that query (parameter -Query) needs to be on a single line as as string.

## PARAMETERS

### -AlertDescriptionFormat


```yaml
Type: System.String
Parameter Sets: Scheduled
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
Parameter Sets: Scheduled
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -AlertRuleTemplate


```yaml
Type: System.String
Parameter Sets: FusionMLTI
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -AlertRuleTemplateName


```yaml
Type: System.String
Parameter Sets: MicrosoftSecurityIncidentCreation, Scheduled
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
Parameter Sets: Scheduled
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
Parameter Sets: Scheduled
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
Parameter Sets: Scheduled
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
Parameter Sets: MicrosoftSecurityIncidentCreation, Scheduled
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
Parameter Sets: MicrosoftSecurityIncidentCreation, Scheduled
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -DisplayNamesExcludeFilter


```yaml
Type: System.String[]
Parameter Sets: MicrosoftSecurityIncidentCreation
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -DisplayNamesFilter


```yaml
Type: System.String[]
Parameter Sets: MicrosoftSecurityIncidentCreation
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
'Account', 'Host', 'IP', 'Malware', 'File', 'Process', 'CloudApplication', 'DNS', 'AzureResource', 'FileHash', 'RegistryKey', 'RegistryValue', 'SecurityGroup', 'URL', 'Mailbox', 'MailCluster', 'MailMessage', 'SubmissionMail'
To construct, see NOTES section for ENTITYMAPPING properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.SecurityInsights.Models.EntityMapping[]
Parameter Sets: Scheduled
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
Parameter Sets: Scheduled
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -GroupByAlertDetail


```yaml
Type: System.String[]
Parameter Sets: Scheduled
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
Parameter Sets: Scheduled
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -GroupByEntity


```yaml
Type: System.String[]
Parameter Sets: Scheduled
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
Parameter Sets: Scheduled
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Kind
The alert rule kind

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

### -LookbackDuration


```yaml
Type: System.TimeSpan
Parameter Sets: Scheduled
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
Parameter Sets: Scheduled
Aliases:

Required: False
Position: Named
Default value: "AllEntities"
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
Parameter Sets: MicrosoftSecurityIncidentCreation
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Query


```yaml
Type: System.String
Parameter Sets: Scheduled
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -QueryFrequency


```yaml
Type: System.TimeSpan
Parameter Sets: Scheduled
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -QueryPeriod


```yaml
Type: System.TimeSpan
Parameter Sets: Scheduled
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ReOpenClosedIncident


```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: Scheduled
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

### -RuleId
Alert rule ID

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: True
Position: Named
Default value: (New-Guid).Guid
Accept pipeline input: False
Accept wildcard characters: False
```

### -SeveritiesFilter


```yaml
Type: System.String[]
Parameter Sets: MicrosoftSecurityIncidentCreation
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
Parameter Sets: Scheduled
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

### -SuppressionDuration


```yaml
Type: System.TimeSpan
Parameter Sets: Scheduled
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
Parameter Sets: Scheduled
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Tactic


```yaml
Type: System.String[]
Parameter Sets: Scheduled
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
Parameter Sets: Scheduled
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -TriggerThreshold


```yaml
Type: System.Int32
Parameter Sets: Scheduled
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -WorkspaceName
The name of the workspace.

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

### Microsoft.Azure.PowerShell.Cmdlets.SecurityInsights.Models.IAlertRule

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.SecurityInsights.Models.IAlertRule

## NOTES

## RELATED LINKS

