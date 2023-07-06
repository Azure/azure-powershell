---
external help file:
Module Name: Az.SecurityInsights
online version: https://learn.microsoft.com/powershell/module/az.securityinsights/new-azsentinelalertrule
schema: 2.0.0
---

# New-AzSentinelAlertRule

## SYNOPSIS
Creates the alert rule.

## SYNTAX

### FusionMLTI (Default)
```
New-AzSentinelAlertRule -ResourceGroupName <String> -WorkspaceName <String> -AlertRuleTemplate <String>
 -Kind <AlertRuleKind> [-RuleId <String>] [-SubscriptionId <String>] [-Enabled] [-DefaultProfile <PSObject>]
 [-AsJob] [-NoWait] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### MicrosoftSecurityIncidentCreation
```
New-AzSentinelAlertRule -ResourceGroupName <String> -WorkspaceName <String> -Kind <AlertRuleKind>
 -ProductFilter <MicrosoftSecurityProductName> [-RuleId <String>] [-SubscriptionId <String>]
 [-AlertRuleTemplateName <String>] [-Description <String>] [-DisplayNamesExcludeFilter <String>]
 [-DisplayNamesFilter <String>] [-Enabled] [-SeveritiesFilter <AlertSeverity[]>] [-DefaultProfile <PSObject>]
 [-AsJob] [-NoWait] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### NRT
```
New-AzSentinelAlertRule -ResourceGroupName <String> -WorkspaceName <String> -DisplayName <String>
 -Kind <AlertRuleKind> -Query <String> -Severity <AlertSeverity> [-RuleId <String>] [-SubscriptionId <String>]
 [-AlertDescriptionFormat <String>] [-AlertDisplayNameFormat <String>] [-AlertRuleTemplateName <String>]
 [-AlertSeverityColumnName <String>] [-AlertTacticsColumnName <String>] [-CreateIncident]
 [-Description <String>] [-Enabled] [-EntityMapping <EntityMapping>] [-GroupByAlertDetail <AlertDetail>]
 [-GroupByCustomDetail <String[]>] [-GroupByEntity <EntityMappingType>] [-GroupingConfigurationEnabled]
 [-LookbackDuration <TimeSpan>] [-MatchingMethod <String>] [-ReOpenClosedIncident]
 [-SuppressionDuration <TimeSpan>] [-SuppressionEnabled] [-Tactic <String>] [-DefaultProfile <PSObject>]
 [-AsJob] [-NoWait] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### Scheduled
```
New-AzSentinelAlertRule -ResourceGroupName <String> -WorkspaceName <String> -DisplayName <String>
 -Kind <AlertRuleKind> -Query <String> -QueryFrequency <TimeSpan> -QueryPeriod <TimeSpan>
 -Severity <AlertSeverity> -TriggerOperator <TriggerOperator> -TriggerThreshold <Int32> [-RuleId <String>]
 [-SubscriptionId <String>] [-AlertDescriptionFormat <String>] [-AlertDisplayNameFormat <String>]
 [-AlertRuleTemplateName <String>] [-AlertSeverityColumnName <String>] [-AlertTacticsColumnName <String>]
 [-CreateIncident] [-Description <String>] [-Enabled] [-EntityMapping <EntityMapping>]
 [-EventGroupingSettingAggregationKind <EventGroupingAggregationKind>] [-GroupByAlertDetail <AlertDetail>]
 [-GroupByCustomDetail <String[]>] [-GroupByEntity <EntityMappingType>] [-GroupingConfigurationEnabled]
 [-LookbackDuration <TimeSpan>] [-MatchingMethod <String>] [-ReOpenClosedIncident]
 [-SuppressionDuration <TimeSpan>] [-SuppressionEnabled] [-Tactic <String>] [-DefaultProfile <PSObject>]
 [-AsJob] [-NoWait] [-Confirm] [-WhatIf] [<CommonParameters>]
```

## DESCRIPTION
Creates the alert rule.

## EXAMPLES

### Example 1: Create the Fusion Alert rule
```powershell
 $AlertRuleTemplateName = "f71aba3d-28fb-450b-b192-4e76a83015c8"
 New-AzSentinelAlertRule -ResourceGroupName "myResourceGroupName" -WorkspaceName "myWorkspaceName" -Kind Fusion -Enabled -AlertRuleTemplateName $AlertRuleTemplateName
```

This command creates an Alert Rule of the Fusion kind based on the template "Advanced Multistage Attack Detection"

### Example 2: Create the ML Behavior Analytics Alert Rule
```powershell
 $AlertRuleTemplateName = "fa118b98-de46-4e94-87f9-8e6d5060b60b"
 New-AzSentinelAlertRule -ResourceGroupName "myResourceGroupName" -WorkspaceName "myWorkspaceName" -Kind MLBehaviorAnalytics -Enabled -AlertRuleTemplateName $AlertRuleTemplateName
```

This command creates an Alert Rule of the MLBehaviorAnalytics kind based on the template "Anomalous SSH Login Detection"

### Example 3: Create the Threat Intelligence Alert Rule
```powershell
 $AlertRuleTemplateName = "0dd422ee-e6af-4204-b219-f59ac172e4c6"
 New-AzSentinelAlertRule -ResourceGroupName "myResourceGroupName" -WorkspaceName "myWorkspaceName" -Kind ThreatIntelligence -Enabled -AlertRuleTemplateName $AlertRuleTemplateName
```

This command creates an Alert Rule of the ThreatIntelligence kind based on the template "Microsoft Threat Intelligence Analytics"

### Example 4: Create a Microsoft Security Incident Creation Alert Rule
```powershell
 $AlertRuleTemplateName = "a2e0eb51-1f11-461a-999b-cd0ebe5c7a72"
 New-AzSentinelAlertRule -ResourceGroupName "myResourceGroupName" -WorkspaceName "myWorkspaceName" -Kind MicrosoftSecurityIncidentCreation -Enabled -AlertRuleTemplateName $AlertRuleTemplateName -ProductFilter "Azure Security Center for IoT"
```

This command creates an Alert Rule of the MicrosoftSecurityIncidentCreation kind based on the template for Create incidents based on Azure Security Center for IoT alerts.

### Example 5: Create a Scheduled Alert Rule
```powershell
New-AzSentinelAlertRule -ResourceGroupName "myResourceGroup" -WorkspaceName "myWorkspaceName" -Kind Scheduled -Enabled -DisplayName "Powershell Exection Alert (Several Times per Hour)" -Severity Low -Query "SecurityEvent | where EventId == 4688" -QueryFrequency (New-TimeSpan -Hours 1) -QueryPeriod (New-TimeSpan -Hours 1) -TriggerThreshold 10
```

This command creates an Alert Rule of the Scheduled kind.
Please note that that query (parameter -Query) needs to be on a single line as as string.

### Example 6: Create a Near Realtime Alert Rule
```powershell
New-AzSentinelAlertRule -ResourceGroupName "myResourceGroup" -WorkspaceName "myWorkspaceName" -Kind NRT -Enabled -DisplayName "Break glass account accessed" -Severity High -Query "let Break_Glass_Account = _GetWatchlist('break_glass_account')\n|project UPN;\nSigninLogs\n| where UserPrincipalName in (Break_Glass_Account)"
```

This command creates an Alert Rule of the NRT kind.
Please note that that query (parameter -Query) needs to be on a single line as as string.

## PARAMETERS

### -AlertDescriptionFormat


```yaml
Type: System.String
Parameter Sets: NRT, Scheduled
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
Parameter Sets: NRT, Scheduled
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
Parameter Sets: MicrosoftSecurityIncidentCreation, NRT, Scheduled
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
Parameter Sets: NRT, Scheduled
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
Parameter Sets: NRT, Scheduled
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
Parameter Sets: NRT, Scheduled
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -DefaultProfile
The credentials, account, tenant, and subscription used for communication with Azure.

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
Parameter Sets: MicrosoftSecurityIncidentCreation, NRT, Scheduled
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
Parameter Sets: NRT, Scheduled
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -DisplayNamesExcludeFilter


```yaml
Type: System.String
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
Type: System.String
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
Type: Microsoft.Azure.PowerShell.Cmdlets.SecurityInsights.Models.Api20210901Preview.EntityMapping
Parameter Sets: NRT, Scheduled
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -EventGroupingSettingAggregationKind


```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.SecurityInsights.Support.EventGroupingAggregationKind
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
Type: Microsoft.Azure.PowerShell.Cmdlets.SecurityInsights.Support.AlertDetail
Parameter Sets: NRT, Scheduled
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
Parameter Sets: NRT, Scheduled
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -GroupByEntity


```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.SecurityInsights.Support.EntityMappingType
Parameter Sets: NRT, Scheduled
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
Parameter Sets: NRT, Scheduled
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Kind
Kind of the the data connection

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.SecurityInsights.Support.AlertRuleKind
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
Parameter Sets: NRT, Scheduled
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
Parameter Sets: NRT, Scheduled
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
Type: Microsoft.Azure.PowerShell.Cmdlets.SecurityInsights.Support.MicrosoftSecurityProductName
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
Parameter Sets: NRT, Scheduled
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
Parameter Sets: NRT, Scheduled
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ResourceGroupName
The Resource Group Name.

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
[Alias('RuleId')]
 The Id of the Rule.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: (New-Guid).Guid
Accept pipeline input: False
Accept wildcard characters: False
```

### -SeveritiesFilter
High, Medium, Low, Informational

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.SecurityInsights.Support.AlertSeverity[]
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
Type: Microsoft.Azure.PowerShell.Cmdlets.SecurityInsights.Support.AlertSeverity
Parameter Sets: NRT, Scheduled
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -SubscriptionId
Gets subscription credentials which uniquely identify Microsoft Azure subscription.
The subscription ID forms part of the URI for every service call.

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
Parameter Sets: NRT, Scheduled
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
Parameter Sets: NRT, Scheduled
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Tactic
[Microsoft.Azure.PowerShell.Cmdlets.SecurityInsights.Support.AttackTactic]
InitialAccess, Execution, Persistence, PrivilegeEscalation, DefenseEvasion, CredentialAccess, Discovery, LateralMovement, Collection, Exfiltration, CommandAndControl, Impact, PreAttack

```yaml
Type: System.String
Parameter Sets: NRT, Scheduled
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -TriggerOperator


```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.SecurityInsights.Support.TriggerOperator
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

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.SecurityInsights.Models.Api20210901Preview.AlertRule

## NOTES

ALIASES

COMPLEX PARAMETER PROPERTIES

To create the parameters described below, construct a hash table containing the appropriate properties. For information on hash tables, run Get-Help about_Hash_Tables.


ENTITYMAPPING <EntityMapping>: 'Account', 'Host', 'IP', 'Malware', 'File', 'Process', 'CloudApplication', 'DNS', 'AzureResource', 'FileHash', 'RegistryKey', 'RegistryValue', 'SecurityGroup', 'URL', 'Mailbox', 'MailCluster', 'MailMessage', 'SubmissionMail'
  - `[EntityType <EntityMappingType?>]`: The V3 type of the mapped entity
  - `[FieldMapping <IFieldMapping[]>]`: array of field mappings for the given entity mapping
    - `[ColumnName <String>]`: the column name to be mapped to the identifier
    - `[Identifier <String>]`: the V3 identifier of the entity

## RELATED LINKS
