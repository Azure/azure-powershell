---
external help file:
Module Name: Az.AlertsManagement
online version: https://learn.microsoft.com/powershell/module/az.alertsmanagement/new-azprometheusrulegroup
schema: 2.0.0
---

# New-AzPrometheusRuleGroup

## SYNOPSIS
Create or update a Prometheus rule group definition.

## SYNTAX

### CreateViaIdentity (Default)
```
New-AzPrometheusRuleGroup -InputObject <IAlertsIdentity> -Parameter <IPrometheusRuleGroupResource>
 [-DefaultProfile <PSObject>] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### Create
```
New-AzPrometheusRuleGroup -ResourceGroupName <String> -RuleGroupName <String>
 -Parameter <IPrometheusRuleGroupResource> [-SubscriptionId <String>] [-DefaultProfile <PSObject>] [-Confirm]
 [-WhatIf] [<CommonParameters>]
```

### CreateExpanded
```
New-AzPrometheusRuleGroup -ResourceGroupName <String> -RuleGroupName <String> -Location <String>
 -Rule <IPrometheusRule[]> -Scope <String[]> [-SubscriptionId <String>] [-ClusterName <String>]
 [-Description <String>] [-Enabled] [-Interval <String>] [-Tag <Hashtable>] [-DefaultProfile <PSObject>]
 [-Confirm] [-WhatIf] [<CommonParameters>]
```

### CreateViaIdentityExpanded
```
New-AzPrometheusRuleGroup -InputObject <IAlertsIdentity> -Location <String> -Rule <IPrometheusRule[]>
 -Scope <String[]> [-ClusterName <String>] [-Description <String>] [-Enabled] [-Interval <String>]
 [-Tag <Hashtable>] [-DefaultProfile <PSObject>] [-Confirm] [-WhatIf] [<CommonParameters>]
```

## DESCRIPTION
Create or update a Prometheus rule group definition.

## EXAMPLES

### Example 1: Create a Prometheus rule group definition.
```powershell
ew-AzPrometheusRuleGroup -ResourceGroupName MyResourceGroup -RuleGroupName RuleGroup1 -Location "East Us" -Rule $rule -Scope "/subscriptions/{subscription}/resourcegroups/MyResourceGroup/providers/microsoft.monitor/accounts/MyMonitor"
```

```output
Name       Location Interval ClusterName Enabled
----       -------- -------- ----------- -------
RuleGroup2 East Us
```

Create a Prometheus rule group definition.

## PARAMETERS

### -ClusterName
the cluster name of the rule group evaluation.

```yaml
Type: System.String
Parameter Sets: CreateExpanded, CreateViaIdentityExpanded
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
the description of the Prometheus rule group that will be included in the alert email.

```yaml
Type: System.String
Parameter Sets: CreateExpanded, CreateViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Enabled
the flag that indicates whether the Prometheus rule group is enabled.

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: CreateExpanded, CreateViaIdentityExpanded
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
Type: Microsoft.Azure.PowerShell.Cmdlets.Alerts.Models.IAlertsIdentity
Parameter Sets: CreateViaIdentity, CreateViaIdentityExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -Interval
the interval in which to run the Prometheus rule group represented in ISO 8601 duration format.
Should be between 1 and 15 minutes

```yaml
Type: System.String
Parameter Sets: CreateExpanded, CreateViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Location
The geo-location where the resource lives

```yaml
Type: System.String
Parameter Sets: CreateExpanded, CreateViaIdentityExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Parameter
The Prometheus rule group resource.
To construct, see NOTES section for PARAMETER properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Alerts.Models.Api20210722Preview.IPrometheusRuleGroupResource
Parameter Sets: Create, CreateViaIdentity
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
Parameter Sets: Create, CreateExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Rule
defines the rules in the Prometheus rule group.
To construct, see NOTES section for RULE properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Alerts.Models.Api20210722Preview.IPrometheusRule[]
Parameter Sets: CreateExpanded, CreateViaIdentityExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -RuleGroupName
The name of the rule group.

```yaml
Type: System.String
Parameter Sets: Create, CreateExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Scope
the list of resource id's that this rule group is scoped to.

```yaml
Type: System.String[]
Parameter Sets: CreateExpanded, CreateViaIdentityExpanded
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
Parameter Sets: Create, CreateExpanded
Aliases:

Required: False
Position: Named
Default value: (Get-AzContext).Subscription.Id
Accept pipeline input: False
Accept wildcard characters: False
```

### -Tag
Resource tags.

```yaml
Type: System.Collections.Hashtable
Parameter Sets: CreateExpanded, CreateViaIdentityExpanded
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

### Microsoft.Azure.PowerShell.Cmdlets.Alerts.Models.Api20210722Preview.IPrometheusRuleGroupResource

### Microsoft.Azure.PowerShell.Cmdlets.Alerts.Models.IAlertsIdentity

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.Alerts.Models.Api20210722Preview.IPrometheusRuleGroupResource

## NOTES

ALIASES

COMPLEX PARAMETER PROPERTIES

To create the parameters described below, construct a hash table containing the appropriate properties. For information on hash tables, run Get-Help about_Hash_Tables.


`INPUTOBJECT <IAlertsIdentity>`: Identity Parameter
  - `[Id <String>]`: Resource identity path
  - `[ResourceGroupName <String>]`: The name of the resource group. The name is case insensitive.
  - `[RuleGroupName <String>]`: The name of the rule group.
  - `[SubscriptionId <String>]`: The ID of the target subscription.

`PARAMETER <IPrometheusRuleGroupResource>`: The Prometheus rule group resource.
  - `Location <String>`: The geo-location where the resource lives
  - `Rule <IPrometheusRule[]>`: defines the rules in the Prometheus rule group.
    - `Expression <String>`: the expression to run for the rule.
    - `[Action <IPrometheusRuleGroupAction[]>]`: The array of actions that are performed when the alert rule becomes active, and when an alert condition is resolved. Only relevant for alerts.
      - `[ActionGroupId <String>]`: The resource id of the action group to use.
      - `[ActionProperty <IPrometheusRuleGroupActionProperties>]`: The properties of an action group object.
        - `[(Any) <String>]`: This indicates any property can be added to this object.
    - `[Alert <String>]`: the name of the alert rule.
    - `[Annotation <IPrometheusRuleAnnotations>]`: annotations for rule group. Only relevant for alerts.
      - `[(Any) <String>]`: This indicates any property can be added to this object.
    - `[Enabled <Boolean?>]`: the flag that indicates whether the Prometheus rule is enabled.
    - `[For <String>]`: the amount of time alert must be active before firing. Only relevant for alerts.
    - `[Label <IPrometheusRuleLabels>]`: labels for rule group. Only relevant for alerts.
      - `[(Any) <String>]`: This indicates any property can be added to this object.
    - `[Record <String>]`: the name of the recording rule.
    - `[ResolveConfigurationAutoResolved <Boolean?>]`: the flag that indicates whether or not to auto resolve a fired alert.
    - `[ResolveConfigurationTimeToResolve <String>]`: the duration a rule must evaluate as healthy before the fired alert is automatically resolved represented in ISO 8601 duration format. Should be between 1 and 15 minutes
    - `[Severity <Int32?>]`: the severity of the alerts fired by the rule. Only relevant for alerts.
  - `Scope <String[]>`: the list of resource id's that this rule group is scoped to.
  - `[Tag <ITrackedResourceTags>]`: Resource tags.
    - `[(Any) <String>]`: This indicates any property can be added to this object.
  - `[SystemDataCreatedAt <DateTime?>]`: The timestamp of resource creation (UTC).
  - `[SystemDataCreatedBy <String>]`: The identity that created the resource.
  - `[SystemDataCreatedByType <CreatedByType?>]`: The type of identity that created the resource.
  - `[SystemDataLastModifiedAt <DateTime?>]`: The timestamp of resource last modification (UTC)
  - `[SystemDataLastModifiedBy <String>]`: The identity that last modified the resource.
  - `[SystemDataLastModifiedByType <CreatedByType?>]`: The type of identity that last modified the resource.
  - `[ClusterName <String>]`: the cluster name of the rule group evaluation.
  - `[Description <String>]`: the description of the Prometheus rule group that will be included in the alert email.
  - `[Enabled <Boolean?>]`: the flag that indicates whether the Prometheus rule group is enabled.
  - `[Interval <String>]`: the interval in which to run the Prometheus rule group represented in ISO 8601 duration format. Should be between 1 and 15 minutes

`RULE <IPrometheusRule[]>`: defines the rules in the Prometheus rule group.
  - `Expression <String>`: the expression to run for the rule.
  - `[Action <IPrometheusRuleGroupAction[]>]`: The array of actions that are performed when the alert rule becomes active, and when an alert condition is resolved. Only relevant for alerts.
    - `[ActionGroupId <String>]`: The resource id of the action group to use.
    - `[ActionProperty <IPrometheusRuleGroupActionProperties>]`: The properties of an action group object.
      - `[(Any) <String>]`: This indicates any property can be added to this object.
  - `[Alert <String>]`: the name of the alert rule.
  - `[Annotation <IPrometheusRuleAnnotations>]`: annotations for rule group. Only relevant for alerts.
    - `[(Any) <String>]`: This indicates any property can be added to this object.
  - `[Enabled <Boolean?>]`: the flag that indicates whether the Prometheus rule is enabled.
  - `[For <String>]`: the amount of time alert must be active before firing. Only relevant for alerts.
  - `[Label <IPrometheusRuleLabels>]`: labels for rule group. Only relevant for alerts.
    - `[(Any) <String>]`: This indicates any property can be added to this object.
  - `[Record <String>]`: the name of the recording rule.
  - `[ResolveConfigurationAutoResolved <Boolean?>]`: the flag that indicates whether or not to auto resolve a fired alert.
  - `[ResolveConfigurationTimeToResolve <String>]`: the duration a rule must evaluate as healthy before the fired alert is automatically resolved represented in ISO 8601 duration format. Should be between 1 and 15 minutes
  - `[Severity <Int32?>]`: the severity of the alerts fired by the rule. Only relevant for alerts.

## RELATED LINKS

