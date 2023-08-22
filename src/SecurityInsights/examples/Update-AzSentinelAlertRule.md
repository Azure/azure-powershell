### Example 1: Update a scheduled alert rule
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