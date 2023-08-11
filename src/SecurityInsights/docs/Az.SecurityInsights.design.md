#### New-AzSentinelAlertRule

#### SYNOPSIS
Create the alert rule.

#### SYNTAX

+ FusionMLTI (Default)
```powershell
New-AzSentinelAlertRule -ResourceGroupName <String> -WorkspaceName <String> -AlertRuleTemplate <String>
 -Kind <String> [-RuleId <String>] [-SubscriptionId <String>] [-Enabled] [-DefaultProfile <PSObject>] [-AsJob]
 [-NoWait] [-Confirm] [-WhatIf] [<CommonParameters>]
```

+ MicrosoftSecurityIncidentCreation
```powershell
New-AzSentinelAlertRule -ResourceGroupName <String> -WorkspaceName <String> -DisplayName <String>
 -Kind <String> -ProductFilter <String> [-RuleId <String>] [-SubscriptionId <String>]
 [-AlertRuleTemplateName <String>] [-Description <String>] [-DisplayNamesExcludeFilter <String>]
 [-DisplayNamesFilter <String>] [-Enabled] [-SeveritiesFilter <String>] [-DefaultProfile <PSObject>] [-AsJob]
 [-NoWait] [-Confirm] [-WhatIf] [<CommonParameters>]
```

+ Scheduled
```powershell
New-AzSentinelAlertRule -ResourceGroupName <String> -WorkspaceName <String> -DisplayName <String>
 -Kind <String> -Query <String> -QueryFrequency <TimeSpan> -QueryPeriod <TimeSpan> -Severity <String>
 -TriggerOperator <String> -TriggerThreshold <Int32> [-RuleId <String>] [-SubscriptionId <String>]
 [-AlertDescriptionFormat <String>] [-AlertDisplayNameFormat <String>] [-AlertRuleTemplateName <String>]
 [-AlertSeverityColumnName <String>] [-AlertTacticsColumnName <String>] [-CreateIncident]
 [-Description <String>] [-Enabled] [-EntityMapping <EntityMapping>]
 [-EventGroupingSettingAggregationKind <String>] [-GroupByAlertDetail <String>]
 [-GroupByCustomDetail <String[]>] [-GroupByEntity <String>] [-GroupingConfigurationEnabled]
 [-LookbackDuration <TimeSpan>] [-MatchingMethod <String>] [-ReOpenClosedIncident]
 [-SuppressionDuration <TimeSpan>] [-SuppressionEnabled] [-Tactic <String>] [-DefaultProfile <PSObject>]
 [-AsJob] [-NoWait] [-Confirm] [-WhatIf] [<CommonParameters>]
```

#### EXAMPLES

+ Example 1: Create the Fusion Alert rule
```powershell
$AlertRuleTemplateName = "f71aba3d-28fb-450b-b192-4e76a83015c8"
New-AzSentinelAlertRule -ResourceGroupName "si-jj-test" -WorkspaceName "si-test-ws" -Kind Fusion -Enabled -AlertRuleTemplate $AlertRuleTemplateName
```

This command creates an Alert Rule of the Fusion kind based on the template "Advanced Multistage Attack Detection"

+ Example 2: Create a Microsoft Security Incident Creation Alert Rule
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

+ Example 3: Create a Scheduled Alert Rule
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


#### Get-AzSentinelAlertRule

#### SYNOPSIS
Gets the alert rule.

#### SYNTAX

+ List (Default)
```powershell
Get-AzSentinelAlertRule -ResourceGroupName <String> -WorkspaceName <String> [-SubscriptionId <String[]>]
 [-DefaultProfile <PSObject>] [<CommonParameters>]
```

+ Get
```powershell
Get-AzSentinelAlertRule -ResourceGroupName <String> -RuleId <String> -WorkspaceName <String>
 [-SubscriptionId <String[]>] [-DefaultProfile <PSObject>] [<CommonParameters>]
```

+ GetViaIdentity
```powershell
Get-AzSentinelAlertRule -InputObject <ISecurityInsightsIdentity> [-DefaultProfile <PSObject>]
 [<CommonParameters>]
```

+ GetViaIdentityWorkspace
```powershell
Get-AzSentinelAlertRule -RuleId <String> -WorkspaceInputObject <ISecurityInsightsIdentity>
 [-DefaultProfile <PSObject>] [<CommonParameters>]
```

#### EXAMPLES

+ Example 1: List all Alert Rules
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

+ Example 2: Get an Alert Rule
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

+ Example 3: Get an Alert Rule by object Id
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


#### Remove-AzSentinelAlertRule

#### SYNOPSIS
Delete the alert rule.

#### SYNTAX

+ Delete (Default)
```powershell
Remove-AzSentinelAlertRule -ResourceGroupName <String> -RuleId <String> -WorkspaceName <String>
 [-SubscriptionId <String>] [-DefaultProfile <PSObject>] [-PassThru] [-Confirm] [-WhatIf] [<CommonParameters>]
```

+ DeleteViaIdentity
```powershell
Remove-AzSentinelAlertRule -InputObject <ISecurityInsightsIdentity> [-DefaultProfile <PSObject>] [-PassThru]
 [-Confirm] [-WhatIf] [<CommonParameters>]
```

+ DeleteViaIdentityWorkspace
```powershell
Remove-AzSentinelAlertRule -RuleId <String> -WorkspaceInputObject <ISecurityInsightsIdentity>
 [-DefaultProfile <PSObject>] [-PassThru] [-Confirm] [-WhatIf] [<CommonParameters>]
```

#### EXAMPLES

+ Example 1: Remove an alert rule
```powershell
Remove-AzSentinelAlertRule -ResourceGroupName "si-jj-test" -WorkspaceName "si-test-ws" -RuleId 2b52d061-3ecf-43d9-9193-16aac078f7b5
```

The command removes a Sentinel alert rule


#### Update-AzSentinelAlertRule

#### SYNOPSIS
Create the alert rule.

#### SYNTAX

+ UpdateScheduled (Default)
```powershell
Update-AzSentinelAlertRule -ResourceGroupName <String> -RuleId <String> -WorkspaceName <String> -Scheduled
 [-SubscriptionId <String>] [-AlertDescriptionFormat <String>] [-AlertDisplayNameFormat <String>]
 [-AlertRuleTemplateName <String>] [-AlertSeverityColumnName <String>] [-AlertTacticsColumnName <String>]
 [-CreateIncident] [-Description <String>] [-Disabled] [-DisplayName <String>] [-Enabled]
 [-EntityMapping <EntityMapping>] [-EventGroupingSettingAggregationKind <Object>]
 [-GroupByAlertDetail <Object>] [-GroupByCustomDetail <String[]>] [-GroupByEntity <Object>]
 [-GroupingConfigurationEnabled] [-LookbackDuration <TimeSpan>] [-MatchingMethod <String>] [-Query <String>]
 [-QueryFrequency <TimeSpan>] [-QueryPeriod <TimeSpan>] [-ReOpenClosedIncident] [-Severity <Object>]
 [-SuppressionDuration <TimeSpan>] [-SuppressionEnabled] [-Tactic <Object>] [-TriggerOperator <Object>]
 [-TriggerThreshold <Int32>] [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-Confirm] [-WhatIf]
 [<CommonParameters>]
```

+ UpdateFusionMLTI
```powershell
Update-AzSentinelAlertRule -ResourceGroupName <String> -RuleId <String> -WorkspaceName <String> -FusionMLorTI
 [-SubscriptionId <String>] [-AlertRuleTemplateName <String>] [-Description <String>] [-Disabled] [-Enabled]
 [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-Confirm] [-WhatIf] [<CommonParameters>]
```

+ UpdateMicrosoftSecurityIncidentCreation
```powershell
Update-AzSentinelAlertRule -ResourceGroupName <String> -RuleId <String> -WorkspaceName <String>
 -MicrosoftSecurityIncidentCreation [-SubscriptionId <String>] [-AlertRuleTemplateName <String>]
 [-Description <String>] [-Disabled] [-DisplayNamesExcludeFilter <String>] [-DisplayNamesFilter <String>]
 [-Enabled] [-ProductFilter <Object>] [-SeveritiesFilter <Object>] [-DefaultProfile <PSObject>] [-AsJob]
 [-NoWait] [-Confirm] [-WhatIf] [<CommonParameters>]
```

+ UpdateViaIdentityFusionMLTI
```powershell
Update-AzSentinelAlertRule -InputObject <ISecurityInsightsIdentity> -FusionMLorTI
 [-AlertRuleTemplateName <String>] [-Description <String>] [-Disabled] [-Enabled] [-DefaultProfile <PSObject>]
 [-AsJob] [-NoWait] [-Confirm] [-WhatIf] [<CommonParameters>]
```

+ UpdateViaIdentityMicrosoftSecurityIncidentCreation
```powershell
Update-AzSentinelAlertRule -InputObject <ISecurityInsightsIdentity> -MicrosoftSecurityIncidentCreation
 [-AlertRuleTemplateName <String>] [-Description <String>] [-Disabled] [-DisplayNamesExcludeFilter <String>]
 [-DisplayNamesFilter <String>] [-Enabled] [-ProductFilter <Object>] [-SeveritiesFilter <Object>]
 [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-Confirm] [-WhatIf] [<CommonParameters>]
```

+ UpdateViaIdentityUpdateScheduled
```powershell
Update-AzSentinelAlertRule -InputObject <ISecurityInsightsIdentity> -Scheduled
 [-AlertDescriptionFormat <String>] [-AlertDisplayNameFormat <String>] [-AlertRuleTemplateName <String>]
 [-AlertSeverityColumnName <String>] [-AlertTacticsColumnName <String>] [-CreateIncident]
 [-Description <String>] [-Disabled] [-DisplayName <String>] [-Enabled] [-EntityMapping <EntityMapping>]
 [-EventGroupingSettingAggregationKind <Object>] [-GroupByAlertDetail <Object>]
 [-GroupByCustomDetail <String[]>] [-GroupByEntity <Object>] [-GroupingConfigurationEnabled]
 [-LookbackDuration <TimeSpan>] [-MatchingMethod <String>] [-Query <String>] [-QueryFrequency <TimeSpan>]
 [-QueryPeriod <TimeSpan>] [-ReOpenClosedIncident] [-Severity <Object>] [-SuppressionDuration <TimeSpan>]
 [-SuppressionEnabled] [-Tactic <Object>] [-TriggerOperator <Object>] [-TriggerThreshold <Int32>]
 [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-Confirm] [-WhatIf] [<CommonParameters>]
```

#### EXAMPLES

+ Example 1: Update an scheduled alert rule
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


#### New-AzSentinelAlertRuleAction

#### SYNOPSIS
Create the action of alert rule.

#### SYNTAX

+ CreateExpanded (Default)
```powershell
New-AzSentinelAlertRuleAction -ResourceGroupName <String> -RuleId <String> -WorkspaceName <String>
 [-Id <String>] [-SubscriptionId <String>] [-LogicAppResourceId <String>] [-TriggerUri <String>]
 [-DefaultProfile <PSObject>] [-Confirm] [-WhatIf] [<CommonParameters>]
```

+ CreateViaIdentityAlertRuleExpanded
```powershell
New-AzSentinelAlertRuleAction -AlertRuleInputObject <ISecurityInsightsIdentity> [-Id <String>]
 [-LogicAppResourceId <String>] [-TriggerUri <String>] [-DefaultProfile <PSObject>] [-Confirm] [-WhatIf]
 [<CommonParameters>]
```

+ CreateViaIdentityExpanded
```powershell
New-AzSentinelAlertRuleAction -InputObject <ISecurityInsightsIdentity> [-LogicAppResourceId <String>]
 [-TriggerUri <String>] [-DefaultProfile <PSObject>] [-Confirm] [-WhatIf] [<CommonParameters>]
```

+ CreateViaIdentityWorkspaceExpanded
```powershell
New-AzSentinelAlertRuleAction -RuleId <String> -WorkspaceInputObject <ISecurityInsightsIdentity>
 [-Id <String>] [-LogicAppResourceId <String>] [-TriggerUri <String>] [-DefaultProfile <PSObject>] [-Confirm]
 [-WhatIf] [<CommonParameters>]
```

#### EXAMPLES

+ Example 1: Add a Logic App Playbook as an action to an existing analytics rule
```powershell
$LogicAppResourceId = Get-AzLogicApp -ResourceGroupName "si-jj-test" -Name "myLogicApp"
$LogicAppTriggerUri = Get-AzLogicAppTriggerCallbackUrl -ResourceGroupName "si-jj-test" -Name $LogicAppResourceId.Name -TriggerName "Microsoft_Sentinel_alert"
New-AzSentinelAlertRuleAction -ResourceGroupName "si-jj-test" -WorkspaceName "si-test-ws" -RuleId "727fde97-bd0a-4b6d-a730-9d77fbcdb786" -LogicAppResourceId ($LogicAppResourceId.Id) -TriggerUri ($LogicAppTriggerUri.Value)
```

```output
Etag                         : 
Id                           : /subscriptions/9e223dbe-3399-4e19-88eb-0975f02ac87f/resourceGroups/si-jj-test/providers/Microsoft.OperationalInsights/workspaces/si-test-ws/prov 
                               iders/Microsoft.SecurityInsights/alertRules/727fde97-bd0a-4b6d-a730-9d77fbcdb786/actions/830f0b57-f450-48d2-8930-45e8a8657385
LogicAppResourceId           : /subscriptions/9e223dbe-3399-4e19-88eb-0975f02ac87f/resourceGroups/si-jj-test/providers/Microsoft.Logic/workflows/myLogicApp
Name                         : 830f0b57-f450-48d2-8930-45e8a8657385
ResourceGroupName            : si-jj-test
SystemDataCreatedAt          : 
SystemDataCreatedBy          : 
SystemDataCreatedByType      : 
SystemDataLastModifiedAt     : 
SystemDataLastModifiedBy     : 
SystemDataLastModifiedByType : 
Type                         : Microsoft.SecurityInsights/alertRules/actions
WorkflowId                   : 71ed151a52fb4db8b40b43ef4b71ef32
```

This command adds an existing Logic App Playbook to an existing analytics rule


#### Get-AzSentinelAlertRuleAction

#### SYNOPSIS
Gets the action of alert rule.

#### SYNTAX

+ List (Default)
```powershell
Get-AzSentinelAlertRuleAction -ResourceGroupName <String> -RuleId <String> -WorkspaceName <String>
 [-SubscriptionId <String[]>] [-DefaultProfile <PSObject>] [<CommonParameters>]
```

+ Get
```powershell
Get-AzSentinelAlertRuleAction -Id <String> -ResourceGroupName <String> -RuleId <String>
 -WorkspaceName <String> [-SubscriptionId <String[]>] [-DefaultProfile <PSObject>] [<CommonParameters>]
```

+ GetViaIdentity
```powershell
Get-AzSentinelAlertRuleAction -InputObject <ISecurityInsightsIdentity> [-DefaultProfile <PSObject>]
 [<CommonParameters>]
```

+ GetViaIdentityAlertRule
```powershell
Get-AzSentinelAlertRuleAction -AlertRuleInputObject <ISecurityInsightsIdentity> -Id <String>
 [-DefaultProfile <PSObject>] [<CommonParameters>]
```

+ GetViaIdentityWorkspace
```powershell
Get-AzSentinelAlertRuleAction -Id <String> -RuleId <String> -WorkspaceInputObject <ISecurityInsightsIdentity>
 [-DefaultProfile <PSObject>] [<CommonParameters>]
```

#### EXAMPLES

+ Example 1: List all Actions for a given Alert Rule
```powershell
Get-AzSentinelAlertRuleAction -ResourceGroupName "si-jj-test" -WorkspaceName "si-test-ws" -RuleId "727fde97-bd0a-4b6d-a730-9d77fbcdb786"
```

```output
Etag                         : "3100142b-0000-0300-0000-64cc637a0000"
Id                           : /subscriptions/9e223dbe-3399-4e19-88eb-0975f02ac87f/resourceGroups/si-jj-test/providers/Microsoft.OperationalInsights/workspaces/si-test-ws/prov 
                               iders/Microsoft.SecurityInsights/alertRules/asicustomalertsv3_727fde97-bd0a-4b6d-a730-9d77fbcdb786_830f0b57-f450-48d2-8930-45e8a8657385/actions/ 
                               830f0b57-f450-48d2-8930-45e8a8657385
LogicAppResourceId           : /subscriptions/9e223dbe-3399-4e19-88eb-0975f02ac87f/resourceGroups/si-jj-test/providers/Microsoft.Logic/workflows/myLogicApp
Name                         : 830f0b57-f450-48d2-8930-45e8a8657385
ResourceGroupName            : si-jj-test
SystemDataCreatedAt          : 
SystemDataCreatedBy          : 
SystemDataCreatedByType      : 
SystemDataLastModifiedAt     : 
SystemDataLastModifiedBy     : 
SystemDataLastModifiedByType : 
Type                         : Microsoft.SecurityInsights/alertRules/actions
WorkflowId                   : 71ed151a52fb4db8b40b43ef4b71ef32
```

This command lists all Actions for a given Alert Rule.


#### Remove-AzSentinelAlertRuleAction

#### SYNOPSIS
Delete the action of alert rule.

#### SYNTAX

+ Delete (Default)
```powershell
Remove-AzSentinelAlertRuleAction -Id <String> -ResourceGroupName <String> -RuleId <String>
 -WorkspaceName <String> [-SubscriptionId <String>] [-DefaultProfile <PSObject>] [-PassThru] [-Confirm]
 [-WhatIf] [<CommonParameters>]
```

+ DeleteViaIdentity
```powershell
Remove-AzSentinelAlertRuleAction -InputObject <ISecurityInsightsIdentity> [-DefaultProfile <PSObject>]
 [-PassThru] [-Confirm] [-WhatIf] [<CommonParameters>]
```

+ DeleteViaIdentityAlertRule
```powershell
Remove-AzSentinelAlertRuleAction -AlertRuleInputObject <ISecurityInsightsIdentity> -Id <String>
 [-DefaultProfile <PSObject>] [-PassThru] [-Confirm] [-WhatIf] [<CommonParameters>]
```

+ DeleteViaIdentityWorkspace
```powershell
Remove-AzSentinelAlertRuleAction -Id <String> -RuleId <String>
 -WorkspaceInputObject <ISecurityInsightsIdentity> [-DefaultProfile <PSObject>] [-PassThru] [-Confirm]
 [-WhatIf] [<CommonParameters>]
```

#### EXAMPLES

+ Example 1: Removes an alert rule action
```powershell
Remove-AzSentinelAlertRuleAction -ResourceGroupName "si-jj-test" -WorkspaceName "si-test-ws" -RuleId "727fde97-bd0a-4b6d-a730-9d77fbcdb786" -Id "830f0b57-f450-48d2-8930-45e8a8657385"
```

This command removes an alert rule action.


#### Update-AzSentinelAlertRuleAction

#### SYNOPSIS
Create the action of alert rule.

#### SYNTAX

+ UpdateExpanded (Default)
```powershell
Update-AzSentinelAlertRuleAction -Id <String> -ResourceGroupName <String> -RuleId <String>
 -WorkspaceName <String> [-SubscriptionId <String>] [-LogicAppResourceId <String>] [-TriggerUri <String>]
 [-DefaultProfile <PSObject>] [-Confirm] [-WhatIf] [<CommonParameters>]
```

+ UpdateViaIdentityAlertRuleExpanded
```powershell
Update-AzSentinelAlertRuleAction -AlertRuleInputObject <ISecurityInsightsIdentity> -Id <String>
 [-LogicAppResourceId <String>] [-TriggerUri <String>] [-DefaultProfile <PSObject>] [-Confirm] [-WhatIf]
 [<CommonParameters>]
```

+ UpdateViaIdentityExpanded
```powershell
Update-AzSentinelAlertRuleAction -InputObject <ISecurityInsightsIdentity> [-LogicAppResourceId <String>]
 [-TriggerUri <String>] [-DefaultProfile <PSObject>] [-Confirm] [-WhatIf] [<CommonParameters>]
```

+ UpdateViaIdentityWorkspaceExpanded
```powershell
Update-AzSentinelAlertRuleAction -Id <String> -RuleId <String>
 -WorkspaceInputObject <ISecurityInsightsIdentity> [-LogicAppResourceId <String>] [-TriggerUri <String>]
 [-DefaultProfile <PSObject>] [-Confirm] [-WhatIf] [<CommonParameters>]
```

#### EXAMPLES

+ Example 1: Updates an alert rule action
```powershell
$LogicAppResourceId = Get-AzLogicApp -ResourceGroupName "si-jj-test" -Name "myLogicApp"
$LogicAppTriggerUri = Get-AzLogicAppTriggerCallbackUrl -ResourceGroupName "si-jj-test" -Name $LogicAppResourceId.Name -TriggerName "Microsoft_Sentinel_alert"
Update-AzSentinelAlertRuleAction -ResourceGroupName "si-jj-test" -WorkspaceName "si-test-ws" -RuleId "727fde97-bd0a-4b6d-a730-9d77fbcdb786" -LogicAppResourceId ($LogicAppResourceId.Id) -TriggerUri ($LogicAppTriggerUri.Value) -Id ((New-Guid).Guid)
```

This command updates an alert rule action


#### Get-AzSentinelAlertRuleTemplate

#### SYNOPSIS
Gets the alert rule template.

#### SYNTAX

+ List (Default)
```powershell
Get-AzSentinelAlertRuleTemplate -ResourceGroupName <String> -WorkspaceName <String>
 [-SubscriptionId <String[]>] [-DefaultProfile <PSObject>] [<CommonParameters>]
```

+ Get
```powershell
Get-AzSentinelAlertRuleTemplate -Id <String> -ResourceGroupName <String> -WorkspaceName <String>
 [-SubscriptionId <String[]>] [-DefaultProfile <PSObject>] [<CommonParameters>]
```

+ GetViaIdentity
```powershell
Get-AzSentinelAlertRuleTemplate -InputObject <ISecurityInsightsIdentity> [-DefaultProfile <PSObject>]
 [<CommonParameters>]
```

+ GetViaIdentityWorkspace
```powershell
Get-AzSentinelAlertRuleTemplate -Id <String> -WorkspaceInputObject <ISecurityInsightsIdentity>
 [-DefaultProfile <PSObject>] [<CommonParameters>]
```

#### EXAMPLES

+ Example 1: List all Alert Rule Templates
```powershell
Get-AzSentinelAlertRuleTemplate -ResourceGroupName "si-jj-test" -WorkspaceName "si-test-ws"
```

```output
Kind      Name                                 SystemDataCreatedAt SystemDataCreatedBy SystemDataCreatedByType SystemDataLastModifiedAt SystemDataLastModifiedBy SystemDataLast 
                                                                                                                                                                 ModifiedByType 
----      ----                                 ------------------- ------------------- ----------------------- ------------------------ ------------------------ -------------- 
Scheduled 46ac55ae-47b8-414a-8f94-89ccd1962178
Scheduled 155f40c6-610d-497d-85fc-3cf06ec13256
Scheduled 4d94d4a9-dc96-450a-9dea-4d4d4594199b
Scheduled 050b9b3d-53d0-4364-a3da-1b678b8211ec
Scheduled c094384d-7ea7-4091-83be-18706ecca981
Scheduled dc99e38c-f4e9-4837-94d7-353ac0b01a77
Scheduled 8955c0fb-3408-47b0-a3b9-a1faec41e427
Scheduled f041e01d-840d-43da-95c8-4188f6cef546
Scheduled 6e95aef3-a1e0-4063-8e74-cd59aa59f245
Scheduled 009b9bae-23dd-43c4-bcb9-11c4ba7c784a
Scheduled e4779bdc-397a-4b71-be28-59e6a1e1d16b
Scheduled 85aca4d1-5d15-4001-abd9-acb86ca1786a
Scheduled 572e75ef-5147-49d9-9d65-13f2ed1e3a86
Scheduled 194dd92e-d6e7-4249-85a5-273350a7f5ce
Scheduled c37711a4-5f44-4472-8afc-0679bc0ef966
Scheduled 6b652b4f-9810-4eec-9027-7aa88ce4db23
Scheduled f0be259a-34ac-4946-aa15-ca2b115d5feb
Scheduled 95a15f39-d9cc-4667-8cdd-58f3113691c9
Scheduled 5f171045-88ab-4634-baae-a7b6509f483b
Scheduled 7cb8f77d-c52f-4e46-b82f-3cf2e106224a
Scheduled 7b907bf7-77d4-41d0-a208-5643ff75bf9a
Scheduled d7feb859-f03e-4e8d-8b21-617be0213b13
Scheduled 15049017-527f-4d3b-b011-b0e99e68ef45
Scheduled 75ea5c39-93e5-489b-b1e1-68fa6c9d2d04

AlertRulesCreatedByTemplateCount : 0
CreatedDateUtc                   : 7/16/2019 12:00:00 AM
Description                      : Create incidents based on all alerts generated in Microsoft Defender for Cloud
DisplayName                      : Create incidents based on Microsoft Defender for Cloud
DisplayNamesExcludeFilter        : 
DisplayNamesFilter               : 
Id                               : /subscriptions/9e223dbe-3399-4e19-88eb-0975f02ac87f/resourceGroups/si-jj-test/providers/Microsoft.OperationalInsights/workspaces/si-test-ws/ 
                                   providers/Microsoft.SecurityInsights/AlertRuleTemplates/90586451-7ba8-4c1e-9904-7d1b7c3cc4d6
Kind                             : MicrosoftSecurityIncidentCreation
LastUpdatedDateUtc               : 7/25/2021 12:00:00 AM
Name                             : 90586451-7ba8-4c1e-9904-7d1b7c3cc4d6
ProductFilter                    : Azure Security Center
RequiredDataConnector            : {{
                                     "connectorId": "AzureSecurityCenter",
                                     "dataTypes": [ "SecurityAlert (ASC)" ]
                                   }}
SeveritiesFilter                 : {Low, Medium, High}
Status                           : Available
SystemDataCreatedAt              : 
SystemDataCreatedBy              : 
SystemDataCreatedByType          : 
SystemDataLastModifiedAt         : 
SystemDataLastModifiedBy         : 
SystemDataLastModifiedByType     : 
Type                             : Microsoft.SecurityInsights/AlertRuleTemplates

Scheduled 32555639-b639-4c2b-afda-c0ae0abefa55
Scheduled 066395ac-ef91-4993-8bf6-25c61ab0ca5a
Scheduled bfb1c90f-8006-4325-98be-c7fffbc254d6
Scheduled 0625fcce-6d52-491e-8c68-1d9b801d25b9
Scheduled 26a3b261-b997-4374-94ea-6c37f67f4f39
Scheduled a0907abe-6925-4d90-af2b-c7e89dc201a6
Scheduled acc4c247-aaf7-494b-b5da-17f18863878a
Scheduled 9122a9cb-916b-4d98-a199-1b7b0af8d598
Scheduled 22a320c2-e1e5-4c74-a35b-39fc9cdcf859
Scheduled d2bc08fa-030a-4eea-931a-762d27c6a042
Scheduled c2da1106-bfe4-4a63-bf14-5ab73130ccd5
Scheduled 50eb4cbd-188f-44f4-b964-bab84dcdec10
Scheduled feb0a2fb-ae75-4343-8cbc-ed545f1da289
Scheduled d9938c3b-16f9-444d-bc22-ea9a9110e0fd
Scheduled 01f64465-b1ef-41ea-a7f5-31553a11ad43
Scheduled 9fb57e58-3ed8-4b89-afcf-c8e786508b1c
Scheduled e2559891-383c-4caf-ae67-55a008b9f89e
Scheduled 2b701288-b428-4fb8-805e-e4372c574786
Scheduled c9b6d281-b96b-4763-b728-9a04b9fe1246
Scheduled 572f3951-5fa3-4e42-9640-fe194d859419
Scheduled 3a9d5ede-2b9d-43a2-acc4-d272321ff77c
Scheduled aa1eff90-29d4-49dc-a3ea-b65199f516db
Scheduled 3fbc20a4-04c4-464e-8fcb-6667f53e4987
Scheduled d82eb796-d1eb-43c8-a813-325ce3417cef
Scheduled 3fe3c520-04f1-44b8-8398-782ed21435f8
Scheduled af435ca1-fb70-4de1-92c1-7435c48482a9
Scheduled 3edb7215-250b-40c0-8b46-79093949242d
Scheduled d0aa8969-1bbe-4da3-9e76-09e5f67c9d85
Scheduled 5dd76a87-9f87-4576-bab3-268b0e2b338b
Scheduled 84cf1d59-f620-4fee-b569-68daf7008b7b
Scheduled 011c84d8-85f0-4370-b864-24c13455aa94
Scheduled 7ee72a9e-2e54-459c-bc8a-8c08a6532a63
Scheduled 30c8b802-ace1-4408-bc29-4c5c5afb49e1
Scheduled 97ad74c4-fdd9-4a3f-b6bf-5e28f4f71e06
Scheduled a04cf847-a832-4c60-b687-b0b6147da219
Scheduled 677da133-e487-4108-a150-5b926591a92b
Scheduled 643c2025-9604-47c5-833f-7b4b9378a1f5
Scheduled 84cccc86-5c11-4b3a-aca6-7c8f738ed0f7
Scheduled 90d3f6ec-80fb-48e0-9937-2c70c9df9bad
Scheduled 3bd33158-3f0b-47e3-a50f-7c20a1b88038
Scheduled 8dcf7238-a7d0-4cfd-8d0c-b230e3cd9182
Scheduled 8c2ef238-67a0-497d-b1dd-5c8a0f533e25
Scheduled 01e8ffff-dc0c-43fe-aa22-d459c4204553

AlertRulesCreatedByTemplateCount : 0
CreatedDateUtc                   : 7/16/2019 12:00:00 AM
Description                      : Create incidents based on all alerts generated in Microsoft Defender for Identity
DisplayName                      : Create incidents based on Microsoft Defender for Identity alerts
DisplayNamesExcludeFilter        : 
DisplayNamesFilter               : 
Id                               : /subscriptions/9e223dbe-3399-4e19-88eb-0975f02ac87f/resourceGroups/si-jj-test/providers/Microsoft.OperationalInsights/workspaces/si-test-ws/ 
                                   providers/Microsoft.SecurityInsights/AlertRuleTemplates/40ba9493-4183-4eee-974f-87fe39c8f267
Kind                             : MicrosoftSecurityIncidentCreation
LastUpdatedDateUtc               : 7/16/2019 12:00:00 AM
Name                             : 40ba9493-4183-4eee-974f-87fe39c8f267
ProductFilter                    : Azure Advanced Threat Protection
RequiredDataConnector            : {{
                                     "connectorId": "AzureAdvancedThreatProtection",
                                     "dataTypes": [ "SecurityAlert (AATP)" ]
                                   }}
SeveritiesFilter                 : 
Status                           : Available
SystemDataCreatedAt              : 
SystemDataCreatedBy              : 
SystemDataCreatedByType          : 
SystemDataLastModifiedAt         : 
SystemDataLastModifiedBy         : 
SystemDataLastModifiedByType     : 
Type                             : Microsoft.SecurityInsights/AlertRuleTemplates

Scheduled f6a51e2c-2d6a-4f92-a090-cfb002ca611f
Scheduled 56f3f35c-3aca-4437-a1fb-b7a84dc4af00
Scheduled 2fc5d810-c9cc-491a-b564-841427ae0e50
Scheduled 5239248b-abfb-4c6a-8177-b104ade5db56
Scheduled 0433c8a3-9aa6-4577-beef-2ea23be41137
Scheduled d3980830-dd9d-40a5-911f-76b44dfdce16
Scheduled a7b9df32-1367-402d-b385-882daf6e3020
Scheduled f2eb15bd-8a88-4b24-9281-e133edfba315
Scheduled a3c144f9-8051-47d4-ac29-ffb0c312c910
Scheduled 6dd2629c-534b-4275-8201-d7968b4fa77e
Scheduled 957cb240-f45d-4491-9ba5-93430a3c08be
Scheduled 44a555d8-ecee-4a25-95ce-055879b4b14b

AlertRulesCreatedByTemplateCount : 0
CreatedDateUtc                   : 7/16/2019 12:00:00 AM
Description                      : Create incidents based on all alerts generated in Microsoft Defender for Cloud Apps
DisplayName                      : Create incidents based on Microsoft Cloud App Security alerts
DisplayNamesExcludeFilter        : 
DisplayNamesFilter               : 
Id                               : /subscriptions/9e223dbe-3399-4e19-88eb-0975f02ac87f/resourceGroups/si-jj-test/providers/Microsoft.OperationalInsights/workspaces/si-test-ws/ 
                                   providers/Microsoft.SecurityInsights/AlertRuleTemplates/b3cfc7c0-092c-481c-a55b-34a3979758cb
Kind                             : MicrosoftSecurityIncidentCreation
LastUpdatedDateUtc               : 7/16/2019 12:00:00 AM
Name                             : b3cfc7c0-092c-481c-a55b-34a3979758cb
ProductFilter                    : Microsoft Cloud App Security
RequiredDataConnector            : {{
                                     "connectorId": "MicrosoftCloudAppSecurity",
                                     "dataTypes": [ "SecurityAlert (MCAS)" ]
                                   }}
SeveritiesFilter                 : 
Status                           : Available
SystemDataCreatedAt              : 
SystemDataCreatedBy              : 
SystemDataCreatedByType          : 
SystemDataLastModifiedAt         : 
SystemDataLastModifiedBy         : 
SystemDataLastModifiedByType     : 
Type                             : Microsoft.SecurityInsights/AlertRuleTemplates
```

This command lists all Alert Rule Templates under a Microsoft Sentinel workspace.

+ Example 2: Get an Alert Rule Template
```powershell
Get-AzSentinelAlertRuleTemplate -ResourceGroupName "si-jj-test" -WorkspaceName "si-test-ws" -Id "532c1811-79ee-4d9f-8d4d-6304c840daa1"
```

```output
AlertRulesCreatedByTemplateCount : 0
CreatedDateUtc                   : 7/16/2019 12:00:00 AM
Description                      : Create incidents based on all alerts generated in Azure Active Directory Identity Protection
DisplayName                      : Create incidents based on Azure Active Directory Identity Protection alerts
DisplayNamesExcludeFilter        : 
DisplayNamesFilter               : 
Id                               : /subscriptions/9e223dbe-3399-4e19-88eb-0975f02ac87f/resourceGroups/si-jj-test/providers/Microsoft.OperationalInsights/workspaces/si-test-ws/ 
                                   providers/Microsoft.SecurityInsights/AlertRuleTemplates/532c1811-79ee-4d9f-8d4d-6304c840daa1
Kind                             : MicrosoftSecurityIncidentCreation
LastUpdatedDateUtc               : 7/16/2019 12:00:00 AM
Name                             : 532c1811-79ee-4d9f-8d4d-6304c840daa1
ProductFilter                    : Azure Active Directory Identity Protection
RequiredDataConnector            : {{
                                     "connectorId": "AzureActiveDirectoryIdentityProtection",
                                     "dataTypes": [ "SecurityAlert (IPC)" ]
                                   }}
SeveritiesFilter                 : 
Status                           : Available
SystemDataCreatedAt              : 
SystemDataCreatedBy              : 
SystemDataCreatedByType          : 
SystemDataLastModifiedAt         : 
SystemDataLastModifiedBy         : 
SystemDataLastModifiedByType     : 
Type                             : Microsoft.SecurityInsights/AlertRuleTemplates
```

This command gets an Alert Rule Template.


#### New-AzSentinelAnomalySecurityMlAnalyticsSettingsObject

#### SYNOPSIS
Create an in-memory object for AnomalySecurityMlAnalyticsSettings.

#### SYNTAX

```powershell
New-AzSentinelAnomalySecurityMlAnalyticsSettingsObject [-AnomalySettingsVersion <Int32>]
 [-AnomalyVersion <String>]
 [-CustomizableObservation <IAnomalySecurityMlAnalyticsSettingsPropertiesCustomizableObservations>]
 [-Description <String>] [-DisplayName <String>] [-Enabled <Boolean>] [-Etag <String>] [-Frequency <TimeSpan>]
 [-IsDefaultSetting <Boolean>] [-RequiredDataConnector <ISecurityMlAnalyticsSettingsDataSource[]>]
 [-SettingsDefinitionId <String>] [-SettingsStatus <String>] [-Tactic <String[]>] [-Technique <String[]>]
 [<CommonParameters>]
```

#### EXAMPLES

+ Example 1: Create an Anomaly SecurityMlAnalyticsSettings Object
```powershell
$setting = New-AzSentinelAnomalySecurityMlAnalyticsSettingsObject -AnomalyVersion 1.0.5 -Enabled $false -DisplayName "Login from unusual region" -Frequency (New-TimeSpan -Hours 1) -SettingsStatus Production -IsDefaultSetting $true -SettingsDefinitionId "f209187f-1d17-4431-94af-c141bf5f23db"
```

```output
AnomalySettingsVersion       : 
AnomalyVersion               : 1.0.5
CustomizableObservation      : {
                               }
Description                  : 
DisplayName                  : Login from unusual region
Enabled                      : False
Etag                         : 
Frequency                    : 01:00:00
Id                           : 
IsDefaultSetting             : True
Kind                         : Anomaly
LastModifiedUtc              : 
Name                         : 
RequiredDataConnector        : 
SettingsDefinitionId         : f209187f-1d17-4431-94af-c141bf5f23db
SettingsStatus               : Production
SystemDataCreatedAt          : 
SystemDataCreatedBy          : 
SystemDataCreatedByType      : 
SystemDataLastModifiedAt     : 
SystemDataLastModifiedBy     : 
SystemDataLastModifiedByType : 
Tactic                       : 
Technique                    : 
Type                         : 
```

This command creates a Anomaly SecurityMlAnalyticsSettings Object


#### New-AzSentinelAutomationRule

#### SYNOPSIS
Create the automation rule.

#### SYNTAX

+ CreateViaIdentityExpanded (Default)
```powershell
New-AzSentinelAutomationRule -InputObject <ISecurityInsightsIdentity> -Action <IAutomationRuleAction[]>
 -DisplayName <String> -Order <Int32> -TriggeringLogicIsEnabled -TriggeringLogicTriggersOn <String>
 -TriggeringLogicTriggersWhen <String> [-TriggeringLogicCondition <IAutomationRuleCondition[]>]
 [-TriggeringLogicExpirationTimeUtc <DateTime>] [-DefaultProfile <PSObject>] [-Confirm] [-WhatIf]
 [<CommonParameters>]
```

+ CreateExpanded
```powershell
New-AzSentinelAutomationRule -ResourceGroupName <String> -WorkspaceName <String>
 -Action <IAutomationRuleAction[]> -DisplayName <String> -Order <Int32> -TriggeringLogicIsEnabled
 -TriggeringLogicTriggersOn <String> -TriggeringLogicTriggersWhen <String> [-Id <String>]
 [-SubscriptionId <String>] [-TriggeringLogicCondition <IAutomationRuleCondition[]>]
 [-TriggeringLogicExpirationTimeUtc <DateTime>] [-DefaultProfile <PSObject>] [-Confirm] [-WhatIf]
 [<CommonParameters>]
```

+ CreateViaIdentityWorkspaceExpanded
```powershell
New-AzSentinelAutomationRule -WorkspaceInputObject <ISecurityInsightsIdentity>
 -Action <IAutomationRuleAction[]> -DisplayName <String> -Order <Int32> -TriggeringLogicIsEnabled
 -TriggeringLogicTriggersOn <String> -TriggeringLogicTriggersWhen <String> [-Id <String>]
 [-TriggeringLogicCondition <IAutomationRuleCondition[]>] [-TriggeringLogicExpirationTimeUtc <DateTime>]
 [-DefaultProfile <PSObject>] [-Confirm] [-WhatIf] [<CommonParameters>]
```

#### EXAMPLES

+ Example 1: Create an Automation Rule using Run Playbook
```powershell
$LogicAppResource = Get-AzLogicApp -ResourceGroupName "si-jj-test" -Name "AlertLogicApp"
$automationRuleAction = New-AzSentinelAutomationRuleActionObject -ActionType RunPlaybook -Order 1 -LogicAppResourceId $LogicAppResource.Id -TenantId (Get-AzContext).Tenant.Id
New-AzSentinelAutomationRule -ResourceGroupName "si-jj-test" -WorkspaceName "si-test-ws3" -Action $automationRuleAction -DisplayName "Run Playbook to create alerts" -Order 2 -TriggeringLogicIsEnabled -TriggeringLogicTriggersOn Alerts -TriggeringLogicTriggersWhen Created
```

```output
Action                           : {{
                                     "order": 1,
                                     "actionType": "RunPlaybook",
                                     "actionConfiguration": {
                                       "logicAppResourceId":
                                   "/subscriptions/9e223dbe-3399-4e19-88eb-0975f02ac87f/resourceGroups/si-jj-test/providers/Microsoft.Logic/workflows/myLogicApp",
                                       "tenantId": "72f988bf-86f1-41af-91ab-2d7cd011db47"
                                     }
                                   }}
CreatedByEmail                   : v-jiaji@microsoft.com
CreatedByName                    : Joyer Jin (Wicresoft North America Ltd)
CreatedByObjectId                : 6205f759-1234-453c-9712-34d7671bceff
CreatedByUserPrincipalName       : v-jiaji@microsoft.com
CreatedTimeUtc                   : 8/4/2023 10:57:22 AM
DisplayName                      : Run Playbook to reset AAD password
Etag                             : "0b0032b0-0000-0100-0000-64ccd9920000"
Id                               : /subscriptions/9e223dbe-3399-4e19-88eb-0975f02ac87f/resourceGroups/si-jj-test/providers/Microsoft.OperationalInsights/workspaces/si-test-ws/ 
                                   providers/Microsoft.SecurityInsights/AutomationRules/ed8c40f0-af1c-4774-82c3-e86e79f33ff8
LastModifiedByEmail              : v-jiaji@microsoft.com
LastModifiedByName               : Joyer Jin (Wicresoft North America Ltd)
LastModifiedByObjectId           : 6205f759-1234-453c-9712-34d7671bceff
LastModifiedByUserPrincipalName  : v-jiaji@microsoft.com
LastModifiedTimeUtc              : 8/4/2023 10:57:22 AM
Name                             : ed8c40f0-af1c-4774-82c3-e86e79f33ff8
Order                            : 2
ResourceGroupName                : si-jj-test
SystemDataCreatedAt              : 
SystemDataCreatedBy              : 
SystemDataCreatedByType          : 
SystemDataLastModifiedAt         : 
SystemDataLastModifiedBy         : 
SystemDataLastModifiedByType     : 
TriggeringLogicCondition         : {}
TriggeringLogicExpirationTimeUtc : 
TriggeringLogicIsEnabled         : True
TriggeringLogicTriggersOn        : Alerts
TriggeringLogicTriggersWhen      : Created
Type                             : Microsoft.SecurityInsights/AutomationRules
```

This command creates an Automation Rule that has an Action of Run Playbook.

+ Example 2: Creates an Automation Rule that has an Action of changing the severity
```powershell
$automationRuleAction2 = New-AzSentinelAutomationRuleActionObject -ActionType ModifyProperties -Order 1 -Severity High
#### Condition document link https://learn.microsoft.com/en-us/azure/sentinel/create-manage-use-automation-rules####define-conditions
$triggeringLogicCondition = New-AzSentinelAutomationRuleActionCondition -Type PropertyChanged -ChangedPropertyName IncidentOwner
New-AzSentinelAutomationRule -ResourceGroupName "si-jj-test" -WorkspaceName "si-test-ws3" -Action $automationRuleAction2 -DisplayName "Change severity to High" -Order 3 -TriggeringLogicIsEnabled -TriggeringLogicTriggersOn Incidents -TriggeringLogicTriggersWhen Updated -TriggeringLogicCondition $triggeringLogicCondition
```

This command creates an Automation Rule that has an Action of changing the severity.


#### Get-AzSentinelAutomationRule

#### SYNOPSIS
Gets the automation rule.

#### SYNTAX

+ List (Default)
```powershell
Get-AzSentinelAutomationRule -ResourceGroupName <String> -WorkspaceName <String> [-SubscriptionId <String[]>]
 [-DefaultProfile <PSObject>] [<CommonParameters>]
```

+ Get
```powershell
Get-AzSentinelAutomationRule -Id <String> -ResourceGroupName <String> -WorkspaceName <String>
 [-SubscriptionId <String[]>] [-DefaultProfile <PSObject>] [<CommonParameters>]
```

+ GetViaIdentity
```powershell
Get-AzSentinelAutomationRule -InputObject <ISecurityInsightsIdentity> [-DefaultProfile <PSObject>]
 [<CommonParameters>]
```

+ GetViaIdentityWorkspace
```powershell
Get-AzSentinelAutomationRule -Id <String> -WorkspaceInputObject <ISecurityInsightsIdentity>
 [-DefaultProfile <PSObject>] [<CommonParameters>]
```

#### EXAMPLES

+ Example 1: List all Automation Rules
```powershell
Get-AzSentinelAutomationRule -ResourceGroupName "si-jj-test" -WorkspaceName "si-test-ws"
```

```output
Action                           : {{
                                     "order": 1,
                                     "actionType": "ModifyProperties",
                                     "actionConfiguration": {
                                       "severity": "High"
                                     }
                                   }}
CreatedByEmail                   : v-jiaji@microsoft.com
CreatedByName                    : Joyer Jin (Wicresoft North America Ltd)
CreatedByObjectId                : 6205f759-1234-453c-9712-34d7671bceff
CreatedByUserPrincipalName       : v-jiaji@microsoft.com
CreatedTimeUtc                   : 8/4/2023 10:07:55 AM
DisplayName                      : Change severity to High
Etag                             : "0b009c21-0000-0100-0000-64cccdfb0000"
Id                               : /subscriptions/9e223dbe-3399-4e19-88eb-0975f02ac87f/resourceGroups/si-jj-test/providers/Microsoft.OperationalInsights/workspaces/si-test-ws/ 
                                   providers/Microsoft.SecurityInsights/AutomationRules/240357d9-583c-4889-ae96-a8372d62349a
LastModifiedByEmail              : v-jiaji@microsoft.com
LastModifiedByName               : Joyer Jin (Wicresoft North America Ltd)
LastModifiedByObjectId           : 6205f759-1234-453c-9712-34d7671bceff
LastModifiedByUserPrincipalName  : v-jiaji@microsoft.com
LastModifiedTimeUtc              : 8/4/2023 10:07:55 AM
Name                             : 240357d9-583c-4889-ae96-a8372d62349a
Order                            : 3
ResourceGroupName                : si-jj-test
SystemDataCreatedAt              : 
SystemDataCreatedBy              : 
SystemDataCreatedByType          : 
SystemDataLastModifiedAt         : 
SystemDataLastModifiedBy         : 
SystemDataLastModifiedByType     : 
TriggeringLogicCondition         : {{
                                     "conditionType": "PropertyChanged",
                                     "conditionProperties": {
                                       "propertyName": "IncidentStatus",
                                       "changeType": "ChangedTo",
                                       "operator": "Equals",
                                       "propertyValues": [ "Active" ]
                                     }
                                   }}
TriggeringLogicExpirationTimeUtc : 
TriggeringLogicIsEnabled         : True
TriggeringLogicTriggersOn        : Incidents
TriggeringLogicTriggersWhen      : Updated
Type                             : Microsoft.SecurityInsights/AutomationRules
```

This command lists all Automation Rules under a Microsoft Sentinel workspace.

+ Example 2: Get an Automation Rule
```powershell
 Get-AzSentinelAutomationRule -ResourceGroupName "si-jj-test" -WorkspaceName "si-test-ws" -Id "240357d9-583c-4889-ae96-a8372d62349a"
```

```output
Action                           : {{
                                     "order": 1,
                                     "actionType": "ModifyProperties",
                                     "actionConfiguration": {
                                       "severity": "High"
                                     }
                                   }}
CreatedByEmail                   : v-jiaji@microsoft.com
CreatedByName                    : Joyer Jin (Wicresoft North America Ltd)
CreatedByObjectId                : 6205f759-1234-453c-9712-34d7671bceff
CreatedByUserPrincipalName       : v-jiaji@microsoft.com
CreatedTimeUtc                   : 8/4/2023 10:07:55 AM
DisplayName                      : Change severity to High
Etag                             : "0b009c21-0000-0100-0000-64cccdfb0000"
Id                               : /subscriptions/9e223dbe-3399-4e19-88eb-0975f02ac87f/resourceGroups/si-jj-test/providers/Microsoft.OperationalInsights/workspaces/si-test-ws/ 
                                   providers/Microsoft.SecurityInsights/AutomationRules/240357d9-583c-4889-ae96-a8372d62349a
LastModifiedByEmail              : v-jiaji@microsoft.com
LastModifiedByName               : Joyer Jin (Wicresoft North America Ltd)
LastModifiedByObjectId           : 6205f759-1234-453c-9712-34d7671bceff
LastModifiedByUserPrincipalName  : v-jiaji@microsoft.com
LastModifiedTimeUtc              : 8/4/2023 10:07:55 AM
Name                             : 240357d9-583c-4889-ae96-a8372d62349a
Order                            : 3
ResourceGroupName                : si-jj-test
SystemDataCreatedAt              : 
SystemDataCreatedBy              : 
SystemDataCreatedByType          : 
SystemDataLastModifiedAt         : 
SystemDataLastModifiedBy         : 
SystemDataLastModifiedByType     : 
TriggeringLogicCondition         : {{
                                     "conditionType": "PropertyChanged",
                                     "conditionProperties": {
                                       "propertyName": "IncidentStatus",
                                       "changeType": "ChangedTo",
                                       "operator": "Equals",
                                       "propertyValues": [ "Active" ]
                                     }
                                   }}
TriggeringLogicExpirationTimeUtc : 
TriggeringLogicIsEnabled         : True
TriggeringLogicTriggersOn        : Incidents
TriggeringLogicTriggersWhen      : Updated
Type                             : Microsoft.SecurityInsights/AutomationRules
```

This command gets an Automation Rule.


#### Remove-AzSentinelAutomationRule

#### SYNOPSIS
Delete the automation rule.

#### SYNTAX

+ Delete (Default)
```powershell
Remove-AzSentinelAutomationRule -Id <String> -ResourceGroupName <String> -WorkspaceName <String>
 [-SubscriptionId <String>] [-DefaultProfile <PSObject>] [-Confirm] [-WhatIf] [<CommonParameters>]
```

+ DeleteViaIdentity
```powershell
Remove-AzSentinelAutomationRule -InputObject <ISecurityInsightsIdentity> [-DefaultProfile <PSObject>]
 [-Confirm] [-WhatIf] [<CommonParameters>]
```

+ DeleteViaIdentityWorkspace
```powershell
Remove-AzSentinelAutomationRule -Id <String> -WorkspaceInputObject <ISecurityInsightsIdentity>
 [-DefaultProfile <PSObject>] [-Confirm] [-WhatIf] [<CommonParameters>]
```

#### EXAMPLES

+ Example 1: Removes a Sentinel automation rule
```powershell
Remove-AzSentinelAutomationRule -ResourceGroupName "si-jj-test" -WorkspaceName "si-test-ws" -Id 240357d9-583c-4889-ae96-a8372d62349a
```

This command removes a Sentinel automation rule


#### Update-AzSentinelAutomationRule

#### SYNOPSIS
Create the automation rule.

#### SYNTAX

+ UpdateViaIdentityExpanded (Default)
```powershell
Update-AzSentinelAutomationRule -InputObject <ISecurityInsightsIdentity> -Action <IAutomationRuleAction[]>
 -DisplayName <String> -Order <Int32> -TriggeringLogicIsEnabled -TriggeringLogicTriggersOn <String>
 -TriggeringLogicTriggersWhen <String> [-TriggeringLogicCondition <IAutomationRuleCondition[]>]
 [-TriggeringLogicExpirationTimeUtc <DateTime>] [-DefaultProfile <PSObject>] [-Confirm] [-WhatIf]
 [<CommonParameters>]
```

+ UpdateExpanded
```powershell
Update-AzSentinelAutomationRule -Id <String> -ResourceGroupName <String> -WorkspaceName <String>
 -Action <IAutomationRuleAction[]> -DisplayName <String> -Order <Int32> -TriggeringLogicIsEnabled
 -TriggeringLogicTriggersOn <String> -TriggeringLogicTriggersWhen <String> [-SubscriptionId <String>]
 [-TriggeringLogicCondition <IAutomationRuleCondition[]>] [-TriggeringLogicExpirationTimeUtc <DateTime>]
 [-DefaultProfile <PSObject>] [-Confirm] [-WhatIf] [<CommonParameters>]
```

+ UpdateViaIdentityWorkspaceExpanded
```powershell
Update-AzSentinelAutomationRule -Id <String> -WorkspaceInputObject <ISecurityInsightsIdentity>
 -Action <IAutomationRuleAction[]> -DisplayName <String> -Order <Int32> -TriggeringLogicIsEnabled
 -TriggeringLogicTriggersOn <String> -TriggeringLogicTriggersWhen <String>
 [-TriggeringLogicCondition <IAutomationRuleCondition[]>] [-TriggeringLogicExpirationTimeUtc <DateTime>]
 [-DefaultProfile <PSObject>] [-Confirm] [-WhatIf] [<CommonParameters>]
```

#### EXAMPLES

+ Example 1: Updates an automation rule
```powershell
$LogicAppResource = Get-AzLogicApp -ResourceGroupName "si-jj-test" -Name "IncidentLogicApp"
$automationRuleAction = New-AzSentinelAutomationRuleActionObject -ActionType RunPlaybook -Order 1 -LogicAppResourceId $LogicAppResource.Id -TenantId (Get-AzContext).Tenant.Id
Update-AzSentinelAutomationRule -ResourceGroupName "si-jj-test" -WorkspaceName "si-test-ws3" -Id ((New-Guid).Guid) -Action $automationRuleAction -DisplayName "Run Playbook to Incident create" -Order 2 -TriggeringLogicIsEnabled -TriggeringLogicTriggersOn Incidents -TriggeringLogicTriggersWhen Created
```

```output
Action                           : {{
                                     "order": 1,
                                     "actionType": "RunPlaybook",
                                     "actionConfiguration": {
                                       "logicAppResourceId":
                                   "/subscriptions/9e223dbe-3399-4e19-88eb-0975f02ac87f/resourceGroups/si-jj-test/providers/Microsoft.Logic/workflows/IncidentLogicApp",
                                       "tenantId": "72f988bf-86f1-41af-91ab-2d7cd011db47"
                                     }
                                   }}
CreatedByEmail                   : v-jiaji@microsoft.com
CreatedByName                    : Joyer Jin (Wicresoft North America Ltd)
CreatedByObjectId                : 6205f759-1234-453c-9712-34d7671bceff
CreatedByUserPrincipalName       : v-jiaji@microsoft.com
CreatedTimeUtc                   : 8/9/2023 1:58:17 AM
DisplayName                      : Run Playbook to Incident create
Etag                             : "4e005720-0000-0100-0000-64d2f2b90000"
Id                               : /subscriptions/9e223dbe-3399-4e19-88eb-0975f02ac87f/resourceGroups/si-jj-test/providers/Microsoft.OperationalInsights/workspaces/si-test-ws3/providers/Micros 
                                   oft.SecurityInsights/AutomationRules/e9b32c90-071e-4db7-b1d2-a931d895a6c3
LastModifiedByEmail              : v-jiaji@microsoft.com
LastModifiedByName               : Joyer Jin (Wicresoft North America Ltd)
LastModifiedByObjectId           : 6205f759-1234-453c-9712-34d7671bceff
LastModifiedByUserPrincipalName  : v-jiaji@microsoft.com
LastModifiedTimeUtc              : 8/9/2023 1:58:17 AM
Name                             : e9b32c90-071e-4db7-b1d2-a931d895a6c3
Order                            : 2
ResourceGroupName                : si-jj-test
SystemDataCreatedAt              : 
SystemDataCreatedBy              : 
SystemDataCreatedByType          : 
SystemDataLastModifiedAt         : 
SystemDataLastModifiedBy         : 
SystemDataLastModifiedByType     : 
TriggeringLogicCondition         : {}
TriggeringLogicExpirationTimeUtc : 
TriggeringLogicIsEnabled         : True
TriggeringLogicTriggersOn        : Incidents
TriggeringLogicTriggersWhen      : Created
Type                             : Microsoft.SecurityInsights/AutomationRules
```

This command updates an automation rule


#### New-AzSentinelAutomationRuleActionCondition

#### SYNOPSIS
Create the automation rule action condition.

#### SYNTAX

+ CreatePropertyArrayChanged (Default)
```powershell
New-AzSentinelAutomationRuleActionCondition -Type <String> [-ArrayChangeType <String>] [-ArrayType <String>]
 [<CommonParameters>]
```

+ CreateProperty
```powershell
New-AzSentinelAutomationRuleActionCondition -Type <String> [-Operator <String>] [-PropertyName <String>]
 [-PropertyValue <String[]>] [<CommonParameters>]
```

+ CreatePropertyChanged
```powershell
New-AzSentinelAutomationRuleActionCondition -Type <String> [-ChangedPropertyName <Object>]
 [-ChangeType <String>] [-Operator <String>] [-PropertyValue <String[]>] [<CommonParameters>]
```

#### EXAMPLES

+ Example 1: Create a PropertyChanged automation rule condition object for automation rule
```powershell
New-AzSentinelAutomationRuleActionCondition -Type PropertyChanged -ChangedPropertyName IncidentOwner
```

```output
ConditionPropertyChangeType : 
ConditionPropertyName       : IncidentOwner
ConditionPropertyOperator   : 
ConditionPropertyValue      : 
ConditionType               : PropertyChanged
```

This command creates an automation rule condition object for automation rule


#### New-AzSentinelAutomationRuleActionObject

#### SYNOPSIS
Create the automation rule action object.

#### SYNTAX

+ CreateRunPlaybook (Default)
```powershell
New-AzSentinelAutomationRuleActionObject -ActionType <String> -Order <Int32> [-LogicAppResourceId <String>]
 [-TenantId <String>] [<CommonParameters>]
```

+ CreateModifyProperties
```powershell
New-AzSentinelAutomationRuleActionObject -ActionType <String> -Order <Int32> [-Classification <String>]
 [-ClassificationComment <String>] [-ClassificationReason <String>] [-Label <IIncidentLabel>]
 [-OwnerAssignedTo <String>] [-OwnerEmail <String>] [-OwnerObjectId <String>] [-OwnerType <String>]
 [-OwnerUserPrincipalName <String>] [-Severity <String>] [-Status <String>] [<CommonParameters>]
```

#### EXAMPLES

+ Example 1: Create a RunPlaybook automation rule action object for automation rule
```powershell
New-AzSentinelAutomationRuleActionObject -ActionType RunPlaybook -Order 1 -LogicAppResourceId $LogicAppResource.Id -TenantId (Get-AzContext).Tenant.Id
```

```output
ActionConfigurationLogicAppResourceId                                                                                           ActionConfigurationTenantId          ActionType  Order
-------------------------------------                                                                                           ---------------------------          ----------  -----
/subscriptions/9e223dbe-3399-4e19-88eb-0975f02ac87f/resourceGroups/si-jj-test/providers/Microsoft.Logic/workflows/AlertLogicApp 72f988bf-86f1-41af-91ab-2d7cd011db47 RunPlaybook     1
```

This command creates a automation rule action object for automation rule.

+ Example 2: Create a ModifyProperties automation rule action object for automation rule
```powershell
New-AzSentinelAutomationRuleActionObject -ActionType ModifyProperties -Order 1 -Severity High
```

```output
ActionConfigurationClassification        : 
ActionConfigurationClassificationComment : 
ActionConfigurationClassificationReason  : 
ActionConfigurationLabel                 : 
ActionConfigurationSeverity              : High
ActionConfigurationStatus                : 
ActionType                               : ModifyProperties
Order                                    : 1
OwnerAssignedTo                          : 
OwnerEmail                               : 
OwnerObjectId                            : 
OwnerType                                : 
OwnerUserPrincipalName                   : 
```

This command creates a ModifyProperties automation rule action object for automation rule.


#### New-AzSentinelBookmark

#### SYNOPSIS
Create the bookmark.

#### SYNTAX

+ CreateExpanded (Default)
```powershell
New-AzSentinelBookmark -ResourceGroupName <String> -WorkspaceName <String> [-Id <String>]
 [-SubscriptionId <String>] [-DisplayName <String>] [-EventTime <DateTime>] [-IncidentInfoIncidentId <String>]
 [-IncidentInfoRelationName <String>] [-IncidentInfoSeverity <String>] [-IncidentInfoTitle <String>]
 [-Label <String[]>] [-Note <String>] [-Query <String>] [-QueryEndTime <DateTime>] [-QueryResult <String>]
 [-QueryStartTime <DateTime>] [-UpdatedByObjectId <String>] [-DefaultProfile <PSObject>] [-Confirm] [-WhatIf]
 [<CommonParameters>]
```

+ CreateViaIdentityExpanded
```powershell
New-AzSentinelBookmark -InputObject <ISecurityInsightsIdentity> [-DisplayName <String>]
 [-EventTime <DateTime>] [-IncidentInfoIncidentId <String>] [-IncidentInfoRelationName <String>]
 [-IncidentInfoSeverity <String>] [-IncidentInfoTitle <String>] [-Label <String[]>] [-Note <String>]
 [-Query <String>] [-QueryEndTime <DateTime>] [-QueryResult <String>] [-QueryStartTime <DateTime>]
 [-UpdatedByObjectId <String>] [-DefaultProfile <PSObject>] [-Confirm] [-WhatIf] [<CommonParameters>]
```

+ CreateViaIdentityWorkspaceExpanded
```powershell
New-AzSentinelBookmark -WorkspaceInputObject <ISecurityInsightsIdentity> [-Id <String>]
 [-DisplayName <String>] [-EventTime <DateTime>] [-IncidentInfoIncidentId <String>]
 [-IncidentInfoRelationName <String>] [-IncidentInfoSeverity <String>] [-IncidentInfoTitle <String>]
 [-Label <String[]>] [-Note <String>] [-Query <String>] [-QueryEndTime <DateTime>] [-QueryResult <String>]
 [-QueryStartTime <DateTime>] [-UpdatedByObjectId <String>] [-DefaultProfile <PSObject>] [-Confirm] [-WhatIf]
 [<CommonParameters>]
```

#### EXAMPLES

+ Example 1: Create a Bookmark
```powershell
$queryStartTime = (Get-Date).AddDays(-1).ToUniversalTime() | Get-Date -Format "yyyy-MM-ddThh:00:00.000Z"
$queryEndTime = (Get-Date).ToUniversalTime() | Get-Date -Format "yyyy-MM-ddThh:00:00.000Z"
New-AzSentinelBookmark -ResourceGroupName "si-jj-test" -WorkspaceName "si-test-ws" -DisplayName "Incident Evidence" -Query "SecurityEvent | take 1" -QueryStartTime $queryStartTime -QueryEndTime $queryEndTime -EventTime $queryEndTime
```

```output
Created                      : 8/2/2023 9:34:31 AM
CreatedByEmail               : v-jiaji@microsoft.com
CreatedByName                : Joyer Jin (Wicresoft North America Ltd)
CreatedByObjectId            : 6205f759-1234-453c-9712-34d7671bceff
DisplayName                  : Incident Evidence
Etag                         : "5a0a5305-0000-0100-0000-64ca23270000"
EventTime                    : 8/2/2023 9:00:00 AM
Id                           : /subscriptions/9e223dbe-3399-4e19-88eb-0975f02ac87f/resourceGroups/si-jj-test/providers/Microsoft.OperationalInsights/workspaces/si-test-ws/prov 
                               iders/Microsoft.SecurityInsights/Bookmarks/70aaef57-7165-444b-959d-67e6668d57d0
IncidentInfoIncidentId       : 
IncidentInfoRelationName     : 
IncidentInfoSeverity         : 
IncidentInfoTitle            : 
Label                        : {}
Name                         : 70aaef57-7165-444b-959d-67e6668d57d0
Note                         : 
Query                        : SecurityEvent | take 1
QueryEndTime                 : 8/2/2023 9:00:00 AM
QueryResult                  : 
QueryStartTime               : 8/1/2023 9:00:00 AM
ResourceGroupName            : si-jj-test
SystemDataCreatedAt          : 
SystemDataCreatedBy          : 
SystemDataCreatedByType      : 
SystemDataLastModifiedAt     : 
SystemDataLastModifiedBy     : 
SystemDataLastModifiedByType : 
Type                         : Microsoft.SecurityInsights/Bookmarks
Updated                      : 8/2/2023 9:34:31 AM
UpdatedByEmail               : v-jiaji@microsoft.com
UpdatedByName                : Joyer Jin (Wicresoft North America Ltd)
UpdatedByObjectId            : 6205f759-1234-453c-9712-34d7671bceff
```

This command creates a Bookmark.


#### Get-AzSentinelBookmark

#### SYNOPSIS
Gets a bookmark.

#### SYNTAX

+ List (Default)
```powershell
Get-AzSentinelBookmark -ResourceGroupName <String> -WorkspaceName <String> [-SubscriptionId <String[]>]
 [-DefaultProfile <PSObject>] [<CommonParameters>]
```

+ Get
```powershell
Get-AzSentinelBookmark -Id <String> -ResourceGroupName <String> -WorkspaceName <String>
 [-SubscriptionId <String[]>] [-DefaultProfile <PSObject>] [<CommonParameters>]
```

+ GetViaIdentity
```powershell
Get-AzSentinelBookmark -InputObject <ISecurityInsightsIdentity> [-DefaultProfile <PSObject>]
 [<CommonParameters>]
```

+ GetViaIdentityWorkspace
```powershell
Get-AzSentinelBookmark -Id <String> -WorkspaceInputObject <ISecurityInsightsIdentity>
 [-DefaultProfile <PSObject>] [<CommonParameters>]
```

#### EXAMPLES

+ Example 1: List all Bookmarks
```powershell
Get-AzSentinelBookmark -ResourceGroupName "si-jj-test" -WorkspaceName "si-test-ws"
```

```output
Created                      : 8/2/2023 9:34:31 AM
CreatedByEmail               : v-jiaji@microsoft.com
CreatedByName                : Joyer Jin (Wicresoft North America Ltd)
CreatedByObjectId            : 6205f759-1234-453c-9712-34d7671bceff
DisplayName                  : Incident Evidence
Etag                         : "5a0a5305-0000-0100-0000-64ca23270000"
EventTime                    : 8/2/2023 9:00:00 AM
Id                           : /subscriptions/9e223dbe-3399-4e19-88eb-0975f02ac87f/resourceGroups/si-jj-test/providers/Microsoft.OperationalInsights/workspaces/si-test-ws/prov 
                               iders/Microsoft.SecurityInsights/Bookmarks/70aaef57-7165-444b-959d-67e6668d57d0
IncidentInfoIncidentId       : 
IncidentInfoRelationName     : 
IncidentInfoSeverity         : 
IncidentInfoTitle            : 
Label                        : {}
Name                         : 70aaef57-7165-444b-959d-67e6668d57d0
Note                         : 
Query                        : SecurityEvent | take 1
QueryEndTime                 : 8/2/2023 9:00:00 AM
QueryResult                  : 
QueryStartTime               : 8/1/2023 9:00:00 AM
ResourceGroupName            : si-jj-test
SystemDataCreatedAt          : 
SystemDataCreatedBy          : 
SystemDataCreatedByType      : 
SystemDataLastModifiedAt     : 
SystemDataLastModifiedBy     : 
SystemDataLastModifiedByType : 
Type                         : Microsoft.SecurityInsights/Bookmarks
Updated                      : 8/2/2023 9:34:31 AM
UpdatedByEmail               : v-jiaji@microsoft.com
UpdatedByName                : Joyer Jin (Wicresoft North America Ltd)
UpdatedByObjectId            : 6205f759-1234-453c-9712-34d7671bceff
```

This command lists all Bookmarks under a Microsoft Sentinel workspace.

+ Example 2: Get a Bookmark
```powershell
Get-AzSentinelBookmark -ResourceGroupName "si-jj-test" -WorkspaceName "si-test-ws" -Id "70aaef57-7165-444b-959d-67e6668d57d0"
```

```output
Created                      : 8/2/2023 9:34:31 AM
CreatedByEmail               : v-jiaji@microsoft.com
CreatedByName                : Joyer Jin (Wicresoft North America Ltd)
CreatedByObjectId            : 6205f759-1234-453c-9712-34d7671bceff
DisplayName                  : Incident Evidence
Etag                         : "5a0a5305-0000-0100-0000-64ca23270000"
EventTime                    : 8/2/2023 9:00:00 AM
Id                           : /subscriptions/9e223dbe-3399-4e19-88eb-0975f02ac87f/resourceGroups/si-jj-test/providers/Microsoft.OperationalInsights/workspaces/si-test-ws/prov 
                               iders/Microsoft.SecurityInsights/Bookmarks/70aaef57-7165-444b-959d-67e6668d57d0
IncidentInfoIncidentId       : 
IncidentInfoRelationName     : 
IncidentInfoSeverity         : 
IncidentInfoTitle            : 
Label                        : {}
Name                         : 70aaef57-7165-444b-959d-67e6668d57d0
Note                         : 
Query                        : SecurityEvent | take 1
QueryEndTime                 : 8/2/2023 9:00:00 AM
QueryResult                  : 
QueryStartTime               : 8/1/2023 9:00:00 AM
ResourceGroupName            : si-jj-test
SystemDataCreatedAt          : 
SystemDataCreatedBy          : 
SystemDataCreatedByType      : 
SystemDataLastModifiedAt     : 
SystemDataLastModifiedBy     : 
SystemDataLastModifiedByType : 
Type                         : Microsoft.SecurityInsights/Bookmarks
Updated                      : 8/2/2023 9:34:31 AM
UpdatedByEmail               : v-jiaji@microsoft.com
UpdatedByName                : Joyer Jin (Wicresoft North America Ltd)
UpdatedByObjectId            : 6205f759-1234-453c-9712-34d7671bceff
```

This command gets a Bookmark.


#### Remove-AzSentinelBookmark

#### SYNOPSIS
Delete the bookmark.

#### SYNTAX

+ Delete (Default)
```powershell
Remove-AzSentinelBookmark -Id <String> -ResourceGroupName <String> -WorkspaceName <String>
 [-SubscriptionId <String>] [-DefaultProfile <PSObject>] [-PassThru] [-Confirm] [-WhatIf] [<CommonParameters>]
```

+ DeleteViaIdentity
```powershell
Remove-AzSentinelBookmark -InputObject <ISecurityInsightsIdentity> [-DefaultProfile <PSObject>] [-PassThru]
 [-Confirm] [-WhatIf] [<CommonParameters>]
```

+ DeleteViaIdentityWorkspace
```powershell
Remove-AzSentinelBookmark -Id <String> -WorkspaceInputObject <ISecurityInsightsIdentity>
 [-DefaultProfile <PSObject>] [-PassThru] [-Confirm] [-WhatIf] [<CommonParameters>]
```

#### EXAMPLES

+ Example 1: Remove a Sentinel Bookmark
```powershell
Remove-AzSentinelBookmark -ResourceGroupName "myResourceGroup" -WorkspaceName "myWorkspaceName" -Id <bookMarkId> 
```

This command removes a bookmark


#### Update-AzSentinelBookmark

#### SYNOPSIS
Create the bookmark.

#### SYNTAX

+ UpdateExpanded (Default)
```powershell
Update-AzSentinelBookmark -Id <String> -ResourceGroupName <String> -WorkspaceName <String>
 [-SubscriptionId <String>] [-DisplayName <String>] [-EventTime <DateTime>] [-IncidentInfoIncidentId <String>]
 [-IncidentInfoRelationName <String>] [-IncidentInfoSeverity <String>] [-IncidentInfoTitle <String>]
 [-Label <String[]>] [-Note <String>] [-Query <String>] [-QueryEndTime <DateTime>] [-QueryResult <String>]
 [-QueryStartTime <DateTime>] [-UpdatedByObjectId <String>] [-DefaultProfile <PSObject>] [-Confirm] [-WhatIf]
 [<CommonParameters>]
```

+ UpdateViaIdentityExpanded
```powershell
Update-AzSentinelBookmark -InputObject <ISecurityInsightsIdentity> [-DisplayName <String>]
 [-EventTime <DateTime>] [-IncidentInfoIncidentId <String>] [-IncidentInfoRelationName <String>]
 [-IncidentInfoSeverity <String>] [-IncidentInfoTitle <String>] [-Label <String[]>] [-Note <String>]
 [-Query <String>] [-QueryEndTime <DateTime>] [-QueryResult <String>] [-QueryStartTime <DateTime>]
 [-UpdatedByObjectId <String>] [-DefaultProfile <PSObject>] [-Confirm] [-WhatIf] [<CommonParameters>]
```

+ UpdateViaIdentityWorkspaceExpanded
```powershell
Update-AzSentinelBookmark -Id <String> -WorkspaceInputObject <ISecurityInsightsIdentity>
 [-DisplayName <String>] [-EventTime <DateTime>] [-IncidentInfoIncidentId <String>]
 [-IncidentInfoRelationName <String>] [-IncidentInfoSeverity <String>] [-IncidentInfoTitle <String>]
 [-Label <String[]>] [-Note <String>] [-Query <String>] [-QueryEndTime <DateTime>] [-QueryResult <String>]
 [-QueryStartTime <DateTime>] [-UpdatedByObjectId <String>] [-DefaultProfile <PSObject>] [-Confirm] [-WhatIf]
 [<CommonParameters>]
```

#### EXAMPLES

+ Example 1: Update Sentinel Bookmark
```powershell
 $queryStartTime = (Get-Date).AddDays(-1).ToUniversalTime() | Get-Date -Format "yyyy-MM-ddThh:00:00.000Z"
 $queryEndTime = (Get-Date).ToUniversalTime() | Get-Date -Format "yyyy-MM-ddThh:00:00.000Z"
 Update-AzSentinelBookmark -ResourceGroupName "myResourceGroup" -WorkspaceName "myWorkspaceName" -Id ((New-Guid).Guid) -DisplayName "Incident Evidence" -Query "SecurityEvent | take 1" -QueryStartTime $queryStartTime -QueryEndTime $queryEndTime -EventTime $queryEndTime
```

This command updates a bookmark


#### New-AzSentinelDataConnector

#### SYNOPSIS
Create the data connector.

#### SYNTAX

+ AADAATP (Default)
```powershell
New-AzSentinelDataConnector -ResourceGroupName <String> -WorkspaceName <String> -Kind <String> [-Id <String>]
 [-SubscriptionId <String>] [-Alerts <String>] [-TenantId <String>] [-DefaultProfile <PSObject>] [-AsJob]
 [-NoWait] [-Confirm] [-WhatIf] [<CommonParameters>]
```

+ AmazonWebServicesCloudTrail
```powershell
New-AzSentinelDataConnector -ResourceGroupName <String> -WorkspaceName <String> -AWSRoleArn <String>
 -Kind <String> [-Id <String>] [-SubscriptionId <String>] [-Log <String>] [-DefaultProfile <PSObject>]
 [-AsJob] [-NoWait] [-Confirm] [-WhatIf] [<CommonParameters>]
```

+ AzureSecurityCenter
```powershell
New-AzSentinelDataConnector -ResourceGroupName <String> -WorkspaceName <String> -ASCSubscriptionId <String>
 -Kind <String> [-Id <String>] [-SubscriptionId <String>] [-Alerts <String>] [-DefaultProfile <PSObject>]
 [-AsJob] [-NoWait] [-Confirm] [-WhatIf] [<CommonParameters>]
```

+ MicrosoftCloudAppSecurity
```powershell
New-AzSentinelDataConnector -ResourceGroupName <String> -WorkspaceName <String> -Kind <String> [-Id <String>]
 [-SubscriptionId <String>] [-Alerts <String>] [-DiscoveryLog <String>] [-TenantId <String>]
 [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-Confirm] [-WhatIf] [<CommonParameters>]
```

+ MicrosoftDefenderAdvancedThreatProtection
```powershell
New-AzSentinelDataConnector -ResourceGroupName <String> -WorkspaceName <String> -Kind <String> [-Id <String>]
 [-SubscriptionId <String>] [-Alerts <String>] [-TenantId <String>] [-DefaultProfile <PSObject>] [-AsJob]
 [-NoWait] [-Confirm] [-WhatIf] [<CommonParameters>]
```

+ Office365
```powershell
New-AzSentinelDataConnector -ResourceGroupName <String> -WorkspaceName <String> -Kind <String> [-Id <String>]
 [-SubscriptionId <String>] [-Alerts <String>] [-Exchange <String>] [-SharePoint <String>] [-Teams <String>]
 [-TenantId <String>] [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-Confirm] [-WhatIf]
 [<CommonParameters>]
```

+ ThreatIntelligence
```powershell
New-AzSentinelDataConnector -ResourceGroupName <String> -WorkspaceName <String> -Kind <String> [-Id <String>]
 [-SubscriptionId <String>] [-Indicator <String>] [-TenantId <String>] [-DefaultProfile <PSObject>] [-AsJob]
 [-NoWait] [-Confirm] [-WhatIf] [<CommonParameters>]
```

#### EXAMPLES

+ Example 1: Enable a data connector.
```powershell
New-AzSentinelDataConnector -ResourceGroupName "myResourceGroupName" -WorkspaceName "myWorkspaceName" -Kind 'MicrosoftThreatIntelligence' -BingSafetyPhishingURL Enabled -BingSafetyPhishingUrlLookbackPeriod All  -MicrosoftEmergingThreatFeed Enabled -MicrosoftEmergingThreatFeedLookbackPeriod All
```

This command enables the Threat Intelligence data connector


#### Get-AzSentinelDataConnector

#### SYNOPSIS
Gets a data connector.

#### SYNTAX

+ List (Default)
```powershell
Get-AzSentinelDataConnector -ResourceGroupName <String> -WorkspaceName <String> [-SubscriptionId <String[]>]
 [-DefaultProfile <PSObject>] [<CommonParameters>]
```

+ Get
```powershell
Get-AzSentinelDataConnector -Id <String> -ResourceGroupName <String> -WorkspaceName <String>
 [-SubscriptionId <String[]>] [-DefaultProfile <PSObject>] [<CommonParameters>]
```

+ GetViaIdentity
```powershell
Get-AzSentinelDataConnector -InputObject <ISecurityInsightsIdentity> [-DefaultProfile <PSObject>]
 [<CommonParameters>]
```

+ GetViaIdentityWorkspace
```powershell
Get-AzSentinelDataConnector -Id <String> -WorkspaceInputObject <ISecurityInsightsIdentity>
 [-DefaultProfile <PSObject>] [<CommonParameters>]
```

#### EXAMPLES

+ Example 1: List all Data Connectors
```powershell
 Get-AzSentinelDataConnector -ResourceGroupName "myResourceGroupName" -workspaceName "myWorkspaceName"
```

```output
Kind : AzureActiveDirectory
Name : 8207e1f9-a793-4869-afb1-5ad4540d66d1

Kind : AzureAdvancedThreatProtection
Name : 1d75aada-a558-4461-986b-c6822182e81d

Kind : Office365
Name : 6323c716-83ae-4cfd-bf93-58235c8beb23

```

This command lists all DataConnectors under a Microsoft Sentinel workspace.

+ Example 2: Get a specific Data Connector
```powershell
 Get-AzSentinelDataConnector -ResourceGroupName "myResourceGroupName" -workspaceName "myWorkspaceName" | Where-Object {$_.kind -eq "Office365"}
```

```output
Kind                         : Office365
Name                         : 6323c716-83ae-4cfd-bf93-58235c8beb23
SharePointState              : enabled
```

This command gets a specific DataConnector based on kind


#### Remove-AzSentinelDataConnector

#### SYNOPSIS
Delete the data connector.

#### SYNTAX

+ Delete (Default)
```powershell
Remove-AzSentinelDataConnector -Id <String> -ResourceGroupName <String> -WorkspaceName <String>
 [-SubscriptionId <String>] [-DefaultProfile <PSObject>] [-PassThru] [-Confirm] [-WhatIf] [<CommonParameters>]
```

+ DeleteViaIdentity
```powershell
Remove-AzSentinelDataConnector -InputObject <ISecurityInsightsIdentity> [-DefaultProfile <PSObject>]
 [-PassThru] [-Confirm] [-WhatIf] [<CommonParameters>]
```

+ DeleteViaIdentityWorkspace
```powershell
Remove-AzSentinelDataConnector -Id <String> -WorkspaceInputObject <ISecurityInsightsIdentity>
 [-DefaultProfile <PSObject>] [-PassThru] [-Confirm] [-WhatIf] [<CommonParameters>]
```

#### EXAMPLES

+ Example 1: Removes Sentinel Data Connector
```powershell
Remove-AzSentinelDataConnector -ResourceGroupName "myResourceGroupName" -workspaceName "myWorkspaceName" -Id 661b961f-53d8-4bd1-be97-24e808fd04f5
```

This command removes a data connector.


#### Update-AzSentinelDataConnector

#### SYNOPSIS
Create the data connector.

#### SYNTAX

+ UpdateAADAATP (Default)
```powershell
Update-AzSentinelDataConnector -Id <String> -ResourceGroupName <String> -WorkspaceName <String> -AzureADorAATP
 [-SubscriptionId <String>] [-Alerts <String>] [-TenantId <String>] [-DefaultProfile <PSObject>] [-AsJob]
 [-NoWait] [-Confirm] [-WhatIf] [<CommonParameters>]
```

+ UpdateAmazonWebServicesCloudTrail
```powershell
Update-AzSentinelDataConnector -Id <String> -ResourceGroupName <String> -WorkspaceName <String> -AWSCloudTrail
 [-SubscriptionId <String>] [-AWSRoleArn <String>] [-Log <String>] [-DefaultProfile <PSObject>] [-AsJob]
 [-NoWait] [-Confirm] [-WhatIf] [<CommonParameters>]
```

+ UpdateAmazonWebServicesS3
```powershell
Update-AzSentinelDataConnector [-DetinationTable <String>] [-SQSURL <String[]>] [-DefaultProfile <PSObject>]
 [-AsJob] [-NoWait] [-Confirm] [-WhatIf] [<CommonParameters>]
```

+ UpdateAzureSecurityCenter
```powershell
Update-AzSentinelDataConnector -Id <String> -ResourceGroupName <String> -WorkspaceName <String>
 -AzureSecurityCenter [-SubscriptionId <String>] [-Alerts <String>] [-ASCSubscriptionId <String>]
 [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-Confirm] [-WhatIf] [<CommonParameters>]
```

+ UpdateMicrosoftCloudAppSecurity
```powershell
Update-AzSentinelDataConnector -Id <String> -ResourceGroupName <String> -WorkspaceName <String>
 -CloudAppSecurity [-SubscriptionId <String>] [-Alerts <String>] [-DiscoveryLog <String>] [-TenantId <String>]
 [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-Confirm] [-WhatIf] [<CommonParameters>]
```

+ UpdateMicrosoftDefenderAdvancedThreatProtection
```powershell
Update-AzSentinelDataConnector -Id <String> -ResourceGroupName <String> -WorkspaceName <String> -DefenderATP
 [-SubscriptionId <String>] [-Alerts <String>] [-TenantId <String>] [-DefaultProfile <PSObject>] [-AsJob]
 [-NoWait] [-Confirm] [-WhatIf] [<CommonParameters>]
```

+ UpdateOffice365
```powershell
Update-AzSentinelDataConnector -Id <String> -ResourceGroupName <String> -WorkspaceName <String> -Office365
 [-SubscriptionId <String>] [-Exchange <String>] [-SharePoint <String>] [-Teams <String>] [-TenantId <String>]
 [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-Confirm] [-WhatIf] [<CommonParameters>]
```

+ UpdateThreatIntelligence
```powershell
Update-AzSentinelDataConnector -Id <String> -ResourceGroupName <String> -WorkspaceName <String>
 -ThreatIntelligence [-SubscriptionId <String>] [-Indicator <String>] [-TenantId <String>]
 [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-Confirm] [-WhatIf] [<CommonParameters>]
```

+ UpdateViaIdentityAADAATP
```powershell
Update-AzSentinelDataConnector -InputObject <ISecurityInsightsIdentity> -AzureADorAATP [-Alerts <String>]
 [-TenantId <String>] [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-Confirm] [-WhatIf]
 [<CommonParameters>]
```

+ UpdateViaIdentityAmazonWebServicesCloudTrail
```powershell
Update-AzSentinelDataConnector -InputObject <ISecurityInsightsIdentity> -AWSCloudTrail [-AWSRoleArn <String>]
 [-Log <String>] [-TenantId <String>] [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-Confirm] [-WhatIf]
 [<CommonParameters>]
```

+ UpdateViaIdentityAzureSecurityCenter
```powershell
Update-AzSentinelDataConnector -InputObject <ISecurityInsightsIdentity> -AzureSecurityCenter
 [-Alerts <String>] [-ASCSubscriptionId <String>] [-TenantId <String>] [-DefaultProfile <PSObject>] [-AsJob]
 [-NoWait] [-Confirm] [-WhatIf] [<CommonParameters>]
```

+ UpdateViaIdentityMicrosoftCloudAppSecurity
```powershell
Update-AzSentinelDataConnector -InputObject <ISecurityInsightsIdentity> -CloudAppSecurity [-Alerts <String>]
 [-DiscoveryLog <String>] [-TenantId <String>] [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-Confirm]
 [-WhatIf] [<CommonParameters>]
```

+ UpdateViaIdentityMicrosoftDefenderAdvancedThreatProtection
```powershell
Update-AzSentinelDataConnector -InputObject <ISecurityInsightsIdentity> -DefenderATP [-Alerts <String>]
 [-TenantId <String>] [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-Confirm] [-WhatIf]
 [<CommonParameters>]
```

+ UpdateViaIdentityOffice365
```powershell
Update-AzSentinelDataConnector -InputObject <ISecurityInsightsIdentity> -Office365 [-Exchange <String>]
 [-SharePoint <String>] [-Teams <String>] [-TenantId <String>] [-DefaultProfile <PSObject>] [-AsJob] [-NoWait]
 [-Confirm] [-WhatIf] [<CommonParameters>]
```

+ UpdateViaIdentityThreatIntelligence
```powershell
Update-AzSentinelDataConnector -InputObject <ISecurityInsightsIdentity> -ThreatIntelligence
 [-Indicator <String>] [-TenantId <String>] [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-Confirm]
 [-WhatIf] [<CommonParameters>]
```

#### EXAMPLES

+ Example 1: Update a Sentinel data connector
```powershell
Update-AzSentinelDataConnector -ResourceGroupName "myResourceGroupName" -workspaceName "myWorkspaceName" -Id 3bd6c555-1412-4103-9b9d-2b0b40cda6b6 -SharePoint "Enabled"
```

This command updates a Sentinel data connector


#### New-AzSentinelIncident

#### SYNOPSIS
Create an incident.

#### SYNTAX

+ CreateExpanded (Default)
```powershell
New-AzSentinelIncident -ResourceGroupName <String> -WorkspaceName <String> [-Id <String>]
 [-SubscriptionId <String>] [-Classification <String>] [-ClassificationComment <String>]
 [-ClassificationReason <String>] [-Description <String>] [-FirstActivityTimeUtc <DateTime>]
 [-Label <IIncidentLabel[]>] [-LastActivityTimeUtc <DateTime>] [-OwnerAssignedTo <String>]
 [-OwnerEmail <String>] [-OwnerObjectId <String>] [-OwnerType <String>] [-OwnerUserPrincipalName <String>]
 [-Severity <String>] [-Status <String>] [-Title <String>] [-DefaultProfile <PSObject>] [-Confirm] [-WhatIf]
 [<CommonParameters>]
```

+ CreateViaIdentityExpanded
```powershell
New-AzSentinelIncident -InputObject <ISecurityInsightsIdentity> [-Classification <String>]
 [-ClassificationComment <String>] [-ClassificationReason <String>] [-Description <String>]
 [-FirstActivityTimeUtc <DateTime>] [-Label <IIncidentLabel[]>] [-LastActivityTimeUtc <DateTime>]
 [-OwnerAssignedTo <String>] [-OwnerEmail <String>] [-OwnerObjectId <String>] [-OwnerType <String>]
 [-OwnerUserPrincipalName <String>] [-Severity <String>] [-Status <String>] [-Title <String>]
 [-DefaultProfile <PSObject>] [-Confirm] [-WhatIf] [<CommonParameters>]
```

+ CreateViaIdentityWorkspaceExpanded
```powershell
New-AzSentinelIncident -WorkspaceInputObject <ISecurityInsightsIdentity> [-Id <String>]
 [-Classification <String>] [-ClassificationComment <String>] [-ClassificationReason <String>]
 [-Description <String>] [-FirstActivityTimeUtc <DateTime>] [-Label <IIncidentLabel[]>]
 [-LastActivityTimeUtc <DateTime>] [-OwnerAssignedTo <String>] [-OwnerEmail <String>]
 [-OwnerObjectId <String>] [-OwnerType <String>] [-OwnerUserPrincipalName <String>] [-Severity <String>]
 [-Status <String>] [-Title <String>] [-DefaultProfile <PSObject>] [-Confirm] [-WhatIf] [<CommonParameters>]
```

#### EXAMPLES

+ Example 1: Create an Incident
```powershell
New-AzSentinelIncident -ResourceGroupName "si-jj-test" -WorkspaceName "si-test-ws" -Id ((New-Guid).Guid) -Title "NewIncident" -Description "My Description" -Severity Low -Status New
```

```output
AdditionalDataAlertProductName    : {}
AdditionalDataAlertsCount         : 0
AdditionalDataBookmarksCount      : 0
AdditionalDataCommentsCount       : 0
AdditionalDataProviderIncidentUrl : 
AdditionalDataTactic              : {}
Classification                    : 
ClassificationComment             : 
ClassificationReason              : 
CreatedTimeUtc                    : 8/2/2023 9:40:07 AM
Description                       : My Description
Etag                              : "3403385d-0000-0100-0000-64ca24770000"
FirstActivityTimeUtc              : 
Id                                : /subscriptions/9e223dbe-3399-4e19-88eb-0975f02ac87f/resourceGroups/si-jj-test/providers/Microsoft.OperationalInsights/workspaces/si-test-ws 
                                    /providers/Microsoft.SecurityInsights/Incidents/9f5c6069-39bc-4814-bd1b-728012a3c95d
Label                             : {}
LastActivityTimeUtc               : 
LastModifiedTimeUtc               : 8/2/2023 9:40:07 AM
Name                              : 9f5c6069-39bc-4814-bd1b-728012a3c95d
Number                            : 1
OwnerAssignedTo                   : 
OwnerEmail                        : 
OwnerObjectId                     : 
OwnerType                         : 
OwnerUserPrincipalName            : 
ProviderIncidentId                : 1
ProviderName                      : Azure Sentinel
RelatedAnalyticRuleId             : {}
ResourceGroupName                 : si-jj-test
Severity                          : Low
Status                            : New
SystemDataCreatedAt               : 
SystemDataCreatedBy               : 
SystemDataCreatedByType           : 
SystemDataLastModifiedAt          : 
SystemDataLastModifiedBy          : 
SystemDataLastModifiedByType      : 
Title                             : NewIncident
Type                              : Microsoft.SecurityInsights/Incidents
Url                               : https://portal.azure.com/####asset/Microsoft_Azure_Security_Insights/Incident/subscriptions/9e223dbe-3399-4e19-88eb-0975f02ac87f/resourceGroup 
                                    s/si-jj-test/providers/Microsoft.OperationalInsights/workspaces/si-test-ws/providers/Microsoft.SecurityInsights/Incidents/9f5c6069-39bc-481 
                                    4-bd1b-728012a3c95d
```

This command creates an Incident.


#### Get-AzSentinelIncident

#### SYNOPSIS
Gets a given incident.

#### SYNTAX

+ List (Default)
```powershell
Get-AzSentinelIncident -ResourceGroupName <String> -WorkspaceName <String> [-SubscriptionId <String[]>]
 [-Filter <String>] [-Orderby <String>] [-SkipToken <String>] [-Top <Int32>] [-DefaultProfile <PSObject>]
 [<CommonParameters>]
```

+ Get
```powershell
Get-AzSentinelIncident -Id <String> -ResourceGroupName <String> -WorkspaceName <String>
 [-SubscriptionId <String[]>] [-DefaultProfile <PSObject>] [<CommonParameters>]
```

+ GetViaIdentity
```powershell
Get-AzSentinelIncident -InputObject <ISecurityInsightsIdentity> [-DefaultProfile <PSObject>]
 [<CommonParameters>]
```

+ GetViaIdentityWorkspace
```powershell
Get-AzSentinelIncident -Id <String> -WorkspaceInputObject <ISecurityInsightsIdentity>
 [-DefaultProfile <PSObject>] [<CommonParameters>]
```

#### EXAMPLES

+ Example 1: List all Incidents
```powershell
Get-AzSentinelIncident -ResourceGroupName "si-jj-test" -WorkspaceName "si-test-ws"
```

```output
AdditionalDataAlertProductName    : {}
AdditionalDataAlertsCount         : 0
AdditionalDataBookmarksCount      : 0
AdditionalDataCommentsCount       : 0
AdditionalDataProviderIncidentUrl : 
AdditionalDataTactic              : {}
Classification                    : 
ClassificationComment             : 
ClassificationReason              : 
CreatedTimeUtc                    : 8/2/2023 9:40:07 AM
Description                       : My Description
Etag                              : "3403385d-0000-0100-0000-64ca24770000"
FirstActivityTimeUtc              : 
Id                                : /subscriptions/9e223dbe-3399-4e19-88eb-0975f02ac87f/resourceGroups/si-jj-test/providers/Microsoft.OperationalInsights/workspaces/si-test-ws 
                                    /providers/Microsoft.SecurityInsights/Incidents/9f5c6069-39bc-4814-bd1b-728012a3c95d
Label                             : {}
LastActivityTimeUtc               : 
LastModifiedTimeUtc               : 8/2/2023 9:40:07 AM
Name                              : 9f5c6069-39bc-4814-bd1b-728012a3c95d
Number                            : 1
OwnerAssignedTo                   : 
OwnerEmail                        : 
OwnerObjectId                     : 
OwnerType                         : 
OwnerUserPrincipalName            : 
ProviderIncidentId                : 1
ProviderName                      : Azure Sentinel
RelatedAnalyticRuleId             : {}
ResourceGroupName                 : si-jj-test
Severity                          : Low
Status                            : New
SystemDataCreatedAt               : 
SystemDataCreatedBy               : 
SystemDataCreatedByType           : 
SystemDataLastModifiedAt          : 
SystemDataLastModifiedBy          : 
SystemDataLastModifiedByType      : 
Title                             : NewIncident
Type                              : Microsoft.SecurityInsights/Incidents
Url                               : https://portal.azure.com/####asset/Microsoft_Azure_Security_Insights/Incident/subscriptions/9e223dbe-3399-4e19-88eb-0975f02ac87f/resourceGroup 
                                    s/si-jj-test/providers/Microsoft.OperationalInsights/workspaces/si-test-ws/providers/Microsoft.SecurityInsights/Incidents/9f5c6069-39bc-481 
                                    4-bd1b-728012a3c95d
```

This command lists all Incidents under a Microsoft Sentinel workspace.

+ Example 2: Get an Incident
```powershell
Get-AzSentinelIncident -ResourceGroupName "si-jj-test" -WorkspaceName "si-test-ws" -Id "9f5c6069-39bc-4814-bd1b-728012a3c95d"
```

```output
AdditionalDataAlertProductName    : {}
AdditionalDataAlertsCount         : 0
AdditionalDataBookmarksCount      : 0
AdditionalDataCommentsCount       : 0
AdditionalDataProviderIncidentUrl : 
AdditionalDataTactic              : {}
Classification                    : 
ClassificationComment             : 
ClassificationReason              : 
CreatedTimeUtc                    : 8/2/2023 9:40:07 AM
Description                       : My Description
Etag                              : "3403385d-0000-0100-0000-64ca24770000"
FirstActivityTimeUtc              : 
Id                                : /subscriptions/9e223dbe-3399-4e19-88eb-0975f02ac87f/resourceGroups/si-jj-test/providers/Microsoft.OperationalInsights/workspaces/si-test-ws 
                                    /providers/Microsoft.SecurityInsights/Incidents/9f5c6069-39bc-4814-bd1b-728012a3c95d
Label                             : {}
LastActivityTimeUtc               : 
LastModifiedTimeUtc               : 8/2/2023 9:40:07 AM
Name                              : 9f5c6069-39bc-4814-bd1b-728012a3c95d
Number                            : 1
OwnerAssignedTo                   : 
OwnerEmail                        : 
OwnerObjectId                     : 
OwnerType                         : 
OwnerUserPrincipalName            : 
ProviderIncidentId                : 1
ProviderName                      : Azure Sentinel
RelatedAnalyticRuleId             : {}
ResourceGroupName                 : si-jj-test
Severity                          : Low
Status                            : New
SystemDataCreatedAt               : 
SystemDataCreatedBy               : 
SystemDataCreatedByType           : 
SystemDataLastModifiedAt          : 
SystemDataLastModifiedBy          : 
SystemDataLastModifiedByType      : 
Title                             : NewIncident
Type                              : Microsoft.SecurityInsights/Incidents
Url                               : https://portal.azure.com/####asset/Microsoft_Azure_Security_Insights/Incident/subscriptions/9e223dbe-3399-4e19-88eb-0975f02ac87f/resourceGroup 
                                    s/si-jj-test/providers/Microsoft.OperationalInsights/workspaces/si-test-ws/providers/Microsoft.SecurityInsights/Incidents/9f5c6069-39bc-481 
                                    4-bd1b-728012a3c95d
```

This command gets an Incident.


#### Remove-AzSentinelIncident

#### SYNOPSIS
Deletes a given incident.

#### SYNTAX

+ Delete (Default)
```powershell
Remove-AzSentinelIncident -Id <String> -ResourceGroupName <String> -WorkspaceName <String>
 [-SubscriptionId <String>] [-DefaultProfile <PSObject>] [-PassThru] [-Confirm] [-WhatIf] [<CommonParameters>]
```

+ DeleteViaIdentity
```powershell
Remove-AzSentinelIncident -InputObject <ISecurityInsightsIdentity> [-DefaultProfile <PSObject>] [-PassThru]
 [-Confirm] [-WhatIf] [<CommonParameters>]
```

+ DeleteViaIdentityWorkspace
```powershell
Remove-AzSentinelIncident -Id <String> -WorkspaceInputObject <ISecurityInsightsIdentity>
 [-DefaultProfile <PSObject>] [-PassThru] [-Confirm] [-WhatIf] [<CommonParameters>]
```

#### EXAMPLES

+ Example 1: Removes an incident based on the incident Id
```powershell
Remove-AzSentinelIncident -ResourceGroupName "myResourceGroup" -WorkspaceName "myWorkspaceName" -Id <IncidentId>
```

This command removes an incident based on the incident id.

+ Example 2: Removes an incident based on the incident number
```powershell
$myIncident = Get-AzSentinelIncident -ResourceGroupName "myResourceGroup" -WorkspaceName "myWorkspaceName" -Id <IncidentId> | Where-Object {$_.Number -eq "780"}
```

The command removes an incident based on an incident number.


#### Update-AzSentinelIncident

#### SYNOPSIS
Create an incident.

#### SYNTAX

+ UpdateExpanded (Default)
```powershell
Update-AzSentinelIncident -Id <String> -ResourceGroupName <String> -WorkspaceName <String>
 [-SubscriptionId <String>] [-Classification <String>] [-ClassificationComment <String>]
 [-ClassificationReason <String>] [-Description <String>] [-FirstActivityTimeUtc <DateTime>]
 [-Label <IIncidentLabel[]>] [-LastActivityTimeUtc <DateTime>] [-OwnerAssignedTo <String>]
 [-OwnerEmail <String>] [-OwnerObjectId <String>] [-OwnerType <String>] [-OwnerUserPrincipalName <String>]
 [-Severity <String>] [-Status <String>] [-Title <String>] [-DefaultProfile <PSObject>] [-Confirm] [-WhatIf]
 [<CommonParameters>]
```

+ UpdateViaIdentityExpanded
```powershell
Update-AzSentinelIncident -InputObject <ISecurityInsightsIdentity> [-Classification <String>]
 [-ClassificationComment <String>] [-ClassificationReason <String>] [-Description <String>]
 [-FirstActivityTimeUtc <DateTime>] [-Label <IIncidentLabel[]>] [-LastActivityTimeUtc <DateTime>]
 [-OwnerAssignedTo <String>] [-OwnerEmail <String>] [-OwnerObjectId <String>] [-OwnerType <String>]
 [-OwnerUserPrincipalName <String>] [-Severity <String>] [-Status <String>] [-Title <String>]
 [-DefaultProfile <PSObject>] [-Confirm] [-WhatIf] [<CommonParameters>]
```

+ UpdateViaIdentityWorkspaceExpanded
```powershell
Update-AzSentinelIncident -Id <String> -WorkspaceInputObject <ISecurityInsightsIdentity>
 [-Classification <String>] [-ClassificationComment <String>] [-ClassificationReason <String>]
 [-Description <String>] [-FirstActivityTimeUtc <DateTime>] [-Label <IIncidentLabel[]>]
 [-LastActivityTimeUtc <DateTime>] [-OwnerAssignedTo <String>] [-OwnerEmail <String>]
 [-OwnerObjectId <String>] [-OwnerType <String>] [-OwnerUserPrincipalName <String>] [-Severity <String>]
 [-Status <String>] [-Title <String>] [-DefaultProfile <PSObject>] [-Confirm] [-WhatIf] [<CommonParameters>]
```

#### EXAMPLES

+ Example 1: Update an Incident
```powershell
Update-AzSentinelIncident -ResourceGroupName "myResourceGroupName" -WorkspaceName "myWorkspaceName" -Id "4a21e485-75ae-48b3-a7b9-e6a92bcfe434" -OwnerAssignedTo "user@mydomain.local"
```

This command updates an incident by assigning an owner.


#### Get-AzSentinelIncidentAlert

#### SYNOPSIS
Gets all alerts for an incident.

#### SYNTAX

```powershell
Get-AzSentinelIncidentAlert -IncidentId <String> -ResourceGroupName <String> -WorkspaceName <String>
 [-SubscriptionId <String[]>] [-DefaultProfile <PSObject>] [-Confirm] [-WhatIf] [<CommonParameters>]
```

#### EXAMPLES

+ Example 1: List all Alerts for a given Incident
```powershell
Get-AzSentinelIncidentAlert -ResourceGroupName "si-jj-test" -WorkspaceName "si-test-ws" -IncidentId "9f5c6069-39bc-4814-bd1b-728012a3c95d"
```

```output
AlertDisplayName : (Preview) TI map IP entity to SigninLogs
FriendlyName     : (Preview) TI map IP entity to SigninLogs
Description      : Identifies a match in SigninLogs from any IP IOC from TI
Kind             : SecurityAlert
Name             : d1e4d1dd-8d16-1aed-59bd-a256266d7244
ProductName      : Azure Sentinel
Status           : New
ProviderAlertId  : d6c7a42b-c0da-41ef-9629-b3d2d407b181
Tactic           : {Impact}
```

This command lists all Alerts for a given Incident.


#### Get-AzSentinelIncidentBookmark

#### SYNOPSIS
Gets all bookmarks for an incident.

#### SYNTAX

```powershell
Get-AzSentinelIncidentBookmark -IncidentId <String> -ResourceGroupName <String> -WorkspaceName <String>
 [-SubscriptionId <String[]>] [-DefaultProfile <PSObject>] [-Confirm] [-WhatIf] [<CommonParameters>]
```

#### EXAMPLES

+ Example 1: List all Bookmarks for a given Incident
```powershell
 Get-AzSentinelIncidentBookmark -ResourceGroupName "myResourceGroupName" -workspaceName "myWorkspaceName" -IncidentId "7f40bbbc-e205-404b-bc2b-5d71cd1017a8"
```

```output
DisplayName    : My 2021 Bookmark
FriendlyName   : My 2021 Bookmark
Label          : {my Tags}
Note           : my notes
                 2nd line notes
CreatedByEmail : luke@contoso.com
CreatedByName  : Luke
Name           : 4557d832-41f0-456f-977e-78a2e129b8d0 
```

This command lists all Bookmarks for a given Incident.


#### New-AzSentinelIncidentComment

#### SYNOPSIS
Create a comment for a given incident.

#### SYNTAX

+ CreateExpanded (Default)
```powershell
New-AzSentinelIncidentComment -IncidentId <String> -ResourceGroupName <String> -WorkspaceName <String>
 [-Id <String>] [-SubscriptionId <String>] [-Message <String>] [-DefaultProfile <PSObject>] [-Confirm]
 [-WhatIf] [<CommonParameters>]
```

+ CreateViaIdentityExpanded
```powershell
New-AzSentinelIncidentComment -InputObject <ISecurityInsightsIdentity> [-Message <String>]
 [-DefaultProfile <PSObject>] [-Confirm] [-WhatIf] [<CommonParameters>]
```

+ CreateViaIdentityIncidentExpanded
```powershell
New-AzSentinelIncidentComment -IncidentInputObject <ISecurityInsightsIdentity> [-Id <String>]
 [-Message <String>] [-DefaultProfile <PSObject>] [-Confirm] [-WhatIf] [<CommonParameters>]
```

+ CreateViaIdentityWorkspaceExpanded
```powershell
New-AzSentinelIncidentComment -IncidentId <String> -WorkspaceInputObject <ISecurityInsightsIdentity>
 [-Id <String>] [-Message <String>] [-DefaultProfile <PSObject>] [-Confirm] [-WhatIf] [<CommonParameters>]
```

#### EXAMPLES

+ Example 1: Create an Incident Comment
```powershell
New-AzSentinelIncidentComment -ResourceGroupName "si-jj-test" -WorkspaceName "si-test-ws" -IncidentId "9f5c6069-39bc-4814-bd1b-728012a3c95d" -Message "IncidentCommentGoesHere"
```

```output
AuthorEmail                  : v-jiaji@microsoft.com
AuthorName                   : Joyer Jin (Wicresoft North America Ltd)
AuthorObjectId               : 6205f759-1234-453c-9712-34d7671bceff
AuthorUserPrincipalName      : v-jiaji@microsoft.com
CreatedTimeUtc               : 8/2/2023 9:50:38 AM
Etag                         : "3503c21a-0000-0100-0000-64ca26ee0000"
Id                           : /subscriptions/9e223dbe-3399-4e19-88eb-0975f02ac87f/resourceGroups/si-jj-test/providers/Microsoft.OperationalInsights/workspaces/si-test-ws/prov 
                               iders/Microsoft.SecurityInsights/Incidents/9f5c6069-39bc-4814-bd1b-728012a3c95d/Comments/418b3920-c025-4631-92b3-3e9cc489317f
LastModifiedTimeUtc          : 8/2/2023 9:50:38 AM
Message                      : IncidentCommentGoesHere
Name                         : 418b3920-c025-4631-92b3-3e9cc489317f
ResourceGroupName            : si-jj-test
SystemDataCreatedAt          : 
SystemDataCreatedBy          : 
SystemDataCreatedByType      : 
SystemDataLastModifiedAt     : 
SystemDataLastModifiedBy     : 
SystemDataLastModifiedByType : 
Type                         : Microsoft.SecurityInsights/Incidents/Comments
```

This command creates an Incident Comment.


#### Get-AzSentinelIncidentComment

#### SYNOPSIS
Gets a comment for a given incident.

#### SYNTAX

+ List (Default)
```powershell
Get-AzSentinelIncidentComment -IncidentId <String> -ResourceGroupName <String> -WorkspaceName <String>
 [-SubscriptionId <String[]>] [-Filter <String>] [-Orderby <String>] [-SkipToken <String>] [-Top <Int32>]
 [-DefaultProfile <PSObject>] [<CommonParameters>]
```

+ Get
```powershell
Get-AzSentinelIncidentComment -Id <String> -IncidentId <String> -ResourceGroupName <String>
 -WorkspaceName <String> [-SubscriptionId <String[]>] [-DefaultProfile <PSObject>] [<CommonParameters>]
```

+ GetViaIdentity
```powershell
Get-AzSentinelIncidentComment -InputObject <ISecurityInsightsIdentity> [-DefaultProfile <PSObject>]
 [<CommonParameters>]
```

+ GetViaIdentityIncident
```powershell
Get-AzSentinelIncidentComment -Id <String> -IncidentInputObject <ISecurityInsightsIdentity>
 [-DefaultProfile <PSObject>] [<CommonParameters>]
```

+ GetViaIdentityWorkspace
```powershell
Get-AzSentinelIncidentComment -Id <String> -IncidentId <String>
 -WorkspaceInputObject <ISecurityInsightsIdentity> [-DefaultProfile <PSObject>] [<CommonParameters>]
```

#### EXAMPLES

+ Example 1: List all Incident Comments for a given Incident 
```powershell
 Get-AzSentinelIncidentComment -ResourceGroupName "myResourceGroupName" -workspaceName "myWorkspaceName" -IncidentId "7a4c27ea-d61a-496b-b5c3-246770c857c1"
```

```output
AuthorEmail             : john@contoso.com
AuthorName              : John Contoso
AuthorUserPrincipalName : john@contoso.com
CreatedTimeUtc          : 1/6/2022 2:15:44 PM
Message                 : This is my comment
Name                    : da0957c9-2f1a-44a2-bc83-a2c0696b2bf1

```

This command lists all Incident Comments for a given Incident.

+ Example 2: Get an Incident Comment
```powershell
 Get-AzSentinelIncidentComment -ResourceGroupName "myResourceGroupName" -workspaceName "myWorkspaceName" -IncidentId "7a4c27ea-d61a-496b-b5c3-246770c857c1" -Id "da0957c9-2f1a-44a2-bc83-a2c0696b2bf1"
```

```output
AuthorEmail             : john@contoso.com
AuthorName              : John Contoso
AuthorUserPrincipalName : john@contoso.com
CreatedTimeUtc          : 1/6/2022 2:15:44 PM
Message                 : This is my comment
Name                    : da0957c9-2f1a-44a2-bc83-a2c0696b2bf1
```

This command gets an Incident Comment.


#### Remove-AzSentinelIncidentComment

#### SYNOPSIS
Deletes a comment for a given incident.

#### SYNTAX

+ Delete (Default)
```powershell
Remove-AzSentinelIncidentComment -Id <String> -IncidentId <String> -ResourceGroupName <String>
 -WorkspaceName <String> [-SubscriptionId <String>] [-DefaultProfile <PSObject>] [-PassThru] [-Confirm]
 [-WhatIf] [<CommonParameters>]
```

+ DeleteViaIdentity
```powershell
Remove-AzSentinelIncidentComment -InputObject <ISecurityInsightsIdentity> [-DefaultProfile <PSObject>]
 [-PassThru] [-Confirm] [-WhatIf] [<CommonParameters>]
```

+ DeleteViaIdentityIncident
```powershell
Remove-AzSentinelIncidentComment -Id <String> -IncidentInputObject <ISecurityInsightsIdentity>
 [-DefaultProfile <PSObject>] [-PassThru] [-Confirm] [-WhatIf] [<CommonParameters>]
```

+ DeleteViaIdentityWorkspace
```powershell
Remove-AzSentinelIncidentComment -Id <String> -IncidentId <String>
 -WorkspaceInputObject <ISecurityInsightsIdentity> [-DefaultProfile <PSObject>] [-PassThru] [-Confirm]
 [-WhatIf] [<CommonParameters>]
```

#### EXAMPLES

+ Example 1: Remove an incident comment
```powershell
Remove-AzSentinelIncidentComment -ResourceGroupName "myResourceGroupName" -workspaceName "myWorkspaceName" -IncidentId 7cc984fe-61a2-43c2-a1a4-3583c8a89da2 -Id 7a4c27ea-d61a-496b-b5c3-246770c857c1
```

This command removes an incident comment


#### Update-AzSentinelIncidentComment

#### SYNOPSIS
Create a comment for a given incident.

#### SYNTAX

+ UpdateExpanded (Default)
```powershell
Update-AzSentinelIncidentComment -Id <String> -IncidentId <String> -ResourceGroupName <String>
 -WorkspaceName <String> [-SubscriptionId <String>] [-Message <String>] [-DefaultProfile <PSObject>]
 [-Confirm] [-WhatIf] [<CommonParameters>]
```

+ UpdateViaIdentityExpanded
```powershell
Update-AzSentinelIncidentComment -InputObject <ISecurityInsightsIdentity> [-Message <String>]
 [-DefaultProfile <PSObject>] [-Confirm] [-WhatIf] [<CommonParameters>]
```

+ UpdateViaIdentityIncidentExpanded
```powershell
Update-AzSentinelIncidentComment -Id <String> -IncidentInputObject <ISecurityInsightsIdentity>
 [-Message <String>] [-DefaultProfile <PSObject>] [-Confirm] [-WhatIf] [<CommonParameters>]
```

+ UpdateViaIdentityWorkspaceExpanded
```powershell
Update-AzSentinelIncidentComment -Id <String> -IncidentId <String>
 -WorkspaceInputObject <ISecurityInsightsIdentity> [-Message <String>] [-DefaultProfile <PSObject>] [-Confirm]
 [-WhatIf] [<CommonParameters>]
```

#### EXAMPLES

+ Example 1: Update incident comment
```powershell
Update-AzSentinelIncidentComment -ResourceGroupName "myResourceGroupName" -workspaceName "myWorkspaceName" -IncidentId 7cc984fe-61a2-43c2-a1a4-3583c8a89da2 -Id 8bb5c1eb-a3a9-4575-9451-cd2834be0e0a -Message "my comment"
```

This command updates an incident comment


#### Get-AzSentinelIncidentEntity

#### SYNOPSIS
Gets all entities for an incident.

#### SYNTAX

```powershell
Get-AzSentinelIncidentEntity -IncidentId <String> -ResourceGroupName <String> -WorkspaceName <String>
 [-SubscriptionId <String[]>] [-DefaultProfile <PSObject>] [-Confirm] [-WhatIf] [<CommonParameters>]
```

#### EXAMPLES

+ Example 1: List all Entities for a given Incident
```powershell
 Get-AzSentinelIncidentEntity -ResourceGroupName "myResourceGroupName" -workspaceName "myWorkspaceName" -IncidentId "0ddb580f-efd0-4076-bb77-77e9aef8a187"
```

```output
FriendlyName : win2019
Kind         : Host
Name         : cb577adf-0266-8873-84d7-accf4b45417b
```

This command lists all Entities for a given Incident.


#### New-AzSentinelIncidentRelation

#### SYNOPSIS
Create a relation for a given incident.

#### SYNTAX

+ CreateExpanded (Default)
```powershell
New-AzSentinelIncidentRelation -IncidentId <String> -ResourceGroupName <String> -WorkspaceName <String>
 [-RelationName <String>] [-SubscriptionId <String>] [-RelatedResourceId <String>]
 [-DefaultProfile <PSObject>] [-Confirm] [-WhatIf] [<CommonParameters>]
```

+ CreateViaIdentityExpanded
```powershell
New-AzSentinelIncidentRelation -InputObject <ISecurityInsightsIdentity> [-RelatedResourceId <String>]
 [-DefaultProfile <PSObject>] [-Confirm] [-WhatIf] [<CommonParameters>]
```

+ CreateViaIdentityIncidentExpanded
```powershell
New-AzSentinelIncidentRelation -IncidentInputObject <ISecurityInsightsIdentity> [-RelationName <String>]
 [-RelatedResourceId <String>] [-DefaultProfile <PSObject>] [-Confirm] [-WhatIf] [<CommonParameters>]
```

+ CreateViaIdentityWorkspaceExpanded
```powershell
New-AzSentinelIncidentRelation -IncidentId <String> -WorkspaceInputObject <ISecurityInsightsIdentity>
 [-RelationName <String>] [-RelatedResourceId <String>] [-DefaultProfile <PSObject>] [-Confirm] [-WhatIf]
 [<CommonParameters>]
```

#### EXAMPLES

+ Example 1: Create a Incident Relation
```powershell
$bookmark = Get-AzSentinelBookmark -ResourceGroupName "si-jj-test" -WorkspaceName "si-test-ws" -Id "70aaef57-7165-444b-959d-67e6668d57d0"
New-AzSentinelIncidentRelation -ResourceGroupName "si-jj-test" -WorkspaceName "si-test-ws" -IncidentId "9f5c6069-39bc-4814-bd1b-728012a3c95d" -RelationName ((New-Guid).Guid) -RelatedResourceId ($bookmark.Id)
```

```output
Etag                         : "9403d27f-0000-0100-0000-64cb1f890000"
Id                           : /subscriptions/9e223dbe-3399-4e19-88eb-0975f02ac87f/resourceGroups/si-jj-test/providers/Microsoft.OperationalInsights/workspaces/si-test-ws/prov 
                               iders/Microsoft.SecurityInsights/Incidents/9f5c6069-39bc-4814-bd1b-728012a3c95d/relations/f94951bd-6491-4c71-a3f4-dfeaaf98047e
Name                         : f94951bd-6491-4c71-a3f4-dfeaaf98047e
RelatedResourceId            : /subscriptions/9e223dbe-3399-4e19-88eb-0975f02ac87f/resourceGroups/si-jj-test/providers/Microsoft.OperationalInsights/workspaces/si-test-ws/prov 
                               iders/Microsoft.SecurityInsights/Bookmarks/70aaef57-7165-444b-959d-67e6668d57d0
RelatedResourceKind          : 
RelatedResourceName          : 70aaef57-7165-444b-959d-67e6668d57d0
RelatedResourceType          : Microsoft.SecurityInsights/Bookmarks
ResourceGroupName            : si-jj-test
SystemDataCreatedAt          : 
SystemDataCreatedBy          : 
SystemDataCreatedByType      : 
SystemDataLastModifiedAt     : 
SystemDataLastModifiedBy     : 
SystemDataLastModifiedByType : 
Type                         : Microsoft.SecurityInsights/Incidents/relations
```

This command creates a Incident Relation connecting the Bookmark to the Incident.


#### Get-AzSentinelIncidentRelation

#### SYNOPSIS
Gets a relation for a given incident.

#### SYNTAX

+ List (Default)
```powershell
Get-AzSentinelIncidentRelation -IncidentId <String> -ResourceGroupName <String> -WorkspaceName <String>
 [-SubscriptionId <String[]>] [-Filter <String>] [-Orderby <String>] [-SkipToken <String>] [-Top <Int32>]
 [-DefaultProfile <PSObject>] [<CommonParameters>]
```

+ Get
```powershell
Get-AzSentinelIncidentRelation -IncidentId <String> -RelationName <String> -ResourceGroupName <String>
 -WorkspaceName <String> [-SubscriptionId <String[]>] [-DefaultProfile <PSObject>] [<CommonParameters>]
```

+ GetViaIdentity
```powershell
Get-AzSentinelIncidentRelation -InputObject <ISecurityInsightsIdentity> [-DefaultProfile <PSObject>]
 [<CommonParameters>]
```

+ GetViaIdentityIncident
```powershell
Get-AzSentinelIncidentRelation -IncidentInputObject <ISecurityInsightsIdentity> -RelationName <String>
 [-DefaultProfile <PSObject>] [<CommonParameters>]
```

+ GetViaIdentityWorkspace
```powershell
Get-AzSentinelIncidentRelation -IncidentId <String> -RelationName <String>
 -WorkspaceInputObject <ISecurityInsightsIdentity> [-DefaultProfile <PSObject>] [<CommonParameters>]
```

#### EXAMPLES

+ Example 1: List all Incident Relations for a given Incident 
```powershell
 Get-AzSentinelIncidentRelation -ResourceGroupName "myResourceGroupName" -workspaceName "myWorkspaceName" -IncidentId "myIncidentId"
```

```output
Name                : 8969f5ea-4e92-433a-9b67-2f9233d8113f_457a48b2-9dfc-7054-64a5-e8a9d17489d7
RelatedResourceName : 457a48b2-9dfc-7054-64a5-e8a9d17489d7
RelatedResourceKind : SecurityAlert
RelatedResourceType : Microsoft.SecurityInsights/entities

Name                : 076bda5c-7d94-b6d8-8ef4-b0b2a0830dac_df9493a7-4f2e-84da-1f41-4914e8c029ba
RelatedResourceName : df9493a7-4f2e-84da-1f41-4914e8c029ba
RelatedResourceKind : SecurityAlert
RelatedResourceType : Microsoft.SecurityInsights/entities
```

This command lists all Incident Relations for a given Incident.

+ Example 2: Get a Incident Relation
```powershell
 Get-AzSentinelIncidentRelation -ResourceGroupName "myResourceGroupName" -workspaceName "myWorkspaceName" -IncidentId "myIncidentId" -RelationName "myIncidentRelationId"
```

```output
Name                : 076bda5c-7d94-b6d8-8ef4-b0b2a0830dac_df9493a7-4f2e-84da-1f41-4914e8c029ba
RelatedResourceName : df9493a7-4f2e-84da-1f41-4914e8c029ba
RelatedResourceKind : SecurityAlert
RelatedResourceType : Microsoft.SecurityInsights/entities
```

This command gets a Incident Relation.

+ Example 3: Get a Incident Relation by object Id
```powershell
 $Incidentrelations = Get-AzSentinelIncidentRelation -ResourceGroupName "myResourceGroupName" -workspaceName "myWorkspaceName" -IncidentId "myIncidentId"
 $Incidentrelations[0] | Get-AzSentinelIncidentRelation
```

```output
Name                : 076bda5c-7d94-b6d8-8ef4-b0b2a0830dac_df9493a7-4f2e-84da-1f41-4914e8c029ba
RelatedResourceName : df9493a7-4f2e-84da-1f41-4914e8c029ba
RelatedResourceKind : SecurityAlert
RelatedResourceType : Microsoft.SecurityInsights/entities
```

This command gets a Incident by object


#### Remove-AzSentinelIncidentRelation

#### SYNOPSIS
Deletes a relation for a given incident.

#### SYNTAX

+ Delete (Default)
```powershell
Remove-AzSentinelIncidentRelation -IncidentId <String> -RelationName <String> -ResourceGroupName <String>
 -WorkspaceName <String> [-SubscriptionId <String>] [-DefaultProfile <PSObject>] [-PassThru] [-Confirm]
 [-WhatIf] [<CommonParameters>]
```

+ DeleteViaIdentity
```powershell
Remove-AzSentinelIncidentRelation -InputObject <ISecurityInsightsIdentity> [-DefaultProfile <PSObject>]
 [-PassThru] [-Confirm] [-WhatIf] [<CommonParameters>]
```

+ DeleteViaIdentityIncident
```powershell
Remove-AzSentinelIncidentRelation -IncidentInputObject <ISecurityInsightsIdentity> -RelationName <String>
 [-DefaultProfile <PSObject>] [-PassThru] [-Confirm] [-WhatIf] [<CommonParameters>]
```

+ DeleteViaIdentityWorkspace
```powershell
Remove-AzSentinelIncidentRelation -IncidentId <String> -RelationName <String>
 -WorkspaceInputObject <ISecurityInsightsIdentity> [-DefaultProfile <PSObject>] [-PassThru] [-Confirm]
 [-WhatIf] [<CommonParameters>]
```

#### EXAMPLES

+ Example 1: Removes the incident relation
```powershell
Remove-AzSentinelIncidentRelation -ResourceGroupName "myResourceGroupName" -workspaceName "myWorkspaceName" -IncidentId "7cc984fe-61a2-43c2-a1a4-3583c8a89da2" -RelationName "7cc984fe-61a2-43c2-a1a4-3583c8a89db4"
```

This command removes the incident relation


#### Update-AzSentinelIncidentRelation

#### SYNOPSIS
Create a relation for a given incident.

#### SYNTAX

+ UpdateExpanded (Default)
```powershell
Update-AzSentinelIncidentRelation -IncidentId <String> -RelationName <String> -ResourceGroupName <String>
 -WorkspaceName <String> [-SubscriptionId <String>] [-RelatedResourceId <String>] [-DefaultProfile <PSObject>]
 [-Confirm] [-WhatIf] [<CommonParameters>]
```

+ UpdateViaIdentityExpanded
```powershell
Update-AzSentinelIncidentRelation -InputObject <ISecurityInsightsIdentity> [-RelatedResourceId <String>]
 [-DefaultProfile <PSObject>] [-Confirm] [-WhatIf] [<CommonParameters>]
```

+ UpdateViaIdentityIncidentExpanded
```powershell
Update-AzSentinelIncidentRelation -IncidentInputObject <ISecurityInsightsIdentity> -RelationName <String>
 [-RelatedResourceId <String>] [-DefaultProfile <PSObject>] [-Confirm] [-WhatIf] [<CommonParameters>]
```

+ UpdateViaIdentityWorkspaceExpanded
```powershell
Update-AzSentinelIncidentRelation -IncidentId <String> -RelationName <String>
 -WorkspaceInputObject <ISecurityInsightsIdentity> [-RelatedResourceId <String>] [-DefaultProfile <PSObject>]
 [-Confirm] [-WhatIf] [<CommonParameters>]
```

#### EXAMPLES

+ Example 1: Update an incident relation
```powershell
 $bookmark = Get-AzSentinelBookmark -ResourceGroupName "myResourceGroup" -WorkspaceName "myWorkspaceName" -Id "myBookmarkId"
 Update-AzSentinelIncidentRelation -ResourceGroupName "myResourceGroup" -WorkspaceName "myWorkspaceName" -IncidentId "myIncidentId" -RelationName ((New-Guid).Guid) -RelatedResourceId ($bookmark.Id)
```

This command updates an incident relation


#### Get-AzSentinelMetadata

#### SYNOPSIS
Get a Metadata.

#### SYNTAX

+ List (Default)
```powershell
Get-AzSentinelMetadata -ResourceGroupName <String> -WorkspaceName <String> [-SubscriptionId <String[]>]
 [-Filter <String>] [-Orderby <String>] [-Skip <Int32>] [-Top <Int32>] [-DefaultProfile <PSObject>]
 [<CommonParameters>]
```

+ Get
```powershell
Get-AzSentinelMetadata -Name <String> -ResourceGroupName <String> -WorkspaceName <String>
 [-SubscriptionId <String[]>] [-DefaultProfile <PSObject>] [<CommonParameters>]
```

+ GetViaIdentity
```powershell
Get-AzSentinelMetadata -InputObject <ISecurityInsightsIdentity> [-DefaultProfile <PSObject>]
 [<CommonParameters>]
```

+ GetViaIdentityWorkspace
```powershell
Get-AzSentinelMetadata -Name <String> -WorkspaceInputObject <ISecurityInsightsIdentity>
 [-DefaultProfile <PSObject>] [<CommonParameters>]
```

#### EXAMPLES

+ Example 1: Get Solution metadata from the workspace
```powershell
 Get-AzSentinelMetadata -ResourceGroupName "myResourceGroupName" -workspaceName "myWorkspaceName"
```

```output
Etag    Name                                                SystemDataCreatedAt     SystemDataCreatedBy SystemDataCreatedByType
----    ----                                                -------------------     ------------------- -----------
        azuresentinel.azure-sentinel-solution-slackaudit    3/11/2022 11:20:19 PM   user@domain.local   User       
```

This command lists all Solution metadata for a workspace.


#### New-AzSentinelOnboardingState

#### SYNOPSIS
Create Sentinel onboarding state

#### SYNTAX

+ CreateExpanded (Default)
```powershell
New-AzSentinelOnboardingState -Name <String> -ResourceGroupName <String> -WorkspaceName <String>
 [-SubscriptionId <String>] [-CustomerManagedKey] [-DefaultProfile <PSObject>] [-Confirm] [-WhatIf]
 [<CommonParameters>]
```

+ Create
```powershell
New-AzSentinelOnboardingState -Name <String> -ResourceGroupName <String> -WorkspaceName <String>
 -SentinelOnboardingStateParameter <ISentinelOnboardingState> [-SubscriptionId <String>]
 [-DefaultProfile <PSObject>] [-Confirm] [-WhatIf] [<CommonParameters>]
```

+ CreateViaIdentity
```powershell
New-AzSentinelOnboardingState -InputObject <ISecurityInsightsIdentity>
 -SentinelOnboardingStateParameter <ISentinelOnboardingState> [-DefaultProfile <PSObject>] [-Confirm]
 [-WhatIf] [<CommonParameters>]
```

+ CreateViaIdentityExpanded
```powershell
New-AzSentinelOnboardingState -InputObject <ISecurityInsightsIdentity> [-CustomerManagedKey]
 [-DefaultProfile <PSObject>] [-Confirm] [-WhatIf] [<CommonParameters>]
```

+ CreateViaIdentityWorkspace
```powershell
New-AzSentinelOnboardingState -Name <String> -WorkspaceInputObject <ISecurityInsightsIdentity>
 -SentinelOnboardingStateParameter <ISentinelOnboardingState> [-DefaultProfile <PSObject>] [-Confirm]
 [-WhatIf] [<CommonParameters>]
```

+ CreateViaIdentityWorkspaceExpanded
```powershell
New-AzSentinelOnboardingState -Name <String> -WorkspaceInputObject <ISecurityInsightsIdentity>
 [-CustomerManagedKey] [-DefaultProfile <PSObject>] [-Confirm] [-WhatIf] [<CommonParameters>]
```

#### EXAMPLES

+ Example 1: Add Sentinel onboarding state
```powershell
New-AzSentinelOnboardingState -ResourceGroupName "si-jj-test" -WorkspaceName "si-test-ws" -Name "default"
```

```output
CustomerManagedKey           : 
Etag                         : 
Id                           : /subscriptions/9e223dbe-3399-4e19-88eb-0975f02ac87f/resourceGroups/si-jj-test/providers/Microsoft.OperationalInsights/workspaces/si-test-ws/prov 
                               iders/Microsoft.SecurityInsights/onboardingStates/default
Name                         : default
ResourceGroupName            : si-jj-test
SystemDataCreatedAt          : 8/3/2023 3:49:07 AM
SystemDataCreatedBy          : v-jiaji@microsoft.com
SystemDataCreatedByType      : User
SystemDataLastModifiedAt     : 8/3/2023 3:49:07 AM
SystemDataLastModifiedBy     : v-jiaji@microsoft.com
SystemDataLastModifiedByType : User
Type                         : Microsoft.SecurityInsights/onboardingStates
```

This command configures the onboarding state of Sentinel


#### Get-AzSentinelOnboardingState

#### SYNOPSIS
Get Sentinel onboarding state

#### SYNTAX

+ List (Default)
```powershell
Get-AzSentinelOnboardingState -ResourceGroupName <String> -WorkspaceName <String> [-SubscriptionId <String[]>]
 [-DefaultProfile <PSObject>] [<CommonParameters>]
```

+ Get
```powershell
Get-AzSentinelOnboardingState -Name <String> -ResourceGroupName <String> -WorkspaceName <String>
 [-SubscriptionId <String[]>] [-DefaultProfile <PSObject>] [<CommonParameters>]
```

+ GetViaIdentity
```powershell
Get-AzSentinelOnboardingState -InputObject <ISecurityInsightsIdentity> [-DefaultProfile <PSObject>]
 [<CommonParameters>]
```

+ GetViaIdentityWorkspace
```powershell
Get-AzSentinelOnboardingState -Name <String> -WorkspaceInputObject <ISecurityInsightsIdentity>
 [-DefaultProfile <PSObject>] [<CommonParameters>]
```

#### EXAMPLES

+ Example 1: List all Onboarding States
```powershell
 Get-AzSentinelOnboardingState -ResourceGroupName "myResourceGroupName" -workspaceName "myWorkspaceName"
```

```output
Id   : /subscriptions/314b1a41-c53c-4092-8d4a-2810f6a44a0c/resourceGroups/myRG/providers/Microsoft.OperationalInsights/workspaces/cybersecurity/providers/Microsoft.SecurityInsights/onboardingStates/default
Name : default
```

This command lists all Onboarding States under a Microsoft Sentinel workspace.

+ Example 2: Get an Onboarding State
```powershell
 Get-AzSentinelOnboardingState -ResourceGroupName "myResourceGroupName" -workspaceName "myWorkspaceName" -Name "default"
```

```output
Id   : /subscriptions/314b1a41-c53c-4092-8d4a-2810f6a44a0c/resourceGroups/myRG/providers/Microsoft.OperationalInsights/workspaces/cybersecurity/providers/Microsoft.SecurityInsights/onboardingStates/default
Name : default
```

This command gets an Onboarding State.


#### Remove-AzSentinelOnboardingState

#### SYNOPSIS
Delete Sentinel onboarding state

#### SYNTAX

+ Delete (Default)
```powershell
Remove-AzSentinelOnboardingState -Name <String> -ResourceGroupName <String> -WorkspaceName <String>
 [-SubscriptionId <String>] [-DefaultProfile <PSObject>] [-PassThru] [-Confirm] [-WhatIf] [<CommonParameters>]
```

+ DeleteViaIdentity
```powershell
Remove-AzSentinelOnboardingState -InputObject <ISecurityInsightsIdentity> [-DefaultProfile <PSObject>]
 [-PassThru] [-Confirm] [-WhatIf] [<CommonParameters>]
```

+ DeleteViaIdentityWorkspace
```powershell
Remove-AzSentinelOnboardingState -Name <String> -WorkspaceInputObject <ISecurityInsightsIdentity>
 [-DefaultProfile <PSObject>] [-PassThru] [-Confirm] [-WhatIf] [<CommonParameters>]
```

#### EXAMPLES

+ Example 1: Remove the Sentinel onboarding state
```powershell
Remove-AzSentinelOnboardingState -ResourceGroupName "myResourceGroupName" -WorkspaceName "myWorkspaceName" -Name "default"
```

This commands removes the Sentinel onboarding state


#### New-AzSentinelSecurityMlAnalyticsSetting

#### SYNOPSIS
Create the Security ML Analytics Settings.

#### SYNTAX

+ CreateViaIdentity (Default)
```powershell
New-AzSentinelSecurityMlAnalyticsSetting -InputObject <ISecurityInsightsIdentity>
 -SecurityMlAnalyticsSetting <ISecurityMlAnalyticsSetting> [-DefaultProfile <PSObject>] [-Confirm] [-WhatIf]
 [<CommonParameters>]
```

+ Create
```powershell
New-AzSentinelSecurityMlAnalyticsSetting -ResourceGroupName <String> -SettingsResourceName <String>
 -WorkspaceName <String> -SecurityMlAnalyticsSetting <ISecurityMlAnalyticsSetting> [-SubscriptionId <String>]
 [-DefaultProfile <PSObject>] [-Confirm] [-WhatIf] [<CommonParameters>]
```

+ CreateViaIdentityWorkspace
```powershell
New-AzSentinelSecurityMlAnalyticsSetting -SettingsResourceName <String>
 -WorkspaceInputObject <ISecurityInsightsIdentity> -SecurityMlAnalyticsSetting <ISecurityMlAnalyticsSetting>
 [-DefaultProfile <PSObject>] [-Confirm] [-WhatIf] [<CommonParameters>]
```

#### EXAMPLES

+ Example 1: Create a SecurityMlAnalyticsSetting
```powershell
$setting = New-AzSentinelAnomalySecurityMlAnalyticsSettingsObject -AnomalyVersion 1.0.5 -Enabled $false -DisplayName "Login from unusual region" -Frequency (New-TimeSpan -Hours 1) -SettingsStatus Production -IsDefaultSetting $true -SettingsDefinitionId "f209187f-1d17-4431-94af-c141bf5f23db"
New-AzSentinelSecurityMlAnalyticsSetting -ResourceGroupName "si-jj-test" -WorkspaceName "si-test-w4" -SettingsResourceName f209187f-1d17-4431-94af-c141bf5f23db -SecurityMlAnalyticsSetting $setting
```

```output
AnomalySettingsVersion       : 0
AnomalyVersion               : 1.0.5
CustomizableObservation      : {
                               }
Description                  : 
DisplayName                  : Login from unusual region
Enabled                      : False
Etag                         : "0a003319-0000-0300-0000-64d4c4510000"
Frequency                    : 01:00:00
Id                           : /subscriptions/9e223dbe-3399-4e19-88eb-0975f02ac87f/resourceGroups/si-jj-test/providers/Microsoft.OperationalInsights/workspaces/si-test-w4/provi 
                               ders/Microsoft.SecurityInsights/securityMLAnalyticsSettings/f209187f-1d17-4431-94af-c141bf5f23db
IsDefaultSetting             : True
Kind                         : Anomaly
LastModifiedUtc              : 8/10/2023 11:04:47 AM
Name                         : f209187f-1d17-4431-94af-c141bf5f23db
RequiredDataConnector        : {}
SettingsDefinitionId         : f209187f-1d17-4431-94af-c141bf5f23db
SettingsStatus               : Production
SystemDataCreatedAt          : 
SystemDataCreatedBy          : 
SystemDataCreatedByType      : 
SystemDataLastModifiedAt     : 
SystemDataLastModifiedBy     : 
SystemDataLastModifiedByType : 
Tactic                       : {}
Technique                    : {}
Type                         : Microsoft.SecurityInsights/securityMLAnalyticsSettings
```

This command creates a SecurityMlAnalyticsSetting


#### Get-AzSentinelSecurityMlAnalyticsSetting

#### SYNOPSIS
Gets the Security ML Analytics Settings.

#### SYNTAX

+ List (Default)
```powershell
Get-AzSentinelSecurityMlAnalyticsSetting -ResourceGroupName <String> -WorkspaceName <String>
 [-SubscriptionId <String[]>] [-DefaultProfile <PSObject>] [<CommonParameters>]
```

+ Get
```powershell
Get-AzSentinelSecurityMlAnalyticsSetting -ResourceGroupName <String> -SettingsResourceName <String>
 -WorkspaceName <String> [-SubscriptionId <String[]>] [-DefaultProfile <PSObject>] [<CommonParameters>]
```

+ GetViaIdentity
```powershell
Get-AzSentinelSecurityMlAnalyticsSetting -InputObject <ISecurityInsightsIdentity> [-DefaultProfile <PSObject>]
 [<CommonParameters>]
```

+ GetViaIdentityWorkspace
```powershell
Get-AzSentinelSecurityMlAnalyticsSetting -SettingsResourceName <String>
 -WorkspaceInputObject <ISecurityInsightsIdentity> [-DefaultProfile <PSObject>] [<CommonParameters>]
```

#### EXAMPLES

+ Example 1: Get list of SecurityMlAnalyticsSetting
```powershell
Get-AzSentinelSecurityMlAnalyticsSetting -ResourceGroupName "si-jj-test" -WorkspaceName "si-test-w4"
```

```output
Etag Kind    Name                                 SystemDataCreatedAt SystemDataCreatedBy SystemDataCreatedByType SystemDataLastModifiedAt SystemDataLastModifiedBy SystemDataLa 
                                                                                                                                                                    stModifiedBy 
                                                                                                                                                                    Type
---- ----    ----                                 ------------------- ------------------- ----------------------- ------------------------ ------------------------ ------------ 
     Anomaly f209187f-1d17-4431-94af-c141bf5f23db
     Anomaly b40a7a5b-5d39-46fe-a79e-2acdb38e1ce7
     Anomaly 29094df8-e0c7-4475-a74c-bda74a07affb
     Anomaly 3f8fa297-1fbb-4515-98af-b77be2c873a1
     Anomaly ffe3625d-a933-4f63-b192-7e6ebf3be5fb
     Anomaly c9053c76-c6cd-409a-a10f-e20b05cc91f5
     Anomaly e7277475-4e31-41c7-9997-0b8b3d7f00cd
     Anomaly 622844c2-fc11-4efc-91e6-c05b06ab3008
     Anomaly 543c9254-eb6f-4fdd-858d-783e0e3d5cb9
     Anomaly 9c712bb2-08dc-44d3-b66b-af154dfc1c4f
     Anomaly 200f05a2-db6e-4ff7-be83-bbc30b44755f
     Anomaly 8a12afde-ed27-46ac-a5ef-392e3d4f071f
     Anomaly d7309cb9-b16b-4c7a-9e4b-3e9009bd373d
     Anomaly 1d10c95d-ef32-41cd-aca0-c6a7f4523494
     Anomaly 7e38a3e4-ccb9-4c73-b4ee-290b3bed077c
     Anomaly 95514e77-1b23-4f05-817c-ae363c53aad3
     Anomaly d4f9d54b-6dec-4655-8631-0fa8d4954fea
     Anomaly 0c804654-63b9-4241-89f8-1cddd7e9cacd
     Anomaly c097bfdb-8b4b-4a98-b74d-1871ffd50a03
     Anomaly 9c27cee8-0a33-4abe-8683-212c0a98fc28
     Anomaly 8bada072-c58c-4df3-a17e-e02392b48240
     Anomaly 32686052-5bed-48ef-9ffa-39fc7699f085
     Anomaly 23850aa1-37d3-4b4b-9f39-4ebf5feb59fd
     Anomaly edc946ae-cba8-419f-8e90-309966895956
     Anomaly 8a602940-4153-4045-a741-3bf15591ae29
     Anomaly 16d55bbb-8c54-4c1d-8537-521824e76bb6
     Anomaly 38781e25-924e-4c9d-9a76-8703077be83d
     Anomaly 8595d264-2f64-442d-b293-4e16dffc9882
     Anomaly fc1b7e7a-bc24-42c3-ad67-5c76c8fcb2d6
     Anomaly a3863d8b-8be1-4f52-8ba2-d6cec98b606b
     Anomaly 93c4b361-ea7d-40f4-9ca6-e501cdef9c53
     Anomaly 67722b33-6ac1-485c-ad6f-9418f360d1d5
     Anomaly b783df9c-4088-452e-a791-0c4fca47a109
     Anomaly 61a45b42-5fe8-47ef-9b16-c61e6b76ab8e
     Anomaly c5644575-4982-4a07-8884-b11ec2866dc3
     Anomaly 30dea201-74da-4141-8d21-8a18f0861d60
     Anomaly bb32dc8a-4f6b-4274-a28f-50f3400070b4
     Anomaly 1de6460f-30dc-4e8c-8086-8100d8e2b461
     Anomaly a255ca7d-ea19-4b7b-8d88-a51ce1c72c29
     Anomaly 36f191f8-d1d1-4a22-8ba7-22c9b64a651a
     Anomaly 2bb167bf-3951-435b-a932-8b03bfde0a2b
     Anomaly 3dccf381-2bb2-40c6-81a0-ab878bdf323f
     Anomaly 2d3e33c6-d8e6-4b51-92d6-dbe8bd9efb05
     Anomaly db58d592-4e64-4800-825e-12c09622dd47
     Anomaly 5020e404-9768-4364-98f6-679940c21362
     Anomaly 25bf2f45-1cf0-47d2-b394-a7b331d707b3
     Anomaly 8546330c-e1fb-422a-9388-5c09e9a8f4ca
     Anomaly d0bd9611-2fc1-42cb-af4e-793b6f28ba92
     Anomaly 7faf4218-3769-4f05-bbd1-f32ca00489bb
     Anomaly 06107abb-1b68-4fdc-841b-8a1ff9301467
     Anomaly 03401f05-5c45-4f2d-9295-092764090e02
     Anomaly 1f6d7abe-2cb7-4a4c-aeca-91fe6bfad0b2
     Anomaly 8d19b599-3c58-41ea-8db1-7ed22f80561e
     Anomaly ae9128e8-2740-4b62-8bde-54e62b183fca
     Anomaly af7fd11a-f305-44e1-8f46-f31580a15eab
     Anomaly 213252f1-497c-4124-91da-6cb43902d5b1
     Anomaly 467a1afd-68e1-4b4a-864f-5aa1ae505ad8

```

This command lists SecurityMlAnalyticsSettings.

+ Example 2: Get specific SecurityMlAnalyticsSetting with specified resource group and workspace
```powershell
Get-AzSentinelSecurityMlAnalyticsSetting -ResourceGroupName "si-jj-test" -WorkspaceName "si-test-w4" -SettingsResourceName "f209187f-1d17-4431-94af-c141bf5f23db"
```

```output
AnomalySettingsVersion       : 0
AnomalyVersion               : 1.0.5
CustomizableObservation      : {
                               }
Description                  : 
DisplayName                  : Login from unusual region
Enabled                      : False
Etag                         : "0a003319-0000-0300-0000-64d4c4510000"
Frequency                    : 01:00:00
Id                           : /subscriptions/9e223dbe-3399-4e19-88eb-0975f02ac87f/resourceGroups/si-jj-test/providers/Microsoft.OperationalInsights/workspaces/si-test-w4/provi 
                               ders/Microsoft.SecurityInsights/securityMLAnalyticsSettings/f209187f-1d17-4431-94af-c141bf5f23db
IsDefaultSetting             : True
Kind                         : Anomaly
LastModifiedUtc              : 8/10/2023 11:04:47 AM
Name                         : f209187f-1d17-4431-94af-c141bf5f23db
RequiredDataConnector        : {}
SettingsDefinitionId         : f209187f-1d17-4431-94af-c141bf5f23db
SettingsStatus               : Production
SystemDataCreatedAt          : 
SystemDataCreatedBy          : 
SystemDataCreatedByType      : 
SystemDataLastModifiedAt     : 
SystemDataLastModifiedBy     : 
SystemDataLastModifiedByType : 
Tactic                       : {}
Technique                    : {}
Type                         : Microsoft.SecurityInsights/securityMLAnalyticsSettings
```

This command gets specific SecurityMlAnalyticsSetting with specified resource group and workspace.


#### Remove-AzSentinelSecurityMlAnalyticsSetting

#### SYNOPSIS
Delete the Security ML Analytics Settings.

#### SYNTAX

+ Delete (Default)
```powershell
Remove-AzSentinelSecurityMlAnalyticsSetting -ResourceGroupName <String> -SettingsResourceName <String>
 -WorkspaceName <String> [-SubscriptionId <String>] [-DefaultProfile <PSObject>] [-PassThru] [-Confirm]
 [-WhatIf] [<CommonParameters>]
```

+ DeleteViaIdentity
```powershell
Remove-AzSentinelSecurityMlAnalyticsSetting -InputObject <ISecurityInsightsIdentity>
 [-DefaultProfile <PSObject>] [-PassThru] [-Confirm] [-WhatIf] [<CommonParameters>]
```

+ DeleteViaIdentityWorkspace
```powershell
Remove-AzSentinelSecurityMlAnalyticsSetting -SettingsResourceName <String>
 -WorkspaceInputObject <ISecurityInsightsIdentity> [-DefaultProfile <PSObject>] [-PassThru] [-Confirm]
 [-WhatIf] [<CommonParameters>]
```

#### EXAMPLES

+ Example 1: Delete specific SecurityMlAnalyticsSetting with specified resource group and workspace
```powershell
Remove-AzSentinelSecurityMlAnalyticsSetting -ResourceGroupName "si-jj-test" -WorkspaceName "si-test-w4" -SettingsResourceName "f209187f-1d17-4431-94af-c141bf5f23db"
```

This command deletes specific SecurityMlAnalyticsSetting with specified resource group and workspace.


#### Update-AzSentinelSecurityMlAnalyticsSetting

#### SYNOPSIS
Create the Security ML Analytics Settings.

#### SYNTAX

+ UpdateViaIdentity (Default)
```powershell
Update-AzSentinelSecurityMlAnalyticsSetting -InputObject <ISecurityInsightsIdentity>
 -SecurityMlAnalyticsSetting <ISecurityMlAnalyticsSetting> [-DefaultProfile <PSObject>] [-Confirm] [-WhatIf]
 [<CommonParameters>]
```

+ Update
```powershell
Update-AzSentinelSecurityMlAnalyticsSetting -ResourceGroupName <String> -SettingsResourceName <String>
 -WorkspaceName <String> -SecurityMlAnalyticsSetting <ISecurityMlAnalyticsSetting> [-SubscriptionId <String>]
 [-DefaultProfile <PSObject>] [-Confirm] [-WhatIf] [<CommonParameters>]
```

+ UpdateViaIdentityWorkspace
```powershell
Update-AzSentinelSecurityMlAnalyticsSetting -SettingsResourceName <String>
 -WorkspaceInputObject <ISecurityInsightsIdentity> -SecurityMlAnalyticsSetting <ISecurityMlAnalyticsSetting>
 [-DefaultProfile <PSObject>] [-Confirm] [-WhatIf] [<CommonParameters>]
```

#### EXAMPLES

+ Example 1: Update specific SecurityMlAnalyticsSetting with specified resource group and workspace
```powershell
$setting = New-AzSentinelAnomalySecurityMlAnalyticsSettingsObject -AnomalyVersion 1.0.5 -Enabled $false -DisplayName "Login from unusual region" -Frequency (New-TimeSpan -Hours 2) -SettingsStatus Production -IsDefaultSetting $true -SettingsDefinitionId "f209187f-1d17-4431-94af-c141bf5f23db"
Update-AzSentinelSecurityMlAnalyticsSetting -ResourceGroupName "si-jj-test" -WorkspaceName "si-test-w4" -SettingsResourceName f209187f-1d17-4431-94af-c141bf5f23db -SecurityMlAnalyticsSetting $setting
```

```output
AnomalySettingsVersion       : 0
AnomalyVersion               : 1.0.5
CustomizableObservation      : {
                               }
Description                  : 
DisplayName                  : Login from unusual region
Enabled                      : False
Etag                         : "0a003319-0000-0300-0000-64d4c4510000"
Frequency                    : 02:00:00
Id                           : /subscriptions/9e223dbe-3399-4e19-88eb-0975f02ac87f/resourceGroups/si-jj-test/providers/Microsoft.OperationalInsights/workspaces/si-test-w4/provi 
                               ders/Microsoft.SecurityInsights/securityMLAnalyticsSettings/f209187f-1d17-4431-94af-c141bf5f23db
IsDefaultSetting             : True
Kind                         : Anomaly
LastModifiedUtc              : 8/10/2023 11:04:47 AM
Name                         : f209187f-1d17-4431-94af-c141bf5f23db
RequiredDataConnector        : {}
SettingsDefinitionId         : f209187f-1d17-4431-94af-c141bf5f23db
SettingsStatus               : Production
SystemDataCreatedAt          : 
SystemDataCreatedBy          : 
SystemDataCreatedByType      : 
SystemDataLastModifiedAt     : 
SystemDataLastModifiedBy     : 
SystemDataLastModifiedByType : 
Tactic                       : {}
Technique                    : {}
Type                         : Microsoft.SecurityInsights/securityMLAnalyticsSettings
```

This command updates specific SecurityMlAnalyticsSetting with specified resource group and workspace


#### Get-AzSentinelThreatIntelligenceIndicator

#### SYNOPSIS
View a threat intelligence indicator by name.

#### SYNTAX

+ List (Default)
```powershell
Get-AzSentinelThreatIntelligenceIndicator -ResourceGroupName <String> -WorkspaceName <String>
 [-SubscriptionId <String[]>] [-Filter <String>] [-Orderby <String>] [-SkipToken <String>] [-Top <Int32>]
 [-DefaultProfile <PSObject>] [<CommonParameters>]
```

+ Get
```powershell
Get-AzSentinelThreatIntelligenceIndicator -Name <String> -ResourceGroupName <String> -WorkspaceName <String>
 [-SubscriptionId <String[]>] [-DefaultProfile <PSObject>] [<CommonParameters>]
```

+ GetViaIdentity
```powershell
Get-AzSentinelThreatIntelligenceIndicator -InputObject <ISecurityInsightsIdentity>
 [-DefaultProfile <PSObject>] [<CommonParameters>]
```

+ GetViaIdentityWorkspace
```powershell
Get-AzSentinelThreatIntelligenceIndicator -Name <String> -WorkspaceInputObject <ISecurityInsightsIdentity>
 [-DefaultProfile <PSObject>] [<CommonParameters>]
```

#### EXAMPLES

+ Example 1: List all Threat Intelligence Indicators
```powershell
 Get-AzSentinelThreatIntelligenceIndicator -ResourceGroupName "myResourceGroupName" -workspaceName "myWorkspaceName"
```

```output
Kind : indicator
Name : 8ff8f736-8f9b-a180-49a2-9a395cf088ca

Kind : indicator
Name : 8afa82a1-6c4a-dca2-595f-28239965882d
```

This command lists all Threat Intelligence Indicators under a Microsoft Sentinel workspace.

+ Example 2: Get a Threat Intelligence Indicator
```powershell
 Get-AzSentinelThreatIntelligenceIndicator -ResourceGroupName "myResourceGroupName" -workspaceName "myWorkspaceName" -Name "514840ce-5582-f7a4-8562-7996e29dc07a"
```

```output
Kind : indicator
Name : 514840ce-5582-f7a4-8562-7996e29dc07a
```

This command gets a Threat Intelligence Indicator by name (Id)

+ Example 3: Get the Threat Intelligence Indicator top 3
```powershell
 $tiIndicators = Get-AzSentinelThreatIntelligenceIndicator -ResourceGroupName "myResourceGroupName" -workspaceName "myWorkspaceName" -Top 3
```

```output
Kind : indicator
Name : 8ff8f736-8f9b-a180-49a2-9a395cf088ca

Kind : indicator
Name : 8afa82a1-6c4a-dca2-595f-28239965882d

Kind : indicator
Name : 38ac867b-85f9-be4c-afd5-b3cffdcf69f1
```

This command gets a Threat Intelligence Indicator by object


#### Get-AzSentinelThreatIntelligenceIndicatorMetric

#### SYNOPSIS
Get threat intelligence indicators metrics (Indicators counts by Type, Threat Type, Source).

#### SYNTAX

```powershell
Get-AzSentinelThreatIntelligenceIndicatorMetric -ResourceGroupName <String> -WorkspaceName <String>
 [-SubscriptionId <String[]>] [-DefaultProfile <PSObject>] [<CommonParameters>]
```

#### EXAMPLES

+ Example 1: Get all metrics for Threat Intelligence Indicators
```powershell
 Get-AzSentinelThreatIntelligenceIndicatorMetric -ResourceGroupName "myResourceGroupName" -workspaceName "myWorkspaceName"
```

```output
LastUpdatedTimeUtc : 2022-02-07T10:44:45.3919348Z
PatternTypeMetric  : {network-traffic, url, ipv4-addr, file}
SourceMetric       : {Microsoft Emerging Threat Feed, Bing Safety Phishing URL, Azure Sentinel, CyberCrime…}
ThreatTypeMetric   : {botnet, maliciousurl, phishing, malicious-activity…}
```

This command gets Threat Intelligence Indicator metrics.


#### Invoke-AzSentinelThreatIntelligenceIndicatorQuery

#### SYNOPSIS
Query threat intelligence indicators as per filtering criteria.

#### SYNTAX

```powershell
Invoke-AzSentinelThreatIntelligenceIndicatorQuery -ResourceGroupName <String> -WorkspaceName <String>
 [-SubscriptionId <String>] [-Id <String[]>] [-IncludeDisabled] [-Keyword <String[]>] [-MaxConfidence <Int32>]
 [-MaxValidUntil <String>] [-MinConfidence <Int32>] [-MinValidUntil <String>] [-PageSize <Int32>]
 [-PatternType <String[]>] [-SkipToken <String>] [-SortBy <IThreatIntelligenceSortingCriteria[]>]
 [-Source <String[]>] [-ThreatType <String[]>] [-DefaultProfile <PSObject>] [-Confirm] [-WhatIf]
 [<CommonParameters>]
```

#### EXAMPLES

+ Example 1: Query all Threat Intelligence Indicators
```powershell
Invoke-AzSentinelThreatIntelligenceIndicatorQuery -ResourceGroupName "myResourceGroupName" -WorkspaceName "myWorkspaceName"
```

```output
Etag                                    Kind        Name                                    SystemDataCreatedAt SystemDataCreatedBy
----                                    ----        ----                                    ------------------- -------
"b603878e-0000-0100-0000-62d1d0010000"  indicator   f4dd9aa3-081b-2f0b-a5d7-3805954e8a39
```

This command queries TI indicators.


