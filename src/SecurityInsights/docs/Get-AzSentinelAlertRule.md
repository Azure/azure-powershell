---
external help file:
Module Name: Az.SecurityInsights
online version: https://learn.microsoft.com/powershell/module/az.securityinsights/get-azsentinelalertrule
schema: 2.0.0
---

# Get-AzSentinelAlertRule

## SYNOPSIS
Gets the alert rule.

## SYNTAX

### List (Default)
```
Get-AzSentinelAlertRule -ResourceGroupName <String> -WorkspaceName <String> [-SubscriptionId <String[]>]
 [-DefaultProfile <PSObject>] [<CommonParameters>]
```

### Get
```
Get-AzSentinelAlertRule -ResourceGroupName <String> -RuleId <String> -WorkspaceName <String>
 [-SubscriptionId <String[]>] [-DefaultProfile <PSObject>] [<CommonParameters>]
```

### GetViaIdentity
```
Get-AzSentinelAlertRule -InputObject <ISecurityInsightsIdentity> [-DefaultProfile <PSObject>]
 [<CommonParameters>]
```

### GetViaIdentityWorkspace
```
Get-AzSentinelAlertRule -RuleId <String> -WorkspaceInputObject <ISecurityInsightsIdentity>
 [-DefaultProfile <PSObject>] [<CommonParameters>]
```

## DESCRIPTION
Gets the alert rule.

## EXAMPLES

### Example 1: List all Alert Rules
```powershell
Get-AzSentinelAlertRule -ResourceGroupName "si-jj-test" -WorkspaceName "si-test-ws"
```

```output
Etag                                   Kind   Name          SystemDataCreatedAt SystemDataCreatedBy SystemDataCreatedByType SystemDataLastModifiedAt SystemDataLastModifiedBy SystemDataLastModifiedByType
----                                   ----   ----          ------------------- ------------------- ----------------------- ------------------------ ------------------------ ----------------------------
"16001bcb-0000-0100-0000-64ca0f0e0000" Fusion BuiltInFusion

AlertRuleTemplateName        : a2e0eb51-1f11-461a-999b-cd0ebe5c7a72
Description                  : 
DisplayName                  : testing displayname
DisplayNamesExcludeFilter    : 
DisplayNamesFilter           : 
Enabled                      : True
Etag                         : "160073ee-0000-0100-0000-64ca18a50000"
Id                           : /subscriptions/9e223dbe-3399-4e19-88eb-0975f02ac87f/resourceGroups/si-jj-test/providers/Microsoft.OperationalInsights/workspaces/si-test-ws/providers/Microsoft.SecurityInsights/alertRules/2b52d061-3ecf-43d9-9193- 
                               16aac078f7b5
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
Id                                         : /subscriptions/9e223dbe-3399-4e19-88eb-0975f02ac87f/resourceGroups/si-jj-test/providers/Microsoft.OperationalInsights/workspaces/si-test-ws/providers/Microsoft.SecurityInsights/alertRules/727fde97-b 
                                             d0a-4b6d-a730-9d77fbcdb786
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

This command lists all Alert Rules under a Microsoft Sentinel workspace.

### Example 2: Get an Alert Rule
```powershell
Get-AzSentinelAlertRule -ResourceGroupName "si-jj-test" -WorkspaceName "si-test-ws" -RuleId "727fde97-bd0a-4b6d-a730-9d77fbcdb786"
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
Id                                         : /subscriptions/9e223dbe-3399-4e19-88eb-0975f02ac87f/resourceGroups/si-jj-test/providers/Microsoft.OperationalInsights/workspaces/si-test-ws/providers/Microsoft.SecurityInsights/alertRules/727fde97-b 
                                             d0a-4b6d-a730-9d77fbcdb786
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

This command gets an Alert Rule.

### Example 3: Get an Alert Rule by object Id
```powershell
$rules = Get-AzSentinelAlertRule -ResourceGroupName "si-jj-test" -WorkspaceName "si-test-ws"
$rules[1] | Get-AzSentinelAlertRule
```

```output
AlertRuleTemplateName        : a2e0eb51-1f11-461a-999b-cd0ebe5c7a72
Description                  : 
DisplayName                  : testing displayname
DisplayNamesExcludeFilter    : 
DisplayNamesFilter           : 
Enabled                      : True
Etag                         : "160073ee-0000-0100-0000-64ca18a50000"
Id                           : /subscriptions/9e223dbe-3399-4e19-88eb-0975f02ac87f/resourceGroups/si-jj-test/providers/Microsoft.OperationalInsights/workspaces/si-test-ws/providers/Microsoft.SecurityInsights/alertRules/2b52d061-3ecf-43d9-9193- 
                               16aac078f7b5
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

This command gets an Alert Rule by object

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
Type: Microsoft.Azure.PowerShell.Cmdlets.SecurityInsights.Models.ISecurityInsightsIdentity
Parameter Sets: GetViaIdentity
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -ResourceGroupName
The name of the resource group.
The name is case insensitive.

```yaml
Type: System.String
Parameter Sets: Get, List
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
Parameter Sets: Get, GetViaIdentityWorkspace
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
Type: System.String[]
Parameter Sets: Get, List
Aliases:

Required: False
Position: Named
Default value: (Get-AzContext).Subscription.Id
Accept pipeline input: False
Accept wildcard characters: False
```

### -WorkspaceInputObject
Identity Parameter
To construct, see NOTES section for WORKSPACEINPUTOBJECT properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.SecurityInsights.Models.ISecurityInsightsIdentity
Parameter Sets: GetViaIdentityWorkspace
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -WorkspaceName
The name of the workspace.

```yaml
Type: System.String
Parameter Sets: Get, List
Aliases:

Required: True
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

