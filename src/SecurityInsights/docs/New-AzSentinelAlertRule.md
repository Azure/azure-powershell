---
external help file:
Module Name: Az.SecurityInsights
online version: https://docs.microsoft.com/powershell/module/az.securityinsights/new-azsentinelalertrule
schema: 2.0.0
---

# New-AzSentinelAlertRule

## SYNOPSIS
Creates or updates the alert rule.

## SYNTAX

### FusionMLTI (Default)
```
New-AzSentinelAlertRule -ResourceGroupName <String> -WorkspaceName <String> -AlertRuleTemplateName <String>
 -Kind <AlertRuleKind> [-OperationalInsightsResourceProvider <String>] [-RuleId <String>]
 [-SubscriptionId <String>] [-Disabled] [-Enabled] [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-Confirm]
 [-WhatIf] [<CommonParameters>]
```

### MicrosoftSecurityIncidentCreation
```
New-AzSentinelAlertRule -ResourceGroupName <String> -WorkspaceName <String> -Kind <AlertRuleKind>
 -ProductFilter <MicrosoftSecurityProductName> [-OperationalInsightsResourceProvider <String>]
 [-RuleId <String>] [-SubscriptionId <String>] [-AlertRuleTemplateName <String>] [-Description <String>]
 [-Disabled] [-DisplayNamesExcludeFilter <String>] [-DisplayNamesFilter <String>] [-Enabled]
 [-SeveritiesFilter <AlertSeverity[]>] [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-Confirm] [-WhatIf]
 [<CommonParameters>]
```

### NRT
```
New-AzSentinelAlertRule -ResourceGroupName <String> -WorkspaceName <String> -DisplayName <String>
 -Kind <AlertRuleKind> -Query <String> -Severity <AlertSeverity>
 [-OperationalInsightsResourceProvider <String>] [-RuleId <String>] [-SubscriptionId <String>]
 [-AlertDetailOverrideAlertDescriptionFormat <String>] [-AlertDetailOverrideAlertDisplayNameFormat <String>]
 [-AlertDetailOverrideAlertSeverityColumnName <String>] [-AlertDetailOverrideAlertTacticsColumnName <String>]
 [-AlertRuleTemplateName <String>] [-Description <String>] [-Disabled] [-Enabled]
 [-EntityMapping <EntityMapping>] [-GroupingConfigurationEnabled]
 [-GroupingConfigurationGroupByAlertDetail <AlertDetail>]
 [-GroupingConfigurationGroupByCustomDetail <String[]>]
 [-GroupingConfigurationGroupByEntity <EntityMappingType>] [-GroupingConfigurationLookbackDuration <TimeSpan>]
 [-GroupingConfigurationMatchingMethod <String>] [-GroupingConfigurationReOpenClosedIncident]
 [-IncidentConfigurationCreateIncident] [-SuppressionDuration <TimeSpan>] [-SuppressionEnabled]
 [-Tactic <String>] [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### Scheduled
```
New-AzSentinelAlertRule -ResourceGroupName <String> -WorkspaceName <String> -DisplayName <String>
 -Kind <AlertRuleKind> -Query <String> -QueryFrequency <TimeSpan> -QueryPeriod <TimeSpan>
 -Severity <AlertSeverity> -TriggerOperator <TriggerOperator> -TriggerThreshold <Int32>
 [-OperationalInsightsResourceProvider <String>] [-RuleId <String>] [-SubscriptionId <String>]
 [-AlertDetailOverrideAlertDescriptionFormat <String>] [-AlertDetailOverrideAlertDisplayNameFormat <String>]
 [-AlertDetailOverrideAlertSeverityColumnName <String>] [-AlertDetailOverrideAlertTacticsColumnName <String>]
 [-AlertRuleTemplateName <String>] [-Description <String>] [-Disabled] [-Enabled]
 [-EntityMapping <EntityMapping>] [-EventGroupingSettingAggregationKind <EventGroupingAggregationKind>]
 [-GroupingConfigurationEnabled] [-GroupingConfigurationGroupByAlertDetail <AlertDetail>]
 [-GroupingConfigurationGroupByCustomDetail <String[]>]
 [-GroupingConfigurationGroupByEntity <EntityMappingType>] [-GroupingConfigurationLookbackDuration <TimeSpan>]
 [-GroupingConfigurationMatchingMethod <String>] [-GroupingConfigurationReOpenClosedIncident]
 [-IncidentConfigurationCreateIncident] [-SuppressionDuration <TimeSpan>] [-SuppressionEnabled]
 [-Tactic <String>] [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-Confirm] [-WhatIf] [<CommonParameters>]
```

## DESCRIPTION
Creates or updates the alert rule.

## EXAMPLES

### Example 1: {{ Add title here }}
```powershell
PS C:\> {{ Add code here }}

{{ Add output here }}
```

{{ Add description here }}

### Example 2: {{ Add title here }}
```powershell
PS C:\> {{ Add code here }}

{{ Add output here }}
```

{{ Add description here }}

## PARAMETERS

### -AlertDetailOverrideAlertDescriptionFormat


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

### -AlertDetailOverrideAlertDisplayNameFormat


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

### -AlertDetailOverrideAlertSeverityColumnName


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

### -AlertDetailOverrideAlertTacticsColumnName


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

### -AlertRuleTemplateName


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

### -GroupingConfigurationGroupByAlertDetail


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

### -GroupingConfigurationGroupByCustomDetail


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

### -GroupingConfigurationGroupByEntity


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

### -GroupingConfigurationLookbackDuration


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

### -GroupingConfigurationMatchingMethod


```yaml
Type: System.String
Parameter Sets: NRT, Scheduled
Aliases:

Required: False
Position: Named
Default value: AllEntities
Accept pipeline input: False
Accept wildcard characters: False
```

### -GroupingConfigurationReOpenClosedIncident


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

### -IncidentConfigurationCreateIncident


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

### -OperationalInsightsResourceProvider
The name of Operational Insights Resource Provider.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: "Microsoft.OperationalInsights"
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

