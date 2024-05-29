---
external help file: Microsoft.Azure.PowerShell.Cmdlets.AlertsManagement.dll-Help.xml
Module Name: Az.AlertsManagement
online version: https://learn.microsoft.com/powershell/module/az.alertsmanagement/set-azalertprocessingrule
schema: 2.0.0
---

# Set-AzAlertProcessingRule

## SYNOPSIS
Create or update an alert processing rule.

## SYNTAX

### BySimplifiedFormatSuppressionActionRule (Default)
```
Set-AzAlertProcessingRule -ResourceGroupName <String> -Name <String> [-Description <String>]
 [-Enabled <String>] -Scope <System.Collections.Generic.List`1[System.String]> [-Tag <Hashtable>]
 [-FilterSeverity <String>] [-FilterMonitorService <String>] [-FilterMonitorCondition <String>]
 [-FilterTargetResource <String>] [-FilterTargetResourceType <String>] [-FilterTargetResourceGroup <String>]
 [-FilterAlertRuleId <String>] [-FilterAlertRuleName <String>] [-FilterDescription <String>]
 [-FilterAlertContext <String>] [-FilterSignalType <String>] -AlertProcessingRuleType <String>
 [-ScheduleStartDateTime <String>] [-ScheduleEndDateTime <String>] [-ScheduleTimeZone <String>]
 [-ScheduleReccurenceType <String>] [-ScheduleReccurence2Type <String>]
 [-ScheduleReccurenceDaysOfWeek <String>] [-ScheduleReccurence2DaysOfWeek <String>]
 [-ScheduleReccurenceDaysOfMonth <String>] [-ScheduleReccurence2DaysOfMonth <String>]
 [-ScheduleReccurenceStartTime <String>] [-ScheduleReccurence2StartTime <String>]
 [-ScheduleReccurenceEndTime <String>] [-ScheduleReccurence2EndTime <String>]
 [-DefaultProfile <IAzureContextContainer>] [-WhatIf] [-Confirm]
 [<CommonParameters>]
```

### ByInputObject
```
Set-AzAlertProcessingRule -InputObject <PSAlertProcessingRule> [-DefaultProfile <IAzureContextContainer>]
 [-WhatIf] [-Confirm] [<CommonParameters>]
```

### BySimplifiedFormatActionGroupActionRule
```
Set-AzAlertProcessingRule -ResourceGroupName <String> -Name <String> [-Description <String>]
 [-Enabled <String>] -Scope <System.Collections.Generic.List`1[System.String]> [-Tag <Hashtable>]
 [-FilterSeverity <String>] [-FilterMonitorService <String>] [-FilterMonitorCondition <String>]
 [-FilterTargetResource <String>] [-FilterTargetResourceType <String>] [-FilterTargetResourceGroup <String>]
 [-FilterAlertRuleId <String>] [-FilterAlertRuleName <String>] [-FilterDescription <String>]
 [-FilterAlertContext <String>] [-FilterSignalType <String>] -AlertProcessingRuleType <String>
 [-ScheduleStartDateTime <String>] [-ScheduleEndDateTime <String>] [-ScheduleTimeZone <String>]
 [-ScheduleReccurenceType <String>] [-ScheduleReccurence2Type <String>]
 [-ScheduleReccurenceDaysOfWeek <String>] [-ScheduleReccurence2DaysOfWeek <String>]
 [-ScheduleReccurenceDaysOfMonth <String>] [-ScheduleReccurence2DaysOfMonth <String>]
 [-ScheduleReccurenceStartTime <String>] [-ScheduleReccurence2StartTime <String>]
 [-ScheduleReccurenceEndTime <String>] [-ScheduleReccurence2EndTime <String>] -ActionGroupId <String>
 [-DefaultProfile <IAzureContextContainer>] [-WhatIf] [-Confirm]
 [<CommonParameters>]
```

## DESCRIPTION
**Set-AzAlertProcessingRule** creates or updates an alert processing rule.

## EXAMPLES

### Example 1
```powershell
Set-AzAlertProcessingRule -ResourceGroupName "test-rg" -Name "AddActionGroupToSubscription" -Scope "/subscriptions/MySubscriptionId" -Description "Add ActionGroup1 to all alerts in the subscription" -Enabled "True" -AlertProcessingRuleType "AddActionGroups" -ActionGroupId "/subscriptions/MySubscriptionId/resourcegroups/MyResourceGroup1/providers/microsoft.insights/actiongroups/ActionGroup1"
```

This cmdlet creates an alert processing rule that adds an action group to all alerts in a resource group.

### Example 2
```powershell
Set-AzAlertProcessingRule -ResourceGroupName "test-rg" -Name "AddActionGroupsBySeverity" -Scope "/subscriptions/MySubscriptionId" -Description "Add AGId1 and AGId2 to all Sev0 and Sev1 alerts in these resourceGroups" -Enabled "True" -AlertProcessingRuleType "AddActionGroups" -ActionGroupId "/subscriptions/MySubscriptionId/resourcegroups/MyResourceGroup1/providers/microsoft.insights/actiongroups/ActionGroup1,/subscriptions/MySubscriptionId/resourceGroups/MyResourceGroup2/providers/microsoft.insights/actionGroups/MyActionGroup2" -FilterMonitorCondition "Equals:Sev0,Sev1"
```

This cmdlet creates a rule that adds two action groups to all Sev0 and Sev1 alerts

## PARAMETERS

### -ActionGroupId
Action Group Ids which are to be notified, Comma separated list of values
Required only if alert processing rule type is AddActionGroups.


```yaml
Type: System.String
Parameter Sets: BySimplifiedFormatActionGroupActionRule
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -AlertProcessingRuleType
Alert Processing rule Type. Allowed values: AddActionGroups, RemoveAllActionGroups.

```yaml
Type: System.String
Parameter Sets: BySimplifiedFormatSuppressionActionRule, BySimplifiedFormatActionGroupActionRule
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -DefaultProfile
The credentials, account, tenant, and subscription used for communication with Azure.

```yaml
Type: Microsoft.Azure.Commands.Common.Authentication.Abstractions.Core.IAzureContextContainer
Parameter Sets: (All)
Aliases: AzContext, AzureRmContext, AzureCredential

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Description
Description of Alert Processing Rule

```yaml
Type: System.String
Parameter Sets: BySimplifiedFormatSuppressionActionRule, BySimplifiedFormatActionGroupActionRule
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Enabled
Indicate if the given alert processing rule is enabled or disabled (default is enabled).  Allowed values: False, True.

```yaml
Type: System.String
Parameter Sets: BySimplifiedFormatSuppressionActionRule, BySimplifiedFormatActionGroupActionRule
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -FilterAlertContext
Expected format - {\<operation\>:\<comma separated list of values\>}  operation: one of <Equals, NotEquals, Contains, DoesNotContain>
For eg. 
Contains:smartgroups

```yaml
Type: System.String
Parameter Sets: BySimplifiedFormatSuppressionActionRule, BySimplifiedFormatActionGroupActionRule
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -FilterAlertRuleId
Expected format - {\<operation\>:\<comma separated list of values\>}  operation: one of <Equals, NotEquals, Contains, DoesNotContain>
For eg.
Equals:/subscriptions/MySubscriptionId/resourceGroups/abvarma/providers/microsoft.insights/metricAlerts/test-mrmc-vm-abvarma

```yaml
Type: System.String
Parameter Sets: BySimplifiedFormatSuppressionActionRule, BySimplifiedFormatActionGroupActionRule
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -FilterAlertRuleName
Expected format - {\<operation\>:\<comma separated list of values\>}  operation: one of <Equals, NotEquals, Contains, DoesNotContain>
For eg.
Equals:ARM Name Test1,ARM Name Test2


```yaml
Type: System.String
Parameter Sets: BySimplifiedFormatSuppressionActionRule, BySimplifiedFormatActionGroupActionRule
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -FilterDescription
Expected format - {\<operation\>:\<comma separated list of values\>} operation: one of <Equals, NotEquals, Contains, DoesNotContain>
For eg.
Contains:Test Alert

```yaml
Type: System.String
Parameter Sets: BySimplifiedFormatSuppressionActionRule, BySimplifiedFormatActionGroupActionRule
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -FilterMonitorCondition
Expected format - {\<operation\>:\<comma separated list of values\>} operation: one of <Equals, NotEquals, Contains, DoesNotContain>
For eg.
NotEquals:Resolved

```yaml
Type: System.String
Parameter Sets: BySimplifiedFormatSuppressionActionRule, BySimplifiedFormatActionGroupActionRule
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -FilterMonitorService
Expected format - {\<operation\>:\<comma separated list of values\>} operation: one of <Equals, NotEquals, Contains, DoesNotContain>
For eg.
Equals:Platform,Log Analytics

```yaml
Type: System.String
Parameter Sets: BySimplifiedFormatSuppressionActionRule, BySimplifiedFormatActionGroupActionRule
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -FilterSeverity
Expected format - {\<operation\>:\<comma separated list of values\>} severity: one of <Sev0, Sev1, Sev2, Sev3, Sev4>.
For eg.
Equals:Sev0,Sev1

```yaml
Type: System.String
Parameter Sets: BySimplifiedFormatSuppressionActionRule, BySimplifiedFormatActionGroupActionRule
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -FilterSignalType
Expected format - {\<operation\>:\<comma separated list of values\>}  operation: one of <Equals, NotEquals, Contains, DoesNotContain>
For eg.
Equals:Metric

```yaml
Type: System.String
Parameter Sets: BySimplifiedFormatSuppressionActionRule, BySimplifiedFormatActionGroupActionRule
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -FilterTargetResource
Expected format - {\<operation\>:\<comma separated list of values\>}  operation: one of <Equals, NotEquals, Contains, DoesNotContain>
For eg.
Equals:mySQLDataBaseName

```yaml
Type: System.String
Parameter Sets: BySimplifiedFormatSuppressionActionRule, BySimplifiedFormatActionGroupActionRule
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -FilterTargetResourceGroup
Expected format - {\<operation\>:\<comma separated list of values\>}  operation: one of <Equals, NotEquals, Contains, DoesNotContain>
For eg.
NotEquals:/subscriptions/\<subscriptionID\>/resourceGroups/test

```yaml
Type: System.String
Parameter Sets: BySimplifiedFormatSuppressionActionRule, BySimplifiedFormatActionGroupActionRule
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -FilterTargetResourceType
Expected format - {\<operation\>:\<comma separated list of values\>}  operation: one of <Equals, NotEquals, Contains, DoesNotContain>
For eg.
Contains:Virtual Machines,Storage Account

```yaml
Type: System.String
Parameter Sets: BySimplifiedFormatSuppressionActionRule, BySimplifiedFormatActionGroupActionRule
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -InputObject
The alert processing rule resource

```yaml
Type: Microsoft.Azure.Commands.AlertsManagement.OutputModels.PSAlertProcessingRule
Parameter Sets: ByInputObject
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -Name
Alert Processing Rule Name

```yaml
Type: System.String
Parameter Sets: BySimplifiedFormatSuppressionActionRule, BySimplifiedFormatActionGroupActionRule
Aliases: ResourceId

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ResourceGroupName
Resource Group Name

```yaml
Type: System.String
Parameter Sets: BySimplifiedFormatSuppressionActionRule, BySimplifiedFormatActionGroupActionRule
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ScheduleEndDateTime
End Date Time. Format 2022-09-21 06:00:00
Should be mentioned in case of Reccurent  Schedule - Daily, Weekly or Monthly.

```yaml
Type: System.String
Parameter Sets: BySimplifiedFormatSuppressionActionRule, BySimplifiedFormatActionGroupActionRule
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ScheduleReccurence2DaysOfMonth
List of recurrence pattern values Expected format For a monthly recurrence type.
comma separated list of values  For eg. 1,3,12

```yaml
Type: System.String
Parameter Sets: BySimplifiedFormatSuppressionActionRule, BySimplifiedFormatActionGroupActionRule
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ScheduleReccurence2DaysOfWeek
List of recurrence pattern values Expected format For a weekly recurrence type.
comma separated list of values For eg. Monday,Saturday

```yaml
Type: System.String
Parameter Sets: BySimplifiedFormatSuppressionActionRule, BySimplifiedFormatActionGroupActionRule
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ScheduleReccurence2EndTime
Reccurence Start Time in the timezone of ScheduleTimeZone parameter. Format 06:00:00
Should be mentioned in case of Reccurent  Schedule - Daily, Weekly or Monthly.

```yaml
Type: System.String
Parameter Sets: BySimplifiedFormatSuppressionActionRule, BySimplifiedFormatActionGroupActionRule
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ScheduleReccurence2StartTime
Reccurence Start Time in the timezone of ScheduleTimeZone parameter. Format 06:00:00
Should be mentioned in case of Reccurent  Schedule - Daily, Weekly or Monthly.

```yaml
Type: System.String
Parameter Sets: BySimplifiedFormatSuppressionActionRule, BySimplifiedFormatActionGroupActionRule
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ScheduleReccurence2Type
Specifies when the processing rule should be applied.
Allowed values: Daily, Monthly, Weekly.

```yaml
Type: System.String
Parameter Sets: BySimplifiedFormatSuppressionActionRule, BySimplifiedFormatActionGroupActionRule
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ScheduleReccurenceDaysOfMonth
List of recurrence pattern values Expected format For a monthly recurrence type.
comma separated list of values  For eg. 1,3,12

```yaml
Type: System.String
Parameter Sets: BySimplifiedFormatSuppressionActionRule, BySimplifiedFormatActionGroupActionRule
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ScheduleReccurenceDaysOfWeek
List of recurrence pattern values Expected format For a weekly recurrence type.
comma separated list of values For eg. Monday,Saturday

```yaml
Type: System.String
Parameter Sets: BySimplifiedFormatSuppressionActionRule, BySimplifiedFormatActionGroupActionRule
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ScheduleReccurenceEndTime
Reccurence Start Time in the timezone of ScheduleTimeZone parameter. Format 06:00:00
Should be mentioned in case of Reccurent  Schedule - Daily, Weekly or Monthly.

```yaml
Type: System.String
Parameter Sets: BySimplifiedFormatSuppressionActionRule, BySimplifiedFormatActionGroupActionRule
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ScheduleReccurenceStartTime
Reccurence Start Time in the timezone of ScheduleTimeZone parameter. Format 06:00:00
Should be mentioned in case of Reccurent  Schedule - Daily, Weekly or Monthly.

```yaml
Type: System.String
Parameter Sets: BySimplifiedFormatSuppressionActionRule, BySimplifiedFormatActionGroupActionRule
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ScheduleReccurenceType
Specifies when the processing rule should be applied.
Allowed values: Daily, Monthly, Weekly.

```yaml
Type: System.String
Parameter Sets: BySimplifiedFormatSuppressionActionRule, BySimplifiedFormatActionGroupActionRule
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ScheduleStartDateTime
Start Date Time. Format 2022-09-21 06:00:00
Should be mentioned in case of Reccurent  Schedule - Daily, Weekly or Monthly.

```yaml
Type: System.String
Parameter Sets: BySimplifiedFormatSuppressionActionRule, BySimplifiedFormatActionGroupActionRule
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ScheduleTimeZone
Schedule time zone.  Default: UTC.

```yaml
Type: System.String
Parameter Sets: BySimplifiedFormatSuppressionActionRule, BySimplifiedFormatActionGroupActionRule
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Scope
List of resource IDs, Comma separated list of values
The rule will apply to alerts that fired on resources within that scope

```yaml
Type: System.Collections.Generic.List`1[System.String]
Parameter Sets: BySimplifiedFormatSuppressionActionRule, BySimplifiedFormatActionGroupActionRule
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Tag
Alert Processing rule tags.
For eg.
@{"tag1" = "key1";"tag2" = "key2"}
Use {} to clear existing tags. 

```yaml
Type: System.Collections.Hashtable
Parameter Sets: BySimplifiedFormatSuppressionActionRule, BySimplifiedFormatActionGroupActionRule
Aliases:

Required: False
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
Shows what would happen if the cmdlet runs. The cmdlet is not run.

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

### Microsoft.Azure.Commands.AlertsManagement.OutputModels.PSActionRule

## OUTPUTS

### Microsoft.Azure.Commands.AlertsManagement.OutputModels.PSActionRule

## NOTES

## RELATED LINKS
