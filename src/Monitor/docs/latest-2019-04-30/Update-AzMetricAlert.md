---
external help file:
Module Name: Az.Monitor
online version: https://docs.microsoft.com/en-us/powershell/module/az.monitor/update-azmetricalert
schema: 2.0.0
---

# Update-AzMetricAlert

## SYNOPSIS
Update an metric alert definition.

## SYNTAX

### UpdateExpanded (Default)
```
Update-AzMetricAlert -Name <String> -ResourceGroupName <String> [-SubscriptionId <String>]
 [-Action <IMetricAlertAction[]>] [-AutoMitigate] [-Description <String>] [-Enabled]
 [-EvaluationFrequency <TimeSpan>] [-Severity <Int32>] [-Tag <Hashtable>] [-WindowSize <TimeSpan>]
 [-DefaultProfile <PSObject>] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### UpdateExpandedByResourceId
```
Update-AzMetricAlert -Name <String> -ResourceGroupName <String> -Condition <MetricCriteria[]>
 -TargetResourceId <String> [-SubscriptionId <String>] [-Action <IMetricAlertAction[]>] [-AutoMitigate]
 [-Description <String>] [-Enabled] [-EvaluationFrequency <TimeSpan>] [-Severity <Int32>] [-Tag <Hashtable>]
 [-WindowSize <TimeSpan>] [-DefaultProfile <PSObject>] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### UpdateExpandedByScope
```
Update-AzMetricAlert -Name <String> -ResourceGroupName <String> -Condition <MetricCriteria[]>
 -TargetResourceRegion <String> -TargetResourceScope <String[]> -TargetResourceType <String>
 [-SubscriptionId <String>] [-Action <IMetricAlertAction[]>] [-AutoMitigate] [-Description <String>]
 [-Enabled] [-EvaluationFrequency <TimeSpan>] [-Severity <Int32>] [-Tag <Hashtable>] [-WindowSize <TimeSpan>]
 [-DefaultProfile <PSObject>] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### UpdateViaIdentityExpanded
```
Update-AzMetricAlert -InputObject <IMonitorIdentity> [-Action <IMetricAlertAction[]>] [-AutoMitigate]
 [-Description <String>] [-Enabled] [-EvaluationFrequency <TimeSpan>] [-Severity <Int32>] [-Tag <Hashtable>]
 [-WindowSize <TimeSpan>] [-DefaultProfile <PSObject>] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### UpdateViaIdentityExpandedByResourceId
```
Update-AzMetricAlert -InputObject <IMonitorIdentity> -Condition <MetricCriteria[]> -TargetResourceId <String>
 [-Action <IMetricAlertAction[]>] [-AutoMitigate] [-Description <String>] [-Enabled]
 [-EvaluationFrequency <TimeSpan>] [-Severity <Int32>] [-Tag <Hashtable>] [-WindowSize <TimeSpan>]
 [-DefaultProfile <PSObject>] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### UpdateViaIdentityExpandedByScope
```
Update-AzMetricAlert -InputObject <IMonitorIdentity> -Condition <MetricCriteria[]>
 -TargetResourceRegion <String> -TargetResourceScope <String[]> -TargetResourceType <String>
 [-Action <IMetricAlertAction[]>] [-AutoMitigate] [-Description <String>] [-Enabled]
 [-EvaluationFrequency <TimeSpan>] [-Severity <Int32>] [-Tag <Hashtable>] [-WindowSize <TimeSpan>]
 [-DefaultProfile <PSObject>] [-Confirm] [-WhatIf] [<CommonParameters>]
```

## DESCRIPTION
Update an metric alert definition.

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

### -Action
the array of actions that are performed when the alert rule becomes active, and when an alert condition is resolved.
To construct, see NOTES section for ACTION properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Monitor.Models.Api20180301.IMetricAlertAction[]
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -AutoMitigate
the flag that indicates whether the alert should be auto resolved or not.

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

### -Condition
The rule criteria that defines the conditions of the alert rule.
To construct, see NOTES section for CONDITION properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Monitor.Models.Api20180301.MetricCriteria[]
Parameter Sets: UpdateExpandedByResourceId, UpdateExpandedByScope, UpdateViaIdentityExpandedByResourceId, UpdateViaIdentityExpandedByScope
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
the description of the metric alert that will be included in the alert email.

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
the flag that indicates whether the metric alert is enabled.

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

### -EvaluationFrequency
how often the metric alert is evaluated represented in ISO 8601 duration format.

```yaml
Type: System.TimeSpan
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -InputObject
Identity Parameter
To construct, see NOTES section for INPUTOBJECT properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Monitor.Models.IMonitorIdentity
Parameter Sets: UpdateViaIdentityExpanded, UpdateViaIdentityExpandedByResourceId, UpdateViaIdentityExpandedByScope
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
Dynamic: False
```

### -Name
The name of the rule.

```yaml
Type: System.String
Parameter Sets: UpdateExpanded, UpdateExpandedByResourceId, UpdateExpandedByScope
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
Parameter Sets: UpdateExpanded, UpdateExpandedByResourceId, UpdateExpandedByScope
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -Severity
Alert severity {0, 1, 2, 3, 4}

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

### -SubscriptionId
The Azure subscription Id.

```yaml
Type: System.String
Parameter Sets: UpdateExpanded, UpdateExpandedByResourceId, UpdateExpandedByScope
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

### -TargetResourceId
the target resource id for rule.

```yaml
Type: System.String
Parameter Sets: UpdateExpandedByResourceId, UpdateViaIdentityExpandedByResourceId
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -TargetResourceRegion
the region of the target resource(s) on which the alert is created/updated.

```yaml
Type: System.String
Parameter Sets: UpdateExpandedByScope, UpdateViaIdentityExpandedByScope
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -TargetResourceScope
the list of resource id's that this metric alert is scoped to.

```yaml
Type: System.String[]
Parameter Sets: UpdateExpandedByScope, UpdateViaIdentityExpandedByScope
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -TargetResourceType
the resource type of the target resource(s) on which the alert is created/updated.

```yaml
Type: System.String
Parameter Sets: UpdateExpandedByScope, UpdateViaIdentityExpandedByScope
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -WindowSize
the period of time (in ISO 8601 duration format) that is used to monitor alert activity based on the threshold.

```yaml
Type: System.TimeSpan
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

### Microsoft.Azure.PowerShell.Cmdlets.Monitor.Models.IMonitorIdentity

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.Monitor.Models.Api20180301.IMetricAlertResource

## ALIASES

## NOTES

### COMPLEX PARAMETER PROPERTIES
To create the parameters described below, construct a hash table containing the appropriate properties. For information on hash tables, run Get-Help about_Hash_Tables.

#### ACTION <IMetricAlertAction[]>: the array of actions that are performed when the alert rule becomes active, and when an alert condition is resolved.
  - `[ActionGroupId <String>]`: the id of the action group to use.
  - `[WebhookProperty <IMetricAlertActionWebhookProperties>]`: The properties of a webhook object.
    - `[(Any) <String>]`: This indicates any property can be added to this object.

#### CONDITION <MetricCriteria[]>: The rule criteria that defines the conditions of the alert rule.
  - `Operator <Operator>`: the criteria operator.
  - `Threshold <Double>`: the criteria threshold value that activates the alert.
  - `CriterionType <CriterionType>`: Specifies the type of threshold criteria
  - `MetricName <String>`: Name of the metric.
  - `Name <String>`: Name of the criteria.
  - `TimeAggregation <AggregationType>`: the criteria time aggregation types.
  - `[Dimension <IMetricDimension[]>]`: List of dimension conditions.
    - `Name <String>`: Name of the dimension.
    - `Operator <String>`: the dimension operator. Only 'Include' and 'Exclude' are supported
    - `Value <String[]>`: list of dimension values.
  - `[MetricNamespace <String>]`: Namespace of the metric.

#### INPUTOBJECT <IMonitorIdentity>: Identity Parameter
  - `[ActionGroupName <String>]`: The name of the action group.
  - `[ActivityLogAlertName <String>]`: The name of the activity log alert.
  - `[AutoscaleSettingName <String>]`: The autoscale setting name.
  - `[Id <String>]`: Resource identity path
  - `[IncidentName <String>]`: The name of the incident to retrieve.
  - `[LogProfileName <String>]`: The name of the log profile.
  - `[MetricName <String>]`: The name of the metric to retrieve the baseline for.
  - `[Name <String>]`: The name of the diagnostic setting.
  - `[ResourceGroupName <String>]`: The name of the resource group.
  - `[ResourceName <String>]`: The ARM resource name
  - `[ResourceProvider <String>]`: The ARM resource provider name
  - `[ResourceTypeName <String>]`: The ARM resource type name
  - `[ResourceUri <String>]`: The identifier of the resource.
  - `[RuleName <String>]`: The name of the rule.
  - `[StatusName <String>]`: The name of the status.
  - `[SubscriptionId <String>]`: The Azure subscription Id.

## RELATED LINKS

