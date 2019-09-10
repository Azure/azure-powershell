---
external help file:
Module Name: Az.Monitor
online version: https://docs.microsoft.com/en-us/powershell/module/az.monitor/set-azscheduledqueryrule
schema: 2.0.0
---

# Set-AzScheduledQueryRule

## SYNOPSIS
Creates or updates an log search rule.

## SYNTAX

```
Set-AzScheduledQueryRule -Name <String> -ResourceGroupName <String> -AlertingAction <AlertingAction>
 -Location <String> -SourceDataSourceId <String> [-SubscriptionId <String>] [-Description <String>]
 [-ScheduleFrequencyInMinute <Int32>] [-ScheduleTimeWindowInMinute <Int32>]
 [-SourceAuthorizedResource <String[]>] [-SourceQuery <String>] [-SourceQueryType <QueryType>]
 [-Tag <Hashtable>] [-DefaultProfile <PSObject>] [-Enabled] [-Confirm] [-WhatIf] [<CommonParameters>]
```

## DESCRIPTION
Creates or updates an log search rule.

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

### -AlertingAction
The scheduled query rule Alerting Action.
To construct, see NOTES section for ALERTINGACTION properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Monitor.Models.Api20180416.AlertingAction
Parameter Sets: (All)
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
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
Dynamic: False
```

### -Description
The description of the Log Search rule.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -Enabled
The flag which indicates whether the Log Search rule is enabled or not.

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -Location
Resource location

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -Name
The name of the rule.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -ResourceGroupName
The name of the resource group.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -ScheduleFrequencyInMinute
frequency (in minutes) at which rule condition should be evaluated.

```yaml
Type: System.Int32
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -ScheduleTimeWindowInMinute
Time window for which data needs to be fetched for query (should be greater than or equal to frequencyInMinutes).

```yaml
Type: System.Int32
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -SourceAuthorizedResource
List of Resource referred into query

```yaml
Type: System.String[]
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -SourceDataSourceId
The resource uri over which log search query is to be run.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -SourceQuery
Log search query.
Required for action type - AlertingAction

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -SourceQueryType
Set value to 'ResultCount' .

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Monitor.Support.QueryType
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -SubscriptionId
The Azure subscription Id.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: (Get-AzContext).Subscription.Id
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -Tag
Resource tags

```yaml
Type: System.Collections.Hashtable
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
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
Dynamic: False
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
Dynamic: False
```

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see [about_CommonParameters](http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.Monitor.Models.Api20180416.ILogSearchRuleResource

## ALIASES

## NOTES

### COMPLEX PARAMETER PROPERTIES
To create the parameters described below, construct a hash table containing the appropriate properties. For information on hash tables, run Get-Help about_Hash_Tables.

#### ALERTINGACTION <AlertingAction>: The scheduled query rule Alerting Action.
  - `Severity <AlertSeverity>`: Severity of the alert
  - `TriggerThreshold <Double>`: Result or count threshold based on which rule should be triggered.
  - `TriggerThresholdOperator <ConditionalOperator>`: Evaluation operation for rule - 'GreaterThan' or 'LessThan.
  - `OdataType <String>`: Specifies the action. Supported values - AlertingAction, LogToMetricAction
  - `[AznActionCustomWebhookPayload <String>]`: Custom payload to be sent for all webhook URI in Azure action group
  - `[AznActionEmailSubject <String>]`: Custom subject override for all email ids in Azure action group
  - `[AznActionGroup <String[]>]`: Azure Action Group reference.
  - `[MetricTriggerMetricColumn <String>]`: Evaluation of metric on a particular column
  - `[MetricTriggerThreshold <Double?>]`: The threshold of the metric trigger.
  - `[MetricTriggerThresholdOperator <ConditionalOperator?>]`: Evaluation operation for Metric -'GreaterThan' or 'LessThan' or 'Equal'.
  - `[MetricTriggerType <MetricTriggerType?>]`: Metric Trigger Type - 'Consecutive' or 'Total'
  - `[ThrottlingInMin <Int32?>]`: time (in minutes) for which Alerts should be throttled or suppressed.

## RELATED LINKS

